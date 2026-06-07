using System.Collections.Generic;
using Factory;
using FixMath;
using JetBrains.Annotations;
using Motorways.Utility;

namespace Motorways
{
	public class RailTileAtlas
	{
		private readonly Dictionary<RailTileConnection, RailTileDefinition> _connectionToDefinition = new Dictionary<RailTileConnection, RailTileDefinition>();

		private readonly List<RailTileDefinition> _indexToDefinition = new List<RailTileDefinition>();

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
					RailTileConnection connection = new RailTileConnection(tileDirection, oppositeDirection);
					RailTileDefinition definition = CreateDefinition(connection);
					AddDefinition(connection, definition);
				}
				RailTileConnection connection2 = new RailTileConnection(tileDirection, TileDirection.None);
				AddDefinition(connection2, CreateDefinition(connection2));
				connection2 = new RailTileConnection(TileDirection.None, tileDirection);
				AddDefinition(connection2, CreateDefinition(connection2));
			}
		}

		[CanBeNull]
		public RailTileDefinition GetDefinition(RailTileConnection connection)
		{
			if (_connectionToDefinition.TryGetValue(connection, out var value))
			{
				return value;
			}
			Diagnostics.FailAssert($"Couldn't find RailTileDefinition for {connection}");
			return null;
		}

		[NotNull]
		private RailTileDefinition CreateDefinition(RailTileConnection connection)
		{
			RailTileDefinition railTileDefinition = null;
			for (int i = 1; i <= 3; i++)
			{
				RoadTileRotation roadTileRotation = (RoadTileRotation)i;
				RailTileConnection rotatedConnection = connection.GetRotatedConnection(roadTileRotation);
				if (_connectionToDefinition.TryGetValue(rotatedConnection, out var value))
				{
					railTileDefinition = value.CreateRotatedDefinition(_scope, TileUtilities.SubtractRotation(RoadTileRotation.None, roadTileRotation));
				}
				if (railTileDefinition != null)
				{
					return railTileDefinition;
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
			railTileDefinition = _scope.Get<RailTileDefinition>();
			railTileDefinition.rotation = RoadTileRotation.None;
			railTileDefinition.path = roadTilePath;
			return railTileDefinition;
		}

		private void AddDefinition(RailTileConnection connection, RailTileDefinition definition)
		{
			_connectionToDefinition.Add(connection, definition);
			definition.index = _indexToDefinition.Count;
			_indexToDefinition.Add(definition);
		}
	}
}
