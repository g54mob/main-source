using System;
using Rewired;

internal static class AxZHxbJVUZerMtgvYFHiGyXYrJKaA
{
	public enum YUhBmlMOJBnmzLEulqNkmuyrbsqO
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private struct qrPjuCEKVMBVHJfpvJFihKyvXCMV
	{
		public enum sHwObaMzFGyFKszLKmWjdMfJtxfg
		{
			MatchAnyOption = 0,
			MatchAllOptions = 1,
			IgnoreOptions = 2
		}

		public PidVid hTFKfWRTmqSqPvqlVFiVLjvIgonJ;

		public culpeKqqpLYmRhkwltWEHngnmyvF pwcBnWHYAfsEQJCXfgCtGngAESFFb;

		public sHwObaMzFGyFKszLKmWjdMfJtxfg HvcqQQPebgnlPtZteMAvzJiGaKzJ;

		public qrPjuCEKVMBVHJfpvJFihKyvXCMV(PidVid P_0, culpeKqqpLYmRhkwltWEHngnmyvF P_1, sHwObaMzFGyFKszLKmWjdMfJtxfg P_2)
		{
			hTFKfWRTmqSqPvqlVFiVLjvIgonJ = P_0;
			pwcBnWHYAfsEQJCXfgCtGngAESFFb = P_1;
			HvcqQQPebgnlPtZteMAvzJiGaKzJ = P_2;
		}

		public bool ZkNbFDeSYNNbGsbXmmcYFEeCVlbkc(ushort P_0, ushort P_1, culpeKqqpLYmRhkwltWEHngnmyvF P_2)
		{
			if (hTFKfWRTmqSqPvqlVFiVLjvIgonJ.vendorId != P_0)
			{
				return false;
			}
			if (hTFKfWRTmqSqPvqlVFiVLjvIgonJ.productId != P_1)
			{
				return false;
			}
			return HvcqQQPebgnlPtZteMAvzJiGaKzJ switch
			{
				sHwObaMzFGyFKszLKmWjdMfJtxfg.MatchAnyOption => (pwcBnWHYAfsEQJCXfgCtGngAESFFb & P_2) != 0, 
				sHwObaMzFGyFKszLKmWjdMfJtxfg.MatchAllOptions => pwcBnWHYAfsEQJCXfgCtGngAESFFb == P_2, 
				sHwObaMzFGyFKszLKmWjdMfJtxfg.IgnoreOptions => true, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public enum culpeKqqpLYmRhkwltWEHngnmyvF
	{
		None = 0,
		Bluetooth = 1,
		USB = 2
	}

	private static Guid[] CmTCTTMLkClfyXsXDBDTcimnjoOz = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] xKLYndSsUXLTylqWfDqTIwVzYHklA = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string DMHhdpKNeVUUELkukARnxLVJlhAR = ".*xbox[ \\-]one.*";

	private static readonly qrPjuCEKVMBVHJfpvJFihKyvXCMV[] wmiTtQYzQDgioBndSIgPcmMTEbzZA = new qrPjuCEKVMBVHJfpvJFihKyvXCMV[1]
	{
		new qrPjuCEKVMBVHJfpvJFihKyvXCMV(new PidVid(8201, 1406), culpeKqqpLYmRhkwltWEHngnmyvF.USB, qrPjuCEKVMBVHJfpvJFihKyvXCMV.sHwObaMzFGyFKszLKmWjdMfJtxfg.MatchAnyOption)
	};

	public static string bbdvctbPDfmGBUBAvijpEmyhgfDtA(zMnTBxgjEBHfEVnTbRhfyPtfXlAV P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return uPNFVQHUqODWoDMisCMvAysBBGQFA(P_0.BQYGLqbyloBbMZABxqFBMgpnoTUx, P_1, P_2, P_3) switch
		{
			YUhBmlMOJBnmzLEulqNkmuyrbsqO.CombinedTriggers => "[CombinedTriggers]", 
			YUhBmlMOJBnmzLEulqNkmuyrbsqO.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static YUhBmlMOJBnmzLEulqNkmuyrbsqO uPNFVQHUqODWoDMisCMvAysBBGQFA(oYrOjnJoWpYbXeOQrleqFxKDJJqB[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!LdrKvYKnLeuXQMPFUYrBLqOftMEE(P_1, P_2, P_3))
		{
			return YUhBmlMOJBnmzLEulqNkmuyrbsqO.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].BpBnYzShRKSeVfUdxWNVFaGgohbh == 1 && !P_0[i].QBjYrkfxjiIQomNvzuJnRKYErEiu && P_0[i].OqwzwnfMvLjaWGgUUAiYDKTwhCcIb.WZEdBZHyvobknDLaxhcDixpNCShgb == 53)
			{
				return YUhBmlMOJBnmzLEulqNkmuyrbsqO.SplitTriggers;
			}
		}
		return YUhBmlMOJBnmzLEulqNkmuyrbsqO.CombinedTriggers;
	}

	public static bool LdrKvYKnLeuXQMPFUYrBLqOftMEE(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(CmTCTTMLkClfyXsXDBDTcimnjoOz, P_0) >= 0)
		{
			return true;
		}
		if (bZCJDmHxMRinDhBadJpAZTVgDmYA(P_1))
		{
			return true;
		}
		if (bZCJDmHxMRinDhBadJpAZTVgDmYA(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool bZCJDmHxMRinDhBadJpAZTVgDmYA(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < xKLYndSsUXLTylqWfDqTIwVzYHklA.Length; i++)
		{
			if (xKLYndSsUXLTylqWfDqTIwVzYHklA[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool yxbiPyBCfaTRLBROrAkPLxJMyGKJ(InputSource P_0, ushort P_1, ushort P_2, culpeKqqpLYmRhkwltWEHngnmyvF P_3)
	{
		if (P_0 == InputSource.DirectInput || P_0 == InputSource.RawInput)
		{
			for (int i = 0; i < wmiTtQYzQDgioBndSIgPcmMTEbzZA.Length; i++)
			{
				if (wmiTtQYzQDgioBndSIgPcmMTEbzZA[i].ZkNbFDeSYNNbGsbXmmcYFEeCVlbkc(P_1, P_2, P_3))
				{
					return true;
				}
			}
		}
		return false;
	}
}
