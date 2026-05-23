using System;
using Assets.Scripts.Game.Other;

namespace Assets.Scripts.Managers
{
	public class MapController
	{
		private static PlayerInventory inventory;

		public static int index;

		private static bool isFinalBossStage;

		private const string finalBossMapName = "FinalBossMap";

		private static bool reseting;

		public static Action A_NewRunStarted;

		public static RunConfig runConfig;

		private static string mainMenuSceneName;

		public static MapData currentMap { get; private set; }

		public static StageData currentStage { get; private set; }

		public static void RestartRun()
		{
		}

		public static void StartNewMap(RunConfig newRunConfig)
		{
		}

		private static void TryCleanupInventory()
		{
		}

		public static void LoadNextStage()
		{
		}

		public static void LoadFinalStage()
		{
		}

		public static bool IsFirstStage()
		{
			return false;
		}

		public static int GetStageIndex()
		{
			return 0;
		}

		public static bool IsLastStage()
		{
			return false;
		}

		public static bool IsFinalBossStage()
		{
			return false;
		}

		public static void TestFinalBoss()
		{
		}

		public static bool IsTierFinalStage()
		{
			return false;
		}

		public static PlayerInventory GetPlayerInventory(CharacterData data)
		{
			return null;
		}

		public static bool HasPlayerInventory()
		{
			return false;
		}

		public static void TestMap(MapData mapData, StageData stageData)
		{
		}

		public static void TestMap(RunConfig testConfig)
		{
		}

		public static bool IsMainMenu()
		{
			return false;
		}
	}
}
