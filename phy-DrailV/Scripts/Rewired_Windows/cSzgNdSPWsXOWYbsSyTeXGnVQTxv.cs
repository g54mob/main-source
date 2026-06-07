using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;

internal abstract class cSzgNdSPWsXOWYbsSyTeXGnVQTxv : YszNVDBZreQueMHaxAPTEUkXgqRz
{
	internal abstract class nQhciUzXdTqxtyrcwLcDDRzxcNdk
	{
		private int gfcHeeeVicQbjUegVbXZZdwsqusJ;

		private int[] HKnATvDgtkRPjMwnkZnolTqKuJDz;

		protected ZirEdAMKfgjqovtnBVQNMbFyiXxCA[] EFpHrsFLouNlEgYqRjLITLMXDVui;

		public ZirEdAMKfgjqovtnBVQNMbFyiXxCA BkOPFuJPuwwYFxfFTaZXlqNCSHtU;

		private int tENHSFfcOMgrcuruSYsGqpcnouDL;

		private int rvcCFygLbHLWnBuRjNywrQKtGMOcA = -1;

		private bool qcODuIRkFCERlUpWWjyXkIXUkDfY;

		protected int qrrIvanBVQxdaeCgFSVlKCmJPqGi => gfcHeeeVicQbjUegVbXZZdwsqusJ;

		protected int[] iPHubLhYjLNMPmTWQCUzjmYbIriK => HKnATvDgtkRPjMwnkZnolTqKuJDz;

		public UpdateLoopType WHDTzYTojOwKfxiTarplhaTxVeNq
		{
			set
			{
				if (rvcCFygLbHLWnBuRjNywrQKtGMOcA != (int)updateLoopType)
				{
					rvcCFygLbHLWnBuRjNywrQKtGMOcA = (int)updateLoopType;
					tENHSFfcOMgrcuruSYsGqpcnouDL = HKnATvDgtkRPjMwnkZnolTqKuJDz[(int)updateLoopType];
					BkOPFuJPuwwYFxfFTaZXlqNCSHtU = EFpHrsFLouNlEgYqRjLITLMXDVui[tENHSFfcOMgrcuruSYsGqpcnouDL];
				}
			}
		}

		public nQhciUzXdTqxtyrcwLcDDRzxcNdk()
		{
		}

		public void qMWksQEqmcasrkaUqJAdGQoioDgg(UpdateLoopSetting P_0, Func<UpdateLoopType, ZirEdAMKfgjqovtnBVQNMbFyiXxCA> P_1)
		{
			if (qcODuIRkFCERlUpWWjyXkIXUkDfY)
			{
				Logger.LogError("Already initialized!");
				return;
			}
			HKnATvDgtkRPjMwnkZnolTqKuJDz = new int[3];
			gfcHeeeVicQbjUegVbXZZdwsqusJ = 0;
			List<ZirEdAMKfgjqovtnBVQNMbFyiXxCA> list = new List<ZirEdAMKfgjqovtnBVQNMbFyiXxCA>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list2 = tList.list;
				EnumConverter.ToUpdateLoopTypes(P_0, list2);
				for (int i = 0; i < list2.Count; i++)
				{
					HKnATvDgtkRPjMwnkZnolTqKuJDz[(int)list2[i]] = gfcHeeeVicQbjUegVbXZZdwsqusJ;
					gfcHeeeVicQbjUegVbXZZdwsqusJ++;
					list.Add(P_1(list2[i]));
				}
			}
			EFpHrsFLouNlEgYqRjLITLMXDVui = list.ToArray();
			BkOPFuJPuwwYFxfFTaZXlqNCSHtU = EFpHrsFLouNlEgYqRjLITLMXDVui[0];
			qcODuIRkFCERlUpWWjyXkIXUkDfY = true;
		}

		private void NwafWjKVCDaLOJZvYJuBjPyNWxsK(UpdateLoopType P_0, ZirEdAMKfgjqovtnBVQNMbFyiXxCA P_1)
		{
			EFpHrsFLouNlEgYqRjLITLMXDVui[HKnATvDgtkRPjMwnkZnolTqKuJDz[(int)P_0]] = P_1;
		}

		public virtual void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
		{
			if (rvcCFygLbHLWnBuRjNywrQKtGMOcA != (int)P_0)
			{
				WHDTzYTojOwKfxiTarplhaTxVeNq = P_0;
			}
		}

		public void sbvNiOKcscCGRBGGcMbdhHrjtptuB()
		{
			for (int i = 0; i < gfcHeeeVicQbjUegVbXZZdwsqusJ; i++)
			{
				EFpHrsFLouNlEgYqRjLITLMXDVui[i].sbvNiOKcscCGRBGGcMbdhHrjtptuB();
			}
		}
	}

	internal abstract class ZirEdAMKfgjqovtnBVQNMbFyiXxCA
	{
		public readonly UpdateLoopType WHDTzYTojOwKfxiTarplhaTxVeNq;

		public ZirEdAMKfgjqovtnBVQNMbFyiXxCA(UpdateLoopType P_0)
		{
			WHDTzYTojOwKfxiTarplhaTxVeNq = P_0;
		}

		public abstract void sbvNiOKcscCGRBGGcMbdhHrjtptuB();
	}

	internal nQhciUzXdTqxtyrcwLcDDRzxcNdk xSxdXdIXGcMohhPTuDvIiQULhHADb;

	public cSzgNdSPWsXOWYbsSyTeXGnVQTxv(nQhciUzXdTqxtyrcwLcDDRzxcNdk P_0, byte P_1, HIDInfo P_2)
		: base(P_1, P_2)
	{
		xSxdXdIXGcMohhPTuDvIiQULhHADb = P_0;
	}

	public virtual void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
	{
		if (xSxdXdIXGcMohhPTuDvIiQULhHADb != null)
		{
			xSxdXdIXGcMohhPTuDvIiQULhHADb.mefhGqvTkcrETnFSidhNngFjAYNV(P_0);
		}
	}
}
