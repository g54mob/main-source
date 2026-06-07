using System;
using UnityEngine;

namespace FractureField.Quarry
{
	[Serializable]
	public class QuarryBounds
	{
		public Collider2D BoundsCollider;

		private Vector2 DefaultMin;

		private Vector2 DefaultMax;

		private Bounds _cachedBounds;

		public Vector2 Min => default(Vector2);

		public Vector2 Max => default(Vector2);

		public Vector2 Size => default(Vector2);

		public QuarryBounds()
		{
		}

		public QuarryBounds(Vector2 min, Vector2 max)
		{
		}

		public bool IsPointInBounds(Vector2 point)
		{
			return false;
		}

		public Vector2 GetRandomPointInBounds()
		{
			return default(Vector2);
		}

		private Vector2 GetRandomPointInCollider()
		{
			return default(Vector2);
		}

		public Bounds GetBounds()
		{
			return default(Bounds);
		}

		public Vector2 ClampToBounds(Vector2 position)
		{
			return default(Vector2);
		}
	}
}
