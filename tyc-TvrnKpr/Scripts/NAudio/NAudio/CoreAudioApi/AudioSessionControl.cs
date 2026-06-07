using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioSessionControl : IDisposable
	{
		private readonly IAudioSessionControl audioSessionControlInterface;

		private readonly IAudioSessionControl2 audioSessionControlInterface2;

		private AudioSessionEventsCallback audioSessionEventCallback;

		public AudioMeterInformation AudioMeterInformation { get; }

		public SimpleAudioVolume SimpleAudioVolume { get; }

		public AudioSessionState State => default(AudioSessionState);

		public string DisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string IconPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string GetSessionIdentifier => null;

		public string GetSessionInstanceIdentifier => null;

		public uint GetProcessID => 0u;

		public bool IsSystemSoundsSession => false;

		public AudioSessionControl(IAudioSessionControl audioSessionControl)
		{
		}

		public void Dispose()
		{
		}

		~AudioSessionControl()
		{
		}

		public Guid GetGroupingParam()
		{
			return default(Guid);
		}

		public void SetGroupingParam(Guid groupingId, Guid context)
		{
		}

		public void RegisterEventClient(IAudioSessionEventsHandler eventClient)
		{
		}

		public void UnRegisterEventClient(IAudioSessionEventsHandler eventClient)
		{
		}
	}
}
