using AssembleSystem.Utils;

namespace AssembleSystem
{
	public interface IInventoryManagable
	{
		string ID { get; }

		PartConfig ItemConfig { get; }

		void PickupItem();

		void RemoveItem();
	}
}
