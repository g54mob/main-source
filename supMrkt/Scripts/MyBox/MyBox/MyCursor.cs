using System;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public struct MyCursor
	{
		public Texture2D Texture;

		public Vector2 Hotspot;

		public void ApplyAsLockedCursor()
		{
		}

		public void ApplyAsFreeCursor()
		{
		}

		public void ApplyAsConfinedCursor()
		{
		}
	}
}
