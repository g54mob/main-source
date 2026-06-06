using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Crime
{
	public class WantedStatusTracker
	{
		private readonly Dictionary<ulong, CrimeRateManager.PlayerWantedRecord> _records;

		private readonly object _lock;

		private float _wantedTimerDuration;

		private bool _enableLogging;

		public WantedStatusTracker(float wantedTimerDuration = 120f, bool enableLogging = false)
		{
		}

		public bool IsWanted(ulong playerId)
		{
			return false;
		}

		public CrimeRateManager.PlayerWantedStatus GetStatus(ulong playerId)
		{
			return default(CrimeRateManager.PlayerWantedStatus);
		}

		public CrimeRateManager.PlayerWantedRecord GetOrCreateRecord(ulong playerId)
		{
			return null;
		}

		public void MarkWanted(ulong playerId, Vector3 crimeLocation, string reason = "Crime witnessed")
		{
		}

		public void MarkArrested(ulong playerId)
		{
		}

		public void ClearWantedStatus(ulong playerId, string reason = "Timer expired")
		{
		}

		public void SetStatus(ulong playerId, CrimeRateManager.PlayerWantedStatus status, string reason = "Manual")
		{
		}

		public void UpdateAll(float currentTime)
		{
		}

		public void RemovePlayer(ulong playerId)
		{
		}

		public void ClearAll()
		{
		}

		public List<ulong> GetAllWantedPlayers()
		{
			return null;
		}

		public int GetWantedCount()
		{
			return 0;
		}
	}
}
