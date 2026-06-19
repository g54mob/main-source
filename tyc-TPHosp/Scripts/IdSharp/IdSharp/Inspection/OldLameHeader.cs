using System.IO;
using System.Runtime.InteropServices;

namespace IdSharp.Inspection
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct OldLameHeader
	{
		public byte UnusedByte;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Encoder;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.AsAny)]
		public byte[] VersionString;

		public static OldLameHeader FromBinaryReader(BinaryReader br)
		{
			return new OldLameHeader
			{
				UnusedByte = br.ReadByte(),
				Encoder = br.ReadBytes(4),
				VersionString = br.ReadBytes(16)
			};
		}
	}
}
