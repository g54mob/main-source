using System;
using System.Threading.Tasks;
using Sentry.Protocol.Envelopes;

namespace Sentry.Extensibility
{
	public interface IBackgroundWorker
	{
		int QueuedItems { get; }

		bool EnqueueEnvelope(Envelope envelope);

		Task FlushAsync(TimeSpan timeout);
	}
}
