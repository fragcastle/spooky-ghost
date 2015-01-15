using UnityEngine;
using System.Collections;

public class Platform : BaseBehavior
{
    private PlayerController _player;
    private bool _passed = false;
    
    public float JumpSpeed = 3.5F;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!_player)
            return;
    	
		if (!_passed && _player.transform.position.x >= transform.position.x)
		{
    		_player.ObstaclesPassed++;
    		_passed = true;
    		
    		audio.Play();
		}
		
        if (IsBelowTheFoldX())
        {
            Destroy(gameObject);
        }
    }
}
