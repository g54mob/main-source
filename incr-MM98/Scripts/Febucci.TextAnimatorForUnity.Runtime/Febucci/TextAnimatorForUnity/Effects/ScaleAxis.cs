using System;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class ScaleAxis : Axis
	{
		public Vector3 SampleScale(float pct, float intensity)
		{
			return Vector3.LerpUnclamped(Vector3.one, Vector3.Scale(Vector3.one, multiplier), weight.Evaluate((pct + phaseShift) % 1f) * intensity);
		}
	}
}
