using System.Collections.Generic;
using UnityEngine;

public class SpriteLibrary
{
	private static Dictionary<string, Sprite> Sprites;

	static SpriteLibrary()
	{
		Sprites = new Dictionary<string, Sprite>();
		LoadSpritesheet("Items");
		LoadSpritesheet("Numerals");
	}

	private static void LoadSpritesheet(string name)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(name);
		for (int i = 0; i < array.Length; i++)
		{
			Sprites[array[i].name] = array[i];
		}
	}

	public static Sprite Get(string name)
	{
		return Sprites[name];
	}
}
