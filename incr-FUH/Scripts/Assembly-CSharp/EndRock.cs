using System.Collections.Generic;
using UnityEngine;

public class EndRock : MonoBehaviour
{
	public List<Sprite> RockSprite;

	private int _cachedLevel;

	public Sign RockSign;

	private void Start()
	{
		RockSign.SetForRock();
		RockSign.gameObject.SetActive(value: false);
		if (CharDisplay.HasEndless)
		{
			RockSign.gameObject.SetActive(value: true);
		}
	}

	private void Update()
	{
		if (_cachedLevel != GameController.Instance.PrestigeCount)
		{
			_cachedLevel = GameController.Instance.PrestigeCount;
			GetComponent<SpriteRenderer>().sprite = RockSprite[_cachedLevel];
			if (GameController.Instance.PrestigeCount == 8)
			{
				RockSign.gameObject.SetActive(value: true);
			}
		}
		RockSign.gameObject.SetActive(CharDisplay.HasEndless);
	}
}
