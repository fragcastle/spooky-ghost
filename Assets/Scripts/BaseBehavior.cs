﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BaseBehavior : MonoBehaviour
{
    /// <summary>
    /// Is the current transform off the bottom of the screen.
    /// </summary>
    /// <returns></returns>
    public bool IsBelowTheFold()
    {
        var halfHeight = Screen.height / 2;

        var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0));
        var distance = Vector3.Distance(p1, p2);

        return (Camera.main.transform.position.y - distance > transform.position.y);
    }

    /// <summary>
    /// Is the current transform off the bottom of the screen.
    /// </summary>
    /// <returns></returns>
    public bool IsBelowTheFold(float buffer)
    {
        var halfHeight = Screen.height / 2;

        var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0));
        var distance = Vector3.Distance(p1, p2);

        return (Camera.main.transform.position.y - distance > transform.position.y + buffer);
	}
	
	/// <summary>
	/// Is the current transform off the bottom of the screen.
	/// </summary>
	/// <returns></returns>
	public bool IsBelowTheFoldX()
	{
		var halfWidth = Screen.width / 2;
		
		var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
		var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, halfWidth, 0));
		var distance = Vector3.Distance(p1, p2);
        
        return (Camera.main.transform.position.x - distance > transform.position.x);
	}
	
	/// <summary>
	/// Is the current transform off the bottom of the screen.
	/// </summary>
	/// <returns></returns>
	public bool IsBelowTheFoldX(float buffer)
	{
		var halfWidth = Screen.width / 2;
		
		var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
		var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, halfWidth, 0));
		var distance = Vector3.Distance(p1, p2);
		
		return (Camera.main.transform.position.x - distance > transform.position.x + buffer);
    }
    
    /// <summary>
    /// Width of the screen in world units.
	/// </summary>
	/// <returns></returns>
	public float ScreenWidth()
	{
		var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
		var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.width, 0));
		var distance = Vector3.Distance(p1, p2);
		
		return distance;
	}
	
	/// <summary>
	/// Width of the screen in world units.
	/// </summary>
	/// <returns></returns>
	public float ScreenHeight()
	{
		var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
		var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
		var distance = Vector3.Distance(p1, p2);
		
		return distance;
	}

    /// <summary>
    /// The top of the screen in y world coordinates.
    /// </summary>
    public float TopOfTheScreen()
    {
        var halfHeight = Screen.height / 2;

        var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0));
        var distance = Vector3.Distance(p1, p2);

        return Camera.main.transform.position.y + distance;
    }

    public float LeftOfScreenX()
    {
        var halfWidth = Screen.width / 2;

        var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var p2 = Camera.main.ScreenToWorldPoint(new Vector3(-halfWidth, 0, 0));
        var distance = Vector3.Distance(p1, p2);

        return distance;
    }

    public float RightOfScreenX()
    {
        var halfWidth = Screen.width / 2;

        var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var p2 = Camera.main.ScreenToWorldPoint(new Vector3(halfWidth, 0, 0));
        var distance = Vector3.Distance(p1, p2);

        return distance;
    }

	public bool IsMobile()
	{
		return Application.platform == RuntimePlatform.Android
			|| Application.platform == RuntimePlatform.IPhonePlayer
			|| Application.platform == RuntimePlatform.WP8Player;
	}
    
    public int RandomIndex(int arrayLength)
    {
        return Mathf.FloorToInt(UnityEngine.Random.value * (arrayLength - 1));
    }
}
