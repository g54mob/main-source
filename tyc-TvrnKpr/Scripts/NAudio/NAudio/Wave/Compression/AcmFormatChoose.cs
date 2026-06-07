using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	[StructLayout((LayoutKind)0, CharSet = CharSet.Auto, Pack = 4, Size = 444)]
	internal struct AcmFormatChoose
	{
		public int structureSize;

		public AcmFormatChooseStyleFlags styleFlags;

		public IntPtr ownerWindowHandle;

		public IntPtr selectedWaveFormatPointer;

		public int selectedWaveFormatByteSize;

		public string title;

		public string formatTagDescription;

		public string formatDescription;

		public string name;

		public int nameByteSize;

		public AcmFormatEnumFlags formatEnumFlags;

		public IntPtr waveFormatEnumPointer;

		public IntPtr instanceHandle;

		public string templateName;

		public IntPtr customData;

		public AcmInterop.AcmFormatChooseHookProc windowCallbackFunction;
	}
}
