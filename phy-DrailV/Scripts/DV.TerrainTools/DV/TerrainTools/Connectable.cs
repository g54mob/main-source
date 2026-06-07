using System;
using UnityEngine;

namespace DV.TerrainTools
{
	public class Connectable : Point
	{
		public ConnectablePrefab prefab;

		public int NumConnectors => prefab.connectors.Length;

		public bool IsValidConnector(int connectorIndex)
		{
			if (connectorIndex >= 0)
			{
				return connectorIndex < NumConnectors;
			}
			return false;
		}

		public Transform GetConnector(int connectorIndex)
		{
			if (!IsValidConnector(connectorIndex))
			{
				throw new ArgumentOutOfRangeException("connectorIndex");
			}
			return prefab.connectors[connectorIndex];
		}

		public (Vector3 position, Quaternion rotation) GetConnectorWorldSpaceInfo(int connectorIndex)
		{
			Transform connector = GetConnector(connectorIndex);
			Vector3 item = base.transform.TransformPoint(connector.position);
			Quaternion item2 = base.transform.rotation * connector.rotation;
			return (position: item, rotation: item2);
		}
	}
}
