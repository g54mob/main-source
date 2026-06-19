using System.Runtime.InteropServices;

namespace IdSharp.Inspection
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct VBRData
	{
		public bool Found;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] ID;

		public int Frames;

		public int Bytes;

		public byte Scale;

		public string VendorID;
	}
}
