using FMOD;
using FMODUnity;
using UnityEngine;

namespace Logic.Audio
{
	public struct AudioManagerQueuedEvent : IAudioManagerQueuedEvent
	{
		private readonly EventReference _eventReference;

		private readonly float _priority;

		private readonly bool _is3D;

		private readonly Vector3 _position;

		private readonly string _parameterName;

		private readonly int _parameterValue;

		GUID IAudioManagerQueuedEvent.GUID => _eventReference.Guid;

		float IAudioManagerQueuedEvent.Priority => _priority;

		public AudioManagerQueuedEvent(EventReference reference, float priority)
		{
			_eventReference = reference;
			_priority = priority;
			_is3D = false;
			_position = Vector3.zero;
			_parameterName = string.Empty;
			_parameterValue = 0;
		}

		public AudioManagerQueuedEvent(EventReference reference, Vector3 position, float priority)
		{
			_eventReference = reference;
			_priority = priority;
			_is3D = true;
			_position = position;
			_parameterName = string.Empty;
			_parameterValue = 0;
		}

		public AudioManagerQueuedEvent(EventReference reference, string parameterName, int parameterValue, float priority)
		{
			_eventReference = reference;
			_priority = priority;
			_is3D = false;
			_position = Vector3.zero;
			_parameterName = parameterName;
			_parameterValue = parameterValue;
		}

		public AudioManagerQueuedEvent(EventReference reference, Vector3 position, string parameterName, int parameterValue, float priority)
		{
			_eventReference = reference;
			_priority = priority;
			_is3D = true;
			_position = position;
			_parameterName = parameterName;
			_parameterValue = parameterValue;
		}

		void IAudioManagerQueuedEvent.Start(AudioManagerPlayer pool)
		{
			pool.PlayOneShotInternal(_eventReference, _is3D, _position, _parameterName, _parameterValue);
		}
	}
}
