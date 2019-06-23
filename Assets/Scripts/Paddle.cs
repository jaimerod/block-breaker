using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
  [SerializeField] float ScreenUnits = 16f;
  [SerializeField] float minX = 1f;
  [SerializeField] float maxY = 15f;

  bool IsAutoplayEnabled()
  {
    GameSession gameSession = FindObjectOfType<GameSession>();
    return gameSession.AutoplayEnabled;
  }

  float getBallXPos()
  {
    Ball ball = FindObjectOfType<Ball>();
    return ball.transform.position.x;
  }

  // Update is called once per frame
  void Update()
  {
    float MousePosInUnits = Input.mousePosition.x / Screen.width * ScreenUnits;
    Vector2 newPos = new Vector2();

    if (IsAutoplayEnabled())
    {
      newPos = new Vector2(getBallXPos(), transform.position.y);
    }
    else
    {
      newPos = new Vector2(Mathf.Clamp(MousePosInUnits, minX, maxY), transform.position.y);
    }

    transform.position = newPos;
  }
}
