using System.Threading;

namespace Sentry.Internal
{
	internal interface ITransactionProfilerFactory
	{
		ITransactionProfiler? Start(ITransactionTracer transaction, CancellationToken cancellationToken);
	}
}
