using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Serialization;

public class EnergyGridConnector : SceneBehaviour, IPersistentReference
{
	[SerializeField]
	[FormerlySerializedAs("LinkTransform")]
	[FormerlySerializedAs("_linkTransform")]
	private Transform _connectionTransform;

	[SerializeField]
	[FormerlySerializedAs("LinkCapacity")]
	[FormerlySerializedAs("_linkCapacity")]
	private int _connectionsCapacity = 2;

	[SerializeField]
	private bool _showUnconnectedWarning = true;

	[SerializeField]
	private bool _isTownheart;

	private readonly List<IEnergyGridComponent> _components = new List<IEnergyGridComponent>();

	private readonly List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	private int _connectionsCount;

	public virtual Transform ConnectionTransform => _connectionTransform;

	public int ConnectionsCapacity
	{
		get
		{
			if (Connections == null)
			{
				return 0;
			}
			return _connectionsCapacity;
		}
	}

	public bool IsTownheart => _isTownheart;

	public EnergyGrid EnergyGrid { get; private set; }

	public EnergyGridConnector[] Connections { get; private set; }

	public virtual string Name => "";

	public virtual Sprite IconSprite => null;

	public virtual OutlineRendererComponent OutlineRenderer => null;

	public int PersistentIndex { get; set; } = -1;

	private void Start()
	{
		if (EnergyGrid != null || Connections == null)
		{
			return;
		}
		EnergyGridConnector[] connections = Connections;
		foreach (EnergyGridConnector energyGridConnector in connections)
		{
			if (!(energyGridConnector == null))
			{
				Disconnect(energyGridConnector);
				energyGridConnector.Disconnect(this);
				new EnergyGridConnectionEvent(GameEventType.EnergyGridConnectionRemoved, this, energyGridConnector).Dispatch();
			}
		}
	}

	public void InitializeConnections(int capacity = -1)
	{
		if (capacity < 0)
		{
			capacity = _connectionsCapacity;
		}
		if (Connections == null)
		{
			Connections = new EnergyGridConnector[capacity];
		}
		else if (Connections.Length < capacity)
		{
			EnergyGridConnector[] connections = Connections;
			Connections = new EnergyGridConnector[capacity];
			int i = 0;
			for (int num = connections.Length; i < num; i++)
			{
				Connections[i] = connections[i];
			}
		}
		_connectionsCount = 0;
	}

	public void AddComponent(IEnergyGridComponent component)
	{
		if (_components.AddUnique(component) && EnergyGrid != null)
		{
			component.AddToEnergyGrid(EnergyGrid);
		}
	}

	public void RemoveComponent(IEnergyGridComponent component)
	{
		if (_components.Remove(component) && EnergyGrid != null)
		{
			component.RemoveFromEnergyGrid(EnergyGrid);
		}
	}

	public void PopulateEnergyGridConnections(ref HashSet<EnergyGridConnector> components, ref HashSet<EnergyGridConnector> visited)
	{
		if (!visited.Add(this) || !components.Add(this))
		{
			return;
		}
		EnergyGridConnector[] connections = Connections;
		foreach (EnergyGridConnector energyGridConnector in connections)
		{
			if (energyGridConnector != null)
			{
				energyGridConnector.PopulateEnergyGridConnections(ref components, ref visited);
			}
		}
	}

	public virtual bool Connect(EnergyGridConnector component, uint index)
	{
		if (index < Connections.Length && Connections[index] == null)
		{
			Connections[index] = component;
			_connectionsCount++;
			return true;
		}
		return false;
	}

	public virtual bool Connect(EnergyGridConnector component)
	{
		if (IsConnected(component))
		{
			return false;
		}
		for (int i = 0; i < Connections.Length; i++)
		{
			if (Connections[i] == null)
			{
				Connections[i] = component;
				_connectionsCount++;
				return true;
			}
		}
		return false;
	}

	public virtual bool Disconnect(EnergyGridConnector component)
	{
		for (int i = 0; i < Connections.Length; i++)
		{
			if (Connections[i] == component)
			{
				Connections[i] = null;
				_connectionsCount--;
				return true;
			}
		}
		return false;
	}

	public void SetEnergyGrid(EnergyGrid grid)
	{
		if (!grid.AddConnector(this))
		{
			return;
		}
		EnergyGrid?.RemoveConnector(this);
		EnergyGrid = grid;
		foreach (IEnergyGridComponent component in _components)
		{
			component.AddToEnergyGrid(grid);
		}
		new EnergyGridEvent(GameEventType.EnergyGridsUpdated, grid).Dispatch();
	}

	public void ClearEnergyGrid()
	{
		if (EnergyGrid == null || !EnergyGrid.RemoveConnector(this))
		{
			return;
		}
		foreach (IEnergyGridComponent component in _components)
		{
			component.RemoveFromEnergyGrid(EnergyGrid);
		}
		EnergyGrid = null;
	}

	protected void UpdateConnectionMalfunction()
	{
		if (_showUnconnectedWarning)
		{
			if (HasConnections())
			{
				RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorNotLinkedToEnergyGridProperties);
			}
			else
			{
				AddMalfunction(GameManager.Settings.BuildableSettings.ErrorNotLinkedToEnergyGridProperties);
			}
		}
	}

	public void AddMalfunction(PlaceableAlertProperties properties)
	{
		if (_malfunctions.AddUnique(properties))
		{
			MalfunctionAdded(properties);
		}
	}

	public void RemoveMalfunction(PlaceableAlertProperties properties)
	{
		_malfunctions.Remove(properties);
		MalfunctionRemoved(properties);
	}

	protected void RemoveAllMalfunctions()
	{
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			MalfunctionRemoved(malfunction);
		}
		_malfunctions.Clear();
	}

	protected virtual void MalfunctionAdded(PlaceableAlertProperties properties)
	{
	}

	protected virtual void MalfunctionRemoved(PlaceableAlertProperties properties)
	{
	}

	public bool IsInRange(Vector3 position)
	{
		return Vector3.Distance(base.transform.position.Leveled(), position.Leveled()) < GameManager.Settings.BuildableSettings.CableLinkRange;
	}

	public bool HasConnections()
	{
		if (Connections.IsNullOrEmpty())
		{
			return false;
		}
		EnergyGridConnector[] connections = Connections;
		for (int i = 0; i < connections.Length; i++)
		{
			if (!(connections[i] == null))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsConnected(EnergyGridConnector component)
	{
		if (Connections.IsNullOrEmpty())
		{
			return false;
		}
		EnergyGridConnector[] connections = Connections;
		for (int i = 0; i < connections.Length; i++)
		{
			if (connections[i] == component)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanConnect(uint index)
	{
		if (Connections != null && index < Connections.Length)
		{
			return Connections[index] == null;
		}
		return false;
	}

	public virtual bool CanConnect()
	{
		return _connectionsCount < _connectionsCapacity;
	}

	public bool TryGetConnectedComponent(out EnergyGridConnector connectedComponent, uint index)
	{
		connectedComponent = null;
		if (Connections != null && index < Connections.Length)
		{
			connectedComponent = Connections[index];
		}
		return connectedComponent;
	}

	public void RestoreReferences(IEnergyGridComponentPersistentData persistentData)
	{
		Connections = persistentData.GetEnergyLinks();
		_connectionsCount = 0;
		if (Connections != null)
		{
			InitializeConnections(Connections.Length);
			EnergyGridConnector[] connections = Connections;
			foreach (EnergyGridConnector energyGridConnector in connections)
			{
				if ((bool)energyGridConnector)
				{
					_connectionsCount++;
					if (EnergyGrid != null && energyGridConnector.EnergyGrid != null && energyGridConnector.EnergyGrid != EnergyGrid)
					{
						EnergyGrid.Merge(energyGridConnector.EnergyGrid);
					}
				}
			}
		}
		else
		{
			InitializeConnections();
		}
		UpdateConnectionMalfunction();
	}
}
