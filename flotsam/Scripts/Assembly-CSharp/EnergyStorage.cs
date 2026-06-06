using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

public class EnergyStorage : MonoBehaviour, IBuildableExtendable, IPersistentReference, IEnergyGridStorage, IEnergyGridComponent, IComparable<IEnergyGridStorage>
{
	[SerializeField]
	private float _energyCapacity = 1000f;

	public UnityEvent OnEnergyUpdateEvent { get; private set; } = new UnityEvent();

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid => Connector.EnergyGrid;

	public bool IsEmpty => EnergyAmount <= 0f;

	public bool IsFull => EnergyAmount >= EnergyCapacity;

	public float EnergyAmount { get; private set; }

	public float NormalizedEnergyAmount
	{
		get
		{
			if (!(EnergyCapacity <= 0f))
			{
				return EnergyAmount / EnergyCapacity;
			}
			return 0f;
		}
	}

	public float EnergyCapacity => _energyCapacity;

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Connector = GetComponent<EnergyGridConnector>();
		Connector.AddComponent(this);
		EnergyStorageProgressBarShaderManager componentInChildren = GetComponentInChildren<EnergyStorageProgressBarShaderManager>();
		if (componentInChildren != null)
		{
			componentInChildren.Initialize(this);
		}
	}

	public void Finish(bool restored = false)
	{
	}

	public void Remove()
	{
		Connector.RemoveComponent(this);
	}

	public void AddToEnergyGrid(EnergyGrid grid)
	{
		grid.Storages.AddUnique(this);
		grid.AddComponent(this);
	}

	public void RemoveFromEnergyGrid(EnergyGrid grid)
	{
		if (grid != null)
		{
			grid.Storages.Remove(this);
			grid.RemoveComponent(this);
		}
	}

	public void SetEnergyAmount(float amount)
	{
		EnergyAmount = Mathf.Clamp(amount, 0f, _energyCapacity);
		OnEnergyUpdateEvent.Invoke();
	}

	public bool TryRequestEnergy(float energyAmount, out float returnedAmount)
	{
		if (EnergyAmount - energyAmount >= 0f)
		{
			SetEnergyAmount(EnergyAmount - energyAmount);
			returnedAmount = energyAmount;
			return true;
		}
		returnedAmount = EnergyAmount;
		SetEnergyAmount(0f);
		return false;
	}

	public bool TryAddEnergy(float energyAmount, out float addedAmount)
	{
		if (EnergyAmount + energyAmount <= EnergyCapacity)
		{
			SetEnergyAmount(EnergyAmount + energyAmount);
			addedAmount = energyAmount;
			return true;
		}
		addedAmount = EnergyCapacity - EnergyAmount;
		SetEnergyAmount(EnergyCapacity);
		return false;
	}

	public int CompareTo(IEnergyGridStorage other)
	{
		return other?.EnergyAmount.CompareTo(EnergyAmount) ?? (-1);
	}

	public EnergyGridOverviewSlotUI ReturnUI()
	{
		if (!EnergyStorageOverviewUI.TryReturnAvailableUI(out var ui))
		{
			ui = UnityEngine.Object.Instantiate(GameManager.Settings.UISettings.EnergyStorageOverviewUIPrefab);
		}
		ui.Initialize(this);
		return ui;
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
		return new EnergyStoragePersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		EnergyStoragePersistentData energyStoragePersistentData = persistentData as EnergyStoragePersistentData;
		EnergyAmount = energyStoragePersistentData.EnergyAmount;
		OnEnergyUpdateEvent.Invoke();
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
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

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		text = Regex.Replace(text, "%ENERGY_CAPACITY%", $"<b>{EnergyCapacity}</b>", RegexOptions.IgnoreCase);
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
