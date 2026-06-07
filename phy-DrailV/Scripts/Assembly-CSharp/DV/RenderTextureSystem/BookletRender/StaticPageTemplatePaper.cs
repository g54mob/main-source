using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class StaticPageTemplatePaper : TemplatePaper
	{
		public StaticPageTemplatePaperData data;

		[Header("Optional")]
		public Text pageNumber;

		public override void FillInData()
		{
			if (pageNumber != null)
			{
				pageNumber.text = data.pageNumber;
			}
		}

		public override void CleanUp()
		{
		}
	}
}
