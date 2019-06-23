using UnityEngine;

public class Ball : MonoBehaviour
{
  // Fields
  [SerializeField] Paddle paddle1;
  [SerializeField] float SidewaysMotion = 2f;
  [SerializeField] float VerticalMotion = 16f;
  [SerializeField] float Randomness = 10f;
  [SerializeField] AudioClip[] ballSounds;
  [SerializeField] AudioClip launchSound;

  // State
  Vector2 paddleToBallVector;
  bool hasLaunched = false;

  // Cached Component References
  AudioSource myAudioSource;
  Rigidbody2D myRigidbody2D;

  // Start is called before the first frame update
  void Start()
  {
    paddleToBallVector = transform.position - paddle1.transform.position;

    // Cache Components
    myAudioSource = GetComponent<AudioSource>();
    myRigidbody2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!hasLaunched)
    {
      LockBallToPaddle();
      LaunchOnMouseClick();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (hasLaunched)
    {
      RandomizeVector();
      PlayCrashSound();
    }
  }

  private void RandomizeVector()
  {
    float RandomX = Random.Range(Randomness * -1, Randomness);
    float RandomY = Random.Range(Randomness * -1, Randomness);
    myRigidbody2D.velocity += new Vector2(RandomX, RandomY);

  }

  private void PlayCrashSound()
  {
    AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
    myAudioSource.PlayOneShot(clip);
  }

  private void LaunchOnMouseClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      myRigidbody2D.velocity = new Vector2(SidewaysMotion, VerticalMotion);
      myAudioSource.PlayOneShot(launchSound);
      hasLaunched = true;
    }
  }

  private void LockBallToPaddle()
  {
    // Stick the ball to the paddle
    if (!hasLaunched)
    {
      transform.position = 
        new Vector2(paddle1.transform.position.x, paddle1.transform.position.y) + 
        paddleToBallVector;
    }
  }
}
