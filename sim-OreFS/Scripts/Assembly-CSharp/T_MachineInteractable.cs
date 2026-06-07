using System.Collections.Generic;
using UnityEngine;

public class T_MachineInteractable : InteractableBase
{
	[Header("References")]
	[SerializeField]
	private T_Machine machine;

	private T_Equipments localEquipments;

	private T_Sack currentSack;

	private T_ItemSO currentTransferItem;

	private void Awake()
	{
		if (machine == null)
		{
			machine = GetComponent<T_Machine>();
		}
		if (machine == null)
		{
			Debug.LogError("T_MachineInteractable: T_Machine component'i bulunamadı!");
		}
	}

	private void Start()
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			localEquipments = GameManager.Instance.localEquipments;
		}
	}

	public override bool CanInteractPrimary()
	{
		if (localEquipments == null || localEquipments.pickupItem == null)
		{
			return false;
		}
		if (localEquipments.pickupItem.GetComponent<T_Sack>() == null)
		{
			return false;
		}
		return true;
	}

	public override void OnPrimaryInteracted()
	{
		if (machine == null)
		{
			return;
		}
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			localEquipments = GameManager.Instance.localEquipments;
		}
		if (localEquipments == null || localEquipments.pickupItem == null)
		{
			return;
		}
		T_Sack component = localEquipments.pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			return;
		}
		T_ItemSO firstValidItemFromSack = GetFirstValidItemFromSack(component);
		if (firstValidItemFromSack == null)
		{
			Debug.LogWarning("[MachineInteractable] Sack'te tarife uygun item yok!");
			return;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		string itemID = firstValidItemFromSack.GetItemID();
		int num = (storedItemCounts.ContainsKey(itemID) ? storedItemCounts[itemID] : 0);
		if (num <= 0)
		{
			Debug.LogWarning("[MachineInteractable] Sack'te bu item'dan yok!");
		}
		else
		{
			OpenPickerUI(component, firstValidItemFromSack, num);
		}
	}

	private T_ItemSO GetFirstValidItemFromSack(T_Sack sack)
	{
		if (sack == null || machine == null)
		{
			return null;
		}
		if (machine.AcceptedRecipes == null || machine.AcceptedRecipes.Count == 0)
		{
			return null;
		}
		foreach (KeyValuePair<string, int> storedItemCount in sack.GetStoredItemCounts())
		{
			string key = storedItemCount.Key;
			foreach (T_ItemSO acceptedRecipe in machine.AcceptedRecipes)
			{
				if (acceptedRecipe != null && IsItemValidForRecipe(key, acceptedRecipe) && ItemSOManager.Instance != null)
				{
					return ItemSOManager.Instance.GetItemSOById(key);
				}
			}
		}
		return null;
	}

	private bool IsItemValidForRecipe(string itemId, T_ItemSO recipe)
	{
		if (recipe == null || string.IsNullOrEmpty(itemId))
		{
			return false;
		}
		if (recipe.Type == PickupType.Resource)
		{
			if (recipe.ore != null && recipe.ore.GetItemID() == itemId)
			{
				return true;
			}
		}
		else if (recipe.Type == PickupType.Product && recipe.RecipeList != null)
		{
			foreach (T_ItemSO.RecipeIngredient recipe2 in recipe.RecipeList)
			{
				if (recipe2.Item != null && recipe2.Item.GetItemID() == itemId)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void OpenPickerUI(T_Sack sack, T_ItemSO item, int availableCount)
	{
		if (GameManager.Instance == null || GameManager.Instance.UImanager == null)
		{
			Debug.LogWarning("[MachineInteractable] UIManager bulunamadı!");
			return;
		}
		PickerUI pickerUI = GameManager.Instance.UImanager.pickerUI;
		if (pickerUI == null)
		{
			Debug.LogWarning("[MachineInteractable] PickerUI bulunamadı!");
			return;
		}
		currentSack = sack;
		currentTransferItem = item;
		pickerUI.OpenUI(item, availableCount, OnPickerTransferRequested);
		Debug.Log($"[MachineInteractable] PickerUI açıldı - Item: {item.Name}, Available: {availableCount}");
	}

	private void OnPickerTransferRequested(T_ItemSO item, int quantity)
	{
		if (machine == null || currentSack == null || item == null)
		{
			Debug.LogWarning("[MachineInteractable] Transfer için gerekli referanslar eksik!");
			return;
		}
		machine.TransferPartialItemsFromSack(currentSack.netId, item.GetItemID(), quantity);
		Debug.Log($"[MachineInteractable] Transfer isteği gönderildi - Item: {item.Name}, Quantity: {quantity}");
		currentSack = null;
		currentTransferItem = null;
	}

	public void OpenUIPanel()
	{
		if (!(machine == null) && GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.machineUI != null)
		{
			GameManager.Instance.UImanager.machineUI.OpenUIPanel(machine);
			if (TutorialManager.Instance != null)
			{
				TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.ProduceProduct, TutorialSubStepType.OpenMachinePanel);
			}
		}
	}

	public void CloseUIPanel()
	{
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.machineUI != null)
		{
			GameManager.Instance.UImanager.machineUI.CloseUIPanel();
		}
	}
}
