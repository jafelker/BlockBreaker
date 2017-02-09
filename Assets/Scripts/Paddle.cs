using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start () {
	    this.ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}
	void MoveWithMouse() {
	    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float mousePosInBlocks = Input.mousePosition.x/Screen.width*16 - 0.5f;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp(worldPos.x -0.5f, 0f, 15f), this.transform.position.y, -1f);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3(Mathf.Clamp(this.ball.transform.position.x-0.5f,0f,15f),this.transform.position.y,-1f);
		this.transform.position = paddlePos;
	}
}
