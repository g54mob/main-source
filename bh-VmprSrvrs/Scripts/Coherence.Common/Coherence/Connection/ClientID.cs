using System;

namespace Coherence.Connection
{
	public readonly struct ClientID : IEquatable<ClientID>, IComparable<ClientID>
	{
		public static readonly ClientID Server;

		private readonly uint id;

		public ClientID(uint id)
		{
			this.id = 0u;
		}

		public static explicit operator uint(ClientID cid)
		{
			return 0u;
		}

		public static explicit operator ClientID(uint cid)
		{
			return default(ClientID);
		}

		bool IEquatable<ClientID>.Equals(ClientID other)
		{
			return false;
		}

		public bool Equals(in ClientID other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public int CompareTo(ClientID other)
		{
			return 0;
		}

		public static bool operator ==(in ClientID left, in ClientID right)
		{
			return false;
		}

		public static bool operator !=(in ClientID left, in ClientID right)
		{
			return false;
		}

		public static bool operator >(in ClientID left, in ClientID right)
		{
			return false;
		}

		public static bool operator >=(in ClientID left, in ClientID right)
		{
			return false;
		}

		public static bool operator <(in ClientID left, in ClientID right)
		{
			return false;
		}

		public static bool operator <=(in ClientID left, in ClientID right)
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
