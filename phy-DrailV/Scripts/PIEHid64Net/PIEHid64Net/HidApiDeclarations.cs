using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace PIEHid64Net
{
	internal sealed class HidApiDeclarations
	{
		public struct HIDD_ATTRIBUTES
		{
			public int Size;

			public short VendorID;

			public short ProductID;

			public short VersionNumber;
		}

		public struct HIDP_CAPS
		{
			public short Usage;

			public short UsagePage;

			public short InputReportByteLength;

			public short OutputReportByteLength;

			public short FeatureReportByteLength;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
			public short[] Reserved;

			public short NumberLinkCollectionNodes;

			public short NumberInputButtonCaps;

			public short NumberInputValueCaps;

			public short NumberInputDataIndices;

			public short NumberOutputButtonCaps;

			public short NumberOutputValueCaps;

			public short NumberOutputDataIndices;

			public short NumberFeatureButtonCaps;

			public short NumberFeatureValueCaps;

			public short NumberFeatureDataIndices;
		}

		public struct HidP_Value_Caps
		{
			public short UsagePage;

			public byte ReportID;

			public int IsAlias;

			public short BitField;

			public short LinkCollection;

			public short LinkUsage;

			public short LinkUsagePage;

			public int IsRange;

			public int IsStringRange;

			public int IsDesignatorRange;

			public int IsAbsolute;

			public int HasNull;

			public byte Reserved;

			public short BitSize;

			public short ReportCount;

			public short Reserved2;

			public short Reserved3;

			public short Reserved4;

			public short Reserved5;

			public short Reserved6;

			public int LogicalMin;

			public int LogicalMax;

			public int PhysicalMin;

			public int PhysicalMax;

			public short UsageMin;

			public short UsageMax;

			public short StringMin;

			public short StringMax;

			public short DesignatorMin;

			public short DesignatorMax;

			public short DataIndexMin;

			public short DataIndexMax;
		}

		public const short HidP_Input = 0;

		public const short HidP_Output = 1;

		public const short HidP_Feature = 2;

		[DllImport("hid.dll")]
		public static extern bool HidD_FlushQueue(SafeFileHandle HidDeviceObject);

		[DllImport("hid.dll")]
		public static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);

		[DllImport("hid.dll")]
		public static extern int HidD_GetAttributes(SafeFileHandle HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);

		[DllImport("hid.dll")]
		public static extern bool HidD_GetFeature(SafeFileHandle HidDeviceObject, ref byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll")]
		public static extern bool HidD_GetInputReport(SafeFileHandle HidDeviceObject, ref byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll")]
		public static extern void HidD_GetHidGuid(ref Guid HidGuid);

		[DllImport("hid.dll")]
		public static extern int HidD_GetManufacturerString(SafeFileHandle HidDeviceObject, ref byte sss, int StringSize);

		[DllImport("hid.dll")]
		public static extern bool HidD_GetNumInputBuffers(SafeFileHandle HidDeviceObject, ref int NumberBuffers);

		[DllImport("hid.dll")]
		public static extern bool HidD_GetPreparsedData(SafeFileHandle HidDeviceObject, ref IntPtr PreparsedData);

		[DllImport("hid.dll")]
		public static extern int HidD_GetProductString(SafeFileHandle HidDeviceObject, ref byte sss, int StringSize);

		[DllImport("hid.dll")]
		public static extern int HidD_GetSerialNumberString(SafeFileHandle HidDeviceObject, ref byte sss, int StringSize);

		[DllImport("hid.dll")]
		public static extern bool HidD_SetFeature(SafeFileHandle HidDeviceObject, ref byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll")]
		public static extern bool HidD_SetNumInputBuffers(SafeFileHandle HidDeviceObject, int NumberBuffers);

		[DllImport("hid.dll")]
		public static extern bool HidD_SetOutputReport(SafeFileHandle HidDeviceObject, ref byte lpReportBuffer, int ReportBufferLength);

		[DllImport("hid.dll")]
		public static extern int HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

		[DllImport("hid.dll")]
		public static extern int HidP_GetValueCaps(short ReportType, ref byte ValueCaps, ref short ValueCapsLength, IntPtr PreparsedData);
	}
}
