using System;
using System.Collections.Generic;

namespace Restory.Gameplay.RegularPayments
{
	public class RegularPaymentObjectRegistry
	{
		private readonly HashSet<RegularPaymentObject> all = new HashSet<RegularPaymentObject>();

		public IReadOnlyCollection<RegularPaymentObject> All => all;

		public event Action<RegularPaymentObject> OnRegistered;

		public event Action<RegularPaymentObject> OnUnregistered;

		public event Action OnCleared;

		public void Register(RegularPaymentObject device)
		{
			if (all.Add(device))
			{
				this.OnRegistered?.Invoke(device);
			}
		}

		public void Unregister(RegularPaymentObject device)
		{
			if (all.Remove(device))
			{
				this.OnUnregistered?.Invoke(device);
			}
		}

		public void Clear()
		{
			all.Clear();
			this.OnCleared?.Invoke();
		}
	}
}
