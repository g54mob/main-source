using System;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct ChatRoom : IEquatable<ChatRoom>
	{
		public ClanData clan;

		public CSteamID id;

		public EChatRoomEnterResponse enterResponse;

		public readonly UserData[] Members => Clans.Client.GetChatMembers(clan);

		public readonly bool IsOpenInSteam => Clans.Client.IsClanChatWindowOpenInSteam(id);

		public bool SendMessage(string message)
		{
			return SteamFriends.SendClanChatMessage(id, message);
		}

		public bool OpenChatWindowInSteam()
		{
			return Clans.Client.OpenChatWindowInSteam(id);
		}

		public void Leave()
		{
			Clans.Client.LeaveChatRoom(id);
		}

		public bool Equals(ChatRoom other)
		{
			if (clan == other.clan)
			{
				return id == other.id;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj.GetType() == typeof(ChatRoom))
			{
				ChatRoom other = (ChatRoom)obj;
				return Equals(other);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return clan.GetHashCode() ^ id.GetHashCode();
		}

		public static bool operator ==(ChatRoom l, ChatRoom r)
		{
			return l.Equals(r);
		}

		public static bool operator !=(ChatRoom l, ChatRoom r)
		{
			return !l.Equals(r);
		}
	}
}
