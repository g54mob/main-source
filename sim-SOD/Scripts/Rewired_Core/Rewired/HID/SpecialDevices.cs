namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class SpecialDevices
	{
		private class mMqDRAkpxksGZISaoBbDIgnwDoqi
		{
			public readonly ushort lhiGCPjbBGGizbMRLFDsWLmrDlni;

			public readonly ushort TyMDeiLNLCYnHsiBTYfJovJXikH;

			public readonly string wklaaYETQzeRPqtlDkbmWTPSoNBB;

			public readonly bool kcINnJBcSubHeahhWHGeIKgAVoIK;

			public readonly int XyDSvilZjruxcQqguPGliTxoEyf;

			public readonly int IgqENbXlOJjmdYabybFUbrnIfCYF;

			public readonly int EigpwVxsdDWCZPAQOJSfBPimkTp;

			public readonly float EitCkthlEGjyWVlnWafqhWIhsXwh;

			public mMqDRAkpxksGZISaoBbDIgnwDoqi(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
			}

			public bool zryBaXXTmhqyQjDHkGkLNbAGUGi(ushort P_0, ushort P_1)
			{
				return false;
			}

			public bool zryBaXXTmhqyQjDHkGkLNbAGUGi(ushort P_0, ushort P_1, string P_2)
			{
				return false;
			}

			public bool zryBaXXTmhqyQjDHkGkLNbAGUGi(string P_0)
			{
				return false;
			}
		}

		private const float iRoNKjWwOtTSoGcwwaVKPxohPzA = 0.034f;

		private static mMqDRAkpxksGZISaoBbDIgnwDoqi[] LjNYqNFaMqWHFBdnchMUZiiTjnd;

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

		private static bool dNBnySRSVaDFWZLynJGqATeZMBG(ushort P_0, ushort P_1, string P_2 = null)
		{
			return false;
		}

		private static mMqDRAkpxksGZISaoBbDIgnwDoqi rrDGOItwDkcRAmspaoKlvIjGDS(ushort P_0, ushort P_1, string P_2 = null)
		{
			return null;
		}
	}
}
