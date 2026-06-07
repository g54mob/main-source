namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class SpecialDevices
	{
		private class SlZVHNjNVboyGIduFLgTBJKSwITv
		{
			public readonly ushort lCauwKXCMTUJUlmnZwFeQLAWrGjn;

			public readonly ushort rqsZiuAdKVpQNApjCdLSJHAYhtMC;

			public readonly string rQqdAcfyhRveZnzrmkZHJYcJLFld;

			public readonly bool ZSUAYwJGTBAwLPgHRqrqHewZlnBB;

			public readonly int oKaYQKNoWyfdXVPhhAUTeMfhXlGqA;

			public readonly int DBAjrviQIzrNdgbpqRdTARdSEajV;

			public readonly int zmTeXajtISgEhaKGfHYKMPkfhHPQ;

			public readonly float ecwAtVfYfZIkiAaKCTQomKzCGOKTA;

			public SlZVHNjNVboyGIduFLgTBJKSwITv(ushort P_0, ushort P_1, string P_2, bool P_3, int P_4, int P_5, int P_6, float P_7)
			{
				lCauwKXCMTUJUlmnZwFeQLAWrGjn = P_0;
				rqsZiuAdKVpQNApjCdLSJHAYhtMC = P_1;
				if (string.IsNullOrEmpty(P_2))
				{
					P_2 = string.Empty;
				}
				rQqdAcfyhRveZnzrmkZHJYcJLFld = P_2;
				ZSUAYwJGTBAwLPgHRqrqHewZlnBB = P_3;
				oKaYQKNoWyfdXVPhhAUTeMfhXlGqA = P_4;
				DBAjrviQIzrNdgbpqRdTARdSEajV = P_5;
				zmTeXajtISgEhaKGfHYKMPkfhHPQ = P_6;
				ecwAtVfYfZIkiAaKCTQomKzCGOKTA = P_7;
			}

			public bool rRWadxOJguQcEQrVsaOKgqotkbbX(ushort P_0, ushort P_1)
			{
				if (lCauwKXCMTUJUlmnZwFeQLAWrGjn == P_0)
				{
					return rqsZiuAdKVpQNApjCdLSJHAYhtMC == P_1;
				}
				return false;
			}

			public bool awJWEHccLHkiSiLjKIUAGxmkDpIW(ushort P_0, ushort P_1, string P_2)
			{
				if (lCauwKXCMTUJUlmnZwFeQLAWrGjn != P_0 || rqsZiuAdKVpQNApjCdLSJHAYhtMC != P_1)
				{
					if (!string.IsNullOrEmpty(P_2))
					{
						return rQqdAcfyhRveZnzrmkZHJYcJLFld == P_2;
					}
					return false;
				}
				return true;
			}

			public bool uhYWOiNRzDCgpyzpudJRvQBVfJjF(string P_0)
			{
				if (!string.IsNullOrEmpty(P_0))
				{
					return rQqdAcfyhRveZnzrmkZHJYcJLFld == P_0;
				}
				return false;
			}
		}

		private const float FJsKYXYfNBoGvlYFyJkARPsVEIZR = 0.034f;

		private static SlZVHNjNVboyGIduFLgTBJKSwITv[] DVxoTCSowPNEXRfSzjheRApGudfF = new SlZVHNjNVboyGIduFLgTBJKSwITv[3]
		{
			new SlZVHNjNVboyGIduFLgTBJKSwITv(1133, 50726, "SpaceNavigator", true, -350, 350, 0, 0.034f),
			new SlZVHNjNVboyGIduFLgTBJKSwITv(1133, 50728, "SpaceNavigator for Notebooks", true, -350, 350, 0, 0.034f),
			new SlZVHNjNVboyGIduFLgTBJKSwITv(1133, 50727, "Space Explorer", true, -350, 350, 0, 0.034f)
		};

		public static bool RequiresRelativeToAbsoluteAxisConversion(ushort vendorId, ushort productId, string productName = null)
		{
			return RCKMsAZhTVsjdaTQGBElSDCIeFkFA(vendorId, productId, productName)?.ZSUAYwJGTBAwLPgHRqrqHewZlnBB ?? false;
		}

		public static float GetRelativeToAbsoluteAxisEventTimeout(ushort vendorId, ushort productId, string productName = null)
		{
			return RCKMsAZhTVsjdaTQGBElSDCIeFkFA(vendorId, productId, productName)?.ecwAtVfYfZIkiAaKCTQomKzCGOKTA ?? 0f;
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, out int min, out int max, out int zero)
		{
			return GetRelativeAxisRanges(vendorId, productId, null, out min, out max, out zero);
		}

		public static bool GetRelativeAxisRanges(ushort vendorId, ushort productId, string productName, out int min, out int max, out int zero)
		{
			for (int i = 0; i < DVxoTCSowPNEXRfSzjheRApGudfF.Length; i++)
			{
				if (DVxoTCSowPNEXRfSzjheRApGudfF[i].rRWadxOJguQcEQrVsaOKgqotkbbX(vendorId, productId) && DVxoTCSowPNEXRfSzjheRApGudfF[i].ZSUAYwJGTBAwLPgHRqrqHewZlnBB)
				{
					min = DVxoTCSowPNEXRfSzjheRApGudfF[i].oKaYQKNoWyfdXVPhhAUTeMfhXlGqA;
					max = DVxoTCSowPNEXRfSzjheRApGudfF[i].DBAjrviQIzrNdgbpqRdTARdSEajV;
					zero = DVxoTCSowPNEXRfSzjheRApGudfF[i].zmTeXajtISgEhaKGfHYKMPkfhHPQ;
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
			return aQQCcXLgJOKXtluhOUYLMwKPMbBF(vendorId, productId, productName);
		}

		private static bool aQQCcXLgJOKXtluhOUYLMwKPMbBF(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < DVxoTCSowPNEXRfSzjheRApGudfF.Length; i++)
			{
				if (DVxoTCSowPNEXRfSzjheRApGudfF[i].awJWEHccLHkiSiLjKIUAGxmkDpIW(P_0, P_1, P_2))
				{
					return true;
				}
			}
			return false;
		}

		private static SlZVHNjNVboyGIduFLgTBJKSwITv RCKMsAZhTVsjdaTQGBElSDCIeFkFA(ushort P_0, ushort P_1, string P_2 = null)
		{
			for (int i = 0; i < DVxoTCSowPNEXRfSzjheRApGudfF.Length; i++)
			{
				if (DVxoTCSowPNEXRfSzjheRApGudfF[i].awJWEHccLHkiSiLjKIUAGxmkDpIW(P_0, P_1, P_2))
				{
					return DVxoTCSowPNEXRfSzjheRApGudfF[i];
				}
			}
			return null;
		}
	}
}
