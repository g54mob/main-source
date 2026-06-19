using System.Collections.Generic;
using System.Collections.Immutable;
using Sentry.Protocol;

namespace Sentry.Internal
{
	internal class NoOpTransaction : NoOpSpan, ITransactionTracer, ITransactionData, ISpanData, ITraceContext, IHasTags, IHasExtra, ITransactionContext, IEventLike, ISpan
	{
		public new static ITransactionTracer Instance { get; } = new NoOpTransaction();

		public SdkVersion Sdk => SdkVersion.Instance;

		public string Name
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		public bool? IsParentSampled
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TransactionNameSource NameSource => TransactionNameSource.Custom;

		public string? Distribution
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		public SentryLevel? Level
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SentryRequest Request
		{
			get
			{
				return new SentryRequest();
			}
			set
			{
			}
		}

		public SentryContexts Contexts
		{
			get
			{
				return new SentryContexts();
			}
			set
			{
			}
		}

		public SentryUser User
		{
			get
			{
				return new SentryUser();
			}
			set
			{
			}
		}

		public string? Platform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string? Release
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string? Environment
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string? TransactionName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IReadOnlyList<string> Fingerprint
		{
			get
			{
				return ImmutableList<string>.Empty;
			}
			set
			{
			}
		}

		public IReadOnlyCollection<ISpan> Spans => ImmutableList<ISpan>.Empty;

		public IReadOnlyCollection<Breadcrumb> Breadcrumbs => ImmutableList<Breadcrumb>.Empty;

		private NoOpTransaction()
		{
		}

		public ISpan? GetLastActiveSpan()
		{
			return null;
		}

		public void AddBreadcrumb(Breadcrumb breadcrumb)
		{
		}
	}
}
