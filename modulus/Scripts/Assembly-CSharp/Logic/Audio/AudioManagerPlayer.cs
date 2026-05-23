#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using Events;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.Audio
{
	[DefaultExecutionOrder(-5000)]
	public class AudioManagerPlayer : MonoBehaviour
	{
		private const int MaxDuplicateEventsPerFrame = 4;

		[SerializeField]
		private AudioManagerPool _pool;

		[SerializeField]
		private BaseEvent _levelClearedEvent;

		[Header("Culling")]
		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private float _cullOneShotDistance = 20f;

		private readonly Dictionary<GUID, List<IAudioManagerQueuedEvent>> _queuedEvents = new Dictionary<GUID, List<IAudioManagerQueuedEvent>>();

		private void Awake()
		{
			_levelClearedEvent.Register(OnLevelCleared);
		}

		private void OnDestroy()
		{
			_levelClearedEvent.UnRegister(OnLevelCleared);
		}

		private void OnLevelCleared()
		{
			_queuedEvents.Clear();
		}

		private void LateUpdate()
		{
			try
			{
				foreach (List<IAudioManagerQueuedEvent> value in _queuedEvents.Values)
				{
					for (int i = 0; i < value.Count; i++)
					{
						value[i].Start(this);
					}
				}
			}
			catch (Exception pException)
			{
				_queuedEvents.Clear();
				this.DevException(pException, "LateUpdate", 56);
			}
			_queuedEvents.Clear();
		}

		internal void PlayOneShot(EventReference eventReference, bool force = false)
		{
			if (force)
			{
				PlayOneShotInternal(eventReference, is3D: false, Vector3.zero, string.Empty, 0);
				return;
			}
			AudioManagerQueuedEvent audioManagerQueuedEvent = new AudioManagerQueuedEvent(eventReference, 0f);
			QueueEventInstance(audioManagerQueuedEvent);
		}

		internal void PlayOneShot(EventReference eventReference, Vector3 position, bool force = false)
		{
			if (force)
			{
				PlayOneShotInternal(eventReference, is3D: true, position, string.Empty, 0);
				return;
			}
			float sqrMagnitude = (_cameraViewLocator.CameraView.ListenerPosition - position).sqrMagnitude;
			if (!(sqrMagnitude > _cullOneShotDistance * _cullOneShotDistance))
			{
				AudioManagerQueuedEvent audioManagerQueuedEvent = new AudioManagerQueuedEvent(eventReference, position, 0f - sqrMagnitude);
				QueueEventInstance(audioManagerQueuedEvent);
			}
		}

		internal void PlayOneShot(EventReference eventReference, string parameterName, int parameterValue, bool force = false)
		{
			if (force)
			{
				PlayOneShotInternal(eventReference, is3D: false, Vector3.zero, parameterName, parameterValue);
				return;
			}
			AudioManagerQueuedEvent audioManagerQueuedEvent = new AudioManagerQueuedEvent(eventReference, parameterName, parameterValue, 0f);
			QueueEventInstance(audioManagerQueuedEvent);
		}

		internal void PlayOneShot(EventReference eventReference, Vector3 position, string parameterName, int parameterValue, bool force = false)
		{
			if (force)
			{
				PlayOneShotInternal(eventReference, is3D: true, position, parameterName, parameterValue);
				return;
			}
			float sqrMagnitude = (_cameraViewLocator.CameraView.ListenerPosition - position).sqrMagnitude;
			if (!(sqrMagnitude > _cullOneShotDistance * _cullOneShotDistance))
			{
				AudioManagerQueuedEvent audioManagerQueuedEvent = new AudioManagerQueuedEvent(eventReference, position, parameterName, parameterValue, 0f - sqrMagnitude);
				QueueEventInstance(audioManagerQueuedEvent);
			}
		}

		internal void PlayOneShotInternal(EventReference eventReference, bool is3D, Vector3 position, string parameterName, int parameterValue)
		{
			EventInstance instance = _pool.GetInstance(eventReference);
			if (!string.IsNullOrEmpty(parameterName))
			{
				instance.setParameterByName(parameterName, parameterValue);
			}
			if (is3D)
			{
				instance.set3DAttributes(position.To3DAttributes());
			}
			instance.start();
		}

		internal EventInstance PlayLoop(EventReference eventReference)
		{
			EventInstance instance = _pool.GetInstance(eventReference, isLoop: true);
			instance.start();
			return instance;
		}

		internal EventInstance PlayLoop(EventReference eventReference, Vector3 position)
		{
			EventInstance instance = _pool.GetInstance(eventReference, isLoop: true);
			instance.set3DAttributes(position.To3DAttributes());
			instance.start();
			return instance;
		}

		internal EventInstance PlayLoop(EventReference eventReference, Vector3 position, string parameterName, int parameterValue)
		{
			EventInstance instance = _pool.GetInstance(eventReference, isLoop: true);
			instance.setParameterByName(parameterName, parameterValue);
			instance.set3DAttributes(position.To3DAttributes());
			instance.start();
			return instance;
		}

		internal EventInstance PlayLoop(EventReference eventReference, GameObject attachedGameObject)
		{
			EventInstance instance = _pool.GetInstance(eventReference, isLoop: true);
			RuntimeManager.AttachInstanceToGameObject(instance, attachedGameObject, nonRigidbodyVelocity: true);
			instance.start();
			return instance;
		}

		internal void StopLoop(ref EventInstance instance, bool fadeOut)
		{
			instance.stop((!fadeOut) ? FMOD.Studio.STOP_MODE.IMMEDIATE : FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_pool.ReturnInstanceToPool(instance);
			instance.clearHandle();
		}

		private void QueueEventInstance(IAudioManagerQueuedEvent eventToQueue)
		{
			if (!_queuedEvents.TryGetValue(eventToQueue.GUID, out var value))
			{
				value = new List<IAudioManagerQueuedEvent>(5);
				_queuedEvents.Add(eventToQueue.GUID, value);
			}
			int num = value.Count - 1;
			while (num >= 0 && !(eventToQueue.Priority <= value[num].Priority))
			{
				num--;
			}
			if (num >= value.Count - 1)
			{
				if (value.Count < 4)
				{
					value.Add(eventToQueue);
				}
				return;
			}
			value.Insert(num + 1, eventToQueue);
			if (value.Count > 4)
			{
				value.RemoveAt(value.Count - 1);
			}
		}
	}
}
