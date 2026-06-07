using System.Collections.Generic;

namespace Gh.Tk
{
	public class StockInfo : IPersistable
	{
		[PersistenceObjectReference]
		public List<GameItem> Items;

		public int totalAmount;

		private LoggedInt demand;

		private LoggedInt GetDemandObject()
		{
			return null;
		}

		public void RecordDemand(int amount)
		{
		}

		public int GetDemandPast48Hours()
		{
			return 0;
		}
	}
}
