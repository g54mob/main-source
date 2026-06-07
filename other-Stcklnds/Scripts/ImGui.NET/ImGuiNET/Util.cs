using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ImGuiNET
{
	internal static class Util
	{
		internal const int StackAllocationSizeLimit = 2048;

		public unsafe static string StringFromPtr(byte* ptr)
		{
			int i;
			for (i = 0; ptr[i] != 0; i++)
			{
			}
			return Encoding.UTF8.GetString(ptr, i);
		}

		internal unsafe static bool AreStringsEqual(byte* a, int aLength, byte* b)
		{
			for (int i = 0; i < aLength; i++)
			{
				if (a[i] != b[i])
				{
					return false;
				}
			}
			if (b[aLength] != 0)
			{
				return false;
			}
			return true;
		}

		internal unsafe static byte* Allocate(int byteCount)
		{
			return (byte*)(void*)Marshal.AllocHGlobal(byteCount);
		}

		internal unsafe static void Free(byte* ptr)
		{
			Marshal.FreeHGlobal((IntPtr)ptr);
		}

		internal unsafe static int CalcSizeInUtf8(string s, int start, int length)
		{
			if (start < 0 || length < 0 || start + length > s.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			fixed (char* ptr = s)
			{
				return Encoding.UTF8.GetByteCount(ptr + start, length);
			}
		}

		internal unsafe static int GetUtf8(string s, byte* utf8Bytes, int utf8ByteCount)
		{
			fixed (char* chars = s)
			{
				return Encoding.UTF8.GetBytes(chars, s.Length, utf8Bytes, utf8ByteCount);
			}
		}

		internal unsafe static int GetUtf8(string s, int start, int length, byte* utf8Bytes, int utf8ByteCount)
		{
			if (start < 0 || length < 0 || start + length > s.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			fixed (char* ptr = s)
			{
				return Encoding.UTF8.GetBytes(ptr + start, length, utf8Bytes, utf8ByteCount);
			}
		}
	}
}
