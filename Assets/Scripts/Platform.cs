using UnityEngine;
using System.Collections;

public class Platform : BaseBehavior
{
    private Transform _player;
    
    public float JumpSpeed = 3.5F;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (!_player)
            return;

        if (IsBelowTheFoldX())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
		Destroy(collision2D.gameObject);
		
		if (PlatformDirector.Current)
			PlatformDirector.Current.audio.Play();
    }
}
