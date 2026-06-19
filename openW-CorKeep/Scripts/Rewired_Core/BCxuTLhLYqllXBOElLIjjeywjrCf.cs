using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class BCxuTLhLYqllXBOElLIjjeywjrCf
{
	public class yaCdEjKFXJAaZyHvIJUjPMMgvoUF
	{
		public readonly Action<InputActionEventData> eblHOGNbzkGakcnvfQnTxHAtvFbSA;

		public readonly UpdateLoopType EHxVIBngDtyMqfiJAFPgdGuJLQTnA;

		public readonly InputActionEventType WyMJWKAENOlDvURDGFOEYTOgKNvW;

		public readonly int bKVTakXNPYDPulDPSFvxagXbFcIEb;

		public readonly bool iGbEKxAJmBhhpSdknnTUWwpoQXgL;

		public float[] cFvYFoqhYMKrpJHCtWcnUbczQcmj;

		public yaCdEjKFXJAaZyHvIJUjPMMgvoUF(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			EHxVIBngDtyMqfiJAFPgdGuJLQTnA = P_1;
			WyMJWKAENOlDvURDGFOEYTOgKNvW = P_2;
			bKVTakXNPYDPulDPSFvxagXbFcIEb = P_3;
			eblHOGNbzkGakcnvfQnTxHAtvFbSA = P_0;
			PUvuZWfIhxfKQnJBcLtIMqIFgaoC(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				iGbEKxAJmBhhpSdknnTUWwpoQXgL = true;
				break;
			}
		}

		public bool oQvxhYLeIScQYKzJxNfZzpsMvvVS(int P_0, out float P_1)
		{
			if (cFvYFoqhYMKrpJHCtWcnUbczQcmj == null || cFvYFoqhYMKrpJHCtWcnUbczQcmj.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = cFvYFoqhYMKrpJHCtWcnUbczQcmj[P_0];
			return true;
		}

		private void PUvuZWfIhxfKQnJBcLtIMqIFgaoC(object[] P_0)
		{
			switch (WyMJWKAENOlDvURDGFOEYTOgKNvW)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + WyMJWKAENOlDvURDGFOEYTOgKNvW.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				cFvYFoqhYMKrpJHCtWcnUbczQcmj = new float[2];
				if (P_0[0] is float)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + WyMJWKAENOlDvURDGFOEYTOgKNvW.ToString() + "\". Argument 0: time [float]");
					}
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + WyMJWKAENOlDvURDGFOEYTOgKNvW.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + WyMJWKAENOlDvURDGFOEYTOgKNvW.ToString() + "\". Requires 1 argument: time [float]");
				}
				cFvYFoqhYMKrpJHCtWcnUbczQcmj = new float[1];
				if (P_0[0] is float)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + WyMJWKAENOlDvURDGFOEYTOgKNvW.ToString() + "\". Argument 0: time [float]");
			case InputActionEventType.ButtonDoublePressed:
			case InputActionEventType.ButtonJustDoublePressed:
			case InputActionEventType.NegativeButtonDoublePressed:
			case InputActionEventType.NegativeButtonJustDoublePressed:
			case InputActionEventType.ButtonDoublePressJustReleased:
			case InputActionEventType.NegativeButtonDoublePressJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					break;
				}
				cFvYFoqhYMKrpJHCtWcnUbczQcmj = new float[1];
				if (P_0[0] is float)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					cFvYFoqhYMKrpJHCtWcnUbczQcmj[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + WyMJWKAENOlDvURDGFOEYTOgKNvW.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class jOhmCSgofdwSGXUGBOlaxOMHStjn
	{
		public static readonly jOhmCSgofdwSGXUGBOlaxOMHStjn _003C_003E9 = new jOhmCSgofdwSGXUGBOlaxOMHStjn();

		public static Func<AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>> _003C_003E9__8_0;

		internal AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> aPUjuVasZlncHKOCIHlWCYxNUloj()
		{
			return new AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>();
		}
	}

	private sealed class aFWOffARaeCsLmiqfbNazwmJRXXQ
	{
		public Action<InputActionEventData> bYPMgEmdluRMBFAhhKYTZwHodkvo;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> QQfiIVxQgmHxsSFDUbqBmEhcEplb;

		internal bool KWZHYSCdhvAAdqBgUZrAMrFVqoKV(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			return P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == bYPMgEmdluRMBFAhhKYTZwHodkvo;
		}
	}

	private sealed class JSVeZERacxHPcfydQujxMZHPfPiN
	{
		public Action<InputActionEventData> ePJanrtmxhupEMRhrQaWQjfaxfVs;

		public int utEUEsAmTPgUpnOvtHfSbjFaRAOQ;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> GlFqqbOhmMQfgLmDgtQoEkiqDfYBA;

		internal bool hGmXJAhOORizvaOEEwWCXtvZnFzp(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == ePJanrtmxhupEMRhrQaWQjfaxfVs)
			{
				return P_0.bKVTakXNPYDPulDPSFvxagXbFcIEb == utEUEsAmTPgUpnOvtHfSbjFaRAOQ;
			}
			return false;
		}
	}

	private sealed class yucYhmZVMmHPPHZReuVryRjhlIpT
	{
		public Action<InputActionEventData> CbvYMSItSTgjtsGdTZtUihLXAEpKA;

		public UpdateLoopType GUPIxhddUMQdoBNmeIMlqvLKilsHA;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> VseFKUmDzGhVPNndtEwDPchdoPSE;

		internal bool iOLPulhsjZhGRvhwFEDLUoIJbWwY(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == CbvYMSItSTgjtsGdTZtUihLXAEpKA)
			{
				return P_0.EHxVIBngDtyMqfiJAFPgdGuJLQTnA == GUPIxhddUMQdoBNmeIMlqvLKilsHA;
			}
			return false;
		}
	}

	private sealed class ssQqDLbWvtVFRlRwzUPbyKaLjGGH
	{
		public Action<InputActionEventData> rjcxJZjAxCOTprXilIwCWkjwquxo;

		public InputActionEventType RGMjmXxHwiKDnFNxWhBMYrwWTPIk;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> KhcGgcFnyStSJVTzedfOCQhJodBtA;

		internal bool AOpDVLcuZOYGHFonFLEZdKhCoDPbc(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == rjcxJZjAxCOTprXilIwCWkjwquxo)
			{
				return P_0.WyMJWKAENOlDvURDGFOEYTOgKNvW == RGMjmXxHwiKDnFNxWhBMYrwWTPIk;
			}
			return false;
		}
	}

	private sealed class yYDSrppTQDIlzczSwSmIdswIfSkM
	{
		public Action<InputActionEventData> yAmytAaZkrWdbErDHIAgakBRNSpeb;

		public UpdateLoopType JiiReJTxwneBQBkuXzrWMbgMeoSo;

		public int JnzHGAljpqVvvRNyjckGFaUbSNLvA;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> HVeXhhrXimditeYrFIMPhKjmcrneA;

		internal bool LtmndQGdHmrOzTKPcKLPAHRLRryT(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == yAmytAaZkrWdbErDHIAgakBRNSpeb && P_0.EHxVIBngDtyMqfiJAFPgdGuJLQTnA == JiiReJTxwneBQBkuXzrWMbgMeoSo)
			{
				return P_0.bKVTakXNPYDPulDPSFvxagXbFcIEb == JnzHGAljpqVvvRNyjckGFaUbSNLvA;
			}
			return false;
		}
	}

	private sealed class tEUVTKTvngfcLwtwEncyOZShMjzb
	{
		public Action<InputActionEventData> hfWqEBJcDnJJpFQbFUKeGgtuqFDy;

		public UpdateLoopType mxMDJwITyshbTfgSeIHwzuPmUoKXB;

		public int CosIbTIcfIgzXckthXaBIcqVPFXV;

		public InputActionEventType ttPbqjUXuwQJipJhihrzAxiTohyJ;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> NGihBAjIMZblXuNBNhlYjcDmgjrFb;

		internal bool jJRtnaiAqhrxgSZKrpsDtsuiuLQG(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == hfWqEBJcDnJJpFQbFUKeGgtuqFDy && P_0.EHxVIBngDtyMqfiJAFPgdGuJLQTnA == mxMDJwITyshbTfgSeIHwzuPmUoKXB && P_0.bKVTakXNPYDPulDPSFvxagXbFcIEb == CosIbTIcfIgzXckthXaBIcqVPFXV)
			{
				return P_0.WyMJWKAENOlDvURDGFOEYTOgKNvW == ttPbqjUXuwQJipJhihrzAxiTohyJ;
			}
			return false;
		}
	}

	private sealed class QmcMacHEQUjHepLIcCzRSpVqMJtN
	{
		public Action<InputActionEventData> dvQTWCqxOXlCOYZiaoHzxuTgILch;

		public UpdateLoopType QdzKaUMOhLBnZsGlSjIlFEmqObdIb;

		public InputActionEventType rVmydKQzgTfEeCcKJaInhjiXKqNEA;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> oJHYQZxJcuctvFMLALloTptLqxmhA;

		internal bool IBslEduDUsrdLpkEprFKvLBzKmme(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == dvQTWCqxOXlCOYZiaoHzxuTgILch && P_0.EHxVIBngDtyMqfiJAFPgdGuJLQTnA == QdzKaUMOhLBnZsGlSjIlFEmqObdIb)
			{
				return P_0.WyMJWKAENOlDvURDGFOEYTOgKNvW == rVmydKQzgTfEeCcKJaInhjiXKqNEA;
			}
			return false;
		}
	}

	private sealed class zHjslqLynEUGbLDnanvzAMaVINAhA
	{
		public Action<InputActionEventData> OJXguNbDACjzdnhJIMKaiHdceDRQ;

		public int mBOZQFOnutNpbhlJUTNyqcGlKkPe;

		public InputActionEventType fyzevKKjabGIDRhpccIlREdmbxngA;

		public Predicate<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> kflbudHZUNgdLnSWLDSCgiiGoskHA;

		internal bool gwTxzGzklEbdWIPDZFcRlXimOrRl(yaCdEjKFXJAaZyHvIJUjPMMgvoUF P_0)
		{
			if (P_0.eblHOGNbzkGakcnvfQnTxHAtvFbSA == OJXguNbDACjzdnhJIMKaiHdceDRQ && P_0.bKVTakXNPYDPulDPSFvxagXbFcIEb == mBOZQFOnutNpbhlJUTNyqcGlKkPe)
			{
				return P_0.WyMJWKAENOlDvURDGFOEYTOgKNvW == fyzevKKjabGIDRhpccIlREdmbxngA;
			}
			return false;
		}
	}

	private static yaCdEjKFXJAaZyHvIJUjPMMgvoUF[] kRLFHcClcwOXaDuWcTKCxGJnIZT;

	private bool rFyeenANtIqsbvLHErLdBZiXejgTA;

	private AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] tztDISfnXLVhfsznBcfmsoGKTNxW;

	private int[] bRyqbZHiKKdFceFxNoklWlRRzYeS;

	private int HxPxtSlAwVPmvGKgJXmOVNyQNLtb;

	public int mQuBsyAHuWgGMgVseLjUOaPECQufc;

	static BCxuTLhLYqllXBOElLIjjeywjrCf()
	{
		kRLFHcClcwOXaDuWcTKCxGJnIZT = new yaCdEjKFXJAaZyHvIJUjPMMgvoUF[100];
	}

	private void RKCYLYyJRkjApxmBoCeoSbewlpUA()
	{
		if (!rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			IList<InputAction> list = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.zDegZifxhvKwqdNZQWkPQxguqoRu;
			int num = list?.Count ?? 0;
			tztDISfnXLVhfsznBcfmsoGKTNxW = new AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[num + 1];
			bRyqbZHiKKdFceFxNoklWlRRzYeS = new int[ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.gybAtbieWPNpFVpXiXYFojvGoFkI + 1];
			ArrayTools.Populate(tztDISfnXLVhfsznBcfmsoGKTNxW, 0, tztDISfnXLVhfsznBcfmsoGKTNxW.Length, jOhmCSgofdwSGXUGBOlaxOMHStjn._003C_003E9.aPUjuVasZlncHKOCIHlWCYxNUloj);
			for (int i = 0; i < num; i++)
			{
				bRyqbZHiKKdFceFxNoklWlRRzYeS[list[i].id] = i;
			}
			HxPxtSlAwVPmvGKgJXmOVNyQNLtb = num;
			rFyeenANtIqsbvLHErLdBZiXejgTA = true;
		}
	}

	public void pdqLFPnoJpIypJUIQYBegAEIzwlQ(fDpcCKCuzPiJSPYRYUOXoNEJrNYcb P_0, UpdateLoopType P_1)
	{
		AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF> aList = tztDISfnXLVhfsznBcfmsoGKTNxW[bRyqbZHiKKdFceFxNoklWlRRzYeS[P_0.cJgRzxCqtyuAlhucVhDRSNWKxSHe]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = tztDISfnXLVhfsznBcfmsoGKTNxW[HxPxtSlAwVPmvGKgJXmOVNyQNLtb];
			}
			int count = aList._count;
			if (kRLFHcClcwOXaDuWcTKCxGJnIZT.Length < count)
			{
				kRLFHcClcwOXaDuWcTKCxGJnIZT = new yaCdEjKFXJAaZyHvIJUjPMMgvoUF[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, kRLFHcClcwOXaDuWcTKCxGJnIZT, count);
			}
			for (int j = 0; j < count; j++)
			{
				yaCdEjKFXJAaZyHvIJUjPMMgvoUF yaCdEjKFXJAaZyHvIJUjPMMgvoUF2 = kRLFHcClcwOXaDuWcTKCxGJnIZT[j];
				if (yaCdEjKFXJAaZyHvIJUjPMMgvoUF2 == null || (!P_0.OpFUptdiJJHBuJreBdzpcqAoeWapA && !yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.iGbEKxAJmBhhpSdknnTUWwpoQXgL) || yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.EHxVIBngDtyMqfiJAFPgdGuJLQTnA != P_1 || (yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.bKVTakXNPYDPulDPSFvxagXbFcIEb >= 0 && yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.bKVTakXNPYDPulDPSFvxagXbFcIEb != P_0.cJgRzxCqtyuAlhucVhDRSNWKxSHe))
				{
					continue;
				}
				bool flag = false;
				switch (yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.WyMJWKAENOlDvURDGFOEYTOgKNvW)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.QjFgvPKGEeCadAwWpAOVbYVEwiocc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.QjFgvPKGEeCadAwWpAOVbYVEwiocc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num5);
					if (P_0.hDuEdSZIVodLmMgAcBClwJzyStxt(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num11))
					{
						continue;
					}
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(1, out var num12);
					if (P_0.sOsQEzsgKiHXPzOVEBhITTUQrJSc(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.IjFBYreATrxTjLNbqySkhPrzZrjNA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.BTkggOefvqEUVCIxbmeoCMWRrttS())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.tkgMQvUaqSzRkgPvBglpNsGXRHuK())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.pQiccvFOkHaSfeEAGxAyBgsphfSic())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num9);
					if (P_0.wUCqyJpqbVGgXlUCgZmqnapuZFiL(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num6);
					if (P_0.MAsIOVeSXLcrzYnfXRltcrTDvsUAA(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num4))
					{
						continue;
					}
					if (P_0.bIinHhvpUOIPAPGUJVspophPjzvH(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.WPpvGUJVQDjdSfNgllfkKsCeAiPM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.fVQgMTKMYhFErizSsNYktdPwEgAj())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num15))
					{
						continue;
					}
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(1, out var num16);
					if (P_0.WIhbzSNjjwDnIIspHqtaHIgnUxqv(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.sRHHMiCACydmibRnOXTCQfEROLPI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.utjUHiKzTnssUhdvAnYCntvklNiU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.gEgAMcaSKCMofNvLoSPhPyGOeqnO())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.CppttvrfXZuypUSpWtnBEPhObOGp())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.QwZBioUoWnclJYPKXrhzcsKZeMN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.YIetwDuXfleVZXjOOGVpyoIZRdlg())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.MZVcABaPnzwSAYScLIsjwTNwITCA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.MZVcABaPnzwSAYScLIsjwTNwITCA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num3);
					if (P_0.APRUMcTqPXHnSsLFqUoHcEftujgM(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num))
					{
						continue;
					}
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(1, out var num2);
					if (P_0.SGhUbfNCpyJYvQMUSVDVPEdBaLJM(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.dXjwGMaeXYEoLItTeUrdPplGifLc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.HkPSkWatznDEtFObKrhQofsAFDBy())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.IlnDwsriqNmIJnrVMGHpsxuVmCDk())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.PkjAuEhiLFblGFpEoLUSgkwdAWMPc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num14);
					if (P_0.OeHFCiBFoMONSFkDxrjrhjfrdKyBb(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num13);
					if (P_0.kAUIGHIRmqgIhITYRXdfyDeKJHvGA(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num10))
					{
						continue;
					}
					if (P_0.lzWSNJyuyDIVWfatOfBuxuMlyjQV(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.xGIVsgNZGAhBEPFOvKvKctfPctqN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.bnLTdeGiNoyyYqFMzrKaIlOcyqfD())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(0, out var num7))
					{
						continue;
					}
					yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.oQvxhYLeIScQYKzJxNfZzpsMvvVS(1, out var num8);
					if (P_0.OjFDupAWRtqEHLCDApfpexwBEnJBb(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.CirBXpYSwLpjktkuuieVfTCjxvsq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.OAoJiIXLmaeobgaxEVYinJhHPJCFb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.bVHaNgmFElRWmAMIPleLrwEkLgyI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.hMmBMCeSZmjRTcvFyylliQozOMsN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.PVixsVWcKhmAyzCuiqalzruTETQV())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.XGGeYmbOfRhTwqlTUNjJhyHmjBDTA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.KnkutKftHwuYOokXdGbLzZTyJRsc()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.KnkutKftHwuYOokXdGbLzZTyJRsc()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.NfEoghEuLnJfqxUnwoWveanivKEy()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.NfEoghEuLnJfqxUnwoWveanivKEy()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.KnkutKftHwuYOokXdGbLzZTyJRsc()) || !MathTools.ApproximatelyZero(P_0.cXVwqwFLrwcAUZbciwKrYuIRvMfI()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.NfEoghEuLnJfqxUnwoWveanivKEy()) || !MathTools.ApproximatelyZero(P_0.EGadHTOIaTgtghmXgjBjDCxfZOmzb()))
					{
						flag = true;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				try
				{
					if (flag)
					{
						InputActionEventData obj = P_0.KzuFeFaQFTEZxVHGKxwAIZRQZZnu(P_1);
						obj.eventType = yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.WyMJWKAENOlDvURDGFOEYTOgKNvW;
						yaCdEjKFXJAaZyHvIJUjPMMgvoUF2.eblHOGNbzkGakcnvfQnTxHAtvFbSA(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void SaYSvOCCFxTyuzbgnBwPsDgAgnBI(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			RKCYLYyJRkjApxmBoCeoSbewlpUA();
		}
		yaCdEjKFXJAaZyHvIJUjPMMgvoUF item;
		try
		{
			if (P_3 > ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.gybAtbieWPNpFVpXiXYFojvGoFkI)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new yaCdEjKFXJAaZyHvIJUjPMMgvoUF(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			tztDISfnXLVhfsznBcfmsoGKTNxW[HxPxtSlAwVPmvGKgJXmOVNyQNLtb].Add(item);
		}
		else
		{
			tztDISfnXLVhfsznBcfmsoGKTNxW[bRyqbZHiKKdFceFxNoklWlRRzYeS[P_3]].Add(item);
		}
		UvtUdiqFofVkpVeKOoFSrCrHfbQg();
	}

	public void uFqqgoHAUxQlTUOQXGOzgqdbGydg(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			RKCYLYyJRkjApxmBoCeoSbewlpUA();
		}
		yaCdEjKFXJAaZyHvIJUjPMMgvoUF item;
		try
		{
			item = new yaCdEjKFXJAaZyHvIJUjPMMgvoUF(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		tztDISfnXLVhfsznBcfmsoGKTNxW[HxPxtSlAwVPmvGKgJXmOVNyQNLtb].Add(item);
		UvtUdiqFofVkpVeKOoFSrCrHfbQg();
	}

	public void jGkBWgeSNqpwexvvptzxWYHPWFqQ(Action<InputActionEventData> P_0)
	{
		aFWOffARaeCsLmiqfbNazwmJRXXQ aFWOffARaeCsLmiqfbNazwmJRXXQ2 = new aFWOffARaeCsLmiqfbNazwmJRXXQ();
		aFWOffARaeCsLmiqfbNazwmJRXXQ2.bYPMgEmdluRMBFAhhKYTZwHodkvo = P_0;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(aFWOffARaeCsLmiqfbNazwmJRXXQ2.KWZHYSCdhvAAdqBgUZrAMrFVqoKV);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void lBBOBjgNcZDUDdRpTbhbjbhBfTGzB(Action<InputActionEventData> P_0, int P_1)
	{
		JSVeZERacxHPcfydQujxMZHPfPiN jSVeZERacxHPcfydQujxMZHPfPiN = new JSVeZERacxHPcfydQujxMZHPfPiN();
		jSVeZERacxHPcfydQujxMZHPfPiN.ePJanrtmxhupEMRhrQaWQjfaxfVs = P_0;
		jSVeZERacxHPcfydQujxMZHPfPiN.utEUEsAmTPgUpnOvtHfSbjFaRAOQ = P_1;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA && jSVeZERacxHPcfydQujxMZHPfPiN.utEUEsAmTPgUpnOvtHfSbjFaRAOQ <= ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.gybAtbieWPNpFVpXiXYFojvGoFkI)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(jSVeZERacxHPcfydQujxMZHPfPiN.hGmXJAhOORizvaOEEwWCXtvZnFzp);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void vJFcDcPGyXLAMkqxJIFgUiRqWKyr(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		yucYhmZVMmHPPHZReuVryRjhlIpT yucYhmZVMmHPPHZReuVryRjhlIpT2 = new yucYhmZVMmHPPHZReuVryRjhlIpT();
		yucYhmZVMmHPPHZReuVryRjhlIpT2.CbvYMSItSTgjtsGdTZtUihLXAEpKA = P_0;
		yucYhmZVMmHPPHZReuVryRjhlIpT2.GUPIxhddUMQdoBNmeIMlqvLKilsHA = P_1;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(yucYhmZVMmHPPHZReuVryRjhlIpT2.iOLPulhsjZhGRvhwFEDLUoIJbWwY);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void wQpKkCZjnSdjrHhgLHbWmDCAKUBpA(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		ssQqDLbWvtVFRlRwzUPbyKaLjGGH ssQqDLbWvtVFRlRwzUPbyKaLjGGH2 = new ssQqDLbWvtVFRlRwzUPbyKaLjGGH();
		ssQqDLbWvtVFRlRwzUPbyKaLjGGH2.rjcxJZjAxCOTprXilIwCWkjwquxo = P_0;
		ssQqDLbWvtVFRlRwzUPbyKaLjGGH2.RGMjmXxHwiKDnFNxWhBMYrwWTPIk = P_1;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(ssQqDLbWvtVFRlRwzUPbyKaLjGGH2.AOpDVLcuZOYGHFonFLEZdKhCoDPbc);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void iXvcCqRkwMYBghfdQDuqhtmXCvOEA(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		yYDSrppTQDIlzczSwSmIdswIfSkM yYDSrppTQDIlzczSwSmIdswIfSkM2 = new yYDSrppTQDIlzczSwSmIdswIfSkM();
		yYDSrppTQDIlzczSwSmIdswIfSkM2.yAmytAaZkrWdbErDHIAgakBRNSpeb = P_0;
		yYDSrppTQDIlzczSwSmIdswIfSkM2.JiiReJTxwneBQBkuXzrWMbgMeoSo = P_1;
		yYDSrppTQDIlzczSwSmIdswIfSkM2.JnzHGAljpqVvvRNyjckGFaUbSNLvA = P_2;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA && yYDSrppTQDIlzczSwSmIdswIfSkM2.JnzHGAljpqVvvRNyjckGFaUbSNLvA <= ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.gybAtbieWPNpFVpXiXYFojvGoFkI)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(yYDSrppTQDIlzczSwSmIdswIfSkM2.LtmndQGdHmrOzTKPcKLPAHRLRryT);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void aVJEUraTbOFxxgWHxJkGhPbhZOnTB(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		tEUVTKTvngfcLwtwEncyOZShMjzb tEUVTKTvngfcLwtwEncyOZShMjzb2 = new tEUVTKTvngfcLwtwEncyOZShMjzb();
		tEUVTKTvngfcLwtwEncyOZShMjzb2.hfWqEBJcDnJJpFQbFUKeGgtuqFDy = P_0;
		tEUVTKTvngfcLwtwEncyOZShMjzb2.mxMDJwITyshbTfgSeIHwzuPmUoKXB = P_1;
		tEUVTKTvngfcLwtwEncyOZShMjzb2.CosIbTIcfIgzXckthXaBIcqVPFXV = P_3;
		tEUVTKTvngfcLwtwEncyOZShMjzb2.ttPbqjUXuwQJipJhihrzAxiTohyJ = P_2;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA && tEUVTKTvngfcLwtwEncyOZShMjzb2.CosIbTIcfIgzXckthXaBIcqVPFXV <= ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.gybAtbieWPNpFVpXiXYFojvGoFkI)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(tEUVTKTvngfcLwtwEncyOZShMjzb2.jJRtnaiAqhrxgSZKrpsDtsuiuLQG);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void QTfQUfkULnTnltxJSjexJtFlLLSh(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		QmcMacHEQUjHepLIcCzRSpVqMJtN qmcMacHEQUjHepLIcCzRSpVqMJtN = new QmcMacHEQUjHepLIcCzRSpVqMJtN();
		qmcMacHEQUjHepLIcCzRSpVqMJtN.dvQTWCqxOXlCOYZiaoHzxuTgILch = P_0;
		qmcMacHEQUjHepLIcCzRSpVqMJtN.QdzKaUMOhLBnZsGlSjIlFEmqObdIb = P_1;
		qmcMacHEQUjHepLIcCzRSpVqMJtN.rVmydKQzgTfEeCcKJaInhjiXKqNEA = P_2;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(qmcMacHEQUjHepLIcCzRSpVqMJtN.IBslEduDUsrdLpkEprFKvLBzKmme);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void CFIrUUqVufJjNoOhIcKVKzDDQBNq(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		zHjslqLynEUGbLDnanvzAMaVINAhA zHjslqLynEUGbLDnanvzAMaVINAhA2 = new zHjslqLynEUGbLDnanvzAMaVINAhA();
		zHjslqLynEUGbLDnanvzAMaVINAhA2.OJXguNbDACjzdnhJIMKaiHdceDRQ = P_0;
		zHjslqLynEUGbLDnanvzAMaVINAhA2.mBOZQFOnutNpbhlJUTNyqcGlKkPe = P_2;
		zHjslqLynEUGbLDnanvzAMaVINAhA2.fyzevKKjabGIDRhpccIlREdmbxngA = P_1;
		if (rFyeenANtIqsbvLHErLdBZiXejgTA && zHjslqLynEUGbLDnanvzAMaVINAhA2.mBOZQFOnutNpbhlJUTNyqcGlKkPe <= ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.gybAtbieWPNpFVpXiXYFojvGoFkI)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(zHjslqLynEUGbLDnanvzAMaVINAhA2.gwTxzGzklEbdWIPDZFcRlXimOrRl);
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	public void JLuRkuTrxESkZZGWSlpoVTsMegRC()
	{
		if (rFyeenANtIqsbvLHErLdBZiXejgTA)
		{
			AList<yaCdEjKFXJAaZyHvIJUjPMMgvoUF>[] array = tztDISfnXLVhfsznBcfmsoGKTNxW;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			UvtUdiqFofVkpVeKOoFSrCrHfbQg();
		}
	}

	private void UvtUdiqFofVkpVeKOoFSrCrHfbQg()
	{
		int num = 0;
		for (int i = 0; i < tztDISfnXLVhfsznBcfmsoGKTNxW.Length; i++)
		{
			num += tztDISfnXLVhfsznBcfmsoGKTNxW[i]._count;
		}
		mQuBsyAHuWgGMgVseLjUOaPECQufc = num;
	}
}
