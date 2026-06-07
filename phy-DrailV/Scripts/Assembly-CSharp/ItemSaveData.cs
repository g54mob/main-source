using Newtonsoft.Json.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemSaveData : MonoBehaviour
{
	public delegate void ItemSaveDataLoadedDelegate(JObject data);

	public delegate JObject ItemSaveDataRequestedDelegate(JObject data);

	private JObject saveData;

	public event ItemSaveDataLoadedDelegate ItemSaveDataLoaded;

	public event ItemSaveDataLoadedDelegate AfterItemSaveDataLoaded;

	public event ItemSaveDataRequestedDelegate ItemSaveDataRequested;

	public event ItemSaveDataLoadedDelegate AfterContainerSaveDataLoaded;

	public void LoadItemData(JObject data)
	{
		saveData = data;
		if (saveData != null)
		{
			this.ItemSaveDataLoaded?.Invoke(saveData);
		}
	}

	public void PostLoadItemData()
	{
		if (saveData != null)
		{
			this.AfterItemSaveDataLoaded?.Invoke(saveData);
		}
	}

	public void PostContainerLoadData()
	{
		this.AfterContainerSaveDataLoaded?.Invoke(saveData);
	}

	public JObject SaveItemData()
	{
		if (saveData == null)
		{
			saveData = new JObject();
		}
		this.ItemSaveDataRequested?.Invoke(saveData);
		return saveData;
	}
}
