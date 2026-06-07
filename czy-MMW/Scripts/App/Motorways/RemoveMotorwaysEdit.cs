using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class RemoveMotorwaysEdit : TileEdit
	{
		[Serialize(true, null)]
		public Vector2Int Coordinates { get; private set; }

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			Tile tile = tilemap.GetTile(Coordinates);
			if (tile == null)
			{
				yield break;
			}
			TileDirectionBitfield motorwayRamps = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active);
			if (motorwayRamps.Count <= 0)
			{
				yield break;
			}
			List<Vector2Int> connectedTiles = new List<Vector2Int>();
			TileDirectionBitfield.Enumerator enumerator = motorwayRamps.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				int motorwayInDirection = tile.GetMotorwayInDirection(current, RoadState.Planned | RoadState.Active);
				TileEdit.Log.Info("Traversing motorway {0} in direction {1} from clearing tile.", motorwayInDirection, current);
				Motorway motorway = tilemap.GetMotorway(motorwayInDirection);
				if (Diagnostics.Verify(motorway != null, "Unable to find expected motorway {0}.", motorwayInDirection))
				{
					Vector2Int vector2Int = ((motorway.StartCoordinates == tile.Coordinates) ? motorway.EndCoordinates : motorway.StartCoordinates);
					if (!connectedTiles.Contains(vector2Int))
					{
						TileEdit.Log.Info("Returning {0} as an affected tile from clearing tile {1}.", vector2Int, Coordinates);
						connectedTiles.Add(vector2Int);
						yield return tilemap.GetTile(vector2Int);
					}
				}
			}
			yield return tile;
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			Tile.Log.Info("Applying RemoveMotorwayEdit from tile {0}, to tile {1}.", Coordinates, tile.Coordinates);
			TileDirectionBitfield.Enumerator enumerator;
			if (tile.Coordinates.Equals(Coordinates))
			{
				enumerator = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active).GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					int motorwayInDirection = tile.GetMotorwayInDirection(current, RoadState.Planned | RoadState.Active);
					tile.SetNodeState(new RoadTileNode(current, RoadType.Motorway, motorwayInDirection), RoadState.Mothballed);
				}
				return true;
			}
			TileEdit.Log.Info("Mothballing motorway connections between {0} and non-adjacent tile {1}.", Coordinates, tile.Coordinates);
			enumerator = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current2 = enumerator.Current;
				int motorwayInDirection2 = tile.GetMotorwayInDirection(current2, RoadState.Planned | RoadState.Active);
				Motorway motorway = tile.Tilemap.GetMotorway(motorwayInDirection2);
				if (Diagnostics.Verify(motorway != null, "Unable to find motorway {0}.", motorwayInDirection2) && (motorway.StartCoordinates == Coordinates || motorway.EndCoordinates == Coordinates))
				{
					TileEdit.Log.Info("Mothballing node for motorway {0}.", motorwayInDirection2);
					Diagnostics.Verify(tile.SetNodeState(new RoadTileNode(current2, RoadType.Motorway, motorwayInDirection2), RoadState.Mothballed), "Failed to mothball node on motorway {0}, connected to cleared tile {1}.", motorwayInDirection2, Coordinates);
				}
			}
			return true;
		}

		public override IEnumerable<Motorway> GetAffectedMotorways(ITilemap tilemap)
		{
			Tile tile = tilemap.GetTile(Coordinates);
			if (tile == null)
			{
				yield break;
			}
			TileDirectionBitfield.Enumerator enumerator = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				int motorwayInDirection = tile.GetMotorwayInDirection(current, RoadState.Planned | RoadState.Active);
				Motorway motorway = tilemap.GetMotorway(motorwayInDirection);
				if (Diagnostics.Verify(motorway != null, "Unable to find motorway from ID {0}", motorwayInDirection))
				{
					yield return motorway;
				}
			}
		}

		public override bool ApplyToAffectedMotorway(Motorway motorway)
		{
			motorway.SetState(RoadState.Mothballed);
			return true;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			int num = 0;
			foreach (Motorway affectedMotorway in GetAffectedMotorways(tilemap))
			{
				num += affectedMotorway.ConcreteCost;
			}
			upgradeDatabase.MothballUpgrade(UpgradeType.Concrete, num);
			return true;
		}

		public override void Reset()
		{
			base.Reset();
			Coordinates = default(Vector2Int);
		}

		public static RemoveMotorwaysEdit Create(IScope scope, Vector2Int coordinates)
		{
			RemoveMotorwaysEdit removeMotorwaysEdit = scope.Get<RemoveMotorwaysEdit>();
			removeMotorwaysEdit.Coordinates = coordinates;
			return removeMotorwaysEdit;
		}
	}
}
