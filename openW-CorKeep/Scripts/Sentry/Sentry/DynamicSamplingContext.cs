using System;
using System.Collections.Generic;
using System.Globalization;
using Sentry.Internal.Extensions;

namespace Sentry
{
	internal class DynamicSamplingContext
	{
		public static readonly DynamicSamplingContext Empty = new DynamicSamplingContext(new Dictionary<string, string>().AsReadOnly());

		public IReadOnlyDictionary<string, string> Items { get; }

		public bool IsEmpty => Items.Count == 0;

		private DynamicSamplingContext(IReadOnlyDictionary<string, string> items)
		{
			Items = items;
		}

		private DynamicSamplingContext(SentryId traceId, string publicKey, bool? sampled, double? sampleRate = null, string? release = null, string? environment = null, string? userSegment = null, string? transactionName = null)
		{
			if (traceId == SentryId.Empty)
			{
				throw new ArgumentOutOfRangeException("traceId");
			}
			if (string.IsNullOrWhiteSpace(publicKey))
			{
				throw new ArgumentException(null, "publicKey");
			}
			bool flag;
			if (sampleRate.HasValue)
			{
				double valueOrDefault = sampleRate.GetValueOrDefault();
				if (valueOrDefault < 0.0 || valueOrDefault > 1.0)
				{
					flag = true;
					goto IL_0061;
				}
			}
			flag = false;
			goto IL_0061;
			IL_0061:
			if (flag)
			{
				throw new ArgumentOutOfRangeException("sampleRate");
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(7)
			{
				["trace_id"] = traceId.ToString(),
				["public_key"] = publicKey
			};
			if (sampled.HasValue)
			{
				dictionary.Add("sampled", sampled.Value ? "true" : "false");
			}
			if (sampleRate.HasValue)
			{
				dictionary.Add("sample_rate", sampleRate.Value.ToString(CultureInfo.InvariantCulture));
			}
			if (!string.IsNullOrWhiteSpace(release))
			{
				dictionary.Add("release", release);
			}
			if (!string.IsNullOrWhiteSpace(environment))
			{
				dictionary.Add("environment", environment);
			}
			if (!string.IsNullOrWhiteSpace(userSegment))
			{
				dictionary.Add("user_segment", userSegment);
			}
			if (!string.IsNullOrWhiteSpace(transactionName))
			{
				dictionary.Add("transaction", transactionName);
			}
			Items = dictionary;
		}

		public BaggageHeader ToBaggageHeader()
		{
			return BaggageHeader.Create(Items, useSentryPrefix: true);
		}

		public static DynamicSamplingContext? CreateFromBaggageHeader(BaggageHeader baggage)
		{
			IReadOnlyDictionary<string, string> sentryMembers = baggage.GetSentryMembers();
			if (!sentryMembers.TryGetValue("trace_id", out var value) || !Guid.TryParse(value, out var result) || result == Guid.Empty)
			{
				return null;
			}
			if (!sentryMembers.TryGetValue("public_key", out var value2) || string.IsNullOrWhiteSpace(value2))
			{
				return null;
			}
			if (sentryMembers.TryGetValue("sampled", out var value3) && !bool.TryParse(value3, out var result2))
			{
				return null;
			}
			double result3 = default(double);
			result2 = !sentryMembers.TryGetValue("sample_rate", out var value4) || !double.TryParse(value4, NumberStyles.Float, CultureInfo.InvariantCulture, out result3);
			if (!result2)
			{
				bool flag = ((result3 < 0.0 || result3 > 1.0) ? true : false);
				result2 = flag;
			}
			if (result2)
			{
				return null;
			}
			return new DynamicSamplingContext(sentryMembers);
		}

		public static DynamicSamplingContext CreateFromTransaction(TransactionTracer transaction, SentryOptions options)
		{
			string publicKey = options.ParsedDsn.PublicKey;
			SentryId traceId = transaction.TraceId;
			bool? isSampled = transaction.IsSampled;
			double value = transaction.SampleRate.Value;
			return new DynamicSamplingContext(userSegment: transaction.User.Segment, transactionName: transaction.NameSource.IsHighQuality() ? transaction.Name : null, release: options.SettingLocator.GetRelease(), environment: options.SettingLocator.GetEnvironment(), traceId: traceId, publicKey: publicKey, sampled: isSampled, sampleRate: value);
		}

		public static DynamicSamplingContext CreateFromPropagationContext(SentryPropagationContext propagationContext, SentryOptions options)
		{
			SentryId traceId = propagationContext.TraceId;
			string publicKey = options.ParsedDsn.PublicKey;
			string release = options.SettingLocator.GetRelease();
			string environment = options.SettingLocator.GetEnvironment();
			string release2 = release;
			string environment2 = environment;
			return new DynamicSamplingContext(traceId, publicKey, null, null, release2, environment2);
		}
	}
}
