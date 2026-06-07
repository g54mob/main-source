using System;

namespace Coherence.RSL.Transport
{
	public readonly struct ConnectionID : IEquatable<ConnectionID>, IComparable<ConnectionID>
	{
		public static readonly ConnectionID Server;

		private readonly uint id;

		public ConnectionID(uint id)
		{
			this.id = 0u;
		}

		public static explicit operator uint(ConnectionID cid)
		{
			return 0u;
		}

		public static explicit operator ConnectionID(uint cid)
		{
			return default(ConnectionID);
		}

		bool IEquatable<ConnectionID>.Equals(ConnectionID other)
		{
			return false;
		}

		public bool Equals(in ConnectionID other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public int CompareTo(ConnectionID other)
		{
			return 0;
		}

		public static bool operator ==(in ConnectionID left, in ConnectionID right)
		{
			return false;
		}

		public static bool operator !=(in ConnectionID left, in ConnectionID right)
		{
			return false;
		}

		public static bool operator >(in ConnectionID left, in ConnectionID right)
		{
			return false;
		}

		public static bool operator >=(in ConnectionID left, in ConnectionID right)
		{
			return false;
		}

		public static bool operator <(in ConnectionID left, in ConnectionID right)
		{
			return false;
		}

		public static bool operator <=(in ConnectionID left, in ConnectionID right)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
