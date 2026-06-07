using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class RemoveUnbuiltMotorwaysEdit : TileEdit
	{
		[Serialize(true, null)]
		public Vector2Int Coordinates { get; private set; }

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			Tile tile = tilemap.GetTile(Coordinates);
			if (tile != null)
			{
				yield return tile;
			}
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			Tile.Log.Info("Applying RemoveMotorwayEdit from tile {0}, to tile {1}.", Coordinates, tile.Coordinates);
			if (tile.Coordinates.Equals(Coordinates))
			{
				if (tile.UnbuiltMotorwayId != -1)
				{
					tile.UnbuiltMotorwayId = -1;
					tile.UnbuiltMotorwayNumber = 0;
					Tile.Log.Info("Removed unbuilt motorway.");
					return true;
				}
				return true;
			}
			return false;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			upgradeDatabase.MothballUpgrade(UpgradeType.Motorway);
			upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.Motorway);
			return true;
		}

		public static RemoveUnbuiltMotorwaysEdit Create(IScope scope, Vector2Int coordinates)
		{
			RemoveUnbuiltMotorwaysEdit removeUnbuiltMotorwaysEdit = scope.Get<RemoveUnbuiltMotorwaysEdit>();
			removeUnbuiltMotorwaysEdit.Coordinates = coordinates;
			return removeUnbuiltMotorwaysEdit;
		}
	}
}
