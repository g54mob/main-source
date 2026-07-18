using System;
using UnityEngine;

namespace AssetKits.ParticleImage
{
	[Serializable]
	public struct SeparatedMinMaxCurve
	{
		[SerializeField]
		private bool separable;

		public bool separated;

		public ParticleSystem.MinMaxCurve mainCurve;

		public ParticleSystem.MinMaxCurve xCurve;

		public ParticleSystem.MinMaxCurve yCurve;

		public ParticleSystem.MinMaxCurve zCurve;

		public SeparatedMinMaxCurve(float startValue, bool separated = false, bool separable = true)
		{
			mainCurve = new ParticleSystem.MinMaxCurve(startValue);
			xCurve = new ParticleSystem.MinMaxCurve(startValue);
			yCurve = new ParticleSystem.MinMaxCurve(startValue);
			zCurve = new ParticleSystem.MinMaxCurve(startValue);
			this.separated = separated;
			this.separable = separable;
		}

		public SeparatedMinMaxCurve(AnimationCurve startValue, bool separated = false, bool separable = true)
		{
			mainCurve = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(startValue.keys));
			xCurve = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(startValue.keys));
			yCurve = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(startValue.keys));
			zCurve = new ParticleSystem.MinMaxCurve(1f, new AnimationCurve(startValue.keys));
			this.separated = separated;
			this.separable = separable;
		}

		public Vector3 Evaluate(float time, float lerp)
		{
			if (separated)
			{
				return new Vector3(xCurve.Evaluate(time, lerp), yCurve.Evaluate(time, lerp), zCurve.Evaluate(time, lerp));
			}
			return new Vector3(mainCurve.Evaluate(time, lerp), mainCurve.Evaluate(time, lerp), mainCurve.Evaluate(time, lerp));
		}

		public Vector3 EvaluateZ(float time, float lerp)
		{
			if (separated)
			{
				return new Vector3(0f, 0f, zCurve.Evaluate(time, lerp));
			}
			return new Vector3(0f, 0f, mainCurve.Evaluate(time, lerp));
		}

		public Vector2 EvaluateXY(float time, float lerp)
		{
			if (separated)
			{
				return new Vector2(xCurve.Evaluate(time, lerp), yCurve.Evaluate(time, lerp));
			}
			return new Vector2(mainCurve.Evaluate(time, lerp), mainCurve.Evaluate(time, lerp));
		}
	}
}
