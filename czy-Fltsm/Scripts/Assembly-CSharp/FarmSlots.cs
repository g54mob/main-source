using System;
using PajamaLlama;

[Serializable]
public class FarmSlots : Slots
{
	private RecipeVisual[] _farmVisualSlots;

	public void Initialize()
	{
		_farmVisualSlots = new RecipeVisual[TransformData.Length];
	}

	public void Display(int farmQueueIndex, QueuedRecipe queuedRecipe)
	{
		if (TryGetRecipeVisual(farmQueueIndex, out var recipeVisual))
		{
			if ((bool)recipeVisual)
			{
				PrefabPool.Repool(recipeVisual);
			}
			recipeVisual = PrefabPool.GetInstance(FlotsamGame.Random(queuedRecipe.Recipe.Properties.RecipeVisualPrefabs));
			recipeVisual.Initialize(queuedRecipe);
			if (queuedRecipe.Progress < queuedRecipe.ProductionTime)
			{
				recipeVisual.StartRecipe(queuedRecipe.Progress);
			}
			else
			{
				recipeVisual.FinishRecipe();
			}
			_farmVisualSlots[farmQueueIndex] = recipeVisual;
			recipeVisual.transform.SetParent(Parent);
			TransformData[farmQueueIndex].Apply(recipeVisual.transform);
		}
	}

	public void Update(int farmQueueIndex, float progress)
	{
		if (TryGetRecipeVisual(farmQueueIndex, out var recipeVisual) && (bool)recipeVisual)
		{
			recipeVisual.UpdateRecipe(progress);
		}
	}

	public void Finish(int farmQueueIndex)
	{
		if (TryGetRecipeVisual(farmQueueIndex, out var recipeVisual) && (bool)recipeVisual)
		{
			recipeVisual.FinishRecipe();
		}
	}

	public void Remove(int farmQueueIndex)
	{
		if (TryGetRecipeVisual(farmQueueIndex, out var recipeVisual))
		{
			if ((bool)recipeVisual)
			{
				recipeVisual.Repool();
			}
			_farmVisualSlots[farmQueueIndex] = null;
		}
	}

	private bool TryGetRecipeVisual(int index, out RecipeVisual recipeVisual)
	{
		if (index < 0 || index >= _farmVisualSlots.Length)
		{
			recipeVisual = null;
			return false;
		}
		recipeVisual = _farmVisualSlots[index];
		return true;
	}
}
