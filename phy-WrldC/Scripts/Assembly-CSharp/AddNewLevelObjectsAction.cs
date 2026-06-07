using RLD;
using UnityEngine;

public class AddNewLevelObjectsAction : IUndoRedoAction
{
	private bool shouldDestroyOnRemovedFromStack;

	private LevelObjectView[] levelObjectViews;

	public AddNewLevelObjectsAction(LevelObjectView[] levelObjectViews)
	{
		this.levelObjectViews = levelObjectViews;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (levelObjectViews != null)
		{
			for (int i = 0; i < levelObjectViews.Length; i++)
			{
				levelObjectViews[i].gameObject.SetActive(value: false);
			}
		}
		shouldDestroyOnRemovedFromStack = true;
	}

	public void Redo()
	{
		if (levelObjectViews != null)
		{
			for (int i = 0; i < levelObjectViews.Length; i++)
			{
				levelObjectViews[i].gameObject.SetActive(value: true);
			}
		}
		shouldDestroyOnRemovedFromStack = false;
	}

	public void OnRemovedFromUndoRedoStack()
	{
		if (levelObjectViews != null && shouldDestroyOnRemovedFromStack)
		{
			for (int i = 0; i < levelObjectViews.Length; i++)
			{
				Object.Destroy(levelObjectViews[i].gameObject);
			}
			levelObjectViews = null;
		}
	}
}
