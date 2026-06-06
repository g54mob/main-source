using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlots : Slots
{
	[SerializeField]
	private bool _canGenerateSlots;

	[SerializeField]
	[ConditionalHide("_canGenerateSlots", true)]
	private int _topLayerVisualAmount = 1;

	private List<StorageVisual> _activeVisuals = new List<StorageVisual>();

	private Inventory _inventory;

	private SubInventoryType _inventoryType;

	private OutlineRendererComponent _outlineRenderer;

	private static Dictionary<ItemProperties, Queue<StorageVisual>> _cachedVisuals;

	private static Transform _cachedVisualParent;

	public void Initialize(Inventory inventory, SubInventoryType inventoryType, OutlineRendererComponent outlineRenderer)
	{
		if (!(Parent == null))
		{
			_inventory = inventory;
			_inventoryType = inventoryType;
			_inventory.InventoryUpdatedEvent.AddListener(UpdateSlot);
			_outlineRenderer = outlineRenderer;
			if (_canGenerateSlots)
			{
				GenerateSlots();
			}
			GameEventDispatcher.AddListener(GameEventType.DevTools_UpdateResourceVisuals, DevTools_UpdateResourceVisuals);
		}
	}

	public void Remove()
	{
		if (!(Parent == null) && !(_inventory == null))
		{
			_inventory.InventoryUpdatedEvent.RemoveListener(UpdateSlot);
			GameEventDispatcher.RemoveListener(GameEventType.DevTools_UpdateResourceVisuals, DevTools_UpdateResourceVisuals);
		}
	}

	private void GenerateSlots()
	{
		int num = 0;
		int num2 = _inventory.ReturnCapacity(_inventoryType);
		if (num2 > TransformData.Length && TransformData.Length != 0)
		{
			_topLayerVisualAmount = Mathf.Clamp(_topLayerVisualAmount, 1, TransformData.Length);
			num = Mathf.CeilToInt((float)(num2 - TransformData.Length) / (float)_topLayerVisualAmount);
			AddGeneratedSlotTransforms(num);
		}
	}

	private void AddGeneratedSlotTransforms(int levelsToAdd)
	{
		for (int i = 0; i < levelsToAdd; i++)
		{
			Array.Resize(ref TransformData, TransformData.Length + _topLayerVisualAmount);
			for (int j = 0; j < _topLayerVisualAmount; j++)
			{
				TransformData transformData = TransformData[TransformData.Length - 1 - _topLayerVisualAmount - j];
				TransformData[TransformData.Length - 1 - j] = new TransformData(transformData.Position, transformData.Rotation, transformData.Scale);
				TransformData[TransformData.Length - 1 - j].Position.y += 0.72f;
				TransformData[TransformData.Length - 1 - j].Rotation.y += UnityEngine.Random.Range(-180, 180);
			}
		}
	}

	public void UpdateSlot()
	{
		if (GeneralDevTools.ResourceVisualsDisabled)
		{
			return;
		}
		List<Item> list = _inventory.ReturnAllItems(_inventoryType);
		foreach (StorageVisual activeVisual in _activeVisuals)
		{
			_outlineRenderer.UpdateStorageVisual(activeVisual);
			activeVisual.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < list.Count; i++)
		{
			Item item = list[i];
			if (i >= TransformData.Length)
			{
				break;
			}
			StorageVisual storageVisual = ReturnVisual(item.Properties);
			storageVisual.gameObject.SetActive(value: true);
			_outlineRenderer.UpdateStorageVisual(storageVisual, addToConstructionOutline: true);
			storageVisual.transform.SetParent(Parent);
			TransformData[i].Apply(storageVisual.transform);
		}
		for (int num = _activeVisuals.Count - 1; num >= 0; num--)
		{
			StorageVisual storageVisual = _activeVisuals[num];
			if (!storageVisual.gameObject.activeSelf)
			{
				CacheVisual(storageVisual);
				_activeVisuals.RemoveAt(num);
			}
		}
	}

	public static void CacheVisual(StorageVisual visual)
	{
		if (_cachedVisuals == null)
		{
			_cachedVisuals = new Dictionary<ItemProperties, Queue<StorageVisual>>();
		}
		if (!_cachedVisuals.TryGetValue(visual.ItemProperties, out var value))
		{
			value = new Queue<StorageVisual>();
			_cachedVisuals.Add(visual.ItemProperties, value);
		}
		if (_cachedVisualParent == null)
		{
			_cachedVisualParent = new GameObject("CachedInventorySlotsParent").transform;
		}
		visual.transform.SetParent(_cachedVisualParent);
		value.Enqueue(visual);
	}

	public static void ClearCachedVisuals()
	{
		if (_cachedVisuals != null)
		{
			_cachedVisuals.Clear();
		}
	}

	private StorageVisual ReturnVisual(ItemProperties properties)
	{
		foreach (StorageVisual activeVisual in _activeVisuals)
		{
			if (activeVisual.ItemProperties == properties && !activeVisual.gameObject.activeSelf)
			{
				return activeVisual;
			}
		}
		StorageVisual storageVisual = ReturnOrCreateCachedVisual(properties);
		_activeVisuals.Add(storageVisual);
		return storageVisual;
	}

	private static StorageVisual ReturnOrCreateCachedVisual(ItemProperties properties)
	{
		StorageVisual storageVisual = null;
		if (_cachedVisuals == null)
		{
			_cachedVisuals = new Dictionary<ItemProperties, Queue<StorageVisual>>();
		}
		if (_cachedVisuals.TryGetValue(properties, out var value) && value.Count > 0)
		{
			storageVisual = value.Dequeue();
		}
		else
		{
			storageVisual = UnityEngine.Object.Instantiate(properties.StorageVisualPrefab);
			storageVisual.Initialize(properties);
		}
		return storageVisual;
	}

	private void DevTools_UpdateResourceVisuals(GameEvent gameEvent)
	{
		if (GeneralDevTools.ResourceVisualsDisabled)
		{
			foreach (StorageVisual activeVisual in _activeVisuals)
			{
				_outlineRenderer.UpdateStorageVisual(activeVisual);
				activeVisual.gameObject.SetActive(value: false);
			}
			return;
		}
		UpdateSlot();
	}
}
