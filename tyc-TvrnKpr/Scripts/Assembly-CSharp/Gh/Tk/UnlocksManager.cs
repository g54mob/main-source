using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public static class UnlocksManager
	{
		public static List<ProfileUnlock> SaveGameProfileUnlocks;

		private static Dictionary<UnlockType, HashSet<string>> _unlockCache;

		public static Dictionary<string, UnlockState> SaveGameUnlockStates;

		public static List<string> SaveGameSeenUnlocks;

		public static event EventHandler UnlockStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void TriggerUnlocksRefresh()
		{
		}

		public static bool IsBlocked(string key)
		{
			return false;
		}

		public static bool IsLocked(string key)
		{
			return false;
		}

		public static bool IsUnlocked(string key)
		{
			return false;
		}

		public static bool IsZoneLocked(string key)
		{
			return false;
		}

		public static void UnlockZone(string key)
		{
		}

		private static bool IsPlayerProfileUnlockState(string key, UnlockState state)
		{
			return false;
		}

		public static bool IsTavernUnlockState(string key, UnlockState state)
		{
			return false;
		}

		public static void SetUnlockState(string keyToUnlock, UnlockState setState, bool saveToProfile)
		{
		}

		public static bool IsSeenUnlock(string unlockId)
		{
			return false;
		}

		public static bool IsSeenInUI(string unlockId)
		{
			return false;
		}

		public static void MarkAsSeenInUI(string unlockId)
		{
		}

		public static bool IsSeenUnlockThisSession(string unlockId)
		{
			return false;
		}

		public static void MarkAsSeenUnlock(string templateId, bool forceAddToSaveGame = false)
		{
		}

		public static IEnumerable<string> GetUnlockedProps()
		{
			return null;
		}

		public static IEnumerable<string> GetCompiledUnlockCache(UnlockType unlockType)
		{
			return null;
		}

		public static bool IsPropUnlocked(string key)
		{
			return false;
		}

		public static void PopulateSaveGameSeenUnlocks()
		{
		}

		private static bool IsUnlockCurrentlyAvailable(string templateId)
		{
			return false;
		}

		public static void OnNewLevelStarted()
		{
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnLevelUnloaded(object sender, EventArgs e)
		{
		}

		public static void ResetSaveGameUnlocks()
		{
		}

		public static HashSet<string> GetSaveGameUnlocksCache(UnlockType unlockType)
		{
			return null;
		}

		public static void AddSaveGameUnlock(ProfileUnlock unlock)
		{
		}

		public static List<ProfileUnlock> CollectProfileUnlocksForSaveGame()
		{
			return null;
		}

		public static Dictionary<string, UnlockState> CollectUnlockStatesForSaveGame()
		{
			return null;
		}

		public static List<string> CollectSeenUnlocksForSaveGame()
		{
			return null;
		}

		public static void LoadSaveGameProfileUnlocks(List<ProfileUnlock> unlocks)
		{
		}

		public static void LoadSaveGameUnlockStates(Dictionary<string, UnlockState> unlockStates)
		{
		}

		public static void LoadSaveGameSeenUnlocks(List<string> seenUnlocks)
		{
		}

		public static List<string> GetUnseenUnlockedProps()
		{
			return null;
		}
	}
}
