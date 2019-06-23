using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  [SerializeField] AudioClip[] breakSounds;
  [SerializeField] GameObject blockSparklesVFX;
  [SerializeField] Sprite[] hitSprites;



  // State Variables
  [SerializeField] int timesHit = 0; // Serialized for debug

  // Cached References
  Level level;
  GameSession gameSession;

  private void Start()
  {
    gameSession = FindObjectOfType<GameSession>();
    level = FindObjectOfType<Level>();

    if (tag == "Breakable")
    {
      level.CountBreakableBlocks();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (tag == "Breakable")
    {
      HandleHits();
    }
  } 

  private void ShowNextHitSprite()
  {
    int spriteIndex = timesHit - 1;
    GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

  }

  private void HandleHits()
  {
    timesHit++;

    if (timesHit >= hitSprites.Length + 1)
    {
      DestroyBlock();
    }
    else
    {
      ShowNextHitSprite();
    }
  }

  private void DestroyBlock()
  {
    gameSession.AddToScore();
    TriggerSparklesVFX();
    level.RemoveBreakableBlock();
    AudioSource.PlayClipAtPoint(breakSounds[UnityEngine.Random.Range(0, breakSounds.Length)], transform.position);
    Destroy(gameObject);
  }

  private void TriggerSparklesVFX()
  {
    GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    Destroy(sparkles, 1f);
  }
}
