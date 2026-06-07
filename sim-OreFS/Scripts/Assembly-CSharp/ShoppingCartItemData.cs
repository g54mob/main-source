using System;
using UnityEngine;

[Serializable]
public struct ShoppingCartItemData : IEquatable<ShoppingCartItemData>
{
	public int itemSOIndex;

	public int quantity;

	public bool IsValid
	{
		get
		{
			if (itemSOIndex >= 0)
			{
				return quantity > 0;
			}
			return false;
		}
	}

	public static bool IsTutorialFreeItem(T_BuildingItemSO itemSO)
	{
		if (itemSO == null)
		{
			return false;
		}
		if (TutorialManager.Instance == null || !TutorialManager.Instance.IsTutorialRunning)
		{
			return false;
		}
		if (!itemSO.isTutorialFree)
		{
			return false;
		}
		if (itemSO.TutorialSubStepTypesForFreeBuy == null || itemSO.TutorialSubStepTypesForFreeBuy.Length == 0)
		{
			return false;
		}
		TutorialSubStepType currentSubStep = TutorialManager.Instance.CurrentSubStep;
		TutorialSubStepType[] tutorialSubStepTypesForFreeBuy = itemSO.TutorialSubStepTypesForFreeBuy;
		foreach (TutorialSubStepType tutorialSubStepType in tutorialSubStepTypesForFreeBuy)
		{
			if (currentSubStep == tutorialSubStepType)
			{
				return true;
			}
		}
		return false;
	}

	public int GetTotalPrice(T_BuildingItemSO itemSO)
	{
		if (itemSO == null)
		{
			return 0;
		}
		if (IsTutorialFreeItem(itemSO))
		{
			Debug.Log("[ShoppingCartItemData] Item '" + itemSO.Name + "' is FREE in tutorial!");
			return 0;
		}
		return itemSO.Price * itemSO.packageQuantity * quantity;
	}

	public bool Equals(ShoppingCartItemData other)
	{
		if (itemSOIndex == other.itemSOIndex)
		{
			return quantity == other.quantity;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ShoppingCartItemData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(itemSOIndex, quantity);
	}

	public static bool operator ==(ShoppingCartItemData left, ShoppingCartItemData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ShoppingCartItemData left, ShoppingCartItemData right)
	{
		return !left.Equals(right);
	}
}
