using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Tetrominos;
    public float movementFrequency = 0.8f;
    private float passedTime = 0;
    private float currentMovementFrequency;
    private GameObject currentTetromino;
    private bool isGameOver = false;  // Add a game over flag
    
    void Start()
    {
        currentMovementFrequency = movementFrequency;
        SpawnTetromino();
    }

    void Update()
    {
        // Check if the game is over
        if (isGameOver)
            return; // Stop all game logic if the game is over

        passedTime += Time.deltaTime;

        // Move Tetromino based on the movement frequency
        if (passedTime >= currentMovementFrequency)
        {
            passedTime -= currentMovementFrequency;
            MoveTetromino(Vector3.down);
        }

        // Handle user input
        UserInput();
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTetromino(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTetromino(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentTetromino.transform.Rotate(0, 0, 90);

            if (!IsValidPosition())
            {
                currentTetromino.transform.Rotate(0, 0, -90);
            }
        }

        // Temporarily increase speed when the down arrow is held
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentMovementFrequency = 0.2f; // Faster speed when holding down
        }
        else
        {
            currentMovementFrequency = movementFrequency; // Return to normal speed
        }
    }

    void SpawnTetromino()
    {
        int index = Random.Range(0, Tetrominos.Length);
        currentTetromino = Instantiate(Tetrominos[index], new Vector3(5, 17, 0), Quaternion.identity);

        // Check if the Tetromino is in a valid position (game over condition)
        if (!IsValidPosition())
        {
            Debug.Log("Invalid position for Tetromino: " + currentTetromino.transform.position);
            GameOver();
        }

    }

    void MoveTetromino(Vector3 direction)
    {
        currentTetromino.transform.position += direction;

        if (!IsValidPosition())
        {
            currentTetromino.transform.position -= direction;

            if (direction == Vector3.down)
            {
                GetComponent<GridScript>().UpdateGrid(currentTetromino.transform);
                CheckForLines();
                SpawnTetromino();  // Spawn the next Tetromino
            }
        }
    }

    bool IsValidPosition()
    {
        return GetComponent<GridScript>().IsValidPosition(currentTetromino.transform);
    }

    void CheckForLines()
    {
        GetComponent<GridScript>().CheckForLines();
    }

    // ... other code ...

    void GameOver()
    {
        // display game over message and stop the game
        Debug.Log("Game Over!");  // You can replace this with UI display logic
        isGameOver = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);// Restart the scene
    }
}
