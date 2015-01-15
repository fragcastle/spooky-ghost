using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour
{
	void Start ()
	{
		var text = GetComponent<Text>();
		Debug.Log(PlayerPrefs.GetInt(Constants.HighScoreKey).ToString());
		if (PlayerPrefs.HasKey(Constants.HighScoreKey))
		{
			var highScore = PlayerPrefs.GetInt(Constants.HighScoreKey);
			
			text.text = highScore.ToString();
		}
		else
		{
			text.enabled = false;
		}
	}
	
	void Update ()
	{

	}
}
