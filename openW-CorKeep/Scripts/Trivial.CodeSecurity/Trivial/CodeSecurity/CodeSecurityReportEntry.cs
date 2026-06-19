namespace Trivial.CodeSecurity
{
	public struct CodeSecurityReportEntry
	{
		public enum ReportEntryType
		{
			IllegalAssembly = 0,
			IllegalNamespace = 1,
			IllegalType = 2,
			IllegalMember = 3,
			IllegalPInvoke = 4,
			IllegalOccurence = 5
		}

		private ReportEntryType entryType;

		private CodeSecurityLocation location;

		private string message;

		public ReportEntryType EntryType => entryType;

		public CodeSecurityLocation Location => location;

		public string Message => message;

		internal CodeSecurityReportEntry(ReportEntryType entryType, CodeSecurityLocation location, string message)
		{
			this.entryType = entryType;
			this.location = location;
			this.message = message;
		}

		public override string ToString()
		{
			return message;
		}
	}
}
