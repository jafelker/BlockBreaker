using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    public static bool hasStarted;
    // Use this for initialization
    private void Start () {
        hasStarted = false;
        this.paddle = FindObjectOfType<Paddle>();
        this.paddleToBallVector = this.transform.position - this.paddle.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 rightTweak = new Vector2(Random.Range(0f,0.2f),0f);
        Vector2 leftTweak = new Vector2(Random.Range(-0.2f,0),0f);
        Vector2 downTweak = new Vector2(0f,Random.Range(-0.2f,0));
        if (!hasStarted || collision.gameObject.CompareTag("Breakable")) return;
        //audio.Play();
        if(this.transform.position.x < 8 && Math.Abs(GetComponent<Rigidbody2D>().velocity.x) < 0.1) {
            //Debug.Log("ball x pos less than 8 and x vel == 0");
            GetComponent<Rigidbody2D>().velocity += rightTweak;
        }else if(this.transform.position.x >= 8 && Math.Abs(GetComponent<Rigidbody2D>().velocity.x) < 0.1) {
            //Debug.Log("ball x pos greater than 8 and x vel == 0");
            GetComponent<Rigidbody2D>().velocity += leftTweak;
        }else if(Math.Abs(GetComponent<Rigidbody2D>().velocity.y) < 0.1) {
            GetComponent<Rigidbody2D>().velocity += downTweak;
        }
    }
	
    // Update is called once per frame
    void Update () {
        if(!hasStarted) {
            this.transform.position = this.paddle.transform.position + this.paddleToBallVector;
        }
        if (!Input.GetMouseButtonDown(0) || hasStarted) return;
        print ("mouse clicked, launch ball");
        hasStarted = true;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.2f,0.2f),7f);
    }
}