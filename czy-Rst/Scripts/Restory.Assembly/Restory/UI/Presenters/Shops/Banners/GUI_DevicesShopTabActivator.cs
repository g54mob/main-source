using Restory.UI.Presenters.Shops.Elements;
using Restory.UI.Views;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.Banners
{
	public class GUI_DevicesShopTabActivator : MonoBehaviour
	{
		[SerializeField]
		private GUI_WebBrowserPageSwitcher webBrowserPageSwitcher;

		[SerializeField]
		private GUI_WebBrowserTabView devicesShopTabView;

		[SerializeField]
		private GUI_ElementsShopProductsPanel elementsShopPanel;

		private void OnEnable()
		{
			elementsShopPanel.OnBannerClicked += ResolveOnBannerClicked;
		}

		private void OnDisable()
		{
			elementsShopPanel.OnBannerClicked -= ResolveOnBannerClicked;
		}

		private void ResolveOnBannerClicked()
		{
			webBrowserPageSwitcher.ResolveTabClick(devicesShopTabView);
		}
	}
}
