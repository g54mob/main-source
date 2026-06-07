using System.Collections.Generic;
using Factory;
using FixMath;
using JetBrains.Annotations;
using Motorways.Utility;

namespace Motorways
{
	public class BoatPathTileAtlas
	{
		private readonly Dictionary<BoatPathTileConnection, BoatPathTileDefinition> _connectionToDefinition = new Dictionary<BoatPathTileConnection, BoatPathTileDefinition>();

		private readonly List<BoatPathTileDefinition> _indexToDefinition = new List<BoatPathTileDefinition>();

		[Dependency]
		private IScope _scope;

		private const int MaxDirectionChange = 2;

		public void Initialize()
		{
			TileDirection[] directions = TileUtilities.Directions;
			foreach (TileDirection tileDirection in directions)
			{
				for (int j = -2; j <= 2; j++)
				{
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(TileUtilities.GetRotatedDirection(tileDirection, j));
					BoatPathTileConnection connection = new BoatPathTileConnection(tileDirection, oppositeDirection);
					BoatPathTileDefinition definition = CreateDefinition(connection);
					AddDefinition(connection, definition);
				}
				BoatPathTileConnection connection2 = new BoatPathTileConnection(tileDirection, TileDirection.None);
				AddDefinition(connection2, CreateDefinition(connection2));
				connection2 = new BoatPathTileConnection(TileDirection.None, tileDirection);
				AddDefinition(connection2, CreateDefinition(connection2));
			}
		}

		[CanBeNull]
		public BoatPathTileDefinition GetDefinition(BoatPathTileConnection connection)
		{
			if (_connectionToDefinition.TryGetValue(connection, out var value))
			{
				return value;
			}
			Diagnostics.FailAssert($"Couldn't find BoatPathTileDefinition for {connection}");
			return null;
		}

		[NotNull]
		private BoatPathTileDefinition CreateDefinition(BoatPathTileConnection connection)
		{
			BoatPathTileDefinition boatPathTileDefinition = null;
			for (int i = 1; i <= 3; i++)
			{
				RoadTileRotation roadTileRotation = (RoadTileRotation)i;
				BoatPathTileConnection rotatedConnection = connection.GetRotatedConnection(roadTileRotation);
				if (_connectionToDefinition.TryGetValue(rotatedConnection, out var value))
				{
					boatPathTileDefinition = value.CreateRotatedDefinition(_scope, TileUtilities.SubtractRotation(RoadTileRotation.None, roadTileRotation));
				}
				if (boatPathTileDefinition != null)
				{
					return boatPathTileDefinition;
				}
			}
			RoadTilePath roadTilePath = _scope.Get<RoadTilePath>();
			Vector2Fixed tileEdgeForDirection = TileUtilities.GetTileEdgeForDirection(connection.input);
			Vector2Fixed tileEdgeForDirection2 = TileUtilities.GetTileEdgeForDirection(connection.output);
			if (connection.IsDeadEnd || connection.output == TileUtilities.GetOppositeDirection(connection.input))
			{
				roadTilePath.pathPieces.Add(RoadTilePath.Piece.Create(_scope, new List<Vector2Fixed> { tileEdgeForDirection, tileEdgeForDirection2 }));
			}
			else
			{
				Fix64 oneHalf = Fix64Consts.OneHalf;
				Vector2Fixed inH = tileEdgeForDirection - TileUtilities.GetVectorFixedForDirection(connection.input) * oneHalf;
				Vector2Fixed outH = tileEdgeForDirection2 - TileUtilities.GetVectorFixedForDirection(connection.output) * oneHalf;
				Spline.BezierSplineFixed bezierSplineFixed = new Spline.BezierSplineFixed(tileEdgeForDirection, inH, outH, tileEdgeForDirection2);
				roadTilePath.pathPieces.Add(RoadTilePath.Piece.Create(_scope, bezierSplineFixed.Rasterize(10)));
			}
			boatPathTileDefinition = _scope.Get<BoatPathTileDefinition>();
			boatPathTileDefinition.rotation = RoadTileRotation.None;
			boatPathTileDefinition.path = roadTilePath;
			return boatPathTileDefinition;
		}

		private void AddDefinition(BoatPathTileConnection connection, BoatPathTileDefinition definition)
		{
			_connectionToDefinition.Add(connection, definition);
			definition.index = _indexToDefinition.Count;
			_indexToDefinition.Add(definition);
		}
	}
}
