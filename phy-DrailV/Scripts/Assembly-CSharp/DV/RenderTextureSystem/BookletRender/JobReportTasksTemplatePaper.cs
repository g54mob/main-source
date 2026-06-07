using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportTasksTemplatePaper : TemplatePaper
	{
		[Serializable]
		public class ReportEntryElement
		{
			public GameObject entryGO;

			public TextMeshProUGUI description;

			public TextMeshProUGUI timestamp;

			public Image checkmarkDoneImage;

			public Image checkmarkXImage;

			public Image warningImage;

			public ReportEntryElement(GameObject entryGO, TextMeshProUGUI description, TextMeshProUGUI timestamp, Image checkmarkDoneImage, Image checkmarkXImage, Image warningImage)
			{
				this.entryGO = entryGO;
				this.description = description;
				this.timestamp = timestamp;
				this.checkmarkDoneImage = checkmarkDoneImage;
				this.checkmarkXImage = checkmarkXImage;
				this.warningImage = warningImage;
			}

			public void Set(JobReportTasksTemplatePaperData.JobReportEntry entry)
			{
				entryGO.SetActive(value: true);
				description.text = entry.description;
				timestamp.text = entry.timestamp;
				checkmarkDoneImage.gameObject.SetActive(entry.state == JobReportTasksTemplatePaperData.EntryState.COMPLETED);
				warningImage.gameObject.SetActive(entry.state == JobReportTasksTemplatePaperData.EntryState.WARNING);
				checkmarkXImage.gameObject.SetActive(entry.state == JobReportTasksTemplatePaperData.EntryState.IN_PROGRESS_WITH_X_MARK);
			}

			public void Disable()
			{
				entryGO.SetActive(value: false);
			}
		}

		public JobReportTasksTemplatePaperData data;

		public List<ReportEntryElement> reportEntryElements;

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
				Debug.LogError("More tasks passed through data than JobReportTasksTemplatePaper can fit!", this);
			}
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
