using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public static class IntPtrUtility
	{
		private const string kZuluFormat = "yyyy-MM-dd HH:mm:ss zzz";

		public static string AsString(this IntPtr ptr)
		{
			return null;
		}

		public static DateTime AsDateTime(this IntPtr ptr)
		{
			return default(DateTime);
		}

		public static DateTime? AsOptionalDateTime(this IntPtr ptr)
		{
			return null;
		}

		public static T AsStruct<T>(this IntPtr ptr) where T : struct
		{
			return default(T);
		}
	}
}
