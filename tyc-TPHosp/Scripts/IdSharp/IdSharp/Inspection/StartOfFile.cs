using System.IO;
using System.Runtime.InteropServices;

namespace IdSharp.Inspection
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StartOfFile
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Misc1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Info1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Misc2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Info2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Misc3;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Info3;

		public static StartOfFile FromBinaryReader(BinaryReader br)
		{
			return new StartOfFile
			{
				Misc1 = br.ReadBytes(13),
				Info1 = br.ReadBytes(4),
				Misc2 = br.ReadBytes(4),
				Info2 = br.ReadBytes(4),
				Misc3 = br.ReadBytes(11),
				Info3 = br.ReadBytes(4)
			};
		}
	}
}
