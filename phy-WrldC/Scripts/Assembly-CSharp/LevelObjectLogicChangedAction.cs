using RLD;

public class LevelObjectLogicChangedAction : IUndoRedoAction
{
	private LevelObjectView levelObjectView;

	private bool oldIsInvertedLogic;

	private bool newIsInvertedLogic;

	private bool oldIsPressOnce;

	private bool newIsPressOnce;

	public LevelObjectLogicChangedAction(LevelObjectView levelObjectView, bool oldIsInvertedLogic, bool newIsInvertedLogic, bool oldIsPressOnce, bool newIsPressOnce)
	{
		this.levelObjectView = levelObjectView;
		this.oldIsInvertedLogic = oldIsInvertedLogic;
		this.newIsInvertedLogic = newIsInvertedLogic;
		this.oldIsPressOnce = oldIsPressOnce;
		this.newIsPressOnce = newIsPressOnce;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (!(levelObjectView == null))
		{
			levelObjectView.IsInvertedLogic = oldIsInvertedLogic;
			levelObjectView.IsPressOnce = oldIsPressOnce;
		}
	}

	public void Redo()
	{
		if (!(levelObjectView == null))
		{
			levelObjectView.IsInvertedLogic = newIsInvertedLogic;
			levelObjectView.IsPressOnce = newIsPressOnce;
		}
	}

	public void OnRemovedFromUndoRedoStack()
	{
	}
}
