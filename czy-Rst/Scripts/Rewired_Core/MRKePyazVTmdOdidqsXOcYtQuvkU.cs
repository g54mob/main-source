using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class MRKePyazVTmdOdidqsXOcYtQuvkU
{
	private class NZOBvqGnXYkGwJXhAvfgSfpnVQbU
	{
		private ButtonStateFlags CXvRwlDADJdNvHKlVDQAMDxoGavFb;

		private ButtonStateFlags NKMEuVHfJiZpbEYnpwJThpcPYmNjA;

		private ButtonStateFlags BUcCatHeMdFZOFsdcRXDUHjGvlpSb;

		private ButtonStateFlags XQCIXvQqQsbIUnIhfFWiiqpmsvDq;

		private uint ryVuoqLZQGhGfjiDIrTkAsxYRPqN;

		private bool saSJCReAYaDokELfORIaodPyDgGB;

		private bool PLKoLvcHCGwIvvSIPPeGSdewIZKt;

		private bool WnRNEGVkhKsNAlRTEeOKFpFgbePEb;

		private ahIrTDYEUXggKjTPrKKChNowHIRpA jZYeXJhnnBbodxehEwmPlmjkuaHWA;

		public bool ttjSihaGbVjzSfnCdGzDSduyiprV => saSJCReAYaDokELfORIaodPyDgGB;

		public bool wdGeaYjNpZccFRJrapvuDIHIwViyA
		{
			get
			{
				return PLKoLvcHCGwIvvSIPPeGSdewIZKt;
			}
			set
			{
				PLKoLvcHCGwIvvSIPPeGSdewIZKt = pLKoLvcHCGwIvvSIPPeGSdewIZKt;
			}
		}

		public ButtonStateFlags RdGUVQJARDFRneytJcjtGanadCIBb(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (CXvRwlDADJdNvHKlVDQAMDxoGavFb & ButtonStateFlags.On) != 0;
				flag2 = (NKMEuVHfJiZpbEYnpwJThpcPYmNjA & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!PLKoLvcHCGwIvvSIPPeGSdewIZKt) ? CXvRwlDADJdNvHKlVDQAMDxoGavFb : ButtonStateFlags.Off);
			}
			else
			{
				flag = (BUcCatHeMdFZOFsdcRXDUHjGvlpSb & ButtonStateFlags.On) != 0;
				flag2 = (XQCIXvQqQsbIUnIhfFWiiqpmsvDq & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!PLKoLvcHCGwIvvSIPPeGSdewIZKt) ? BUcCatHeMdFZOFsdcRXDUHjGvlpSb : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (PLKoLvcHCGwIvvSIPPeGSdewIZKt)
				{
					if (flag2 && !WnRNEGVkhKsNAlRTEeOKFpFgbePEb && jZYeXJhnnBbodxehEwmPlmjkuaHWA.OIZqgzicTEvcFKKYKXJAtfIQnYye)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (WnRNEGVkhKsNAlRTEeOKFpFgbePEb && jZYeXJhnnBbodxehEwmPlmjkuaHWA.OIZqgzicTEvcFKKYKXJAtfIQnYye)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !PLKoLvcHCGwIvvSIPPeGSdewIZKt && !WnRNEGVkhKsNAlRTEeOKFpFgbePEb)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void IoSwfRCPAzDMiYHulzQmrcOKWXrs()
		{
			NKMEuVHfJiZpbEYnpwJThpcPYmNjA = CXvRwlDADJdNvHKlVDQAMDxoGavFb;
			XQCIXvQqQsbIUnIhfFWiiqpmsvDq = BUcCatHeMdFZOFsdcRXDUHjGvlpSb;
			WnRNEGVkhKsNAlRTEeOKFpFgbePEb = PLKoLvcHCGwIvvSIPPeGSdewIZKt;
			CXvRwlDADJdNvHKlVDQAMDxoGavFb = ButtonStateFlags.Off;
			BUcCatHeMdFZOFsdcRXDUHjGvlpSb = ButtonStateFlags.Off;
		}

		public void YiPJgwVhZReCURrBBBAFksXlNNuX(uint P_0)
		{
			if (ryVuoqLZQGhGfjiDIrTkAsxYRPqN < P_0 - 1)
			{
				saSJCReAYaDokELfORIaodPyDgGB = false;
			}
		}

		public void kVNpJKTwiGzipiJZntKIretJZfKe(bool P_0)
		{
			pivhlNNKOxLgavbXzcMUBnXgmyDzA((P_0 ? CXvRwlDADJdNvHKlVDQAMDxoGavFb : BUcCatHeMdFZOFsdcRXDUHjGvlpSb) | ButtonStateFlags.On, P_0);
		}

		public void pivhlNNKOxLgavbXzcMUBnXgmyDzA(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				CXvRwlDADJdNvHKlVDQAMDxoGavFb = P_0;
			}
			else
			{
				BUcCatHeMdFZOFsdcRXDUHjGvlpSb = P_0;
			}
			ryVuoqLZQGhGfjiDIrTkAsxYRPqN = ReInput.currentFrame;
			if (!saSJCReAYaDokELfORIaodPyDgGB)
			{
				saSJCReAYaDokELfORIaodPyDgGB = true;
			}
		}

		public void MaDkQocFojuRpYPdzEbBEQAuhNTib(ref ahIrTDYEUXggKjTPrKKChNowHIRpA P_0)
		{
			jZYeXJhnnBbodxehEwmPlmjkuaHWA = P_0;
			PLKoLvcHCGwIvvSIPPeGSdewIZKt = P_0.BhREzJwdcXaoacEmRgGVEHqIKWQoB;
			WnRNEGVkhKsNAlRTEeOKFpFgbePEb = P_0.BhREzJwdcXaoacEmRgGVEHqIKWQoB;
		}

		public void GIzoxeZOMGirEnECKSvQHosaCVDK()
		{
			CXvRwlDADJdNvHKlVDQAMDxoGavFb = ButtonStateFlags.Off;
			NKMEuVHfJiZpbEYnpwJThpcPYmNjA = ButtonStateFlags.Off;
			BUcCatHeMdFZOFsdcRXDUHjGvlpSb = ButtonStateFlags.Off;
			XQCIXvQqQsbIUnIhfFWiiqpmsvDq = ButtonStateFlags.Off;
			ryVuoqLZQGhGfjiDIrTkAsxYRPqN = 0u;
			saSJCReAYaDokELfORIaodPyDgGB = false;
			PLKoLvcHCGwIvvSIPPeGSdewIZKt = false;
			WnRNEGVkhKsNAlRTEeOKFpFgbePEb = false;
		}
	}

	public struct ahIrTDYEUXggKjTPrKKChNowHIRpA
	{
		public bool OIZqgzicTEvcFKKYKXJAtfIQnYye;

		public bool BhREzJwdcXaoacEmRgGVEHqIKWQoB;

		public static ahIrTDYEUXggKjTPrKKChNowHIRpA jJsDddAKQUlNTGmdcqIYHLFFbcbrE => default(ahIrTDYEUXggKjTPrKKChNowHIRpA);
	}

	[Serializable]
	private sealed class KiSiZQUajHxFoimCOeUWkuMuDpXEA
	{
		public static readonly KiSiZQUajHxFoimCOeUWkuMuDpXEA _003C_003E9 = new KiSiZQUajHxFoimCOeUWkuMuDpXEA();

		public static Func<NZOBvqGnXYkGwJXhAvfgSfpnVQbU> _003C_003E9__22_0;

		internal MRKePyazVTmdOdidqsXOcYtQuvkU SwCGJJVgbTEMAdRDfHIYEKAPMEVA()
		{
			return new MRKePyazVTmdOdidqsXOcYtQuvkU();
		}

		internal void oiXWEuiCbIfhlGnFPqrDTnJEzfENA(MRKePyazVTmdOdidqsXOcYtQuvkU P_0)
		{
			P_0.LwdLuZTikNTVunqpOgVxBZpssogoA();
		}

		internal NZOBvqGnXYkGwJXhAvfgSfpnVQbU tlABOVlYYXqwIQozgGPWbpTbMbvq()
		{
			return new NZOBvqGnXYkGwJXhAvfgSfpnVQbU();
		}
	}

	private const int bHGFTXgWfaqMrQlEJZJdwwDklRAeA = 20;

	private const int SyhqfZxieKgTXeEoZqPdNbAPowPyA = 10;

	private static ObjectPool<MRKePyazVTmdOdidqsXOcYtQuvkU> fsJkbUrEJbhagheopRHhjsOTdnOrA;

	private static MRKePyazVTmdOdidqsXOcYtQuvkU[] zzjXhQiUqDdsSgmWWAQTLXIHcazd;

	private static int unHtKcljvKaFyJSxdyOWNmJEYduJ;

	public int OCEIuDQSEXXklBRiDQoaRePVhtWjA;

	private UpdateLoopDataSet<NZOBvqGnXYkGwJXhAvfgSfpnVQbU> baohdGyOXAjOSNBvFoSYUqObHtUd;

	public bool xFoOPLSQWOrhVAQSwePfilVLalmkA
	{
		get
		{
			int count = baohdGyOXAjOSNBvFoSYUqObHtUd.Count;
			for (int i = 0; i < count; i++)
			{
				if (baohdGyOXAjOSNBvFoSYUqObHtUd[i].ttjSihaGbVjzSfnCdGzDSduyiprV)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool qkDqfzMotoQQxMWSTvBPUhlqYFog
	{
		get
		{
			return baohdGyOXAjOSNBvFoSYUqObHtUd.Current.wdGeaYjNpZccFRJrapvuDIHIwViyA;
		}
		set
		{
			baohdGyOXAjOSNBvFoSYUqObHtUd.Current.wdGeaYjNpZccFRJrapvuDIHIwViyA = flag;
		}
	}

	static MRKePyazVTmdOdidqsXOcYtQuvkU()
	{
		fsJkbUrEJbhagheopRHhjsOTdnOrA = new ObjectPool<MRKePyazVTmdOdidqsXOcYtQuvkU>(20, KiSiZQUajHxFoimCOeUWkuMuDpXEA._003C_003E9.SwCGJJVgbTEMAdRDfHIYEKAPMEVA, KiSiZQUajHxFoimCOeUWkuMuDpXEA._003C_003E9.oiXWEuiCbIfhlGnFPqrDTnJEzfENA);
		zzjXhQiUqDdsSgmWWAQTLXIHcazd = new MRKePyazVTmdOdidqsXOcYtQuvkU[20];
	}

	public static void KYpyiLRWepHOREXafEuLrfDJpMTP()
	{
		unHtKcljvKaFyJSxdyOWNmJEYduJ = 0;
		Array.Clear(zzjXhQiUqDdsSgmWWAQTLXIHcazd, 0, zzjXhQiUqDdsSgmWWAQTLXIHcazd.Length);
		fsJkbUrEJbhagheopRHhjsOTdnOrA.Clear();
	}

	public static MRKePyazVTmdOdidqsXOcYtQuvkU rEJwcpqicCoKnzCoggngDWTlfAIh(int P_0)
	{
		for (int i = 0; i < unHtKcljvKaFyJSxdyOWNmJEYduJ; i++)
		{
			if (zzjXhQiUqDdsSgmWWAQTLXIHcazd[i] != null && zzjXhQiUqDdsSgmWWAQTLXIHcazd[i].OCEIuDQSEXXklBRiDQoaRePVhtWjA == P_0)
			{
				return zzjXhQiUqDdsSgmWWAQTLXIHcazd[i];
			}
		}
		return null;
	}

	public static MRKePyazVTmdOdidqsXOcYtQuvkU BXNqqItjXjrVOXjvxORMcShpsPbT(int P_0, ahIrTDYEUXggKjTPrKKChNowHIRpA P_1)
	{
		MRKePyazVTmdOdidqsXOcYtQuvkU mRKePyazVTmdOdidqsXOcYtQuvkU = rEJwcpqicCoKnzCoggngDWTlfAIh(P_0);
		if (mRKePyazVTmdOdidqsXOcYtQuvkU != null)
		{
			return mRKePyazVTmdOdidqsXOcYtQuvkU;
		}
		mRKePyazVTmdOdidqsXOcYtQuvkU = fsJkbUrEJbhagheopRHhjsOTdnOrA.Get();
		mRKePyazVTmdOdidqsXOcYtQuvkU.TjfaJGjeQLkOihDMWBgqLucKwrxkA(P_0);
		mRKePyazVTmdOdidqsXOcYtQuvkU.tvbnjOwPSDkFanEPlWywlRDJSFGw(ref P_1);
		mRKePyazVTmdOdidqsXOcYtQuvkU.baohdGyOXAjOSNBvFoSYUqObHtUd.SetUpdateLoop(ReInput.currentUpdateLoop);
		wRCsLXnbcsqJllLSXiHRuBsCmSVN(mRKePyazVTmdOdidqsXOcYtQuvkU);
		return mRKePyazVTmdOdidqsXOcYtQuvkU;
	}

	public static void PxwxeMOoxWJDvemdJPqrEHomaNQCA(UpdateLoopType P_0)
	{
		for (int i = 0; i < unHtKcljvKaFyJSxdyOWNmJEYduJ; i++)
		{
			if (zzjXhQiUqDdsSgmWWAQTLXIHcazd[i] != null)
			{
				zzjXhQiUqDdsSgmWWAQTLXIHcazd[i].CsSNoZdTAChTyIBZDHzBkdbJAUYN(P_0);
			}
		}
	}

	public static void ByFcaqttpHJyDMxOSwpqpBrfthDT(UpdateLoopType P_0, uint P_1)
	{
		for (int num = unHtKcljvKaFyJSxdyOWNmJEYduJ - 1; num >= 0; num--)
		{
			if (zzjXhQiUqDdsSgmWWAQTLXIHcazd[num] == null)
			{
				if (num == unHtKcljvKaFyJSxdyOWNmJEYduJ - 1)
				{
					unHtKcljvKaFyJSxdyOWNmJEYduJ--;
				}
			}
			else
			{
				zzjXhQiUqDdsSgmWWAQTLXIHcazd[num].wDNGFTgWkSiYmCxbwsrYkrmhwAyZ(P_1);
				if (!zzjXhQiUqDdsSgmWWAQTLXIHcazd[num].xFoOPLSQWOrhVAQSwePfilVLalmkA)
				{
					rzouPmZTeHhRlmELUzkYQoCCEHKR(num);
				}
			}
		}
	}

	private static void wRCsLXnbcsqJllLSXiHRuBsCmSVN(MRKePyazVTmdOdidqsXOcYtQuvkU P_0)
	{
		int num = ZKKTCxMhoHYFdkjsyDkdIZIlXQYh();
		if (num < 0)
		{
			if (unHtKcljvKaFyJSxdyOWNmJEYduJ == zzjXhQiUqDdsSgmWWAQTLXIHcazd.Length)
			{
				MRKePyazVTmdOdidqsXOcYtQuvkU[] array = zzjXhQiUqDdsSgmWWAQTLXIHcazd;
				zzjXhQiUqDdsSgmWWAQTLXIHcazd = new MRKePyazVTmdOdidqsXOcYtQuvkU[zzjXhQiUqDdsSgmWWAQTLXIHcazd.Length + 10];
				Array.Copy(array, zzjXhQiUqDdsSgmWWAQTLXIHcazd, array.Length);
			}
			num = unHtKcljvKaFyJSxdyOWNmJEYduJ;
			unHtKcljvKaFyJSxdyOWNmJEYduJ++;
		}
		zzjXhQiUqDdsSgmWWAQTLXIHcazd[num] = P_0;
	}

	private static void rzouPmZTeHhRlmELUzkYQoCCEHKR(int P_0)
	{
		if (P_0 >= 0 && P_0 < unHtKcljvKaFyJSxdyOWNmJEYduJ)
		{
			MRKePyazVTmdOdidqsXOcYtQuvkU mRKePyazVTmdOdidqsXOcYtQuvkU = zzjXhQiUqDdsSgmWWAQTLXIHcazd[P_0];
			if (mRKePyazVTmdOdidqsXOcYtQuvkU != null)
			{
				fsJkbUrEJbhagheopRHhjsOTdnOrA.Return(mRKePyazVTmdOdidqsXOcYtQuvkU);
				zzjXhQiUqDdsSgmWWAQTLXIHcazd[P_0] = null;
			}
			if (P_0 == unHtKcljvKaFyJSxdyOWNmJEYduJ - 1)
			{
				unHtKcljvKaFyJSxdyOWNmJEYduJ--;
			}
		}
	}

	private static int ZKKTCxMhoHYFdkjsyDkdIZIlXQYh()
	{
		for (int i = 0; i < unHtKcljvKaFyJSxdyOWNmJEYduJ; i++)
		{
			if (zzjXhQiUqDdsSgmWWAQTLXIHcazd[i] == null)
			{
				return i;
			}
		}
		if (unHtKcljvKaFyJSxdyOWNmJEYduJ >= zzjXhQiUqDdsSgmWWAQTLXIHcazd.Length)
		{
			return -1;
		}
		int result = unHtKcljvKaFyJSxdyOWNmJEYduJ;
		unHtKcljvKaFyJSxdyOWNmJEYduJ++;
		return result;
	}

	public ButtonStateFlags xgmQEHuJPCchuhoFOGpJEbtNqnhN(bool P_0)
	{
		return baohdGyOXAjOSNBvFoSYUqObHtUd.Current.RdGUVQJARDFRneytJcjtGanadCIBb(P_0);
	}

	public MRKePyazVTmdOdidqsXOcYtQuvkU()
	{
		baohdGyOXAjOSNBvFoSYUqObHtUd = new UpdateLoopDataSet<NZOBvqGnXYkGwJXhAvfgSfpnVQbU>(ReInput.UserData.ConfigVars.updateLoop, KiSiZQUajHxFoimCOeUWkuMuDpXEA._003C_003E9.tlABOVlYYXqwIQozgGPWbpTbMbvq);
		LwdLuZTikNTVunqpOgVxBZpssogoA();
	}

	public void CsSNoZdTAChTyIBZDHzBkdbJAUYN(UpdateLoopType P_0)
	{
		baohdGyOXAjOSNBvFoSYUqObHtUd.SetUpdateLoop(P_0);
		baohdGyOXAjOSNBvFoSYUqObHtUd.Current.IoSwfRCPAzDMiYHulzQmrcOKWXrs();
	}

	public void wDNGFTgWkSiYmCxbwsrYkrmhwAyZ(uint P_0)
	{
		baohdGyOXAjOSNBvFoSYUqObHtUd.Current.YiPJgwVhZReCURrBBBAFksXlNNuX(P_0);
	}

	public void CSQEhgGDIXdTDxbJaWIpgQOyCkyZA(UpdateLoopType P_0, bool P_1)
	{
		baohdGyOXAjOSNBvFoSYUqObHtUd.Current.kVNpJKTwiGzipiJZntKIretJZfKe(P_1);
	}

	public void RMPXLiVPcQjhyBDbrdgxOIdDvzIQ(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		baohdGyOXAjOSNBvFoSYUqObHtUd.Current.pivhlNNKOxLgavbXzcMUBnXgmyDzA(P_1, P_2);
	}

	private void tvbnjOwPSDkFanEPlWywlRDJSFGw(ref ahIrTDYEUXggKjTPrKKChNowHIRpA P_0)
	{
		int count = baohdGyOXAjOSNBvFoSYUqObHtUd.Count;
		for (int i = 0; i < count; i++)
		{
			baohdGyOXAjOSNBvFoSYUqObHtUd[i].MaDkQocFojuRpYPdzEbBEQAuhNTib(ref P_0);
		}
	}

	private void TjfaJGjeQLkOihDMWBgqLucKwrxkA(int P_0)
	{
		OCEIuDQSEXXklBRiDQoaRePVhtWjA = P_0;
	}

	private void LwdLuZTikNTVunqpOgVxBZpssogoA()
	{
		OCEIuDQSEXXklBRiDQoaRePVhtWjA = -1;
		int count = baohdGyOXAjOSNBvFoSYUqObHtUd.Count;
		for (int i = 0; i < count; i++)
		{
			baohdGyOXAjOSNBvFoSYUqObHtUd[i].GIzoxeZOMGirEnECKSvQHosaCVDK();
		}
	}
}
