using Sentry.Extensibility;

namespace Sentry
{
	internal class SentryPropagationContext
	{
		internal DynamicSamplingContext? _dynamicSamplingContext;

		public SentryId TraceId { get; }

		public SpanId SpanId { get; }

		public SpanId? ParentSpanId { get; }

		public DynamicSamplingContext GetOrCreateDynamicSamplingContext(SentryOptions options)
		{
			if (_dynamicSamplingContext == null)
			{
				options.LogDebug("Creating the Dynamic Sampling Context from the Propagation Context");
				_dynamicSamplingContext = this.CreateDynamicSamplingContext(options);
			}
			return _dynamicSamplingContext;
		}

		internal SentryPropagationContext(SentryId traceId, SpanId parentSpanId, DynamicSamplingContext? dynamicSamplingContext = null)
		{
			TraceId = traceId;
			SpanId = SpanId.Create();
			ParentSpanId = parentSpanId;
			_dynamicSamplingContext = dynamicSamplingContext;
		}

		public SentryPropagationContext()
		{
			TraceId = SentryId.Create();
			SpanId = SpanId.Create();
		}

		public SentryPropagationContext(SentryPropagationContext? other)
		{
			TraceId = other?.TraceId ?? SentryId.Create();
			SpanId = other?.SpanId ?? SpanId.Create();
			ParentSpanId = other?.ParentSpanId;
			_dynamicSamplingContext = other?._dynamicSamplingContext;
		}

		public static SentryPropagationContext CreateFromHeaders(IDiagnosticLogger? logger, SentryTraceHeader? traceHeader, BaggageHeader? baggageHeader)
		{
			logger?.LogDebug("Creating a propagation context from headers.");
			if (traceHeader == null)
			{
				logger?.LogInfo("Sentry trace header is null. Creating new Sentry Propagation Context.");
				return new SentryPropagationContext();
			}
			DynamicSamplingContext dynamicSamplingContext = baggageHeader?.CreateDynamicSamplingContext();
			return new SentryPropagationContext(traceHeader.TraceId, traceHeader.SpanId, dynamicSamplingContext);
		}
	}
}
