using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CraftingSelectorFilter : MonoBehaviour
{
	public CraftingSelectorData craftingSelectorData;

	public Action OnFilterUpdated;

	protected virtual void OnEnable()
	{
		craftingSelectorData.filters.Add(this);
	}

	protected void OnDisable()
	{
		craftingSelectorData.filters.Remove(this);
	}

	public abstract void FilterObjects(List<CraftingSelectorData.RecipeSlot> recipeSlots);

	protected void UpdateFilter()
	{
		craftingSelectorData.UpdateList();
		OnFilterUpdated?.Invoke();
	}
}
