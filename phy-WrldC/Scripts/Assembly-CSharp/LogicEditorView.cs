using UnityEngine;

public class LogicEditorView : BaseGUIView
{
	public const string SelectUserLogicEvent = "LogicEditorView.SelectUserLogicEvent";

	public const string NewUserLogicEvent = "LogicEditorView.NewUserLogicEvent";

	public const string DeleteUserLogicEvent = "LogicEditorView.DeleteUserLogicEvent";

	public const string SwapUserLogicEvent = "LogicEditorView.SwapUserLogicEvent";

	public const string UpdateIODefaultKey = "LogicEditorView.UpdateIODefaultKey";

	public const string LogicNameChangedEvent = "LogicEditorView.LogicNameChangedEvent";

	public const string InstructionIndexChangedEvent = "LogicEditorView.InstructionIndexChangedEvent";

	public const string IOButton3DHighlightEvent = "LogicEditorView.IOButton3DHighlightEvent";

	public const string IsKeyboardInUsingEvent = "LogicEditorView.IsKeyboardInUsingEvent";

	public const string IsBeingDragEvent = "LogicEditorView.IsBeingDragEvent";

	public const string MouseOverScrollViewEvent = "LogicEditorView.MouseOverScrollViewEvent";

	public GameObject logicSlotPrefab;

	public GameObject blockInputSlotPrefab;

	public GameObject blockOutputSlotPrefab;

	public LogicEditorUserLogicView LogicEditorUserLogicView { get; set; }

	public LogicEditorSelectedLogicView LogicEditorSelectedLogicView { get; set; }

	public LogicEditorInstructionsInventoryView LogicEditorInstructionsInventoryView { get; set; }

	public LogicEditorBlockIOView LogicEditorBlockIOView { get; set; }

	public override void Initialize()
	{
		LogicEditorUserLogicView = new LogicEditorUserLogicView(this);
		LogicEditorSelectedLogicView = new LogicEditorSelectedLogicView(this);
		LogicEditorInstructionsInventoryView = new LogicEditorInstructionsInventoryView(this);
		LogicEditorBlockIOView = new LogicEditorBlockIOView(this);
		LogicEditorUserLogicView.OnBeginingEditLogicName += delegate
		{
			NotifyChange("LogicEditorView.IsKeyboardInUsingEvent", true);
		};
		LogicEditorUserLogicView.OnEndingEditLogicName += delegate
		{
			NotifyChange("LogicEditorView.IsKeyboardInUsingEvent", false);
		};
		LogicEditorSelectedLogicView.OnBeginingEditLogicName += delegate
		{
			NotifyChange("LogicEditorView.IsKeyboardInUsingEvent", true);
		};
		LogicEditorSelectedLogicView.OnEndingEditLogicName += delegate
		{
			NotifyChange("LogicEditorView.IsKeyboardInUsingEvent", false);
		};
		LogicEditorSelectedLogicView.OnLogicNameChangedEvent += delegate(Logic logic, string newName)
		{
			NotifyChange("LogicEditorView.LogicNameChangedEvent", logic, newName);
		};
		LogicEditorSelectedLogicView.OnLogicActivationChangedEvent += LogicEditorUserLogicView.SetLogicSlotActiveState;
		Util.AddMouseOverUIEvents(LogicEditorUserLogicView.MainPanel, base.OnMouseOverUIHandler);
		Util.AddMouseOverUIEvents(LogicEditorSelectedLogicView.MainPanel, base.OnMouseOverUIHandler);
		Util.AddMouseOverUIEvents(LogicEditorInstructionsInventoryView.MainPanel, base.OnMouseOverUIHandler);
		Util.AddMouseOverUIEvents(LogicEditorBlockIOView.MainPanel, base.OnMouseOverUIHandler);
	}

	public void ClearLogicEditor()
	{
		LogicEditorUserLogicView.ClearLogicSlots();
	}

	public void AddUserLogicSlot(Logic logic, int index)
	{
		LogicEditorUserLogicView.AddUserLogicSlot(logic, index);
	}

	public void RemoveUserLogicSlot(int index)
	{
		LogicEditorUserLogicView.RemoveUserLogicSlot(index);
	}

	public void SwapUserLogicSlot(int oldIndex, int newIndex)
	{
		LogicEditorUserLogicView.SwapUserLogicSlot(oldIndex, newIndex);
	}

	public void LogicSlotNameChanged(Logic logic)
	{
		LogicEditorUserLogicView.LogicSlotNameChanged(logic);
	}

	public void SetSelectedLogic(Logic logic)
	{
		LogicEditorSelectedLogicView.SetSelectedLogic(logic);
	}

	public void DeselectSelectedLogic()
	{
		LogicEditorSelectedLogicView.DeselectSelectedLogic();
	}

	public void SelectUserLogic(int index)
	{
		LogicEditorUserLogicView.SetSelectedLogicSlot(index);
		NotifyChange("LogicEditorView.SelectUserLogicEvent", index);
	}

	public void NewUserLogicHandler(string name)
	{
		NotifyChange("LogicEditorView.NewUserLogicEvent", name, LogicType.Loop);
	}

	public void DeleteUserLogicHandler(int index)
	{
		NotifyChange("LogicEditorView.DeleteUserLogicEvent", index);
	}

	public void SwapUserLogicHandler(int oldIndex, int newIndex)
	{
		NotifyChange("LogicEditorView.SwapUserLogicEvent", oldIndex, newIndex);
	}

	public void UpdateIODefaultKeyHandler(LogicIO logicIO)
	{
		NotifyChange("LogicEditorView.UpdateIODefaultKey", logicIO);
	}

	public void InstructionIndexChangedHandler(InstructionsList oldInstructionsList, InstructionsList newInstructionsList, int oldIndex, int newIndex)
	{
		NotifyChange("LogicEditorView.InstructionIndexChangedEvent", oldInstructionsList, newInstructionsList, oldIndex, newIndex);
	}

	public void SetIOButton3DHighlight(SocketIO socketIO, bool isHighlighted)
	{
		NotifyChange("LogicEditorView.IOButton3DHighlightEvent", socketIO, isHighlighted);
	}

	public void MouseOverScrollViewHandler(bool isMouseOverScrollView, bool isScrollbarActive)
	{
		NotifyChange("LogicEditorView.MouseOverScrollViewEvent", isMouseOverScrollView, isScrollbarActive);
	}

	public void SetKeyboardInUse(bool isKeyboardInUse)
	{
		NotifyChange("LogicEditorView.IsKeyboardInUsingEvent", isKeyboardInUse);
	}

	public void SetBeingDragEvent(bool isBeingDrag)
	{
		NotifyChange("LogicEditorView.IsBeingDragEvent", isBeingDrag);
	}
}
