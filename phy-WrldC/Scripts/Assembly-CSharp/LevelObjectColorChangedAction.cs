using RLD;
using UnityEngine;

public class LevelObjectColorChangedAction : IUndoRedoAction
{
	private LevelObjectView levelObjectView;

	private Color oldColor;

	private Color newColor;

	private bool oldIsWithGrid;

	private bool newIsWithGrid;

	private bool oldIsAltTexture;

	private bool newIsAltTexture;

	public LevelObjectColorChangedAction(LevelObjectView levelObjectView, Color oldColor, Color newColor, bool oldIsGrid, bool newIsGrid, bool oldIsAltTex, bool newIsAltTex)
	{
		this.levelObjectView = levelObjectView;
		this.oldColor = oldColor;
		this.newColor = newColor;
		oldIsWithGrid = oldIsGrid;
		newIsWithGrid = newIsGrid;
		oldIsAltTexture = oldIsAltTex;
		newIsAltTexture = newIsAltTex;
	}

	public void Execute()
	{
		MonoSingleton<RTUndoRedo>.Get.RecordAction(this);
	}

	public void Undo()
	{
		if (!(levelObjectView == null))
		{
			levelObjectView.SetColor(oldColor);
			levelObjectView.SetGridOnTexture(oldIsWithGrid);
			levelObjectView.IsAltTexOffset = oldIsAltTexture;
		}
	}

	public void Redo()
	{
		if (!(levelObjectView == null))
		{
			levelObjectView.SetColor(newColor);
			levelObjectView.SetGridOnTexture(newIsWithGrid);
			levelObjectView.IsAltTexOffset = newIsAltTexture;
		}
	}

	public void OnRemovedFromUndoRedoStack()
	{
	}
}
