using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesBookletRender : BookletTextureRender
	{
		public FeesSummaryTemplatePaper summaryPageTemplate;

		public FeesListTemplatePaper feesListPageTemplate;

		public FeesEnvironmentTemplatePaper environmentTemplatePaper;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			switch (templateData.GetTemplatePaperType())
			{
			case TemplatePaperType.FeesSummary:
				feesListPageTemplate.gameObject.SetActive(value: false);
				if (environmentTemplatePaper != null)
				{
					environmentTemplatePaper.gameObject.SetActive(value: false);
				}
				summaryPageTemplate.data = templateData as FeesSummaryTemplatePaperData;
				summaryPageTemplate.gameObject.SetActive(value: true);
				summaryPageTemplate.FillInData();
				break;
			case TemplatePaperType.FeesList:
				summaryPageTemplate.gameObject.SetActive(value: false);
				if (environmentTemplatePaper != null)
				{
					environmentTemplatePaper.gameObject.SetActive(value: false);
				}
				feesListPageTemplate.data = templateData as FeesListTemplatePaperData;
				feesListPageTemplate.gameObject.SetActive(value: true);
				feesListPageTemplate.FillInData();
				break;
			case TemplatePaperType.FeesEnvironment:
				summaryPageTemplate.gameObject.SetActive(value: false);
				feesListPageTemplate.gameObject.SetActive(value: false);
				environmentTemplatePaper.data = templateData as FeesEnvironmentTemplatePaperData;
				environmentTemplatePaper.gameObject.SetActive(value: true);
				environmentTemplatePaper.FillInData();
				break;
			default:
				Debug.LogError("Unexpected TemplatePaperData type given to generate FeesBookletRender textures", this);
				break;
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			summaryPageTemplate.CleanUp();
			feesListPageTemplate.CleanUp();
			if (environmentTemplatePaper != null)
			{
				environmentTemplatePaper.CleanUp();
			}
		}

		protected override void DisableTemplatePapers()
		{
			summaryPageTemplate.gameObject.SetActive(value: false);
			feesListPageTemplate.gameObject.SetActive(value: false);
			if (environmentTemplatePaper != null)
			{
				environmentTemplatePaper.gameObject.SetActive(value: false);
			}
		}
	}
}
