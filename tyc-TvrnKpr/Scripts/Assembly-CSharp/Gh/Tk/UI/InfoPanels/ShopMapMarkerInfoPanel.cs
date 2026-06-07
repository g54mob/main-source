using I18n;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class ShopMapMarkerInfoPanel : MapMarkerInfoPanel
	{
		public TextMeshProI18n Name;

		public TextMeshProI18n ShopInfoDetail;

		public TextMeshProI18n WaresDetail;

		[SerializeField]
		private OpenShopMapMarkerButton _openShopButton;

		[SerializeField]
		private ShopPurchaseLicenseButton _purchaseLicenseButton;

		public override void Refresh()
		{
		}

		private void RefreshShopInfoDetail()
		{
		}
	}
}
