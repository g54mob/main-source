using System;
using System.Collections.Generic;
using FractureField.Achievements;
using FractureField.Bombs;
using FractureField.Drones;
using FractureField.GameManagers;
using FractureField.PlayerStats;
using FractureField.Prestige;
using FractureField.Prestige.RealityShatter;
using FractureField.Prestige.WorldFracture;
using FractureField.QuarryForeman;
using FractureField.Rewards;
using FractureField.Rocks;
using FractureField.Stats;
using FractureField.Tools;
using Reactivity;

namespace FractureField
{
	public class Game
	{
		private static Game _instance;

		private bool _shouldShowChangelog;

		private string _previousVersion;

		private readonly GameLoop _gameLoop;

		private readonly RandomManagers _randomManagers;

		private readonly MiscManager _miscManager;

		private readonly CurrencyManager _currencyManager;

		private readonly PlayerStatsManager _playerStatsManager;

		private readonly RockManager _rockManager;

		private readonly ToolManager _toolManager;

		private readonly StatsManager _statsManager;

		private readonly DroneManager _droneManager;

		private readonly BombManager _bombManager;

		private readonly WorldFractureManager _worldFractureManager;

		private readonly RealityShatterManager _realityShatterManager;

		private readonly QuarryForemanManager _quarryForemanManager;

		private readonly RewardBatcher _rewardBatcher;

		private readonly AchievementManager _achievementManager;

		public static Game Instance => null;

		public static RBool IsInitialized { get; private set; }

		private static List<Action> OnInitializedActions { get; }

		public static bool ShouldShowChangelog => false;

		public static string PreviousVersion => null;

		public static RTrigger OnGameRestart { get; }

		public static Ref<PrestigeLayerType> OnPrestigeLayerReset { get; }

		public static GameLoop Loop => null;

		public static RandomManagers Randoms => null;

		public static MiscManager Misc => null;

		public static CurrencyManager Currencies => null;

		public static PlayerStatsManager PlayerStats => null;

		public static RockManager Rocks => null;

		public static ToolManager Tools => null;

		public static StatsManager Stats => null;

		public static DroneManager Drones => null;

		public static BombManager Bombs => null;

		public static WorldFractureManager WorldFracture => null;

		public static RealityShatterManager RealityShatter => null;

		public static QuarryForemanManager QuarryForeman => null;

		public static RewardBatcher RewardBatcher => null;

		public static AchievementManager Achievements => null;

		public static void ClearInstance()
		{
		}

		private Game()
		{
		}

		private void Init()
		{
		}

		public static void RegisterOnInitializedAction(Action action)
		{
		}

		private void CheckVersionChange()
		{
		}

		public static void ChangelogShown()
		{
		}
	}
}
