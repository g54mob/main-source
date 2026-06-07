using System.Collections.Generic;
using UnityEngine;

public class DotLevel : MonoBehaviour
{
	public List<SpriteRenderer> DotSprites;

	private int _cachedLevel = -1;

	private bool _cachedCanLevel;

	private void Start()
	{
		_cachedLevel = -1;
		_cachedCanLevel = false;
		for (int i = 0; i < DotSprites.Count; i++)
		{
			DotSprites[i].gameObject.SetActive(value: false);
		}
	}

	public void ProcessDots(BaseBuilding building)
	{
		if (building == null)
		{
			UpdateDots(0, canLevel: false);
		}
		else if (building.BuildingType == BaseBuilding.BuildingTypeEnum.Hole || building.BuildingType == BaseBuilding.BuildingTypeEnum.Rock)
		{
			UpdateDots(0, canLevel: false);
		}
		else
		{
			UpdateDots(building.GetLevel(), building.CanIncreaseLevel());
		}
	}

	private void UpdateDots(int level, bool canLevel)
	{
		if (_cachedLevel == level && _cachedCanLevel == canLevel)
		{
			return;
		}
		_cachedLevel = level;
		_cachedCanLevel = canLevel;
		for (int i = 0; i < DotSprites.Count; i++)
		{
			if (level == 0)
			{
				DotSprites[i].gameObject.SetActive(value: false);
				continue;
			}
			DotSprites[i].gameObject.SetActive(value: true);
			if (i < level)
			{
				DotSprites[i].color = Color.white;
			}
			else if (canLevel && i == level)
			{
				DotSprites[i].color = Color.yellow;
			}
			else
			{
				DotSprites[i].color = new Color(0.15f, 0.15f, 0.15f);
			}
		}
	}
}
