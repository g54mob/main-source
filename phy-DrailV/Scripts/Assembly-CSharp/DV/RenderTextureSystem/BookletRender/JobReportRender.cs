using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportRender : BookletTextureRender
	{
		public JobReportOverviewTemplatePaper reportOverviewPageTemplate;

		public JobReportTasksTemplatePaper reportTasksPageTemplate;

		public JobReportPaymentTemplatePaper reportPaymentPageTemplate;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.ReportOverview)
			{
				reportTasksPageTemplate.gameObject.SetActive(value: false);
				reportPaymentPageTemplate.gameObject.SetActive(value: false);
				reportOverviewPageTemplate.data = templateData as JobReportOverviewTemplatePaperData;
				reportOverviewPageTemplate.gameObject.SetActive(value: true);
				reportOverviewPageTemplate.FillInData();
			}
			else if (templateData.GetTemplatePaperType() == TemplatePaperType.ReportTasks)
			{
				reportOverviewPageTemplate.gameObject.SetActive(value: false);
				reportPaymentPageTemplate.gameObject.SetActive(value: false);
				reportTasksPageTemplate.data = templateData as JobReportTasksTemplatePaperData;
				reportTasksPageTemplate.gameObject.SetActive(value: true);
				reportTasksPageTemplate.FillInData();
			}
			else if (templateData.GetTemplatePaperType() == TemplatePaperType.ReportPayment)
			{
				reportOverviewPageTemplate.gameObject.SetActive(value: false);
				reportTasksPageTemplate.gameObject.SetActive(value: false);
				reportPaymentPageTemplate.data = templateData as JobReportPaymentTemplatePaperData;
				reportPaymentPageTemplate.gameObject.SetActive(value: true);
				reportPaymentPageTemplate.FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate JobReport textures", this);
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			reportOverviewPageTemplate.CleanUp();
			reportTasksPageTemplate.CleanUp();
			reportPaymentPageTemplate.CleanUp();
		}

		protected override void DisableTemplatePapers()
		{
			reportOverviewPageTemplate.gameObject.SetActive(value: false);
			reportTasksPageTemplate.gameObject.SetActive(value: false);
			reportPaymentPageTemplate.gameObject.SetActive(value: false);
		}
	}
}
