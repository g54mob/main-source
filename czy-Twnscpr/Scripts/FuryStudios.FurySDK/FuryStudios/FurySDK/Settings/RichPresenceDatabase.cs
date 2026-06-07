using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[CreateAssetMenu]
	public class RichPresenceDatabase : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal RichPresenceInfo[] richPresences;

		private Dictionary<RichPresenceID, RichPresenceInfo> database;

		public IReadOnlyCollection<RichPresenceID> Keys => null;

		public string GetSteamRichPresenceID(RichPresenceID key)
		{
			return null;
		}

		public string GetGOGRichPresenceID(RichPresenceID key)
		{
			return null;
		}

		public string GetGDKRichPresenceID(RichPresenceID key)
		{
			return null;
		}

		public string GetEpicRichPresenceID(RichPresenceID key)
		{
			return null;
		}

		public string GetAndroidRichPresenceID(RichPresenceID key)
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
