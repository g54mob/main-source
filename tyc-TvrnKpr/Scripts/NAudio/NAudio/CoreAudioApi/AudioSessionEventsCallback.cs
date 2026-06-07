using System;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioSessionEventsCallback : IAudioSessionEvents
	{
		private readonly IAudioSessionEventsHandler audioSessionEventsHandler;

		public AudioSessionEventsCallback(IAudioSessionEventsHandler handler)
		{
		}

		public int OnDisplayNameChanged([In] string displayName, [In] ref Guid eventContext)
		{
			return 0;
		}

		public int OnIconPathChanged([In] string iconPath, [In] ref Guid eventContext)
		{
			return 0;
		}

		public int OnSimpleVolumeChanged([In] float volume, [In] bool isMuted, [In] ref Guid eventContext)
		{
			return 0;
		}

		public int OnChannelVolumeChanged([In] uint channelCount, [In] IntPtr newVolumes, [In] uint channelIndex, [In] ref Guid eventContext)
		{
			return 0;
		}

		public int OnGroupingParamChanged([In] ref Guid groupingId, [In] ref Guid eventContext)
		{
			return 0;
		}

		public int OnStateChanged([In] AudioSessionState state)
		{
			return 0;
		}

		public int OnSessionDisconnected([In] AudioSessionDisconnectReason disconnectReason)
		{
			return 0;
		}
	}
}
