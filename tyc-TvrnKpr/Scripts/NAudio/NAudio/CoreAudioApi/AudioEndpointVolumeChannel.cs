using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeChannel
	{
		private readonly uint channel;

		private readonly IAudioEndpointVolume audioEndpointVolume;

		private Guid notificationGuid;

		public Guid NotificationGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public float VolumeLevel
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float VolumeLevelScalar
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal AudioEndpointVolumeChannel(IAudioEndpointVolume parent, int channel)
		{
		}
	}
}
