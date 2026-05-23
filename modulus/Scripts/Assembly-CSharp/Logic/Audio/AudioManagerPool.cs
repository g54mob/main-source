#define ENABLE_DEBUG_EXCEPTIONS
using System;
using System.Collections.Generic;
using Events;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Utils;

namespace Logic.Audio
{
	public class AudioManagerPool : MonoBehaviour
	{
		private struct EventInstancePair
		{
			public GUID Guid;

			public EventInstancePair(GUID guid)
			{
				Guid = guid;
			}
		}

		[SerializeField]
		private BaseEvent _levelClearedEvent;

		private readonly Dictionary<GUID, List<IntPtr>> _oneShotCollections = new Dictionary<GUID, List<IntPtr>>();

		private readonly Dictionary<IntPtr, GUID> _oneShotsHandleToGuid = new Dictionary<IntPtr, GUID>();

		private void Awake()
		{
			_levelClearedEvent.Register(OnLevelCleared);
		}

		private void OnDestroy()
		{
			_levelClearedEvent.UnRegister(OnLevelCleared);
			ClearAllInstances();
		}

		private void OnLevelCleared()
		{
			ClearAllInstances();
		}

		private void ClearAllInstances()
		{
			EventInstance eventInstance = default(EventInstance);
			foreach (IntPtr key in _oneShotsHandleToGuid.Keys)
			{
				eventInstance.handle = key;
				eventInstance.release();
			}
			_oneShotCollections.Clear();
		}

		private List<IntPtr> GetInstanceCollection(GUID guid)
		{
			if (!_oneShotCollections.TryGetValue(guid, out var value))
			{
				value = new List<IntPtr>();
				_oneShotCollections.Add(guid, value);
			}
			return value;
		}

		internal EventInstance GetInstance(EventReference eventReference, bool isLoop = false)
		{
			List<IntPtr> instanceCollection = GetInstanceCollection(eventReference.Guid);
			EventInstance result = default(EventInstance);
			if (instanceCollection.Count > 0)
			{
				result.handle = instanceCollection[0];
				result.getPlaybackState(out var state);
				if (state == PLAYBACK_STATE.STOPPED)
				{
					instanceCollection.RemoveAt(0);
				}
				else
				{
					result = CreateInstance(eventReference);
				}
			}
			else
			{
				result = CreateInstance(eventReference);
			}
			if (!isLoop)
			{
				instanceCollection.Add(result.handle);
			}
			return result;
			EventInstance CreateInstance(EventReference eventReference2)
			{
				EventInstance result2 = RuntimeManager.CreateInstance(eventReference2);
				_oneShotsHandleToGuid.Add(result2.handle, eventReference2.Guid);
				return result2;
			}
		}

		internal void ReturnInstanceToPool(EventInstance eventInstance)
		{
			if (!_oneShotsHandleToGuid.TryGetValue(eventInstance.handle, out var value))
			{
				eventInstance.release();
				this.DevException("Failed: Tried returning an instance that was never in a pool", "ReturnInstanceToPool", 110);
			}
			else
			{
				GetInstanceCollection(value).Add(eventInstance.handle);
			}
		}
	}
}
