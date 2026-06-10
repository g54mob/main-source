using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class KeySpritePair : Pair<Sprite>
	{
		public KeySpritePair(string id, Sprite value)
			: base(id, value)
		{
		}
	}
}
