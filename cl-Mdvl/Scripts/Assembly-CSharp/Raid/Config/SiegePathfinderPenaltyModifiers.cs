using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace Raid.Config
{
	[Serializable]
	[FVSerializableKey("SiegePathfinderPenaltyModifiers", "")]
	public class SiegePathfinderPenaltyModifiers : IFVSerializable
	{
		[SerializeField]
		private int everyVictoriesInRowCount;

		[SerializeField]
		private float waterPenaltyModifier = 1f;

		[SerializeField]
		private float breakDoorPenaltyModifier = 1f;

		[SerializeField]
		private float breakWallPenaltyModifier = 1f;

		[SerializeField]
		private float buildFloorPenaltyModifier = 1f;

		[SerializeField]
		private float buildFloorAirBridgePenaltyModifier = 1f;

		[SerializeField]
		private float mineWallPenaltyModifier = 1f;

		[SerializeField]
		private float buildLadderPenaltyModifier = 1f;

		public int EveryVictoriesInRowCount => everyVictoriesInRowCount;

		public float WaterPenaltyModifier => waterPenaltyModifier;

		public float BreakDoorPenaltyModifier => breakDoorPenaltyModifier;

		public float BreakWallPenaltyModifier => breakWallPenaltyModifier;

		public float BuildFloorPenaltyModifier => buildFloorPenaltyModifier;

		public float BuildFloorAirBridgePenaltyModifier => buildFloorAirBridgePenaltyModifier;

		public float MineWallPenaltyModifier => mineWallPenaltyModifier;

		public float BuildLadderPenaltyModifier => buildLadderPenaltyModifier;

		public SiegePathfinderPenaltyModifiers()
		{
		}

		public override string ToString()
		{
			return string.Format("\n{0}: {1}, \n{2}: {3}, \n{4}: {5}, \n{6}: {7}, \n{8}: {9}, \n{10}: {11}, \n{12}: {13}, \n{14}: {15}", "everyVictoriesInRowCount", everyVictoriesInRowCount, "waterPenaltyModifier", waterPenaltyModifier, "breakDoorPenaltyModifier", breakDoorPenaltyModifier, "breakWallPenaltyModifier", breakWallPenaltyModifier, "buildFloorPenaltyModifier", buildFloorPenaltyModifier, "buildFloorAirBridgePenaltyModifier", buildFloorAirBridgePenaltyModifier, "mineWallPenaltyModifier", mineWallPenaltyModifier, "buildLadderPenaltyModifier", buildLadderPenaltyModifier);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("everyVictoriesInRowCount", everyVictoriesInRowCount);
			serializer.Write("waterPenaltyModifier", waterPenaltyModifier);
			serializer.Write("breakDoorPenaltyModifier", breakDoorPenaltyModifier);
			serializer.Write("breakWallPenaltyModifier", breakWallPenaltyModifier);
			serializer.Write("buildFloorPenaltyModifier", buildFloorPenaltyModifier);
			serializer.Write("buildFloorAirBridgePenaltyModifier", buildFloorAirBridgePenaltyModifier);
			serializer.Write("mineWallPenaltyModifier", mineWallPenaltyModifier);
			serializer.Write("buildLadderPenaltyModifier", buildLadderPenaltyModifier);
		}

		public SiegePathfinderPenaltyModifiers(FVDeserializer deserializer)
		{
			everyVictoriesInRowCount = deserializer.ReadInt("everyVictoriesInRowCount");
			waterPenaltyModifier = deserializer.ReadFloat("waterPenaltyModifier");
			breakDoorPenaltyModifier = deserializer.ReadFloat("breakDoorPenaltyModifier");
			breakWallPenaltyModifier = deserializer.ReadFloat("breakWallPenaltyModifier");
			buildFloorPenaltyModifier = deserializer.ReadFloat("buildFloorPenaltyModifier");
			buildFloorAirBridgePenaltyModifier = deserializer.ReadFloat("buildFloorAirBridgePenaltyModifier");
			mineWallPenaltyModifier = deserializer.ReadFloat("mineWallPenaltyModifier");
			buildLadderPenaltyModifier = deserializer.ReadFloat("buildLadderPenaltyModifier");
		}
	}
}
