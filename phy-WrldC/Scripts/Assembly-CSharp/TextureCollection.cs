using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextureCollection
{
	private readonly Dictionary<string, Texture2D> textures;

	private readonly Dictionary<string, Sprite> sprites;

	public TextureCollection()
	{
		textures = new Dictionary<string, Texture2D>();
		sprites = new Dictionary<string, Sprite>();
	}

	public void AddTexture(string key, Texture2D texture)
	{
		if (textures.ContainsKey(key))
		{
			textures[key] = texture;
		}
		else
		{
			textures.Add(key, texture);
		}
		Sprite value = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.zero);
		if (sprites.ContainsKey(key))
		{
			sprites[key] = value;
		}
		else
		{
			sprites.Add(key, value);
		}
	}

	public Texture2D GetTexture(string key)
	{
		if (!textures.ContainsKey(key))
		{
			return null;
		}
		return textures[key];
	}

	public void RemoveTexture(string key)
	{
		if (textures.ContainsKey(key))
		{
			textures.Remove(key);
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

	public string[] GetAllKeys()
	{
		return textures.Keys.ToArray();
	}
}
