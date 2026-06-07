using PajamaLlama;
using UnityEngine;

public class RecipePrefabVisual : RecipeVisual
{
	[SerializeField]
	private GameObject _startPrefab;

	[SerializeField]
	private GameObject _finishedPrefab;

	private GameObject _visual;

	public override void StartRecipe(float startProgress)
	{
		RepoolVisual();
		_visual = PrefabPool.GetInstance(_startPrefab, base.transform);
	}

	public override void FinishRecipe()
	{
		RepoolVisual();
		_visual = PrefabPool.GetInstance(_finishedPrefab, base.transform);
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
