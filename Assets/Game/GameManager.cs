using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool recording = true;
    private bool isPaused = false;
    private float fixedDeltaTime;

    void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
        PlayerPrefsManager.DeleteAll();
        //CheckLevesUnlocked();
        PlayerPrefsManager.UnlockLevel(0);
        //CheckLevesUnlocked();

    }

    void Update() {
        if (CrossPlatformInputManager.GetButton("Fire1")) {
            recording = false;
        } else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            PauseUnpauseGame();
        }
    }

    void CheckLevesUnlocked() {
        int numberOfLevels = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < numberOfLevels; i++) {
            print("Level " + i + " of " + numberOfLevels + " is unlocked: " + PlayerPrefsManager.IsLevelUnlocked(i));
        }
    }

    void PauseUnpauseGame() {
        if (isPaused) {
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
            isPaused = false;
        } else {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            isPaused = true;
        }
    }

    void OnApplicationPause(bool pause) {
        isPaused = pause;
        PauseUnpauseGame();
    }

}
