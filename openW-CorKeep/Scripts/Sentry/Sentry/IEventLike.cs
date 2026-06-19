using System.Collections.Generic;

namespace Sentry
{
	public interface IEventLike : IHasTags, IHasExtra
	{
		IReadOnlyCollection<Breadcrumb> Breadcrumbs { get; }

		string? Distribution { get; set; }

		SentryLevel? Level { get; set; }

		SentryRequest Request { get; set; }

		SentryContexts Contexts { get; set; }

		SentryUser User { get; set; }

		string? Release { get; set; }

		string? Environment { get; set; }

		string? TransactionName { get; set; }

		SdkVersion Sdk { get; }

		IReadOnlyList<string> Fingerprint { get; set; }

		void AddBreadcrumb(Breadcrumb breadcrumb);
	}
}
