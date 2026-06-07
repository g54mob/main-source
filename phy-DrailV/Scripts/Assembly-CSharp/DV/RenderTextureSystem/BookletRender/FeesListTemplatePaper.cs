using System;
using System.Collections.Generic;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class FeesListTemplatePaper : TemplatePaper
	{
		[Serializable]
		public class FeeElement
		{
			public GameObject elemGO;

			public TextMeshProUGUI feeType;

			public TextMeshProUGUI carId;

			public TextMeshProUGUI title;

			public TextMeshProUGUI amount1;

			public TextMeshProUGUI amount2;

			public TextMeshProUGUI pricePerUnit;

			public TextMeshProUGUI total;

			public Image carIcon;

			public Image resourceIcon;

			public FeeElement(GameObject elemGO, TextMeshProUGUI feeType, TextMeshProUGUI carId, TextMeshProUGUI title, TextMeshProUGUI amount1, TextMeshProUGUI amount2, TextMeshProUGUI pricePerUnit, TextMeshProUGUI total, Image carIcon, Image resourceIcon)
			{
				this.elemGO = elemGO;
				this.feeType = feeType;
				this.carId = carId;
				this.title = title;
				this.amount1 = amount1;
				this.amount2 = amount2;
				this.pricePerUnit = pricePerUnit;
				this.total = total;
				this.carIcon = carIcon;
				this.resourceIcon = resourceIcon;
			}
		}

		public FeesListTemplatePaperData data;

		public TextMeshProUGUI feesId;

		public TextMeshProUGUI feeTypeTitle;

		public List<FeeElement> feeElements;

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
			List<FeesListTemplatePaperData.FeeListElement> feesElements = data.feesElements;
			int count = feesElements.Count;
			for (int i = 0; i < feeElements.Count; i++)
			{
				FeeElement feeElement = feeElements[i];
				bool flag = i < count;
				feeElement.elemGO.SetActive(flag);
				if (flag)
				{
					FeesListTemplatePaperData.FeeListElement feeListElement = feesElements[i];
					feeElement.feeType.text = feeListElement.feeType;
					feeElement.carId.text = feeListElement.carId;
					feeElement.title.text = feeListElement.elementTypeTitle;
					feeElement.amount1.text = feeListElement.amount1;
					feeElement.amount2.text = feeListElement.amount2;
					feeElement.pricePerUnit.text = feeListElement.pricePerUnit;
					feeElement.total.text = feeListElement.totalElementPrice;
					bool flag2 = false;
					Sprite sprite = null;
					bool flag3 = feeListElement.resourceType != ResourceType.Cargo_DMG;
					if (flag3)
					{
						sprite = feeListElement.carType.ToV2().icon;
						flag2 = sprite != null;
					}
					feeElement.carIcon.gameObject.SetActive(flag3 && flag2);
					feeElement.carIcon.sprite = sprite;
					Sprite resourceIcon = GetResourceIcon(feeListElement);
					bool active = resourceIcon != null;
					feeElement.resourceIcon.gameObject.SetActive(active);
					feeElement.resourceIcon.sprite = resourceIcon;
				}
			}
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}

		private Sprite GetResourceIcon(FeesListTemplatePaperData.FeeListElement feeElemData)
		{
			Sprite result = null;
			if (feeElemData.resourceType == ResourceType.Cargo_DMG)
			{
				if (feeElemData.cargoType != CargoType.None)
				{
					result = feeElemData.cargoType.ToV2().resourceIcon;
				}
				else
				{
					Debug.LogError("Trying to get icon for None. This shouldn't happen");
				}
			}
			else
			{
				result = feeElemData.resourceType.ToV2().resourceIcon;
			}
			return result;
		}
	}
}
