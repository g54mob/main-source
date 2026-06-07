using DV.ThingTypes;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesSummaryTemplatePaperData : TemplatePaperData
	{
		public const string NO_FEE_TEXT = "/";

		public static readonly Color NO_FEE_TEXT_COLOR = new Color(0.0863f, 0.0863f, 0.0863f);

		public string feesId;

		public string feeTypeTitle;

		public string feeSum1;

		public string feeSum2;

		public string feeSum3;

		public string summaryAssessment;

		public bool showYouAreInsuredText;

		public string totalPrice;

		public string feeToleranceInfoText;

		public string pageNumber;

		public string totalPages;

		public TrainCarLivery summaryIconCarLivery;

		public FeesSummaryTemplatePaperData(string feesId, string feeTypeTitle, TrainCarLivery summaryIconCarLivery, string feeSum1, string feeSum2, string feeSum3, string summaryAssessment, bool showYouAreInsuredText, string totalPrice, string feeToleranceInfoText, string pageNumber, string totalPages)
		{
			this.feesId = feesId;
			this.feeTypeTitle = feeTypeTitle;
			this.feeSum1 = feeSum1;
			this.feeSum2 = feeSum2;
			this.feeSum3 = feeSum3;
			this.summaryAssessment = summaryAssessment;
			this.showYouAreInsuredText = showYouAreInsuredText;
			this.totalPrice = totalPrice;
			this.feeToleranceInfoText = feeToleranceInfoText;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
			this.summaryIconCarLivery = summaryIconCarLivery;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.FeesSummary;
		}
	}
}
