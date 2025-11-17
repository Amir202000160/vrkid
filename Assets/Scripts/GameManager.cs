using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;

    private int successfulThrows = 0;

    void Start()
    {
       
        UpdateScoreDisplay();
    }

    
    public void IncrementThrowCount()
    {
        successfulThrows++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Throws: " + successfulThrows.ToString();
        }
    }
}