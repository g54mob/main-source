using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesEnvironmentTemplatePaper : TemplatePaper
	{
		public FeesEnvironmentTemplatePaperData data;

		public TextMeshProUGUI feesId;

		public TextMeshProUGUI feeTypeTitle;

		public TextMeshProUGUI environmentDamageDescription;

		public TextMeshProUGUI environmentDamagePrice;

		public List<GameObject> environmentDamageLevelImages;

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
			environmentDamageDescription.text = data.descriptionText;
			environmentDamagePrice.text = data.price;
			int damageLevel = data.damageLevel;
			for (int i = 0; i < environmentDamageLevelImages.Count; i++)
			{
				environmentDamageLevelImages[i].SetActive(i == damageLevel);
			}
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
