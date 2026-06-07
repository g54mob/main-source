using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	[StructLayout((LayoutKind)0, Pack = 4, Size = 156)]
	internal struct AcmFormatDetails
	{
		public int structSize;

		public int formatIndex;

		public int formatTag;

		public AcmDriverDetailsSupportFlags supportFlags;

		public IntPtr waveFormatPointer;

		public int waveFormatByteSize;

		public string formatDescription;

		public const int FormatDescriptionChars = 128;
	}
}
