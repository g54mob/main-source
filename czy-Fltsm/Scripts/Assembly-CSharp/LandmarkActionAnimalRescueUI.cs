using System;
using UnityEngine;

public class LandmarkActionAnimalRescueUI : LandmarkActionUI
{
	private LandmarkActionAnimalRescue _action;

	private RescuePanel _rescuePanel;

	public void Initialize(LandmarkActionAnimalRescue action)
	{
		base.Initialize(action);
		_action = action;
		InitializeRescuePanel();
	}

	private void InitializeRescuePanel()
	{
		Debug.LogException(new NotImplementedException());
	}

	public void UpdateRescuePanel()
	{
		_rescuePanel.ResetPanel();
		InitializeRescuePanel();
	}

	public override bool IsLandmarkActionUI(LandmarkAction landmarkAction)
	{
		return landmarkAction is LandmarkActionAnimalRescue;
	}
}
