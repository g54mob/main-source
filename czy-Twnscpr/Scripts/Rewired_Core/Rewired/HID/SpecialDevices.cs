namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal static class SpecialDevices
	{
		private class fbZrApBTkWZXHCiecYAfYMZZoHq
		{
			public readonly ushort sPNokwVErqMphtxZJgjMajXCHvj;

			public readonly ushort CUnojPxdpoRDXcpBNErfHImankFX;

			public readonly string jmYEEjruMZKNpvrYHGIUrqItRJf;

			public readonly bool pTdJOgnNgIEHmrfbIHrMqDNgDqK;

			public readonly int QokLeJRFrJoBeSKiqbRHYHEBoMr;

			public readonly int NMNbzOzegbFtjMqtiFauBTWnJQCY;

			public readonly int RQJpByBvRfLXLHLYYBbPnSPRBaz;

			public readonly float BWEMQLZkgapeQfdkKUHMoxTXReq;

			public fbZrApBTkWZXHCiecYAfYMZZoHq(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
			}

			public bool olZfOirBUNwfInDNwmVvvfhlxOk(ushort P_0, ushort P_1)
			{
				return false;
			}

			public bool olZfOirBUNwfInDNwmVvvfhlxOk(ushort P_0, ushort P_1, string P_2)
			{
				return false;
			}

			public bool olZfOirBUNwfInDNwmVvvfhlxOk(string P_0)
			{
				return false;
			}
		}

		private const float lVFaeAusgLAbwCyakgzkpnNAzuQ = 0.034f;

		private static fbZrApBTkWZXHCiecYAfYMZZoHq[] AgqswmdboWdJTDRbyyUspIJgAbfb;

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			min = default(int);
			max = default(int);
			zero = default(int);
			return false;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			min = default(int);
			max = default(int);
			zero = default(int);
			return false;
		}

		public static bool IsSupportedSpecialDevice(ushort vendorId, ushort productId, string productName = null)
		{
			return false;
		}

		private static bool oswSUllPnQMJIFXybtLCgoPsXeG(ushort P_0, ushort P_1, string P_2 = null)
		{
			return false;
		}

		private static fbZrApBTkWZXHCiecYAfYMZZoHq inSEttDcFhjlaDCaJrXMoPCbQYCj(ushort P_0, ushort P_1, string P_2 = null)
		{
			return null;
		}
	}
}
