using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalKeyCode : Optional<KeyCode>
	{
		public OptionalKeyCode(KeyCode value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalKeyCode WithValue(KeyCode value)
		{
			return new OptionalKeyCode(value, enabledByDefault: true);
		}
	}
}
