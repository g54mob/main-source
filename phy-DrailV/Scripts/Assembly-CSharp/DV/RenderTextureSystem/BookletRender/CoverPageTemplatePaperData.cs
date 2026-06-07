namespace DV.RenderTextureSystem.BookletRender
{
	public class CoverPageTemplatePaperData : TemplatePaperData
	{
		public string jobID;

		public string jobType;

		public string pageNumber;

		public string totalPages;

		public CoverPageTemplatePaperData(string jobID, string jobType, string pageNumber, string totalPages)
		{
			this.jobID = jobID;
			this.jobType = jobType;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.CoverPage;
		}
	}
}
