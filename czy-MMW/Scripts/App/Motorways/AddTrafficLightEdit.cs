using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class AddTrafficLightEdit : TileEdit
	{
		[Serialize(true, null)]
		public Vector2Int OriginCoordinates { get; private set; }

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			yield return tilemap.GetOrCreateTile(OriginCoordinates);
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (base.CanApplyToSimulation && Diagnostics.Verify(TileEditor.TileSupportsTrafficLight(tile), "Can't apply a traffic light to this tile"))
			{
				tile.HasTrafficLight = true;
				return true;
			}
			return false;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			return upgradeDatabase.ConsumeUpgrade(UpgradeType.TrafficLight);
		}

		public static AddTrafficLightEdit Create(IScope scope, Vector2Int originCoordinates)
		{
			AddTrafficLightEdit addTrafficLightEdit = scope.Get<AddTrafficLightEdit>();
			addTrafficLightEdit.OriginCoordinates = originCoordinates;
			return addTrafficLightEdit;
		}

		public override void Reset()
		{
			base.Reset();
			OriginCoordinates = Vector2Int.zero;
		}
	}
}
