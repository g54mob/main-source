using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class ReceiptBookletRender : BookletTextureRender
	{
		public ReceiptTemplatePaper receiptListPageTemplate;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.Receipt)
			{
				receiptListPageTemplate.data = templateData as ReceiptTemplatePaperData;
				receiptListPageTemplate.gameObject.SetActive(value: true);
				receiptListPageTemplate.FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate ReceiptBookletRender textures", this);
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			receiptListPageTemplate.CleanUp();
		}

		protected override void DisableTemplatePapers()
		{
			receiptListPageTemplate.gameObject.SetActive(value: false);
		}
	}
}
