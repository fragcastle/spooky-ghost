using UnityEngine;
using System.Collections;

public class DecorationDirector : BaseBehavior
{
    private GameObject _player;

	private float _lastX = 0;
    private float _distanceToGenerate = 5;

    public Transform Decoration;

    public float DecorationRangeMin = 0.2F;
	public float DecorationRange = 0.3F;

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
			var decoration = (Transform)Instantiate(Decoration, new Vector3(transform.position.x, _lastX, transform.position.z), Quaternion.identity);

			decoration.parent = transform;

			_lastX += DecorationRangeMin;
        }

		while (_lastX < playerPosition.x + _distanceToGenerate)
        {
			_lastX += DecorationRangeMin + (DecorationRange * Random.value);

            var screenHeight = ScreenHeight();
			var yPosition = (screenHeight * Random.value) - (screenHeight / 2);

			var decoration = (Transform)Instantiate(Decoration, new Vector3(_lastX, yPosition, transform.position.z), Quaternion.identity);

			decoration.parent = transform;
        }
    }
}
