using Restory.Data.RegularPayments;
using Restory.Gameplay.Statistics;

namespace Restory.UI.Views.DayEndWindow
{
	public class MoneyReceiptData
	{
		public int MoneyEarnedFromCompletingWorkOrders;

		public int MoneyEarnedFromCompletingEmailOrders;

		public int MoneyEarnedFromSellingDevices;

		public int MoneyBalanceChangeToday;

		public int MoneyBalance;

		public Expense[] Purchases;

		public RegularPaymentInfo[] RegularPaymentsMade;
	}
}
