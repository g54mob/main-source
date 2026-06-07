using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class Sprites : MonoBehaviour
	{
		public static Sprites Instance;

		private Dictionary<string, Sprite> _allSpritesDictionary;

		public void Awake()
		{
		}

		public Sprite GetIconMissingIcon()
		{
			return null;
		}

		public Sprite GetSprite(string[] spriteNames, bool generalize = false)
		{
			return null;
		}

		public Sprite GetSprite(string spriteName, bool generalize = false)
		{
			return null;
		}

		private Sprite GetSpriteInternal(string spriteName, bool generalize = false)
		{
			return null;
		}
	}
}
