using System;
using Steamworks;

namespace Kitchen.Transports
{
	public class SteamNetworkTarget : INetworkTarget, IEquatable<INetworkTarget>, IPlatformSpecificIdentifier, IEquatable<IPlatformSpecificIdentifier>, IEquatable<SteamNetworkTarget>
	{
		public readonly SteamId ID;

		public bool IsHostMode { get; }

		public bool IsValid => ID.IsValid;

		public static SteamNetworkTarget Host => new SteamNetworkTarget();

		public bool IsEquivalent(INetworkTarget other)
		{
			return Equals(other);
		}

		public static SteamNetworkTarget FromString(string command)
		{
			return new SteamNetworkTarget(new SteamId
			{
				Value = Convert.ToUInt64(command)
			});
		}

		public static implicit operator SteamNetworkTarget(SteamId id)
		{
			return new SteamNetworkTarget(id);
		}

		public static implicit operator SteamNetworkTarget(Friend fr)
		{
			return new SteamNetworkTarget(fr.Id);
		}

		public static implicit operator SteamId(SteamNetworkTarget target)
		{
			return target.ID;
		}

		public SteamNetworkTarget()
		{
			IsHostMode = true;
		}

		public SteamNetworkTarget(SteamId id)
		{
			ID = id;
		}

		public override string ToString()
		{
			return "SteamNetworkTarget [" + ID.ToString() + "]";
		}

		public bool Equals(SteamNetworkTarget other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			if (ID.Equals(other.ID))
			{
				return IsHostMode == other.IsHostMode;
			}
			return false;
		}

		public bool Equals(INetworkTarget other)
		{
			if (other is SteamNetworkTarget steamNetworkTarget)
			{
				return this == steamNetworkTarget;
			}
			return false;
		}

		public bool Equals(IPlatformSpecificIdentifier other)
		{
			if (other is SteamNetworkTarget steamNetworkTarget)
			{
				return this == steamNetworkTarget;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((SteamNetworkTarget)obj);
		}

		public override int GetHashCode()
		{
			return (ID.GetHashCode() * 397) ^ IsHostMode.GetHashCode();
		}

		public static bool operator ==(SteamNetworkTarget left, SteamNetworkTarget right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(SteamNetworkTarget left, SteamNetworkTarget right)
		{
			return !object.Equals(left, right);
		}
	}
}
