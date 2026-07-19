using System;
using System.IO;
using System.Runtime.InteropServices;

namespace UniGLTF
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct GlbHeader
	{
		public static void WriteTo(Stream s)
		{
			s.WriteByte(103);
			s.WriteByte(108);
			s.WriteByte(84);
			s.WriteByte(70);
			byte[] bytes = BitConverter.GetBytes(2u);
			s.Write(bytes, 0, bytes.Length);
		}
	}
}
