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
			id = modId;
			this.type = type;
			resourceType = ReportResourceType.Mods;
			this.summary = summary;
			this.user = user;
			this.contactEmail = contactEmail;
		}

		public bool CanSend()
		{
			if (!id.HasValue || summary == null || !type.HasValue || !resourceType.HasValue || user == null || contactEmail == null)
			{
				return false;
			}
			return true;
		}
	}
}
