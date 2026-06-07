using System;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class UVParameter
	{
		[SerializeField]
		public Vector2 shift = Vector2.zero;

		[SerializeField]
		public Vector2 scale = Vector2.one;

		[SerializeField]
		public float rotation;

		public UVParameter Clone()
		{
			return new UVParameter
			{
				shift = shift,
				scale = scale,
				rotation = rotation
			};
		}

		public void Reset(UVParameter src)
		{
			if (src == null)
			{
				shift = Vector2.zero;
				scale = Vector2.one;
				rotation = 0f;
			}
			else
			{
				shift = src.shift;
				scale = src.scale;
				rotation = src.rotation;
			}
		}
	}
}
