using System.Collections.Generic;
using UnityEngine;

public class ItemDevTools : MonoBehaviour
{
	[SerializeField]
	private Transform _spawnItemsParent;

	[SerializeField]
	private ItemSpawnIcon _spawnIconPrefab;

	private int _spawnAmount = 1;

	private List<ItemSpawnIcon> _spawnItemIcons;

	private void Awake()
	{
		_spawnItemIcons = new List<ItemSpawnIcon>();
		ItemProperties[] itemProperties = GameManager.Settings.ItemSettings.ItemProperties;
		foreach (ItemProperties properties in itemProperties)
		{
			ItemSpawnIcon itemSpawnIcon = Object.Instantiate(_spawnIconPrefab, _spawnItemsParent);
			itemSpawnIcon.Initialize(properties);
			itemSpawnIcon.SpawnEvent.AddListener(SpawnItems);
			_spawnItemIcons.Add(itemSpawnIcon);
		}
	}

	private void OnDestroy()
	{
		foreach (ItemSpawnIcon spawnItemIcon in _spawnItemIcons)
		{
			spawnItemIcon.SpawnEvent.RemoveListener(SpawnItems);
		}
	}

	private void SpawnItems(ItemProperties properties)
	{
		if (_spawnAmount < 0)
		{
			for (int num = -_spawnAmount; num > 0; num--)
			{
				RemoveItem(properties);
			}
		}
		else
		{
			for (int i = 0; i < _spawnAmount; i++)
			{
				SpawnItem(properties);
			}
		}
	}

	private void SpawnItem(ItemProperties properties)
	{
		Storage storage = Selector.ReturnSelectedObjectComponent<Storage>(ObjectType.Buildable);
		if (storage != null)
		{
			Item item = new Item(properties);
			if (storage.Buildable.Inventory.FitsInInventory(item))
			{
				GameManager.ResourceManager.SpawnItemToInventory(storage.Buildable.Inventory, item);
			}
			else
			{
				storage = null;
				Debug.LogWarning($"Could not spawn {item.Properties.name} to the selected storage. Attempting to spawn to another storage...");
			}
		}
		if (storage == null)
		{
			Community.PlayerCommunity.SpawnItemToAvailableStorage(properties);
		}
	}

	private void RemoveItem(ItemProperties properties)
	{
		Storage storage = Selector.ReturnSelectedObjectComponent<Storage>(ObjectType.Buildable);
		if (storage == null)
		{
			foreach (Storage item in (IEnumerable<Storage>)Community.PlayerCommunity.Storages)
			{
				if (item.Inventory.ReturnContainsItem(properties))
				{
					storage = item;
					break;
				}
			}
		}
		if (storage != null)
		{
			storage.Buildable.Inventory.RemoveItem(properties, SubInventoryType.Storage);
		}
	}

	public void SetSpawnAmount(string amount)
	{
		if (!int.TryParse(amount, out _spawnAmount))
		{
			Debug.LogError($"Could not set spawn amount of {_spawnAmount.ToString()} as that is not an integer.");
		}
	}
}
