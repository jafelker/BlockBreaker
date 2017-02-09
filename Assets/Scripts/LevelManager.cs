using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    void Awake() {
        //if(Application.loadedLevelName == "Win Screen") {
        //	LifeManager.livesLeft = 0;
        //}
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Win Screen"))) {
            LifeManager.livesLeft = 0;
        } 
    }

    public void LoadLevel(string sceneName){
        Debug.Log ("New Level load: " + sceneName);
        Brick.breakableCount = 0;
        //Application.LoadLevel (name);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitRequest(){
        Debug.Log ("Quit requested");
        Application.Quit ();
    }
    public void LoadNextLevel() {
        Brick.breakableCount = 0;
//		Application.LoadLevel(Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void BrickDestroyed() {
        if(Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }

    public void DroppedBall() {
        LifeManager.livesLeft--;
        Debug.Log(LifeManager.livesLeft);
        if(LifeManager.livesLeft <=0) {
            LoadLevel ("Lose Screen");
        } else {
            Ball.hasStarted = false;
        }
    }
}