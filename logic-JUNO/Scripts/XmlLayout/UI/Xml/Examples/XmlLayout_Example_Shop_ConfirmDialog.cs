using System;
using System.Collections;
using UnityEngine.UI;

namespace UI.Xml.Examples
{
	internal class XmlLayout_Example_Shop_ConfirmDialog : XmlLayoutController
	{
		private ExampleProduct product;

		private Action<ExampleProduct> callback;

		public void Show(ExampleProduct product, Action<ExampleProduct> callback = null)
		{
			base.xmlLayout.Show();
			this.product = product;
			this.callback = callback;
			StartCoroutine(DelayedShow());
		}

		protected IEnumerator DelayedShow()
		{
			while (!base.xmlLayout.IsReady)
			{
				yield return null;
			}
			base.xmlLayout.GetElementById<Image>("productImage").sprite = product.Image;
			base.xmlLayout.GetElementById<Text>("productQuantity").text = $"x{product.Quantity}";
			base.xmlLayout.GetElementById<Text>("productPrice").text = $"${product.Price}";
		}

		private void ConfirmPurchase()
		{
			callback(product);
			Hide();
		}
	}
}
