using System;
using UnityEngine;

[Serializable]
public class GameplayPlayerData
{
	public bool ForceMouseAndKeyboard;

	public bool EdgeScrolling;

	public bool InvertHorizontalRotation;

	public bool InvertVerticalRotation;

	public bool InvertScrolling;

	public float RotationSensitivity = 0.5f;

	public float MovementSensitivity = 0.5f;

	public float ScrollingSensitivity = 0.5f;

	public int SelectedLanguageIndex;

	public int AutosaveLimit = 5;

	public bool ToggleGeneralStorageFilters = true;

	public bool SnapBuilding = true;

	public bool ShowBuildingGrid = true;

	public GameplayPlayerData()
	{
	}

	public GameplayPlayerData(GameplayPlayerData gameplayPlayerData)
	{
		Copy(gameplayPlayerData);
	}

	public void ResetSettings()
	{
		ForceMouseAndKeyboard = false;
		EdgeScrolling = true;
		InvertHorizontalRotation = false;
		InvertVerticalRotation = false;
		InvertScrolling = false;
		RotationSensitivity = 0.5f;
		MovementSensitivity = 0.5f;
		ScrollingSensitivity = 0.5f;
		SelectedLanguageIndex = 0;
		AutosaveLimit = 5;
		ToggleGeneralStorageFilters = true;
		SnapBuilding = true;
		ShowBuildingGrid = true;
	}

	public bool IsEqual(GameplayPlayerData gameplayData)
	{
		if (gameplayData.ForceMouseAndKeyboard != ForceMouseAndKeyboard)
		{
			return false;
		}
		if (gameplayData.EdgeScrolling != EdgeScrolling)
		{
			return false;
		}
		if (gameplayData.InvertHorizontalRotation != InvertHorizontalRotation)
		{
			return false;
		}
		if (gameplayData.InvertVerticalRotation != InvertVerticalRotation)
		{
			return false;
		}
		if (gameplayData.InvertScrolling != InvertScrolling)
		{
			return false;
		}
		if (!Mathf.Approximately(gameplayData.MovementSensitivity, MovementSensitivity))
		{
			return false;
		}
		if (!Mathf.Approximately(gameplayData.RotationSensitivity, RotationSensitivity))
		{
			return false;
		}
		if (!Mathf.Approximately(gameplayData.ScrollingSensitivity, ScrollingSensitivity))
		{
			return false;
		}
		if (gameplayData.SelectedLanguageIndex != SelectedLanguageIndex)
		{
			return false;
		}
		if (gameplayData.AutosaveLimit != AutosaveLimit)
		{
			return false;
		}
		if (gameplayData.ToggleGeneralStorageFilters != ToggleGeneralStorageFilters)
		{
			return false;
		}
		return true;
	}

	public void Copy(GameplayPlayerData gameplayPlayerData)
	{
		ForceMouseAndKeyboard = gameplayPlayerData.ForceMouseAndKeyboard;
		EdgeScrolling = gameplayPlayerData.EdgeScrolling;
		InvertHorizontalRotation = gameplayPlayerData.InvertHorizontalRotation;
		InvertVerticalRotation = gameplayPlayerData.InvertVerticalRotation;
		InvertScrolling = gameplayPlayerData.InvertScrolling;
		MovementSensitivity = gameplayPlayerData.MovementSensitivity;
		RotationSensitivity = gameplayPlayerData.RotationSensitivity;
		ScrollingSensitivity = gameplayPlayerData.ScrollingSensitivity;
		SelectedLanguageIndex = gameplayPlayerData.SelectedLanguageIndex;
		AutosaveLimit = gameplayPlayerData.AutosaveLimit;
		ToggleGeneralStorageFilters = gameplayPlayerData.ToggleGeneralStorageFilters;
	}
}
