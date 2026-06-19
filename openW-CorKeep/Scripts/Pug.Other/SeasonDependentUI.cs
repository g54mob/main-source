using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class SeasonDependentUI : MonoBehaviour, IManagedLateUpdate
{
	[Serializable]
	public class SeasonDependentObject
	{
		public Season season;

		public List<GameObject> objectsToEnable;

		public List<GameObject> objectsToDisable;

		public List<SpriteRendererAndSprite> spritesToChange;

		public List<SkinsAndSpriteSheets> skinsToChange;
	}

	[Serializable]
	public class SpriteRendererAndSprite
	{
		public SpriteRenderer SR;

		public Sprite sprite;

		public Color color;
	}

	[Serializable]
	public class SkinsAndSpriteSheets
	{
		public SpriteSheetSkin skinComponent;

		public Texture2D spriteSheet;
	}

	[ArrayElementTitle("season")]
	public List<SeasonDependentObject> seasonDependentObjects;

	private int prevSeason = -1;

	private void OnEnable()
	{
		Manager.update.AddToLateUpdate(this);
	}

	private void OnDisable()
	{
		Manager.update.RemoveFromLateUpdate(this);
	}

	public void ManagedLateUpdate()
	{
		Season season = Manager.prefs.season;
		if (prevSeason == (int)season)
		{
			return;
		}
		bool flag = false;
		foreach (SeasonDependentObject seasonDependentObject in seasonDependentObjects)
		{
			if (seasonDependentObject.season == Manager.prefs.season)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			season = Season.None;
		}
		foreach (SeasonDependentObject seasonDependentObject2 in seasonDependentObjects)
		{
			if (seasonDependentObject2.season != season)
			{
				continue;
			}
			foreach (GameObject item in seasonDependentObject2.objectsToEnable)
			{
				item.SetActive(value: true);
			}
			foreach (GameObject item2 in seasonDependentObject2.objectsToDisable)
			{
				item2.SetActive(value: false);
			}
			foreach (SpriteRendererAndSprite item3 in seasonDependentObject2.spritesToChange)
			{
				item3.SR.sprite = item3.sprite;
				item3.SR.color = item3.color;
			}
			foreach (SkinsAndSpriteSheets item4 in seasonDependentObject2.skinsToChange)
			{
				item4.skinComponent.SetSkin(item4.spriteSheet);
			}
			break;
		}
		prevSeason = (int)Manager.prefs.season;
	}
}
