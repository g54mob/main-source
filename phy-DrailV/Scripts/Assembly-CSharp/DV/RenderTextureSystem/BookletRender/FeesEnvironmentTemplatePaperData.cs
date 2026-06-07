namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesEnvironmentTemplatePaperData : TemplatePaperData
	{
		public string feesId;

		public string feeTypeTitle;

		public string descriptionText;

		public int damageLevel;

		public string price;

		public string pageNumber;

		public string totalPages;

		public FeesEnvironmentTemplatePaperData(string feesId, string feeTypeTitle, string descriptionText, int damageLevel, string price, string pageNumber, string totalPages)
		{
			this.feesId = feesId;
			this.feeTypeTitle = feeTypeTitle;
			this.descriptionText = descriptionText;
			this.damageLevel = damageLevel;
			this.price = price;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.FeesEnvironment;
		}
	}
}
