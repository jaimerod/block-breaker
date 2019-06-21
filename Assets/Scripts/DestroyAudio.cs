using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
  static DestroyAudio instance = null;

  void Awake()
  {
    if (instance != null)
    {
      Destroy(gameObject);
    } else
    {
      instance = this;
      DontDestroyOnLoad(transform.gameObject);
    }
  }
}
