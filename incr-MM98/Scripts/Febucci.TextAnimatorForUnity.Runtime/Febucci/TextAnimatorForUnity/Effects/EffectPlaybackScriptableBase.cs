using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	public abstract class EffectPlaybackScriptableBase : ScriptableObject, IEffectPlayback, IParameterUpdater, ITagProvider
	{
		public abstract IEffectPhase Phase { get; }

		public abstract string TagID { get; }

		public abstract void UpdateParameters(RegionParameters parameters);

		public abstract void Initialize();

		public abstract float GetTotalDuration();

		public abstract void CalculateIntensity01(float time, out float intensity, out bool hasFinishedEffect);
	}
}
