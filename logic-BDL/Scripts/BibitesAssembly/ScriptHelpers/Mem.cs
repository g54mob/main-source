using System;
using System.Runtime.InteropServices;

namespace ScriptHelpers
{
	public static class Mem
	{
		[DllImport("msvcrt.dll")]
		public unsafe static extern void* memcpy(void* dest, void* src, int count);

		public unsafe static void Copy(Array src, int srcOffset, Array dst, int dstOffset, int count)
		{
			if (src == null || dst == null)
			{
				throw new ArgumentNullException((src == null) ? "src" : "dst");
			}
			int num = Buffer.ByteLength(src) / src.Length * srcOffset;
			int num2 = Buffer.ByteLength(dst) / dst.Length * dstOffset;
			int count2 = Buffer.ByteLength(src) / src.Length * count;
			fixed (byte* src2 = &((byte[])src)[num])
			{
				fixed (byte* dest = &((byte[])dst)[num2])
				{
					memcpy(dest, src2, count2);
				}
			}
		}
	}
}
