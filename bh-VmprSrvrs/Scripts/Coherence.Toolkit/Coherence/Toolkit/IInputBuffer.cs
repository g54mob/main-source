namespace Coherence.Toolkit
{
	public interface IInputBuffer
	{
		int Size { get; }

		int Delay { get; set; }

		long LastFrame { get; }

		long LastSentFrame { get; }

		long LastReceivedFrame { get; }

		long LastAcknowledgedFrame { get; }

		long LastConsumedFrame { get; }

		long? MispredictionFrame { get; }

		internal int QueueCount { get; }

		event StaleInputHandler OnStaleInput;

		bool ShouldPause(long currentFrame, long commonReceivedFrame);

		void Reset();

		internal bool TryPeekInput(long frame, out object input);
	}
}
