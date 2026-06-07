namespace Epic.OnlineServices.Reports
{
	public class SendPlayerBehaviorReportOptions
	{
		public ProductUserId ReporterUserId { get; set; }

		public ProductUserId ReportedUserId { get; set; }

		public PlayerReportsCategory ReportCategory { get; set; }

		public string ReportDescription { get; set; }
	}
}
