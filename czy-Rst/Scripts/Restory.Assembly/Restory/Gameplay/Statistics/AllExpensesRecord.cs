using System;
using System.Collections.Generic;
using Restory.Data.RegularPayments;

namespace Restory.Gameplay.Statistics
{
	[Serializable]
	public class AllExpensesRecord
	{
		public List<RegularPaymentInfo> RegularPayments = new List<RegularPaymentInfo>();

		public List<Expense> Purchases = new List<Expense>();
	}
}
