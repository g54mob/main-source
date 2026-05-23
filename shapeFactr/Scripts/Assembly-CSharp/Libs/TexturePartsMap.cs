using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Libs
{
	[Serializable]
	public class TexturePartsMap
	{
		public string[,] Map;

		public float pivotOffsetX;

		public float pivotOffsetY;

		public bool forcePivotBottom;

		[IgnoreDataMember]
		public int Width => 0;

		[IgnoreDataMember]
		public int Height => 0;

		public TexturePartsMap(string[,] map)
		{
		}

		public (string, Rect, Vector2)[] GetSpriteInfos(int pixelsPerUnit)
		{
			return null;
		}
	}
}
