using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public GameObject StartUi;
    public GameObject ENdUi;

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
        if (successfulThrows >= 8)
        {
            StartUi.SetActive(false);
            ENdUi.SetActive(true);
            Debug.Log("Congratulations! You've reached 10 successful throws!");
        }
    }
}