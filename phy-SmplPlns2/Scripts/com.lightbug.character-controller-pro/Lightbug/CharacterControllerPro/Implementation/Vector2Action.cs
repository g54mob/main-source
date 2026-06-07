using System;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[Serializable]
	public struct Vector2Action
	{
		public Vector2 value;

		public bool Detected => value != Vector2.zero;

		public bool Right => value.x > 0f;

		public bool Left => value.x < 0f;

		public bool Up => value.y > 0f;

		public bool Down => value.y < 0f;

		public void Reset()
		{
			value = Vector2.zero;
		}
	}
}
