using System;
using UnityEngine;

namespace __Project__.Scripts.WallPaintSystem
{
	[Serializable]
	public struct ColorData
	{
		public int colorIndex;

		public Material material;

		public Color color;

		public ColorData(int index)
		{
			colorIndex = 0;
			material = null;
			color = default(Color);
		}
	}
}
