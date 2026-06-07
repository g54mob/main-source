using System;
using UnityEngine;

namespace Febucci.UI.Effects
{
	[Serializable]
	public class EmissionCurve
	{
		public int cycles;

		public float duration;

		[SerializeField]
		public AnimationCurve weightOverTime;

		public float GetMaxDuration()
		{
			if (cycles <= 0)
			{
				return -1f;
			}
			return duration * (float)cycles;
		}

		public EmissionCurve()
		{
			cycles = -1;
			duration = 1f;
			weightOverTime = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f));
		}

		public EmissionCurve(params Keyframe[] keyframes)
		{
			cycles = -1;
			duration = 1f;
			weightOverTime = new AnimationCurve(keyframes);
		}

		public float Evaluate(float timePassed)
		{
			if (cycles > 0 && timePassed > duration * (float)cycles)
			{
				return 0f;
			}
			return weightOverTime.Evaluate(timePassed % duration);
		}
	}
}
