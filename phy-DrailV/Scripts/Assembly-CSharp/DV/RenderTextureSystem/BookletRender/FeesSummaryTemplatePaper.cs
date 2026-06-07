using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesSummaryTemplatePaper : TemplatePaper
	{
		public FeesSummaryTemplatePaperData data;

		public TextMeshProUGUI feesId;

		public TextMeshProUGUI feeTypeTitle;

		public Image summaryCarIcon;

		public TextMeshProUGUI sum1;

		public TextMeshProUGUI sum2;

		public TextMeshProUGUI sum3;

		public TextMeshProUGUI summaryAssessment;

		public TextMeshProUGUI youAreInsuredText;

		public TextMeshProUGUI total;

		public TextMeshProUGUI feeToleranceInfo;

		public Text pageNumber;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for summary page, but data was not set!", this);
				return;
			}
			feesId.text = data.feesId;
			if (feeTypeTitle != null)
			{
				feeTypeTitle.text = data.feeTypeTitle;
			}
			if (summaryCarIcon != null)
			{
				if (data.summaryIconCarLivery != null)
				{
					summaryCarIcon.sprite = data.summaryIconCarLivery.icon;
				}
				summaryCarIcon.gameObject.SetActive(data.summaryIconCarLivery != null);
			}
			sum1.text = data.feeSum1;
			if (data.feeSum1 == "/")
			{
				sum1.color = FeesSummaryTemplatePaperData.NO_FEE_TEXT_COLOR;
			}
			sum2.text = data.feeSum2;
			if (data.feeSum2 == "/")
			{
				sum2.color = FeesSummaryTemplatePaperData.NO_FEE_TEXT_COLOR;
			}
			sum3.text = data.feeSum3;
			if (data.feeSum3 == "/")
			{
				sum3.color = FeesSummaryTemplatePaperData.NO_FEE_TEXT_COLOR;
			}
			summaryAssessment.text = data.summaryAssessment;
			youAreInsuredText.gameObject.SetActive(data.showYouAreInsuredText);
			total.text = data.totalPrice;
			feeToleranceInfo.text = data.feeToleranceInfoText;
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
