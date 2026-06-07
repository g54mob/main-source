using UnityEngine;

public class StoreUIProcessorInfo : MonoBehaviour
{
	[SerializeField]
	private UIList recipesList;

	private Processor selectedProcessor;

	public Processor SelectedProcessor
	{
		get
		{
			return selectedProcessor;
		}
		set
		{
			selectedProcessor = value;
			LoadData();
		}
	}

	private void LoadData()
	{
		recipesList.LoadList(selectedProcessor.Recipes);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
