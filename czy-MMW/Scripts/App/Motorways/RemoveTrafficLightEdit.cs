using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class RemoveTrafficLightEdit : TileEdit
	{
		[Serialize(true, null)]
		public Vector2Int Coordinates { get; private set; }

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			yield return tilemap.GetTile(Coordinates);
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (tile.HasTrafficLight)
			{
				tile.HasTrafficLight = false;
				return true;
			}
			return false;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			Tile tile = tilemap.GetTile(Coordinates);
			if (tile != null && tile.HasTrafficLight)
			{
				upgradeDatabase.MothballUpgrade(UpgradeType.TrafficLight);
				upgradeDatabase.ReleaseMothballedUpgrade(UpgradeType.TrafficLight);
			}
			return true;
		}

		public static RemoveTrafficLightEdit Create(IScope scope, Vector2Int coordinates)
		{
			RemoveTrafficLightEdit removeTrafficLightEdit = scope.Get<RemoveTrafficLightEdit>();
			removeTrafficLightEdit.Coordinates = coordinates;
			return removeTrafficLightEdit;
		}

		public override void Reset()
		{
			base.Reset();
			Coordinates = Vector2Int.zero;
		}
	}
}
