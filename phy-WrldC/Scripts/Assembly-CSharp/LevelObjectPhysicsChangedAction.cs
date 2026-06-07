using RLD;

public class LevelObjectPhysicsChangedAction : IUndoRedoAction
{
	private LevelObjectView levelObjectView;

	private bool oldIsAffectedByPhysics;

	private bool newIsAffectedByPhysic;

	private float oldMassValue;

	private float newMassValue;

	public LevelObjectPhysicsChangedAction(LevelObjectView levelObjectView, bool oldIsAffected, bool newIsAffected, float oldMass, float newMass)
	{
		this.levelObjectView = levelObjectView;
		oldIsAffectedByPhysics = oldIsAffected;
		newIsAffectedByPhysic = newIsAffected;
		oldMassValue = oldMass;
		newMassValue = newMass;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (!(levelObjectView == null))
		{
			levelObjectView.IsAffectedByPhysics = oldIsAffectedByPhysics;
			levelObjectView.Mass = oldMassValue;
		}
	}

	public void Redo()
	{
		if (!(levelObjectView == null))
		{
			levelObjectView.IsAffectedByPhysics = newIsAffectedByPhysic;
			levelObjectView.Mass = newMassValue;
		}
	}

	public void OnRemovedFromUndoRedoStack()
	{
	}
}
