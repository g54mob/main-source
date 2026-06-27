using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class SpritesPool
	{
		[SerializeField]
		private List<Sprite> dictionary;

		public Sprite Get(string name)
		{
			if (dictionary == null)
			{
				return null;
			}
			for (int i = 0; i < dictionary.Count; i++)
			{
				if (dictionary[i].name == name)
				{
					return dictionary[i];
				}
			}
			Debug.Log("Not find sprite " + name);
			return null;
		}

		public void Add(Sprite sprite)
		{
			if (dictionary == null)
			{
				dictionary = new List<Sprite>();
			}
			if (!dictionary.Contains(sprite))
			{
				dictionary.Add(sprite);
			}
		}

		public void Clear()
		{
			if (dictionary != null)
			{
				dictionary.Clear();
			}
		}
	}
}
