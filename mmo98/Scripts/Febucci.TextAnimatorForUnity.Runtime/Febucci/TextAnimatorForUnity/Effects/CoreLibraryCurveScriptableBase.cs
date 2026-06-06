using System;
using Febucci.TextAnimatorCore;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	public abstract class CoreLibraryCurveScriptableBase<TEffectCurve> : EffectCurveScriptableBase where TEffectCurve : IEffectCurve, new()
	{
		[SerializeField]
		private TEffectCurve curve;

		private bool initialized;

		public override int BakeResolution => curve.BakeResolution;

		public sealed override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				TEffectCurve val = curve;
				if (val == null)
				{
					curve = new TEffectCurve();
				}
				if (curve == null)
				{
					throw new Exception($"Unable to instantiate effect of type: {typeof(TEffectCurve)}");
				}
				OnInitialize();
			}
		}

		protected virtual void OnInitialize()
		{
		}

		public override float Evaluate01(float time)
		{
			return curve.Evaluate01(time);
		}

		public override float EvaluateRange(float time)
		{
			return curve.EvaluateRange(time);
		}

		private void OnEnable()
		{
			initialized = false;
		}
	}
}
