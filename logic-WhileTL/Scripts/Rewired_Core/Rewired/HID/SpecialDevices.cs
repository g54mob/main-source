namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class SpecialDevices
	{
		private class eYcjETfUtOAElCtQnSNEyLUdrRtu
		{
			public readonly ushort fSoHPUfJCksYThdbElmhKTIwCwuC;

			public readonly ushort BKKOorJJLcGhpuCjWgkAccaWERACA;

			public readonly string owfHvPZuMHnTvzhNYgLnJnqLLyAr;

			public readonly bool uPEYyQXaUEFFAlCJZFgzHCNMbJNpA;

			public readonly int RLJrcltjfHprOKQCxAkusbWjSDkM;

			public readonly int UvscAqHXOhgwFkUHfCfXabYDxdNab;

			public readonly int YtkssGbxlzQRnLseFyQaVDHdPikF;

			public readonly float WTdKzkzYEcunmrZVPLqhUdxrwJbg;

			public eYcjETfUtOAElCtQnSNEyLUdrRtu(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
			{
				fSoHPUfJCksYThdbElmhKTIwCwuC = P_0;
				BKKOorJJLcGhpuCjWgkAccaWERACA = P_1;
				if (string.IsNullOrEmpty(P_2))
				{
					P_2 = string.Empty;
				}
				owfHvPZuMHnTvzhNYgLnJnqLLyAr = P_2;
				uPEYyQXaUEFFAlCJZFgzHCNMbJNpA = P_3;
				RLJrcltjfHprOKQCxAkusbWjSDkM = P_4;
				UvscAqHXOhgwFkUHfCfXabYDxdNab = P_5;
				YtkssGbxlzQRnLseFyQaVDHdPikF = P_6;
				WTdKzkzYEcunmrZVPLqhUdxrwJbg = P_7;
			}

			public bool rbwxKTRcrHcsrnbLpSUTDfnPltxb(ushort P_0, ushort P_1)
			{
				if (fSoHPUfJCksYThdbElmhKTIwCwuC == P_0)
				{
					return BKKOorJJLcGhpuCjWgkAccaWERACA == P_1;
				}
				return false;
			}

			public bool rbwxKTRcrHcsrnbLpSUTDfnPltxb(ushort P_0, ushort P_1, string P_2)
			{
				if (fSoHPUfJCksYThdbElmhKTIwCwuC != P_0 || BKKOorJJLcGhpuCjWgkAccaWERACA != P_1)
				{
					if (!string.IsNullOrEmpty(P_2))
					{
						return owfHvPZuMHnTvzhNYgLnJnqLLyAr == P_2;
					}
					return false;
				}
				return true;
			}

			public bool rbwxKTRcrHcsrnbLpSUTDfnPltxb(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return owfHvPZuMHnTvzhNYgLnJnqLLyAr == P_0;
				}
				return false;
			}
		}

		private const float qFeuRuIkURFNMBGCxDrVqBBokANZ = 0.034f;

		private static eYcjETfUtOAElCtQnSNEyLUdrRtu[] TxRVuMXfMGWlpPABjaRBXKPQpGyq = new eYcjETfUtOAElCtQnSNEyLUdrRtu[3]
		{
			new eYcjETfUtOAElCtQnSNEyLUdrRtu(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
			new eYcjETfUtOAElCtQnSNEyLUdrRtu(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
			new eYcjETfUtOAElCtQnSNEyLUdrRtu(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return nPvErXYwpzyuOWkEoMFlrWQaphHm(vendorId, productId, productName)?.uPEYyQXaUEFFAlCJZFgzHCNMbJNpA ?? false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return nPvErXYwpzyuOWkEoMFlrWQaphHm(vendorId, productId, productName)?.WTdKzkzYEcunmrZVPLqhUdxrwJbg ?? 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			return GetRelativeAxisRanges(vendorId, productId, null, out min, out max, out zero);
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			for (int i = 0; i < TxRVuMXfMGWlpPABjaRBXKPQpGyq.Length; i++)
			{
				if (TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].rbwxKTRcrHcsrnbLpSUTDfnPltxb(vendorId, productId) && TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].uPEYyQXaUEFFAlCJZFgzHCNMbJNpA)
				{
					min = TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].RLJrcltjfHprOKQCxAkusbWjSDkM;
					max = TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].UvscAqHXOhgwFkUHfCfXabYDxdNab;
					zero = TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].YtkssGbxlzQRnLseFyQaVDHdPikF;
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
			return xAXXrXFmRQrVcXxIwQodClNOAyHW(vendorId, productId, productName);
		}

		private static bool xAXXrXFmRQrVcXxIwQodClNOAyHW(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < TxRVuMXfMGWlpPABjaRBXKPQpGyq.Length; i++)
			{
				if (TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].rbwxKTRcrHcsrnbLpSUTDfnPltxb(P_0, P_1, P_2))
				{
					return true;
				}
			}
			return false;
		}

		private static eYcjETfUtOAElCtQnSNEyLUdrRtu nPvErXYwpzyuOWkEoMFlrWQaphHm(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < TxRVuMXfMGWlpPABjaRBXKPQpGyq.Length; i++)
			{
				if (TxRVuMXfMGWlpPABjaRBXKPQpGyq[i].rbwxKTRcrHcsrnbLpSUTDfnPltxb(P_0, P_1, P_2))
				{
					return TxRVuMXfMGWlpPABjaRBXKPQpGyq[i];
				}
			}
			return null;
		}
	}
}
