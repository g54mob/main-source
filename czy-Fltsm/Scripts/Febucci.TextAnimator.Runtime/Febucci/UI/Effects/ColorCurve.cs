using System;
using UnityEngine;

namespace Febucci.UI.Effects
{
	[Serializable]
	public struct ColorCurve
	{
		public bool enabled;

		public Gradient colorOverTime;

		public float waveSize;

		public float duration;

		public ColorCurve(float waveSize)
		{
			enabled = false;
			this.waveSize = waveSize;
			duration = 1f;
			colorOverTime = new Gradient();
			colorOverTime.SetKeys(new GradientColorKey[3]
			{
				new GradientColorKey(Color.white, 0f),
				new GradientColorKey(Color.cyan, 0.5f),
				new GradientColorKey(Color.white, 1f)
			}, new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			});
		}

		public Color32 Evaluate(float time, int charIndex)
		{
			time = Mathf.Repeat(time + (float)charIndex * waveSize, duration);
			return colorOverTime.Evaluate(time);
		}
	}
}
