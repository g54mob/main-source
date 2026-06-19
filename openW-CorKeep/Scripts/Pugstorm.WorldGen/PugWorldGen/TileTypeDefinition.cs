using System;
using UnityEngine;

namespace PugWorldGen
{
	[Serializable]
	public class TileTypeDefinition
	{
		public string name;

		[ColorUsage(false)]
		public Color32 color;
	}
}
