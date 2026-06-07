using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave.Compression
{
	internal class AcmInterop
	{
		public delegate bool AcmDriverEnumCallback(IntPtr hAcmDriverId, IntPtr instance, AcmDriverDetailsSupportFlags flags);

		public delegate bool AcmFormatEnumCallback(IntPtr hAcmDriverId, ref AcmFormatDetails formatDetails, IntPtr dwInstance, AcmDriverDetailsSupportFlags flags);

		public delegate bool AcmFormatTagEnumCallback(IntPtr hAcmDriverId, ref AcmFormatTagDetails formatTagDetails, IntPtr dwInstance, AcmDriverDetailsSupportFlags flags);

		public delegate bool AcmFormatChooseHookProc(IntPtr windowHandle, int message, IntPtr wParam, IntPtr lParam);

		[PreserveSig]
		public static extern MmResult acmDriverAdd(out IntPtr driverHandle, IntPtr driverModule, IntPtr driverFunctionAddress, int priority, AcmDriverAddFlags flags);

		[PreserveSig]
		public static extern MmResult acmDriverRemove(IntPtr driverHandle, int removeFlags);

		[PreserveSig]
		public static extern MmResult acmDriverClose(IntPtr hAcmDriver, int closeFlags);

		[PreserveSig]
		public static extern MmResult acmDriverEnum(AcmDriverEnumCallback fnCallback, IntPtr dwInstance, AcmDriverEnumFlags flags);

		[PreserveSig]
		public static extern MmResult acmDriverDetails(IntPtr hAcmDriver, ref AcmDriverDetails driverDetails, int reserved);

		[PreserveSig]
		public static extern MmResult acmDriverOpen(out IntPtr pAcmDriver, IntPtr hAcmDriverId, int openFlags);

		[PreserveSig]
		public static extern MmResult acmFormatChoose(ref AcmFormatChoose formatChoose);

		[PreserveSig]
		public static extern MmResult acmFormatEnum(IntPtr hAcmDriver, ref AcmFormatDetails formatDetails, AcmFormatEnumCallback callback, IntPtr instance, AcmFormatEnumFlags flags);

		[PreserveSig]
		public static extern MmResult acmFormatSuggest(IntPtr hAcmDriver, [In] WaveFormat sourceFormat, [In][Out] WaveFormat destFormat, int sizeDestFormat, AcmFormatSuggestFlags suggestFlags);

		[PreserveSig]
		public static extern MmResult acmFormatSuggest2(IntPtr hAcmDriver, IntPtr sourceFormatPointer, IntPtr destFormatPointer, int sizeDestFormat, AcmFormatSuggestFlags suggestFlags);

		[PreserveSig]
		public static extern MmResult acmFormatTagEnum(IntPtr hAcmDriver, ref AcmFormatTagDetails formatTagDetails, AcmFormatTagEnumCallback callback, IntPtr instance, int reserved);

		[PreserveSig]
		public static extern MmResult acmMetrics(IntPtr hAcmObject, AcmMetrics metric, out int output);

		[PreserveSig]
		public static extern MmResult acmStreamOpen(out IntPtr hAcmStream, IntPtr hAcmDriver, [In] WaveFormat sourceFormat, [In] WaveFormat destFormat, [In] WaveFilter waveFilter, IntPtr callback, IntPtr instance, AcmStreamOpenFlags openFlags);

		[PreserveSig]
		public static extern MmResult acmStreamOpen2(out IntPtr hAcmStream, IntPtr hAcmDriver, IntPtr sourceFormatPointer, IntPtr destFormatPointer, [In] WaveFilter waveFilter, IntPtr callback, IntPtr instance, AcmStreamOpenFlags openFlags);

		[PreserveSig]
		public static extern MmResult acmStreamClose(IntPtr hAcmStream, int closeFlags);

		[PreserveSig]
		public static extern MmResult acmStreamConvert(IntPtr hAcmStream, [In][Out] AcmStreamHeaderStruct streamHeader, AcmStreamConvertFlags streamConvertFlags);

		[PreserveSig]
		public static extern MmResult acmStreamPrepareHeader(IntPtr hAcmStream, [In][Out] AcmStreamHeaderStruct streamHeader, int prepareFlags);

		[PreserveSig]
		public static extern MmResult acmStreamReset(IntPtr hAcmStream, int resetFlags);

		[PreserveSig]
		public static extern MmResult acmStreamSize(IntPtr hAcmStream, int inputBufferSize, out int outputBufferSize, AcmStreamSizeFlags flags);

		[PreserveSig]
		public static extern MmResult acmStreamUnprepareHeader(IntPtr hAcmStream, [In][Out] AcmStreamHeaderStruct streamHeader, int flags);
	}
}
