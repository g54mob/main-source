using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodDispensorGUIController : MonoBehaviour
{
	public FoodDispensorBoxes boxesRef;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI descriptionText;

	public TextScaleInOnLoad nameScale;

	public Image icon;

	public InchwormBounce iconBounceRef;

	public Tooltip tooltipRef;

	public List<DispenserFloraDisplay> floraInfo;

	private bool hasInitializedFood;

	private FoodDispensor dispensorRef;

	private string menuOpenSound = "dispenser_menu_open";

	private string foodSelectSound = "dispenser_menu_food_select";

	private GUIManagerPens guiManagerRef;

	private FloraManager floraManagerRef;

	private InventoryManager inventoryRef;

	private DogGutsManager dogGutsManagerRef;

	private void Initialize()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		floraManagerRef = registrationScript.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		dogGutsManagerRef = registrationScript.GetGlobalComponent<DogGutsManager>(GlobalObject.DOG_GUT_MANAGER);
		InitializeGUI();
		AudioController.Play(menuOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			CloseGUI();
		}
	}

	public void SetDispensorRef(FoodDispensor newRef)
	{
		dispensorRef = newRef;
		Initialize();
	}

	private void InitializeGUI()
	{
		guiManagerRef.DisableBG(LockReason.FOOD_DISPENSOR);
		guiManagerRef.RegisterNewPopup(LockReason.FOOD_DISPENSOR, stomp: true, CloseGUI);
		boxesRef.CreateBoxes();
	}

	private void OnBoxesLoaded()
	{
	}

	public void UpdateItem(InventoryItem newItem, bool playSounds)
	{
		if (!(dispensorRef.currentFood == newItem) || !hasInitializedFood)
		{
			dispensorRef.SetCurrentDispensedFood(newItem);
			nameText.text = newItem.itemNameLocalized;
			descriptionText.text = newItem.itemDescriptionLocalized;
			nameScale.RequestScaleIn();
			icon.sprite = newItem.icon;
			iconBounceRef.RequestBounce();
			hasInitializedFood = true;
			UpdateFloraDisplay(newItem);
			if (playSounds)
			{
				AudioController.Play(foodSelectSound);
			}
		}
	}

	public InventoryItem GetCurrentlyDispensedFood()
	{
		return dispensorRef.currentFood;
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.FOOD_DISPENSOR);
		guiManagerRef.ClearPopupRegistration(LockReason.FOOD_DISPENSOR);
		Object.Destroy(base.gameObject);
	}

	public List<InventoryItem> GetAllPossibleDispensedFood()
	{
		return dispensorRef.dispensedFood;
	}

	public void OnFloraHoverStart(GutFloraResource floraRef, bool unlocked)
	{
		tooltipRef.SetItem(floraRef, unlocked);
		tooltipRef.gameObject.SetActive(value: true);
	}

	public void OnFloraHover()
	{
		tooltipRef.HoverBehavior();
	}

	public void OnFloraHoverStop()
	{
		tooltipRef.gameObject.SetActive(value: false);
	}

	private void UpdateFloraDisplay(InventoryItem newItem)
	{
		Eatable component = newItem.itemPrefab.GetComponent<Eatable>();
		int count = component.gutFloraTypes.Count;
		if (count > floraInfo.Count)
		{
			Debug.LogError("Hoisted by my own petard.");
		}
		for (int i = 0; i < floraInfo.Count; i++)
		{
			if (i < count)
			{
				string pathForFlora = dogGutsManagerRef.GetPathForFlora(component.gutFloraTypes[i]);
				bool discovered = floraManagerRef.GetUnlockInfoForFloraPath(pathForFlora).foodListDiscoveries.Contains(inventoryRef.GetPathForItem(newItem));
				floraInfo[i].ActivateDisplay(component.gutFloraTypes[i], discovered);
			}
			else
			{
				floraInfo[i].DeactivateDisplay();
			}
		}
	}
}
