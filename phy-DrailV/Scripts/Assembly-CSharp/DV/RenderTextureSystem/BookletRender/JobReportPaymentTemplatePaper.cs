using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class JobReportPaymentTemplatePaper : TemplatePaper
	{
		public JobReportPaymentTemplatePaperData data;

		public TextMeshProUGUI basePayment;

		public TextMeshProUGUI bonusPayment;

		public TextMeshProUGUI expirationPenalty;

		public TextMeshProUGUI totalPayment;

		public TextMeshProUGUI totalPaymentText;

		public Text pageNumber;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for job report overview page, but data was not set!", this);
				return;
			}
			basePayment.text = data.basePayment;
			bonusPayment.text = data.bonusPayment;
			expirationPenalty.text = data.expirationPenalty;
			if (data.expirationPenalty != "/")
			{
				expirationPenalty.color = JobReportPaymentTemplatePaperData.EXPIRATION_PENALTY_COLOR;
			}
			totalPayment.text = data.totalPayment;
			totalPaymentText.text = data.totalPaymentText;
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
