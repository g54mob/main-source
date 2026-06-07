using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportOverviewTemplatePaper : TemplatePaper
	{
		public JobReportOverviewTemplatePaperData data;

		public TextMeshProUGUI jobId;

		public TextMeshProUGUI jobState;

		public Image jobStateBgColor;

		public GameObject jobCompletedStamp;

		public TextMeshProUGUI elapsedTime;

		public TextMeshProUGUI bonusTime;

		public TextMeshProUGUI expirationTime;

		public TextMeshProUGUI basePayement;

		public List<JobReportTasksTemplatePaper.ReportEntryElement> reportEntryElements;

		public Text pageNumber;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for job report overview page, but data was not set!", this);
				return;
			}
			if (reportEntryElements.Count < data.reportEntries.Count)
			{
				Debug.LogError("More tasks passed through data than JobReportOverviewTemplatePaper can fit!", this);
			}
			jobId.text = data.jobId;
			jobState.text = data.jobState;
			jobStateBgColor.color = data.jobStateBgColor;
			jobCompletedStamp.SetActive(data.completedStampActive);
			elapsedTime.text = data.elapsedTime;
			bonusTime.text = data.bonusTime;
			expirationTime.text = data.expirationTime;
			basePayement.text = data.basePayement;
			for (int i = 0; i < reportEntryElements.Count; i++)
			{
				if (i < data.reportEntries.Count)
				{
					reportEntryElements[i].Set(data.reportEntries[i]);
				}
				else
				{
					reportEntryElements[i].Disable();
				}
			}
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
