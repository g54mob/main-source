using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class AudioClockClient : IDisposable
	{
		private IAudioClock audioClockClientInterface;

		public int Characteristics => 0;

		public ulong Frequency => 0uL;

		public ulong AdjustedPosition => 0uL;

		public bool CanAdjustPosition => false;

		internal AudioClockClient(IAudioClock audioClockClientInterface)
		{
		}

		public bool GetPosition(out ulong position, out ulong qpcPosition)
		{
			position = default(ulong);
			qpcPosition = default(ulong);
			return false;
		}

		public void Dispose()
		{
		}
	}
}
