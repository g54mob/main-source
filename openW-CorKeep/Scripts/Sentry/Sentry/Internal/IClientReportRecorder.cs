namespace Sentry.Internal
{
	internal interface IClientReportRecorder
	{
		void RecordDiscardedEvent(DiscardReason reason, DataCategory category, int quantity = 1);

		ClientReport? GenerateClientReport();

		void Load(ClientReport report);
	}
}
