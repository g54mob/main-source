using System;
using Febucci.TextAnimatorCore;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	public abstract class EffectCurveScriptableBase : ScriptableObject, IEffectCurve
	{
		public abstract int BakeResolution { get; }

		public abstract float Evaluate01(float time);

		public abstract float EvaluateRange(float time);

		public virtual void Initialize()
		{
		}
	}
}
