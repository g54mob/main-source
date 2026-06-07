using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[CreateAssetMenu]
	public class LeaderboardsDatabase : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal LeaderboardInfo[] leaderboards;

		private Dictionary<StatID, LeaderboardInfo> database;

		public IReadOnlyCollection<StatID> Keys => null;

		public uint GetPS4ID(StatID id)
		{
			return 0u;
		}

		public string GetGDKID(StatID id)
		{
			return null;
		}

		public string GetEpicID(StatID id)
		{
			return null;
		}

		public string GetEpicStatID(StatID id)
		{
			return null;
		}

		public string GetiOSID(StatID id)
		{
			return null;
		}

		public string GetAndroidID(StatID id)
		{
			return null;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
