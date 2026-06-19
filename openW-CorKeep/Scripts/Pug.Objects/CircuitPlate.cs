using System.Collections.Generic;
using UnityEngine;

public class CircuitPlate : MonoBehaviour
{
	public bool circuitIsActive;

	public Dictionary<CircuitPlate, bool> connections;

	public void UpdateConnection(CircuitPlate circuitPlate, HashSet<CircuitPlate> updatedCircuitPlates)
	{
		if (updatedCircuitPlates.Contains(this))
		{
			return;
		}
		circuitIsActive = false;
		foreach (KeyValuePair<CircuitPlate, bool> connection in connections)
		{
			_ = connection;
			if (circuitPlate.connections[this])
			{
				circuitIsActive = true;
				break;
			}
		}
		foreach (KeyValuePair<CircuitPlate, bool> connection2 in connections)
		{
			if (connection2.Value != circuitIsActive)
			{
				connections[connection2.Key] = circuitIsActive;
				updatedCircuitPlates.Add(this);
				connection2.Key.UpdateConnection(this, updatedCircuitPlates);
			}
		}
	}

	public void AddConnection(CircuitPlate circuitPlate)
	{
		if (!connections.ContainsKey(circuitPlate))
		{
			connections.Add(circuitPlate, circuitIsActive);
			circuitPlate.connections.Add(this, circuitPlate.circuitIsActive);
			if (circuitPlate.circuitIsActive)
			{
				circuitIsActive = true;
			}
		}
		UpdateConnection(circuitPlate, new HashSet<CircuitPlate> { this });
	}

	public void RemoveConnection()
	{
		circuitIsActive = false;
		UpdateConnection(this, new HashSet<CircuitPlate> { this });
		foreach (CircuitPlate key in connections.Keys)
		{
			key.connections.Remove(this);
		}
	}
}
