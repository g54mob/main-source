using RLD;

public class LevelObjectLogicPlugedAction : IUndoRedoAction
{
	private LevelObjectView inputLevelObjectView;

	private LevelObjectView outputLevelObjectView;

	private LevelObjectView lastOutputLevelObjectView;

	public LevelObjectLogicPlugedAction(LevelObjectView inputLevelObjectView, LevelObjectView outputLevelObjectView, LevelObjectView lastOutputLevelObjectView)
	{
		this.inputLevelObjectView = inputLevelObjectView;
		this.outputLevelObjectView = outputLevelObjectView;
		this.lastOutputLevelObjectView = lastOutputLevelObjectView;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (!(inputLevelObjectView == null))
		{
			inputLevelObjectView.LevelObjectViewOutput = lastOutputLevelObjectView;
		}
	}

	public void Redo()
	{
		if (!(inputLevelObjectView == null) || !(outputLevelObjectView == null))
		{
			inputLevelObjectView.LevelObjectViewOutput = outputLevelObjectView;
		}
	}

	public void OnRemovedFromUndoRedoStack()
	{
	}
}
