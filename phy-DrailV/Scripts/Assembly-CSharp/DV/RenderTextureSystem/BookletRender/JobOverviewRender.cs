using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobOverviewRender : BookletTextureRender
	{
		public FrontPageTemplatePaper overviewPage;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.FrontPage)
			{
				overviewPage.data = templateData as FrontPageTemplatePaperData;
				overviewPage.gameObject.SetActive(value: true);
				overviewPage.FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate JobReport textures", this);
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			overviewPage.CleanUp();
		}

		protected override void DisableTemplatePapers()
		{
			overviewPage.gameObject.SetActive(value: false);
		}
	}
}
