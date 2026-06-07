using System.Globalization;
using System.Runtime.InteropServices;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	internal struct DeviceObjectId
	{
		private const int InstanceNumberMax = 65534;

		private const int AnyInstanceMask = 16776960;

		private int _rawType;

		public kwDQWJxJqLfGHqZNmyNdWGtdcVI Flags
		{
			get
			{
				return (kwDQWJxJqLfGHqZNmyNdWGtdcVI)(_rawType & -16776961);
			}
		}

		public int InstanceNumber
		{
			get
			{
				return (_rawType >> 8) & 0xFFFF;
			}
		}

		public DeviceObjectId(kwDQWJxJqLfGHqZNmyNdWGtdcVI typeFlags, int instanceNumber)
		{
			this = default(DeviceObjectId);
			_rawType = (int)(typeFlags & ~kwDQWJxJqLfGHqZNmyNdWGtdcVI.iLYhYyHJNLJdOmftxCwZHCLZhLYR) | ((!(instanceNumber < 0 || instanceNumber > 65534)) ? ((instanceNumber & 0xFFFF) << 8) : 0);
		}

		public static explicit operator int(DeviceObjectId type)
		{
			return type._rawType;
		}

		public bool Equals(DeviceObjectId other)
		{
			return other._rawType == _rawType;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (obj.GetType() != typeof(DeviceObjectId))
			{
				return false;
			}
			return Equals((DeviceObjectId)obj);
		}

		public override int GetHashCode()
		{
			return _rawType;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", Flags, InstanceNumber, _rawType);
		}
	}
}
