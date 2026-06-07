using UnityEngine;

public abstract class ItemDataInventory : IPathfindingNodeProvider
{
	public Transform transform => Inventory.transform;

	public Inventory Inventory { get; private set; }

	public TownQueryCache.Path Path { get; private set; }

	public ItemDataInventory(Inventory inventory)
	{
		Inventory = inventory;
	}

	public void PopulatePath(IPathfindingNodeProvider destination)
	{
		Path = TownQueryCache.ReturnPath(destination, Inventory);
	}

	public PathfindingNode ReturnPathfindingNode(Navigator navigator)
	{
		return Inventory.ReturnPathfindingNode(navigator);
	}
}
