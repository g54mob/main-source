using Restory.UI.Views;
using UnityEngine;

namespace Restory.UI.Presenters.Shops.Banners
{
	public class GUI_DecorShopTabActivator : MonoBehaviour
	{
		[SerializeField]
		private GUI_WebBrowserPageSwitcher webBrowserPageSwitcher;

		[SerializeField]
		private GUI_WebBrowserTabView decorShopTabView;

		public void Activate()
		{
			webBrowserPageSwitcher.ResolveTabClick(decorShopTabView);
		}
	}
}
