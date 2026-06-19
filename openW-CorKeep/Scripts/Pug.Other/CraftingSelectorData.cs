using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CraftingSelectorData : MonoBehaviour
{
	public struct RecipeSlot
	{
		public int Index;

		public ObjectData ObjectData;
	}

	[FormerlySerializedAs("allRecipes")]
	public List<ObjectData> allObjects = new List<ObjectData>();

	public List<CraftingSelectorFilter> filters = new List<CraftingSelectorFilter>();

	private List<RecipeSlot> _filteredObjects = new List<RecipeSlot>();

	public List<RecipeSlot> CurrentObjects => _filteredObjects;

	public event Action OnRecipesUpdate;

	private void Start()
	{
		UpdateList();
	}

	public void UpdateList()
	{
		_filteredObjects.Clear();
		for (int i = 0; i < allObjects.Count; i++)
		{
			_filteredObjects.Add(new RecipeSlot
			{
				Index = i,
				ObjectData = allObjects[i]
			});
		}
		foreach (CraftingSelectorFilter filter in filters)
		{
			filter.FilterObjects(_filteredObjects);
		}
		this.OnRecipesUpdate?.Invoke();
	}
}
