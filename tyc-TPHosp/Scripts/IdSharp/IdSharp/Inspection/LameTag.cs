using System.IO;
using System.Runtime.InteropServices;

namespace IdSharp.Inspection
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct LameTag
	{
		public byte Quality;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Encoder;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.AsAny)]
		public byte[] VersionString;

		public byte TagRevision_EncodingMethod;

		public byte Lowpass;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.AsAny)]
		public byte[] ReplayGain;

		public byte EncodingFlags_ATHType;

		public byte Bitrate;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.AsAny)]
		public byte[] EncoderDelays;

		public byte MiscInfo;

		public byte MP3Gain;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.AsAny)]
		public byte[] Surround_Preset;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.AsAny)]
		public byte[] MusicLength;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.AsAny)]
		public byte[] MusicCRC;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.AsAny)]
		public byte[] InfoTagCRC;

		public byte NoiseShaping;

		public byte StereoMode;

		public static LameTag FromBinaryReader(BinaryReader br)
		{
			LameTag result = default(LameTag);
			result.Quality = br.ReadByte();
			result.Encoder = br.ReadBytes(4);
			result.VersionString = br.ReadBytes(5);
			result.TagRevision_EncodingMethod = (byte)(br.ReadByte() & 0xF);
			result.Lowpass = br.ReadByte();
			result.ReplayGain = br.ReadBytes(8);
			result.EncodingFlags_ATHType = (byte)(br.ReadByte() & 0xF);
			result.Bitrate = br.ReadByte();
			result.EncoderDelays = br.ReadBytes(3);
			result.MiscInfo = br.ReadByte();
			result.MP3Gain = br.ReadByte();
			result.Surround_Preset = br.ReadBytes(2);
			result.MusicLength = br.ReadBytes(4);
			result.MusicCRC = br.ReadBytes(2);
			result.InfoTagCRC = br.ReadBytes(2);
			result.NoiseShaping = (byte)(result.MiscInfo & 3);
			result.StereoMode = (byte)((result.MiscInfo & 0x1C) >> 2);
			return result;
		}
	}
}
