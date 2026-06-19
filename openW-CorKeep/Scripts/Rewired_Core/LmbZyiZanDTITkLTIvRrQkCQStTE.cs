using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class LmbZyiZanDTITkLTIvRrQkCQStTE
{
	private class QCbXfkdwmSOqpCILeIPRdaerRrEBb
	{
		private ButtonStateFlags PGIsFfumrNrAaFZSpaGrnsqgBlIC;

		private ButtonStateFlags OwdmzLCPymJGaBHVXhqaVGpJJWoG;

		private ButtonStateFlags IOVuyjFOplbEJnTHthPijpepOWKF;

		private ButtonStateFlags IonRZznbmmqBVcTXJgOHSkiaYIgf;

		private uint ejakMocHvGeoamVvkbfDsGwCekJDA;

		private bool xdztBEZhzctfhHcfqufzSqesViFr;

		private bool KYlhadNjpIyCyajevGjrqMdyhybZ;

		private bool FoFGSCiUCfhRSmzslqpRLGcbByyA;

		private dSdTKXzdENEWRSzPVakhhpAkhxqd mIpJBFUjQPGAgtvTslCuMUquKHas;

		public bool eIKVWhHjINqBVsogHuDggnxkIKCn => xdztBEZhzctfhHcfqufzSqesViFr;

		public bool zInyCOexQFGEYSZVOXPTqcYWByDT
		{
			get
			{
				return KYlhadNjpIyCyajevGjrqMdyhybZ;
			}
			set
			{
				KYlhadNjpIyCyajevGjrqMdyhybZ = kYlhadNjpIyCyajevGjrqMdyhybZ;
			}
		}

		public ButtonStateFlags YbbTiAgmxRdAofNtjBRCSepqjPtd(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (PGIsFfumrNrAaFZSpaGrnsqgBlIC & ButtonStateFlags.On) != 0;
				flag2 = (OwdmzLCPymJGaBHVXhqaVGpJJWoG & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!KYlhadNjpIyCyajevGjrqMdyhybZ) ? PGIsFfumrNrAaFZSpaGrnsqgBlIC : ButtonStateFlags.Off);
			}
			else
			{
				flag = (IOVuyjFOplbEJnTHthPijpepOWKF & ButtonStateFlags.On) != 0;
				flag2 = (IonRZznbmmqBVcTXJgOHSkiaYIgf & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!KYlhadNjpIyCyajevGjrqMdyhybZ) ? IOVuyjFOplbEJnTHthPijpepOWKF : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (KYlhadNjpIyCyajevGjrqMdyhybZ)
				{
					if (flag2 && !FoFGSCiUCfhRSmzslqpRLGcbByyA && mIpJBFUjQPGAgtvTslCuMUquKHas.NxgOmvPpJKbZWTyuwLljHSiKSAVp)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (FoFGSCiUCfhRSmzslqpRLGcbByyA && mIpJBFUjQPGAgtvTslCuMUquKHas.NxgOmvPpJKbZWTyuwLljHSiKSAVp)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !KYlhadNjpIyCyajevGjrqMdyhybZ && !FoFGSCiUCfhRSmzslqpRLGcbByyA)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void TNzhOZpWvpmNpPJQBgMHHHVImOAm()
		{
			OwdmzLCPymJGaBHVXhqaVGpJJWoG = PGIsFfumrNrAaFZSpaGrnsqgBlIC;
			IonRZznbmmqBVcTXJgOHSkiaYIgf = IOVuyjFOplbEJnTHthPijpepOWKF;
			FoFGSCiUCfhRSmzslqpRLGcbByyA = KYlhadNjpIyCyajevGjrqMdyhybZ;
			PGIsFfumrNrAaFZSpaGrnsqgBlIC = ButtonStateFlags.Off;
			IOVuyjFOplbEJnTHthPijpepOWKF = ButtonStateFlags.Off;
		}

		public void DVwsrwoEuVefFSzpxePcMIYrcWPf(uint P_0)
		{
			if (ejakMocHvGeoamVvkbfDsGwCekJDA < P_0 - 1)
			{
				xdztBEZhzctfhHcfqufzSqesViFr = false;
			}
		}

		public void xIwrlAyATOgPaCffBABjHBjKXozKB(bool P_0)
		{
			eQOhuTqrMjEZjghXBmGjXSruHnuC((P_0 ? PGIsFfumrNrAaFZSpaGrnsqgBlIC : IOVuyjFOplbEJnTHthPijpepOWKF) | ButtonStateFlags.On, P_0);
		}

		public void eQOhuTqrMjEZjghXBmGjXSruHnuC(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				PGIsFfumrNrAaFZSpaGrnsqgBlIC = P_0;
			}
			else
			{
				IOVuyjFOplbEJnTHthPijpepOWKF = P_0;
			}
			ejakMocHvGeoamVvkbfDsGwCekJDA = ReInput.currentFrame;
			if (!xdztBEZhzctfhHcfqufzSqesViFr)
			{
				xdztBEZhzctfhHcfqufzSqesViFr = true;
			}
		}

		public void TKgSucTBXdnOiHLHNVaegcNyyTck(ref dSdTKXzdENEWRSzPVakhhpAkhxqd P_0)
		{
			mIpJBFUjQPGAgtvTslCuMUquKHas = P_0;
			KYlhadNjpIyCyajevGjrqMdyhybZ = P_0.KCsvGRHbJTEhzXDIhcNwvApOjOff;
			FoFGSCiUCfhRSmzslqpRLGcbByyA = P_0.KCsvGRHbJTEhzXDIhcNwvApOjOff;
		}

		public void VKwdqcsbAIXTmkcogXnhvnuXdoV()
		{
			PGIsFfumrNrAaFZSpaGrnsqgBlIC = ButtonStateFlags.Off;
			OwdmzLCPymJGaBHVXhqaVGpJJWoG = ButtonStateFlags.Off;
			IOVuyjFOplbEJnTHthPijpepOWKF = ButtonStateFlags.Off;
			IonRZznbmmqBVcTXJgOHSkiaYIgf = ButtonStateFlags.Off;
			ejakMocHvGeoamVvkbfDsGwCekJDA = 0u;
			xdztBEZhzctfhHcfqufzSqesViFr = false;
			KYlhadNjpIyCyajevGjrqMdyhybZ = false;
			FoFGSCiUCfhRSmzslqpRLGcbByyA = false;
		}
	}

	public struct dSdTKXzdENEWRSzPVakhhpAkhxqd
	{
		public bool NxgOmvPpJKbZWTyuwLljHSiKSAVp;

		public bool KCsvGRHbJTEhzXDIhcNwvApOjOff;

		public static dSdTKXzdENEWRSzPVakhhpAkhxqd iRZlDnforWzPQjaHQcllrpUxNuUF => default(dSdTKXzdENEWRSzPVakhhpAkhxqd);
	}

	[Serializable]
	private sealed class BQxJQUrWKJvFxzCugkYhMEVuYnuh
	{
		public static readonly BQxJQUrWKJvFxzCugkYhMEVuYnuh _003C_003E9 = new BQxJQUrWKJvFxzCugkYhMEVuYnuh();

		public static Func<QCbXfkdwmSOqpCILeIPRdaerRrEBb> _003C_003E9__22_0;

		internal LmbZyiZanDTITkLTIvRrQkCQStTE LnXnCXaPBpfgTbuxbjzzuMTSelzCA()
		{
			return new LmbZyiZanDTITkLTIvRrQkCQStTE();
		}

		internal void dtuGnyDcMCJLyqkzdGXgHJGQzIdwA(LmbZyiZanDTITkLTIvRrQkCQStTE P_0)
		{
			P_0.MHIwFQiJiFnfmoPzsbCPbeIcJRHB();
		}

		internal QCbXfkdwmSOqpCILeIPRdaerRrEBb cxxVKBMspVVYNRARKutlXOUnMYOR()
		{
			return new QCbXfkdwmSOqpCILeIPRdaerRrEBb();
		}
	}

	private const int wanHjJjfWkEamqmkhDpGkACeXwjaA = 20;

	private const int TgGndTQNuInWYZCMfxvAVHfFVmuE = 10;

	private static ObjectPool<LmbZyiZanDTITkLTIvRrQkCQStTE> atcrjMYEgtGofbhWHivKCkVREQjY;

	private static LmbZyiZanDTITkLTIvRrQkCQStTE[] qfAsFYBtxXIPLvbYwYwpxoQHgXKO;

	private static int lRghlwMWYImKxAuJZPErdFEMGdDaA;

	public int XAhiaVdohPYvcICUrKgBdISLGHlm;

	private UpdateLoopDataSet<QCbXfkdwmSOqpCILeIPRdaerRrEBb> qeXslMHhvSUFLOglnXSdaShlHozy;

	public bool eFFDNfatEKJMHYmGFlSGISHaGZbA
	{
		get
		{
			int count = qeXslMHhvSUFLOglnXSdaShlHozy.Count;
			for (int i = 0; i < count; i++)
			{
				if (qeXslMHhvSUFLOglnXSdaShlHozy[i].eIKVWhHjINqBVsogHuDggnxkIKCn)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool baiqmtnJZuucePgsbULscEmsutFM
	{
		get
		{
			return qeXslMHhvSUFLOglnXSdaShlHozy.Current.zInyCOexQFGEYSZVOXPTqcYWByDT;
		}
		set
		{
			qeXslMHhvSUFLOglnXSdaShlHozy.Current.zInyCOexQFGEYSZVOXPTqcYWByDT = flag;
		}
	}

	static LmbZyiZanDTITkLTIvRrQkCQStTE()
	{
		atcrjMYEgtGofbhWHivKCkVREQjY = new ObjectPool<LmbZyiZanDTITkLTIvRrQkCQStTE>(20, BQxJQUrWKJvFxzCugkYhMEVuYnuh._003C_003E9.LnXnCXaPBpfgTbuxbjzzuMTSelzCA, BQxJQUrWKJvFxzCugkYhMEVuYnuh._003C_003E9.dtuGnyDcMCJLyqkzdGXgHJGQzIdwA);
		qfAsFYBtxXIPLvbYwYwpxoQHgXKO = new LmbZyiZanDTITkLTIvRrQkCQStTE[20];
	}

	public static void NiGBeDwrLfxeKBuYRdGuDRAXOrqy()
	{
		lRghlwMWYImKxAuJZPErdFEMGdDaA = 0;
		Array.Clear(qfAsFYBtxXIPLvbYwYwpxoQHgXKO, 0, qfAsFYBtxXIPLvbYwYwpxoQHgXKO.Length);
		atcrjMYEgtGofbhWHivKCkVREQjY.Clear();
	}

	public static LmbZyiZanDTITkLTIvRrQkCQStTE kuiFofPMNSBCeimWMzARbIPboSrx(int P_0)
	{
		for (int i = 0; i < lRghlwMWYImKxAuJZPErdFEMGdDaA; i++)
		{
			if (qfAsFYBtxXIPLvbYwYwpxoQHgXKO[i] != null && qfAsFYBtxXIPLvbYwYwpxoQHgXKO[i].XAhiaVdohPYvcICUrKgBdISLGHlm == P_0)
			{
				return qfAsFYBtxXIPLvbYwYwpxoQHgXKO[i];
			}
		}
		return null;
	}

	public static LmbZyiZanDTITkLTIvRrQkCQStTE MGgmfOQoelfGRCJFFnkrUlmxyPEI(int P_0, dSdTKXzdENEWRSzPVakhhpAkhxqd P_1)
	{
		LmbZyiZanDTITkLTIvRrQkCQStTE lmbZyiZanDTITkLTIvRrQkCQStTE = kuiFofPMNSBCeimWMzARbIPboSrx(P_0);
		if (lmbZyiZanDTITkLTIvRrQkCQStTE != null)
		{
			return lmbZyiZanDTITkLTIvRrQkCQStTE;
		}
		lmbZyiZanDTITkLTIvRrQkCQStTE = atcrjMYEgtGofbhWHivKCkVREQjY.Get();
		lmbZyiZanDTITkLTIvRrQkCQStTE.ADWJMWZTzVsUlWHmiAsBSQlUWkQF(P_0);
		lmbZyiZanDTITkLTIvRrQkCQStTE.giQhMiXzmNvxfsvBJScXXYdXsxbD(ref P_1);
		lmbZyiZanDTITkLTIvRrQkCQStTE.qeXslMHhvSUFLOglnXSdaShlHozy.SetUpdateLoop(ReInput.currentUpdateLoop);
		hNjPBXOLqizukeyMhhwLEtqAfeNB(lmbZyiZanDTITkLTIvRrQkCQStTE);
		return lmbZyiZanDTITkLTIvRrQkCQStTE;
	}

	public static void EFLBiUbVOEdtezRPfcMKgkraamrIA(UpdateLoopType P_0)
	{
		for (int i = 0; i < lRghlwMWYImKxAuJZPErdFEMGdDaA; i++)
		{
			if (qfAsFYBtxXIPLvbYwYwpxoQHgXKO[i] != null)
			{
				qfAsFYBtxXIPLvbYwYwpxoQHgXKO[i].XnvecNWvNSRolNvwnJlmMwyVrhdd(P_0);
			}
		}
	}

	public static void KJqXauMWCZgOKHpeevLFLBsbtEex(UpdateLoopType P_0, uint P_1)
	{
		for (int num = lRghlwMWYImKxAuJZPErdFEMGdDaA - 1; num >= 0; num--)
		{
			if (qfAsFYBtxXIPLvbYwYwpxoQHgXKO[num] == null)
			{
				if (num == lRghlwMWYImKxAuJZPErdFEMGdDaA - 1)
				{
					lRghlwMWYImKxAuJZPErdFEMGdDaA--;
				}
			}
			else
			{
				qfAsFYBtxXIPLvbYwYwpxoQHgXKO[num].fyaRZDXMFIscveBFMgHdVrtpxhZT(P_1);
				if (!qfAsFYBtxXIPLvbYwYwpxoQHgXKO[num].eFFDNfatEKJMHYmGFlSGISHaGZbA)
				{
					sIHZLukbNDjhexDvkyYhecBGEelX(num);
				}
			}
		}
	}

	private static void hNjPBXOLqizukeyMhhwLEtqAfeNB(LmbZyiZanDTITkLTIvRrQkCQStTE P_0)
	{
		int num = CohFFhhnWJsawfgCKhjIBqRplslYA();
		if (num < 0)
		{
			if (lRghlwMWYImKxAuJZPErdFEMGdDaA == qfAsFYBtxXIPLvbYwYwpxoQHgXKO.Length)
			{
				LmbZyiZanDTITkLTIvRrQkCQStTE[] array = qfAsFYBtxXIPLvbYwYwpxoQHgXKO;
				qfAsFYBtxXIPLvbYwYwpxoQHgXKO = new LmbZyiZanDTITkLTIvRrQkCQStTE[qfAsFYBtxXIPLvbYwYwpxoQHgXKO.Length + 10];
				Array.Copy(array, qfAsFYBtxXIPLvbYwYwpxoQHgXKO, array.Length);
			}
			num = lRghlwMWYImKxAuJZPErdFEMGdDaA;
			lRghlwMWYImKxAuJZPErdFEMGdDaA++;
		}
		qfAsFYBtxXIPLvbYwYwpxoQHgXKO[num] = P_0;
	}

	private static void sIHZLukbNDjhexDvkyYhecBGEelX(int P_0)
	{
		if (P_0 >= 0 && P_0 < lRghlwMWYImKxAuJZPErdFEMGdDaA)
		{
			LmbZyiZanDTITkLTIvRrQkCQStTE lmbZyiZanDTITkLTIvRrQkCQStTE = qfAsFYBtxXIPLvbYwYwpxoQHgXKO[P_0];
			if (lmbZyiZanDTITkLTIvRrQkCQStTE != null)
			{
				atcrjMYEgtGofbhWHivKCkVREQjY.Return(lmbZyiZanDTITkLTIvRrQkCQStTE);
				qfAsFYBtxXIPLvbYwYwpxoQHgXKO[P_0] = null;
			}
			if (P_0 == lRghlwMWYImKxAuJZPErdFEMGdDaA - 1)
			{
				lRghlwMWYImKxAuJZPErdFEMGdDaA--;
			}
		}
	}

	private static int CohFFhhnWJsawfgCKhjIBqRplslYA()
	{
		for (int i = 0; i < lRghlwMWYImKxAuJZPErdFEMGdDaA; i++)
		{
			if (qfAsFYBtxXIPLvbYwYwpxoQHgXKO[i] == null)
			{
				return i;
			}
		}
		if (lRghlwMWYImKxAuJZPErdFEMGdDaA >= qfAsFYBtxXIPLvbYwYwpxoQHgXKO.Length)
		{
			return -1;
		}
		int result = lRghlwMWYImKxAuJZPErdFEMGdDaA;
		lRghlwMWYImKxAuJZPErdFEMGdDaA++;
		return result;
	}

	public ButtonStateFlags ktBEPUHkcSRpUmxYaVcImmYXEIrb(bool P_0)
	{
		return qeXslMHhvSUFLOglnXSdaShlHozy.Current.YbbTiAgmxRdAofNtjBRCSepqjPtd(P_0);
	}

	public LmbZyiZanDTITkLTIvRrQkCQStTE()
	{
		qeXslMHhvSUFLOglnXSdaShlHozy = new UpdateLoopDataSet<QCbXfkdwmSOqpCILeIPRdaerRrEBb>(ReInput.UserData.ConfigVars.updateLoop, BQxJQUrWKJvFxzCugkYhMEVuYnuh._003C_003E9.cxxVKBMspVVYNRARKutlXOUnMYOR);
		MHIwFQiJiFnfmoPzsbCPbeIcJRHB();
	}

	public void XnvecNWvNSRolNvwnJlmMwyVrhdd(UpdateLoopType P_0)
	{
		qeXslMHhvSUFLOglnXSdaShlHozy.SetUpdateLoop(P_0);
		qeXslMHhvSUFLOglnXSdaShlHozy.Current.TNzhOZpWvpmNpPJQBgMHHHVImOAm();
	}

	public void fyaRZDXMFIscveBFMgHdVrtpxhZT(uint P_0)
	{
		qeXslMHhvSUFLOglnXSdaShlHozy.Current.DVwsrwoEuVefFSzpxePcMIYrcWPf(P_0);
	}

	public void LQtbJusstBtSQuMzIeSWcAFkJLLl(UpdateLoopType P_0, bool P_1)
	{
		qeXslMHhvSUFLOglnXSdaShlHozy.Current.xIwrlAyATOgPaCffBABjHBjKXozKB(P_1);
	}

	public void UTmaJkgcZCxZvoGDLjQQoiyPdShtA(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		qeXslMHhvSUFLOglnXSdaShlHozy.Current.eQOhuTqrMjEZjghXBmGjXSruHnuC(P_1, P_2);
	}

	private void giQhMiXzmNvxfsvBJScXXYdXsxbD(ref dSdTKXzdENEWRSzPVakhhpAkhxqd P_0)
	{
		int count = qeXslMHhvSUFLOglnXSdaShlHozy.Count;
		for (int i = 0; i < count; i++)
		{
			qeXslMHhvSUFLOglnXSdaShlHozy[i].TKgSucTBXdnOiHLHNVaegcNyyTck(ref P_0);
		}
	}

	private void ADWJMWZTzVsUlWHmiAsBSQlUWkQF(int P_0)
	{
		XAhiaVdohPYvcICUrKgBdISLGHlm = P_0;
	}

	private void MHIwFQiJiFnfmoPzsbCPbeIcJRHB()
	{
		XAhiaVdohPYvcICUrKgBdISLGHlm = -1;
		int count = qeXslMHhvSUFLOglnXSdaShlHozy.Count;
		for (int i = 0; i < count; i++)
		{
			qeXslMHhvSUFLOglnXSdaShlHozy[i].VKwdqcsbAIXTmkcogXnhvnuXdoV();
		}
	}
}
