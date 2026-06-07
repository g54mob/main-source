using System;
using JetBrains.Annotations;
using Unity.Profiling;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.Scripts.Framework.Adventures
{
	[UsedImplicitly]
	public class AdventureManager : IInitializable, IDisposable
	{
		public static int MAX_ASCENSION_POINTS;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private DataManager _dataManager;

		private static AdventureManager _adventureManagerInstance;

		private static readonly ProfilerMarker MarkerInitAdventure;

		private static readonly ProfilerMarker MarkerInitDataManager;

		public AdventureType CurrentAdventure;

		public static bool IsInAdventureMode { get; set; }

		public static DlcType? CurrentAdventureDlcType { get; private set; }

		public static bool ShouldExitAdventureModeOnDisconnect { get; set; }

		public PlayerOptionsData CurrentAdventureSaveData => null;

		public AdventureData AdventureData { get; private set; }

		public Action<AdventureType> OnAdventureStartedEvent { get; set; }

		public Action OnAdventureExitEvent { get; set; }

		public Action<bool> OnAdventureAscended { get; set; }

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void InitAdventure(AdventureType adventureType)
		{
		}

		public bool HasLoadedAtLeastOneDlcWithAdventures()
		{
			return false;
		}

		public bool IsOwned(AdventureType type)
		{
			return false;
		}

		public bool AscendAdventure(AdventureType adventureType, bool forceShowAscensionConfirmation = false)
		{
			return false;
		}

		public void ResetAdventureProgress(AdventureType adventureType)
		{
		}

		public static void ForceExitAdventure()
		{
		}

		public void ExitAdventureMode(bool fireExitEvent = true, bool resetDataManager = true, bool force = false)
		{
		}

		public bool IsAdventureCharacter(CharacterType characterType)
		{
			return false;
		}

		public bool IsAdventureCompleted(AdventureType adventureType)
		{
			return false;
		}

		public bool WasAdventureAlreadyCompleted(AdventureType adventureType)
		{
			return false;
		}

		public bool CanAscend(AdventureType adventureType)
		{
			return false;
		}

		public void InitDataManagerForAdventure(AdventureType adventureType)
		{
		}

		private void ApplyAscension(PlayerOptionsData adventurePod, AdventureType adventureType)
		{
		}

		private void CopyCoreSettingsFromAdventureToBaseGame(PlayerOptionsData AdventureGameSaveData)
		{
		}

		private PlayerOptionsData StartNewAdventure(AdventureType adventureType)
		{
			return null;
		}

		private PlayerOptionsData GenerateNewAdventureData(PlayerOptionsData currentSaveData, AdventureType adventureType)
		{
			return null;
		}

		private PlayerOptionsData PopulateSaveDataWithAdventureData(PlayerOptionsData adventureSaveData, AdventureType adventureType)
		{
			return null;
		}

		public void CopyDataFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
		{
		}

		private void CopyArcanasFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
		{
		}

		private void CopyCoreSettingsFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
		{
		}

		private void CopySkinsFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
		{
		}

		private void CopyRelicsFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
		{
		}

		private PlayerOptionsData LoadAdventureData(AdventureType adventureType)
		{
			return null;
		}
	}
}
