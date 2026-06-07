using System.Collections.Generic;
using System.Linq;
using Factory;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways
{
	public class AddRoundaboutEdit : TileEdit
	{
		private Vector2Int _originCoordinates;

		private int _concreteToMothball;

		private int _concreteToRelease;

		private bool _isReplacingMothballedRoundabout;

		private List<AdjacentTileConnection> _replacedConnections;

		[Dependency]
		private IScope _scope;

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			foreach (Vector2Int coordinatesOffset in Roundabout.GetCoordinatesOffsets())
			{
				yield return tilemap.GetOrCreateTile(_originCoordinates + coordinatesOffset);
			}
			foreach (Vector2Int neighborCoordinatesOffset in Roundabout.GetNeighborCoordinatesOffsets())
			{
				Tile tile = tilemap.GetTile(_originCoordinates + neighborCoordinatesOffset);
				if (tile != null)
				{
					yield return tile;
				}
			}
			yield return tilemap.GetOrCreateTile(_originCoordinates + Roundabout.GetCenterOffset());
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			Vector2Int vector2Int = tile.Coordinates - _originCoordinates;
			if (Roundabout.IsCoordinatesOffsetInRoundabout(vector2Int))
			{
				return tile.SetRoundaboutState(Roundabout.GetConnectionForCoordinatesOffset(vector2Int), _isReplacingMothballedRoundabout ? RoadState.Active : RoadState.Planned);
			}
			TileDirectionBitfield.Enumerator enumerator;
			if (tile.Coordinates == _originCoordinates)
			{
				tile.IsCenterOfRoundabout = true;
				if (_isReplacingMothballedRoundabout)
				{
					enumerator = tile.GetTwoLaneRoads(RoadState.ActiveOrPending).GetEnumerator();
					while (enumerator.MoveNext())
					{
						TileDirection current = enumerator.Current;
						tile.SetNodeState(new RoadTileNode(current), RoadState.Mothballed);
					}
				}
			}
			enumerator = Roundabout.GetInvalidNodeDirectionsForNeighbor(vector2Int).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current2 = enumerator.Current;
				if ((tile.GetTwoLaneRoadStateInDirection(current2) & RoadState.ActiveOrPending) != RoadState.None)
				{
					tile.SetNodeState(new RoadTileNode(current2), RoadState.Mothballed);
				}
			}
			return true;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			if (_concreteToMothball > 0)
			{
				upgradeDatabase.MothballUpgrade(UpgradeType.Concrete, _concreteToMothball);
			}
			if (_concreteToRelease > 0)
			{
				upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Concrete, _concreteToRelease);
			}
			if (_isReplacingMothballedRoundabout)
			{
				return upgradeDatabase.UnmothballUpgrade(UpgradeType.Roundabout);
			}
			return upgradeDatabase.ConsumeUpgrade(UpgradeType.Roundabout);
		}

		public override void ApplyToSimulation(ISimulation simulation)
		{
			RoundaboutModel roundaboutModel = null;
			ModelListEnumerator<RoundaboutModel> enumerator = simulation.GetModels<RoundaboutModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				RoundaboutModel current = enumerator.Current;
				if (current.OriginCoordinates == _originCoordinates)
				{
					roundaboutModel = current;
					break;
				}
			}
			if (!_isReplacingMothballedRoundabout && Diagnostics.Verify(roundaboutModel == null))
			{
				RoundaboutModel roundaboutModel2 = _scope.Get<RoundaboutModel>();
				roundaboutModel2.Initialize(_originCoordinates, _replacedConnections);
				simulation.AddModel(roundaboutModel2);
			}
		}

		public override void Reset()
		{
			base.Reset();
			_originCoordinates = default(Vector2Int);
			_concreteToMothball = 0;
			_concreteToRelease = 0;
			_isReplacingMothballedRoundabout = false;
			_replacedConnections = null;
		}

		public static AddRoundaboutEdit Create(IScope scope, Vector2Int originCoordinates, ITilemap tilemap)
		{
			bool roadsBecomePermanentOverTime = scope.Get<City>().Rules.RoadsBecomePermanentOverTime;
			bool flag = false;
			Vector2Int vector2Int = Roundabout.GetCoordinatesOffsets()[0];
			Tile tile = tilemap.GetTile(originCoordinates + vector2Int);
			if (tile != null)
			{
				RoadTileConnection connectionForCoordinatesOffset = Roundabout.GetConnectionForCoordinatesOffset(vector2Int);
				if (tile.HasRoundabout(RoadState.Mothballed) && tile.GetRoundaboutConnection(RoadState.Mothballed).Equals(connectionForCoordinatesOffset))
				{
					flag = true;
				}
			}
			HashSet<AdjacentTileConnection> hashSet = new HashSet<AdjacentTileConnection>();
			HashSet<AdjacentTileConnection> hashSet2 = new HashSet<AdjacentTileConnection>();
			foreach (Vector2Int coordinatesOffset in Roundabout.GetCoordinatesOffsets())
			{
				RoadTileConnection connectionForCoordinatesOffset2 = Roundabout.GetConnectionForCoordinatesOffset(coordinatesOffset);
				Tile tile2 = tilemap.GetTile(originCoordinates + coordinatesOffset);
				if (tile2 == null)
				{
					continue;
				}
				TileDirectionBitfield.Enumerator enumerator2 = tile2.GetTwoLaneRoads(RoadState.ActiveOrPending).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TileDirection current2 = enumerator2.Current;
					if (!Roundabout.CanConnectionAddExitNode(connectionForCoordinatesOffset2, new RoadTileNode(current2)))
					{
						AdjacentTileConnection item = new AdjacentTileConnection(tile2.Coordinates, current2);
						hashSet.Add(item);
						if (tile2.IsNodePermanent(current2) && roadsBecomePermanentOverTime)
						{
							hashSet2.Add(item);
						}
					}
				}
			}
			int num = 0;
			int concreteToRelease = 0;
			if (hashSet.Any())
			{
				GameBehaviourModel gameBehaviourModel = scope.Get<GameBehaviourModel>();
				int num2 = 0;
				foreach (AdjacentTileConnection item2 in hashSet)
				{
					num += gameBehaviourModel.GetConcreteCostForConnection(tilemap, item2.OriginCoordinates, item2.DestinationCoordinates);
				}
				if (flag)
				{
					foreach (AdjacentTileConnection item3 in hashSet2)
					{
						num2 += gameBehaviourModel.GetConcreteCostForConnection(tilemap, item3.OriginCoordinates, item3.DestinationCoordinates);
					}
					concreteToRelease = num - num2;
				}
			}
			Tile tile3 = tilemap.GetTile(originCoordinates);
			if (tile3 != null && roadsBecomePermanentOverTime)
			{
				TileDirectionBitfield.Enumerator enumerator2 = tile3.GetTwoLaneRoads().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TileDirection current5 = enumerator2.Current;
					if (tile3.IsNodePermanent(current5))
					{
						hashSet2.Add(new AdjacentTileConnection(tile3.Coordinates, current5));
					}
				}
			}
			AddRoundaboutEdit addRoundaboutEdit = scope.Get<AddRoundaboutEdit>();
			addRoundaboutEdit._originCoordinates = originCoordinates;
			addRoundaboutEdit._concreteToMothball = num;
			addRoundaboutEdit._concreteToRelease = concreteToRelease;
			addRoundaboutEdit._isReplacingMothballedRoundabout = flag;
			addRoundaboutEdit._replacedConnections = new List<AdjacentTileConnection>(hashSet2);
			return addRoundaboutEdit;
		}
	}
}
