using System.Collections.Generic;
using Steamworks;

namespace BrewGame.SaveSystem.Storage
{
	public static class SaveSlotSelector
	{
		private const string PREF_KEY_SLOT = "SelectedSaveSlot";

		private const string PREF_KEY_NEW_GAME = "IsNewGame";

		private const string PREF_KEY_INTRO_PLAYED = "IntroPlayed";

		private const string PREF_KEY_INTRO_JUST_COMPLETED = "IntroJustCompleted";

		private const string PREF_KEY_CUSTOMIZATION_JUST_COMPLETED = "CustomizationJustCompleted";

		private static bool _initialized;

		private static List<string> _knownPlayerSteamIds;

		public static IReadOnlyList<string> KnownPlayerSteamIds => null;

		public static int SelectedSlotIndex { get; private set; }

		public static bool IsNewGame { get; private set; }

		public static bool IntroPlayed { get; private set; }

		public static bool IntroJustCompleted { get; private set; }

		public static bool CustomizationJustCompleted { get; private set; }

		public static bool HasSelection => false;

		static SaveSlotSelector()
		{
		}

		public static void EnsureInitialized()
		{
		}

		public static void SelectSlotForLoading(int slotIndex, bool introPlayed = false, List<string> knownPlayerSteamIds = null)
		{
		}

		public static void SelectSlotForNewGame(int slotIndex)
		{
		}

		public static void ClearSelection()
		{
		}

		public static bool IsLocalPlayerKnown()
		{
			return false;
		}

		public static void MarkIntroJustCompleted()
		{
		}

		public static void ClearIntroJustCompleted()
		{
		}

		public static void MarkCustomizationJustCompleted()
		{
		}

		public static void ClearCustomizationJustCompleted()
		{
		}

		public static void SetKnownPlayersInLobby(CSteamID lobbyId, List<string> steamIds)
		{
		}

		public static bool IsCurrentPlayerKnownInLobby(CSteamID lobbyId)
		{
			return false;
		}

		public static void RestoreFromPrefs()
		{
		}
	}
}
