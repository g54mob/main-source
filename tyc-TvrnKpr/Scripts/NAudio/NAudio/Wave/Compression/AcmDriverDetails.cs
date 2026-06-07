using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	[StructLayout((LayoutKind)0, Pack = 2, Size = 924)]
	internal struct AcmDriverDetails
	{
		public int structureSize;

		public uint fccType;

		public uint fccComp;

		public ushort manufacturerId;

		public ushort productId;

		public uint acmVersion;

		public uint driverVersion;

		public AcmDriverDetailsSupportFlags supportFlags;

		public int formatTagsCount;

		public int filterTagsCount;

		public IntPtr hicon;

		public string shortName;

		public string longName;

		public string copyright;

		public string licensing;

		public string features;

		private const int ShortNameChars = 32;

		private const int LongNameChars = 128;

		private const int CopyrightChars = 80;

		private const int LicensingChars = 128;

		private const int FeaturesChars = 512;
	}
}
