using UnityEngine;

public class EditableTabDragHandler : QIElementDragHandlerBase
{
	protected override Canvas GetParentCanvas()
	{
		return GUIManager.Instance.QuickInventoryView.ParentCanvas;
	}

	protected override void OnEndDragHandler(int oldElementIndex, int newElementIndex)
	{
		GameManager.Instance.QuickInventoryController.model.SwapTab(oldElementIndex, newElementIndex);
	}
}
