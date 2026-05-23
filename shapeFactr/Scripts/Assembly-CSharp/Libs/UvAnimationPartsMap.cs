using System;
using UnityEngine;

namespace Libs
{
	[Serializable]
	public class UvAnimationPartsMap
	{
		public string[] Target;

		public int widthSplit;

		public int heightSplit;

		public float basePivotX;

		public float basePivotY;

		public int[] animationOrder;

		public (string, Rect, Vector2)[] GetSpriteInfos(Vector2 spriteSize)
		{
			return null;
		}
	}
}
