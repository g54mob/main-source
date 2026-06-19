using Inventory;
using Unity.Entities;
using Unity.Mathematics;

public struct UIInputActionData
{
	public const int EXECUTION_TICK_OFFSET = 1;

	public UIInputAction action;

	public float2 position;

	public Entity entity;

	public InventoryChangeData inventoryChangeData;

	public CraftActionData craftActionData;
}
