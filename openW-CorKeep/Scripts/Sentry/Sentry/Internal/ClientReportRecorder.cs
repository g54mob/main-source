using System.Collections.Generic;
using System.Linq;
using Sentry.Infrastructure;

namespace Sentry.Internal
{
	internal class ClientReportRecorder : IClientReportRecorder
	{
		private readonly SentryOptions _options;

		private readonly ISystemClock _clock;

		private readonly ThreadsafeCounterDictionary<DiscardReasonWithCategory> _discardedEvents = new ThreadsafeCounterDictionary<DiscardReasonWithCategory>();

		internal IReadOnlyDictionary<DiscardReasonWithCategory, int> DiscardedEvents => _discardedEvents;

		public ClientReportRecorder(SentryOptions options, ISystemClock? clock = null)
		{
			_options = options;
			_clock = clock ?? SystemClock.Clock;
		}

		public void RecordDiscardedEvent(DiscardReason reason, DataCategory category, int quantity = 1)
		{
			if (_options.SendClientReports)
			{
				_discardedEvents.Add(reason.WithCategory(category), quantity);
			}
		}

		public ClientReport? GenerateClientReport()
		{
			if (!_options.SendClientReports)
			{
				return null;
			}
			IReadOnlyDictionary<DiscardReasonWithCategory, int> readOnlyDictionary = _discardedEvents.ReadAllAndReset();
			if (!readOnlyDictionary.Any((KeyValuePair<DiscardReasonWithCategory, int> x) => x.Value > 0))
			{
				return null;
			}
			return new ClientReport(_clock.GetUtcNow(), readOnlyDictionary);
		}

		public void Load(ClientReport clientReport)
		{
			foreach (KeyValuePair<DiscardReasonWithCategory, int> discardedEvent in clientReport.DiscardedEvents)
			{
				_discardedEvents.Add(discardedEvent.Key, discardedEvent.Value);
			}
		}
	}
}
