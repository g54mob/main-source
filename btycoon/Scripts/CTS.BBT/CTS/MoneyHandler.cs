using System;
using System.Collections.Generic;
using System.Globalization;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MoneyHandler : MonoSingleton<MoneyHandler>
	{
		public int numberOfBars = 7;

		private int _currentLevel;

		private int _haemas;

		public int CurrentMoney { get; private set; }

		[field: SerializeField]
		public List<int> MoneyFluctuation { get; private set; } = new List<int>();

		public static event Action<int> MoneyAmountChanged;

		public static event Action<int> EarnedMoney;

		public static event Action LostMoney;

		private void OnEnable()
		{
			EventsManager.ChangeMoney = (Func<Currencies, int, int>)Delegate.Combine(EventsManager.ChangeMoney, new Func<Currencies, int, int>(ChangeMoney));
		}

		private void OnDisable()
		{
			EventsManager.ChangeMoney = (Func<Currencies, int, int>)Delegate.Remove(EventsManager.ChangeMoney, new Func<Currencies, int, int>(ChangeMoney));
			CurrentMoney = 0;
		}

		private int ChangeMoney(Currencies p_currency, int p_change)
		{
			if (p_currency == Currencies.Haemas)
			{
				return _haemas += p_change;
			}
			CurrentMoney += p_change;
			MoneyFluctuation.Add(CurrentMoney);
			MoneyHandler.MoneyAmountChanged?.Invoke(CurrentMoney);
			if (p_change > 0)
			{
				MoneyHandler.EarnedMoney?.Invoke(p_change);
			}
			if (p_change < 0)
			{
				MoneyHandler.LostMoney?.Invoke();
			}
			return CurrentMoney;
		}

		public int GetCurrentMoney(Currencies p_currency)
		{
			if (p_currency == Currencies.Haemas)
			{
				return _haemas;
			}
			return CurrentMoney;
		}

		public void SetCurrentMoney(int p_newMoneyAmount)
		{
			CurrentMoney = p_newMoneyAmount;
			MoneyHandler.MoneyAmountChanged?.Invoke(CurrentMoney);
		}

		public static string GetToMoneyStringFormat(int amount)
		{
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
			numberFormatInfo.NumberGroupSeparator = " ";
			return " " + ((amount < 0) ? "-" : "") + "$" + Math.Abs(amount).ToString("#,0", numberFormatInfo);
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
