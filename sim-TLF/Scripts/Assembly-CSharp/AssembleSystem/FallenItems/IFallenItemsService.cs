namespace AssembleSystem.FallenItems
{
	public interface IFallenItemsService
	{
		void Register(IInventoryManagable item);

		void Unregister(IInventoryManagable item);
	}
}
