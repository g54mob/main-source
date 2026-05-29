using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class Toilet : FurnitureInteractor, IContextActor
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		public ToiletSettingsSO ToiletSettingsSO;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private float _openRotation;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private AnimationCurve _openEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _closedRotation;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private AnimationCurve _closeEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _doorRotationDuration;

		[SerializeField]
		[BoxGroup("Sounds Settings")]
		public MachineSoundsScriptableObject sfxToiletList;

		[SerializeField]
		[BoxGroup("VFX Settings")]
		private Transform _vfxAnchor;

		[SerializeField]
		[BoxGroup("VFX Settings")]
		private JunkObjectParameters[] _vfxPee;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private Transform[] _doorTransform;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		public NavMeshObstacle NavMeshObstacle;

		[SerializeField]
		[BoxGroup("Debug Data")]
		private bool _debugMode;

		[ReadOnly]
		[SerializeField]
		[BoxGroup("Debug Data")]
		private bool _doorStatus;

		[ReadOnly]
		[SerializeField]
		[BoxGroup("Debug Data")]
		private float _dirtiness;

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; } = new ContextActorData();

		[field: SerializeField]
		[field: Space(10f)]
		[field: BoxGroup("Base Settings")]
		public MoveTarget LoadTarget { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Base Settings")]
		public MoveTarget LoadedTarget { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Base Settings")]
		public MoveTarget UnloadTarget { get; private set; }

		public bool IsDirty { get; set; }

		public bool IsOpened => _doorStatus;

		public bool UsageCondition(Agent _agent)
		{
			if (!_agent.IsHuman)
			{
				return false;
			}
			if (IsDirty)
			{
				return false;
			}
			return true;
		}

		public void DirtinessUpdate(float incrementValue)
		{
			_dirtiness += incrementValue;
			if (_dirtiness >= 100f)
			{
				JunkObject.Spawn(_vfxPee[Random.Range(0, _vfxPee.Length)], _vfxAnchor.position, Quaternion.identity, base.Furniture);
				IsDirty = true;
				_dirtiness = 0f;
			}
		}

		public void OnPlaySFXMachine(AudioAsset AudioAsset)
		{
			MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(AudioAsset, base.transform.position);
		}

		public Tween OpenCloseDoor(float _timingBetween)
		{
			Sequence sequence = DOTween.Sequence();
			sequence.Append(OpenDoorTween());
			sequence.AppendInterval(_timingBetween + 1f);
			sequence.Append(CloseDoorTween());
			return sequence;
		}

		public Tween OpenDoorTween()
		{
			_ = _debugMode;
			Sequence sequence = DOTween.Sequence();
			_doorStatus = true;
			OnPlaySFXMachine(sfxToiletList.SoundsList[0]);
			Transform[] doorTransform = _doorTransform;
			foreach (Transform item in doorTransform)
			{
				sequence.AppendCallback(delegate
				{
					item.DOLocalRotate(new Vector3(0f, _openRotation, 0f), _doorRotationDuration).SetEase(_openEasing);
				});
			}
			return sequence;
		}

		public Tween CloseDoorTween()
		{
			_ = _debugMode;
			Sequence sequence = DOTween.Sequence();
			_doorStatus = false;
			OnPlaySFXMachine(sfxToiletList.SoundsList[1]);
			Transform[] doorTransform = _doorTransform;
			foreach (Transform item in doorTransform)
			{
				sequence.AppendCallback(delegate
				{
					item.DOLocalRotate(new Vector3(0f, _closedRotation, 0f), _doorRotationDuration).SetEase(_closeEasing);
				});
			}
			return sequence;
		}
	}
}
