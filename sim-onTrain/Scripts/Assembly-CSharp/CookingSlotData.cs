using System;

[Serializable]
public class CookingSlotData
{
	public string itemName;

	public bool isPlaced;

	public float cookingProgress;

	public bool isCooked;

	public CookingSlotData()
	{
		itemName = "";
		isPlaced = false;
		cookingProgress = 0f;
		isCooked = false;
	}
}
