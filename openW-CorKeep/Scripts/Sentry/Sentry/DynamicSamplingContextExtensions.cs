namespace Sentry
{
	internal static class DynamicSamplingContextExtensions
	{
		public static DynamicSamplingContext? CreateDynamicSamplingContext(this BaggageHeader baggage)
		{
			return DynamicSamplingContext.CreateFromBaggageHeader(baggage);
		}

		public static DynamicSamplingContext CreateDynamicSamplingContext(this TransactionTracer transaction, SentryOptions options)
		{
			return DynamicSamplingContext.CreateFromTransaction(transaction, options);
		}

		public static DynamicSamplingContext CreateDynamicSamplingContext(this SentryPropagationContext propagationContext, SentryOptions options)
		{
			return DynamicSamplingContext.CreateFromPropagationContext(propagationContext, options);
		}
	}
}
