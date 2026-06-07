using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SimulationFlow
	{
		public readonly IReadOnlyList<SimComponent> OrderedSimComps;

		public readonly IReadOnlyList<Port> AllPorts;

		public readonly IReadOnlyList<Fuse> AllFuses;

		private readonly ReadOnlyDictionary<string, Port> fullPortIdToPort;

		private readonly ReadOnlyDictionary<string, Fuse> fullFuseIdToFuse;

		private readonly GameObject simGO;

		public event Action TickEvent;

		public SimulationFlow(SimConnectionDefinition connectionDef, SimGameParams gameParams)
		{
			simGO = connectionDef.gameObject;
			Dictionary<string, Port> dictionary = new Dictionary<string, Port>();
			Dictionary<string, Fuse> dictionary2 = new Dictionary<string, Fuse>();
			Dictionary<string, PortReference> dictionary3 = new Dictionary<string, PortReference>();
			List<SimComponent> list = new List<SimComponent>(connectionDef.executionOrder.Length);
			SimComponentDefinition[] executionOrder = connectionDef.executionOrder;
			for (int i = 0; i < executionOrder.Length; i++)
			{
				SimComponent simComponent = executionOrder[i].InstantiateImplementation();
				list.Add(simComponent);
				foreach (Port allPort in simComponent.GetAllPorts())
				{
					dictionary.Add(allPort.id, allPort);
				}
				foreach (Fuse allFuse in simComponent.GetAllFuses())
				{
					dictionary2.Add(allFuse.id, allFuse);
				}
				foreach (PortReference allPortReference in simComponent.GetAllPortReferences())
				{
					dictionary3.Add(allPortReference.id, allPortReference);
				}
				simComponent.SetGameParams(gameParams);
			}
			OrderedSimComps = list;
			AllPorts = new List<Port>(dictionary.Values);
			AllFuses = new List<Fuse>(dictionary2.Values);
			fullPortIdToPort = new ReadOnlyDictionary<string, Port>(dictionary);
			fullFuseIdToFuse = new ReadOnlyDictionary<string, Fuse>(dictionary2);
			Connection[] connections = connectionDef.connections;
			foreach (Connection connection in connections)
			{
				if (!dictionary.TryGetValue(connection.fullPortIdOut, out var value))
				{
					Debug.LogError("SimulationFlow: " + connection.fullPortIdOut + " -> " + connection.fullPortIdIn + " could not find " + connection.fullPortIdOut);
					continue;
				}
				if (value.type != PortType.OUT)
				{
					Debug.LogError($"SimulationFlow: {connection.fullPortIdOut} -> {connection.fullPortIdIn} source has type {value.type} where an output port is expected");
					continue;
				}
				if (connection.fullPortIdIn == "-EMPTY-")
				{
					Debug.Log("SimulationFlow: output port " + connection.fullPortIdOut + " is connected to -EMPTY-");
					continue;
				}
				if (!dictionary.TryGetValue(connection.fullPortIdIn, out var value2))
				{
					Debug.LogError("SimulationFlow: " + connection.fullPortIdOut + " -> " + connection.fullPortIdIn + " could not find " + connection.fullPortIdIn);
					continue;
				}
				if (value2.type != PortType.IN)
				{
					Debug.LogError($"SimulationFlow: {connection.fullPortIdOut} -> {connection.fullPortIdIn} destination has type {value2.type} where an input port is expected");
					continue;
				}
				if (value.valueType != value2.valueType)
				{
					Debug.LogWarning($"SimulationFlow: {connection.fullPortIdOut} of value type {value.valueType} does not match {connection.fullPortIdIn} of value type {value2.valueType}");
				}
				value.ConnectPort(value2);
			}
			PortReferenceConnection[] portReferenceConnections = connectionDef.portReferenceConnections;
			foreach (PortReferenceConnection portReferenceConnection in portReferenceConnections)
			{
				if (dictionary3.TryGetValue(portReferenceConnection.portReferenceId, out var value3))
				{
					if (dictionary.TryGetValue(portReferenceConnection.portId, out var value4))
					{
						value3.SetPortReference(value4);
					}
				}
				else
				{
					Debug.LogError("Unexpected state: Couldn't find port reference with id " + portReferenceConnection.portReferenceId + ". Skipping setup.");
				}
			}
			for (int j = 0; j < OrderedSimComps.Count; j++)
			{
				SimComponent simComponent2 = OrderedSimComps[j];
				foreach (FuseReference allFuseReference in simComponent2.GetAllFuseReferences())
				{
					if (TryGetFuse(allFuseReference.fuseId, out var fuse))
					{
						allFuseReference.SetFuse(fuse);
					}
					else
					{
						Debug.LogError("Component " + simComponent2.id + " could not find fuse with ID " + allFuseReference.fuseId);
					}
				}
				simComponent2.InitializationAfterConnecting();
			}
		}

		public bool TryGetPort(string portId, out Port port, bool canBeNullOrEmpty = false)
		{
			port = null;
			if (string.IsNullOrEmpty(portId))
			{
				if (!canBeNullOrEmpty)
				{
					Debug.LogError(((simGO.transform.parent != null) ? (simGO.transform.parent.name + ".") : string.Empty) + simGO.name + ": portId is null or empty!");
				}
				return false;
			}
			if (fullPortIdToPort.TryGetValue(portId, out port))
			{
				return true;
			}
			string text = ((simGO.transform.parent != null) ? (simGO.transform.parent.name + ".") : string.Empty);
			Debug.LogError(text + simGO.name + ": Port[" + portId + "] not defined!");
			return false;
		}

		public bool TryGetFuse(string fuseId, out Fuse fuse, bool canBeNull = false)
		{
			fuse = null;
			if (string.IsNullOrEmpty(fuseId))
			{
				if (!canBeNull)
				{
					Debug.LogError(((simGO.transform.parent != null) ? (simGO.transform.parent.name + ".") : string.Empty) + simGO.name + ": fuseId is null or empty!");
				}
				return false;
			}
			if (fullFuseIdToFuse.TryGetValue(fuseId, out fuse))
			{
				return true;
			}
			string text = ((simGO.transform.parent != null) ? (simGO.transform.parent.name + ".") : string.Empty);
			Debug.LogError(text + simGO.name + ": Fuse[" + fuseId + "] not defined!");
			return false;
		}

		public void Tick(float delta)
		{
			for (int i = 0; i < OrderedSimComps.Count; i++)
			{
				OrderedSimComps[i].Tick(delta);
			}
			this.TickEvent?.Invoke();
		}

		public JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			for (int i = 0; i < OrderedSimComps.Count; i++)
			{
				SimComponent simComponent = OrderedSimComps[i];
				JObject saveStateData = simComponent.GetSaveStateData();
				if (saveStateData != null)
				{
					jObject.SetJObject(simComponent.id, saveStateData);
				}
			}
			return jObject;
		}

		public void SetSaveStateData(JObject savedData)
		{
			for (int i = 0; i < OrderedSimComps.Count; i++)
			{
				SimComponent simComponent = OrderedSimComps[i];
				if (simComponent.HasSaveData)
				{
					JObject jObject = savedData.GetJObject(simComponent.id);
					if (jObject != null)
					{
						simComponent.SetSaveStateData(jObject);
					}
					else
					{
						Debug.LogError("Unexpected state: Missing save data for '" + simComponent.id + "' component, skipping.");
					}
				}
			}
		}
	}
}
