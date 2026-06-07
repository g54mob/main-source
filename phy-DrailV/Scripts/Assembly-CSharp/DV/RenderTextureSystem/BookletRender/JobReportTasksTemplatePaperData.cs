using System.Collections.Generic;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportTasksTemplatePaperData : TemplatePaperData
	{
		public enum EntryState
		{
			IN_PROGRESS = 0,
			COMPLETED = 1,
			WARNING = 2,
			IN_PROGRESS_WITH_X_MARK = 3
		}

		public class JobReportEntry
		{
			public string description;

			public string timestamp;

			public EntryState state;

			public JobReportEntry(string description, string timestamp, EntryState state)
			{
				this.description = description;
				this.timestamp = timestamp;
				this.state = state;
			}
		}

		public const int NUMBER_OF_ENTRIES_ON_PAGE = 9;

		public List<JobReportEntry> reportEntries;

		public string pageNumber;

		public string totalPages;

		public JobReportTasksTemplatePaperData(List<JobReportEntry> reportEntries, string pageNumber, string totalPages)
		{
			this.reportEntries = reportEntries;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.ReportTasks;
		}
	}
}
