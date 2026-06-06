using System;
using System.Collections.Generic;

[Serializable]
public class QueuedRecipePersistentData
{
	public int RecipeIndex = -1;

	public QueuedRecipe.Stage RecipeStage;

	public float Progress;

	public bool HasReservedFuel;

	public int[] ItemIndices;

	public QueuedRecipePersistentData(QueuedRecipe queuedRecipe)
	{
		RecipeIndex = ((queuedRecipe.Recipe != null) ? queuedRecipe.Recipe.Index : (-1));
		RecipeStage = queuedRecipe.RecipeStage;
		Progress = queuedRecipe.Progress;
		ItemIndices = ((queuedRecipe.RecipeItems == null) ? null : ReturnItemIndices(queuedRecipe.RecipeItems));
	}

	public List<Item> ReturnItems()
	{
		List<Item> list = new List<Item>();
		if (ItemIndices.IsNullOrEmpty())
		{
			return list;
		}
		for (int i = 0; i < ItemIndices.Length; i++)
		{
			if (PersistentReference<Item>.TryReturnReference(ItemIndices[i], out var reference))
			{
				list.Add(reference);
			}
		}
		return list;
	}

	private int[] ReturnItemIndices(List<Item> items)
	{
		int[] array = new int[items.Count];
		for (int i = 0; i < items.Count; i++)
		{
			array[i] = items[i].PersistentIndex;
		}
		return array;
	}
}
