using UnityEngine;
using System.Collections;

public class BackgroundDirector : BaseBehavior
{
	private GameObject _player;
	
	private float _lastX = 0;
	private float _distanceToGenerate = 20;
	
	public Transform Background;
	
	void Start()
	{
		_player = GameObject.Find("Player");
	}
	
	void Update()
	{
		if (!_player)
			return;
		
		var playerPosition = _player.transform.position;
		
		// Generate the first decoration in the center of screen
		if (_lastX == 0)
		{
			var background = (Transform)Instantiate(Background, new Vector3(_lastX, transform.position.y, transform.position.z), Quaternion.identity);
			
			_lastX += 10.23F;
            
			background.parent = transform;
		}
		
		while (_lastX < playerPosition.x + _distanceToGenerate)
		{
			var background = (Transform)Instantiate(Background, new Vector3(_lastX, transform.position.y, transform.position.z), Quaternion.identity);
			
			_lastX += 10.23F;
			
			background.parent = transform;
		}
	}
}
