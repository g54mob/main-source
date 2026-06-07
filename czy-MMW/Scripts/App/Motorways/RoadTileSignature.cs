using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;

namespace Motorways
{
	[Factory.Serializable(1)]
	public class RoadTileSignature : IComparable<RoadTileSignature>, IReusable, IDisposable
	{
		public class MotorwayAgnosticEqualityComparer : EqualityComparer<RoadTileSignature>
		{
			public override bool Equals(RoadTileSignature signature1, RoadTileSignature signature2)
			{
				if (signature1 == null && signature2 == null)
				{
					return true;
				}
				if (signature1 == null || signature2 == null)
				{
					return false;
				}
				int count = signature1._connections.Count;
				if (count != signature2._connections.Count)
				{
					return false;
				}
				for (int i = 0; i < count; i++)
				{
					if (!signature1._connections[i].Equals(signature2._connections[i], TreatMotorwaysAs.TwoLaneRoads))
					{
						return false;
					}
				}
				return true;
			}

			public override int GetHashCode(RoadTileSignature signature)
			{
				int num = 0;
				foreach (RoadTileConnection connection in signature._connections)
				{
					num ^= connection.GetHashCode(TreatMotorwaysAs.TwoLaneRoads);
				}
				return num;
			}
		}

		[Dependency]
		private IScope _scope;

		private readonly List<RoadTileConnection> _connections = new List<RoadTileConnection>();

		private readonly List<RoadTileNode> _inputNodes = new List<RoadTileNode>();

		private readonly List<RoadTileNode> _outputNodes = new List<RoadTileNode>();

		private TileDirectionBitfield _connectionDirections = TileDirectionBitfield.None;

		public bool IsEmpty => _connections.Count == 0;

		public IEnumerable<RoadTileConnection> Connections => _connections;

		public TileDirectionBitfield ConnectionDirections => _connectionDirections;

		public bool IsDeadEnd
		{
			get
			{
				if (_connections.Count == 1)
				{
					return _connections[0].IsUTurn;
				}
				return false;
			}
		}

		public bool IsRoundaboutCorner
		{
			get
			{
				foreach (RoadTileConnection connection in _connections)
				{
					if (connection.input.type == RoadType.Roundabout && connection.output.type == RoadType.Roundabout && connection.input.direction != TileUtilities.GetOppositeDirection(connection.output.direction))
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool AddNode(RoadTileNode newNode)
		{
			if (!Diagnostics.Verify(newNode.type == RoadType.TwoLane || newNode.type == RoadType.Driveway || newNode.type == RoadType.Motorway, "Unable to add non-TwoLane roads."))
			{
				return false;
			}
			if (_inputNodes.Contains(newNode) || _outputNodes.Contains(newNode))
			{
				return false;
			}
			if (_inputNodes.Count == 0 && _outputNodes.Count == 0)
			{
				AddConnection(new RoadTileConnection(newNode, newNode));
				return true;
			}
			_inputNodes.Add(newNode);
			_outputNodes.Add(newNode);
			if (IsDeadEnd)
			{
				_connections.RemoveAt(0);
			}
			foreach (RoadTileNode inputNode in _inputNodes)
			{
				if (!inputNode.Equals(newNode))
				{
					AddConnection(new RoadTileConnection(inputNode, newNode));
				}
			}
			foreach (RoadTileNode outputNode in _outputNodes)
			{
				if (!outputNode.Equals(newNode))
				{
					AddConnection(new RoadTileConnection(newNode, outputNode));
				}
			}
			return true;
		}

		public bool HasInputNode(RoadTileNode node)
		{
			foreach (RoadTileNode inputNode in _inputNodes)
			{
				if (inputNode.Equals(node))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasOutputNode(RoadTileNode node)
		{
			foreach (RoadTileNode outputNode in _outputNodes)
			{
				if (outputNode.Equals(node))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasNode(RoadTileNode node)
		{
			if (!HasInputNode(node))
			{
				return HasOutputNode(node);
			}
			return true;
		}

		public void AddConnection(RoadTileConnection connection)
		{
			int i;
			for (i = 0; i < _connections.Count && _connections[i].CompareTo(connection) < 0; i++)
			{
			}
			_connections.Insert(i, connection);
			if (!HasInputNode(connection.input))
			{
				_inputNodes.Add(connection.input);
			}
			if (!HasOutputNode(connection.output))
			{
				_outputNodes.Add(connection.output);
			}
			_connectionDirections[connection.input.direction] = true;
			_connectionDirections[connection.output.direction] = true;
		}

		public bool HasConnection(RoadTileConnection connection)
		{
			return _connections.Contains(connection);
		}

		public IEnumerable<RoadTileConnection> GetConnectionsToDirection(TileDirection direction)
		{
			foreach (RoadTileConnection connection in _connections)
			{
				if (connection.input.direction == direction || connection.output.direction == direction)
				{
					yield return connection;
				}
			}
		}

		public void Reset()
		{
			_connections.Clear();
			_inputNodes.Clear();
			_outputNodes.Clear();
			_connectionDirections = TileDirectionBitfield.None;
		}

		public RoadTileSignature CreateRotatedSignature(RoadTileRotation rotation, IScope context)
		{
			if (rotation == RoadTileRotation.None)
			{
				return this;
			}
			RoadTileSignature roadTileSignature = context.Get<RoadTileSignature>();
			foreach (RoadTileConnection connection in _connections)
			{
				roadTileSignature.AddConnection(connection.GetRotatedConnection(rotation));
			}
			return roadTileSignature;
		}

		public int CompareTo(RoadTileSignature otherSignature)
		{
			if (_connections.Count != otherSignature._connections.Count)
			{
				return _connections.Count - otherSignature._connections.Count;
			}
			for (int i = 0; i < _connections.Count; i++)
			{
				int num = _connections[i].CompareTo(otherSignature._connections[i]);
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RoadTileSignature otherSignature))
			{
				return false;
			}
			return CompareTo(otherSignature) == 0;
		}

		public override int GetHashCode()
		{
			int num = 0;
			foreach (RoadTileConnection connection in _connections)
			{
				num ^= connection.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			if (_connections.Count == 0)
			{
				return "RoadTileSignature";
			}
			List<string> list = new List<string>();
			foreach (RoadTileConnection connection in Connections)
			{
				list.Add(connection.ToString());
			}
			return string.Format("RoadTileSignature[Connections={0}]", string.Join(", ", list));
		}

		public void Dispose()
		{
			_scope.Release(this);
		}
	}
}
