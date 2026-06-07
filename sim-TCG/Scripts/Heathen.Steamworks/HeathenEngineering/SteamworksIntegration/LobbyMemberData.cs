using System;
using HeathenEngineering.SteamworksIntegration.API;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct LobbyMemberData : IEquatable<LobbyMemberData>
	{
		public LobbyData lobby;

		public UserData user;

		public readonly string this[string metadataKey]
		{
			get
			{
				return Matchmaking.Client.GetLobbyMemberData(lobby, user, metadataKey);
			}
			set
			{
				if (user == User.Client.Id)
				{
					Matchmaking.Client.SetLobbyMemberData(lobby, metadataKey, value);
				}
			}
		}

		public readonly bool IsReady
		{
			get
			{
				return this["z_heathenReady"] == "true";
			}
			set
			{
				this["z_heathenReady"] = value.ToString().ToLower();
			}
		}

		public readonly string GameVersion
		{
			get
			{
				return this["z_heathenGameVersion"];
			}
			set
			{
				this["z_heathenGameVersion"] = value;
			}
		}

		public readonly bool IsOwner => lobby.Owner.Equals(this);

		public readonly bool Equals(LobbyMemberData other)
		{
			if (other.lobby == lobby)
			{
				return other.user == user;
			}
			return false;
		}

		public readonly void Kick()
		{
			lobby.KickMember(user);
		}

		public static LobbyMemberData Get(LobbyData lobby, UserData user)
		{
			return new LobbyMemberData
			{
				lobby = lobby,
				user = user
			};
		}
	}
}
