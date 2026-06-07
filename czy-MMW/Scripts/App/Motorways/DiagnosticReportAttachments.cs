using System;

namespace Motorways
{
	[Flags]
	public enum DiagnosticReportAttachments
	{
		AppCommandJournal = 1,
		SimCommandJournal = 2,
		SimArchive = 4,
		Screenshot = 8,
		Log = 0x10
	}
}
