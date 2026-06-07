using UnityEngine;

[CreateAssetMenu(menuName = "Tower Factory/Recipe", order = 2)]
public class Recipe : ScriptableObject
{
	[SerializeField]
	private string recipeId = "";

	[SerializeField]
	private Cost[] input;

	[SerializeField]
	private Cost output;

	[SerializeField]
	private float processingTime = 1f;

	public string RecipeId => recipeId;

	public Cost[] Input
	{
		get
		{
			return input;
		}
		set
		{
			input = value;
		}
	}

	public Cost Output => output;

	public float ProcessingTime
	{
		get
		{
			return processingTime;
		}
		set
		{
			processingTime = value;
		}
	}

	public bool HasAllRecipeElements(Storage_ResourceData storage)
	{
		for (int i = 0; i < Input.Length; i++)
		{
			if (storage.GetStoredObjectAmount(Input[i].Resource.Id) < Input[i].Amount)
			{
				return false;
			}
		}
		return true;
	}

	public int GetResourceAmountById(string resourceID)
	{
		Cost[] array = Input;
		foreach (Cost cost in array)
		{
			if (cost.Resource.Id == resourceID)
			{
				return cost.Amount;
			}
		}
		return 0;
	}
}
