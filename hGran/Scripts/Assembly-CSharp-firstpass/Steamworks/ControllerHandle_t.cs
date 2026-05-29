using System;

namespace Steamworks
{
	[Serializable]
	public struct ControllerHandle_t : IEquatable<ControllerHandle_t>, IComparable<ControllerHandle_t>
	{
		public ulong m_ControllerHandle;

		public ControllerHandle_t(ulong value)
		{
			m_ControllerHandle = 0uL;
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

		public static bool operator ==(ControllerHandle_t x, ControllerHandle_t y)
		{
			return false;
		}

		public static bool operator !=(ControllerHandle_t x, ControllerHandle_t y)
		{
			return false;
		}

		public static explicit operator ControllerHandle_t(ulong value)
		{
			return default(ControllerHandle_t);
		}

		public static explicit operator ulong(ControllerHandle_t that)
		{
			return 0uL;
		}

		public bool Equals(ControllerHandle_t other)
		{
			return false;
		}

		public int CompareTo(ControllerHandle_t other)
		{
			return 0;
		}
	}
}
