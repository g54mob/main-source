using System;
using System.Collections.Generic;

[Serializable]
public class CraftRecipe
{
	public enum RecipeLocation
	{
		Character = 0,
		Workbench = 1,
		WoodAssembler = 2
	}

	public string name;

	public RecipeLocation location;

	public List<Item> inputItems = new List<Item>();

	public Item outputItem;

	public CraftRecipe()
	{
		name = "New Recipe";
	}
}
