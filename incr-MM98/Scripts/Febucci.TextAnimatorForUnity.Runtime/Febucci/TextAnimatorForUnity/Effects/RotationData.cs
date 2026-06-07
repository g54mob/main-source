using System;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class RotationData
	{
		public float loopDegrees = 45f;

		public float oscillationDegrees = 45f;

		[Tooltip("1 to lock the rotation to the side of a character, e.g. y = 1 seems like a pendulum, -1 makes it from the bottom. Go beyond 1 to have crazier effects, and 0 to disable")]
		public Vector2 customPivot = new Vector2(0f, 0f);
	}
}
