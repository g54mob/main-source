using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CityEditorController : HighlanderSingleton<CityEditorController>
{
	[Serializable]
	public enum CityEditorMode
	{
		EditBuildings = 1,
		EditStreets = 2,
		Default = 0
	}

	[Serializable]
	public enum CityEditorSubMode
	{
		MoveSelection = 1,
		RenameSelection = 2,
		Default = 0
	}

	public delegate void NewCityEditorData();

	[Header("References")]
	public NewBuilding activeBuilding;

	public Camera cityEditorCam;

	public CityEditorMode currentMode;

	public CityEditorSubMode currentSubMode;

	public PrototypeDebugPanel canvasController;

	[Tooltip("The editor has it's own overrides for post processing; enable/disable this along with the editor itself")]
	public GameObject cityEditorPostProcessingVolume;

	[Tooltip("Disable/Reenable these objects when the city editor is active")]
	public List<GameObject> disableWhileActive;

	[Tooltip("A floor objects that acts as a collider for the mouse ray")]
	public GameObject cityEditFloor;

	[Header("State")]
	public bool needsUpdatedPathfinding;

	public bool dataGenerated;

	[Tooltip("Is/should the city constructor loading something? This is mostly used to trigger the DoF effect but could be useful elsewhere")]
	public bool isLoading;

	public ButtonController previouslySelected;

	public bool canFinishLoadFromCurrentState;

	public CityEditorStreetEdit cityEditorStreetEdit;

	private CityEditorBuildingEdit _buildingEditor;

	private CityEditorStreetEdit _streetEditor;

	private CityEditorInputController _editCam;

	public event NewCityEditorData OnNewCityEditorData
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void GetComponentReferences()
	{
	}

	public void RerunPathfinder()
	{
	}

	public void GenerateNewCityEditorData()
	{
	}

	public void OnHaltOnEndOfLoadState(CityConstructor.LoadState haltedOnState)
	{
	}

	public void ClearCurrentCityEditorData()
	{
	}

	public void FinishLoading()
	{
	}

	public void SetCityEditorWarning(string warning)
	{
	}

	public void SetCityEditor(bool condition)
	{
	}

	public void SwitchEditorMode(CityEditorMode mode)
	{
	}

	public void SwitchEditorSubMode(CityEditorSubMode submode)
	{
	}

	private void DeactivateEditors()
	{
	}

	public ButtonController GetLastSelected()
	{
		return null;
	}

	private void InitializeSelectedModeComponents()
	{
	}

	public void OnNewTileSelected(CityTile newSelection)
	{
	}

	public bool DoesCurrentMapMeetCityRequirements(bool displayPopups)
	{
		return false;
	}

	private void OnDisable()
	{
	}
}
