using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
{
    private ParticleSystem _particleSystem;
    
	private float _moveThreshold = 0F;
	
	private PlayerType _playerType;
	
	public int ObstaclesPassed = 0;
	public float JumpSpeed = 3.5F;
	public AudioSource JumpSound;
	
	public PlayerType PlayerType
	{
		get
		{
			return _playerType;
		}
		set
		{
			_playerType = value;
		}
	}

    void Start()
    {
        _particleSystem = GameObject.Find("ParticleSystem").particleSystem;
    }

    void Update()
	{
		if (IsMobile() && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
		{
			rigidbody2D.velocity = Vector2.up * JumpSpeed;
			
			audio.Play();
		}
		else if (Input.GetButtonDown("Jump"))
		{
			rigidbody2D.velocity = Vector2.up * JumpSpeed;
			
			audio.Play();
        }
        
        transform.Translate(Vector2.right * Time.deltaTime);
        
        _particleSystem.enableEmission = rigidbody2D.velocity.y > 0;
    }
    
    public void OnDeath()
    {
		AddHighScore(ObstaclesPassed);
    }

	private void AddHighScore(int score)
	{
		if (PlayerPrefs.HasKey(Constants.HighScoreKey))
		{
			var oldScore = PlayerPrefs.GetInt(Constants.HighScoreKey);
			
			PlayerPrefs.SetInt(Constants.PreviousHighScoreKey, oldScore);

			if (oldScore > score)
			{
				score = oldScore;
			}
		}
		
		PlayerPrefs.SetInt(Constants.HighScoreKey, score);
	}
}
