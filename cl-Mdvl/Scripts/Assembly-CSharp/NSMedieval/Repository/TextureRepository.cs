using System.Collections.Generic;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class TextureRepository : AddressableRepository<TextureRepository, KeyTexturePair, Texture>
	{
		public override List<string> AddressableLabels()
		{
			return new List<string> { "Texture" };
		}

		public override void AddNewObject(string key, Object obj, bool overwrite = false)
		{
			if (!(obj == null) && !string.IsNullOrEmpty(key) && !dictionary.ContainsKey(key))
			{
				Add(new KeyTexturePair(key, obj as Texture));
			}
		}
	}
}
