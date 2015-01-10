using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
{
    private Animator _animator;
    private ParticleSystem _particleSystem;
    
	private float _moveThreshold = 0F;
	
	private PlayerType _playerType;
	
    public int ObstaclesPassed = 0;
	public float JumpSpeed = 3.5F;
	
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
        _animator = GetComponent<Animator>();
        _particleSystem = GameObject.Find("ParticleSystem").particleSystem;

        if (PlayerPrefs.HasKey(Constants.PlayerTypeKey))
        {
            var playerType = PlayerPrefs.GetString(Constants.PlayerTypeKey);

            DestroyImmediate(_animator);

            _animator = gameObject.AddComponent<Animator>();

            var resource = Resources.Load("Animations/" + playerType + "Player/Player");
            var newAnimationController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(resource);
            _animator.runtimeAnimatorController = newAnimationController;
        }
    }

    void Update()
	{
		ObstaclesPassed = Mathf.Abs(Mathf.RoundToInt(transform.position.y));

        if (Mathf.Abs(rigidbody2D.velocity.y) < 1)
        {
            _animator.SetTrigger("Hovering");
        }
        else if (rigidbody2D.velocity.y < 0)
        {
            _animator.SetTrigger("Falling");
        }
        else
        {
            _animator.SetTrigger("Jumping");
		}
		
		if (IsMobile() && Input.touchCount > 0)
		{
			rigidbody2D.velocity = Vector2.up * JumpSpeed;
		}
		else if (Input.GetButtonDown("Jump"))
		{
			rigidbody2D.velocity = Vector2.up * JumpSpeed;
        }
        
        transform.Translate(Vector2.right * Time.deltaTime);
        
        _particleSystem.enableEmission = rigidbody2D.velocity.y > 0;
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
