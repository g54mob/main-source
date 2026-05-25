using System.Collections.Generic;
using UnityEngine;

public class EndRock : MonoBehaviour
{
	public List<Sprite> RockSprite;

	private int _cachedLevel;

	private void Update()
	{
		if (_cachedLevel != GameController.Instance.PrestigeCount)
		{
			_cachedLevel = GameController.Instance.PrestigeCount;
			GetComponent<SpriteRenderer>().sprite = RockSprite[_cachedLevel];
		}
	}
}
