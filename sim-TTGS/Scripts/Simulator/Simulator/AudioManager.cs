using System.Collections.Generic;
using Dhs5.Utility.Debuggers;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Simulator
{
	public static class AudioManager
	{
		private static readonly Dictionary<GUID, EventInstance> _snapshots = new Dictionary<GUID, EventInstance>();

		public static void PlaySingleEvent(EventReference eventReference, Object context = null)
		{
			if (!eventReference.IsNull)
			{
				EventInstance eventInstance;
				try
				{
					eventInstance = RuntimeManager.CreateInstance(eventReference);
				}
				catch (EventNotFoundException exception)
				{
					Debugger<EDebugCategory>.LogError(EDebugCategory.AUDIO, "Event not found exception!", context);
					UnityEngine.Debug.LogException(exception);
					return;
				}
				if (eventInstance.isValid())
				{
					eventInstance.start();
					eventInstance.release();
				}
			}
		}

		public static void PlaySingleEventAt(EventReference eventReference, Vector3 position, Object context = null)
		{
			if (!eventReference.IsNull)
			{
				EventInstance eventInstance;
				try
				{
					eventInstance = RuntimeManager.CreateInstance(eventReference);
				}
				catch (EventNotFoundException exception)
				{
					Debugger<EDebugCategory>.LogError(EDebugCategory.AUDIO, "Event not found exception!", context);
					UnityEngine.Debug.LogException(exception);
					return;
				}
				if (eventInstance.isValid())
				{
					eventInstance.set3DAttributes(position.To3DAttributes());
					eventInstance.start();
					eventInstance.release();
				}
			}
		}

		public static void PlaySingleEventOn(EventReference eventReference, Transform transform, Object context = null)
		{
			if (!eventReference.IsNull)
			{
				EventInstance instance;
				try
				{
					instance = RuntimeManager.CreateInstance(eventReference);
				}
				catch (EventNotFoundException exception)
				{
					Debugger<EDebugCategory>.LogError(EDebugCategory.AUDIO, "Event not found exception!", context);
					UnityEngine.Debug.LogException(exception);
					return;
				}
				if (instance.isValid())
				{
					RuntimeManager.AttachInstanceToGameObject(instance, transform);
					instance.start();
					instance.release();
				}
			}
		}

		public static EventInstance PlayPersistentEvent(EventReference eventReference, bool withoutRelease = false, Object context = null)
		{
			if (eventReference.IsNull)
			{
				return default(EventInstance);
			}
			EventInstance result;
			try
			{
				result = RuntimeManager.CreateInstance(eventReference);
			}
			catch (EventNotFoundException exception)
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.AUDIO, "Event not found exception!", context);
				UnityEngine.Debug.LogException(exception);
				return default(EventInstance);
			}
			if (!result.isValid())
			{
				return default(EventInstance);
			}
			result.start();
			if (!withoutRelease)
			{
				result.release();
			}
			return result;
		}

		public static EventInstance PlayPersistentEventAt(EventReference eventReference, Vector3 position, bool withoutRelease = false, Object context = null)
		{
			if (eventReference.IsNull)
			{
				return default(EventInstance);
			}
			EventInstance result;
			try
			{
				result = RuntimeManager.CreateInstance(eventReference);
			}
			catch (EventNotFoundException exception)
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.AUDIO, "Event not found exception!", context);
				UnityEngine.Debug.LogException(exception);
				return default(EventInstance);
			}
			if (!result.isValid())
			{
				return default(EventInstance);
			}
			result.set3DAttributes(position.To3DAttributes());
			result.start();
			if (!withoutRelease)
			{
				result.release();
			}
			return result;
		}

		public static EventInstance PlayPersistentEventOn(EventReference eventReference, Transform transform, bool withoutRelease = false, Object context = null)
		{
			if (eventReference.IsNull)
			{
				return default(EventInstance);
			}
			EventInstance eventInstance;
			try
			{
				eventInstance = RuntimeManager.CreateInstance(eventReference);
			}
			catch (EventNotFoundException exception)
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.AUDIO, "Event not found exception!", context);
				UnityEngine.Debug.LogException(exception);
				return default(EventInstance);
			}
			if (!eventInstance.isValid())
			{
				return default(EventInstance);
			}
			RuntimeManager.AttachInstanceToGameObject(eventInstance, transform);
			eventInstance.start();
			if (!withoutRelease)
			{
				eventInstance.release();
			}
			return eventInstance;
		}

		public static void StartEvent(EventInstance instance)
		{
			instance.start();
		}

		public static void StopEvent(EventInstance instance, FMOD.Studio.STOP_MODE stopMode = FMOD.Studio.STOP_MODE.ALLOWFADEOUT)
		{
			instance.stop(stopMode);
		}

		public static void ReleaseEvent(EventInstance instance)
		{
			instance.release();
		}

		public static void SetParameter(PARAMETER_ID id, float value)
		{
			RESULT rESULT = RuntimeManager.StudioSystem.setParameterByID(id, value);
			if (rESULT != RESULT.OK)
			{
				RuntimeUtils.DebugLogError($"[FMOD] failed to set parameter {id} : result = {rESULT}");
			}
		}

		public static bool TryGetParameterByName(string parameter, out PARAMETER_DESCRIPTION desc)
		{
			desc = default(PARAMETER_DESCRIPTION);
			if (string.IsNullOrEmpty(parameter))
			{
				return false;
			}
			RESULT parameterDescriptionByName = RuntimeManager.StudioSystem.getParameterDescriptionByName(parameter, out desc);
			if (parameterDescriptionByName != RESULT.OK)
			{
				RuntimeUtils.DebugLogError($"[FMOD] failed to lookup parameter {parameter} : result = {parameterDescriptionByName}");
				return false;
			}
			return true;
		}

		public static void StartSnapshot(EventReference snapshotReference)
		{
			if (snapshotReference.IsNull)
			{
				return;
			}
			if (_snapshots.TryGetValue(snapshotReference.Guid, out var value))
			{
				value.start();
				return;
			}
			EventInstance value2 = RuntimeManager.CreateInstance(snapshotReference);
			if (value2.isValid())
			{
				value2.start();
				_snapshots.Add(snapshotReference.Guid, value2);
			}
		}

		public static void StopSnapshot(EventReference snapshotReference, FMOD.Studio.STOP_MODE stopMode = FMOD.Studio.STOP_MODE.ALLOWFADEOUT)
		{
			if (!snapshotReference.IsNull && _snapshots.TryGetValue(snapshotReference.Guid, out var value))
			{
				value.stop(stopMode);
			}
		}

		public static void ReleaseSnapshot(EventReference snapshotReference)
		{
			if (!snapshotReference.IsNull && _snapshots.TryGetValue(snapshotReference.Guid, out var value))
			{
				value.release();
				_snapshots.Remove(snapshotReference.Guid);
			}
		}
	}
}
