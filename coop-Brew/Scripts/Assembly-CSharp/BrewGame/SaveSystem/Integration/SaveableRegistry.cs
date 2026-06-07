using System.Collections.Generic;
using UnityEngine;

namespace BrewGame.SaveSystem.Integration
{
	public class SaveableRegistry : MonoBehaviour
	{
		private Dictionary<string, ISaveable> _saveables;

		private List<ISaveable> _sortedSaveables;

		private bool _isDirty;

		private Dictionary<string, Dictionary<string, object>> _pendingStates;

		private static bool _showDebugLogs;

		public static SaveableRegistry Instance { get; private set; }

		public int Count => 0;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Register(ISaveable saveable)
		{
		}

		private void TryRestorePendingState(ISaveable saveable)
		{
		}

		public void SetPendingStates(Dictionary<string, Dictionary<string, object>> states)
		{
		}

		public void ClearPendingStates()
		{
		}

		public bool HasPendingState(string saveableId)
		{
			return false;
		}

		public void CaptureStateForSaveable(ISaveable saveable)
		{
		}

		public void Unregister(ISaveable saveable)
		{
		}

		public void Unregister(string saveableId)
		{
		}

		public void Clear()
		{
		}

		public void RefreshAll(bool restorePendingStates = true)
		{
		}

		public ISaveable GetSaveable(string saveableId)
		{
			return null;
		}

		public IReadOnlyList<ISaveable> GetAllSaveables()
		{
			return null;
		}

		public bool IsRegistered(string saveableId)
		{
			return false;
		}

		public Dictionary<string, Dictionary<string, object>> CaptureAllStates()
		{
			return null;
		}

		public void RestoreAllStates(Dictionary<string, Dictionary<string, object>> allStates)
		{
		}

		private void RebuildSortedList()
		{
		}

		public IEnumerable<T> GetSaveablesOfType<T>() where T : class, ISaveable
		{
			return null;
		}

		public IEnumerable<ISaveable> GetSaveablesWithPrefix(string prefix)
		{
			return null;
		}

		public static void SetDebugLogging(bool enabled)
		{
		}

		public string GetDebugInfo()
		{
			return null;
		}
	}
}
