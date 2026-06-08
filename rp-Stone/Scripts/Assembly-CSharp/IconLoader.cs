using System.Collections.Generic;
using UnityEngine;

public class IconLoader : MonoBehaviour
{
	public AsciiSprite lostItemLaurels;

	private Dictionary<string, AsciiSprite> icons = new Dictionary<string, AsciiSprite>();

	private static IconLoader _instance;

	public static IconLoader Singleton => _instance;

	public AsciiSprite GetSharedIcon(string prefabPath)
	{
		if (icons.ContainsKey(prefabPath))
		{
			return icons[prefabPath];
		}
		AsciiSprite asciiSprite = LoadFromFile(prefabPath);
		if (asciiSprite != null)
		{
			asciiSprite.Load();
			icons.Add(prefabPath, asciiSprite);
		}
		return asciiSprite;
	}

	public AsciiSprite GetSharedIcon(string prefabPath, char symbolToBeReplaced, char symbolToReplaceWith, ItemData.Rarity.Type baseRarity = ItemData.Rarity.Type.Common, bool isShiny = false, string additionalKey = null)
	{
		string text = prefabPath + ":" + symbolToBeReplaced + symbolToReplaceWith;
		if (baseRarity != ItemData.Rarity.Type.Common)
		{
			text = text + ":" + baseRarity;
		}
		if (isShiny)
		{
			text += "S";
		}
		if (additionalKey != null)
		{
			text += additionalKey;
		}
		if (icons.ContainsKey(text))
		{
			return icons[text];
		}
		AsciiSprite asciiSprite = LoadFromFile(prefabPath);
		if (asciiSprite != null)
		{
			AsciiData.StringReplacement stringReplacement = new AsciiData.StringReplacement();
			stringReplacement.find = symbolToBeReplaced.ToString();
			stringReplacement.replaceWith = symbolToReplaceWith.ToString();
			asciiSprite.stringReplacements.Add(stringReplacement);
			asciiSprite.Load();
			switch (baseRarity)
			{
			case ItemData.Rarity.Type.Transcendent:
				asciiSprite.gameObject.AddComponent<AsciiSpritePPRainbow>();
				break;
			default:
				asciiSprite.colorOverride = ItemData.Rarity.GetColorForRarity(baseRarity);
				break;
			case ItemData.Rarity.Type.Common:
				break;
			}
			if (isShiny)
			{
				asciiSprite.gameObject.AddComponent<AsciiSpritePPShiny>();
			}
			icons.Add(text, asciiSprite);
		}
		return asciiSprite;
	}

	public static AsciiSprite LoadFromFile(string prefabPath)
	{
		GameObject gameObject = Utils.InstantiatePrefab(prefabPath);
		if (gameObject != null)
		{
			AsciiSprite component = gameObject.GetComponent<AsciiSprite>();
			if (component == null)
			{
				Utils.LogError(prefabPath + " is not an AsciiSprite");
			}
			return component;
		}
		return null;
	}

	private void Awake()
	{
		_instance = this;
	}
}
