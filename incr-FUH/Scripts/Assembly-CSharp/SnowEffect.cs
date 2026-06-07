using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowEffect : MonoBehaviour
{
	public List<Sprite> Sprites;

	private int _index;

	private float _delta;

	private float _speed = 0.25f;

	private void Start()
	{
		_delta = _speed;
	}

	private void Update()
	{
		_delta -= Time.deltaTime;
		if (_delta <= 0f)
		{
			_delta = _speed;
			_index++;
			if (_index >= Sprites.Count)
			{
				_index = 0;
			}
			GetComponent<Image>().sprite = Sprites[_index];
		}
	}
}
