using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class MissingLicenseRender : BookletTextureRender
	{
		public MissingLicensesPageTemplatePaper missingLicensePage;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.MissingLicense)
			{
				missingLicensePage.data = templateData as MissingLicensesPageTemplatePaperData;
				missingLicensePage.gameObject.SetActive(value: true);
				missingLicensePage.FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate JobMissingLicenseReport textures", this);
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			missingLicensePage.CleanUp();
		}

		protected override void DisableTemplatePapers()
		{
			missingLicensePage.gameObject.SetActive(value: false);
		}
	}
}
