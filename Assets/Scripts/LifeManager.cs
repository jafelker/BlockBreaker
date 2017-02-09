using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
	static LifeManager instance;
	public static int livesLeft {
		get { return _livesLeft; }
		set {
			_livesLeft = value;
		    if (lifeText == null) return;
			lifeText.text = "Lives: " + _livesLeft;
		}
	}
	private static int _livesLeft;
	public static Text lifeText;

	void Awake () {
		lifeText = GetComponent<Text>();
	}
	void Start() {
	    livesLeft = livesLeft <= 0 ? 3 : livesLeft;
	}
}
