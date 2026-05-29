using System;
using System.Text;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct LobbyChatMsg
	{
		public LobbyData lobby;

		public EChatEntryType type;

		public UserData sender;

		public byte[] data;

		public DateTime receivedTime;

		public string Message => ToString();

		public override string ToString()
		{
			return Encoding.UTF8.GetString(data);
		}

		public T FromJson<T>()
		{
			return JsonUtility.FromJson<T>(ToString());
		}

		public bool TryFromJson<T>(out T result)
		{
			try
			{
				result = JsonUtility.FromJson<T>(ToString());
				return true;
			}
			catch
			{
				result = default(T);
				return false;
			}
		}
	}
}
