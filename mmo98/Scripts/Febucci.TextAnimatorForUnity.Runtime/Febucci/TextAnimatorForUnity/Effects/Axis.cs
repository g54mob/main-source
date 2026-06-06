using System;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class Axis
	{
		public bool isEnabled;

		public AnimationCurve weight = new AnimationCurve(new Keyframe(0f, 0f, 0f, 2f), new Keyframe(0.5f, 1f, 0f, 0f), new Keyframe(1f, 0f, -2f, 0f));

		public Vector3 multiplier = new Vector3(1f, 1f, 1f);

		[Range(0f, 1f)]
		public float phaseShift;

		public bool IsValid()
		{
			if (isEnabled)
			{
				return weight != null;
			}
			return false;
		}

		public Vector3 Sample(float pct)
		{
			return weight.Evaluate((pct + phaseShift) % 1f) * multiplier;
		}
	}
}
