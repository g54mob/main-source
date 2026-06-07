using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[CreateAssetMenu]
	public class DlcDatabase : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal DlcInfo[] dlcs;

		private Dictionary<DlcID, DlcInfo> database;

		public IReadOnlyCollection<DlcID> Keys => null;

		public uint GetSteamID(DlcID id)
		{
			return 0u;
		}

		public ulong GetGogID(DlcID id)
		{
			return 0uL;
		}

		public string GetGDKGamePassID(DlcID id)
		{
			return null;
		}

		public string GetGDKConsoleID(DlcID id)
		{
			return null;
		}

		public int GetSwitchID(DlcID id)
		{
			return 0;
		}

		public string GetXboxID(DlcID id)
		{
			return null;
		}

		public string GetEpicID(DlcID id)
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
