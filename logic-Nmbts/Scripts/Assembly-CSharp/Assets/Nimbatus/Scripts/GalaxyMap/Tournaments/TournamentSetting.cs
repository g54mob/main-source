using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments
{
	[Serializable]
	public class TournamentSetting
	{
		public ETournamentType TournamentType;

		public TranslationTerm Title;

		public TranslationTerm TournamentTitle;

		public TranslationTerm TrainingTitle;

		public TranslationTerm TrainingStartButtonTitle;

		public TranslationTerm Description;

		public int NumberOfWins;

		public int NumberOfLosses;

		public ELeaderboard LeaderBoard;

		public EDefaultDroneType DefaultDroneType;

		public bool DisableUpload;

		public string ArenaSceneName;

		public EGravity Gravity;

		public EAirResistance AirResistance;

		public Color UiColor;

		public void ApplySettings()
		{
			WorldController.TerrainSettings.Gravity = Gravity;
			WorldController.TerrainSettings.AirResistance = AirResistance;
		}
	}
}
