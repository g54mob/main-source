using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelInventoryBoxes : MonoBehaviour
{
	public GameObject boxRef;

	public Transform boxHolder;

	public PanelInventoryGUIController guiRef;

	public CursorUpdateArea updateAreaRef;

	public CoreScrollbarUnityGUI scrollRef;

	public RectTransform foodAreaTransform;

	public RectTransform sliderAreaTransform;

	public GameObject tooltipRef;

	public GameObject objectSpawnParticles;

	public Image activeObjectIconHolder;

	public TextMeshProUGUI activeObjectNumLeft;

	private float offsetX = 165f;

	private float offsetY = -155f;

	private int elementsPerRow = 3;

	private float bounceDelayPerElement = 0.015f;

	private float initialOffset = 140f;

	private float finalRowOffset = 275f;

	private int activeBoxIndex;

	private List<PanelInventoryBox> activeBoxes = new List<PanelInventoryBox>();

	private InventoryItem currentlyPlacingItem;

	private string toyDropSound = "toybox_drop";

	private DogHome dogHomeRef;

	private PenFocus penFocusRef;

	private ObjectGrabber grabberRef;

	private GUIManagerPens mainGUIRef;

	private InventoryManager managerRef;

	private void OnDisable()
	{
		for (int num = activeBoxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(activeBoxes[num].gameObject);
		}
		activeBoxes.Clear();
	}

	public void RefreshBoxes(InventoryItem newItem, bool bouncesAllowed = true)
	{
		for (int i = 0; i < activeBoxes.Count; i++)
		{
			Object.Destroy(activeBoxes[i].gameObject);
		}
		activeBoxes.Clear();
		tooltipRef.SetActive(value: false);
		CreateBoxes(newItem, bouncesAllowed);
	}

	public void CreateBoxes(InventoryItem itemRefresh = null, bool bouncesAllowed = true)
	{
		guiRef.ShowMainUI();
		activeBoxIndex = 0;
		tooltipRef.SetActive(value: false);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		mainGUIRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		managerRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		int num = 0;
		Dictionary<InventoryItem, int> heldItemsOfType = managerRef.playerInventory.GetHeldItemsOfType(ItemType.TOY);
		List<InventoryItem> allNewItems = managerRef.playerInventory.GetAllNewItems();
		for (int i = 0; i < allNewItems.Count; i++)
		{
			if (heldItemsOfType.ContainsKey(allNewItems[i]))
			{
				PanelInventoryBox component = Object.Instantiate(boxRef).GetComponent<PanelInventoryBox>();
				component.SetAssociatedItem(allNewItems[i], heldItemsOfType[allNewItems[i]], num, tooltipRef, newObject: true);
				component.SetBoxesRef(this, updateAreaRef);
				PositionNewBox(component, num, bouncesAllowed, itemRefresh, allNewItems[i]);
				num++;
			}
		}
		foreach (InventoryItem key in heldItemsOfType.Keys)
		{
			if (!allNewItems.Contains(key))
			{
				PanelInventoryBox component2 = Object.Instantiate(boxRef).GetComponent<PanelInventoryBox>();
				component2.SetAssociatedItem(key, heldItemsOfType[key], num, tooltipRef);
				component2.SetBoxesRef(this, updateAreaRef);
				PositionNewBox(component2, num, bouncesAllowed, itemRefresh, key);
				num++;
			}
		}
		float num2 = (float)Mathf.Max(Mathf.CeilToInt((float)activeBoxes.Count / (float)elementsPerRow) - 1, 0) * (0f - offsetY) + finalRowOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num2);
		foodAreaTransform.anchoredPosition3D = new Vector3(foodAreaTransform.anchoredPosition3D.x, num2 / 2f - initialOffset, 0f);
		scrollRef.value = 1f;
	}

	private void PositionNewBox(PanelInventoryBox newBox, int index, bool bouncesAllowed, InventoryItem itemRefresh, InventoryItem item)
	{
		int num = activeBoxes.Count % elementsPerRow;
		int num2 = Mathf.FloorToInt(activeBoxes.Count / elementsPerRow);
		newBox.transform.SetParent(boxHolder);
		newBox.transform.localScale = Vector3.one;
		newBox.transform.localPosition = new Vector3(offsetX * (float)num, offsetY * (float)num2, 0f);
		activeBoxes.Add(newBox);
		if (bouncesAllowed)
		{
			if (itemRefresh == null)
			{
				newBox.RequestBounce(bounceDelayPerElement * (float)index, 0.35f, startInvisible: true);
			}
			else if (itemRefresh == item)
			{
				newBox.RequestBounce(0f, 0.5f);
			}
		}
	}

	public void OnBoxSelected(int index, bool fromBox)
	{
		if (!PauseController.IsPaused())
		{
			activeBoxes[activeBoxIndex].Deselect();
			activeBoxIndex = index;
			if (!fromBox)
			{
				activeBoxes[activeBoxIndex].OnBoxSelected();
			}
			if (penFocusRef.FollowCamActive())
			{
				penFocusRef.ClearFollowCam();
			}
			EnterPlacementMode(activeBoxes[activeBoxIndex].GetAssociatedItem());
		}
	}

	private void OnObjectPlaced(Vector3 placementPos, Quaternion rotation, GameObject objectToIgnore)
	{
		List<GameObject> toIgnoreDuringPlacement = new List<GameObject> { objectToIgnore };
		GameObject gameObject = dogHomeRef.TrySpawnItem(currentlyPlacingItem, placementPos, null, moveToGoodLocation: true, null, rotation, toIgnoreDuringPlacement);
		if (gameObject == null)
		{
			Debug.LogError("Something went wrong trying to remove an object from our inventory.");
			return;
		}
		Collider[] componentsInChildren = objectToIgnore.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Collider[] componentsInChildren2 = gameObject.GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				Physics.IgnoreCollision(collider, collider2);
			}
		}
		Object.Instantiate(objectSpawnParticles, gameObject.transform.position, Quaternion.identity);
		AudioController.Play(toyDropSound);
		managerRef.playerInventory.RemoveObjectFromInventory(currentlyPlacingItem);
		int numberOfItemHeld = managerRef.playerInventory.GetNumberOfItemHeld(currentlyPlacingItem);
		if (numberOfItemHeld <= 0)
		{
			ExitPlacementMode();
		}
		else
		{
			activeObjectNumLeft.text = numberOfItemHeld.ToString();
		}
	}

	private void EnterPlacementMode(InventoryItem itemToPlace)
	{
		if (!(Camera.main.GetComponent<PenFocus>().GetFocusedRoom() == null))
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER).SetPettingMode(val: false);
			currentlyPlacingItem = itemToPlace;
			grabberRef.HoldObjectForPlacement(currentlyPlacingItem, OnObjectPlaced, ExitPlacementMode);
			mainGUIRef.HideHUD();
			guiRef.ShowPlacementUI();
			activeObjectIconHolder.sprite = itemToPlace.icon;
			int numberOfItemHeld = managerRef.playerInventory.GetNumberOfItemHeld(currentlyPlacingItem);
			activeObjectNumLeft.text = numberOfItemHeld.ToString();
		}
	}

	public void ExitPlacementMode()
	{
		grabberRef.StopHoldingObjectForPlacement();
		guiRef.ShowMainUI();
		mainGUIRef.ShowHUD();
		RefreshBoxes(null, bouncesAllowed: false);
	}
}
