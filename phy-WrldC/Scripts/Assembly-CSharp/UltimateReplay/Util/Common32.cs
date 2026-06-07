using System.Runtime.InteropServices;

namespace UltimateReplay.Util
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct Common32
	{
		private static Common32 conversion;

		[FieldOffset(0)]
		public float single;

		[FieldOffset(0)]
		public int integer;

		public static float ToSingle(int value)
		{
			conversion.integer = value;
			return conversion.single;
		}

		public static int ToInteger(float value)
		{
			conversion.single = value;
			return conversion.integer;
		}
	}
}
