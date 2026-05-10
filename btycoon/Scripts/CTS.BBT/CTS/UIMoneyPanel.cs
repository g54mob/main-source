using System.Globalization;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UIMoneyPanel : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _moneyText;

		private void OnEnable()
		{
			MoneyHandler.MoneyAmountChanged += SetMoneyAmount;
			SetMoneyAmount(MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
		}

		private void OnDisable()
		{
			MoneyHandler.MoneyAmountChanged -= SetMoneyAmount;
		}

		private void SetMoneyAmount(int amount)
		{
			if ((bool)_moneyText)
			{
				string text = amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
				_moneyText.text = text.Substring(0, text.Length - 3);
			}
		}
	}
}
