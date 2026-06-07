using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioStreamVolume : IDisposable
	{
		private IAudioStreamVolume audioStreamVolumeInterface;

		public int ChannelCount => 0;

		internal AudioStreamVolume(IAudioStreamVolume audioStreamVolumeInterface)
		{
		}

		private void CheckChannelIndex(int channelIndex, string parameter)
		{
		}

		public float[] GetAllVolumes()
		{
			return null;
		}

		public float GetChannelVolume(int channelIndex)
		{
			return 0f;
		}

		public void SetAllVolumes(float[] levels)
		{
		}

		public void SetChannelVolume(int index, float level)
		{
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
