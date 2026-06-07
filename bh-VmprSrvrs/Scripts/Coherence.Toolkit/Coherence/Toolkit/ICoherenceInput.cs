namespace Coherence.Toolkit
{
	public interface ICoherenceInput
	{
		bool IsServerSimulated { get; }

		bool IsReadyToProcessInputs { get; }

		bool IsProducer { get; }

		bool ProcessingEnabled { get; }

		IInputBuffer Buffer { get; }

		int BufferSize { get; }

		int Delay { get; set; }

		long CurrentSimulationFrame { get; }

		long LastFrame { get; }

		long LastSentFrame { get; }

		long LastAcknowledgedFrame { get; }

		long LastReceivedFrame { get; }

		long? MispredictionFrame { get; }

		bool ShouldPause(long commonReceivedFrame);
	}
}
