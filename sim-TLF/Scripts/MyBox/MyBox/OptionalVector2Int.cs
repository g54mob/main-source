using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalVector2Int : Optional<Vector2Int>
	{
		public OptionalVector2Int(Vector2Int value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalVector2Int WithValue(Vector2Int value)
		{
			return new OptionalVector2Int(value, enabledByDefault: true);
		}
	}
}
