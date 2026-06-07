namespace Gh.Tk
{
	internal interface IAcceptedSlotItemKeyProvider
	{
		string GetAcceptedItemKey(int slotIndex);

		int GetSlotCount();
	}
}
