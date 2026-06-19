using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncubatorGUIController : MonoBehaviour
{
	public InventoryItem eggItem;

	public GameObject eggsHolderBoxPrefab;

	public CursorUpdateArea updateAreaRef;

	public GameObject inProgressText;

	public GameObject trashEggButton;

	public GameObject trashConfirmationPopup;

	public GameObject eggsListHolder;

	public GameObject eggsDisplayObject;

	public GameObject baseWindow;

	public RectTransform sliderAreaTransform;

	public RectTransform eggsListTransform;

	public GameObject loadingDogText;

	public Transform dogRotationTransform;

	public InchwormBounce dogRotationBouncer;

	public SaveableDogEgg defaultEgg;

	public Transform defaultEggHolder;

	public GameObject incubateButtonRef;

	private Incubator incubatorRef;

	private IncubatorBox currentlySelectedBox;

	private bool isLoadingDog;

	private bool needsDogRefresh;

	private GameObject currentlyRotatedDog;

	private string selectDogSound = "storage_selectDog";

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private int elementsPerRow = 3;

	private float finalOffset = 10f;

	private float initialOffset = -5f;

	private float verticalOffset = 50f;

	private float horizontalOffset = 50f;

	private List<GameObject> allEggs = new List<GameObject>();

	private bool GUIClosed;

	private DogRegistration dogRegRef;

	private GUIManagerPens guiManagerRef;

	private PlayerInventory inventoryRef;

	private void Awake()
	{
		baseWindow.SetActive(value: true);
		loadingDogText.SetActive(value: false);
		trashConfirmationPopup.SetActive(value: false);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		guiManagerRef.DisableBG(LockReason.INCUBATOR_GUI);
		guiManagerRef.RegisterNewPopup(LockReason.INCUBATOR_GUI, stomp: true, CloseGUI);
		CreateBoxes();
		inProgressText.SetActive(value: false);
		AudioController.Play(windowOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			if (trashConfirmationPopup.activeSelf)
			{
				OnCancelTrashEgg();
			}
			else
			{
				CloseGUI();
			}
		}
	}

	public void SetIncubationRef(Incubator newRef)
	{
		incubatorRef = newRef;
		if (incubatorRef.IsCurrentlyIncubatingEgg())
		{
			inProgressText.SetActive(value: true);
			eggsListHolder.SetActive(value: false);
			trashEggButton.SetActive(value: false);
			eggsDisplayObject.SetActive(value: false);
			incubateButtonRef.SetActive(value: false);
			defaultEggHolder.gameObject.SetActive(value: false);
		}
	}

	public void CloseGUI()
	{
		GUIClosed = true;
		guiManagerRef.EnableBG(LockReason.INCUBATOR_GUI);
		guiManagerRef.ClearPopupRegistration(LockReason.INCUBATOR_GUI);
		Object.Destroy(base.gameObject);
		AudioController.Play(windowCloseSound);
	}

	public void OnIncubateButtonPressed()
	{
		bool isDefaultEgg = true;
		SaveableDogEgg containedItem = currentlySelectedBox.GetContainedItem();
		if (!currentlySelectedBox.IsDefaultEgg())
		{
			isDefaultEgg = false;
			inventoryRef.RemoveEggFromInventory(containedItem);
		}
		RefreshBoxes();
		incubatorRef.PlaceEggInIncubator(containedItem, isDefaultEgg);
		CloseGUI();
	}

	public void SelectBox(IncubatorBox newBox)
	{
		if (!(currentlySelectedBox == newBox))
		{
			if (currentlyRotatedDog != null)
			{
				Object.Destroy(currentlyRotatedDog);
				currentlyRotatedDog = null;
			}
			if (currentlySelectedBox != null)
			{
				currentlySelectedBox.OnDeselected();
			}
			newBox.OnSelected();
			currentlySelectedBox = newBox;
			bool flag = !currentlySelectedBox.IsDefaultEgg();
			trashEggButton.transform.GetChild(0).GetComponent<CoreButtonUnityGUI>().interactable = flag;
			if (flag)
			{
				trashEggButton.GetComponent<Image>().color = Color.black;
			}
			else
			{
				trashEggButton.GetComponent<Image>().color = new Color(0.35f, 0.35f, 0.35f, 1f);
			}
			UpdateDisplay();
		}
	}

	public void OnTrashEggButtonPressed()
	{
		trashConfirmationPopup.SetActive(value: true);
	}

	public void OnConfirmTrashEgg()
	{
		SaveableDogEgg containedItem = currentlySelectedBox.GetContainedItem();
		if (containedItem != null)
		{
			inventoryRef.RemoveEggFromInventory(containedItem);
			RefreshBoxes();
		}
		trashConfirmationPopup.SetActive(value: false);
	}

	public void OnCancelTrashEgg()
	{
		trashConfirmationPopup.SetActive(value: false);
	}

	private void RefreshBoxes()
	{
		for (int num = allEggs.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allEggs[num]);
		}
		if (currentlyRotatedDog != null)
		{
			Object.Destroy(currentlyRotatedDog);
			currentlyRotatedDog = null;
		}
		allEggs.Clear();
		CreateBoxes();
	}

	private void CreateBoxes()
	{
		GameObject gameObject = Object.Instantiate(eggsHolderBoxPrefab, defaultEggHolder);
		IncubatorBox component = gameObject.GetComponent<IncubatorBox>();
		component.SetControllerRef(this, null);
		component.SetContainedItem(defaultEgg, 1, defaultEgg: true);
		PositionNewBox(gameObject, isDefault: true);
		List<SaveableDogEgg> heldEggs = inventoryRef.GetHeldEggs(fertilized: true);
		for (int i = 0; i < heldEggs.Count; i++)
		{
			GameObject gameObject2 = Object.Instantiate(eggsHolderBoxPrefab, eggsListTransform);
			IncubatorBox component2 = gameObject2.GetComponent<IncubatorBox>();
			component2.SetControllerRef(this, updateAreaRef);
			component2.SetContainedItem(heldEggs[i], 1);
			PositionNewBox(gameObject2);
		}
		eggsListHolder.SetActive(value: true);
		if (TutorialController.IsTutorialActive())
		{
			trashEggButton.SetActive(value: false);
		}
		else
		{
			trashEggButton.SetActive(value: true);
		}
		if (allEggs.Count > 1)
		{
			SelectBox(allEggs[1].GetComponent<IncubatorBox>());
		}
		else
		{
			SelectBox(allEggs[0].GetComponent<IncubatorBox>());
		}
	}

	private void PositionNewBox(GameObject obj, bool isDefault = false)
	{
		if (isDefault)
		{
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = Vector3.zero;
			allEggs.Add(obj);
			return;
		}
		int num = allEggs.Count - 1;
		int num2 = num % elementsPerRow;
		int num3 = Mathf.FloorToInt(num / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num2 + Vector3.down * verticalOffset * num3;
		float num4 = (float)(num3 + 1) * verticalOffset;
		float num5 = (float)num3 * verticalOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num4 + finalOffset);
		eggsListTransform.anchoredPosition3D = new Vector3(eggsListTransform.anchoredPosition3D.x, initialOffset + (num5 + finalOffset) / 2f, 0f);
		allEggs.Add(obj);
	}

	private void UpdateDisplay()
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		SaveableDogEgg containedItem = currentlySelectedBox.GetContainedItem();
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		if (containedItem.associatedGene != null)
		{
			dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, containedItem.associatedGene, null, manualDog: false, dogProfile: containedItem.dogProfile, callback: OnNewDogCreated, playerOwned: false);
			return;
		}
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, null, null, manualDog: false, dogProfile: containedItem.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: true);
	}

	private void OnNewDogCreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDog = false;
		if (needsDogRefresh || currentlySelectedBox == null)
		{
			Object.Destroy(dog);
			needsDogRefresh = false;
			if (currentlySelectedBox != null)
			{
				UpdateDisplay();
			}
			else
			{
				loadingDogText.SetActive(value: false);
			}
			return;
		}
		currentlyRotatedDog = dog;
		loadingDogText.SetActive(value: false);
		dogRotationBouncer.RequestBounce();
		dogRegRef.MakeDogSuitableForUIDisplay(dog);
		if (!incubatorRef.IsCurrentlyIncubatingEgg())
		{
			AudioController.Play(selectDogSound);
		}
		dog.transform.SetParent(dogRotationTransform, worldPositionStays: true);
	}
}
