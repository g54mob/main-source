using System;

namespace NAudio.CoreAudioApi
{
	public class AudioVolumeNotificationData
	{
		private readonly Guid eventContext;

		private readonly bool muted;

		private readonly float masterVolume;

		private readonly int channels;

		private readonly float[] channelVolume;

		private readonly Guid guid;

		public Guid EventContext => default(Guid);

		public bool Muted => false;

		public Guid Guid => default(Guid);

		public float MasterVolume => 0f;

		public int Channels => 0;

		public float[] ChannelVolume => null;

		public AudioVolumeNotificationData(Guid eventContext, bool muted, float masterVolume, float[] channelVolume, Guid guid)
		{
		}
	}
}
