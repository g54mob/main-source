using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

internal abstract class kbKSDIvuMQdJtiYApSbKaAFKfgWJA : QAOlVgyStIKpRmoWAGbpIzIYHZwjA
{
	internal abstract class dAQmXhGphruPEKaQJAKzcuDaTHWH
	{
		private int uqKIrPwQVWeRuEJCuOGdjliqwqRl;

		private int[] PpRzLjiSVjfBkadgWSIZpoSzcLRX;

		protected BIUOnbtijWevVHVJqjwlzzrpSgSdA[] PakJHFHhqUNsnlMUilMsvasgKvuJ;

		public BIUOnbtijWevVHVJqjwlzzrpSgSdA PhJajzYQjRlnbdFWgdJjwyplducY;

		private int altkzQvoxHItwsngLOEeKNwskYZi;

		private int LXIzOClWHdkSCPOaeDXDJPdrqfwy = -1;

		private bool PRuHVNSYgvyimtPMtdlvkZLlrmjH;

		protected int CajStOZNjNLtmcotdEUpBVyyJzrM => uqKIrPwQVWeRuEJCuOGdjliqwqRl;

		protected int[] MTgtyFUsVwoflWEIhPcYuvFZUgio => PpRzLjiSVjfBkadgWSIZpoSzcLRX;

		public UpdateLoopType AMCPQuelaCTaiwSoIcWQJBYpQhpt
		{
			set
			{
				if (LXIzOClWHdkSCPOaeDXDJPdrqfwy != (int)updateLoopType)
				{
					LXIzOClWHdkSCPOaeDXDJPdrqfwy = (int)updateLoopType;
					altkzQvoxHItwsngLOEeKNwskYZi = PpRzLjiSVjfBkadgWSIZpoSzcLRX[(int)updateLoopType];
					PhJajzYQjRlnbdFWgdJjwyplducY = PakJHFHhqUNsnlMUilMsvasgKvuJ[altkzQvoxHItwsngLOEeKNwskYZi];
				}
			}
		}

		public dAQmXhGphruPEKaQJAKzcuDaTHWH()
		{
		}

		public void UreSkxRMtwEvPNjPdvkMaYZDErrs(UpdateLoopSetting P_0, Func<UpdateLoopType, BIUOnbtijWevVHVJqjwlzzrpSgSdA> P_1)
		{
			if (PRuHVNSYgvyimtPMtdlvkZLlrmjH)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			PpRzLjiSVjfBkadgWSIZpoSzcLRX = new int[3];
			uqKIrPwQVWeRuEJCuOGdjliqwqRl = 0;
			List<BIUOnbtijWevVHVJqjwlzzrpSgSdA> list = new List<BIUOnbtijWevVHVJqjwlzzrpSgSdA>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					PpRzLjiSVjfBkadgWSIZpoSzcLRX[(int)list2[i]] = uqKIrPwQVWeRuEJCuOGdjliqwqRl;
					uqKIrPwQVWeRuEJCuOGdjliqwqRl++;
					list.Add(P_1(list2[i]));
				}
			}
			PakJHFHhqUNsnlMUilMsvasgKvuJ = list.ToArray();
			PhJajzYQjRlnbdFWgdJjwyplducY = PakJHFHhqUNsnlMUilMsvasgKvuJ[0];
			PRuHVNSYgvyimtPMtdlvkZLlrmjH = true;
		}

		private void BdtvTlzirUCEKaURRvwSPMYowFXWA(UpdateLoopType P_0, BIUOnbtijWevVHVJqjwlzzrpSgSdA P_1)
		{
			PakJHFHhqUNsnlMUilMsvasgKvuJ[PpRzLjiSVjfBkadgWSIZpoSzcLRX[(int)P_0]] = P_1;
		}

		public virtual void RmlNIIYUllWUfZtfmWPwZidldnJJ(UpdateLoopType P_0)
		{
			if (LXIzOClWHdkSCPOaeDXDJPdrqfwy != (int)P_0)
			{
				AMCPQuelaCTaiwSoIcWQJBYpQhpt = P_0;
			}
		}

		public void fhjCfqvUTMrkYbMxzGQMeXtnUdXL()
		{
			for (int i = 0; i < uqKIrPwQVWeRuEJCuOGdjliqwqRl; i++)
			{
				PakJHFHhqUNsnlMUilMsvasgKvuJ[i].dHeCrlIpjtkRpHmMFLCJEHpJRIDmA();
			}
		}
	}

	internal abstract class BIUOnbtijWevVHVJqjwlzzrpSgSdA
	{
		public readonly UpdateLoopType jmQRSfbknLBbPBMHOvImdDeyioWs;

		public BIUOnbtijWevVHVJqjwlzzrpSgSdA(UpdateLoopType P_0)
		{
			jmQRSfbknLBbPBMHOvImdDeyioWs = P_0;
		}

		public abstract void dHeCrlIpjtkRpHmMFLCJEHpJRIDmA();
	}

	internal dAQmXhGphruPEKaQJAKzcuDaTHWH tTYtBEpDoxXoEnilidxSDCnYOlNGb;

	public kbKSDIvuMQdJtiYApSbKaAFKfgWJA(dAQmXhGphruPEKaQJAKzcuDaTHWH P_0, byte P_1, HIDInfo P_2)
		: base(P_1, P_2)
	{
		tTYtBEpDoxXoEnilidxSDCnYOlNGb = P_0;
	}

	public virtual void MZFwzvrZKCinFmXFNNjNGHEdiRxcA(UpdateLoopType P_0)
	{
		if (tTYtBEpDoxXoEnilidxSDCnYOlNGb != null)
		{
			tTYtBEpDoxXoEnilidxSDCnYOlNGb.RmlNIIYUllWUfZtfmWPwZidldnJJ(P_0);
		}
	}
}
