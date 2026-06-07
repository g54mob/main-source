public class LogicEditorController : BaseController<LogicEditorView, LogicSystemModel>
{
	public CreationButtonsController CreationButtonsController { get; set; }

	public bool IsKeyboardInUse { get; private set; }

	public bool IsBeingDrag { get; private set; }

	public Instruction ClipboardInstruction { get; set; }

	public LogicEditorController(LogicEditorView logicEditorView, LogicSystemModel logicSystemModel)
		: base(logicEditorView, logicSystemModel, false)
	{
		IsKeyboardInUse = false;
		IsBeingDrag = false;
		ClipboardInstruction = null;
	}

	protected override void SyncViewWithModel()
	{
		view.ClearLogicEditor();
		for (int i = 0; i < model.GetAllLogics().Count; i++)
		{
			ModelChangeHandler("LogicSystemModel.AddLogicEvent", model.GetLogic(i), i);
		}
		ClipboardInstruction = null;
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LogicSystemModel.AddLogicEvent":
		{
			Logic logic = data[0] as Logic;
			int index = (int)data[1];
			view.AddUserLogicSlot(logic, index);
			break;
		}
		case "LogicSystemModel.RemoveLogicEvent":
		{
			int index = (int)data[0];
			view.RemoveUserLogicSlot(index);
			break;
		}
		case "LogicSystemModel.SwapLogicEvent":
		{
			int oldIndex = (int)data[0];
			int newIndex = (int)data[1];
			view.SwapUserLogicSlot(oldIndex, newIndex);
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LogicEditorView.SelectUserLogicEvent":
		{
			int index = (int)data[0];
			Logic logic = model.GetLogic(index);
			if (logic != null)
			{
				view.SetSelectedLogic(logic);
			}
			else
			{
				view.DeselectSelectedLogic();
			}
			break;
		}
		case "LogicEditorView.NewUserLogicEvent":
		{
			string logicName = (string)data[0];
			LogicType type = (LogicType)data[1];
			model.AddLogic(logicName, type);
			view.SelectUserLogic(model.GetAllLogics().Count - 1);
			break;
		}
		case "LogicEditorView.DeleteUserLogicEvent":
		{
			int index = (int)data[0];
			view.DeselectSelectedLogic();
			model.RemoveLogic(index);
			break;
		}
		case "LogicEditorView.SwapUserLogicEvent":
		{
			int oldIndex = (int)data[0];
			int newIndex = (int)data[1];
			model.SwapLogic(oldIndex, newIndex);
			break;
		}
		case "LogicEditorView.UpdateIODefaultKey":
		{
			LogicIO logicIO = (LogicIO)data[0];
			GameManager.Instance.MainCreationController.model.UpdateDefaultKey(logicIO.BlockId, logicIO.BodyIndex, logicIO.Name, logicIO.DefaultKey, logicIO.DefaultAxis);
			break;
		}
		case "LogicEditorView.LogicNameChangedEvent":
		{
			Logic logic2 = data[0] as Logic;
			string name = (string)data[1];
			logic2.Name = name;
			view.LogicSlotNameChanged(logic2);
			break;
		}
		case "LogicEditorView.InstructionIndexChangedEvent":
		{
			InstructionsList instructionsList = data[0] as InstructionsList;
			InstructionsList instructionsList2 = data[1] as InstructionsList;
			int oldIndex = (int)data[2];
			int newIndex = (int)data[3];
			if (instructionsList == instructionsList2)
			{
				instructionsList.SwapInstruction(oldIndex, newIndex);
				break;
			}
			Instruction instruction = instructionsList.GetInstruction(oldIndex);
			instructionsList.LightRemoveInstruction(oldIndex);
			instructionsList2.InsertInstruction(instruction, newIndex);
			break;
		}
		case "LogicEditorView.IOButton3DHighlightEvent":
		{
			SocketIO socketIO = data[0] as SocketIO;
			bool isHighlight = (bool)data[1];
			int blockId = socketIO.LogicIO.BlockId;
			if (socketIO.LogicIO.Place == LogicIOPlace.Component)
			{
				CreationButtonsController.view.SetButton3DHighlight(blockId.ToString(), isHighlight);
			}
			else if (socketIO.LogicIO.Place == LogicIOPlace.HingeJoint)
			{
				int bodyIndex = socketIO.LogicIO.BodyIndex;
				int hingeJointIndex = socketIO.LogicIO.HingeJointIndex;
				CreationButtonsController.view.SetButton3DHighlight($"{blockId}.{bodyIndex}.{hingeJointIndex}", isHighlight);
			}
			break;
		}
		case "LogicEditorView.IsKeyboardInUsingEvent":
			IsKeyboardInUse = (bool)data[0];
			GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardTranslationActive(!IsKeyboardInUse);
			GameManager.Instance.CameraManager.OrbitCamera.SetKeyboardVerticalTranslationActive(!IsKeyboardInUse);
			break;
		case "LogicEditorView.IsBeingDragEvent":
			IsBeingDrag = (bool)data[0];
			break;
		case "LogicEditorView.MouseOverScrollViewEvent":
		{
			bool flag = (bool)data[0];
			bool flag2 = (bool)data[1];
			GameManager.Instance.CameraManager.OrbitCamera.SetZoomActive(!(flag && flag2));
			break;
		}
		}
	}
}
