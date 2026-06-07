using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLib : ScriptableObject
{
	[Serializable]
	public class Alias
	{
		public string spriteName;

		public List<string> altNames;
	}

	public List<Sprite> sprites;

	public List<Alias> aliases;

	public Sprite Find(string name)
	{
		Sprite sprite = FindSprite(name);
		if (sprite != null)
		{
			return sprite;
		}
		foreach (Alias alias in aliases)
		{
			if (alias.altNames.Contains(name))
			{
				return FindSprite(alias.spriteName);
			}
		}
		return null;
	}

	private Sprite FindSprite(string name)
	{
		foreach (Sprite sprite in sprites)
		{
			if (sprite.name == name)
			{
				return sprite;
			}
		}
		return null;
	}
}
