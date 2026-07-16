public class PlaceableItem : ItemBehaviour, IItemBehavior
{
	void IItemBehavior.OnItemSelection(Item item)
	{
		_ = InventorySystem.GetItemLibrary().itemInfos[item.id];
		GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.NPCDialogSequence);
	}

	void IItemBehavior.OnItemUse(Item item)
	{
	}
}
