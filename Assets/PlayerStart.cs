using UnityEngine;
using System.Collections;

public class PlayerStart : MonoBehaviour
{
	private float _startY;
	
	void Start ()
	{
		_startY = transform.position.y;
	}
	
	void Update ()
	{
		transform.position = new Vector2(transform.position.x, _startY + Mathf.Sin(Time.fixedTime) / 2);
	}
}
