using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnergyGridConnectionVisualizer : SceneBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("_linkPrefab")]
	private EnergyGridConnection _connectionPrefab;

	private readonly List<EnergyGridConnection> _connections = new List<EnergyGridConnection>();

	private void Start()
	{
		GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionAdded, OnConnectionAdded);
		GameEventDispatcher.AddListener(GameEventType.EnergyGridConnectionRemoved, OnConnectionRemoved);
		foreach (EnergyGrid grid in EnergyGridManager.Grids)
		{
			foreach (EnergyGridConnector link in grid.Links)
			{
				if (link.Connections != null)
				{
					EnergyGridConnector[] connections = link.Connections;
					foreach (EnergyGridConnector b in connections)
					{
						AddConnection(link, b);
					}
				}
			}
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionAdded, OnConnectionAdded);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridConnectionRemoved, OnConnectionRemoved);
	}

	private void OnConnectionAdded(GameEvent gameEvent)
	{
		EnergyGridConnectionEvent energyGridConnectionEvent = gameEvent as EnergyGridConnectionEvent;
		AddConnection(energyGridConnectionEvent.ComponentA, energyGridConnectionEvent.ComponentB);
	}

	private void OnConnectionRemoved(GameEvent gameEvent)
	{
		EnergyGridConnectionEvent energyGridConnectionEvent = gameEvent as EnergyGridConnectionEvent;
		RemoveConnection(energyGridConnectionEvent.ComponentA, energyGridConnectionEvent.ComponentB);
	}

	private void RemoveConnection(EnergyGridConnector a, EnergyGridConnector b)
	{
		if (TryReturnConnection(a, b, out var connection))
		{
			_connections.Remove(connection);
			UnityEngine.Object.Destroy(connection.gameObject);
		}
	}

	private void AddConnection(EnergyGridConnector a, EnergyGridConnector b)
	{
		if (!(a == null) && !(b == null) && !TryReturnConnection(a, b, out var _))
		{
			EnergyGridConnection energyGridConnection = UnityEngine.Object.Instantiate(_connectionPrefab);
			energyGridConnection.Initialize(a, b);
			_connections.Add(energyGridConnection);
		}
	}

	private bool TryReturnConnection(EnergyGridConnector a, EnergyGridConnector b, out EnergyGridConnection connection)
	{
		foreach (EnergyGridConnection connection2 in _connections)
		{
			if (connection2.HasConnection(a, b))
			{
				connection = connection2;
				return true;
			}
		}
		connection = null;
		return false;
	}

	public static Mesh GenerateCable(float height)
	{
		int cableSideAmount = GameManager.Settings.BuildableSettings.CableSideAmount;
		float cableSegmentLength = GameManager.Settings.BuildableSettings.CableSegmentLength;
		float cableRadius = GameManager.Settings.BuildableSettings.CableRadius;
		Mesh mesh = new Mesh();
		int num = cableSideAmount;
		int num2 = (int)(height / cableSegmentLength);
		num2 = Mathf.Clamp(num2, 1, num2);
		float num3 = height / (float)num2;
		int num4 = num * (num2 + 1);
		Vector3[] array = new Vector3[num4];
		Vector2[] array2 = new Vector2[num4];
		Color[] array3 = new Color[num4];
		int[] array4 = new int[num * num2 * 6];
		float num5 = MathF.PI * 2f / (float)cableSideAmount;
		float num6 = 0f;
		for (int i = 0; i <= num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				num6 = (float)j * num5;
				int num7 = i * num;
				array[num7 + j] = new Vector3(cableRadius * Mathf.Sin(num6), cableRadius * Mathf.Cos(num6), (float)i * num3 - height / 2f);
				array2[num7 + j] = Vector3.one * i;
				float num8 = Mathf.Clamp(Mathf.Sin(MathF.PI * ((float)i / (float)num2)), 0f, 1f);
				array3[num7 + j] = new Color(num8, num8, num8, 1f);
				if (i != num2)
				{
					int num9 = num * 6 * i + j * 6;
					array4[num9] = num7 + j;
					array4[num9 + 1] = num7 + j + cableSideAmount;
					array4[num9 + 2] = num7 + (j + 1) % cableSideAmount + cableSideAmount;
					array4[num9 + 3] = num7 + j;
					array4[num9 + 4] = num7 + (j + 1) % cableSideAmount + cableSideAmount;
					array4[num9 + 5] = num7 + (j + 1) % cableSideAmount;
				}
			}
		}
		mesh.vertices = array;
		mesh.uv = array2;
		mesh.triangles = array4;
		mesh.colors = array3;
		mesh.RecalculateNormals();
		return mesh;
	}
}
