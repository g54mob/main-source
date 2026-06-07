using System.Collections.Generic;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public class ReceiptTemplatePaperData : TemplatePaperData
	{
		public class ReceiptElementData
		{
			public string elemName;

			public string amount;

			public string pricePerUnit;

			public string price;

			public Sprite elemIcon;

			public ReceiptElementData(string elemName, string amount, string pricePerUnit, string price, Sprite elemIcon)
			{
				this.elemName = elemName;
				this.amount = amount;
				this.pricePerUnit = pricePerUnit;
				this.price = price;
				this.elemIcon = elemIcon;
			}
		}

		public const int NUMBER_OF_ELEMENTS_PER_PAGE = 4;

		public string totalPrice;

		public List<ReceiptElementData> receiptElements;

		public string pageNumber;

		public string totalPages;

		public ReceiptTemplatePaperData(string totalPrice, List<ReceiptElementData> receiptElements, string pageNumber, string totalPages)
		{
			this.totalPrice = totalPrice;
			this.receiptElements = receiptElements;
			this.pageNumber = pageNumber;
			this.totalPages = totalPages;
		}

		public override TemplatePaperType GetTemplatePaperType()
		{
			return TemplatePaperType.Receipt;
		}
	}
}
