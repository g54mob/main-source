using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Libs
{
	[Serializable]
	public class NamedSprites
	{
		[FormerlySerializedAs("partsName")]
		[FormerlySerializedAs("element")]
		public string name;

		public Sprite[] sprites;

		public NamedSprites(string name, List<Sprite> sprites)
		{
		}

		public NamedSprites(string name)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
