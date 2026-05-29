using System;
using System.Linq;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct ClanData : IEquatable<CSteamID>, IEquatable<ClanData>, IEquatable<ulong>, IComparable<CSteamID>, IComparable<ClanData>, IComparable<ulong>
	{
		[SerializeField]
		private ulong id;

		public readonly CSteamID SteamId => new CSteamID(id);

		public readonly AccountID_t AccountId => SteamId.GetAccountID();

		public readonly uint FriendId => SteamId.GetAccountID().m_AccountID;

		public readonly bool IsValid
		{
			get
			{
				CSteamID steamId = SteamId;
				if (steamId == CSteamID.Nil || steamId.GetEAccountType() != EAccountType.k_EAccountTypeClan || steamId.GetEUniverse() != EUniverse.k_EUniversePublic)
				{
					return false;
				}
				return true;
			}
		}

		public readonly Texture2D Icon => Friends.Client.GetLoadedAvatar(this);

		public readonly string Name => Clans.Client.GetName(this);

		public readonly string Tag => Clans.Client.GetTag(this);

		public readonly UserData Owner => Clans.Client.GetOwner(this);

		public readonly UserData[] Officers => Clans.Client.GetOfficers(this);

		public readonly int NumberOfMembersInChat => Clans.Client.GetChatMemberCount(this);

		public readonly UserData[] MembersInChat => Clans.Client.GetChatMembers(this);

		public readonly bool IsOfficialGameGroup => Clans.Client.IsClanOfficialGameGroup(this);

		public readonly bool IsPublic => Clans.Client.IsClanPublic(this);

		public readonly bool IsUserOwner => Owner == UserData.Me;

		public readonly bool IsUserOfficer => Officers.Any((UserData p) => p == UserData.Me);

		public static ClanData[] Get()
		{
			return Clans.Client.GetClans();
		}

		public static ClanData Get(uint accountId)
		{
			return new CSteamID(new AccountID_t(accountId), EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeClan);
		}

		public static ClanData Get(AccountID_t accountId)
		{
			return new CSteamID(accountId, EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeClan);
		}

		public static ClanData Get(ulong id)
		{
			return new ClanData
			{
				id = id
			};
		}

		public static ClanData Get(CSteamID id)
		{
			return new ClanData
			{
				id = id.m_SteamID
			};
		}

		public readonly void JoinChat(Action<ChatRoom, bool> callback)
		{
			Clans.Client.JoinChatRoom(id, callback);
		}

		public readonly void LoadIcon(Action<Texture2D> callback)
		{
			Friends.Client.GetFriendAvatar(SteamId, callback);
		}

		public readonly int CompareTo(CSteamID other)
		{
			return id.CompareTo(other.m_SteamID);
		}

		public readonly int CompareTo(ClanData other)
		{
			return id.CompareTo(other.id);
		}

		public readonly int CompareTo(ulong other)
		{
			return id.CompareTo(other);
		}

		public override readonly string ToString()
		{
			return id.ToString();
		}

		public readonly bool Equals(CSteamID other)
		{
			return id.Equals(other);
		}

		public readonly bool Equals(ClanData other)
		{
			return id.Equals(other.id);
		}

		public readonly bool Equals(ulong other)
		{
			return id.Equals(other);
		}

		public override readonly bool Equals(object obj)
		{
			return id.Equals(obj);
		}

		public override readonly int GetHashCode()
		{
			return id.GetHashCode();
		}

		public static bool operator ==(ClanData l, ClanData r)
		{
			return l.id == r.id;
		}

		public static bool operator !=(ClanData l, ClanData r)
		{
			return l.id != r.id;
		}

		public static bool operator ==(ClanData l, CSteamID r)
		{
			return l.id == r.m_SteamID;
		}

		public static bool operator !=(ClanData l, CSteamID r)
		{
			return l.id != r.m_SteamID;
		}

		public static bool operator ==(CSteamID l, ClanData r)
		{
			return l.m_SteamID == r.id;
		}

		public static bool operator !=(CSteamID l, ClanData r)
		{
			return l.m_SteamID != r.id;
		}

		public static bool operator <(ClanData l, ClanData r)
		{
			return l.id < r.id;
		}

		public static bool operator >(ClanData l, ClanData r)
		{
			return l.id > r.id;
		}

		public static bool operator <=(ClanData l, ClanData r)
		{
			return l.id <= r.id;
		}

		public static bool operator >=(ClanData l, ClanData r)
		{
			return l.id >= r.id;
		}

		public static implicit operator CSteamID(ClanData c)
		{
			return c.SteamId;
		}

		public static implicit operator ClanData(CSteamID id)
		{
			return new ClanData
			{
				id = id.m_SteamID
			};
		}

		public static implicit operator ulong(ClanData c)
		{
			return c.id;
		}

		public static implicit operator ClanData(ulong id)
		{
			return new ClanData
			{
				id = id
			};
		}
	}
}
