using System;
using System.Collections.Generic;
using UnityEngine;

public class QueuedRecipe
{
	public enum Stage
	{
		WaitingToReserveItems = 0,
		WaitingToImport = 1,
		WaitingToProduce = 2,
		Producing = 3,
		WaitingToExportItems = 4
	}

	private static Stack<QueuedRecipe> _pool = new Stack<QueuedRecipe>(64);

	public Producer.Recipe Recipe { get; private set; }

	public List<Item> RecipeItems { get; set; }

	public float Progress { get; set; }

	public float NormalizedProgress
	{
		get
		{
			if (ProductionTime != 0f)
			{
				return Mathf.Clamp01(Progress / ProductionTime);
			}
			return 0f;
		}
	}

	public Stage RecipeStage { get; set; }

	public IReadOnlyList<CountedItemProperty> ProducedItems { get; private set; }

	public float ProductionTime { get; private set; }

	public float Pollution { get; private set; }

	public bool RequiresPerson { get; private set; }

	public Activity Activity { get; private set; }

	public DrifterAttributes.AttributeType Attribute { get; private set; }

	private QueuedRecipe()
	{
	}

	public static QueuedRecipe Get(Producer.Recipe recipe)
	{
		QueuedRecipe queuedRecipe = Get();
		queuedRecipe.Initialize(recipe);
		return queuedRecipe;
	}

	public static QueuedRecipe Get(int index, List<Producer.Recipe> recipes)
	{
		if (recipes.TryGetValue(index, out var value))
		{
			return Get(value);
		}
		throw new IndexOutOfRangeException();
	}

	public static bool TryGet(QueuedRecipePersistentData data, List<Producer.Recipe> recipes, out QueuedRecipe instance)
	{
		if (data.RecipeIndex < 0 || recipes.Count <= data.RecipeIndex)
		{
			instance = null;
			return false;
		}
		instance = Get();
		instance.Initialize(recipes[data.RecipeIndex]);
		instance.RecipeItems = data.ReturnItems();
		instance.RecipeStage = data.RecipeStage;
		instance.Progress = data.Progress;
		return true;
	}

	public static QueuedRecipe Get()
	{
		_ = _pool.Count;
		if (_pool.TryPop(out var result))
		{
			result.Reset();
			return result;
		}
		return new QueuedRecipe();
	}

	public void Release()
	{
		Reset();
		if (_pool.Contains(this))
		{
			Debug.LogError("You are trying to release a QueuedRecipe that is already in the QueuedRecipe Pool!");
		}
		else
		{
			_pool.Push(this);
		}
	}

	public void Initialize(Producer.Recipe recipe)
	{
		Recipe = recipe;
		ProducedItems = recipe.Properties.ProducedItems;
		ProductionTime = recipe.Properties.ProductionTime;
		Pollution = recipe.Properties.Pollution;
		RequiresPerson = recipe.Properties.RequiresPerson;
		Activity = recipe.Properties.Activity;
		Attribute = recipe.Properties.Attribute;
	}

	public void Produce(float addedProgress)
	{
		Progress += addedProgress;
	}

	public void Finish()
	{
		if (!RecipeItems.IsNullOrEmpty())
		{
			foreach (Item recipeItem in RecipeItems)
			{
				if (recipeItem.TakeFromInventory())
				{
					ItemEvent.Dispatch(GameEventType.ProducerItemConsumed, recipeItem);
				}
			}
		}
		RecipeItems = Recipe.Properties.ReturnProducedItems();
		foreach (Item recipeItem2 in RecipeItems)
		{
			ItemEvent.Dispatch(Recipe.Properties.ReturnFinishedGameEventType(), recipeItem2);
		}
		RecipeStage = Stage.WaitingToExportItems;
	}

	public void Reset(int recipeIndex, List<Producer.Recipe> recipes, bool resetRecipeState = false)
	{
		Reset();
		Initialize(recipes[recipeIndex]);
		if (resetRecipeState)
		{
			RecipeStage = Recipe.Properties.ResetToStage;
		}
	}

	public void Reset()
	{
		Recipe = null;
		ProducedItems = null;
		ProductionTime = 0f;
		Pollution = 0f;
		RequiresPerson = false;
		Activity = Activity.None;
		Attribute = DrifterAttributes.AttributeType.None;
		RecipeStage = Stage.WaitingToReserveItems;
		Progress = 0f;
		RecipeItems?.Clear();
	}

	public bool AreItemsInInventory(Inventory inventory, SubInventoryType subInventory)
	{
		if (RecipeStage == Stage.WaitingToReserveItems)
		{
			return false;
		}
		foreach (Item recipeItem in RecipeItems)
		{
			if (recipeItem.Inventory != inventory || recipeItem.SubInventory != subInventory)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsSalvagable()
	{
		Stage recipeStage = RecipeStage;
		if (recipeStage == Stage.WaitingToImport || (uint)(recipeStage - 3) <= 1u)
		{
			return false;
		}
		return true;
	}

	public int ReturnProducedItemCount()
	{
		int num = 0;
		if (Recipe != null)
		{
			int count = Recipe.ProducedItems.Count;
			while (0 < count--)
			{
				num += Recipe.ProducedItems[count].Amount;
			}
		}
		return num;
	}

	public ItemProperties ReturnFirstRequiredItemProperties()
	{
		if (Recipe == null || !(Recipe.Properties != null))
		{
			return null;
		}
		return Recipe.Properties.ReturnFirstRequiredItemProperties();
	}

	public ItemProperties ReturnFirstProducedItemProperties()
	{
		if (Recipe == null || !(Recipe.Properties != null))
		{
			return null;
		}
		return Recipe.Properties.ReturnFirstProducedItemProperties();
	}
}
