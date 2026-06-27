using Helpers.Extensions;
using Restory.Gameplay.Inventory;
using Restory.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWidgetWallet : GUI_PcWidget
	{
		[SerializeField]
		private TMP_Text currencySignText;

		[SerializeField]
		private TMP_Text moneySumText;

		private Wallet wallet;

		[Inject]
		private void Construct(Wallet wallet)
		{
			this.wallet = wallet;
		}

		private void Awake()
		{
			currencySignText.text = "¥";
		}

		private void OnDisable()
		{
			if (wallet.MonoShellExists())
			{
				wallet.OnMoneyAmountChanged -= ResolveMoneyInWalletChanged;
			}
		}

		public override void Activate()
		{
			ResolveMoneyInWalletChanged();
			wallet.OnMoneyAmountChanged += ResolveMoneyInWalletChanged;
		}

		public override void Deactivate()
		{
			if (wallet.MonoShellExists())
			{
				wallet.OnMoneyAmountChanged -= ResolveMoneyInWalletChanged;
			}
		}

		private void ResolveMoneyInWalletChanged()
		{
			moneySumText.text = wallet.MoneyAvailable.ToReadableString();
		}
	}
}
