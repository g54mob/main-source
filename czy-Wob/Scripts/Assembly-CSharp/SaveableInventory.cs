using System;
using System.Collections.Generic;

[Serializable]
public class SaveableInventory
{
	public List<SaveableDogEgg> heldEggs = new List<SaveableDogEgg>();

	public List<SaveableDogCore> heldDogCores = new List<SaveableDogCore>();

	public List<SaveableInventoryItem> newItems = new List<SaveableInventoryItem>();

	public List<SaveableInventoryItem> heldItems = new List<SaveableInventoryItem>();

	public SerializableDictionary<string, bool> foodUnlockStatus;

	public SaveableInventory GetCopy()
	{
		SaveableInventory saveableInventory = new SaveableInventory();
		for (int i = 0; i < heldEggs.Count; i++)
		{
			if (heldEggs[i] != null)
			{
				saveableInventory.heldEggs.Add(heldEggs[i].GetCopy());
			}
		}
		for (int j = 0; j < heldDogCores.Count; j++)
		{
			if (heldDogCores[j] != null)
			{
				saveableInventory.heldDogCores.Add(heldDogCores[j].GetCopy());
			}
		}
		if (newItems != null)
		{
			for (int k = 0; k < newItems.Count; k++)
			{
				if (newItems[k] != null)
				{
					saveableInventory.newItems.Add(newItems[k].GetCopy());
				}
			}
		}
		for (int l = 0; l < heldItems.Count; l++)
		{
			if (heldItems[l] != null)
			{
				saveableInventory.heldItems.Add(heldItems[l].GetCopy());
			}
		}
		Dictionary<string, bool> dict = new Dictionary<string, bool>();
		foodUnlockStatus.Load(dict);
		saveableInventory.foodUnlockStatus = new SerializableDictionary<string, bool>(dict);
		return saveableInventory;
	}
}
