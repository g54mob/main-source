namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class SpecialDevices
	{
		private class YuJAVTlgxmaCqBuXCaTItjNVPV
		{
			public readonly ushort BrgQIQRJLDuAcBXJgGkqkzwAMUC;

			public readonly ushort zoKLHtvFVNkkMUCHuynHAkHmONk;

			public readonly string IlfeTYvSpebMqZjIwYsAbNWvauM;

			public readonly bool KNAlcOlqCvlIrXVjvjsoqdgmROl;

			public readonly int rnJdstVdTmJMdemPXtdbQdzHNQM;

			public readonly int iGsFrcbcKOkUyoRrHNiQJRxtNht;

			public readonly int yRcRtEHNlQSsWhVCtIhvrxgLGXG;

			public readonly float epfqsRFIPGIBXVfxqKiFqQVsuLi;

			public YuJAVTlgxmaCqBuXCaTItjNVPV(ushort vendorId, ushort productId, string productName, bool hasRelativeAxes, int axisMin, int axisMax, int axisZero, float relToAbsAxisConversionTimeout)
			{
				BrgQIQRJLDuAcBXJgGkqkzwAMUC = vendorId;
				zoKLHtvFVNkkMUCHuynHAkHmONk = productId;
				if (string.IsNullOrEmpty(productName))
				{
					productName = string.Empty;
				}
				IlfeTYvSpebMqZjIwYsAbNWvauM = productName;
				KNAlcOlqCvlIrXVjvjsoqdgmROl = hasRelativeAxes;
				rnJdstVdTmJMdemPXtdbQdzHNQM = axisMin;
				iGsFrcbcKOkUyoRrHNiQJRxtNht = axisMax;
				yRcRtEHNlQSsWhVCtIhvrxgLGXG = axisZero;
				epfqsRFIPGIBXVfxqKiFqQVsuLi = relToAbsAxisConversionTimeout;
			}

			public bool HgqkqUfKqesUNXtTPFPFvNWddSX(ushort P_0, ushort P_1)
			{
				if (BrgQIQRJLDuAcBXJgGkqkzwAMUC == P_0)
				{
					return zoKLHtvFVNkkMUCHuynHAkHmONk == P_1;
				}
				return false;
			}

			public bool HgqkqUfKqesUNXtTPFPFvNWddSX(ushort P_0, ushort P_1, string P_2)
			{
				if (BrgQIQRJLDuAcBXJgGkqkzwAMUC != P_0 || zoKLHtvFVNkkMUCHuynHAkHmONk != P_1)
				{
					if (!string.IsNullOrEmpty(P_2))
					{
						return IlfeTYvSpebMqZjIwYsAbNWvauM == P_2;
					}
					return false;
				}
				return true;
			}

			public bool HgqkqUfKqesUNXtTPFPFvNWddSX(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return IlfeTYvSpebMqZjIwYsAbNWvauM == P_0;
				}
				return false;
			}
		}

		private const float YvwQayoZCcfHxwjgFglEbiqQWqb = 0.034f;

		private static YuJAVTlgxmaCqBuXCaTItjNVPV[] pFRxUSvKUhxeCxIxLsOEleieFYUD = new YuJAVTlgxmaCqBuXCaTItjNVPV[3]
		{
			new YuJAVTlgxmaCqBuXCaTItjNVPV(1133, 50726, "SpaceNavigator", hasRelativeAxes: true, -350, 350, 0, 0.034f),
			new YuJAVTlgxmaCqBuXCaTItjNVPV(1133, 50728, "SpaceNavigator for Notebooks", hasRelativeAxes: true, -350, 350, 0, 0.034f),
			new YuJAVTlgxmaCqBuXCaTItjNVPV(1133, 50727, "Space Explorer", hasRelativeAxes: true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return BmrcBXiczYMArIkeKMPqWXtGFtpF(vendorId, productId, productName)?.KNAlcOlqCvlIrXVjvjsoqdgmROl ?? false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return BmrcBXiczYMArIkeKMPqWXtGFtpF(vendorId, productId, productName)?.epfqsRFIPGIBXVfxqKiFqQVsuLi ?? 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			return GetRelativeAxisRanges(vendorId, productId, null, out min, out max, out zero);
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			for (int i = 0; i < pFRxUSvKUhxeCxIxLsOEleieFYUD.Length; i++)
			{
				if (pFRxUSvKUhxeCxIxLsOEleieFYUD[i].HgqkqUfKqesUNXtTPFPFvNWddSX(vendorId, productId) && pFRxUSvKUhxeCxIxLsOEleieFYUD[i].KNAlcOlqCvlIrXVjvjsoqdgmROl)
				{
					min = pFRxUSvKUhxeCxIxLsOEleieFYUD[i].rnJdstVdTmJMdemPXtdbQdzHNQM;
					max = pFRxUSvKUhxeCxIxLsOEleieFYUD[i].iGsFrcbcKOkUyoRrHNiQJRxtNht;
					zero = pFRxUSvKUhxeCxIxLsOEleieFYUD[i].yRcRtEHNlQSsWhVCtIhvrxgLGXG;
					return true;
				}
			}
			min = 0;
			max = 0;
			zero = 0;
			return false;
		}

		public static bool IsSupportedSpecialDevice(ushort vendorId, ushort productId, string productName = null)
		{
			return LmVuiLjsJrdGHhluIvlsahoqaex(vendorId, productId, productName);
		}

		private static bool LmVuiLjsJrdGHhluIvlsahoqaex(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < pFRxUSvKUhxeCxIxLsOEleieFYUD.Length; i++)
			{
				if (pFRxUSvKUhxeCxIxLsOEleieFYUD[i].HgqkqUfKqesUNXtTPFPFvNWddSX(P_0, P_1, P_2))
				{
					return true;
				}
			}
			return false;
		}

		private static YuJAVTlgxmaCqBuXCaTItjNVPV BmrcBXiczYMArIkeKMPqWXtGFtpF(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < pFRxUSvKUhxeCxIxLsOEleieFYUD.Length; i++)
			{
				if (pFRxUSvKUhxeCxIxLsOEleieFYUD[i].HgqkqUfKqesUNXtTPFPFvNWddSX(P_0, P_1, P_2))
				{
					return pFRxUSvKUhxeCxIxLsOEleieFYUD[i];
				}
			}
			return null;
		}
	}
}
