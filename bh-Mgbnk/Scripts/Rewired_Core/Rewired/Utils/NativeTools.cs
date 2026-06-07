using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class NativeTools
	{
		private static byte[] GblhcqRovoODkWBcueHqwaOcgVGk;

		public static IntPtr OffsetIntPtr(IntPtr intPtr, int offset)
		{
			return (IntPtr)0;
		}

		public static bool CopyMemory(IntPtr source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			return false;
		}

		public static bool CopyMemory(byte[] source, IntPtr destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			return false;
		}

		public static bool CopyMemory(IntPtr source, byte[] destination, int sourceStartIndex, int destinationStartIndex, int bytesToCopy, bool throwOnError = true)
		{
			return false;
		}

		public static bool FillMemory(IntPtr buffer, int length, byte value, bool throwOnError = true)
		{
			return false;
		}

		public static bool FillMemory(IntPtr buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			return false;
		}

		public static bool FillMemory(byte[] buffer, int length, byte value, bool throwOnError = true)
		{
			return false;
		}

		public static bool FillMemory(byte[] buffer, int startIndex, int length, byte value, bool throwOnError = true)
		{
			return false;
		}

		public static void ZeroFillMemory(IntPtr buffer, int length)
		{
		}

		public static string DumpToString(IntPtr buffer, int length, string stringFormat = "x2")
		{
			return null;
		}

		public static void FreeHGlobalSafe(ref IntPtr pointer)
		{
		}
	}
}
