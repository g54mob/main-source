using System.Collections.Generic;
using NSMedieval.Serialization;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Pathfinding
{
	[FVSerializableKey("TempPathfindingPointInstance", "")]
	public class TempPathfindingPointInstance : WorldObject
	{
		private List<Vec3Int> positions;

		public override List<Vec3Int> Positions => positions;

		public override bool BlueprintExists => false;

		public TempPathfindingPointInstance(Vector3 worldPosition)
			: base(worldPosition)
		{
			positions = new List<Vec3Int> { base.GridDataPosition };
			RemoveFromRegions();
			RegisterInRegions();
		}

		public override void Dispose()
		{
			base.Dispose();
			positions.Clear();
			positions = null;
		}

		public override void Serialize(FVSerializer serializer)
		{
		}

		public TempPathfindingPointInstance(FVDeserializer deserializer)
		{
		}
	}
}
