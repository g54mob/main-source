using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FurnishingsController : PageBasedContent
{
	public enum TabState
	{
		inRoom = 0,
		inStorage = 1,
		inShop = 2
	}

	[Header("Components")]
	public RectTransform rect;

	public WindowContentController wcc;

	public RectTransform entryParent;

	public ButtonController inRoomButton;

	public ButtonController inStorageButton;

	public ButtonController inShopButton;

	public GameObject furnitureElementPrefab;

	public ButtonController chairsButton;

	public ButtonController tablesButton;

	public ButtonController unitsButton;

	public ButtonController electronicsButton;

	public ButtonController structuralButton;

	public ButtonController decorationButton;

	public ButtonController miscButton;

	[Header("Settings")]
	public Sprite uncheckedSprite;

	public Sprite checkedSprite;

	[Header("State")]
	public bool isSetup;

	public TabState tabState;

	public List<FurniturePreset.DecorClass> displayClasses;

	public NewRoom room;

	public MaterialKeyController keyController;

	public TMP_InputField searchInputField;

	private List<FurniturePreset> allRequired;

	private List<FurnitureLocation> allRequiredExisting;

	public List<DecorElementController> spawnedEntries;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public void SetTabState(int newState)
	{
	}

	public void SetTabState(TabState newState, bool forceUpdate = false)
	{
	}

	public override void UpdateListDisplay()
	{
	}

	public void ToggleDisplayClass(int classInt)
	{
	}

	public void SetSelected(FurniturePreset newSelection, FurnitureLocation existingLocation, bool newPlaceExistingRoomObject)
	{
	}

	public void ClearSearchButton()
	{
	}

	public void OnFurnitureChange()
	{
	}

	public void OnChangeRoom()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	public void MoveAllToStorageButton()
	{
	}

	public void ConfirmMoveToStorage()
	{
	}

	public void CancelMoveToStorage()
	{
	}

	public override int GetMaxPages()
	{
		return 0;
	}
}
