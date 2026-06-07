using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	public abstract class CoreLibraryPlaybackScriptable : EffectPlaybackScriptableBase
	{
		[SerializeField]
		private string tagID;

		private IEffectPlayback playback;

		public override string TagID => tagID;

		protected abstract IEffectPlayback Playback { get; }

		public override IEffectPhase Phase { get; }

		public override void UpdateParameters(RegionParameters parameters)
		{
			playback?.UpdateParameters(parameters);
		}

		private void OnEnable()
		{
		}

		public override void Initialize()
		{
			playback = Playback;
			if (playback == null)
			{
				throw new NullReferenceException("Playback is null in " + base.name);
			}
			playback.Initialize();
		}

		public override float GetTotalDuration()
		{
			return playback?.GetTotalDuration() ?? 0f;
		}

		public override void CalculateIntensity01(float time, out float intensity, out bool hasFinishedEffect)
		{
			if (playback != null)
			{
				playback.CalculateIntensity01(time, out intensity, out hasFinishedEffect);
				return;
			}
			intensity = 0f;
			hasFinishedEffect = true;
		}
	}
}
