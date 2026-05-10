using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentActionPinball : AgentActionUseStationNeedFill
	{
		private static readonly StringKey _pinballLoopAnimation = "PinballLoop";

		private static readonly StringKey _pinballIdleAnimation = "PinballIdle";

		private AudioSource _audioSource;

		public override IEnumerator ActionRoutine()
		{
			StationNeedFill station = base.Station;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PinballEnter);
			if (base.ActionAgent.TryGetComponent<SituationnalBarks>(out var component))
			{
				component.Flipper();
			}
			int animCount = Random.Range(1, 3);
			float statAmount = station.Data.ValueIncrease.RandomInRange() / (float)animCount;
			for (int animIndex = 0; animIndex < animCount; animIndex++)
			{
				_audioSource = MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(station.Data.PossibleSounds, station.transform.position);
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PinballStartGame);
				station.PlayAnimation(_pinballLoopAnimation);
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PinballLoop);
				base.ActionAgent.Statistics.AddToStatisticUnitInterval(station.Data.Stat, statAmount);
			}
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PinballExit);
		}

		public override void OnCancel()
		{
			base.OnCancel();
			if ((bool)base.Station)
			{
				base.Station.PlayAnimation(_pinballIdleAnimation);
			}
			if (_audioSource != null)
			{
				_audioSource.Stop();
			}
		}
	}
}
