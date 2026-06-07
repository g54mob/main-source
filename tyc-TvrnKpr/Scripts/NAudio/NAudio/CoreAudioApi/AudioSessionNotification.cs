using System.Runtime.InteropServices;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	internal class AudioSessionNotification : IAudioSessionNotification
	{
		private AudioSessionManager parent;

		internal AudioSessionNotification(AudioSessionManager parent)
		{
		}

		[PreserveSig]
		public int OnSessionCreated(IAudioSessionControl newSession)
		{
			return 0;
		}
	}
}
