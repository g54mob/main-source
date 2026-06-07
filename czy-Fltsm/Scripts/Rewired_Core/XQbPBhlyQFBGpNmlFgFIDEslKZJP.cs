using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class XQbPBhlyQFBGpNmlFgFIDEslKZJP
{
	private class QelmzpNwUGpoVdNlxWAsvKsUGuKP
	{
		private ButtonStateFlags XlUgFuIWGXdIIwIzatCMabsHBEAo;

		private ButtonStateFlags AzngTSkIggVwIypTYqiFOhGyMjwd;

		private ButtonStateFlags CJDmjobcXzhFlINjouNHaseWJGMJ;

		private ButtonStateFlags KmjTeyHmXyympHAxKzXuPisLZggG;

		private uint eDgozSOTYGkEmHZedyanjoOjvTKc;

		private bool lHxWFJphHkVdLsyJjHsSJJwPGlFP;

		private bool MWvBeqGnFOkCYFFUebiATvrBrbzdA;

		private bool TRoAWBMRkSJvpZBHhCtMgMKDnCeXA;

		private xyrBiUFcLFiQhnXPGmvEmNtNzoeY ifxJYGwaQDOeOCizfXMDBKwRCdkm;

		public bool emMsGyzfeJEFnLtCYgSNzTrPXNCO => lHxWFJphHkVdLsyJjHsSJJwPGlFP;

		public bool jgreINMKoLCpqhDrBkIuzhKtAvTeA
		{
			get
			{
				return MWvBeqGnFOkCYFFUebiATvrBrbzdA;
			}
			set
			{
				MWvBeqGnFOkCYFFUebiATvrBrbzdA = mWvBeqGnFOkCYFFUebiATvrBrbzdA;
			}
		}

		public ButtonStateFlags ChnHiROXANnTSEOngQuxJsiPajnm(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (XlUgFuIWGXdIIwIzatCMabsHBEAo & ButtonStateFlags.On) != 0;
				flag2 = (AzngTSkIggVwIypTYqiFOhGyMjwd & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!MWvBeqGnFOkCYFFUebiATvrBrbzdA) ? XlUgFuIWGXdIIwIzatCMabsHBEAo : ButtonStateFlags.Off);
			}
			else
			{
				flag = (CJDmjobcXzhFlINjouNHaseWJGMJ & ButtonStateFlags.On) != 0;
				flag2 = (KmjTeyHmXyympHAxKzXuPisLZggG & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!MWvBeqGnFOkCYFFUebiATvrBrbzdA) ? CJDmjobcXzhFlINjouNHaseWJGMJ : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (MWvBeqGnFOkCYFFUebiATvrBrbzdA)
				{
					if (flag2 && !TRoAWBMRkSJvpZBHhCtMgMKDnCeXA && ifxJYGwaQDOeOCizfXMDBKwRCdkm.NTcSwwzbfIqHmkxShleEAhkncBPdA)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (TRoAWBMRkSJvpZBHhCtMgMKDnCeXA && ifxJYGwaQDOeOCizfXMDBKwRCdkm.NTcSwwzbfIqHmkxShleEAhkncBPdA)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !MWvBeqGnFOkCYFFUebiATvrBrbzdA && !TRoAWBMRkSJvpZBHhCtMgMKDnCeXA)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void FPzzUVVPgjkZduoIYfykMVkplWhc()
		{
			AzngTSkIggVwIypTYqiFOhGyMjwd = XlUgFuIWGXdIIwIzatCMabsHBEAo;
			KmjTeyHmXyympHAxKzXuPisLZggG = CJDmjobcXzhFlINjouNHaseWJGMJ;
			TRoAWBMRkSJvpZBHhCtMgMKDnCeXA = MWvBeqGnFOkCYFFUebiATvrBrbzdA;
			XlUgFuIWGXdIIwIzatCMabsHBEAo = ButtonStateFlags.Off;
			CJDmjobcXzhFlINjouNHaseWJGMJ = ButtonStateFlags.Off;
		}

		public void FZwiWtCfWLuUnfVRsrrDPYTEzXLD(uint P_0)
		{
			if (eDgozSOTYGkEmHZedyanjoOjvTKc < P_0 - 1)
			{
				lHxWFJphHkVdLsyJjHsSJJwPGlFP = false;
			}
		}

		public void zMuSxXKYdAwRYQmTGDOYEdtugxrcA(bool P_0)
		{
			uuGbMKYwHvKUBJHPObcAWgMNDGyx((P_0 ? XlUgFuIWGXdIIwIzatCMabsHBEAo : CJDmjobcXzhFlINjouNHaseWJGMJ) | ButtonStateFlags.On, P_0);
		}

		public void uuGbMKYwHvKUBJHPObcAWgMNDGyx(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				XlUgFuIWGXdIIwIzatCMabsHBEAo = P_0;
			}
			else
			{
				CJDmjobcXzhFlINjouNHaseWJGMJ = P_0;
			}
			eDgozSOTYGkEmHZedyanjoOjvTKc = ReInput.currentFrame;
			if (!lHxWFJphHkVdLsyJjHsSJJwPGlFP)
			{
				lHxWFJphHkVdLsyJjHsSJJwPGlFP = true;
			}
		}

		public void FImUKfhofpvbIwIdGiYRdqHPvwcL(ref xyrBiUFcLFiQhnXPGmvEmNtNzoeY P_0)
		{
			ifxJYGwaQDOeOCizfXMDBKwRCdkm = P_0;
			MWvBeqGnFOkCYFFUebiATvrBrbzdA = P_0.YZuvVKhNrLMKJgCgkzLHkkjferjG;
			TRoAWBMRkSJvpZBHhCtMgMKDnCeXA = P_0.YZuvVKhNrLMKJgCgkzLHkkjferjG;
		}

		public void RUWafbYjVEuJhNpGruYIgcjVLauU()
		{
			XlUgFuIWGXdIIwIzatCMabsHBEAo = ButtonStateFlags.Off;
			AzngTSkIggVwIypTYqiFOhGyMjwd = ButtonStateFlags.Off;
			CJDmjobcXzhFlINjouNHaseWJGMJ = ButtonStateFlags.Off;
			KmjTeyHmXyympHAxKzXuPisLZggG = ButtonStateFlags.Off;
			eDgozSOTYGkEmHZedyanjoOjvTKc = 0u;
			lHxWFJphHkVdLsyJjHsSJJwPGlFP = false;
			MWvBeqGnFOkCYFFUebiATvrBrbzdA = false;
			TRoAWBMRkSJvpZBHhCtMgMKDnCeXA = false;
		}
	}

	public struct xyrBiUFcLFiQhnXPGmvEmNtNzoeY
	{
		public bool NTcSwwzbfIqHmkxShleEAhkncBPdA;

		public bool YZuvVKhNrLMKJgCgkzLHkkjferjG;

		public static xyrBiUFcLFiQhnXPGmvEmNtNzoeY ivDtCkVBJEhQqUgjTpGImrOMMWOG => default(xyrBiUFcLFiQhnXPGmvEmNtNzoeY);
	}

	[Serializable]
	private sealed class RupFINNVkHzpJEQWhzWETgBDRZyI
	{
		public static readonly RupFINNVkHzpJEQWhzWETgBDRZyI _003C_003E9 = new RupFINNVkHzpJEQWhzWETgBDRZyI();

		public static Func<QelmzpNwUGpoVdNlxWAsvKsUGuKP> _003C_003E9__22_0;

		internal XQbPBhlyQFBGpNmlFgFIDEslKZJP LQNYAUMdtjdwxADPmTmWorXtqmbcA()
		{
			return new XQbPBhlyQFBGpNmlFgFIDEslKZJP();
		}

		internal void pTuEfUjqkSLMBPTWkCDAEUHbLKpC(XQbPBhlyQFBGpNmlFgFIDEslKZJP P_0)
		{
			P_0.AoWcyMYdtXGbTkDljCipYkoXiQXVA();
		}

		internal QelmzpNwUGpoVdNlxWAsvKsUGuKP ytfnSSkoPZfGnuWrVguKGWMKhTSrA()
		{
			return new QelmzpNwUGpoVdNlxWAsvKsUGuKP();
		}
	}

	private const int sCxBDITggacYERpOwirfPQSNxOzE = 20;

	private const int TLIhPQoEbQkjoaxsoTkdIUNyIYes = 10;

	private static ObjectPool<XQbPBhlyQFBGpNmlFgFIDEslKZJP> aPylZJsEYlGALOAyCHabZBBeHTjaA;

	private static XQbPBhlyQFBGpNmlFgFIDEslKZJP[] sjYtZVhtVLlRpOXctpbYiOKkvYKn;

	private static int pryBvjGooYFOZGprcCZYmyCTvmPEc;

	public int DefqrQNoFJMJCzwywZpymjWwVSji;

	private UpdateLoopDataSet<QelmzpNwUGpoVdNlxWAsvKsUGuKP> whLwtNlIVOlBxbCJwXFKdnjMrrzW;

	public bool weZBXAXxTGUZgeqOHfkjTAMqZLHq
	{
		get
		{
			int count = whLwtNlIVOlBxbCJwXFKdnjMrrzW.Count;
			for (int i = 0; i < count; i++)
			{
				if (whLwtNlIVOlBxbCJwXFKdnjMrrzW[i].emMsGyzfeJEFnLtCYgSNzTrPXNCO)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool nXeuusDIfwjcSbkGqdARxzcJGoBzA
	{
		get
		{
			return whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.jgreINMKoLCpqhDrBkIuzhKtAvTeA;
		}
		set
		{
			whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.jgreINMKoLCpqhDrBkIuzhKtAvTeA = flag;
		}
	}

	static XQbPBhlyQFBGpNmlFgFIDEslKZJP()
	{
		aPylZJsEYlGALOAyCHabZBBeHTjaA = new ObjectPool<XQbPBhlyQFBGpNmlFgFIDEslKZJP>(20, RupFINNVkHzpJEQWhzWETgBDRZyI._003C_003E9.LQNYAUMdtjdwxADPmTmWorXtqmbcA, RupFINNVkHzpJEQWhzWETgBDRZyI._003C_003E9.pTuEfUjqkSLMBPTWkCDAEUHbLKpC);
		sjYtZVhtVLlRpOXctpbYiOKkvYKn = new XQbPBhlyQFBGpNmlFgFIDEslKZJP[20];
	}

	public static void BQweCAtphicwgHuQORPSKCoEoqW()
	{
		pryBvjGooYFOZGprcCZYmyCTvmPEc = 0;
		Array.Clear(sjYtZVhtVLlRpOXctpbYiOKkvYKn, 0, sjYtZVhtVLlRpOXctpbYiOKkvYKn.Length);
		aPylZJsEYlGALOAyCHabZBBeHTjaA.Clear();
	}

	public static XQbPBhlyQFBGpNmlFgFIDEslKZJP mzqCowBlnAZAIhNmHwTkniNCLRvWA(int P_0)
	{
		for (int i = 0; i < pryBvjGooYFOZGprcCZYmyCTvmPEc; i++)
		{
			if (sjYtZVhtVLlRpOXctpbYiOKkvYKn[i] != null && sjYtZVhtVLlRpOXctpbYiOKkvYKn[i].DefqrQNoFJMJCzwywZpymjWwVSji == P_0)
			{
				return sjYtZVhtVLlRpOXctpbYiOKkvYKn[i];
			}
		}
		return null;
	}

	public static XQbPBhlyQFBGpNmlFgFIDEslKZJP AlseqFygUpijvvuzMomIBteKutUo(int P_0, xyrBiUFcLFiQhnXPGmvEmNtNzoeY P_1)
	{
		XQbPBhlyQFBGpNmlFgFIDEslKZJP xQbPBhlyQFBGpNmlFgFIDEslKZJP = mzqCowBlnAZAIhNmHwTkniNCLRvWA(P_0);
		if (xQbPBhlyQFBGpNmlFgFIDEslKZJP != null)
		{
			return xQbPBhlyQFBGpNmlFgFIDEslKZJP;
		}
		xQbPBhlyQFBGpNmlFgFIDEslKZJP = aPylZJsEYlGALOAyCHabZBBeHTjaA.Get();
		xQbPBhlyQFBGpNmlFgFIDEslKZJP.IzADvDjkRFcyNlBKzBLyRqvfVkQh(P_0);
		xQbPBhlyQFBGpNmlFgFIDEslKZJP.inObnPnTRVfxNXCDMvDwAgSwcbdAA(ref P_1);
		xQbPBhlyQFBGpNmlFgFIDEslKZJP.whLwtNlIVOlBxbCJwXFKdnjMrrzW.SetUpdateLoop(ReInput.currentUpdateLoop);
		vMdTGSeYjezmYJKNuoURHtVjucsD(xQbPBhlyQFBGpNmlFgFIDEslKZJP);
		return xQbPBhlyQFBGpNmlFgFIDEslKZJP;
	}

	public static void MLAwTXIwADpEAApeNJbvBhLZrvx(UpdateLoopType P_0)
	{
		for (int i = 0; i < pryBvjGooYFOZGprcCZYmyCTvmPEc; i++)
		{
			if (sjYtZVhtVLlRpOXctpbYiOKkvYKn[i] != null)
			{
				sjYtZVhtVLlRpOXctpbYiOKkvYKn[i].HMdbgIgqVOBNJkNVsGGBTbwknqlS(P_0);
			}
		}
	}

	public static void KmaMezywuRDQogkAzHEyGTmEiBskA(UpdateLoopType P_0, uint P_1)
	{
		for (int num = pryBvjGooYFOZGprcCZYmyCTvmPEc - 1; num >= 0; num--)
		{
			if (sjYtZVhtVLlRpOXctpbYiOKkvYKn[num] == null)
			{
				if (num == pryBvjGooYFOZGprcCZYmyCTvmPEc - 1)
				{
					pryBvjGooYFOZGprcCZYmyCTvmPEc--;
				}
			}
			else
			{
				sjYtZVhtVLlRpOXctpbYiOKkvYKn[num].jZcNLKpvsEijLZpJTKpSUfhOmaNe(P_1);
				if (!sjYtZVhtVLlRpOXctpbYiOKkvYKn[num].weZBXAXxTGUZgeqOHfkjTAMqZLHq)
				{
					eEXHlkEbeFhASEFMjBOWvRCljdbC(num);
				}
			}
		}
	}

	private static void vMdTGSeYjezmYJKNuoURHtVjucsD(XQbPBhlyQFBGpNmlFgFIDEslKZJP P_0)
	{
		int num = EtpCDeaLkFQcQiWyBsevAhXQWtbLA();
		if (num < 0)
		{
			if (pryBvjGooYFOZGprcCZYmyCTvmPEc == sjYtZVhtVLlRpOXctpbYiOKkvYKn.Length)
			{
				XQbPBhlyQFBGpNmlFgFIDEslKZJP[] array = sjYtZVhtVLlRpOXctpbYiOKkvYKn;
				sjYtZVhtVLlRpOXctpbYiOKkvYKn = new XQbPBhlyQFBGpNmlFgFIDEslKZJP[sjYtZVhtVLlRpOXctpbYiOKkvYKn.Length + 10];
				Array.Copy(array, sjYtZVhtVLlRpOXctpbYiOKkvYKn, array.Length);
			}
			num = pryBvjGooYFOZGprcCZYmyCTvmPEc;
			pryBvjGooYFOZGprcCZYmyCTvmPEc++;
		}
		sjYtZVhtVLlRpOXctpbYiOKkvYKn[num] = P_0;
	}

	private static void eEXHlkEbeFhASEFMjBOWvRCljdbC(int P_0)
	{
		if (P_0 >= 0 && P_0 < pryBvjGooYFOZGprcCZYmyCTvmPEc)
		{
			XQbPBhlyQFBGpNmlFgFIDEslKZJP xQbPBhlyQFBGpNmlFgFIDEslKZJP = sjYtZVhtVLlRpOXctpbYiOKkvYKn[P_0];
			if (xQbPBhlyQFBGpNmlFgFIDEslKZJP != null)
			{
				aPylZJsEYlGALOAyCHabZBBeHTjaA.Return(xQbPBhlyQFBGpNmlFgFIDEslKZJP);
				sjYtZVhtVLlRpOXctpbYiOKkvYKn[P_0] = null;
			}
			if (P_0 == pryBvjGooYFOZGprcCZYmyCTvmPEc - 1)
			{
				pryBvjGooYFOZGprcCZYmyCTvmPEc--;
			}
		}
	}

	private static int EtpCDeaLkFQcQiWyBsevAhXQWtbLA()
	{
		for (int i = 0; i < pryBvjGooYFOZGprcCZYmyCTvmPEc; i++)
		{
			if (sjYtZVhtVLlRpOXctpbYiOKkvYKn[i] == null)
			{
				return i;
			}
		}
		if (pryBvjGooYFOZGprcCZYmyCTvmPEc >= sjYtZVhtVLlRpOXctpbYiOKkvYKn.Length)
		{
			return -1;
		}
		int result = pryBvjGooYFOZGprcCZYmyCTvmPEc;
		pryBvjGooYFOZGprcCZYmyCTvmPEc++;
		return result;
	}

	public ButtonStateFlags oXDUmGfgWGHrNNbJhHGRfncigPAV(bool P_0)
	{
		return whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.ChnHiROXANnTSEOngQuxJsiPajnm(P_0);
	}

	public XQbPBhlyQFBGpNmlFgFIDEslKZJP()
	{
		whLwtNlIVOlBxbCJwXFKdnjMrrzW = new UpdateLoopDataSet<QelmzpNwUGpoVdNlxWAsvKsUGuKP>(ReInput.UserData.ConfigVars.updateLoop, RupFINNVkHzpJEQWhzWETgBDRZyI._003C_003E9.ytfnSSkoPZfGnuWrVguKGWMKhTSrA);
		AoWcyMYdtXGbTkDljCipYkoXiQXVA();
	}

	public void HMdbgIgqVOBNJkNVsGGBTbwknqlS(UpdateLoopType P_0)
	{
		whLwtNlIVOlBxbCJwXFKdnjMrrzW.SetUpdateLoop(P_0);
		whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.FPzzUVVPgjkZduoIYfykMVkplWhc();
	}

	public void jZcNLKpvsEijLZpJTKpSUfhOmaNe(uint P_0)
	{
		whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.FZwiWtCfWLuUnfVRsrrDPYTEzXLD(P_0);
	}

	public void VMzjUdUTFLzEoJGXHnthtJLVIjNk(UpdateLoopType P_0, bool P_1)
	{
		whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.zMuSxXKYdAwRYQmTGDOYEdtugxrcA(P_1);
	}

	public void GUcHXzOThGSFFpQpOLrdpEwsgVbw(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		whLwtNlIVOlBxbCJwXFKdnjMrrzW.Current.uuGbMKYwHvKUBJHPObcAWgMNDGyx(P_1, P_2);
	}

	private void inObnPnTRVfxNXCDMvDwAgSwcbdAA(ref xyrBiUFcLFiQhnXPGmvEmNtNzoeY P_0)
	{
		int count = whLwtNlIVOlBxbCJwXFKdnjMrrzW.Count;
		for (int i = 0; i < count; i++)
		{
			whLwtNlIVOlBxbCJwXFKdnjMrrzW[i].FImUKfhofpvbIwIdGiYRdqHPvwcL(ref P_0);
		}
	}

	private void IzADvDjkRFcyNlBKzBLyRqvfVkQh(int P_0)
	{
		DefqrQNoFJMJCzwywZpymjWwVSji = P_0;
	}

	private void AoWcyMYdtXGbTkDljCipYkoXiQXVA()
	{
		DefqrQNoFJMJCzwywZpymjWwVSji = -1;
		int count = whLwtNlIVOlBxbCJwXFKdnjMrrzW.Count;
		for (int i = 0; i < count; i++)
		{
			whLwtNlIVOlBxbCJwXFKdnjMrrzW[i].RUWafbYjVEuJhNpGruYIgcjVLauU();
		}
	}
}
