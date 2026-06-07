using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class AddUnbuiltMotorwayEdit : TileEdit
	{
		private Vector2Int _originCoordinates;

		private int _motorwayId = -1;

		private int _motorwayNumber;

		public override IEnumerable<Tile> GetAffectedTiles(ITilemap tilemap)
		{
			yield return tilemap.GetOrCreateTile(_originCoordinates);
		}

		public override bool ApplyToAffectedTile(Tile tile)
		{
			if (base.CanApplyToSimulation && Diagnostics.Verify(TileEditor.TileSupportsUnbuiltMotorway(tile, _motorwayId), "Can't apply a new, unbuilt motorway to this tile (tile id is {0}, expected {1}", tile.UnbuiltMotorwayId, _motorwayId))
			{
				TileEdit.Log.Info("Applying unbuilt motorway {0} to tile", _motorwayId);
				tile.UnbuiltMotorwayId = _motorwayId;
				tile.UnbuiltMotorwayNumber = _motorwayNumber;
				return true;
			}
			return false;
		}

		public override bool ApplyToUpgradeDatabase(UpgradeDatabase upgradeDatabase, ITilemap tilemap)
		{
			TileEdit.Log.Info("Consuming a motorway from UnbuildMotorwayEdit");
			return upgradeDatabase.ConsumeUpgrade(UpgradeType.Motorway);
		}

		public override void Reset()
		{
			_originCoordinates = default(Vector2Int);
			_motorwayId = -1;
			_motorwayNumber = 0;
			base.Reset();
		}

		public static AddUnbuiltMotorwayEdit Create(IScope scope, Vector2Int originCoordinates, int motorwayId, int motorwayNumber)
		{
			AddUnbuiltMotorwayEdit addUnbuiltMotorwayEdit = scope.Get<AddUnbuiltMotorwayEdit>();
			addUnbuiltMotorwayEdit._originCoordinates = originCoordinates;
			addUnbuiltMotorwayEdit._motorwayId = motorwayId;
			addUnbuiltMotorwayEdit._motorwayNumber = motorwayNumber;
			return addUnbuiltMotorwayEdit;
		}
	}
}
