using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class SessionCollection
	{
		private readonly IAudioSessionEnumerator audioSessionEnumerator;

		public AudioSessionControl this[int index] => null;

		public int Count => 0;

		internal SessionCollection(IAudioSessionEnumerator realEnumerator)
		{
		}
	}
}
