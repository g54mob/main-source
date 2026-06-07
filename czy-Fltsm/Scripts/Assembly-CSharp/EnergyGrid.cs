using System.Collections.Generic;
using UnityEngine;

public class EnergyGrid : IPersistentReference
{
	public List<EnergyGridConnector> Links { get; private set; }

	public List<IEnergyGridComponent> Components { get; private set; }

	public List<IEnergyGridStorage> Storages { get; private set; }

	public List<IEnergyGridConsumer> Consumers { get; private set; }

	public List<IEnergyGridProducer> Producers { get; private set; }

	public float GridEfficiency { get; private set; } = 1f;

	public bool HasEnergy
	{
		get
		{
			if (!(ReturnStorageEnergy() > 0f))
			{
				return ReturnEnergyProduction() > 0f;
			}
			return true;
		}
	}

	public bool IsFull => ReturnStorageEnergy() >= ReturnStorageCapacity();

	public bool IsEmpty => ReturnStorageEnergy() <= 0f;

	public EnergyGridObjectOfInterest ObjectOfInterest { get; private set; }

	public bool IsTownheartGrid { get; private set; }

	public int PersistentIndex { get; set; }

	public EnergyGrid()
	{
		Links = new List<EnergyGridConnector>();
		Components = new List<IEnergyGridComponent>();
		Storages = new List<IEnergyGridStorage>();
		Consumers = new List<IEnergyGridConsumer>();
		Producers = new List<IEnergyGridProducer>();
		ObjectOfInterest = new EnergyGridObjectOfInterest(this);
	}

	public EnergyGrid(EnergyGridPersistentData data)
		: this()
	{
	}

	public void CalculateEfficiency()
	{
		float deltaTime = Time.deltaTime;
		bool num = Mathf.Approximately(GridEfficiency, 1f);
		float num2 = ReturnEnergyConsumption() * deltaTime;
		float num3 = ReturnEnergyProduction() * deltaTime;
		float num4 = Mathf.Clamp(num2 - num3, 0f, ReturnStorageEnergy());
		float num5 = num3 + num4;
		float num6 = num3 - num2;
		float num7 = Mathf.Min(num2, num3);
		float num8 = num7;
		if (num2 <= 0f)
		{
			GridEfficiency = 1f;
		}
		else
		{
			GridEfficiency = (Mathf.Approximately(num5, num2) ? 1f : Mathf.Clamp(num5 / num2, 0f, 1f));
		}
		if (num != Mathf.Approximately(GridEfficiency, 1f))
		{
			new EnergyGridEvent(GameEventType.EnergyGridEfficiencyUpdated, this).Dispatch();
		}
		if (num4 > 0f)
		{
			RequestStorageEnergy(num4);
		}
		if (num6 > 0f)
		{
			num8 += FillStorageEnergy(num6);
		}
		if (num7 > 0f)
		{
			new EnergyEvent(GameEventType.EnergyConsumed, num7).Dispatch();
		}
		if (num8 > 0f)
		{
			new EnergyEvent(GameEventType.EnergyProduced, num8).Dispatch();
		}
	}

	public bool AddConnector(EnergyGridConnector connector)
	{
		if (Links.AddUnique(connector))
		{
			if (connector.IsTownheart)
			{
				IsTownheartGrid = true;
			}
			return true;
		}
		return false;
	}

	public bool RemoveConnector(EnergyGridConnector connector)
	{
		if (Links.Remove(connector))
		{
			if (connector.IsTownheart)
			{
				IsTownheartGrid = false;
			}
			return true;
		}
		return false;
	}

	public void AddComponent(IEnergyGridComponent component)
	{
		if (Components.AddUnique(component))
		{
			new EnergyGridEvent(GameEventType.EnergyGridEfficiencyUpdated, this).Dispatch();
		}
	}

	public void RemoveComponent(IEnergyGridComponent component)
	{
		if (Components.Remove(component))
		{
			if (Components.Count == 0)
			{
				EnergyGridManager.RemoveGrid(this);
			}
			new EnergyGridEvent(GameEventType.EnergyGridEfficiencyUpdated, this).Dispatch();
		}
	}

	public void AddProducer(IEnergyGridProducer producer)
	{
		if (Producers.AddUnique(producer))
		{
			Sorting.SlowSort(Producers);
		}
	}

	public void RemoveProducer(IEnergyGridProducer producer)
	{
		if (Producers.Remove(producer))
		{
			Sorting.SlowSort(Producers);
		}
	}

	public void UpdateGrids()
	{
		List<HashSet<EnergyGridConnector>> list = ListPool<HashSet<EnergyGridConnector>>.Get();
		HashSet<EnergyGridConnector> visited = new HashSet<EnergyGridConnector>();
		foreach (EnergyGridConnector link in Links)
		{
			if (!visited.Contains(link))
			{
				HashSet<EnergyGridConnector> components = new HashSet<EnergyGridConnector>();
				link.PopulateEnergyGridConnections(ref components, ref visited);
				list.Add(components);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (EnergyGridConnector item in list[0])
		{
			if (!Links.Contains(item))
			{
				item.ClearEnergyGrid();
			}
		}
		list.RemoveAt(0);
		foreach (HashSet<EnergyGridConnector> item2 in list)
		{
			EnergyGrid energyGrid = EnergyGridManager.AddGrid();
			foreach (EnergyGridConnector item3 in item2)
			{
				item3.ClearEnergyGrid();
				item3.SetEnergyGrid(energyGrid);
			}
		}
		ListPool<HashSet<EnergyGridConnector>>.Add(list);
	}

	public float RequestStorageEnergy(float requestedAmount)
	{
		float num = 0f;
		int num2 = ReturnAvailableStorageCount();
		if (num2 <= 0)
		{
			return num;
		}
		float b = ReturnStorageEnergy();
		requestedAmount = Mathf.Min(requestedAmount, b);
		float energyAmount = requestedAmount / (float)num2;
		Sorting.SlowSort(Storages);
		for (int num3 = Storages.Count - 1; num3 >= 0; num3--)
		{
			IEnergyGridStorage energyGridStorage = Storages[num3];
			if (!energyGridStorage.IsEmpty)
			{
				if (energyGridStorage.TryRequestEnergy(energyAmount, out var returnedAmount))
				{
					requestedAmount -= returnedAmount;
					num += returnedAmount;
				}
				else
				{
					requestedAmount -= returnedAmount;
					num += returnedAmount;
					num2--;
					energyAmount = requestedAmount / (float)num2;
				}
			}
		}
		new EnergyEvent(GameEventType.EnergyConsumed, num).Dispatch();
		return num;
	}

	public float FillStorageEnergy(float amountToStore)
	{
		int num = ReturnNonFullStorageCount();
		if (num <= 0)
		{
			return 0f;
		}
		float energyAmount = amountToStore / (float)num;
		float num2 = 0f;
		Sorting.SlowSort(Storages);
		foreach (IEnergyGridStorage storage in Storages)
		{
			if (!storage.IsFull)
			{
				storage.TryAddEnergy(energyAmount, out var addedAmount);
				amountToStore -= addedAmount;
				num2 += addedAmount;
				num--;
				energyAmount = amountToStore / (float)num;
			}
		}
		return num2;
	}

	public bool IsHighestPriority(IEnergyGridProducer producer)
	{
		if (Storages.Count > 0)
		{
			return true;
		}
		int num = 0;
		foreach (IEnergyGridProducer producer2 in Producers)
		{
			if (producer2 != null && !producer2.IsGenerating && producer2.ReturnCanRun() && producer2.EnergyGrid.ReturnRequiresEnergyFromProducer(producer2) && producer2.Priority > num)
			{
				num = producer2.Priority;
			}
		}
		return producer.Priority >= num;
	}

	public float ReturnEnergyRequirement()
	{
		float num = 0f;
		foreach (IEnergyGridConsumer consumer in Consumers)
		{
			num += consumer.EnergyRequirement;
		}
		return num;
	}

	public float ReturnEnergyConsumption()
	{
		float num = 0f;
		foreach (IEnergyGridConsumer consumer in Consumers)
		{
			num += consumer.CurrentEnergyConsumption;
		}
		return num;
	}

	public float ReturnEnergyProduction()
	{
		float num = 0f;
		foreach (IEnergyGridProducer producer in Producers)
		{
			num += producer.Production;
		}
		return num;
	}

	public float ReturnEnergyProductionExcludingProducer(IEnergyGridProducer excludedProducer)
	{
		float num = 0f;
		foreach (IEnergyGridProducer producer in Producers)
		{
			if (producer != excludedProducer)
			{
				num += producer.Production;
			}
		}
		return num;
	}

	public bool ReturnRequiresEnergyFromProducer(IEnergyGridProducer producer)
	{
		if (Storages.Count > 0)
		{
			if (IsFull)
			{
				return false;
			}
			float num = ReturnStorageEnergy();
			float num2 = ReturnStorageCapacity();
			return num / num2 <= producer.EnergyFillPercentage;
		}
		return ReturnEnergyProductionExcludingProducer(producer) < ReturnEnergyRequirement();
	}

	public float ReturnStorageEnergy()
	{
		float num = 0f;
		foreach (IEnergyGridStorage storage in Storages)
		{
			num += storage.EnergyAmount;
		}
		return num;
	}

	public float ReturnStorageCapacity()
	{
		float num = 0f;
		foreach (IEnergyGridStorage storage in Storages)
		{
			num += storage.EnergyCapacity;
		}
		return num;
	}

	public int ReturnNonFullStorageCount()
	{
		int num = 0;
		foreach (IEnergyGridStorage storage in Storages)
		{
			if (!storage.IsFull)
			{
				num++;
			}
		}
		return num;
	}

	public int ReturnAvailableStorageCount()
	{
		int num = 0;
		foreach (IEnergyGridStorage storage in Storages)
		{
			if (!storage.IsEmpty)
			{
				num++;
			}
		}
		return num;
	}

	public void Merge(EnergyGrid other)
	{
		if (other != this)
		{
			for (int num = other.Links.Count - 1; num >= 0; num--)
			{
				other.Links[num].SetEnergyGrid(this);
			}
			EnergyGridManager.RemoveGrid(other);
		}
	}

	public static void Connect(EnergyGridConnector from, EnergyGridConnector to)
	{
		from.Connect(to);
		to.Connect(from);
		from.EnergyGrid.Merge(to.EnergyGrid);
		new EnergyGridConnectionEvent(GameEventType.EnergyGridConnectionAdded, from, to).Dispatch();
	}

	public static void ConnectWithIndex(EnergyGridConnector from, uint fromIndex, EnergyGridConnector to)
	{
		from.Connect(to, fromIndex);
		to.Connect(from);
		from.EnergyGrid.Merge(to.EnergyGrid);
		EnergyGridConnectionEvent.Dispatch(GameEventType.EnergyGridConnectionAdded, from, to);
	}

	public static void Disconnect(EnergyGridConnector componentA, EnergyGridConnector componentB)
	{
		componentA.Disconnect(componentB);
		componentB.Disconnect(componentA);
		if (componentA.EnergyGrid != componentB.EnergyGrid)
		{
			Debug.LogError("Energy grids did not match.");
		}
		componentA.EnergyGrid.UpdateGrids();
		new EnergyGridConnectionEvent(GameEventType.EnergyGridConnectionRemoved, componentA, componentB).Dispatch();
	}

	public static void DisconnectWithIndex(EnergyGridConnector componentA, uint index)
	{
		if (componentA.TryGetConnectedComponent(out var connectedComponent, index))
		{
			Disconnect(componentA, connectedComponent);
		}
	}
}
