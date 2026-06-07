using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobExpiredRender : BookletTextureRender
	{
		public JobExpiredTemplatePaper jobExpiredPage;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.JobExpired)
			{
				jobExpiredPage.data = templateData as JobExpiredTemplatePaperData;
				jobExpiredPage.gameObject.SetActive(value: true);
				jobExpiredPage.FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate JobExpiredTemplatePaper textures", this);
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			jobExpiredPage.CleanUp();
		}

		protected override void DisableTemplatePapers()
		{
			jobExpiredPage.gameObject.SetActive(value: false);
		}
	}
}
