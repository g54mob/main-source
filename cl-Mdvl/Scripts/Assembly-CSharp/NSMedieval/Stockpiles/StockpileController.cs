using System;
using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.Stockpiles
{
	public class StockpileController : MonoSingleton<StockpileController>
	{
		public event Action<StockpileInstance> StockpilePlacedEvent;

		public event Action<StockpileInstance> StockpileDestroyedEvent;

		public void StockpilePlaced(StockpileInstance stockpileInstance)
		{
			this.StockpilePlacedEvent?.Invoke(stockpileInstance);
			if (MonoSingleton<ResourcePileTracker>.IsInstantiated())
			{
				MonoSingleton<ResourcePileTracker>.Instance.ScheduleRecountPiles();
			}
		}

		public void StockpileDestroyed(StockpileInstance stockpileInstance)
		{
			this.StockpileDestroyedEvent?.Invoke(stockpileInstance);
		}
	}
}
