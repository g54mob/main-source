using UnityEngine;

[CreateAssetMenu(fileName = "BuildableObject", menuName = "Build/Object", order = 1)]
public class BuildableObject : ScriptableObject
{
	public ulong ID;

	public Vector3 footprint;

	public Vector3 centerOffset;

	public bool useCustomGridSize;

	public Vector3Int customGridSize = Vector3Int.zero;

	public TextAsset nameAndDescription;

	public int price;

	public BuildCategoriesPane.BuildCategory buildCategory;

	public Sprite icon;

	public GameObject prefabObject;

	public GameObject previewObject;

	private string objectName;

	private string description;

	private string formattedPrice;

	public void Initialize()
	{
		UpdateFormattedPrice();
		UpdateNameAndDescription();
	}

	public string GetName()
	{
		return objectName;
	}

	public string GetDescription()
	{
		return description;
	}

	public string GetFormattedPrice()
	{
		return formattedPrice;
	}

	private void UpdateFormattedPrice()
	{
		formattedPrice = "$" + price;
	}

	private void UpdateNameAndDescription()
	{
		string[] array = nameAndDescription.text.Split('\n');
		objectName = array[0];
		description = array[1];
	}
}
