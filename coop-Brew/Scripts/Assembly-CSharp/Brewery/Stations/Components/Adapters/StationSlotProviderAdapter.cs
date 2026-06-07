using Brewery.Stations.Components.Interfaces;

namespace Brewery.Stations.Components.Adapters
{
	public sealed class StationSlotProviderAdapter : IStationSlotProvider
	{
		private readonly BaseBreweryStation station;

		public int InputSlotCount => 0;

		public StationSlotProviderAdapter(BaseBreweryStation station)
		{
		}

		public StationSlotData GetInputSlot(int index)
		{
			return default(StationSlotData);
		}

		public void SetInputSlot(int index, StationSlotData data)
		{
		}

		public StationSlotData GetOutputSlot()
		{
			return default(StationSlotData);
		}

		public void SetOutputSlot(StationSlotData data)
		{
		}

		public void ClearInputSlots()
		{
		}

		public void NotifySlotsChanged()
		{
		}
	}
}
