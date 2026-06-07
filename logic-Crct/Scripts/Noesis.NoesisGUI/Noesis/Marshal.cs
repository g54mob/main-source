using System;

namespace Noesis
{
	public static class Marshal
	{
		public static void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld)
		{
		}

		public static T PtrToStructure<T>(IntPtr ptr)
		{
			return default(T);
		}

		public static IntPtr StringToHGlobalAnsi(string s)
		{
			return (IntPtr)0;
		}

		public static string PtrToStringAnsi(IntPtr ptr)
		{
			return null;
		}

		public static IntPtr StringToHGlobalUni(string s)
		{
			return (IntPtr)0;
		}

		public static int SizeOf<T>()
		{
			return 0;
		}

		public static IntPtr AllocHGlobal(int numBytes)
		{
			return (IntPtr)0;
		}

		public static void FreeHGlobal(IntPtr hglobal)
		{
		}

		public static void Copy(IntPtr source, byte[] destination, int startIndex, int length)
		{
		}

		public static byte ReadByte(IntPtr ptr, int offset)
		{
			return 0;
		}

		public static IntPtr ReadIntPtr(IntPtr ptr, int ofs)
		{
			return (IntPtr)0;
		}

		public static void WriteInt32(IntPtr ptr, int ofs, int val)
		{
		}

		public static void WriteInt64(IntPtr ptr, int ofs, long val)
		{
		}

		public static void WriteIntPtr(IntPtr ptr, int ofs, IntPtr val)
		{
		}

		public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t)
		{
			return null;
		}

		public static int GetLastWin32Error()
		{
			return 0;
		}
	}
}
