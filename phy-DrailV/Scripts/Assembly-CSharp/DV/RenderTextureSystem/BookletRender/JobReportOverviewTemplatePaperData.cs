using System.Collections.Generic;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportOverviewTemplatePaperData : TemplatePaperData
	{
		public const int NUMBER_OF_ENTRIES_ON_OVERVIEW_PAGE = 5;

		public string jobId;

		public string jobState;

		public Color jobStateBgColor;

		public bool completedStampActive;

		public string elapsedTime;

		public string bonusTime;

		public string expirationTime;

		public string basePayement;

		public List<JobReportTasksTemplatePaperData.JobReportEntry> reportEntries;

		public string pageNumber;

		public string totalPages;

		public JobReportOverviewTemplatePaperData(string jobId, string jobState, Color jobStateBgColor, bool completedStampActive, string elapsedTime, string bonusTime, string expirationTime, string basePayement, List<JobReportTasksTemplatePaperData.JobReportEntry> reportEntries, string pageNumber, string totalPages)
		{
			this.jobId = jobId;
			this.jobState = jobState;
			this.jobStateBgColor = jobStateBgColor;
			this.completedStampActive = completedStampActive;
			this.elapsedTime = elapsedTime;
			this.bonusTime = bonusTime;
			this.expirationTime = expirationTime;
			this.basePayement = basePayement;
			this.reportEntries = reportEntries;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.ReportOverview;
		}
	}
}
