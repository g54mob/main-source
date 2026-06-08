using System;
using Photon.Realtime;
using WebSocketSharp;

namespace Kitchen.NetworkSupport
{
	public struct PhotonNetworkTarget : INetworkTarget, IEquatable<INetworkTarget>, IPlatformSpecificIdentifier, IEquatable<IPlatformSpecificIdentifier>
	{
		public bool IsPlayer;

		public Player Player;

		public string RoomRegion;

		public string RoomName;

		public bool IsHostMode { get; }

		public bool IsValid
		{
			get
			{
				if (!IsPlayer || Player == null)
				{
					if (!IsPlayer)
					{
						return !RoomName.IsNullOrEmpty();
					}
					return false;
				}
				return true;
			}
		}

		public PhotonNetworkTarget(Player player, bool is_host_mode = false)
		{
			Player = player;
			IsPlayer = true;
			IsHostMode = is_host_mode;
			RoomRegion = "";
			RoomName = "";
		}

		public PhotonNetworkTarget(string region, string name)
		{
			Player = null;
			IsPlayer = false;
			IsHostMode = false;
			RoomRegion = region;
			RoomName = name;
		}

		public PhotonNetworkTarget(string name)
		{
			Player = null;
			IsPlayer = false;
			IsHostMode = false;
			RoomRegion = null;
			RoomName = name;
		}

		public PhotonNetworkTarget(PhotonLobby lobby)
		{
			Player = null;
			IsPlayer = false;
			IsHostMode = false;
			RoomRegion = lobby.Room.LoadBalancingClient.CloudRegion;
			RoomName = lobby.Room.Name;
		}

		public bool Matches(Player right)
		{
			if (IsPlayer)
			{
				return object.Equals(Player, right);
			}
			return false;
		}

		public bool Matches(string region, string name)
		{
			if (!IsPlayer && (region == RoomRegion || region == null || RoomRegion == null))
			{
				return name == RoomName;
			}
			return false;
		}

		public bool Equals(INetworkTarget other)
		{
			if (!(other is PhotonNetworkTarget photonNetworkTarget))
			{
				return false;
			}
			if (!Matches(photonNetworkTarget.RoomRegion, photonNetworkTarget.RoomName))
			{
				return Matches(photonNetworkTarget.Player);
			}
			return true;
		}

		public bool Equals(IPlatformSpecificIdentifier other)
		{
			if (other is PhotonNetworkTarget photonNetworkTarget)
			{
				return Equals(photonNetworkTarget);
			}
			return false;
		}

		public bool IsEquivalent(INetworkTarget other)
		{
			return Equals(other);
		}

		public bool IsEquivalent(PhotonLobby other)
		{
			if (other.Room == null)
			{
				return false;
			}
			return other.Room.Name == RoomName;
		}

		public override string ToString()
		{
			if (!IsValid)
			{
				return "Photon.Invalid";
			}
			if (IsPlayer)
			{
				return $"Photon.Player {Player}";
			}
			return "Photon.Room " + RoomName + " (" + RoomRegion + ")";
		}
	}
}
