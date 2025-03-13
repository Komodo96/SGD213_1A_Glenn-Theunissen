using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
//Variable for how fast the player moves
    private float playerSpeed;

//Variable for the UI text that will display the score on screen
    public Text scoreText;
	
//Variable for the UI text that will display the game winning screen
    public Text winText;

// Rigidbody component for the player
	private Rigidbody rb;

//Variable to keep track of how many objects the player has picked up
	private int score;

//Variable to show Game Over UI screen 
    public GameObject gameOverUI;

// At the start of the game, before the first frame update 
	void Start ()	
    {
//call the rigidbody component which is attatched to the player
        rb = GetComponent<Rigidbody>();

//Set the default starting score to 0
		score = 0;

//Update the score displayed by the UI
		SetScoreText();

//Set the win text to inactive by default
		winText.text = "";
    }

//Called once per frame update
	void FixedUpdate ()
	{
// Set local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
//Apply force the the rigidbody component of the player
		rb.AddForce (movement * playerSpeed);
	}

//Called when the player collides with another object with collision active
    void OnTriggerEnter(Collider other) 
    {
//If the player collides with an object designated as a pick up..  
        if (other.gameObject.CompareTag ("Pick Up"))

//Remove the pickup from the scene..
        {	other.gameObject.SetActive (false);

//Increment the score by 1.
            score++;

//Then call the SetScoreText function
            SetScoreText();
        }
	}

//Function used to set the game over UI screen to Active
    void GameOver()
    {
        gameOverUI.SetActive(true);
    }

//Function Used to upadate and display the score on the players screen and check if the player has collected all pickups. If so then display the Win Text on screen
    void SetScoreText()
    {
//Check if the score is currently 0 and if so then return from this function 
		if (score == 0) return;

//Get the current value of the score variable and display it on the player's screen
        scoreText.text = "Score: " + score.ToString ();

//If the score reaches 12 then... 
        if (score >= 12) 
        {

//Call the Game Over function to activate the UI on the player's screen 
            GameOver();

//set the text value of our 'winText' to active
            winText.text = "You Win!";
        }
    }
}