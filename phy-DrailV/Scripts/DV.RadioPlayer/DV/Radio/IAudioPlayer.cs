namespace DV.Radio
{
	public interface IAudioPlayer
	{
		bool StopOnFocusLost { get; set; }

		bool IsStopped { get; }

		RecordInfo CurrentRecordInfo { get; }

		RadioStationInfo CurrentStationInfo { get; }

		void Play();

		void Stop();

		bool Pause();

		long GetSeekPosition();

		void SetSeekPosition(long position);
	}
}
