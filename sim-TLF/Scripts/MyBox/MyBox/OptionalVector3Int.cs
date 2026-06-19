using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalVector3Int : Optional<Vector3Int>
	{
		public OptionalVector3Int(Vector3Int value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalVector3Int WithValue(Vector3Int value)
		{
			return new OptionalVector3Int(value, enabledByDefault: true);
		}
	}
}
