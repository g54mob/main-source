using System;
using System.Collections.Generic;

namespace Restory.Gameplay.MoneyCash
{
	public class CashMoneyObjectRegistry
	{
		private readonly HashSet<CashMoneyObject> all = new HashSet<CashMoneyObject>();

		public IReadOnlyCollection<CashMoneyObject> All => all;

		public event Action<CashMoneyObject> OnInteractiveObjectRegistered;

		public event Action<CashMoneyObject> OnInteractiveObjectUnregistered;

		public void Register(CashMoneyObject cashMoneyObject)
		{
			if (all.Add(cashMoneyObject))
			{
				this.OnInteractiveObjectRegistered?.Invoke(cashMoneyObject);
			}
		}

		public void Unregister(CashMoneyObject cashMoneyObject)
		{
			if (all.Remove(cashMoneyObject))
			{
				this.OnInteractiveObjectUnregistered?.Invoke(cashMoneyObject);
			}
		}

		public void Clear()
		{
			all.Clear();
		}
	}
}
