using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Button playAgainButton;  // Reference to the play again button

    void Start()
    {
        // Attach the listener to the button (make sure it's assigned in the Inspector)
        if (playAgainButton != null)
        {
            playAgainButton.onClick.AddListener(OnPlayAgainClicked);
        }
    }

    void Update()
    {
        // When the user clicks the space bar, move to the next scene if the current scene is the first scene
        if (Input.GetKeyDown(KeyCode.Space) && (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0))
        {
            // Load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }

    // This function will be called when the "Play Again" button is clicked
    public void OnPlayAgainClicked()
    {
        // Load the first scene (assuming it's the game scene)
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);  // Replace "0" with the build index of the first screen if necessary
    }

   
}
