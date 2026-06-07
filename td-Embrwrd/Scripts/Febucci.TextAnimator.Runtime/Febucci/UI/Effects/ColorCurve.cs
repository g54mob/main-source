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
			colorOverTime = null;
			this.waveSize = 0f;
			duration = 0f;
		}

		public Color32 Evaluate(float time, int charIndex)
		{
			return default(Color32);
		}
	}
}
