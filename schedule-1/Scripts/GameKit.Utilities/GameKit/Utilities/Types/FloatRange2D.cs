using System;
using UnityEngine;

namespace GameKit.Utilities.Types
{
	[Serializable]
	public struct FloatRange2D
	{
		public FloatRange X;

		public FloatRange Y;

		public FloatRange2D(FloatRange x, FloatRange y)
		{
			X = default(FloatRange);
			Y = default(FloatRange);
		}

		public FloatRange2D(float xMin, float xMax, float yMin, float yMax)
		{
			X = default(FloatRange);
			Y = default(FloatRange);
		}

		public Vector2 Clamp(Vector2 original)
		{
			return default(Vector2);
		}

		public Vector3 Clamp(Vector3 original)
		{
			return default(Vector3);
		}

		public float ClampX(float original)
		{
			return 0f;
		}

		public float ClampY(float original)
		{
			return 0f;
		}
	}
}
