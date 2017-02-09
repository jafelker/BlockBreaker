using UnityEngine;

public class Brick : MonoBehaviour {

	public static int breakableCount;
	public Sprite[] hitSprites;
	public AudioClip crack;

	private int timesHit;
	private bool isBreakable;
	private LevelManager levelManager;

	void OnCollisionEnter2D(Collision2D collision){
		if(this.isBreakable) {
			//AudioSource.PlayClipAtPoint(crack,transform.position, 0.1f);
			HandleHits();
		}
	}

	void HandleHits() {
	    this.timesHit++;
		int maxHits = this.hitSprites.Length;
		if(this.timesHit >= maxHits) {
			breakableCount--;
		    this.levelManager.BrickDestroyed();
			Destroy(this.gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites() {
		int spriteIndex = this.timesHit;
		if (this.hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = this.hitSprites [spriteIndex];
		}
		else {
			Debug.LogError("sprite index invalid");
		}
	}

	void Start () {
	    this.timesHit = 0;
	    this.isBreakable = (this.CompareTag("Breakable"));
		if(isBreakable) {
			breakableCount++;
		}
//	    breakableCount = 1;
	    this.levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void Update () {

	}
}
