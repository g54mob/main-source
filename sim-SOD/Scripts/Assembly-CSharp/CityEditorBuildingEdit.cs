using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CityEditorBuildingEdit : MonoBehaviour
{
	public delegate void NewTileSelection(CityTile newSelected);

	[Header("References")]
	public GameObject tileSelect1;

	public GameObject tileSelect2;

	public DropdownController buildingTypeDropdown;

	public ButtonController buildingNameButton;

	public ButtonController randomNameButton;

	public ButtonController rotateButton;

	[Header("State")]
	public CityTile currentlyMousedOverTile;

	public CityTile currentlySelectedTile;

	private List<BuildingPreset> buildingPresets;

	private List<NewBuilding> animatingBuildingRotation;

	private TMP_Text _buildingNameText;

	public event NewTileSelection OnNewTileSelection
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

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void SelectBuilding(CityTile newTile)
	{
	}

	public void OnRandomBuildingNameButton()
	{
	}

	public void OnChangeBuildingType()
	{
	}

	public void OnChangeBuildingNameButton()
	{
	}

	private void OnChangeBuildingNamePopupCancel()
	{
	}

	private void OnChangeBuildingNamePopupConfirm()
	{
	}

	public void RenameSelectedBuilding(string newBuildingName)
	{
	}

	public void OnRotateButton()
	{
	}

	private void ProcessSwapBuildingInput()
	{
	}

	private CityTile TryGetTile()
	{
		return null;
	}

	private void SwapTiles(CityTile originTile, CityTile targetTile)
	{
	}

	private void ResetSelection()
	{
	}

	private void OnDisable()
	{
	}
}
