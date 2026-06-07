using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Tables;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	internal class XmlLayout_Example_Shop : XmlLayoutController
	{
		public XmlLayout_Example_Shop_ConfirmDialog ConfirmPurchaseDialog;

		public XmlLayout_Example_CurrencyOverlay CurrencyOverlay;

		[SerializeField]
		public List<ExampleProduct> Products = new List<ExampleProduct>();

		private void OnEnable()
		{
			CurrencyOverlay.Show();
		}

		private void OnDisable()
		{
			CurrencyOverlay.Hide();
		}

		private void OnValidate()
		{
			if (base.gameObject.activeInHierarchy && Application.isPlaying)
			{
				StartCoroutine(Rebuild());
			}
		}

		public IEnumerator Rebuild()
		{
			yield return new WaitForEndOfFrame();
			base.xmlLayout.RebuildLayout();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			if (parseResult != ParseXmlResult.Changed || Products == null || !Products.Any())
			{
				return;
			}
			TableLayout elementById = base.xmlLayout.GetElementById<TableLayout>("shopContent");
			XmlElement elementById2 = base.xmlLayout.GetElementById("productTemplate");
			int num = 4;
			int num2 = 0;
			List<TableRow> source = elementById.Rows.ToList();
			int count = Products.Count;
			float preferredHeight = source.First().preferredHeight;
			TableRow tableRow;
			if (source.Any())
			{
				tableRow = source.Last();
			}
			else
			{
				tableRow = elementById.AddRow(0);
				tableRow.preferredHeight = preferredHeight;
			}
			for (int i = 0; i < count; i++)
			{
				ExampleProduct product = Products[i];
				XmlElement xmlElement = Object.Instantiate(elementById2);
				xmlElement.Initialise(base.xmlLayout, (RectTransform)xmlElement.transform, elementById2.tagHandler);
				xmlElement.gameObject.SetActive(value: true);
				tableRow.AddCell(xmlElement.rectTransform);
				HandleProduct(product, xmlElement, i);
				num2++;
				if (num2 == num && i + 1 < count)
				{
					num2 = 0;
					tableRow = elementById.AddRow(0);
					tableRow.preferredHeight = preferredHeight;
				}
			}
		}

		private void HandleProduct(ExampleProduct product, XmlElement item, int productId)
		{
			Image elementByInternalId = item.GetElementByInternalId<Image>("productImage");
			if (product.Image != null)
			{
				elementByInternalId.sprite = product.Image;
			}
			elementByInternalId.color = Color.white;
			Button elementByInternalId2 = item.GetElementByInternalId<Button>("productBuyButton");
			elementByInternalId2.GetComponentInChildren<Text>().text = $"${product.Price}";
			elementByInternalId2.onClick.AddListener(delegate
			{
				PurchaseButtonClicked(productId);
			});
			item.GetElementByInternalId<Text>("productQuantity").text = $"x{product.Quantity}";
			if (product.IsBestDeal)
			{
				item.GetElementByInternalId<Image>("productBestDeal").gameObject.SetActive(value: true);
			}
		}

		private void PurchaseButtonClicked(int productId)
		{
			ExampleProduct product = Products[productId];
			ConfirmPurchaseDialog.Show(product, PurchaseConfirmed);
		}

		public void PurchaseConfirmed(ExampleProduct product)
		{
			CurrencyOverlay.AddCurrency(product);
		}
	}
}
