using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalVector2 : Optional<Vector2>
	{
		public OptionalVector2(Vector2 value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalVector2 WithValue(Vector2 value)
		{
			return new OptionalVector2(value, enabledByDefault: true);
		}
	}
}
