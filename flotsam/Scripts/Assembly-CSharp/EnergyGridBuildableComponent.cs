using System;
using UnityEngine;

public class EnergyGridBuildableComponent : EnergyGridConnector, IBuildableExtendable
{
	private BuildableVisual _visual;

	public override Transform ConnectionTransform
	{
		get
		{
			if (!_visual)
			{
				return base.ConnectionTransform;
			}
			return _visual.ReturnEnergyLinkTransform(base.ConnectionTransform);
		}
	}

	public Buildable Buildable { get; set; }

	public bool Active { get; private set; }

	public override string Name
	{
		get
		{
			if (!(Buildable != null))
			{
				return "";
			}
			return Buildable.Name;
		}
	}

	public override Sprite IconSprite
	{
		get
		{
			if (!(Buildable != null))
			{
				return null;
			}
			return Buildable.Properties.GetIcon();
		}
	}

	public override OutlineRendererComponent OutlineRenderer
	{
		get
		{
			if (!(Buildable != null))
			{
				return null;
			}
			return Buildable.OutlineRenderer;
		}
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.OnBuildableVisualRegister.AddListener(RegisterVisual);
		InitializeConnections();
	}

	public void Finish(bool restored = false)
	{
		if (base.EnergyGrid == null)
		{
			SetEnergyGrid(EnergyGridManager.AddGrid());
		}
		UpdateConnectionMalfunction();
	}

	public void Remove()
	{
		Buildable.OnBuildableVisualRegister.RemoveListener(RegisterVisual);
		DisconnectAll();
		ClearEnergyGrid();
	}

	public void Activate()
	{
		Active = true;
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public void OnDeconstruct()
	{
		DisconnectAll();
		RemoveAllMalfunctions();
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public void Shutdown()
	{
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public void Upgrade(Buildable buildable)
	{
		DisconnectAll();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new EnergyGridBuildableComponentPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		RestoreReferences(persistentData as IEnergyGridComponentPersistentData);
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	protected override void MalfunctionAdded(PlaceableAlertProperties properties)
	{
		Buildable.AddMalfunction(properties);
	}

	protected override void MalfunctionRemoved(PlaceableAlertProperties properties)
	{
		Buildable.RemoveMalfunction(properties);
	}

	public override bool Connect(EnergyGridConnector component, uint index)
	{
		if (base.Connect(component, index))
		{
			UpdateConnectionMalfunction();
			return true;
		}
		return false;
	}

	public override bool Connect(EnergyGridConnector component)
	{
		if (base.Connect(component))
		{
			UpdateConnectionMalfunction();
			return true;
		}
		return false;
	}

	public override bool Disconnect(EnergyGridConnector component)
	{
		if (base.Disconnect(component))
		{
			UpdateConnectionMalfunction();
			return true;
		}
		return false;
	}

	public void DisconnectAll()
	{
		EnergyGridConnector[] connections = base.Connections;
		foreach (EnergyGridConnector energyGridConnector in connections)
		{
			if ((bool)energyGridConnector)
			{
				EnergyGrid.Disconnect(this, energyGridConnector);
			}
		}
	}

	private void RegisterVisual(BuildableVisual visual)
	{
		_visual = visual;
	}

	public override bool CanConnect()
	{
		if (Buildable.BuildPhase == BuildPhase.Finished)
		{
			return base.CanConnect();
		}
		return false;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
