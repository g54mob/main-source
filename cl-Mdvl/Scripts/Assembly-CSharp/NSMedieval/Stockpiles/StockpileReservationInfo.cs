using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval.Stockpiles
{
	public readonly struct StockpileReservationInfo
	{
		private readonly CreatureBase agent;

		private readonly SimpleResourceCount count;

		public SimpleResourceCount Count => count;

		public Resource Blueprint => count.Blueprint;

		public int Amount => count.Amount;

		public CreatureBase Agent => agent;

		public StockpileReservationInfo(SimpleResourceCount count, CreatureBase agent)
		{
			this.agent = agent;
			this.count = count;
		}
	}
}
