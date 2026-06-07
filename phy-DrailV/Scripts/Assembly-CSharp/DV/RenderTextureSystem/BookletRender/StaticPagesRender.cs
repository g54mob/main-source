using System.Collections.Generic;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class StaticPagesRender : StaticTextureRenderBase
	{
		public List<StaticPageTemplatePaper> staticPages;

		protected override void TemplatePaperDataFill(TemplatePaperData templateData)
		{
			if (templateData.GetTemplatePaperType() == TemplatePaperType.StaticPage)
			{
				DisableTemplatePapers();
				staticPages[currentPage].data = templateData as StaticPageTemplatePaperData;
				staticPages[currentPage].gameObject.SetActive(value: true);
				staticPages[currentPage].FillInData();
			}
			else
			{
				Debug.LogError("Unexpected TemplatePaperData type given to generate textures", this);
			}
		}

		protected override void TemplatePapersCleanUp()
		{
			foreach (StaticPageTemplatePaper staticPage in staticPages)
			{
				staticPage.CleanUp();
			}
		}

		protected override void DisableTemplatePapers()
		{
			foreach (StaticPageTemplatePaper staticPage in staticPages)
			{
				staticPage.gameObject.SetActive(value: false);
			}
		}

		protected override TemplatePaperData[] GetStaticTemplatePaperData()
		{
			TemplatePaperData[] array = new TemplatePaperData[staticPages.Count];
			for (int i = 0; i < staticPages.Count; i++)
			{
				array[i] = new StaticPageTemplatePaperData(i + 1 + "/" + staticPages.Count);
			}
			return array;
		}
	}
}
