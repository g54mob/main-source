using ModIO.Implementation;

namespace ModIO
{
	public class Report
	{
		public long? id;

		public string summary;

		public ReportType? type;

		public ReportResourceType? resourceType;

		public string user;

		public string contactEmail;

		public Report(ModId modId, ReportType type, string summary, string user, string contactEmail)
		{
		}

		public bool CanSend()
		{
			return false;
		}
	}
}
