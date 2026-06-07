using System;

namespace Crosstales.NAudio.Wave
{
	public interface IWaveIn : IDisposable
	{
		WaveFormat WaveFormat { get; set; }

		event EventHandler<WaveInEventArgs> DataAvailable;

		event EventHandler<StoppedEventArgs> RecordingStopped;

		void StartRecording();

		void StopRecording();
	}
}
