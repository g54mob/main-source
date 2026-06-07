using DV.Booklets;
using DV.ThingTypes;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class StaticLicenseBookletRender : StaticTextureRenderBase
	{
		public LicenseTemplatePaper licenseTemplatePaper;

		public JobLicenseType_v2 jobLicense;

		public GeneralLicenseType_v2 generalLicense;

		private void OnValidate()
		{
			if ((jobLicense != null && generalLicense != null) || (jobLicense == null && generalLicense == null))
			{
				Debug.LogError("Either job or general license type need to be set. Set properly!", this);
			}
		}

		protected override TemplatePaperData[] GetStaticTemplatePaperData()
		{
			if (jobLicense != null)
			{
				return new TemplatePaperData[1] { BookletCreator_Licenses.GetJobLicenseTemplateData(jobLicense) };
			}
			if (generalLicense != null)
			{
				return new TemplatePaperData[1] { BookletCreator_Licenses.GetGeneralLicenseTemplateData(generalLicense) };
			}
			Debug.LogError("You must choose at least one license type to render!", this);
			return null;
		}

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.LicensePage)
			{
				DisableTemplatePapers();
				licenseTemplatePaper.data = templateData as LicenseTemplatePaperData;
				licenseTemplatePaper.gameObject.SetActive(value: true);
				licenseTemplatePaper.FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate textures", this);
			}
		}

		protected override void DisableTemplatePapers()
		{
			licenseTemplatePaper.gameObject.SetActive(value: false);
		}

		protected override void TemplatePapersCleanUp()
		{
			licenseTemplatePaper.CleanUp();
		}
	}
}
