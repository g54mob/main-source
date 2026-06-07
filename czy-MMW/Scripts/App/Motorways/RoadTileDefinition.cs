using System.Collections.Generic;
using Factory;
using Factory.Pools;
using UnityEngine;

namespace Motorways
{
	[Serializable(1)]
	public class RoadTileDefinition : IReusable, IReleasedFromScopeHandler
	{
		public int index = -1;

		public RoadTileMesh mesh;

		public RoadTileRotation rotation;

		public readonly Dictionary<RoadTileConnection, RoadTilePath> connectionToPath = new Dictionary<RoadTileConnection, RoadTilePath>(new RoadTileConnection.MotorwayAgnosticEqualityComparer());

		public Vector2 interactionCircleOffset = Vector2.zero;

		public Vector2[] trafficLightOffsets;

		public bool CanExport
		{
			get
			{
				if (connectionToPath != null && rotation == RoadTileRotation.None && connectionToPath.Count > 0)
				{
					return connectionToPath.Count <= 2;
				}
				return false;
			}
		}

		public RoadTilePath GetPath(RoadTileConnection connection)
		{
			if (connectionToPath.TryGetValue(connection, out var value))
			{
				return value;
			}
			return null;
		}

		public RoadTileDefinition CreateRotatedDefinition(IScope scope, RoadTileRotation newRotation)
		{
			RoadTileDefinition roadTileDefinition = scope.Get<RoadTileDefinition>();
			roadTileDefinition.mesh = mesh;
			roadTileDefinition.rotation = newRotation;
			RoadTileRotation roadTileRotation = TileUtilities.SubtractRotation(newRotation, rotation);
			foreach (KeyValuePair<RoadTileConnection, RoadTilePath> item in connectionToPath)
			{
				RoadTileConnection rotatedConnection = item.Key.GetRotatedConnection(roadTileRotation);
				RoadTilePath value = item.Value.CreateRotatedPath(roadTileRotation);
				roadTileDefinition.connectionToPath.Add(rotatedConnection, value);
			}
			return roadTileDefinition;
		}

		public override string ToString()
		{
			if (connectionToPath.Count == 0)
			{
				return "RoadTileDefinition[]";
			}
			List<string> list = new List<string>();
			foreach (KeyValuePair<RoadTileConnection, RoadTilePath> item in connectionToPath)
			{
				list.Add(item.Key.ToString());
			}
			return "RoadTileDefinition[" + string.Join(", ", list) + "]";
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (RoadTilePath value in connectionToPath.Values)
			{
				scope.Release(value);
			}
			connectionToPath.Clear();
		}

		public void Reset()
		{
			index = -1;
			mesh = null;
			rotation = RoadTileRotation.None;
			connectionToPath.Clear();
		}
	}
}
