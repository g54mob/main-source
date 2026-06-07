using System;
using System.Collections;

public class MoveItems : TaskBase
{
	public TransferTarget TargetInventory;

	public SubInventoryType InventoryList;

	public MoveItemsTarget ItemsMoveTarget;

	public bool RemoveMovedItemsFromProject;

	public override TaskType Type => TaskType.MoveItems;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		throw new NotImplementedException();
	}

	protected override void OnGUI()
	{
		Header("Move items", 4, ReturnTypeColor());
		_itemTransferDuration = EditorGUI_FloatField("Duration", _itemTransferDuration);
		TargetInventory = (TransferTarget)(object)EditorGUI_EnumField("Target inventory", TargetInventory);
		InventoryList = (SubInventoryType)(object)EditorGUI_EnumField("Inventory list", InventoryList);
		RemoveMovedItemsFromProject = EditorGUI_Toggle("Remove moved items from project?", RemoveMovedItemsFromProject);
		EditorGUI_HelpBox("Moves items from the project shopping list to the target inventory's list with a given delay.");
	}
}
