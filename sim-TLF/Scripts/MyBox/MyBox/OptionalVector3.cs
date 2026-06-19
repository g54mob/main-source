using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalVector3 : Optional<Vector3>
	{
		public OptionalVector3(Vector3 value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalVector3 WithValue(Vector3 value)
		{
			return new OptionalVector3(value, enabledByDefault: true);
		}
	}
}
