using System;
using UnityEngine;

[RequireComponent(typeof(EnergyGridConnector))]
public class EnergyGridPole : SceneBehaviour, IBuildableExtendable, IDecorationExtendable, IEnergyGridComponent, IPersistentReference
{
	public int PersistentIndex { get; set; }

	public Buildable Buildable { get; private set; }

	public Decoration Decoration { get; private set; }

	public bool Active { get; private set; }

	public EnergyGridConnector Connector { get; set; }

	public EnergyGrid EnergyGrid
	{
		get
		{
			if (!(Connector != null))
			{
				return null;
			}
			return Connector.EnergyGrid;
		}
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Connector = GetComponent<EnergyGridConnector>();
		Connector.AddComponent(this);
	}

	public void Initialize(Decoration decoration)
	{
		Decoration = decoration;
		Connector = GetComponent<EnergyGridConnector>();
		Connector.AddComponent(this);
	}

	public void Finish()
	{
	}

	public void Finish(bool restored)
	{
	}

	public void Remove()
	{
		Connector.RemoveComponent(this);
	}

	private void Update()
	{
		if (EnergyGrid != null && !(Connector == null))
		{
			if (EnergyGrid.GridEfficiency < 1f)
			{
				Connector.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorInefficientGridProperties);
			}
			else
			{
				Connector.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorInefficientGridProperties);
			}
		}
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			if (!(Buildable == null))
			{
				return Buildable.BuildPhase == BuildPhase.Finished;
			}
			return true;
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
		return new EnergyGridPolePersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
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

	public void Upgrade(Decoration decoration)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public void AddToEnergyGrid(EnergyGrid grid)
	{
		grid.AddComponent(this);
	}

	public void RemoveFromEnergyGrid(EnergyGrid grid)
	{
		grid?.RemoveComponent(this);
	}

	public EnergyGridOverviewSlotUI ReturnUI()
	{
		return null;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public bool TryReturnWalkwayPonton(out WalkwayPonton walkwayPonton)
	{
		walkwayPonton = GetComponentInParent<WalkwayPonton>();
		return walkwayPonton != null;
	}
}
