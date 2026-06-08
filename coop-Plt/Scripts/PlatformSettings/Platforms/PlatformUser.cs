using System;
using MessagePack;

namespace Platforms
{
	[MessagePackObject(false)]
	public struct PlatformUser : IEquatable<PlatformUser>
	{
		[Key(0)]
		public PlatformType Platform;

		[Key(1)]
		public int Identifier;

		[IgnoreMember]
		public static PlatformUser NoUser => new PlatformUser(0);

		[IgnoreMember]
		public bool IsValidUser => Identifier != 0;

		public PlatformUser(int id)
		{
			Identifier = id;
			Platform = PlatformSettings.CurrentPlatformType;
		}

		public bool Equals(PlatformUser other)
		{
			if (Platform == other.Platform)
			{
				return Identifier == other.Identifier;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is PlatformUser other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)Platform * 1241 + Identifier.GetHashCode();
		}

		public static bool operator ==(PlatformUser left, PlatformUser right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(PlatformUser left, PlatformUser right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			return $"{Platform}-{Identifier}";
		}
	}
}
