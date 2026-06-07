using System;
using System.Runtime.CompilerServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioEndpointVolume : IDisposable
	{
		private readonly IAudioEndpointVolume audioEndPointVolume;

		private readonly AudioEndpointVolumeChannels channels;

		private readonly AudioEndpointVolumeStepInformation stepInformation;

		private readonly AudioEndpointVolumeVolumeRange volumeRange;

		private readonly EEndpointHardwareSupport hardwareSupport;

		private AudioEndpointVolumeCallback callBack;

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

		public AudioEndpointVolumeVolumeRange VolumeRange => null;

		public EEndpointHardwareSupport HardwareSupport => default(EEndpointHardwareSupport);

		public AudioEndpointVolumeStepInformation StepInformation => null;

		public AudioEndpointVolumeChannels Channels => null;

		public float MasterVolumeLevel
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MasterVolumeLevelScalar
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Mute
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event AudioEndpointVolumeNotificationDelegate OnVolumeNotification
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void VolumeStepUp()
		{
		}

		public void VolumeStepDown()
		{
		}

		internal AudioEndpointVolume(IAudioEndpointVolume realEndpointVolume)
		{
		}

		internal void FireNotification(AudioVolumeNotificationData notificationData)
		{
		}

		public void Dispose()
		{
		}

		~AudioEndpointVolume()
		{
		}
	}
}
