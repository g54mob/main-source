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
			return 0f;
		}

		public EmissionCurve()
		{
		}

		public EmissionCurve(params Keyframe[] keyframes)
		{
		}

		public float Evaluate(float timePassed)
		{
			return 0f;
		}
	}
}
