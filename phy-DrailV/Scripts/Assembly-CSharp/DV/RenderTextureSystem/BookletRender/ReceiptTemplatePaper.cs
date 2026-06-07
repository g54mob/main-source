using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class ReceiptTemplatePaper : TemplatePaper
	{
		[Serializable]
		public class ReceiptElement
		{
			public GameObject elemGO;

			public TextMeshProUGUI name;

			public TextMeshProUGUI amount;

			public TextMeshProUGUI pricePerUnit;

			public TextMeshProUGUI price;

			public Image iconImage;

			public ReceiptElement(GameObject elemGO, TextMeshProUGUI name, TextMeshProUGUI amount, TextMeshProUGUI pricePerUnit, TextMeshProUGUI price, Image iconImage)
			{
				this.elemGO = elemGO;
				this.name = name;
				this.amount = amount;
				this.pricePerUnit = pricePerUnit;
				this.price = price;
				this.iconImage = iconImage;
			}

			public void Set(string elemName, string elemAmount, string elemPricePerUnit, string elemPrice, Sprite elemIcon)
			{
				elemGO.SetActive(value: true);
				name.text = elemName;
				amount.text = elemAmount;
				pricePerUnit.text = elemPricePerUnit;
				price.text = elemPrice;
				iconImage.sprite = elemIcon;
				iconImage.gameObject.SetActive(elemIcon != null);
			}

			public void Clear()
			{
				elemGO.SetActive(value: false);
			}
		}

		public ReceiptTemplatePaperData data;

		public TextMeshProUGUI totalPrice;

		public List<ReceiptElement> receiptElements;

		public Text pageNumber;

		public override void CleanUp()
		{
		}

		public override void FillInData()
		{
			if (data == null)
			{
				Debug.LogWarning("Trying to fill data for receipt page, but data was not set!", this);
				return;
			}
			totalPrice.text = data.totalPrice;
			List<ReceiptTemplatePaperData.ReceiptElementData> list = data.receiptElements;
			int count = list.Count;
			for (int i = 0; i < receiptElements.Count; i++)
			{
				bool num = i < count;
				ReceiptElement receiptElement = receiptElements[i];
				if (num)
				{
					ReceiptTemplatePaperData.ReceiptElementData receiptElementData = list[i];
					receiptElement.Set(receiptElementData.elemName, receiptElementData.amount, receiptElementData.pricePerUnit, receiptElementData.price, receiptElementData.elemIcon);
				}
				else
				{
					receiptElement.Clear();
				}
			}
			pageNumber.text = data.pageNumber + "/" + data.totalPages;
		}
	}
}
