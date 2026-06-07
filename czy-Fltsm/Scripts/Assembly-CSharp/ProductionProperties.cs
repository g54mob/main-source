using System;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Production Properties")]
public class ProductionProperties : ScriptableObject
{
	[Header("General")]
	[Tooltip("Type of this producer.")]
	public Producer.Type Type;

	[ConditionalEnumHide("Type", 0, false, HideInInspector = true)]
	[Tooltip("Project for this production.")]
	public ProjectProperties ProductionProject;

	[ConditionalEnumHide("Type", 0, false, HideInInspector = true)]
	[Tooltip("Project for this production.")]
	public int ExportCapacity = 10;

	[Tooltip("Amount of slots the producer has.")]
	[ConditionalEnumHide("Type", 1, false, HideInInspector = true)]
	public int SlotAmount = 6;

	[Header("Recipes")]
	[Tooltip("Automatically queue up the first recipe from the list below.")]
	public bool AutomaticallyStart;

	[Tooltip("Available recipes for this production.")]
	public List<ProductionRecipeProperties> Recipes = new List<ProductionRecipeProperties>();

	[Tooltip("Cost of the recipe per second.")]
	public float EnergyCost;

	[Header("FMOD")]
	public EventReference FMODEventReference_Production;

	public EventReference FMODEventReference_FarmItemCompleted;

	[NonSerialized]
	private List<ItemProperties> _allRecipeIngredients;

	public bool IsItemRecipeIngredient(Item item)
	{
		if (_allRecipeIngredients == null)
		{
			_allRecipeIngredients = ReturnAllRecipeIngredients();
		}
		return _allRecipeIngredients.Contains(item.Properties);
	}

	private List<ItemProperties> ReturnAllRecipeIngredients()
	{
		List<ItemProperties> list = new List<ItemProperties>();
		foreach (ProductionRecipeProperties recipe in Recipes)
		{
			foreach (CountedItemProperty requiredItem in recipe.RequiredItems)
			{
				list.AddUnique(requiredItem.ItemProperties);
			}
		}
		return list;
	}
}
