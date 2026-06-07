using System;

namespace Steamworks
{
	[Serializable]
	public struct ControllerDigitalActionHandle_t : IEquatable<ControllerDigitalActionHandle_t>, IComparable<ControllerDigitalActionHandle_t>
	{
		public ulong m_ControllerDigitalActionHandle;

		public ControllerDigitalActionHandle_t(ulong value)
		{
			m_ControllerDigitalActionHandle = 0uL;
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

		public static bool operator ==(ControllerDigitalActionHandle_t x, ControllerDigitalActionHandle_t y)
		{
			return false;
		}

		public static bool operator !=(ControllerDigitalActionHandle_t x, ControllerDigitalActionHandle_t y)
		{
			return false;
		}

		public static explicit operator ControllerDigitalActionHandle_t(ulong value)
		{
			return default(ControllerDigitalActionHandle_t);
		}

		public static explicit operator ulong(ControllerDigitalActionHandle_t that)
		{
			return 0uL;
		}

		public bool Equals(ControllerDigitalActionHandle_t other)
		{
			return false;
		}

		public int CompareTo(ControllerDigitalActionHandle_t other)
		{
			return 0;
		}
	}
}
