using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportPaymentTemplatePaperData : TemplatePaperData
	{
		public const string NO_EXPIRATION_PENALTY_TEXT = "/";

		public static readonly Color EXPIRATION_PENALTY_COLOR = new Color(0.803f, 0.1294f, 0.1294f);

		public string basePayment;

		public string bonusPayment;

		public string expirationPenalty;

		public string totalPayment;

		public string totalPaymentText;

		public string pageNumber;

		public string totalPages;

		public JobReportPaymentTemplatePaperData(string basePayment, string bonusPayment, string expirationPenalty, string totalPayment, string totalPaymentText, string pageNumber, string totalPages)
		{
			this.basePayment = basePayment;
			this.bonusPayment = bonusPayment;
			this.expirationPenalty = expirationPenalty;
			this.totalPayment = totalPayment;
			this.totalPaymentText = totalPaymentText;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.ReportPayment;
		}
	}
}
