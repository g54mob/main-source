using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;

[RequireComponent(typeof(Decoration))]
public class CropDecorationBehaviour : SceneBehaviour, IDecorationBehaviour, IItemConsumer, IItemProducer
{
	[Serializable]
	public class PersistentData : IDecoBehaviourPersistentData
	{
		private readonly float _waterConsumed;

		[NonSerialized]
		private CropDecorationBehaviour _instance;

		private readonly SubInventoryPersistentData _export;

		public PersistentData(CropDecorationBehaviour behaviour)
		{
			_waterConsumed = behaviour.WaterConsumed;
		}

		void IDecoBehaviourPersistentData.Restore(IDecorationBehaviour behaviour, DecorationProperties decorationProperties)
		{
			if (behaviour is CropDecorationBehaviour instance)
			{
				_instance = instance;
			}
		}

		void IDecoBehaviourPersistentData.RestoreReferences()
		{
			_instance.Initialize();
			_instance.RestoreCrop(_waterConsumed);
		}
	}

	[SerializeField]
	private ItemProperties _itemToConsume;

	private Decoration _decoration;

	private CropDecorationProperties _properties;

	private ItemDistributer _itemDistributer;

	private bool _hasBeenInitialized;

	public ItemProperties ItemToConsumeProperties => _itemToConsume;

	public float WaterRequirement
	{
		get
		{
			if (!(_properties != null))
			{
				return 0f;
			}
			return _properties.WaterRequirement;
		}
	}

	public float ConsumptionPerDay
	{
		get
		{
			if (!(_properties != null))
			{
				return 0f;
			}
			if (!(_properties.WaterConsumption < _properties.WaterRequirement))
			{
				return _properties.WaterRequirement;
			}
			return _properties.WaterConsumption;
		}
	}

	public float WaterConsumptionPerSecond { get; private set; }

	public float WaterConsumed { get; private set; }

	public float Progress { get; private set; }

	public Buildable Buildable => _decoration.Parent.Buildable;

	public List<ItemProperties> ProducedItems { get; private set; }

	public ResourceProvider ExportResourceProvider { get; private set; }

	private void Start()
	{
		Initialize();
	}

	private void OnDestroy()
	{
		if (_itemDistributer != null)
		{
			_itemDistributer.DetachConsumer(this);
		}
		if (_decoration != null)
		{
			_decoration.Inventory.CompositionUpdatedEvent -= OnCompositionUpdated;
		}
	}

	public void Initialize()
	{
		if (!_hasBeenInitialized)
		{
			_decoration = GetComponent<Decoration>();
			_decoration.AddSubInventory(SubInventoryType.Import);
			_decoration.AddSubInventory(SubInventoryType.Export);
			_properties = _decoration.Properties as CropDecorationProperties;
			ProducedItems = new List<ItemProperties> { _properties.Yield.ItemProperties };
			WaterConsumptionPerSecond = _properties.WaterConsumption / TimeManager.CycleDuration;
			if (WaterRequirement > 0f)
			{
				_decoration.Inventory.CompositionUpdatedEvent += OnCompositionUpdated;
			}
			if (ConsumptionPerDay > 0f && _decoration.Parent.Buildable.TryReturnBuildableExtendable<ItemDistributer>(out _itemDistributer))
			{
				_itemDistributer.AttachConsumer(this);
			}
			GameManager.ResourceManager.AddProductionLimits(this);
			_hasBeenInitialized = true;
		}
	}

	public void RestoreCrop(float waterConsumed)
	{
		if (_decoration == null)
		{
			Start();
		}
		if (!(WaterRequirement <= 0f) && _decoration.Inventory.ReturnCompositionProgress() == 1f)
		{
			WaterConsumptionPerSecond = _properties.WaterConsumption / TimeManager.CycleDuration;
			WaterConsumed = waterConsumed;
			SetProgress(WaterConsumed / WaterRequirement);
			if (!_decoration.Inventory.ReturnIsEmpty(SubInventoryType.Export))
			{
				RegisterExportItemProvider();
				_decoration.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
			}
			else if (Progress >= 1f)
			{
				Debug.LogWarningFormat($"Restored crop '{_properties}' has progress 1, but its export inventory was empty!");
				OnCropFinished();
			}
			else if (ConsumptionPerDay > 0f && _decoration.Parent.Buildable.TryReturnBuildableExtendable<ItemDistributer>(out _itemDistributer))
			{
				_itemDistributer.AttachConsumer(this);
			}
		}
	}

	public float Consume(float availableWater)
	{
		if (_decoration.ConstructionHandler.BuildPhase != BuildPhase.Finished)
		{
			return 0f;
		}
		if (WaterRequirement <= 0f || WaterRequirement <= WaterConsumed)
		{
			if ((bool)_itemDistributer)
			{
				_itemDistributer.DetachConsumer(this);
			}
			return 0f;
		}
		float num = Mathf.Min(WaterConsumptionPerSecond * TimeManager.GetDeltaTime(), availableWater);
		WaterConsumed += num;
		if (WaterRequirement <= WaterConsumed)
		{
			SetProgress(1f);
			OnCropFinished();
		}
		else
		{
			SetProgress(WaterConsumed / WaterRequirement);
		}
		return num;
	}

	private void OnCompositionUpdated(float progress)
	{
		if (progress >= 1f)
		{
			_decoration.Inventory.CompositionUpdatedEvent -= OnCompositionUpdated;
			FinalUpdate.RegisterOneShot(InitializeCropProgress);
		}
	}

	private void InitializeCropProgress()
	{
		SetProgress(WaterConsumed / WaterRequirement);
	}

	private void OnInventoryUpdated()
	{
		if (_decoration.Inventory.ReturnIsEmpty(SubInventoryType.Export))
		{
			ExportResourceProvider?.Unregister();
			_decoration.Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdated);
			WaterConsumed = 0f;
			if (_decoration.Parent.Buildable.BuildPhase != BuildPhase.SalvageShutdown)
			{
				_itemDistributer.AttachConsumer(this);
			}
			else
			{
				_decoration.Parent.RemoveDecoration(_decoration);
			}
		}
	}

	private void SetProgress(float progress)
	{
		_decoration.ConstructionHandler.SetProgress(progress);
	}

	private void OnCropFinished()
	{
		int i = 0;
		for (int amount = _properties.Yield.Amount; i < amount; i++)
		{
			_decoration.Inventory.AddItem(new Item(_properties.Yield.ItemProperties), SubInventoryType.Export);
		}
		ItemEvent.Dispatch(GameEventType.ItemFarmed, _properties.Yield);
		RegisterExportItemProvider();
		_decoration.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
		if ((bool)_itemDistributer)
		{
			_itemDistributer.DetachConsumer(this);
		}
	}

	private void RegisterExportItemProvider()
	{
		if (ExportResourceProvider == null)
		{
			ExportResourceProvider = ResourceProvider.Get(_decoration, SubInventoryType.Export, GameManager.ResourceManager, AssignmentType.Farming);
		}
		ExportResourceProvider.Register();
	}

	int IItemProducer.GetItemsInProductionCount(ItemProperties itemProperties)
	{
		return 0;
	}

	IDecoBehaviourPersistentData IDecorationBehaviour.GetPersistentData()
	{
		return new PersistentData(this);
	}
}
