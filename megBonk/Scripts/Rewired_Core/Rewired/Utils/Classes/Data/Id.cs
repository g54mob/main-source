using System;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Id : IEquatable<Id>, IEquatable<uint>
	{
		public const uint Default = 0u;

		public const uint First = 1u;

		public const uint Invalid = 4294967295u;

		public uint id;

		public static bool IsValid(Id id)
		{
			return false;
		}

		public static bool IsValid(uint id)
		{
			return false;
		}

		public Id(uint P_0)
		{
			id = 0u;
		}

		public bool Equals(Id other)
		{
			return false;
		}

		public bool Equals(uint other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Id a, Id b)
		{
			return false;
		}

		public static bool operator !=(Id a, Id b)
		{
			return false;
		}

		public static implicit operator uint(Id a)
		{
			return 0u;
		}

		public static implicit operator Id(uint a)
		{
			return default(Id);
		}

		public void Increment()
		{
		}
	}
}
