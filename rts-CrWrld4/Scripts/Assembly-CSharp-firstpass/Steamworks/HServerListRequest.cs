using System;

namespace Steamworks
{
	[Serializable]
	public struct HServerListRequest : IEquatable<HServerListRequest>
	{
		public static readonly HServerListRequest Invalid;

		public IntPtr m_HServerListRequest;

		public HServerListRequest(IntPtr value)
		{
			m_HServerListRequest = (IntPtr)0;
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

		public static bool operator ==(HServerListRequest x, HServerListRequest y)
		{
			return false;
		}

		public static bool operator !=(HServerListRequest x, HServerListRequest y)
		{
			return false;
		}

		public static explicit operator HServerListRequest(IntPtr value)
		{
			return default(HServerListRequest);
		}

		public static explicit operator IntPtr(HServerListRequest that)
		{
			return (IntPtr)0;
		}

		public bool Equals(HServerListRequest other)
		{
			return false;
		}
	}
}
