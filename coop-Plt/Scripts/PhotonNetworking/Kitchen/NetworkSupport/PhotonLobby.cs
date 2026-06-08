using System;
using Photon.Realtime;

namespace Kitchen.NetworkSupport
{
	public struct PhotonLobby : IEquatable<PhotonLobby>
	{
		public Room Room;

		public PhotonLobby(Room r)
		{
			Room = r;
		}

		public bool IsEquivalent(Room room)
		{
			if (Room != null && room != null)
			{
				return Room.Name == room.Name;
			}
			return false;
		}

		public bool Equals(PhotonLobby other)
		{
			if (Room != null && other.Room != null)
			{
				return Room.Name == other.Room.Name;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is PhotonLobby other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (Room?.Name == null)
			{
				return 0;
			}
			return Room.Name.GetHashCode();
		}

		public static bool operator ==(PhotonLobby left, PhotonLobby right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(PhotonLobby left, PhotonLobby right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			if (Room != null)
			{
				return Room.ToString();
			}
			return "Invalid PhotonLobby";
		}
	}
}
