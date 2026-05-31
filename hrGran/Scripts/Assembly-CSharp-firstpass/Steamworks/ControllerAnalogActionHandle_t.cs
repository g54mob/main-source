using System;

namespace Steamworks
{
	[Serializable]
	public struct ControllerAnalogActionHandle_t : IEquatable<ControllerAnalogActionHandle_t>, IComparable<ControllerAnalogActionHandle_t>
	{
		public ulong m_ControllerAnalogActionHandle;

		public ControllerAnalogActionHandle_t(ulong value)
		{
			m_ControllerAnalogActionHandle = 0uL;
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

		public static bool operator ==(ControllerAnalogActionHandle_t x, ControllerAnalogActionHandle_t y)
		{
			return false;
		}

		public static bool operator !=(ControllerAnalogActionHandle_t x, ControllerAnalogActionHandle_t y)
		{
			return false;
		}

		public static explicit operator ControllerAnalogActionHandle_t(ulong value)
		{
			return default(ControllerAnalogActionHandle_t);
		}

		public static explicit operator ulong(ControllerAnalogActionHandle_t that)
		{
			return 0uL;
		}

		public bool Equals(ControllerAnalogActionHandle_t other)
		{
			return false;
		}

		public int CompareTo(ControllerAnalogActionHandle_t other)
		{
			return 0;
		}
	}
}
