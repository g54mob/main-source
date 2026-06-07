using UnityEngine;

public class LogicEditorInstructionsInventoryView
{
	public GameObject MainPanel { get; private set; }

	public LogicEditorInstructionsInventoryView(LogicEditorView logicEditorView)
	{
		MainPanel = logicEditorView.mainPanel.transform.Find("InstructionsInventoryPanel").gameObject;
		InstructionInventorySlotDragHandler[] componentsInChildren = MainPanel.GetComponentsInChildren<InstructionInventorySlotDragHandler>(includeInactive: true);
		foreach (InstructionInventorySlotDragHandler obj in componentsInChildren)
		{
			obj.OnBeginDragEvent += delegate
			{
				logicEditorView.SetBeingDragEvent(isBeingDrag: true);
			};
			obj.OnEndDragEvent += delegate
			{
				logicEditorView.SetBeingDragEvent(isBeingDrag: false);
			};
		}
		MainPanel.SetActive(value: false);
	}
}
