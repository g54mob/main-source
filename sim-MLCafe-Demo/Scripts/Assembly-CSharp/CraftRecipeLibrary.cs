using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Craft Recipe Library", menuName = "Libraries/Craft Recipe Library", order = 1)]
public class CraftRecipeLibrary : ScriptableObject
{
	public List<CraftRecipe> craftRecipes = new List<CraftRecipe>();

	public CraftRecipe GetRecipe(int id)
	{
		return craftRecipes[id];
	}

	public CraftRecipe GetRecipeByName(string name)
	{
		CraftRecipe result = null;
		for (int i = 0; i < craftRecipes.Count; i++)
		{
			if (InventorySystem.GetItemLibrary().itemInfos[craftRecipes[i].outputItem.id].name == name)
			{
				result = craftRecipes[i];
				break;
			}
		}
		return result;
	}
}
