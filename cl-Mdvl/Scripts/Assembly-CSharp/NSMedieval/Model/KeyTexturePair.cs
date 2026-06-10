using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class KeyTexturePair : Pair<Texture>
	{
		public KeyTexturePair(string id, Texture value)
			: base(id, value)
		{
		}
	}
}
