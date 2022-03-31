using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    private float currentScore = 0f;
    public event Action onScoreUpdated;

    private void Start(){
        onScoreUpdated?.Invoke();
    }

    public float GetScore(){
        return currentScore;
    }
    // Update is called once per frame

    public void AddScore(float scoreToAdd){
        currentScore += scoreToAdd;
        onScoreUpdated?.Invoke();
    }
}
