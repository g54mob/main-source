using System;
using System.Collections.Generic;

namespace NAudio.Wave.Compression
{
	public class AcmDriver : IDisposable
	{
		private static List<AcmDriver> drivers;

		private AcmDriverDetails details;

		private IntPtr driverId;

		private IntPtr driverHandle;

		private List<AcmFormatTag> formatTags;

		private List<AcmFormat> tempFormatsList;

		private IntPtr localDllHandle;

		public int MaxFormatSize => 0;

		public string ShortName => null;

		public string LongName => null;

		public IntPtr DriverId => (IntPtr)0;

		public IEnumerable<AcmFormatTag> FormatTags => null;

		public static bool IsCodecInstalled(string shortName)
		{
			return false;
		}

		public static AcmDriver AddLocalDriver(string driverFile)
		{
			return null;
		}

		public static void RemoveLocalDriver(AcmDriver localDriver)
		{
		}

		public static bool ShowFormatChooseDialog(IntPtr ownerWindowHandle, string windowTitle, AcmFormatEnumFlags enumFlags, WaveFormat enumFormat, out WaveFormat selectedFormat, out string selectedFormatDescription, out string selectedFormatTagDescription)
		{
			selectedFormat = null;
			selectedFormatDescription = null;
			selectedFormatTagDescription = null;
			return false;
		}

		public static AcmDriver FindByShortName(string shortName)
		{
			return null;
		}

		public static IEnumerable<AcmDriver> EnumerateAcmDrivers()
		{
			return null;
		}

		private static bool DriverEnumCallback(IntPtr hAcmDriver, IntPtr dwInstance, AcmDriverDetailsSupportFlags flags)
		{
			return false;
		}

		private AcmDriver(IntPtr hAcmDriver)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public IEnumerable<AcmFormat> GetFormats(AcmFormatTag formatTag)
		{
			return null;
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		private bool AcmFormatTagEnumCallback(IntPtr hAcmDriverId, ref AcmFormatTagDetails formatTagDetails, IntPtr dwInstance, AcmDriverDetailsSupportFlags flags)
		{
			return false;
		}

		private bool AcmFormatEnumCallback(IntPtr hAcmDriverId, ref AcmFormatDetails formatDetails, IntPtr dwInstance, AcmDriverDetailsSupportFlags flags)
		{
			return false;
		}

		public void Dispose()
		{
		}
	}
}
