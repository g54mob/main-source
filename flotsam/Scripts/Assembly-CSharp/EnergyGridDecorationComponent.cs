using UnityEngine;

public class EnergyGridDecorationComponent : EnergyGridConnector, IDecorationExtendable
{
	public Decoration Decoration { get; private set; }

	public bool Active { get; private set; }

	public override string Name
	{
		get
		{
			if (!(Decoration != null))
			{
				return "";
			}
			return Decoration.Name;
		}
	}

	public override Sprite IconSprite
	{
		get
		{
			if (!(Decoration != null))
			{
				return null;
			}
			return Decoration.Properties.GetIcon();
		}
	}

	public override OutlineRendererComponent OutlineRenderer
	{
		get
		{
			if (!(Decoration != null))
			{
				return null;
			}
			return Decoration.OutlineRenderer;
		}
	}

	public void Initialize(Decoration decoration)
	{
		Decoration = decoration;
		InitializeConnections();
	}

	public void Finish()
	{
		if (base.EnergyGrid == null)
		{
			SetEnergyGrid(EnergyGridManager.AddGrid());
		}
		UpdateConnectionMalfunction();
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void Upgrade(Decoration decoration)
	{
		DisconnectAll();
	}

	public void OnDeconstruct()
	{
		DisconnectAll();
	}

	public void Remove()
	{
		DisconnectAll();
		ClearEnergyGrid();
	}

	public bool IsEnabled()
	{
		return Active;
	}

	protected override void MalfunctionAdded(PlaceableAlertProperties properties)
	{
		Decoration.StatusHolder.AddMalfunction(properties);
	}

	protected override void MalfunctionRemoved(PlaceableAlertProperties properties)
	{
		Decoration.StatusHolder.RemoveMalfunction(properties);
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
		if (base.Connections.IsNullOrEmpty())
		{
			return;
		}
		EnergyGridConnector[] connections = base.Connections;
		foreach (EnergyGridConnector energyGridConnector in connections)
		{
			if (energyGridConnector != null)
			{
				EnergyGrid.Disconnect(this, energyGridConnector);
			}
		}
	}

	public override bool CanConnect()
	{
		if ((bool)Decoration && Decoration.ConstructionHandler != null && Decoration.ConstructionHandler.BuildPhase == BuildPhase.Finished)
		{
			return base.CanConnect();
		}
		return false;
	}
}
