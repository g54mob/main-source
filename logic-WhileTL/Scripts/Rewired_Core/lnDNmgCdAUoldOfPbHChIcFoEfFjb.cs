using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class lnDNmgCdAUoldOfPbHChIcFoEfFjb
{
	public class IpkMfGzLSpWRhxHyUEplACxoHdFo
	{
		public readonly Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public readonly UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

		public readonly InputActionEventType PVigqAEexAbxPwnCdgXfBKBwFyDSA;

		public readonly int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

		public readonly bool KxwARQpqOwbUObnezGVetHizeWZdA;

		public float[] bLKXhOMJGOiCCsJhGKZpeueGTRHs;

		public IpkMfGzLSpWRhxHyUEplACxoHdFo(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_1;
			PVigqAEexAbxPwnCdgXfBKBwFyDSA = P_2;
			oRajQOHwRbMrJNwZiDDGjrEZUMQf = P_3;
			tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
			VfZZsYrNOLMdKuiHwlkvrCZgvBMG(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				KxwARQpqOwbUObnezGVetHizeWZdA = true;
				break;
			}
		}

		public bool loqQRLKqOOhnQdzazuoumFaJONMUA(int P_0, out float P_1)
		{
			if (bLKXhOMJGOiCCsJhGKZpeueGTRHs == null || bLKXhOMJGOiCCsJhGKZpeueGTRHs.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = bLKXhOMJGOiCCsJhGKZpeueGTRHs[P_0];
			return true;
		}

		private void VfZZsYrNOLMdKuiHwlkvrCZgvBMG(object[] P_0)
		{
			switch (PVigqAEexAbxPwnCdgXfBKBwFyDSA)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + PVigqAEexAbxPwnCdgXfBKBwFyDSA.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				bLKXhOMJGOiCCsJhGKZpeueGTRHs = new float[2];
				if (P_0[0] is float)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + PVigqAEexAbxPwnCdgXfBKBwFyDSA.ToString() + "\". Argument 0: time [float]");
					}
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + PVigqAEexAbxPwnCdgXfBKBwFyDSA.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + PVigqAEexAbxPwnCdgXfBKBwFyDSA.ToString() + "\". Requires 1 argument: time [float]");
				}
				bLKXhOMJGOiCCsJhGKZpeueGTRHs = new float[1];
				if (P_0[0] is float)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + PVigqAEexAbxPwnCdgXfBKBwFyDSA.ToString() + "\". Argument 0: time [float]");
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
				bLKXhOMJGOiCCsJhGKZpeueGTRHs = new float[1];
				if (P_0[0] is float)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					bLKXhOMJGOiCCsJhGKZpeueGTRHs[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + PVigqAEexAbxPwnCdgXfBKBwFyDSA.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class GExUQvJsqUnCpImDFvYWJHENshKI
	{
		public static readonly GExUQvJsqUnCpImDFvYWJHENshKI _003C_003E9 = new GExUQvJsqUnCpImDFvYWJHENshKI();

		public static Func<AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>> _003C_003E9__8_0;

		internal AList<IpkMfGzLSpWRhxHyUEplACxoHdFo> LRMAFuwQUwECEEMdQsVeWQaNGxihA()
		{
			return new AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>();
		}
	}

	private sealed class aCQzEZUgZOyenYhaSYVNmBDkVoAv
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			return P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb;
		}
	}

	private sealed class btdLliupGRXGGikVCupLBmfRPbeB
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb)
			{
				return P_0.oRajQOHwRbMrJNwZiDDGjrEZUMQf == oRajQOHwRbMrJNwZiDDGjrEZUMQf;
			}
			return false;
		}
	}

	private sealed class mhFFdXCZJiTARkpFSeSLgDGBVRuic
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb)
			{
				return P_0.KKlbldiDPbDuxfifcGjVGpjaqJEqB == KKlbldiDPbDuxfifcGjVGpjaqJEqB;
			}
			return false;
		}
	}

	private sealed class qBqjbCMUDLiBttPsPEQYEfXrcCMEb
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public InputActionEventType PVigqAEexAbxPwnCdgXfBKBwFyDSA;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb)
			{
				return P_0.PVigqAEexAbxPwnCdgXfBKBwFyDSA == PVigqAEexAbxPwnCdgXfBKBwFyDSA;
			}
			return false;
		}
	}

	private sealed class YRvvEWAMZfzZPvZustQMiDBCYprE
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

		public int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb && P_0.KKlbldiDPbDuxfifcGjVGpjaqJEqB == KKlbldiDPbDuxfifcGjVGpjaqJEqB)
			{
				return P_0.oRajQOHwRbMrJNwZiDDGjrEZUMQf == oRajQOHwRbMrJNwZiDDGjrEZUMQf;
			}
			return false;
		}
	}

	private sealed class XIqeRcukoSwvGtdsOAiqAPgfqSqEA
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

		public int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

		public InputActionEventType PVigqAEexAbxPwnCdgXfBKBwFyDSA;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb && P_0.KKlbldiDPbDuxfifcGjVGpjaqJEqB == KKlbldiDPbDuxfifcGjVGpjaqJEqB && P_0.oRajQOHwRbMrJNwZiDDGjrEZUMQf == oRajQOHwRbMrJNwZiDDGjrEZUMQf)
			{
				return P_0.PVigqAEexAbxPwnCdgXfBKBwFyDSA == PVigqAEexAbxPwnCdgXfBKBwFyDSA;
			}
			return false;
		}
	}

	private sealed class VUKdJvafCRhbfRHrJRTZsBsWVyFFA
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

		public InputActionEventType PVigqAEexAbxPwnCdgXfBKBwFyDSA;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb && P_0.KKlbldiDPbDuxfifcGjVGpjaqJEqB == KKlbldiDPbDuxfifcGjVGpjaqJEqB)
			{
				return P_0.PVigqAEexAbxPwnCdgXfBKBwFyDSA == PVigqAEexAbxPwnCdgXfBKBwFyDSA;
			}
			return false;
		}
	}

	private sealed class LiRjkJibauCdNWrkigFpXYVFNMJG
	{
		public Action<InputActionEventData> tMUcuAfGGoFbaZBeDMMyJYJtxaOb;

		public int oRajQOHwRbMrJNwZiDDGjrEZUMQf;

		public InputActionEventType PVigqAEexAbxPwnCdgXfBKBwFyDSA;

		public Predicate<IpkMfGzLSpWRhxHyUEplACxoHdFo> XyhWDkAJdxMHtXvUupvKhGVVfOEs;

		internal bool rfLuzOpBIuyJNVbPPWMVcbAlYGhF(IpkMfGzLSpWRhxHyUEplACxoHdFo P_0)
		{
			if (P_0.tMUcuAfGGoFbaZBeDMMyJYJtxaOb == tMUcuAfGGoFbaZBeDMMyJYJtxaOb && P_0.oRajQOHwRbMrJNwZiDDGjrEZUMQf == oRajQOHwRbMrJNwZiDDGjrEZUMQf)
			{
				return P_0.PVigqAEexAbxPwnCdgXfBKBwFyDSA == PVigqAEexAbxPwnCdgXfBKBwFyDSA;
			}
			return false;
		}
	}

	private static IpkMfGzLSpWRhxHyUEplACxoHdFo[] LUmlyZLtZqYLHDhpfbPqqKWtEXbO;

	private bool qumTafanxrjKbDduWdypwIzXqmiP;

	private AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] hhSNvMdnckGyPuExIGOwHcrdkEZq;

	private int[] cdIBnhvrxkelmuHVlaqOgQtrxOdn;

	private int EvJKetDdDhMUZeoxKFhzKBvZBByJA;

	public int SvUchSiwLtntKjNRdqNBkvIjahni;

	static lnDNmgCdAUoldOfPbHChIcFoEfFjb()
	{
		LUmlyZLtZqYLHDhpfbPqqKWtEXbO = new IpkMfGzLSpWRhxHyUEplACxoHdFo[100];
	}

	private void gUxczTgMdKUcYRnCXamteWaCXJodc()
	{
		if (!qumTafanxrjKbDduWdypwIzXqmiP)
		{
			IList<InputAction> list = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.aIbkLzPaXeQZjqLXplSFfffNDmjM;
			int num = list?.Count ?? 0;
			hhSNvMdnckGyPuExIGOwHcrdkEZq = new AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[num + 1];
			cdIBnhvrxkelmuHVlaqOgQtrxOdn = new int[ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.dVbqQOLNabUQwqcVwcAGKBYSCgRBA + 1];
			ArrayTools.Populate(hhSNvMdnckGyPuExIGOwHcrdkEZq, 0, hhSNvMdnckGyPuExIGOwHcrdkEZq.Length, GExUQvJsqUnCpImDFvYWJHENshKI._003C_003E9.LRMAFuwQUwECEEMdQsVeWQaNGxihA);
			for (int i = 0; i < num; i++)
			{
				cdIBnhvrxkelmuHVlaqOgQtrxOdn[list[i].id] = i;
			}
			EvJKetDdDhMUZeoxKFhzKBvZBByJA = num;
			qumTafanxrjKbDduWdypwIzXqmiP = true;
		}
	}

	public void lzQtftFgrdhWxlSTZNBDDLGbQNu(HuFUPnVcilGVsLkOQFTNYtvJAVLr P_0, UpdateLoopType P_1)
	{
		AList<IpkMfGzLSpWRhxHyUEplACxoHdFo> aList = hhSNvMdnckGyPuExIGOwHcrdkEZq[cdIBnhvrxkelmuHVlaqOgQtrxOdn[P_0.WtxqRhyewFhRCZexgGgTPAkliDAd]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = hhSNvMdnckGyPuExIGOwHcrdkEZq[EvJKetDdDhMUZeoxKFhzKBvZBByJA];
			}
			int count = aList._count;
			if (LUmlyZLtZqYLHDhpfbPqqKWtEXbO.Length < count)
			{
				LUmlyZLtZqYLHDhpfbPqqKWtEXbO = new IpkMfGzLSpWRhxHyUEplACxoHdFo[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, LUmlyZLtZqYLHDhpfbPqqKWtEXbO, count);
			}
			for (int j = 0; j < count; j++)
			{
				IpkMfGzLSpWRhxHyUEplACxoHdFo ipkMfGzLSpWRhxHyUEplACxoHdFo = LUmlyZLtZqYLHDhpfbPqqKWtEXbO[j];
				if (ipkMfGzLSpWRhxHyUEplACxoHdFo == null || (!P_0.OPjUMjHhYjyuyHXqezxOrhROiazp && !ipkMfGzLSpWRhxHyUEplACxoHdFo.KxwARQpqOwbUObnezGVetHizeWZdA) || ipkMfGzLSpWRhxHyUEplACxoHdFo.KKlbldiDPbDuxfifcGjVGpjaqJEqB != P_1 || (ipkMfGzLSpWRhxHyUEplACxoHdFo.oRajQOHwRbMrJNwZiDDGjrEZUMQf >= 0 && ipkMfGzLSpWRhxHyUEplACxoHdFo.oRajQOHwRbMrJNwZiDDGjrEZUMQf != P_0.WtxqRhyewFhRCZexgGgTPAkliDAd))
				{
					continue;
				}
				bool flag = false;
				switch (ipkMfGzLSpWRhxHyUEplACxoHdFo.PVigqAEexAbxPwnCdgXfBKBwFyDSA)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.PKxzXBSMXndnnwoVrPblHLVDZExv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.PKxzXBSMXndnnwoVrPblHLVDZExv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num5);
					if (P_0.ExzCcLBqDxDpCccDPnSlIdKQoEOxA(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num11))
					{
						continue;
					}
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(1, out var num12);
					if (P_0.MijQAzbgipqhmrRTMEAjRYehWkeS(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.XujDkxfqkqnIoHYvDKerQvlfvmkYA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.NIoDqkKPjEoFxDUldIBBPhbfUQJKB())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.WBIaBbghQpgzOEKyaCjXLOtiaWQP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.mjQmQdEkqdYvFzOGOLRYyQYeGhCg())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num9);
					if (P_0.qLLgoCHAuTvEpknkLUncjRjpPpCPA(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num6);
					if (P_0.dIRAKDCSExHVTMEwLyuUgaSxPzmYA(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num4))
					{
						continue;
					}
					if (P_0.OnVkLWxiYqOUxNEiNSRDGpDMlRXW(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.GspCLfBRlvRsOJxFwoAeDebWMIwrA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.EickhBxXSpLJmZfmCdxGysHgYJXu())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num15))
					{
						continue;
					}
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(1, out var num16);
					if (P_0.FKIXfMMuStjlooachfgAhGsYeFxdA(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.eaNjLDcSHnFbCqctTYQcrKwgfyGlA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.EXdFXyZnCrhwMnlrmXSAPFUZVQyX())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.ddtetPkUaprMIuFlUQlSEQgCcCGx())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.YefNDmxYaFaOfckhdzXTHQWiUwIP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.ZbZXwRDbpUbpKjPSFNzyAkHgzaVKB())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.QslgJubMTuHarludIYDjkIVdWerS())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.ilFAZwkIaxHKmyAvsBXuJQNIEkYs())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.ilFAZwkIaxHKmyAvsBXuJQNIEkYs())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num3);
					if (P_0.qPcUkEjeSlfflnmFngxJeNHykYzH(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num))
					{
						continue;
					}
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(1, out var num2);
					if (P_0.LPlGqCDEjrLvrznYozZSKYQyLwZgA(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.lIQHAOspqBODIsDHNyDmBsnQWNEQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.OkilHHDaqVFWlDDtostqEcGEVAwAA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.unhchykaxdiheOqgVQewBhsRIfZDA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.fFYMTDlJiVbySbkKFktNzGIHtFWr())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num14);
					if (P_0.qDrbhExdaMtikEgOjSQeXXgpcOE(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num13);
					if (P_0.GtCARhmiIoXvysANTyjIfnagnZoV(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num10))
					{
						continue;
					}
					if (P_0.mQrzgDhVvvDGCmvHktGucwxMaJWl(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.IIGKRCnbezOzZtZctpspeCdMcGyh())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.ZLGCVshBdxlKdulKDJOCVMHiBPyhb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(0, out var num7))
					{
						continue;
					}
					ipkMfGzLSpWRhxHyUEplACxoHdFo.loqQRLKqOOhnQdzazuoumFaJONMUA(1, out var num8);
					if (P_0.jRlTkTJBiEfkwFuWPhmwLmDDKZyCb(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.JmphWjkypJvmbntpVBPMUvADBKVu())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.RlPdEncQLrsGZBhKIQtgNrUbzrwX())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.nRtweucGmOdDTZEodSgPcojlorYW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.sSAcKCHLnzXXRUDysDovidHtMfIDA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.xPqNPIUyKmOkDxnElSvJUJmnqPx())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.PSacIhqypanSwWLRlLNySDKJuXOi())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.AcvdmOzScVMcmBUZvbBnEUPMUIFm()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.AcvdmOzScVMcmBUZvbBnEUPMUIFm()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.HqTUEvWMbnrGUEHWWUiDJMMFFUPo()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.HqTUEvWMbnrGUEHWWUiDJMMFFUPo()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.AcvdmOzScVMcmBUZvbBnEUPMUIFm()) || !MathTools.ApproximatelyZero(P_0.qMrEIVBOXEVidwZRmnJsHUjElcFG()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.HqTUEvWMbnrGUEHWWUiDJMMFFUPo()) || !MathTools.ApproximatelyZero(P_0.ARqkTOKJToBnOJOxCZVrebmHrddFA()))
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
						InputActionEventData obj = P_0.xgKVSUsDrkaGwaQToJYPBxLBfDAjb(P_1);
						obj.eventType = ipkMfGzLSpWRhxHyUEplACxoHdFo.PVigqAEexAbxPwnCdgXfBKBwFyDSA;
						ipkMfGzLSpWRhxHyUEplACxoHdFo.tMUcuAfGGoFbaZBeDMMyJYJtxaOb(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void ObmRPnBAXLGPNSMVFccJbPKCnMoh(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!qumTafanxrjKbDduWdypwIzXqmiP)
		{
			gUxczTgMdKUcYRnCXamteWaCXJodc();
		}
		IpkMfGzLSpWRhxHyUEplACxoHdFo item;
		try
		{
			if (P_3 > ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.dVbqQOLNabUQwqcVwcAGKBYSCgRBA)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new IpkMfGzLSpWRhxHyUEplACxoHdFo(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			hhSNvMdnckGyPuExIGOwHcrdkEZq[EvJKetDdDhMUZeoxKFhzKBvZBByJA].Add(item);
		}
		else
		{
			hhSNvMdnckGyPuExIGOwHcrdkEZq[cdIBnhvrxkelmuHVlaqOgQtrxOdn[P_3]].Add(item);
		}
		TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
	}

	public void ObmRPnBAXLGPNSMVFccJbPKCnMoh(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!qumTafanxrjKbDduWdypwIzXqmiP)
		{
			gUxczTgMdKUcYRnCXamteWaCXJodc();
		}
		IpkMfGzLSpWRhxHyUEplACxoHdFo item;
		try
		{
			item = new IpkMfGzLSpWRhxHyUEplACxoHdFo(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		hhSNvMdnckGyPuExIGOwHcrdkEZq[EvJKetDdDhMUZeoxKFhzKBvZBByJA].Add(item);
		TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0)
	{
		aCQzEZUgZOyenYhaSYVNmBDkVoAv aCQzEZUgZOyenYhaSYVNmBDkVoAv2 = new aCQzEZUgZOyenYhaSYVNmBDkVoAv();
		aCQzEZUgZOyenYhaSYVNmBDkVoAv2.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		if (qumTafanxrjKbDduWdypwIzXqmiP)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(aCQzEZUgZOyenYhaSYVNmBDkVoAv2.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, int P_1)
	{
		btdLliupGRXGGikVCupLBmfRPbeB btdLliupGRXGGikVCupLBmfRPbeB2 = new btdLliupGRXGGikVCupLBmfRPbeB();
		btdLliupGRXGGikVCupLBmfRPbeB2.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		btdLliupGRXGGikVCupLBmfRPbeB2.oRajQOHwRbMrJNwZiDDGjrEZUMQf = P_1;
		if (qumTafanxrjKbDduWdypwIzXqmiP && btdLliupGRXGGikVCupLBmfRPbeB2.oRajQOHwRbMrJNwZiDDGjrEZUMQf <= ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.dVbqQOLNabUQwqcVwcAGKBYSCgRBA)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(btdLliupGRXGGikVCupLBmfRPbeB2.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		mhFFdXCZJiTARkpFSeSLgDGBVRuic mhFFdXCZJiTARkpFSeSLgDGBVRuic2 = new mhFFdXCZJiTARkpFSeSLgDGBVRuic();
		mhFFdXCZJiTARkpFSeSLgDGBVRuic2.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		mhFFdXCZJiTARkpFSeSLgDGBVRuic2.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_1;
		if (qumTafanxrjKbDduWdypwIzXqmiP)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(mhFFdXCZJiTARkpFSeSLgDGBVRuic2.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		qBqjbCMUDLiBttPsPEQYEfXrcCMEb qBqjbCMUDLiBttPsPEQYEfXrcCMEb2 = new qBqjbCMUDLiBttPsPEQYEfXrcCMEb();
		qBqjbCMUDLiBttPsPEQYEfXrcCMEb2.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		qBqjbCMUDLiBttPsPEQYEfXrcCMEb2.PVigqAEexAbxPwnCdgXfBKBwFyDSA = P_1;
		if (qumTafanxrjKbDduWdypwIzXqmiP)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(qBqjbCMUDLiBttPsPEQYEfXrcCMEb2.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		YRvvEWAMZfzZPvZustQMiDBCYprE yRvvEWAMZfzZPvZustQMiDBCYprE = new YRvvEWAMZfzZPvZustQMiDBCYprE();
		yRvvEWAMZfzZPvZustQMiDBCYprE.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		yRvvEWAMZfzZPvZustQMiDBCYprE.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_1;
		yRvvEWAMZfzZPvZustQMiDBCYprE.oRajQOHwRbMrJNwZiDDGjrEZUMQf = P_2;
		if (qumTafanxrjKbDduWdypwIzXqmiP && yRvvEWAMZfzZPvZustQMiDBCYprE.oRajQOHwRbMrJNwZiDDGjrEZUMQf <= ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.dVbqQOLNabUQwqcVwcAGKBYSCgRBA)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(yRvvEWAMZfzZPvZustQMiDBCYprE.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		XIqeRcukoSwvGtdsOAiqAPgfqSqEA xIqeRcukoSwvGtdsOAiqAPgfqSqEA = new XIqeRcukoSwvGtdsOAiqAPgfqSqEA();
		xIqeRcukoSwvGtdsOAiqAPgfqSqEA.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		xIqeRcukoSwvGtdsOAiqAPgfqSqEA.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_1;
		xIqeRcukoSwvGtdsOAiqAPgfqSqEA.oRajQOHwRbMrJNwZiDDGjrEZUMQf = P_3;
		xIqeRcukoSwvGtdsOAiqAPgfqSqEA.PVigqAEexAbxPwnCdgXfBKBwFyDSA = P_2;
		if (qumTafanxrjKbDduWdypwIzXqmiP && xIqeRcukoSwvGtdsOAiqAPgfqSqEA.oRajQOHwRbMrJNwZiDDGjrEZUMQf <= ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.dVbqQOLNabUQwqcVwcAGKBYSCgRBA)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(xIqeRcukoSwvGtdsOAiqAPgfqSqEA.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		VUKdJvafCRhbfRHrJRTZsBsWVyFFA vUKdJvafCRhbfRHrJRTZsBsWVyFFA = new VUKdJvafCRhbfRHrJRTZsBsWVyFFA();
		vUKdJvafCRhbfRHrJRTZsBsWVyFFA.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		vUKdJvafCRhbfRHrJRTZsBsWVyFFA.KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_1;
		vUKdJvafCRhbfRHrJRTZsBsWVyFFA.PVigqAEexAbxPwnCdgXfBKBwFyDSA = P_2;
		if (qumTafanxrjKbDduWdypwIzXqmiP)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(vUKdJvafCRhbfRHrJRTZsBsWVyFFA.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void hZGQqfkCleotngNoRVwWiwgaxpqJ(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		LiRjkJibauCdNWrkigFpXYVFNMJG liRjkJibauCdNWrkigFpXYVFNMJG = new LiRjkJibauCdNWrkigFpXYVFNMJG();
		liRjkJibauCdNWrkigFpXYVFNMJG.tMUcuAfGGoFbaZBeDMMyJYJtxaOb = P_0;
		liRjkJibauCdNWrkigFpXYVFNMJG.oRajQOHwRbMrJNwZiDDGjrEZUMQf = P_2;
		liRjkJibauCdNWrkigFpXYVFNMJG.PVigqAEexAbxPwnCdgXfBKBwFyDSA = P_1;
		if (qumTafanxrjKbDduWdypwIzXqmiP && liRjkJibauCdNWrkigFpXYVFNMJG.oRajQOHwRbMrJNwZiDDGjrEZUMQf <= ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.dVbqQOLNabUQwqcVwcAGKBYSCgRBA)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(liRjkJibauCdNWrkigFpXYVFNMJG.rfLuzOpBIuyJNVbPPWMVcbAlYGhF);
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
	{
		if (qumTafanxrjKbDduWdypwIzXqmiP)
		{
			AList<IpkMfGzLSpWRhxHyUEplACxoHdFo>[] array = hhSNvMdnckGyPuExIGOwHcrdkEZq;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			TlJCOMFBCfmyamqEJGaHRKbaKSyrA();
		}
	}

	private void TlJCOMFBCfmyamqEJGaHRKbaKSyrA()
	{
		int num = 0;
		for (int i = 0; i < hhSNvMdnckGyPuExIGOwHcrdkEZq.Length; i++)
		{
			num += hhSNvMdnckGyPuExIGOwHcrdkEZq[i]._count;
		}
		SvUchSiwLtntKjNRdqNBkvIjahni = num;
	}
}
