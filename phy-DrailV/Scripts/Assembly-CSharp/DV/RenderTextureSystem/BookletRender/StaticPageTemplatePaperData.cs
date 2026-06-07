namespace DV.RenderTextureSystem.BookletRender
{
	public class StaticPageTemplatePaperData : TemplatePaperData
	{
		public string pageNumber;

		public StaticPageTemplatePaperData(string pageNumber)
		{
			this.pageNumber = pageNumber;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.StaticPage;
		}
	}
}
