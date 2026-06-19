using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodDispensor : ClickableObject
{
	public GameObject guiPrefab;

	public InventoryItem currentFood;

	public AutoFeeder feederRef;

	public Image currentFoodSprite;

	public List<InventoryItem> dispensedFood;

	private void Awake()
	{
		SetCurrentDispensedFood(currentFood);
	}

	public void SaveObject(SaveablePlacedObject data)
	{
		InventoryManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		data.stringList.Add(globalComponent.GetPathForItem(currentFood));
	}

	public void LoadObject(SaveablePlacedObject data)
	{
		if (data.stringList.Count >= 1)
		{
			InventoryManager globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
			SetCurrentDispensedFood(globalComponent.GetItemForPath(data.stringList[0]));
		}
	}

	protected override void OnClickInternal()
	{
		base.OnClickInternal();
		Object.Instantiate(guiPrefab).GetComponent<FoodDispensorGUIController>().SetDispensorRef(this);
	}

	public void SetCurrentDispensedFood(InventoryItem newFood)
	{
		currentFood = newFood;
		feederRef.foodType = newFood;
		currentFoodSprite.sprite = newFood.icon;
	}

	public void OnDispenseButtonPressed()
	{
		feederRef.DispenseFood();
	}
}
