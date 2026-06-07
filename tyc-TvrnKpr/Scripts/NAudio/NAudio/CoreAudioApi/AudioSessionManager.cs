using System.Runtime.CompilerServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioSessionManager
	{
		public delegate void SessionCreatedDelegate(object sender, IAudioSessionControl newSession);

		private readonly IAudioSessionManager audioSessionInterface;

		private readonly IAudioSessionManager2 audioSessionInterface2;

		private AudioSessionNotification audioSessionNotification;

		private SessionCollection sessions;

		private SimpleAudioVolume simpleAudioVolume;

		private AudioSessionControl audioSessionControl;

		public SimpleAudioVolume SimpleAudioVolume => null;

		public AudioSessionControl AudioSessionControl => null;

		public SessionCollection Sessions => null;

		public event SessionCreatedDelegate OnSessionCreated
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

		internal AudioSessionManager(IAudioSessionManager audioSessionManager)
		{
		}

		internal void FireSessionCreated(IAudioSessionControl newSession)
		{
		}

		public void RefreshSessions()
		{
		}

		public void Dispose()
		{
		}

		private void UnregisterNotifications()
		{
		}

		~AudioSessionManager()
		{
		}
	}
}
