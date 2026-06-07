using System;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : BuildableExtendableBase
{
	[Serializable]
	public class PersistentData : IBuildableExtendablePersistentData
	{
		private int[] _activeModuleIndices;

		[NonSerialized]
		private ModuleManager _instance;

		public PersistentData(ModuleManager instance)
		{
			_activeModuleIndices = GameManager.PersistenceManager.ReturnPropertiesIndexArray(instance._activeModules);
		}

		public void PopulateReferences()
		{
		}

		public void Restore()
		{
		}

		public void RestoreData(Buildable buildable)
		{
			if (!buildable.TryReturnBuildableExtendable<ModuleManager>(out _instance))
			{
				Debug.LogException(new Exception($"Unable to restore ModuleManager for Buidlable '{buildable}'"));
			}
		}

		public void RestoreReferences()
		{
			if (_instance == null || _activeModuleIndices == null)
			{
				return;
			}
			int[] activeModuleIndices = _activeModuleIndices;
			foreach (int index in activeModuleIndices)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<ModuleProperties>(index, out var reference))
				{
					_instance.ActivateModule(reference);
				}
			}
		}
	}

	[SerializeField]
	private QuestProperties _rocketQuestProperties;

	private List<ModuleProperties> _activeModules = new List<ModuleProperties>();

	private ModuleVisual[] _moduleVisuals;

	public ModuleProperties[] Modules { get; private set; }

	public QuestProperties RocketQuestProperties { get; private set; }

	private void Start()
	{
		RestoreActiveModules();
	}

	public override void Initialize(Buildable buildable, bool restored = false)
	{
		base.Initialize(buildable, restored);
		ReturnModuleVisuals();
		base.Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Modules);
	}

	public override void Finish(bool restored = false)
	{
		Modules = base.Buildable.Properties.Modules;
		base.Buildable.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
		OnInventoryUpdated();
		if (base.isActiveAndEnabled)
		{
			RestoreActiveModules();
		}
	}

	public override void Shutdown()
	{
		base.Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdated);
	}

	public override void Upgrade(Buildable upgradedBuildable)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		base.Buildable.Inventory.ReturnAllItems(SubInventoryType.Modules, list);
		if (upgradedBuildable.Inventory.ReturnInventory(SubInventoryType.Modules) == null)
		{
			upgradedBuildable.Inventory.GetOrAddSubInventory(SubInventoryType.Modules);
		}
		upgradedBuildable.Inventory.AddItems(list, SubInventoryType.Modules);
	}

	public bool PlaceModule(ModuleProperties module)
	{
		if (_activeModules.Contains(module) || !base.Buildable.Community.Inventory.TryReturnReserveClosestItems(base.Buildable, module.GetCost(base.Buildable, excludeItemsinInventory: true), out var reservedItems))
		{
			return false;
		}
		foreach (Item item in reservedItems)
		{
			if (item.TryTakeFromInventory(out var _))
			{
				base.Buildable.Inventory.AddItem(item, SubInventoryType.Modules);
			}
		}
		return true;
	}

	public void PopulateInactiveModules(List<ModuleProperties> inactiveModules)
	{
		if (Modules.IsNullOrEmpty())
		{
			return;
		}
		ModuleProperties[] modules = Modules;
		foreach (ModuleProperties item in modules)
		{
			if (!_activeModules.Contains(item))
			{
				inactiveModules.Add(item);
			}
		}
	}

	private void ActivateModule(ModuleProperties module)
	{
		if (_activeModules.AddUnique(module))
		{
			ModuleVisual[] array = ReturnModuleVisuals();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Activate(base.Buildable, module);
			}
			BuildableEvent.Dipatch(GameEventType.ModuleActivated, base.Buildable, module);
		}
	}

	private void DeactivateModule(ModuleProperties module)
	{
		if (_activeModules.Remove(module))
		{
			ModuleVisual[] array = ReturnModuleVisuals();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deactivate(module);
			}
		}
	}

	private void RestoreActiveModules()
	{
		if (!_rocketQuestProperties)
		{
			return;
		}
		_activeModules.Clear();
		if (!StoryManager.TryGetQuest(_rocketQuestProperties, out var questInstance) || questInstance.Objectives == null)
		{
			return;
		}
		foreach (IQuestObjective objective in questInstance.Objectives.Objectives)
		{
			if (objective is ActivateModuleObjective activateModuleObjective && activateModuleObjective.IsCompleted() && Modules.Contains(activateModuleObjective.Module))
			{
				ActivateModule(activateModuleObjective.Module);
			}
		}
	}

	private void OnInventoryUpdated()
	{
		ModuleProperties[] modules = Modules;
		foreach (ModuleProperties moduleProperties in modules)
		{
			if (base.Buildable.Inventory.ReturnContainsItems(moduleProperties.GetCost(base.Buildable, excludeItemsinInventory: false), SubInventoryType.Modules))
			{
				ActivateModule(moduleProperties);
			}
			else
			{
				DeactivateModule(moduleProperties);
			}
		}
	}

	public bool IsActiveModule(ModuleProperties module)
	{
		return _activeModules.Contains(module);
	}

	public bool IsRocket()
	{
		return _rocketQuestProperties;
	}

	public bool CanLaunchRocket()
	{
		if ((bool)_rocketQuestProperties && StoryManager.TryGetQuest(_rocketQuestProperties, out var questInstance) && questInstance.Objectives != null)
		{
			foreach (IQuestObjective objective in questInstance.Objectives.Objectives)
			{
				if (objective is ActivateModuleObjective activateModuleObjective && !activateModuleObjective.IsCompleted())
				{
					return false;
				}
				if (objective is GameEventObjective gameEventObjective && gameEventObjective.HasActiveDialogue())
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public bool HasLaunchedRocket()
	{
		if ((bool)_rocketQuestProperties)
		{
			return StoryManager.IsQuestCompleted(_rocketQuestProperties);
		}
		return false;
	}

	public override float ReturnWeight()
	{
		float num = 0f;
		foreach (ModuleProperties activeModule in _activeModules)
		{
			num += activeModule.Weight;
		}
		return num;
	}

	public float ReturnModifier(ModifierType modifierType)
	{
		float num = 1f;
		foreach (ModuleProperties activeModule in _activeModules)
		{
			if (activeModule.TryGetModifier(modifierType, out var value))
			{
				num += value;
			}
		}
		return num;
	}

	private ModuleVisual[] ReturnModuleVisuals()
	{
		if (_moduleVisuals == null)
		{
			_moduleVisuals = base.Buildable.SpawnedVisual.GetComponentsInChildren<ModuleVisual>(includeInactive: true);
			ModuleVisual[] moduleVisuals = _moduleVisuals;
			for (int i = 0; i < moduleVisuals.Length; i++)
			{
				moduleVisuals[i].Initialize(base.Buildable, _activeModules);
			}
		}
		return _moduleVisuals;
	}

	public override IBuildableExtendablePersistentData ReturnPersistentData()
	{
		if (_activeModules.Count == 0)
		{
			return null;
		}
		return new PersistentData(this);
	}
}
