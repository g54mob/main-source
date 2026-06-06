using System;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class GradientParam
	{
		public bool isEnabled;

		public ColorMode mode;

		public Gradient gradient = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(Color.white, 0f),
				new GradientColorKey(Color.white, 1f)
			}
		};

		[Range(0f, 1f)]
		public float phaseShift;

		public bool IsValid()
		{
			if (isEnabled)
			{
				return gradient != null;
			}
			return false;
		}

		public Color Sample(float pct)
		{
			return gradient.Evaluate((pct + phaseShift) % 1f);
		}
	}
}
