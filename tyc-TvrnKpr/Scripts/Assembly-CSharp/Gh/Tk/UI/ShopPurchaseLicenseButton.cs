using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class ShopPurchaseLicenseButton : BuyButton3DUIView
	{
		[SerializeField]
		private TextMeshPro _priceText;

		private ShopMapMarker _shopMapMarker;

		public virtual ShopMapMarker ShopMapMarker
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnTradeRouteEstablishedChanged(object sender, EventArgs e)
		{
		}

		public override void CheckState()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnTavernMoneyChanged(object sender, EventArgs<int> e)
		{
		}
	}
}
