using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class tPpCplvxCBpYIIbYhfvfnqNQfUM
{
	private class XtfCkoCSmENXbaIDieYsePQzMgqh
	{
		[Flags]
		private enum vyyYCJzEISMYANmPdNdkgzPXsFd : byte
		{
			xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
			kfviHmnknHjtKhFynmBizkJRzjFp = 1,
			CsOCJIsYJtGKmZGzDytjVkpkXWk = 2,
			LKNefDeIXFIZjINdmBytirdbEJbw = 4,
			AekzEfGJMGKquCUSjDaLVbywPrI = 8
		}

		private vyyYCJzEISMYANmPdNdkgzPXsFd rDXFGACXzNvmEuFurHYAqqwyQzh;

		private uint ZmwvjHETUPBPBWYxcVFSxqGcqkg;

		private bool IAPkqDUzQJdPHucoTqCGLiJSizt;

		public bool isActive => IAPkqDUzQJdPHucoTqCGLiJSizt;

		public ButtonStateFlags OzEITSYbvsjksHLvCKYLgBzVvWQ(bool P_0)
		{
			ButtonStateFlags buttonStateFlags = ButtonStateFlags.VgdbsUdbYtLLUhXvNBybiOERwsh;
			if (P_0)
			{
				if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.kfviHmnknHjtKhFynmBizkJRzjFp) != vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					buttonStateFlags |= ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa;
					if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.LKNefDeIXFIZjINdmBytirdbEJbw) == 0)
					{
						buttonStateFlags |= ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU;
					}
				}
				else if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.LKNefDeIXFIZjINdmBytirdbEJbw) != vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					buttonStateFlags |= ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj;
				}
			}
			else if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.CsOCJIsYJtGKmZGzDytjVkpkXWk) != vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				buttonStateFlags |= ButtonStateFlags.UplvurlztepPVkfDEPxOTCIsEIa;
				if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.AekzEfGJMGKquCUSjDaLVbywPrI) == 0)
				{
					buttonStateFlags |= ButtonStateFlags.ppYdXkDrMSlYvDAaCqFoehbWDwU;
				}
			}
			else if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.AekzEfGJMGKquCUSjDaLVbywPrI) != vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				buttonStateFlags |= ButtonStateFlags.UQGNyIlHcyEjlcCTeYUyHSUqsWj;
			}
			return buttonStateFlags;
		}

		public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
		{
			vyyYCJzEISMYANmPdNdkgzPXsFd vyyYCJzEISMYANmPdNdkgzPXsFd2 = vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun;
			if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.kfviHmnknHjtKhFynmBizkJRzjFp) != vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				vyyYCJzEISMYANmPdNdkgzPXsFd2 |= vyyYCJzEISMYANmPdNdkgzPXsFd.LKNefDeIXFIZjINdmBytirdbEJbw;
			}
			if ((rDXFGACXzNvmEuFurHYAqqwyQzh & vyyYCJzEISMYANmPdNdkgzPXsFd.CsOCJIsYJtGKmZGzDytjVkpkXWk) != vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun)
			{
				vyyYCJzEISMYANmPdNdkgzPXsFd2 |= vyyYCJzEISMYANmPdNdkgzPXsFd.AekzEfGJMGKquCUSjDaLVbywPrI;
			}
			rDXFGACXzNvmEuFurHYAqqwyQzh = vyyYCJzEISMYANmPdNdkgzPXsFd2;
		}

		public void AOQgnFcBlXraMNObOnRwRhydWuOc(uint P_0)
		{
			if (ZmwvjHETUPBPBWYxcVFSxqGcqkg < P_0 - 1)
			{
				IAPkqDUzQJdPHucoTqCGLiJSizt = false;
			}
		}

		public void YznpIQNoshMCFPANqaYGMzkecBZ(bool P_0)
		{
			if (P_0)
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh |= vyyYCJzEISMYANmPdNdkgzPXsFd.kfviHmnknHjtKhFynmBizkJRzjFp;
			}
			else
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh |= vyyYCJzEISMYANmPdNdkgzPXsFd.CsOCJIsYJtGKmZGzDytjVkpkXWk;
			}
			ZmwvjHETUPBPBWYxcVFSxqGcqkg = ReInput.currentFrame;
			if (!IAPkqDUzQJdPHucoTqCGLiJSizt)
			{
				IAPkqDUzQJdPHucoTqCGLiJSizt = true;
			}
		}

		public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			rDXFGACXzNvmEuFurHYAqqwyQzh = vyyYCJzEISMYANmPdNdkgzPXsFd.xHdBaRgdNDZThJOvnpmpFtvdLIun;
			ZmwvjHETUPBPBWYxcVFSxqGcqkg = 0u;
			IAPkqDUzQJdPHucoTqCGLiJSizt = false;
		}
	}

	private const int cNgqibYeRhksgXwzIPAyGToxBui = 20;

	private const int rtlBoaaYrwUDzQMhJaFSWAdYTsk = 10;

	private static ObjectPool<tPpCplvxCBpYIIbYhfvfnqNQfUM> GJTNwlFTaGorxveqWCyBtJqAPQf;

	private static tPpCplvxCBpYIIbYhfvfnqNQfUM[] EkYaNrMNmHBLAAblmUlSYneypEd;

	private static int JJwXInRjfqEOuwVlbOUpQiURaQp;

	public int TJhXbXRyMafXnwzQaaZHedOApjW;

	private UpdateLoopDataSet<XtfCkoCSmENXbaIDieYsePQzMgqh> ALzKzwEPPCnkjtevfNykduPJedu;

	[CompilerGenerated]
	private static Func<tPpCplvxCBpYIIbYhfvfnqNQfUM> aiXaKuCWRzBHdQrFqgBzyLzkAydQ;

	[CompilerGenerated]
	private static Action<tPpCplvxCBpYIIbYhfvfnqNQfUM> sPMAcpellUZLaqoZiORhMgRZWDu;

	[CompilerGenerated]
	private static Func<XtfCkoCSmENXbaIDieYsePQzMgqh> fqbZuOCzaGEtjRCXGpKkmkLnbRtb;

	public bool isActive
	{
		get
		{
			int count = ALzKzwEPPCnkjtevfNykduPJedu.Count;
			for (int i = 0; i < count; i++)
			{
				if (ALzKzwEPPCnkjtevfNykduPJedu[i].isActive)
				{
					return true;
				}
			}
			return false;
		}
	}

	static tPpCplvxCBpYIIbYhfvfnqNQfUM()
	{
		GJTNwlFTaGorxveqWCyBtJqAPQf = new ObjectPool<tPpCplvxCBpYIIbYhfvfnqNQfUM>(20, () => new tPpCplvxCBpYIIbYhfvfnqNQfUM(), delegate(tPpCplvxCBpYIIbYhfvfnqNQfUM P_0)
		{
			P_0.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		});
		EkYaNrMNmHBLAAblmUlSYneypEd = new tPpCplvxCBpYIIbYhfvfnqNQfUM[20];
	}

	public static void agvWMBoHtblzmgSmVloJbsDkfGk()
	{
		JJwXInRjfqEOuwVlbOUpQiURaQp = 0;
		Array.Clear(EkYaNrMNmHBLAAblmUlSYneypEd, 0, EkYaNrMNmHBLAAblmUlSYneypEd.Length);
	}

	public static tPpCplvxCBpYIIbYhfvfnqNQfUM asgosewYKyFTkMJESKHnECzoAhE(int P_0)
	{
		for (int i = 0; i < JJwXInRjfqEOuwVlbOUpQiURaQp; i++)
		{
			if (EkYaNrMNmHBLAAblmUlSYneypEd[i] != null && EkYaNrMNmHBLAAblmUlSYneypEd[i].TJhXbXRyMafXnwzQaaZHedOApjW == P_0)
			{
				return EkYaNrMNmHBLAAblmUlSYneypEd[i];
			}
		}
		return null;
	}

	public static tPpCplvxCBpYIIbYhfvfnqNQfUM tbTaqwCgVnCLKvHsvgjnjEDiwyz(int P_0)
	{
		tPpCplvxCBpYIIbYhfvfnqNQfUM tPpCplvxCBpYIIbYhfvfnqNQfUM2 = asgosewYKyFTkMJESKHnECzoAhE(P_0);
		if (tPpCplvxCBpYIIbYhfvfnqNQfUM2 != null)
		{
			return tPpCplvxCBpYIIbYhfvfnqNQfUM2;
		}
		tPpCplvxCBpYIIbYhfvfnqNQfUM2 = GJTNwlFTaGorxveqWCyBtJqAPQf.Get();
		tPpCplvxCBpYIIbYhfvfnqNQfUM2.RcfaEbycwVRZfrTukoZSsFIdNiG(P_0);
		tPpCplvxCBpYIIbYhfvfnqNQfUM2.ALzKzwEPPCnkjtevfNykduPJedu.SetUpdateLoop(ReInput.currentUpdateLoop);
		FdoZBcKiYccteZRenWkuQVQXlJa(tPpCplvxCBpYIIbYhfvfnqNQfUM2);
		return tPpCplvxCBpYIIbYhfvfnqNQfUM2;
	}

	public static void yKnlAOOxoakoftRymnrQvAIGfln(UpdateLoopType P_0)
	{
		for (int i = 0; i < JJwXInRjfqEOuwVlbOUpQiURaQp; i++)
		{
			if (EkYaNrMNmHBLAAblmUlSYneypEd[i] != null)
			{
				EkYaNrMNmHBLAAblmUlSYneypEd[i].iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
			}
		}
	}

	public static void AOQgnFcBlXraMNObOnRwRhydWuOc(UpdateLoopType P_0, uint P_1)
	{
		for (int num = JJwXInRjfqEOuwVlbOUpQiURaQp - 1; num >= 0; num--)
		{
			if (EkYaNrMNmHBLAAblmUlSYneypEd[num] == null)
			{
				if (num == JJwXInRjfqEOuwVlbOUpQiURaQp - 1)
				{
					JJwXInRjfqEOuwVlbOUpQiURaQp--;
				}
			}
			else
			{
				EkYaNrMNmHBLAAblmUlSYneypEd[num].AOQgnFcBlXraMNObOnRwRhydWuOc(P_1);
				if (!EkYaNrMNmHBLAAblmUlSYneypEd[num].isActive)
				{
					DFWhqqEAZceZxFTfkVLwkVCknuuj(num);
				}
			}
		}
	}

	private static void FdoZBcKiYccteZRenWkuQVQXlJa(tPpCplvxCBpYIIbYhfvfnqNQfUM P_0)
	{
		int num = BdIiXdRJvZJGaCgwvrcCQLPLrCZ();
		if (num < 0)
		{
			if (JJwXInRjfqEOuwVlbOUpQiURaQp == EkYaNrMNmHBLAAblmUlSYneypEd.Length)
			{
				tPpCplvxCBpYIIbYhfvfnqNQfUM[] ekYaNrMNmHBLAAblmUlSYneypEd = EkYaNrMNmHBLAAblmUlSYneypEd;
				EkYaNrMNmHBLAAblmUlSYneypEd = new tPpCplvxCBpYIIbYhfvfnqNQfUM[EkYaNrMNmHBLAAblmUlSYneypEd.Length + 10];
				Array.Copy(ekYaNrMNmHBLAAblmUlSYneypEd, EkYaNrMNmHBLAAblmUlSYneypEd, ekYaNrMNmHBLAAblmUlSYneypEd.Length);
			}
			num = JJwXInRjfqEOuwVlbOUpQiURaQp;
			JJwXInRjfqEOuwVlbOUpQiURaQp++;
		}
		EkYaNrMNmHBLAAblmUlSYneypEd[num] = P_0;
	}

	private static void DFWhqqEAZceZxFTfkVLwkVCknuuj(int P_0)
	{
		if (P_0 >= 0 && P_0 < JJwXInRjfqEOuwVlbOUpQiURaQp)
		{
			tPpCplvxCBpYIIbYhfvfnqNQfUM tPpCplvxCBpYIIbYhfvfnqNQfUM2 = EkYaNrMNmHBLAAblmUlSYneypEd[P_0];
			if (tPpCplvxCBpYIIbYhfvfnqNQfUM2 != null)
			{
				GJTNwlFTaGorxveqWCyBtJqAPQf.Return(tPpCplvxCBpYIIbYhfvfnqNQfUM2);
				EkYaNrMNmHBLAAblmUlSYneypEd[P_0] = null;
			}
			if (P_0 == JJwXInRjfqEOuwVlbOUpQiURaQp - 1)
			{
				JJwXInRjfqEOuwVlbOUpQiURaQp--;
			}
		}
	}

	private static int BdIiXdRJvZJGaCgwvrcCQLPLrCZ()
	{
		for (int i = 0; i < JJwXInRjfqEOuwVlbOUpQiURaQp; i++)
		{
			if (EkYaNrMNmHBLAAblmUlSYneypEd[i] == null)
			{
				return i;
			}
		}
		if (JJwXInRjfqEOuwVlbOUpQiURaQp >= EkYaNrMNmHBLAAblmUlSYneypEd.Length)
		{
			return -1;
		}
		int jJwXInRjfqEOuwVlbOUpQiURaQp = JJwXInRjfqEOuwVlbOUpQiURaQp;
		JJwXInRjfqEOuwVlbOUpQiURaQp++;
		return jJwXInRjfqEOuwVlbOUpQiURaQp;
	}

	public ButtonStateFlags OzEITSYbvsjksHLvCKYLgBzVvWQ(bool P_0)
	{
		return ALzKzwEPPCnkjtevfNykduPJedu.Current.OzEITSYbvsjksHLvCKYLgBzVvWQ(P_0);
	}

	public tPpCplvxCBpYIIbYhfvfnqNQfUM()
	{
		ALzKzwEPPCnkjtevfNykduPJedu = new UpdateLoopDataSet<XtfCkoCSmENXbaIDieYsePQzMgqh>(ReInput.UserData.ConfigVars.updateLoop, () => new XtfCkoCSmENXbaIDieYsePQzMgqh());
		VcHhfbFqwxAmqhwBHKVJpDjlfufe();
	}

	public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
	{
		ALzKzwEPPCnkjtevfNykduPJedu.SetUpdateLoop(P_0);
		ALzKzwEPPCnkjtevfNykduPJedu.Current.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
	}

	public void AOQgnFcBlXraMNObOnRwRhydWuOc(uint P_0)
	{
		ALzKzwEPPCnkjtevfNykduPJedu.Current.AOQgnFcBlXraMNObOnRwRhydWuOc(P_0);
	}

	public void YznpIQNoshMCFPANqaYGMzkecBZ(UpdateLoopType P_0, bool P_1)
	{
		ALzKzwEPPCnkjtevfNykduPJedu.Current.YznpIQNoshMCFPANqaYGMzkecBZ(P_1);
	}

	private void RcfaEbycwVRZfrTukoZSsFIdNiG(int P_0)
	{
		TJhXbXRyMafXnwzQaaZHedOApjW = P_0;
	}

	private void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
	{
		TJhXbXRyMafXnwzQaaZHedOApjW = -1;
		for (int i = 0; i < ALzKzwEPPCnkjtevfNykduPJedu.Count; i++)
		{
			ALzKzwEPPCnkjtevfNykduPJedu[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
	}

	[CompilerGenerated]
	private static tPpCplvxCBpYIIbYhfvfnqNQfUM aQJtWCpXsmcYuAFtjnTSDEYBTuQ()
	{
		return new tPpCplvxCBpYIIbYhfvfnqNQfUM();
	}

	[CompilerGenerated]
	private static void ZIJfrJcplnovQTGcTWakaunoYie(tPpCplvxCBpYIIbYhfvfnqNQfUM P_0)
	{
		P_0.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
	}

	[CompilerGenerated]
	private static XtfCkoCSmENXbaIDieYsePQzMgqh sssQhakJqIyRgpjLbjipiZMtjDg()
	{
		return new XtfCkoCSmENXbaIDieYsePQzMgqh();
	}
}
