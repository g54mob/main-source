namespace Brewery.Stations.Components.Interfaces
{
	public interface IStationSlotProvider
	{
		int InputSlotCount { get; }

		StationSlotData GetInputSlot(int index);

		void SetInputSlot(int index, StationSlotData data);

		StationSlotData GetOutputSlot();

		void SetOutputSlot(StationSlotData data);

		void ClearInputSlots();

		void NotifySlotsChanged();
	}
}
