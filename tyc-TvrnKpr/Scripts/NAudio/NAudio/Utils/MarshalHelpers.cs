using System;

namespace NAudio.Utils
{
	public static class MarshalHelpers
	{
		public static int SizeOf<T>()
		{
			return 0;
		}

		public static IntPtr OffsetOf<T>(string fieldName)
		{
			return (IntPtr)0;
		}

		public static T PtrToStructure<T>(IntPtr pointer)
		{
			return default(T);
		}
	}
}
