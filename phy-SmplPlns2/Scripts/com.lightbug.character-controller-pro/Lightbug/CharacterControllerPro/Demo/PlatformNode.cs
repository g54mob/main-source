using System;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[Serializable]
	public class PlatformNode
	{
		public Vector3 position = Vector3.zero;

		public Vector3 eulerAngles = Vector3.zero;

		public AnimationCurve movementCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		public AnimationCurve rotationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Min(0f)]
		public float targetTime = 1f;

		public void Initialize()
		{
			position = Vector3.zero;
			eulerAngles = Vector3.zero;
			movementCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			rotationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			targetTime = 1f;
		}
	}
}
