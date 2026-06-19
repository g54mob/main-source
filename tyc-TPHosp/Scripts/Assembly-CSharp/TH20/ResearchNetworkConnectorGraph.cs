using System.Collections.Generic;

namespace TH20
{
	public class ResearchNetworkConnectorGraph
	{
		private class Item
		{
			public int SourceNodeID;

			public int TargetNodeID;

			public int ConnectorItemID;
		}

		private readonly Dictionary<int, List<Item>> _connectorGraph = new Dictionary<int, List<Item>>();

		public void AddConnection(int sourceNodeId, int targetNodeId, int connectorItemId)
		{
			if (!_connectorGraph.TryGetValue(sourceNodeId, out var value))
			{
				value = new List<Item>();
				_connectorGraph.Add(sourceNodeId, value);
			}
			value.Add(new Item
			{
				SourceNodeID = sourceNodeId,
				TargetNodeID = targetNodeId,
				ConnectorItemID = connectorItemId
			});
		}

		public void ClearConnections()
		{
			_connectorGraph.Clear();
		}

		public bool GetConnectorInfo(int connectorId, out int sourceNodeId, out int targetNodeId)
		{
			foreach (KeyValuePair<int, List<Item>> item in _connectorGraph)
			{
				foreach (Item item2 in item.Value)
				{
					if (item2.ConnectorItemID == connectorId)
					{
						sourceNodeId = item2.SourceNodeID;
						targetNodeId = item2.TargetNodeID;
						return true;
					}
				}
			}
			sourceNodeId = -1;
			targetNodeId = -1;
			return false;
		}

		public bool GetConnectorID(int sourceNodeId, int targetNodeId, out int connectorId)
		{
			if (!_connectorGraph.TryGetValue(sourceNodeId, out var value))
			{
				connectorId = -1;
				return false;
			}
			foreach (Item item in value)
			{
				if (item.SourceNodeID == sourceNodeId && item.TargetNodeID == targetNodeId)
				{
					connectorId = item.ConnectorItemID;
					return true;
				}
			}
			connectorId = -1;
			return false;
		}
	}
}
