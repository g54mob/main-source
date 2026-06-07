using System;
using System.Collections;
using DV.Localization;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV.CashRegister
{
	public class CashRegisterWithModulesTextController
	{
		private TextMeshPro cashText;

		private TextMeshPro totalCostText;

		private TextMeshPro infoText;

		private CashRegisterWithModules cashRegister;

		private string insetWalletToPayText;

		private string readyToBuyText;

		private string selectProductText;

		private string goodByeText;

		private string processingTransactionText;

		private float goodByeTextDuration;

		private Coroutine goodbyeCoro;

		public CashRegisterWithModulesTextController(CashRegisterWithModules cashRegister, TextMeshPro cashText, TextMeshPro totalCostText, TextMeshPro infoText, float goodByeTextDuration)
		{
			this.cashRegister = cashRegister;
			if (cashRegister == null)
			{
				throw new ArgumentNullException("CashRegisterWithModulesTextController needs a valid CashRegisterWithModules reference.");
			}
			this.cashText = cashText;
			this.totalCostText = totalCostText;
			this.infoText = infoText;
			insetWalletToPayText = LocalizationAPI.L("cashreg/insert_wallet");
			readyToBuyText = LocalizationAPI.L("cashreg/ready_to_buy");
			selectProductText = LocalizationAPI.L("cashreg/select_product");
			goodByeText = LocalizationAPI.L("cashreg/good_bye");
			processingTransactionText = LocalizationAPI.L("cashreg/processing_transaction");
			this.goodByeTextDuration = goodByeTextDuration;
		}

		public void UpdateCashText()
		{
			TextMeshPro textMeshPro = cashText;
			string text = (cashText.text = "$" + cashRegister.DepositedCash.ToString("N2", LocalizationAPI.CC));
			textMeshPro.text = text;
		}

		public void UpdateTotalCostText()
		{
			totalCostText.text = "$" + cashRegister.GetTotalCost().ToString("N2", LocalizationAPI.CC);
		}

		public void UpdateInfoText()
		{
			StopGoodbyeCoro();
			if (cashRegister.IsProcessingTransaction)
			{
				infoText.text = processingTransactionText;
			}
			else
			{
				infoText.text = ((cashRegister.TotalUnitsInBasket() <= 0f) ? selectProductText : ((cashRegister.DepositedCash < cashRegister.GetTotalCost()) ? insetWalletToPayText : readyToBuyText));
			}
		}

		public void DisplayGoodbyeText()
		{
			StopGoodbyeCoro();
			goodbyeCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(GoodbyeCoro());
		}

		private IEnumerator GoodbyeCoro()
		{
			infoText.text = goodByeText;
			yield return WaitFor.Seconds(goodByeTextDuration);
			UpdateInfoText();
		}

		private void StopGoodbyeCoro()
		{
			if (goodbyeCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(goodbyeCoro);
				goodbyeCoro = null;
			}
		}

		public void UpdateAllTexts()
		{
			UpdateCashText();
			UpdateTotalCostText();
			UpdateInfoText();
		}

		public void Clear()
		{
			cashText.text = string.Empty;
			totalCostText.text = string.Empty;
			infoText.text = string.Empty;
			StopGoodbyeCoro();
		}
	}
}
