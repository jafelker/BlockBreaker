using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	// Use this for initialization
	void Awake () {
		if(instance != null) {
			Destroy (this.gameObject);
			print ("duplicate music player self destructing");
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
