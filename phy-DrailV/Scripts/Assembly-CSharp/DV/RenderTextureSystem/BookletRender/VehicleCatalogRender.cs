using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class VehicleCatalogRender : StaticTextureRenderBase
	{
		public StaticPageTemplatePaper coverPage;

		public VehicleCatalogPageTemplatePaper[] vehiclePages;

		protected override void TemplatePapersCleanUp()
		{
			coverPage.CleanUp();
			VehicleCatalogPageTemplatePaper[] array = vehiclePages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CleanUp();
			}
		}

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.StaticPage)
			{
				DisableTemplatePapers();
				coverPage.gameObject.SetActive(value: true);
				coverPage.FillInData();
			}
			else if (templateData.GetTemplatePaperType() == TemplatePaperType.VehicleCatalog)
			{
				DisableTemplatePapers();
				vehiclePages[currentPage - 1].gameObject.SetActive(value: true);
				vehiclePages[currentPage - 1].FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate textures", this);
			}
		}

		protected override void DisableTemplatePapers()
		{
			coverPage.gameObject.SetActive(value: false);
			VehicleCatalogPageTemplatePaper[] array = vehiclePages;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: false);
			}
		}

		protected override TemplatePaperData[] GetStaticTemplatePaperData()
		{
			TemplatePaperData[] array = new TemplatePaperData[1 + vehiclePages.Length];
			array[0] = new StaticPageTemplatePaperData(string.Empty);
			for (int i = 0; i < vehiclePages.Length; i++)
			{
				array[i + 1] = new VehicleCatalogPageTemplatePaperData();
			}
			return array;
		}
	}
}
