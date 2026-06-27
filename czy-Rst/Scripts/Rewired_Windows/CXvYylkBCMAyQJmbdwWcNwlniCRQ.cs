using System;
using Rewired;

internal static class CXvYylkBCMAyQJmbdwWcNwlniCRQ
{
	public enum CvLxbpbaPKjlvhsuIEkwBQCMfsdg
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct mdnXnUnpBXiUFpqrOwCoUKOCaLRS
	{
		public enum ylYTigzXcZhzSUFCzzlhAFDocWcC
		{
			MatchAnyOption = 0,
			MatchAllOptions = 1,
			IgnoreOptions = 2
		}

		public PidVid zxgPEiykDxTFyJvckMVkkVdhzgxb;

		public eNsmKaDtaGBZkXaGAaBKiAgCvWiC lwGabAwcGyHIWzcXUhJnOhSnRRSw;

		public ylYTigzXcZhzSUFCzzlhAFDocWcC TxOAtGcVbzpmXZSlPoTjMnIpfbuU;

		public mdnXnUnpBXiUFpqrOwCoUKOCaLRS(PidVid P_0, eNsmKaDtaGBZkXaGAaBKiAgCvWiC P_1, ylYTigzXcZhzSUFCzzlhAFDocWcC P_2)
		{
			zxgPEiykDxTFyJvckMVkkVdhzgxb = P_0;
			lwGabAwcGyHIWzcXUhJnOhSnRRSw = P_1;
			TxOAtGcVbzpmXZSlPoTjMnIpfbuU = P_2;
		}

		public bool VinpIFxcKQnmMBqHZgxQfeOkviep(ushort P_0, ushort P_1, eNsmKaDtaGBZkXaGAaBKiAgCvWiC P_2)
		{
			if (zxgPEiykDxTFyJvckMVkkVdhzgxb.vendorId != P_0)
			{
				return false;
			}
			if (zxgPEiykDxTFyJvckMVkkVdhzgxb.productId != P_1)
			{
				return false;
			}
			return TxOAtGcVbzpmXZSlPoTjMnIpfbuU switch
			{
				ylYTigzXcZhzSUFCzzlhAFDocWcC.MatchAnyOption => (lwGabAwcGyHIWzcXUhJnOhSnRRSw & P_2) != 0, 
				ylYTigzXcZhzSUFCzzlhAFDocWcC.MatchAllOptions => lwGabAwcGyHIWzcXUhJnOhSnRRSw == P_2, 
				ylYTigzXcZhzSUFCzzlhAFDocWcC.IgnoreOptions => true, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public enum eNsmKaDtaGBZkXaGAaBKiAgCvWiC
	{
		None = 0,
		Bluetooth = 1,
		USB = 2
	}

	private static Guid[] WgvYsTlGkVsaqveTgBEZDIWAezTk = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] dOtKkxlUWURScHOCQTvVBojIKrvK = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string PEbSeddxaMfHMpYyHAQnOxladsRP = ".*xbox[ \\-]one.*";

	private static readonly mdnXnUnpBXiUFpqrOwCoUKOCaLRS[] uJOiaMlqIIprmzRjzwzFZkwgPuqP = new mdnXnUnpBXiUFpqrOwCoUKOCaLRS[1]
	{
		new mdnXnUnpBXiUFpqrOwCoUKOCaLRS(new PidVid(8201, 1406), eNsmKaDtaGBZkXaGAaBKiAgCvWiC.USB, mdnXnUnpBXiUFpqrOwCoUKOCaLRS.ylYTigzXcZhzSUFCzzlhAFDocWcC.MatchAnyOption)
	};

	public static string nvNEfzMvLwfTFwCEQimjdXWCnqWqA(tjTiYbJtYWuQKvHRGfylBqLWdsLt P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return mIdqYKeIcRHRsdfiJeRvZLYqVRPq(P_0.JBmZIaKppjUmWjeFSqUXxnXMmEZy, P_1, P_2, P_3) switch
		{
			CvLxbpbaPKjlvhsuIEkwBQCMfsdg.CombinedTriggers => "[CombinedTriggers]", 
			CvLxbpbaPKjlvhsuIEkwBQCMfsdg.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static CvLxbpbaPKjlvhsuIEkwBQCMfsdg mIdqYKeIcRHRsdfiJeRvZLYqVRPq(gPZNdfgGeebNrSGSYAicgVRmbKWIA[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!BKXHCCvnrdhQWaTPvXHliSRSyBDc(P_1, P_2, P_3))
		{
			return CvLxbpbaPKjlvhsuIEkwBQCMfsdg.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].ZyjcgbhBzJfBRbVWYSJJwiURJrsYA == 1 && !P_0[i].MXRKyiECfzrJmGOxSGCzgcilRPjeA && P_0[i].OjMJfnIepYenYGuIdylAOrfLiLtGb.AqcKEPykppxMxdwkEzHLIeNshRwy == 53)
			{
				return CvLxbpbaPKjlvhsuIEkwBQCMfsdg.SplitTriggers;
			}
		}
		return CvLxbpbaPKjlvhsuIEkwBQCMfsdg.CombinedTriggers;
	}

	public static bool BKXHCCvnrdhQWaTPvXHliSRSyBDc(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(WgvYsTlGkVsaqveTgBEZDIWAezTk, P_0) >= 0)
		{
			return true;
		}
		if (hXdKbRmSjBxHxZpLPIypildqIgjJ(P_1))
		{
			return true;
		}
		if (hXdKbRmSjBxHxZpLPIypildqIgjJ(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool hXdKbRmSjBxHxZpLPIypildqIgjJ(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < dOtKkxlUWURScHOCQTvVBojIKrvK.Length; i++)
		{
			if (dOtKkxlUWURScHOCQTvVBojIKrvK[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool aqVtrsmgfbIWDfuGSqJTgQjhAbXU(InputSource P_0, ushort P_1, ushort P_2, eNsmKaDtaGBZkXaGAaBKiAgCvWiC P_3)
	{
		if (P_0 == InputSource.DirectInput || P_0 == InputSource.RawInput)
		{
			for (int i = 0; i < uJOiaMlqIIprmzRjzwzFZkwgPuqP.Length; i++)
			{
				if (uJOiaMlqIIprmzRjzwzFZkwgPuqP[i].VinpIFxcKQnmMBqHZgxQfeOkviep(P_1, P_2, P_3))
				{
					return true;
				}
			}
		}
		return false;
	}
}
