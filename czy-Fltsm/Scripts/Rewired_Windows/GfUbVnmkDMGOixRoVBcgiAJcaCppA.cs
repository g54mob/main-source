using System;
using Rewired;
using Rewired.Utils;

internal static class GfUbVnmkDMGOixRoVBcgiAJcaCppA
{
	public enum AlaKIvpTWEPWFZIrsgtoAAkVJzRK
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct JjbAkqAWrlntFadfFNamERcbFFuc
	{
		public enum VbueeDBxLgOcOhHzIxZYuphLUITpA
		{
			Deny = 0,
			Allow = 1
		}

		public enum RhaoMiciqcxTxREPkEywFIghtjBtA
		{
			MatchAnyProperty = 0,
			MatchAllProperties = 1,
			IgnoreProperties = 2
		}

		public VbueeDBxLgOcOhHzIxZYuphLUITpA kKwHOEtTVbqErZITmzuJjUSbOzQv;

		public InputSource[] LYWnfXiBsfSYnImFddnVuqWquXvk;

		public PidVid TOvGKTglYDlGfTCPGjFafujeUowVB;

		public LBfSIsVrDyriFGkGTaDGvFkBERnR NgxrJmuVFmKxbmxFtVSZCEVfckht;

		public RhaoMiciqcxTxREPkEywFIghtjBtA MRDCslheVXOleqgVPZKhqXErROFmA;

		public JjbAkqAWrlntFadfFNamERcbFFuc(VbueeDBxLgOcOhHzIxZYuphLUITpA P_0, InputSource[] P_1, PidVid P_2, LBfSIsVrDyriFGkGTaDGvFkBERnR P_3, RhaoMiciqcxTxREPkEywFIghtjBtA P_4)
		{
			kKwHOEtTVbqErZITmzuJjUSbOzQv = P_0;
			LYWnfXiBsfSYnImFddnVuqWquXvk = P_1;
			TOvGKTglYDlGfTCPGjFafujeUowVB = P_2;
			NgxrJmuVFmKxbmxFtVSZCEVfckht = P_3;
			MRDCslheVXOleqgVPZKhqXErROFmA = P_4;
		}

		public bool yVuGvYVfKxcjXBeXAHBumhJEjdGY(InputSource P_0, ushort P_1, ushort P_2, LBfSIsVrDyriFGkGTaDGvFkBERnR P_3)
		{
			if (LYWnfXiBsfSYnImFddnVuqWquXvk != null && !ArrayTools.Contains(LYWnfXiBsfSYnImFddnVuqWquXvk, P_0))
			{
				return false;
			}
			if (TOvGKTglYDlGfTCPGjFafujeUowVB.vendorId != P_1)
			{
				return false;
			}
			if (TOvGKTglYDlGfTCPGjFafujeUowVB.productId != P_2)
			{
				return false;
			}
			return MRDCslheVXOleqgVPZKhqXErROFmA switch
			{
				RhaoMiciqcxTxREPkEywFIghtjBtA.MatchAnyProperty => (NgxrJmuVFmKxbmxFtVSZCEVfckht & P_3) != 0, 
				RhaoMiciqcxTxREPkEywFIghtjBtA.MatchAllProperties => NgxrJmuVFmKxbmxFtVSZCEVfckht == P_3, 
				RhaoMiciqcxTxREPkEywFIghtjBtA.IgnoreProperties => true, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public enum LBfSIsVrDyriFGkGTaDGvFkBERnR
	{
		None = 0,
		Bluetooth = 1,
		USB = 2,
		UsesCustomDriver = 4
	}

	private static Guid[] SYOjtXdFzJkEWBqYYfoBiOuJLdlqA = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] xwYVavhCNSqrSpJHmDVHSHVBUJDl = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string LcEaPltwtAuvqDEhtDstFNZbOmhmA = ".*xbox[ \\-]one.*";

	private static JjbAkqAWrlntFadfFNamERcbFFuc[] YdGMWFIBxZPTXPPhlkgaTxarJNfG;

	private static JjbAkqAWrlntFadfFNamERcbFFuc[] zSiityrKjgWkfNqDMhyqVenkSwZH
	{
		get
		{
			if (YdGMWFIBxZPTXPPhlkgaTxarJNfG == null)
			{
				InputSource[] array = new InputSource[2]
				{
					InputSource.RawInput,
					InputSource.DirectInput
				};
				YdGMWFIBxZPTXPPhlkgaTxarJNfG = new JjbAkqAWrlntFadfFNamERcbFFuc[2]
				{
					new JjbAkqAWrlntFadfFNamERcbFFuc(JjbAkqAWrlntFadfFNamERcbFFuc.VbueeDBxLgOcOhHzIxZYuphLUITpA.Allow, array, new PidVid(8201, 1406), LBfSIsVrDyriFGkGTaDGvFkBERnR.UsesCustomDriver, JjbAkqAWrlntFadfFNamERcbFFuc.RhaoMiciqcxTxREPkEywFIghtjBtA.MatchAnyProperty),
					new JjbAkqAWrlntFadfFNamERcbFFuc(JjbAkqAWrlntFadfFNamERcbFFuc.VbueeDBxLgOcOhHzIxZYuphLUITpA.Deny, array, new PidVid(8201, 1406), (LBfSIsVrDyriFGkGTaDGvFkBERnR)3, JjbAkqAWrlntFadfFNamERcbFFuc.RhaoMiciqcxTxREPkEywFIghtjBtA.MatchAnyProperty)
				};
			}
			return YdGMWFIBxZPTXPPhlkgaTxarJNfG;
		}
	}

	public static string hjiUIbMcAixefItPwKEhMmwPspqH(rtcpRxBVLKAMkXCloKUnYbCBcUfE P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return kUUzFEaziDnzCNfSlzlfSwHtNlrD(P_0.PBVcluCoclsKeVmKwfoJcyxZSAjiA, P_1, P_2, P_3) switch
		{
			AlaKIvpTWEPWFZIrsgtoAAkVJzRK.CombinedTriggers => "[CombinedTriggers]", 
			AlaKIvpTWEPWFZIrsgtoAAkVJzRK.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static AlaKIvpTWEPWFZIrsgtoAAkVJzRK kUUzFEaziDnzCNfSlzlfSwHtNlrD(aTedyfCyjkFlTNoTgtYcHldvQSsDA[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!RoincGxnqbMVyALKJUjDnFsLYudt(P_1, P_2, P_3))
		{
			return AlaKIvpTWEPWFZIrsgtoAAkVJzRK.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].FDIZNrdBqXNnppMZuPpFtouAcjCQ == 1 && !P_0[i].CFyXnkCgqrpaAsEuucwfxFMclRXW && P_0[i].GUvUHtIjsGXteOADTPFEqGTWHNFw.UPDjrPiperbZRLxjwaHNGRdxYNOsA == 53)
			{
				return AlaKIvpTWEPWFZIrsgtoAAkVJzRK.SplitTriggers;
			}
		}
		return AlaKIvpTWEPWFZIrsgtoAAkVJzRK.CombinedTriggers;
	}

	public static bool RoincGxnqbMVyALKJUjDnFsLYudt(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(SYOjtXdFzJkEWBqYYfoBiOuJLdlqA, P_0) >= 0)
		{
			return true;
		}
		if (tlOZzTodkRjLRbpMzeexBbDapYPyb(P_1))
		{
			return true;
		}
		if (tlOZzTodkRjLRbpMzeexBbDapYPyb(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool tlOZzTodkRjLRbpMzeexBbDapYPyb(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < xwYVavhCNSqrSpJHmDVHSHVBUJDl.Length; i++)
		{
			if (xwYVavhCNSqrSpJHmDVHSHVBUJDl[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool XUhxuDINlXgOEbuiInnaedQMcHnKA(InputSource P_0, ushort P_1, ushort P_2, LBfSIsVrDyriFGkGTaDGvFkBERnR P_3)
	{
		for (int i = 0; i < zSiityrKjgWkfNqDMhyqVenkSwZH.Length; i++)
		{
			if (zSiityrKjgWkfNqDMhyqVenkSwZH[i].yVuGvYVfKxcjXBeXAHBumhJEjdGY(P_0, P_1, P_2, P_3))
			{
				return zSiityrKjgWkfNqDMhyqVenkSwZH[i].kKwHOEtTVbqErZITmzuJjUSbOzQv switch
				{
					JjbAkqAWrlntFadfFNamERcbFFuc.VbueeDBxLgOcOhHzIxZYuphLUITpA.Allow => true, 
					JjbAkqAWrlntFadfFNamERcbFFuc.VbueeDBxLgOcOhHzIxZYuphLUITpA.Deny => false, 
					_ => throw new NotImplementedException(), 
				};
			}
		}
		return true;
	}
}
