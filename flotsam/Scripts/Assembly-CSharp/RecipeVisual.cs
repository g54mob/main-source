using PajamaLlama;
using UnityEngine;

public abstract class RecipeVisual : MonoBehaviour
{
	protected ProductionRecipeProperties _recipeProperties;

	public virtual void Initialize(QueuedRecipe queuedRecipe)
	{
		_recipeProperties = queuedRecipe.Recipe.Properties;
	}

	public abstract void StartRecipe(float startProgress);

	public virtual void UpdateRecipe(float progress)
	{
	}

	public abstract void FinishRecipe();

	public virtual void Repool()
	{
		PrefabPool.Repool(this);
	}
}
