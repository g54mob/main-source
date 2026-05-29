using System.Collections;
using Animancer;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using CTS.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class AgentActionPlayDarts : AgentActionUseStationNeedFill
	{
		private static Resource<GameObject> _dartPrefab = "Prefabs/pfb_Dart";

		private PooledObject _dart;

		private StringKey _dartTargetKey = "DartTarget";

		private AudioSource _audioSource;

		public override IEnumerator ActionRoutine()
		{
			StationNeedFill station = base.Station;
			AnimationTracker anim = base.ActionAgent.Animator.PlayPunctual(station.Data.PossibleAnimations.GetRandom(), FadeMode.FromStart);
			_audioSource = MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(station.Data.PossibleSounds, station.transform.position);
			if (base.ActionAgent.SkeletonData.TryGetBone(EBone.LHand, out var boneTransform))
			{
				GameObject value = _dartPrefab.Value;
				_dart = Pooler.Pull(value, boneTransform, active: true);
				_dart.transform.SetLocalPositionAndRotation(value.transform.localPosition, value.transform.localRotation);
			}
			if (base.ActionAgent.TryGetComponent<SituationnalBarks>(out var component))
			{
				component.Darts();
			}
			bool threwDart = false;
			while (anim.keepWaiting)
			{
				if (!threwDart && anim.GetNormalizedTime >= 0.7f)
				{
					threwDart = true;
					if ((bool)_dart && station.Targets.TryGetValue(_dartTargetKey, out var value2) && value2.Length != 0)
					{
						Transform random = value2.GetRandom();
						_dart.transform.SetParent(null);
						_dart.transform.LookAt(random.position);
						_dart.transform.DOMove(random.position, 0.25f);
					}
				}
				yield return null;
			}
			base.ActionAgent.Statistics.AddToStatisticUnitInterval(station.Data.Stat, station.Data.ValueIncrease.RandomInRange());
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			if ((bool)_dart)
			{
				Pooler.Push(_dart);
			}
			_dart = null;
		}

		public override void OnCancel()
		{
			base.OnCancel();
			if (_audioSource != null)
			{
				_audioSource.Stop();
			}
		}
	}
}
