using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobBookletRender : BookletTextureRender
	{
		public CoverPageTemplatePaper coverPageTemplate;

		public FrontPageTemplatePaper frontPageTemplate;

		public TaskTemplatePaper taskPageTemplate;

		public ValidateJobTaskTemplatePaper validateJobPageTemplate;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			switch (templateData.GetTemplatePaperType())
			{
			case TemplatePaperType.CoverPage:
				frontPageTemplate.gameObject.SetActive(value: false);
				taskPageTemplate.gameObject.SetActive(value: false);
				validateJobPageTemplate.gameObject.SetActive(value: false);
				coverPageTemplate.data = templateData as CoverPageTemplatePaperData;
				coverPageTemplate.gameObject.SetActive(value: true);
				coverPageTemplate.FillInData();
				break;
			case TemplatePaperType.FrontPage:
				coverPageTemplate.gameObject.SetActive(value: false);
				taskPageTemplate.gameObject.SetActive(value: false);
				validateJobPageTemplate.gameObject.SetActive(value: false);
				frontPageTemplate.data = templateData as FrontPageTemplatePaperData;
				frontPageTemplate.gameObject.SetActive(value: true);
				frontPageTemplate.FillInData();
				break;
			case TemplatePaperType.TaskPage:
				coverPageTemplate.gameObject.SetActive(value: false);
				frontPageTemplate.gameObject.SetActive(value: false);
				validateJobPageTemplate.gameObject.SetActive(value: false);
				taskPageTemplate.data = templateData as TaskTemplatePaperData;
				taskPageTemplate.gameObject.SetActive(value: true);
				taskPageTemplate.FillInData();
				break;
			case TemplatePaperType.ValidateJobTaskPage:
				coverPageTemplate.gameObject.SetActive(value: false);
				frontPageTemplate.gameObject.SetActive(value: false);
				taskPageTemplate.gameObject.SetActive(value: false);
				validateJobPageTemplate.data = templateData as ValidateJobTaskTemplatePaperData;
				validateJobPageTemplate.gameObject.SetActive(value: true);
				validateJobPageTemplate.FillInData();
				break;
			default:
				Debug.LogError("Unexpected TemplatePaperData type given to generate JobReport textures", this);
				break;
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			coverPageTemplate.CleanUp();
			frontPageTemplate.CleanUp();
			taskPageTemplate.CleanUp();
			validateJobPageTemplate.CleanUp();
		}

		protected override void DisableTemplatePapers()
		{
			coverPageTemplate.gameObject.SetActive(value: false);
			frontPageTemplate.gameObject.SetActive(value: false);
			taskPageTemplate.gameObject.SetActive(value: false);
			validateJobPageTemplate.gameObject.SetActive(value: false);
		}
	}
}
