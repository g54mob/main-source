using System;

namespace Steamworks
{
	[Serializable]
	public struct ControllerActionSetHandle_t : IEquatable<ControllerActionSetHandle_t>, IComparable<ControllerActionSetHandle_t>
	{
		public ulong m_ControllerActionSetHandle;

		public ControllerActionSetHandle_t(ulong value)
		{
			m_ControllerActionSetHandle = 0uL;
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

		public static bool operator ==(ControllerActionSetHandle_t x, ControllerActionSetHandle_t y)
		{
			return false;
		}

		public static bool operator !=(ControllerActionSetHandle_t x, ControllerActionSetHandle_t y)
		{
			return false;
		}

		public static explicit operator ControllerActionSetHandle_t(ulong value)
		{
			return default(ControllerActionSetHandle_t);
		}

		public static explicit operator ulong(ControllerActionSetHandle_t that)
		{
			return 0uL;
		}

		public bool Equals(ControllerActionSetHandle_t other)
		{
			return false;
		}

		public int CompareTo(ControllerActionSetHandle_t other)
		{
			return 0;
		}
	}
}
