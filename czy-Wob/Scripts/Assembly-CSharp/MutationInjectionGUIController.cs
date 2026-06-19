using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MutationInjectionGUIController : MonoBehaviour
{
	public GameObject injectionHolderBoxPrefab;

	public RawImage dogImage;

	public Camera dogRenderCam;

	public Transform dogTransform;

	public TextMeshProUGUI dogNameText;

	public Image activeInjectionImage;

	public TextMeshProUGUI activeInjectionName;

	public TextMeshProUGUI activeInjectionDescription;

	public GameObject noInjectionsText;

	public GameObject injectionDisplayObject;

	public GameObject activeDogDisplayObject;

	public GameObject baseWindow;

	public RectTransform sliderAreaTransform;

	public RectTransform injectionsListTransform;

	public Image injectionAppliedImage;

	public Animator injectionAppliedAnimator;

	public GameObject injectionAppliedHolder;

	private string injectionAppliedAnimationName = "InjectionAppliedAnimation";

	private SaveableDog associatedDog;

	private MutationInjectionBox currentlySelectedBox;

	private int elementsPerRow = 5;

	private float finalOffset = 10f;

	private float initialOffset = -5f;

	private float verticalOffset = 50f;

	private float horizontalOffset = 50f;

	private List<GameObject> allInjections = new List<GameObject>();

	private DogRegistration dogRegRef;

	private GUIManagerPens guiManagerRef;

	private PlayerInventory inventoryRef;

	private void Awake()
	{
		baseWindow.SetActive(value: true);
		injectionAppliedHolder.SetActive(value: false);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		guiManagerRef.DisableBG(LockReason.MUTATION_INJECTION_GUI);
		CreateBoxes();
	}

	public void SetAssociatedDog(SaveableDog dog)
	{
		associatedDog = dog;
		CreateDog();
	}

	private void CreateDog()
	{
		dogNameText.text = associatedDog.dogName;
		dogRegRef.RequestNewDog(dogTransform.position, dogTransform.rotation, associatedDog.dogGene, null, manualDog: false, dogProfile: associatedDog.dogProfile, callback: OnDogCreated, playerOwned: false);
	}

	private void OnDogCreated(GameObject dog)
	{
		dogRegRef.MakeDogSuitableForUIDisplay(dog);
		dog.transform.SetParent(dogTransform);
		dog.transform.localPosition = Vector3.zero;
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.MUTATION_INJECTION_GUI);
		Object.Destroy(base.gameObject);
	}

	public void OnInjectButtonPressed()
	{
		injectionAppliedHolder.SetActive(value: true);
		injectionAppliedAnimator.Play(injectionAppliedAnimationName, -1, 0f);
		injectionAppliedImage.sprite = currentlySelectedBox.GetContainedItem().icon;
		dogRegRef.UpdateSaveableDog(associatedDog);
		inventoryRef.RemoveObjectFromInventory(currentlySelectedBox.GetContainedItem());
		RefreshBoxes();
	}

	public void SelectBox(MutationInjectionBox newBox)
	{
		if (currentlySelectedBox != null)
		{
			currentlySelectedBox.OnDeselected();
		}
		newBox.OnSelected();
		currentlySelectedBox = newBox;
		UpdateItemDisplay();
	}

	private void RefreshBoxes()
	{
		for (int num = allInjections.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allInjections[num]);
		}
		allInjections.Clear();
		CreateBoxes();
	}

	private void CreateBoxes()
	{
		Dictionary<InventoryItem, int> heldItemsOfType = inventoryRef.GetHeldItemsOfType(ItemType.INJECTION);
		List<InventoryItem> list = new List<InventoryItem>();
		list.AddRange(heldItemsOfType.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = Object.Instantiate(injectionHolderBoxPrefab, injectionsListTransform);
			MutationInjectionBox component = gameObject.GetComponent<MutationInjectionBox>();
			component.SetControllerRef(this);
			component.SetContainedItem(list[i], heldItemsOfType[list[i]]);
			PositionNewBox(gameObject);
		}
		if (allInjections.Count == 0)
		{
			sliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			injectionsListTransform.anchoredPosition3D = new Vector3(injectionsListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
			noInjectionsText.SetActive(value: true);
			injectionDisplayObject.SetActive(value: false);
			activeDogDisplayObject.transform.localPosition = new Vector3(0f, activeDogDisplayObject.transform.localPosition.y, 0f);
		}
		else
		{
			noInjectionsText.SetActive(value: false);
			SelectBox(allInjections[0].GetComponent<MutationInjectionBox>());
		}
	}

	private void PositionNewBox(GameObject obj)
	{
		int num = allInjections.Count % elementsPerRow;
		int num2 = Mathf.FloorToInt(allInjections.Count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)(num2 + 1) * verticalOffset;
		float num4 = (float)num2 * verticalOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		injectionsListTransform.anchoredPosition3D = new Vector3(injectionsListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allInjections.Add(obj);
	}

	private void UpdateItemDisplay()
	{
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		activeInjectionImage.sprite = containedItem.icon;
		activeInjectionName.text = containedItem.itemNameLocalized;
		activeInjectionDescription.text = containedItem.itemDescriptionLocalized;
	}
}
