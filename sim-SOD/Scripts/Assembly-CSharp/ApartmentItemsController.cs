using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApartmentItemsController : PageBasedContent
{
	[Header("Components")]
	public RectTransform rect;

	public WindowContentController wcc;

	public RectTransform entryParent;

	public ButtonController inRoomButton;

	public ButtonController inStorageButton;

	public ButtonController inShopButton;

	public GameObject itemElementPrefab;

	public ButtonController consumableButton;

	public ButtonController medicalButton;

	public ButtonController equipmentButton;

	public ButtonController electronicsButton;

	public ButtonController documentsButton;

	public ButtonController miscButton;

	[Header("Settings")]
	public Sprite uncheckedSprite;

	public Sprite checkedSprite;

	[Header("State")]
	public bool isSetup;

	public FurnishingsController.TabState tabState;

	public List<InteractablePreset.ItemClass> displayClasses;

	public NewRoom room;

	private List<InteractablePreset> allRequired;

	private List<Interactable> allRequiredExisting;

	public TMP_InputField searchInputField;

	public List<ApartmentItemElementController> spawnedEntries;

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public void SetTabState(int newState)
	{
	}

	public void SetTabState(FurnishingsController.TabState newState, bool forceUpdate = false)
	{
	}

	public override void UpdateListDisplay()
	{
	}

	public void ToggleDisplayClass(int classInt)
	{
	}

	public void PlaceObject(Interactable existingObject)
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

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
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
