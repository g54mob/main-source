using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LangPack.asset", menuName = "LangPack", order = 43)]
public class LangPack : ScriptableObject
{
	[Serializable]
	public class StringEntry
	{
		public string key;

		public string val;
	}

	[Serializable]
	public class SpriteEntry
	{
		public string key;

		public Sprite val;
	}

	public string code;

	public string hash;

	public string stringsHash;

	public string spritesHash;

	public string buildDate;

	public List<StringEntry> strings = new List<StringEntry>();

	public List<SpriteEntry> sprites = new List<SpriteEntry>();

	public string[] errors;

	public void Destroy()
	{
		foreach (SpriteEntry sprite in sprites)
		{
			UnityEngine.Object.Destroy(sprite.val);
		}
		strings.Clear();
		sprites.Clear();
	}
}
