using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public abstract class Bill : ICloneable
	{
		[SerializeField]
		protected float defaultPrice;

		[SerializeField]
		protected float priceMultiplier = 1f;

		[SerializeField]
		protected int daysBeforeMalus;

		[SerializeField]
		[ReadOnly(false, false)]
		protected int unpaidDays;

		[SerializeField]
		[ReadOnly(false, false)]
		protected float dueAmount;

		public int UnpaidDays => unpaidDays;

		public float DueAmount => dueAmount;

		public event Action OnPay;

		public abstract float GetDailyPrice();

		public bool TryPay()
		{
			if (dueAmount <= 0f || GameState.MoneyAmount < dueAmount)
			{
				return false;
			}
			Pay();
			return true;
		}

		private void Pay()
		{
			World.GameState.ConsumeMoney(dueAmount);
			unpaidDays = 0;
			dueAmount = 0f;
			this.OnPay?.Invoke();
		}

		public void UnPaid()
		{
			unpaidDays++;
			if (unpaidDays <= BillsSettings.MaxDaysPriceIncrease)
			{
				dueAmount += GetDailyPrice();
			}
		}

		public void HandleScoreMalus()
		{
			if (!(dueAmount <= 0f))
			{
				World.ScoreManager.ComputeFromScore(ScoreSettings.GetBillMalus(this), "Malus due to unpaid bill " + GetType().Name);
			}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
