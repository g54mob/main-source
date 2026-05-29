using System;
using UnityEngine;

namespace GameKit.Utilities.Types
{
	[Serializable]
	public struct Vector2Range
	{
		public FloatRange X;

		public FloatRange Y;

		public Vector2Range(Vector2 minimum, Vector2 maximum)
		{
			X = default(FloatRange);
			Y = default(FloatRange);
		}

		public Vector2Range(FloatRange minimum, FloatRange maximum)
		{
			X = default(FloatRange);
			Y = default(FloatRange);
		}

		public Vector2 RandomInclusive()
		{
			return default(Vector2);
		}
	}
}
