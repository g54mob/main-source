using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnergyGridConnector))]
public class EnergyItemProducer : SceneBehaviour, IBuildableExtendable, IPersistentReference, IEnergyGridProducer, IEnergyGridComponent, IComparable<IEnergyGridProducer>
{
	public ItemProperties EnergyItemProperties;

	public float PowerRate = 0.5f;

	public float MaxBurnTime = 30f;

	public int ImportCapacity = 10;

	[SerializeField]
	private int _priority = 50;

	[Header("FMOD")]
	[SerializeField]
	private EventReference _FMODEventReference_Production;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Project ImportProject { get; private set; }

	public int ProjectCount { get; private set; }

	public float BurnTimer { get; private set; }

	public int InventoryRefillAmountPoint { get; private set; } = 5;

	public bool IsGenerating { get; private set; }

	public AssignmentType AssignmentType => AssignmentType.EelectricityManagement;

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid => Connector.EnergyGrid;

	public float Production
	{
		get
		{
			if (!IsGenerating)
			{
				return 0f;
			}
			return PowerRate;
		}
	}

	public float EnergyFillPercentage { get; private set; } = 0.5f;

	public int Priority => _priority;

	public UnityEvent OnStartEnergyItemProducing { get; private set; } = new UnityEvent();

	public UnityEvent OnStopEnergyItemProducing { get; private set; } = new UnityEvent();

	public UnityEvent OnEnergyFillPercentageUpdated { get; private set; } = new UnityEvent();

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Import);
		Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Export);
		Connector = GetComponent<EnergyGridConnector>();
		Connector.AddComponent(this);
		if (!restored)
		{
			ImportProject = new Project(GameManager.Settings.ProjectSettings.ImportProperties, base.gameObject);
			ImportProject.AddAssignmentType(AssignmentType);
			Buildable.Community.QueueProject(ImportProject);
			SetInventoryRefillAmountPoint(ImportCapacity / 2);
		}
		Buildable.Community.Inventory.InventoryUpdatedEvent.AddListener(TryReserveAdditionalItems);
		Buildable.Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdate);
	}

	public void Finish(bool restored = false)
	{
		if (!restored)
		{
			TryReserveAdditionalItems();
		}
	}

	public void Remove()
	{
		Connector.RemoveComponent(this);
		if (ImportProject != null)
		{
			ImportProject.Stop(ProjectFlags.BuildableRemoved);
			ImportProject = null;
		}
		Buildable.Community.Inventory.InventoryUpdatedEvent.RemoveListener(TryReserveAdditionalItems);
		Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdate);
	}

	private void OnDestroy()
	{
		if (ImportProject != null)
		{
			ImportProject.Stop(ProjectFlags.BuildableRemoved);
		}
		if (Buildable.Community != null)
		{
			Buildable.Community.Inventory.InventoryUpdatedEvent.RemoveListener(TryReserveAdditionalItems);
		}
		Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdate);
	}

	private void Update()
	{
		BuildPhase buildPhase = Buildable.BuildPhase;
		if (buildPhase != BuildPhase.Finished && buildPhase != BuildPhase.SalvageShutdown)
		{
			return;
		}
		if (!IsGenerating && ReturnCanRun() && EnergyGrid.IsHighestPriority(this) && EnergyGrid.ReturnRequiresEnergyFromProducer(this))
		{
			OnStartEnergyItemProducing?.Invoke();
			Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
			Buildable.FMODEventEmitter.Emit(_FMODEventReference_Production);
			IsGenerating = true;
		}
		if (!IsGenerating)
		{
			return;
		}
		if (ReturnCanRun() && !EnergyGrid.IsFull)
		{
			BurnTimer += Time.deltaTime;
			IsGenerating = true;
			if (BurnTimer > MaxBurnTime)
			{
				BurnItem();
			}
		}
		else
		{
			IsGenerating = false;
			OnStopEnergyItemProducing?.Invoke();
			Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 0);
			Buildable.FMODEventEmitter.Stop(_FMODEventReference_Production);
		}
	}

	public void SetEnergyFillPercentage(float percentage)
	{
		EnergyFillPercentage = percentage;
		OnEnergyFillPercentageUpdated.Invoke();
	}

	public void SetInventoryRefillAmountPoint(int amount)
	{
		InventoryRefillAmountPoint = amount;
		TryReserveAdditionalItems();
	}

	private void BurnItem()
	{
		BurnTimer = 0f;
		Item item = Buildable.Inventory.PeekAtFirstItem(SubInventoryType.Export);
		item.Inventory.TakeItem(item);
		TryReserveAdditionalItems();
	}

	private void TryReserveAdditionalItems()
	{
		int num = Buildable.Inventory.ReturnCount(EnergyItemProperties, SubInventoryType.Export) + ProjectCount;
		if (num > InventoryRefillAmountPoint)
		{
			return;
		}
		int num2 = ImportCapacity - num;
		if (num2 <= 0)
		{
			return;
		}
		int num3 = Buildable.Community.Inventory.ReturnCount(EnergyItemProperties);
		if (num3 > 0)
		{
			int num4 = Mathf.Min(num2, num3);
			ProjectCount += num4;
			if (ResourceManager.TryReserveClosestItems(Buildable, EnergyItemProperties, num4, out var reservedItems))
			{
				ImportProject.AddItems(reservedItems);
			}
		}
	}

	private void OnInventoryUpdate()
	{
		int num = Buildable.Inventory.ReturnCount(EnergyItemProperties, SubInventoryType.Import);
		if (num == 0)
		{
			return;
		}
		List<Item> list = ListPool<Item>.Get();
		Buildable.Inventory.ReturnAllItems(SubInventoryType.Import, list);
		foreach (Item item in list)
		{
			Buildable.Inventory.MoveToSubInventory(item, SubInventoryType.Export);
		}
		ListPool<Item>.Add(list);
		ProjectCount -= num;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new EnergyItemProducerPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		EnergyItemProducerPersistentData energyItemProducerPersistentData = persistentData as EnergyItemProducerPersistentData;
		ProjectCount = energyItemProducerPersistentData.ProjectCount;
		BurnTimer = energyItemProducerPersistentData.BurnTimer;
		EnergyFillPercentage = energyItemProducerPersistentData.EnergyFillPercentage;
		IsGenerating = energyItemProducerPersistentData.IsGenerating;
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		EnergyItemProducerPersistentData energyItemProducerPersistentData = persistentData as EnergyItemProducerPersistentData;
		if (energyItemProducerPersistentData.ImportProject != null && energyItemProducerPersistentData.ImportProject.TryReturn(out var instance))
		{
			ImportProject = instance;
			SetInventoryRefillAmountPoint(energyItemProducerPersistentData.RefillAmountPoint);
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		(persistentData as EnergyItemProducerPersistentData).ImportProject = ImportProject;
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public string ReturnDescription(string text)
	{
		text = Regex.Replace(text, "%ENERGY_PRODUCTION%", $"<b>{PowerRate}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public bool ReturnCanRun()
	{
		if (!Active)
		{
			return false;
		}
		if (Buildable.Inventory.ReturnCount(SubInventoryType.Export, includeReserved: true) == 0)
		{
			return false;
		}
		return true;
	}

	public int CompareTo(IEnergyGridProducer other)
	{
		return other?.Priority.CompareTo(Priority) ?? (-1);
	}

	public void AddToEnergyGrid(EnergyGrid grid)
	{
		grid.AddProducer(this);
		grid.AddComponent(this);
	}

	public void RemoveFromEnergyGrid(EnergyGrid grid)
	{
		if (grid != null)
		{
			grid.RemoveProducer(this);
			grid.RemoveComponent(this);
		}
	}

	public EnergyGridOverviewSlotUI ReturnUI()
	{
		if (!EnergyItemProducerOverviewUI.TryReturnAvailableUI(out var ui))
		{
			ui = UnityEngine.Object.Instantiate(GameManager.Settings.UISettings.EnergyItemProducerOverviewUIPrefab);
		}
		ui.Initialize(this);
		return ui;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
