using System;

namespace Steamworks
{
	[Serializable]
	public struct ClientUnifiedMessageHandle : IEquatable<ClientUnifiedMessageHandle>, IComparable<ClientUnifiedMessageHandle>
	{
		public static readonly ClientUnifiedMessageHandle Invalid;

		public ulong m_ClientUnifiedMessageHandle;

		public ClientUnifiedMessageHandle(ulong value)
		{
			m_ClientUnifiedMessageHandle = 0uL;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return false;
		}

		public static bool operator !=(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return false;
		}

		public static explicit operator ClientUnifiedMessageHandle(ulong value)
		{
			return default(ClientUnifiedMessageHandle);
		}

		public static explicit operator ulong(ClientUnifiedMessageHandle that)
		{
			return 0uL;
		}

		public bool Equals(ClientUnifiedMessageHandle other)
		{
			return false;
		}

		public int CompareTo(ClientUnifiedMessageHandle other)
		{
			return 0;
		}
	}
}
