using Restory.UI.Views;
using Restory.UI.Views.Shops.Devices;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.Banners
{
	public class GUI_PartsShopTabActivator : MonoBehaviour
	{
		[SerializeField]
		private GUI_WebBrowserPageSwitcher webBrowserPageSwitcher;

		[SerializeField]
		private GUI_WebBrowserTabView partsShopTabView;

		[SerializeField]
		private GUI_DeviceShopPanelView deviceShopPanelView;

		private void OnEnable()
		{
			deviceShopPanelView.OnLicenseBannerClicked += ResolveLicenseBannerClicked;
		}

		private void OnDisable()
		{
			deviceShopPanelView.OnLicenseBannerClicked -= ResolveLicenseBannerClicked;
		}

		private void ResolveLicenseBannerClicked()
		{
			webBrowserPageSwitcher.ResolveTabClick(partsShopTabView);
		}
	}
}
