using PajamaLlama;
using UnityEngine;

public class RecipeStorageVisual : RecipeVisual
{
	private GameObject _visual;

	public override void StartRecipe(float startProgress)
	{
		Debug.Log("RecipeStorageVisual.StartRecipe");
		RepoolVisual();
		_visual = PrefabPool.GetInstance(_recipeProperties.RequiredItems[0].ItemProperties.StorageVisualPrefab, base.transform).gameObject;
	}

	public override void FinishRecipe()
	{
		Debug.Log("RecipeStorageVisual.FinishRecipe");
		RepoolVisual();
		_visual = PrefabPool.GetInstance(_recipeProperties.ProducedItems[0].ItemProperties.StorageVisualPrefab, base.transform).gameObject;
	}

	public override void Repool()
	{
		RepoolVisual();
		base.Repool();
	}

	private void RepoolVisual()
	{
		if ((bool)_visual)
		{
			PrefabPool.Repool(_visual);
			_visual = null;
		}
	}
}
