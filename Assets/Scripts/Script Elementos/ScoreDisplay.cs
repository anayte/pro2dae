using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI text;
    private void OnEnable() {
        score.onScoreUpdated += UpdateText;
    }

    // Update is called once per frame
    private void OnDisable() {
        score.onScoreUpdated -= UpdateText;
    }

    private void UpdateText(){
        text.text = "Score : " + score.GetScore();
    }
}
