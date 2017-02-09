using UnityEngine;

public class LoseCollider : MonoBehaviour {
	public LevelManager levelManager;


    void OnTriggerEnter2D(Collider2D coll) {
		HandleDropedBall();
	}
	void OnCollisionEnter2D(Collision2D collision) {
		print ("collision");
	}
	void Start () {
	    this.levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void Update () {
	
	}

	public void HandleDropedBall() {
	    this.levelManager.DroppedBall();
	}
}
