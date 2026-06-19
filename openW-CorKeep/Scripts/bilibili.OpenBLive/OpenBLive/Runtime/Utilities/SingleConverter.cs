using System.Runtime.InteropServices;

namespace OpenBLive.Runtime.Utilities
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct SingleConverter
	{
		[FieldOffset(0)]
		private int intValue;

		[FieldOffset(0)]
		private float floatValue;

		internal SingleConverter(int intValue)
		{
			floatValue = 0f;
			this.intValue = intValue;
		}

		internal SingleConverter(float floatValue)
		{
			intValue = 0;
			this.floatValue = floatValue;
		}

		internal int GetIntValue()
		{
			return intValue;
		}

		internal float GetFloatValue()
		{
			return floatValue;
		}
	}
}
