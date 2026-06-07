using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class OptionalKeyCode : Optional<KeyCode>
	{
		public static OptionalKeyCode WithValue(KeyCode value)
		{
			return null;
		}
	}
}
