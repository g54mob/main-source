using System.Runtime.InteropServices;

namespace Rewired.Libraries.SharpDX.DirectInput
{
	[StructLayout((LayoutKind)0, Size = 4)]
	internal struct DeviceObjectId
	{
		private int _rawType;

		public zfmdQVcnrkfFEEsXtYFYWXIJYkB Flags => default(zfmdQVcnrkfFEEsXtYFYWXIJYkB);

		public int InstanceNumber => 0;

		public bool Equals(DeviceObjectId other)
		{
			return false;
		}

		public override bool Equals(object obj)
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
