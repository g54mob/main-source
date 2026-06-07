using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace DarkTonic.MasterAudio
{
	[Serializable]
	public class GroupBus
	{
		public string busName;

		public float volume;

		public bool isSoloed;

		public bool isMuted;

		public int voiceLimit;

		public bool isExisting;

		public bool isTemporary;

		public bool isUsingOcclusion;

		public MasterAudio.BusVoiceLimitExceededMode busVoiceLimitExceededMode;

		public Color busColor;

		public AudioMixerGroup mixerChannel;

		public bool forceTo2D;

		private readonly List<int> _activeAudioSourcesIds;

		private readonly List<int> _actorInstanceIds;

		private float _originalVolume;

		public int ActiveVoices => 0;

		public bool HasLiveActors => false;

		public bool BusVoiceLimitReached => false;

		public float OriginalVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void AddActorInstanceId(int instanceId)
		{
		}

		public void RemoveActorInstanceId(int instanceId)
		{
		}

		public void AddActiveAudioSourceId(int id)
		{
		}

		public void RemoveActiveAudioSourceId(int id)
		{
		}
	}
}
