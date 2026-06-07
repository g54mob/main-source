using System;
using Assets.Scripts.Audio;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class LuxuryHangarDoorScript : MonoBehaviour, INetworkTriggerStateTarget
	{
		private enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2,
			RX = 3,
			RY = 4,
			RZ = 5
		}

		[SerializeField]
		private Axis _axis = Axis.Z;

		[SerializeField]
		private Transform[] _doorParents;

		[SerializeField]
		private float _openDuration = 3f;

		[SerializeField]
		private float _positionWhenClosed = -4.5f;

		[SerializeField]
		private float _positionWhenOpen = -0.1f;

		[SerializeField]
		private AudioClip _sound;

		[SerializeField]
		private float _soundPitch = 1f;

		[SerializeField]
		private float _soundScale = 1f;

		[SerializeField]
		private AudioClip _soundEnd;

		[SerializeField]
		private AudioClip _soundStart;

		[SerializeField]
		private bool _recursive = true;

		private AudioSource _source;

		private AudioSource _sourceEnd;

		private AudioSource _sourceStart;

		private int _state;

		private Tween _doorMovement;

		public bool IsOpen { get; private set; }

		public event Action Opened;

		public void SetState(int state, bool initialState)
		{
			if (_state != state)
			{
				_state = state;
				if (_state == 1)
				{
					Open();
				}
				else
				{
					Close();
				}
			}
		}

		protected void Awake()
		{
			if (_soundStart != null && _sourceStart == null)
			{
				_sourceStart = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_sourceStart, AudioStore.HangarDoorAudio, _soundStart, loop: false);
				_sourceStart.volume *= _soundScale;
				_sourceStart.minDistance *= _soundScale;
				_sourceStart.maxDistance *= _soundScale;
			}
			if (_soundEnd != null && _sourceEnd == null)
			{
				_sourceEnd = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_sourceEnd, AudioStore.HangarDoorAudio, _soundEnd, loop: false);
				_sourceEnd.volume *= _soundScale;
				_sourceEnd.minDistance *= _soundScale;
				_sourceEnd.maxDistance *= _soundScale;
			}
			if (_sound != null && _source == null)
			{
				_source = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_source, AudioStore.HangarDoorAudio, _sound);
				_source.pitch = _soundPitch;
				_source.volume *= _soundScale;
				_source.minDistance *= _soundScale;
				_source.maxDistance *= _soundScale;
			}
		}

		private void AnimateDoorPanel(Transform doorPanelTransform, float target, int depth = 0)
		{
			Tween tween = null;
			switch (_axis)
			{
			case Axis.X:
				tween = doorPanelTransform.DOLocalMoveX(target, _openDuration);
				break;
			case Axis.Y:
				tween = doorPanelTransform.DOLocalMoveY(target, _openDuration);
				break;
			case Axis.Z:
				tween = doorPanelTransform.DOLocalMoveZ(target, _openDuration);
				break;
			case Axis.RX:
				tween = doorPanelTransform.DOLocalRotate(new Vector3((depth == 0) ? target : ((depth % 2 == 0) ? (2f * target) : (-2f * target)), 0f, 0f), _openDuration);
				break;
			case Axis.RY:
				tween = doorPanelTransform.DOLocalRotate(new Vector3(0f, (depth == 0) ? target : ((depth % 2 == 0) ? (2f * target) : (-2f * target)), 0f), _openDuration);
				break;
			case Axis.RZ:
				tween = doorPanelTransform.DOLocalRotate(new Vector3(0f, 0f, (depth == 0) ? target : ((depth % 2 == 0) ? (2f * target) : (-2f * target))), _openDuration);
				break;
			}
			if (_doorMovement == null && tween != null)
			{
				_doorMovement = tween;
				Tween doorMovement = _doorMovement;
				doorMovement.onComplete = (TweenCallback)Delegate.Combine(doorMovement.onComplete, new TweenCallback(AudioEnd));
			}
			if (!_recursive)
			{
				return;
			}
			foreach (Transform item in doorPanelTransform)
			{
				AnimateDoorPanel(item, target, depth + 1);
			}
		}

		private void AudioEnd()
		{
			if (_source != null)
			{
				_source.Stop();
			}
			if (_sourceEnd != null)
			{
				_sourceEnd.Play();
			}
			Tween doorMovement = _doorMovement;
			doorMovement.onComplete = (TweenCallback)Delegate.Remove(doorMovement.onComplete, new TweenCallback(AudioEnd));
			_doorMovement = null;
		}

		private void AudioStart()
		{
			if (_sourceStart != null)
			{
				_sourceStart.Play();
			}
			if (_source != null)
			{
				_source.timeSamples = (int)(UnityEngine.Random.value * (float)_source.clip.samples);
				_source.Play();
			}
		}

		private void Close()
		{
			Transform[] doorParents = _doorParents;
			foreach (Transform transform in doorParents)
			{
				AnimateDoorPanel(transform.GetChild(0), _positionWhenClosed);
			}
			AudioStart();
			IsOpen = false;
		}

		private void Open()
		{
			IsOpen = true;
			this.Opened?.Invoke();
			Transform[] doorParents = _doorParents;
			foreach (Transform transform in doorParents)
			{
				AnimateDoorPanel(transform.GetChild(0), _positionWhenOpen);
			}
			AudioStart();
		}
	}
}
