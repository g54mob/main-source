namespace Services.Save.Inventory
{
	public interface IInventorySaveable
	{
		string InstanceId { get; }

		string AddressableKey { get; }

		bool IsSceneItem { get; }
	}
}
