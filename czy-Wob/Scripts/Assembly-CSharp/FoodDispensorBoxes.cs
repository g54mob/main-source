using System.Collections.Generic;
using UnityEngine;

public class FoodDispensorBoxes : MonoBehaviour
{
	public GameObject boxRef;

	public Transform boxHolder;

	public FoodDispensorGUIController guiRef;

	public CoreScrollbarUnityGUI scrollRef;

	public CursorUpdateArea updateAreaRef;

	public RectTransform foodAreaTransform;

	public RectTransform sliderAreaTransform;

	private float offsetX = 175f;

	private float offsetY = -225f;

	private int elementsPerRow = 4;

	private float initialOffset = 100f;

	private float finalRowOffset = 475f;

	private int activeBoxIndex;

	private List<FoodDispensorBox> activeBoxes = new List<FoodDispensorBox>();

	private InventoryManager managerRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		managerRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
	}

	private void OnDisable()
	{
		for (int num = activeBoxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(activeBoxes[num].gameObject);
		}
		activeBoxes.Clear();
	}

	public void OnBoxSelected(int index, bool fromBox)
	{
		if (index >= activeBoxes.Count)
		{
			Debug.LogError("Supplied index is invalid.");
			return;
		}
		activeBoxes[activeBoxIndex].Deselect();
		activeBoxIndex = index;
		if (!fromBox)
		{
			activeBoxes[activeBoxIndex].OnBoxSelected();
		}
		guiRef.UpdateItem(activeBoxes[activeBoxIndex].GetAssociateditem(), fromBox);
	}

	public void CreateBoxes()
	{
		int index = 0;
		InventoryItem currentlyDispensedFood = guiRef.GetCurrentlyDispensedFood();
		int num = 0;
		List<InventoryItem> allPossibleDispensedFood = guiRef.GetAllPossibleDispensedFood();
		for (int i = 0; i < allPossibleDispensedFood.Count; i++)
		{
			bool unlockStatusForFood = managerRef.GetUnlockStatusForFood(allPossibleDispensedFood[i]);
			FoodDispensorBox component = Object.Instantiate(boxRef).GetComponent<FoodDispensorBox>();
			component.SetAssociatedItem(allPossibleDispensedFood[i], num, unlockStatusForFood);
			component.SetBoxesRef(this, updateAreaRef);
			int num2 = activeBoxes.Count % elementsPerRow;
			int num3 = Mathf.FloorToInt(activeBoxes.Count / elementsPerRow);
			component.transform.SetParent(boxHolder);
			component.transform.localScale = Vector3.one;
			component.transform.localPosition = new Vector3(offsetX * (float)num2, offsetY * (float)num3, 0f);
			activeBoxes.Add(component);
			if (allPossibleDispensedFood[i] == currentlyDispensedFood)
			{
				index = num;
			}
			num++;
		}
		float num4 = (float)Mathf.Max(Mathf.CeilToInt((float)activeBoxes.Count / (float)elementsPerRow) - 2, 0) * (0f - offsetY) + finalRowOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num4);
		foodAreaTransform.anchoredPosition3D = new Vector3(foodAreaTransform.anchoredPosition3D.x, num4 / 2f - initialOffset, 0f);
		scrollRef.value = 1f;
		OnBoxSelected(index, fromBox: false);
	}
}
