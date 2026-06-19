using System;

[Serializable]
public class SaveableInventoryItem
{
	public string itemPath;

	public int numHeld;

	public SaveableInventoryItem GetCopy()
	{
		return new SaveableInventoryItem
		{
			itemPath = itemPath,
			numHeld = numHeld
		};
	}
}
