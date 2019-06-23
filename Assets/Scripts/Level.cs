using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

  [SerializeField] int breakableBlocks;

  private void Update()
  {
    Scene currentScene = SceneManager.GetActiveScene();

    if (currentScene.name == "Level 2")
    {
      // Time.timeScale = 0.5f;
    }
  }

  public void CountBreakableBlocks()
  {
    breakableBlocks++;
  }

  public void RemoveBreakableBlock()
  {
    breakableBlocks--;

    if (breakableBlocks == 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }
}
