using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
	public List<Sprite> Level1Sprite;

	public List<Sprite> Level2Sprite;

	public List<Sprite> Level3Sprite;

	public List<Sprite> Level4Sprite;

	public List<Sprite> Level5Sprite;

	private int _index;

	private int _level;

	private void Start()
	{
		_index = Random.Range(0, Level1Sprite.Count);
		DrawFlower();
	}

	private void Update()
	{
	}

	public void SetRandomLevel()
	{
		SetLevel(Random.Range(0, 6));
	}

	public void SetLevel(int newLevel)
	{
		if (newLevel < 0)
		{
			newLevel = 0;
		}
		if (newLevel > 5)
		{
			newLevel = 5;
		}
		if (_level != newLevel)
		{
			_level = newLevel;
			DrawFlower();
		}
	}

	private void DrawFlower()
	{
		if (_level == 0)
		{
			GetComponent<SpriteRenderer>().sprite = null;
		}
		else if (_level == 1)
		{
			GetComponent<SpriteRenderer>().sprite = Level1Sprite[_index];
		}
		else if (_level == 2)
		{
			GetComponent<SpriteRenderer>().sprite = Level2Sprite[_index];
		}
		else if (_level == 3)
		{
			GetComponent<SpriteRenderer>().sprite = Level3Sprite[_index];
		}
		else if (_level == 4)
		{
			GetComponent<SpriteRenderer>().sprite = Level4Sprite[_index];
		}
		else if (_level == 5)
		{
			GetComponent<SpriteRenderer>().sprite = Level5Sprite[_index];
		}
	}
}
