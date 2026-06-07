using System.Collections.Generic;
using UnityEngine;

public class SpriteCollection
{
	private Dictionary<string, Sprite> sprites;

	public SpriteCollection()
	{
		sprites = new Dictionary<string, Sprite>();
	}

	public void AddSprite(string key, Sprite sprite)
	{
		if (sprites.ContainsKey(key))
		{
			sprites[key] = sprite;
		}
		else
		{
			sprites.Add(key, sprite);
		}
	}

	public Sprite GetSprite(string key)
	{
		if (!sprites.ContainsKey(key))
		{
			return null;
		}
		return sprites[key];
	}

	public void RemoveSprite(string key)
	{
		if (sprites.ContainsKey(key))
		{
			sprites.Remove(key);
		}
	}
}
