﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
  // Fields
  [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int currentScore = 0;
  [SerializeField] int pointsPerBlockDestroyed = 83; 
  [SerializeField] public bool AutoplayEnabled = false;

  // Cached components
  [SerializeField] TextMeshProUGUI scoreText;

  private void Awake()
  {
    int gameStatusCount = FindObjectsOfType<GameSession>().Length;

    if (gameStatusCount > 1)
    {
      DestroyImmediate(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    scoreText.text = currentScore.ToString();
  }

  // Update is called once per frame
  void Update()
  {
    Time.timeScale = gameSpeed;

    if (Input.GetKeyDown("c"))
    {
      AutoplayEnabled = !AutoplayEnabled;
    }
  }

  public void AddToScore()
  {
    currentScore += pointsPerBlockDestroyed;
    scoreText.text = currentScore.ToString();
  }

  public void ResetScore()
  {
    Destroy(gameObject);
  }
}
