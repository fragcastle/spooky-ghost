using UnityEngine;
using System.Collections;

public class DieWhenBelowTheFold : BaseBehavior
{
	public float Buffer = 0;
	public bool Horizontal = false;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if ((!Horizontal && IsBelowTheFold(Buffer)) || (Horizontal && IsBelowTheFoldX(Buffer)))
		{
			Destroy(gameObject);
		}
	}
}
