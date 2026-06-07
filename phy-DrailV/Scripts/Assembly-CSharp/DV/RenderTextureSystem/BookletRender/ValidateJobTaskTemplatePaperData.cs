namespace DV.RenderTextureSystem.BookletRender
{
	public class ValidateJobTaskTemplatePaperData : TemplatePaperData
	{
		public string stepNum;

		public string pageNumber;

		public string totalPages;

		public ValidateJobTaskTemplatePaperData(string stepNum, string pageNumber, string totalPages)
		{
			this.stepNum = stepNum;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.ValidateJobTaskPage;
		}
	}
}
