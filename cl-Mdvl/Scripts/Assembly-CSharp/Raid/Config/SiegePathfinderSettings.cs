using System;
using NSEipix.Base;
using UnityEngine;

namespace Raid.Config
{
	[Serializable]
	public class SiegePathfinderSettings : SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>
	{
		[SerializeField]
		private uint waterPenalty = 1000u;

		[SerializeField]
		private uint breakDoorPenalty = 70u;

		[SerializeField]
		private uint breakWallPenalty = 100u;

		[SerializeField]
		private uint buildFloorPenalty = 15000u;

		[SerializeField]
		private uint buildFloorAirBridgePenalty = 50000u;

		[SerializeField]
		private uint mineWallPenalty = 45000u;

		[SerializeField]
		private uint buildLadderPenalty = 50000u;

		public uint WaterPenalty => waterPenalty;

		public uint BreakDoorPenalty => breakDoorPenalty;

		public uint BreakWallPenalty => breakWallPenalty;

		public uint BuildFloorPenalty => buildFloorPenalty;

		public uint BuildFloorAirBridgePenalty => buildFloorAirBridgePenalty;

		public uint MineWallPenalty => mineWallPenalty;

		public uint BuildLadderPenalty => buildLadderPenalty;

		public override string GetID()
		{
			return "SiegePathfinderSettings";
		}
	}
}
