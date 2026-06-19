using Sentry.Protocol.Envelopes;

namespace Sentry.Internal
{
	internal interface ITransactionProfiler
	{
		void Finish();

		ISerializable? Collect(SentryTransaction transaction);
	}
}
