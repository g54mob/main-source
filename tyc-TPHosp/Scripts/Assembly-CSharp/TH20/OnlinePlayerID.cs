using System;
using FullSerializerSave;
using MessagePack;
using Steamworks;

namespace TH20
{
	[MessagePackObject(false)]
	public struct OnlinePlayerID : IEquatable<OnlinePlayerID>, IComparable<OnlinePlayerID>
	{
		[IgnoreMember]
		public static readonly OnlinePlayerID Nil;

		[IgnoreMember]
		[fsProperty("m_SteamID")]
		public ulong m_OnlinePlayerID;

		public OnlinePlayerID(ulong ulOnlinePlayerID)
		{
			m_OnlinePlayerID = ulOnlinePlayerID;
		}

		public bool IsValid()
		{
			return this != Nil;
		}

		public static implicit operator OnlinePlayerID(CSteamID steamID)
		{
			return new OnlinePlayerID(steamID.m_SteamID);
		}

		public static implicit operator CSteamID(OnlinePlayerID playerID)
		{
			return new CSteamID(playerID.m_OnlinePlayerID);
		}

		public override string ToString()
		{
			return m_OnlinePlayerID.ToString();
		}

		public override bool Equals(object other)
		{
			if (other is OnlinePlayerID)
			{
				return this == (OnlinePlayerID)other;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_OnlinePlayerID.GetHashCode();
		}

		public static bool operator ==(OnlinePlayerID x, OnlinePlayerID y)
		{
			return x.m_OnlinePlayerID == y.m_OnlinePlayerID;
		}

		public static bool operator !=(OnlinePlayerID x, OnlinePlayerID y)
		{
			return !(x == y);
		}

		public static implicit operator OnlinePlayerID(ulong value)
		{
			return new OnlinePlayerID(value);
		}

		public static implicit operator ulong(OnlinePlayerID that)
		{
			return that.m_OnlinePlayerID;
		}

		public bool Equals(OnlinePlayerID other)
		{
			return m_OnlinePlayerID == other.m_OnlinePlayerID;
		}

		public int CompareTo(OnlinePlayerID other)
		{
			return m_OnlinePlayerID.CompareTo(other.m_OnlinePlayerID);
		}
	}
}
