using Unity.Entities;

public struct InitialMoveInventoryFromCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public Entity entityFrom;

	public int startSlotToMove;

	public int amountToMove;
}
