using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NpcPlayerIdManager
	{
		public const int MaxConnectedHumanPlayers = 100;

		public const int MaxLocallySpawnedNonhumanPlayers = 100;

		public const int PlayerIdSpreadBetweenHumanPlayersAndNpcs = 100;

		private int _maxNpcPlayerId;

		private int _minNpcPlayerId;

		private SortedSet<int> _playerIdsAvailable;

		public int LocalPlayerId { get; }

		public NpcPlayerIdManager(int localPlayerID)
		{
			LocalPlayerId = localPlayerID;
			_minNpcPlayerId = localPlayerID * 100 + 100;
			_maxNpcPlayerId = _minNpcPlayerId + 99;
			_playerIdsAvailable = new SortedSet<int>();
			ResetAvailableIds();
		}

		public int GetNextNpcPlayerId(bool reserve)
		{
			int min = _playerIdsAvailable.Min;
			if (reserve)
			{
				_playerIdsAvailable.Remove(min);
			}
			return min;
		}

		public bool IsInRange(int playerId)
		{
			if (playerId >= _minNpcPlayerId)
			{
				return playerId < _maxNpcPlayerId;
			}
			return false;
		}

		public void ReleaseNpcPlayerId(int playerId)
		{
			if (IsInRange(playerId))
			{
				if (!_playerIdsAvailable.Contains(playerId))
				{
					_playerIdsAvailable.Add(playerId);
				}
				else
				{
					Debug.LogError($"PlayerId already released: {playerId}");
				}
			}
			else
			{
				Debug.LogError($"Attempting to release NPC playerId ({playerId}) that is out of range for the NPC playerId manager.");
			}
		}

		private void Initialize(int startNonHumanPlayerId)
		{
			_minNpcPlayerId = startNonHumanPlayerId;
			_maxNpcPlayerId = _minNpcPlayerId + 99;
			_playerIdsAvailable = new SortedSet<int>();
		}

		private void ResetAvailableIds()
		{
			_playerIdsAvailable.Clear();
			_playerIdsAvailable.UnionWith(Enumerable.Range(_minNpcPlayerId, 100));
		}
	}
}
