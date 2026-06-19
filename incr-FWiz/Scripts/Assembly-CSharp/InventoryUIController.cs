using System.Collections.Generic;
using OUSystems.Basics.DataStructures;
using TMPro;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
	private PlayerInventory _inventory;

	[SerializeField]
	private InventoryUIItemStack _uiItemStackPrefab;

	private List<InventoryUIItemStack> _uiStacks;

	[SerializeField]
	private List<TextMeshProUGUI> _capacityText;

	[SerializeField]
	public InventoryUICapacityAnimator _capacityAnimator;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void EvaluateCapacity(ValueUpdateData<int> _)
	{
	}

	public void EvaluateCapacity()
	{
	}

	public void Hide()
	{
	}

	public void Show()
	{
	}

	public void AddStack(ItemStack stack)
	{
	}

	public void OnKillStack(ItemStack stack)
	{
	}

	public void RotateChildren(int amount)
	{
	}

	public void OnInventoryTooFull()
	{
	}
}
