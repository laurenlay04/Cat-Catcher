using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TMPro.TMP_Text scoreText; //UI TEXT
    private int score = 0; // Player's score
    
    void Start(){
         if (scoreText != null)
        {
            Color visibleColor = scoreText.color;
            visibleColor.a = 1f; // or 255f if you're using byte-based color
            scoreText.color = visibleColor;
        }
        UpdateScoreText();
    }
    
    // Method to add score points when an item is collected
    public void AddScore(int points)
    {
        score += points;  // Add the given number of points to the score
        
        UpdateScoreText();
    }

    void UpdateScoreText(){
        scoreText.text = "Score: " + score;
    }
}