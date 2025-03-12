using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    // Create private variables for player speed, and for the Text UI game objects
    [SerializeField]
    private float playerSpeed;

    public Text scoreText;
    public Text winText;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int score;

	// At the start of the game..
	void Start ()	
    {
		rb = GetComponent<Rigidbody>();
		score = 0;
		SetScoreText();
		winText.text = "";
    }

	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * playerSpeed);
	}

	void OnTriggerEnter(Collider other) 
{
if (other.gameObject.CompareTag ("Pick Up"))
{						    other.gameObject.SetActive (false);
							score = score + 1;
							SetScoreText ();
    }}

    void SetScoreText()
    {
		if (score == 0) return;  
		scoreText.text = "Score: " + score.ToString ();
		if (score >= 12) 
        {
			// Set the text value of our 'winText'
			winText.text = "You Win!";
        }
    }
}