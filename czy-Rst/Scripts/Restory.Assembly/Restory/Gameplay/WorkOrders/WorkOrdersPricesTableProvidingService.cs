using Restory.Data.Money;

namespace Restory.Gameplay.WorkOrders
{
	public class WorkOrdersPricesTableProvidingService
	{
		private readonly WorkOrdersPricesTable pricesTable;

		public WorkOrdersPricesTableProvidingService(WorkOrdersPricesTable pricesTable)
		{
			this.pricesTable = pricesTable;
		}

		public bool TryGetWorkOrderPaymentAmount(string rewardID, out int moneyAmount)
		{
			return pricesTable.TryGetWorkOrderPaymentAmount(rewardID, out moneyAmount);
		}
	}
}
