using Restory.Data.PC;
using Restory.Gameplay.Inventory;
using Restory.UI.Presenters.PC.Apps;
using Restory.UI.Presenters.Shops.Banners;
using Restory.UI.Views;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_WebBrowser : GUI_PcAppBase
	{
		[SerializeField]
		private GUI_WebBrowserView view;

		[SerializeField]
		private GUI_WebBrowserPageSwitcher pageSwitcher;

		[SerializeField]
		private GUI_DecorShopTabActivator decorShopTabActivator;

		private Wallet wallet;

		public bool IsVisible => view.IsVisible;

		public GUI_WebBrowserPageSwitcher PageSwitcher => pageSwitcher;

		public GUI_DecorShopTabActivator DecorShopTabActivator => decorShopTabActivator;

		[Inject]
		private void Construct(Wallet wallet)
		{
			this.wallet = wallet;
		}

		private void OnDisable()
		{
			if ((bool)pageSwitcher)
			{
				pageSwitcher.OnCurrentTabChanged -= ResolveCurrentTabChanged;
			}
			if (wallet != null)
			{
				wallet.OnMoneyAmountChanged -= ResolveMoneyAmountChanged;
			}
		}

		protected override void LaunchProcess(PcAppInfo appInfo)
		{
			base.LaunchProcess(appInfo);
			pageSwitcher.OnCurrentTabChanged += ResolveCurrentTabChanged;
			wallet.OnMoneyAmountChanged += ResolveMoneyAmountChanged;
			view.SetBankBalanceInfo(wallet.MoneyAvailable);
			view.Show();
			pageSwitcher.Activate();
		}

		protected override void StopProcess()
		{
			pageSwitcher.OnCurrentTabChanged -= ResolveCurrentTabChanged;
			wallet.OnMoneyAmountChanged -= ResolveMoneyAmountChanged;
			pageSwitcher.Deactivate();
			view.Hide();
			base.StopProcess();
		}

		private void ResolveCurrentTabChanged(GUI_WebBrowserTabView newTab)
		{
			if (newTab != null)
			{
				view.SetWebAddressText(newTab.WebAddress);
			}
		}

		private void ResolveMoneyAmountChanged()
		{
			view.SetBankBalanceInfo(wallet.MoneyAvailable);
		}
	}
}
