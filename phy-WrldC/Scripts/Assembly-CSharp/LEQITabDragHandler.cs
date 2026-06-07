using UnityEngine;

public class LEQITabDragHandler : QIElementDragHandlerBase
{
	protected override Canvas GetParentCanvas()
	{
		return GUIManager.Instance.LEQuickInventoryView.ParentCanvas;
	}

	protected override void OnEndDragHandler(int oldElementIndex, int newElementIndex)
	{
		GUIManager.Instance.LEQuickInventoryController.model.SwapTab(oldElementIndex, newElementIndex);
	}
}
