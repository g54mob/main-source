using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	internal class XmlLayout_Example_CurrencyOverlay : XmlLayoutController
	{
		[SerializeField]
		public List<ExampleProduct> CurrencyQuantities = new List<ExampleProduct>
		{
			new ExampleProduct
			{
				Name = "Coins",
				Quantity = 0
			},
			new ExampleProduct
			{
				Name = "Green Gems",
				Quantity = 0
			},
			new ExampleProduct
			{
				Name = "Blue Gems",
				Quantity = 0
			},
			new ExampleProduct
			{
				Name = "Red Gems",
				Quantity = 0
			}
		};

		public void AddCurrency(ExampleProduct productPurchased)
		{
			CurrencyQuantities.First((ExampleProduct c) => c.Name == productPurchased.Name).Quantity += productPurchased.Quantity;
			UpdateDisplay();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			UpdateDisplay();
		}

		public void UpdateDisplay()
		{
			for (int i = 0; i < CurrencyQuantities.Count; i++)
			{
				base.xmlLayout.GetElementById<Text>(i.ToString()).text = $"x{CurrencyQuantities[i].Quantity}";
			}
		}
	}
}
