using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class FKYcPWNUMoAdbCrNqFTAyfwrptpl : IDisposable
{
	private abstract class YXUUnCVISPFzVbfPQoDEmOlrfkEh : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool MARFhFcjsPykPWLssrGBVFTwKosjb;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return MARFhFcjsPykPWLssrGBVFTwKosjb;
			}
			[CompilerGenerated]
			set
			{
				MARFhFcjsPykPWLssrGBVFTwKosjb = value;
			}
		}

		protected abstract void Clear();

		void IPoolableObject_Internal.Clear()
		{
			Clear();
		}

		void IDisposable.Dispose()
		{
			Return();
		}

		public void Return()
		{
			((IPoolableObject_Internal)this).pool?.Return(this);
		}

		void IPoolableObject.Return()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Return
			this.Return();
		}
	}

	private class bDhqYXAKMGOBwieTMlRJRVFkmpvB : YXUUnCVISPFzVbfPQoDEmOlrfkEh
	{
		public IjjaNsTYgyWsWoGkfrdEwXNhabgW YISokesrZjvRXWXmyooCeYrSOXIs;

		public xJtjLRloAVFCKIkNGERFcJigdCiZ FUrFrAIfgIBGlfHTqCZAjpHOuLQBA;

		public double pTkAbfaVOqatbAkDijHwmFyoKQkK;

		protected virtual void hBOLWxlHHmDncZCwMBJEAhvluYfKA()
		{
			YISokesrZjvRXWXmyooCeYrSOXIs = null;
			FUrFrAIfgIBGlfHTqCZAjpHOuLQBA = default(xJtjLRloAVFCKIkNGERFcJigdCiZ);
			pTkAbfaVOqatbAkDijHwmFyoKQkK = 0.0;
		}
	}

	private sealed class LlMtwYyPMjdYMAIZfiXNtbsqkPaM : YXUUnCVISPFzVbfPQoDEmOlrfkEh
	{
		public IjjaNsTYgyWsWoGkfrdEwXNhabgW JsTdkMenDqYuDTGmUYPtCgURAQNi;

		public auQfmzpEFzGLnDtXtfBaakWheNKY PzbacCnruPaVqchdCteHjnuifwiMb;

		protected void vXrgwhdwNdCUptyAFcHDpunhJDdI()
		{
			JsTdkMenDqYuDTGmUYPtCgURAQNi = null;
			PzbacCnruPaVqchdCteHjnuifwiMb = default(auQfmzpEFzGLnDtXtfBaakWheNKY);
		}
	}

	[Serializable]
	private sealed class OpkdPVcdiLgDFxaXirKAXRAsGQfBA
	{
		public static readonly OpkdPVcdiLgDFxaXirKAXRAsGQfBA _003C_003E9 = new OpkdPVcdiLgDFxaXirKAXRAsGQfBA();

		public static Func<bDhqYXAKMGOBwieTMlRJRVFkmpvB> _003C_003E9__19_0;

		public static Func<LlMtwYyPMjdYMAIZfiXNtbsqkPaM> _003C_003E9__19_1;

		internal bDhqYXAKMGOBwieTMlRJRVFkmpvB lvHALXennMPJrabSOrFvbCtbDWuxB()
		{
			return new bDhqYXAKMGOBwieTMlRJRVFkmpvB();
		}

		internal LlMtwYyPMjdYMAIZfiXNtbsqkPaM yNFeCLKpvJEyiEkdtCNZczEBLxccB()
		{
			return new LlMtwYyPMjdYMAIZfiXNtbsqkPaM();
		}
	}

	private readonly List<tNoWbaKqbSUoLubXNGsZYacBCvle> NKaFObvSTexhPbKmzKkWREDeboiiA;

	private readonly ReadOnlyCollection<tNoWbaKqbSUoLubXNGsZYacBCvle> PMUeiDpdIeVBHzwGOFLsCVZHjpvq;

	private readonly List<IjjaNsTYgyWsWoGkfrdEwXNhabgW> cYHGZqJhbbxuxXvUiRiLqtazIJSx;

	private readonly Func<int> BqsGsACvMCjkdlVaYxRuxjWyZXCg;

	private readonly Rewired.Utils.Classes.Utility.SpinLock iGRkIlwMRegWvmSPCwmxGHhPoPOX = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock DjAqDErBIWLSrfObhHDHBctjbcAMA = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<bDhqYXAKMGOBwieTMlRJRVFkmpvB> BAMvhiyCSvVRUwfKdFtJStWvPrjI;

	private RingBuffer<LlMtwYyPMjdYMAIZfiXNtbsqkPaM> ueinyejLnfgfLygwUrPPPWXEbpro;

	private bool FsonfjyHziovFjMuSrvrijBXqcNw;

	private readonly ThreadSafeObjectPool<bDhqYXAKMGOBwieTMlRJRVFkmpvB> CJdggygVHLNOqjDaJrMGjqSlFgWmc;

	private readonly ThreadSafeObjectPool<LlMtwYyPMjdYMAIZfiXNtbsqkPaM> KGTDswPAIGIHEjSaELtAKAlxoHHLA;

	private readonly List<tNoWbaKqbSUoLubXNGsZYacBCvle> SDFUZWjNSQacAvbEjHsrgYsebDxS;

	private RingBuffer<bDhqYXAKMGOBwieTMlRJRVFkmpvB> kiNzMfwNyJojUsOVrENugEEkIfxfA;

	private RingBuffer<LlMtwYyPMjdYMAIZfiXNtbsqkPaM> ZvgaWHiFukcbnSXEZmTBuytqftqu;

	private bool ZNDqCBSFeQcaLSYuXjjLXyVrGPMV;

	private Action<IjjaNsTYgyWsWoGkfrdEwXNhabgW, auQfmzpEFzGLnDtXtfBaakWheNKY> SyGbsFabduSDAUtyjexlWTdEWmXc;

	[CompilerGenerated]
	private Action m_eOyuNlqrvarnRFeQhCNWPQZDCbKz;

	private bool FRHjTcMBCiffsFQIvCfKeTNilUlnA;

	private static Guid[] nHdJOAUYErlVqoUTzXLQVmrkyNyf;

	private static string[] OPsueuPUcKpoEKXApKBzUDnZDKcv;

	private static string[] ITpbJqKyFEVJyECXlQtLIpRqGRFjA;

	public event Action eOyuNlqrvarnRFeQhCNWPQZDCbKz
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_eOyuNlqrvarnRFeQhCNWPQZDCbKz;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_eOyuNlqrvarnRFeQhCNWPQZDCbKz, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_eOyuNlqrvarnRFeQhCNWPQZDCbKz;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_eOyuNlqrvarnRFeQhCNWPQZDCbKz, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public FKYcPWNUMoAdbCrNqFTAyfwrptpl(Func<int> P_0)
	{
		BqsGsACvMCjkdlVaYxRuxjWyZXCg = P_0;
		SyGbsFabduSDAUtyjexlWTdEWmXc = GxsUGIiEOPacysPggviGYZYLFWal;
		NKaFObvSTexhPbKmzKkWREDeboiiA = new List<tNoWbaKqbSUoLubXNGsZYacBCvle>();
		SDFUZWjNSQacAvbEjHsrgYsebDxS = new List<tNoWbaKqbSUoLubXNGsZYacBCvle>();
		PMUeiDpdIeVBHzwGOFLsCVZHjpvq = new ReadOnlyCollection<tNoWbaKqbSUoLubXNGsZYacBCvle>(NKaFObvSTexhPbKmzKkWREDeboiiA);
		cYHGZqJhbbxuxXvUiRiLqtazIJSx = new List<IjjaNsTYgyWsWoGkfrdEwXNhabgW>();
		FsonfjyHziovFjMuSrvrijBXqcNw = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)GGlKyqwtSRgaaWuZtxjwSYfoOckk.IxvjPdsczxfVuHMZdgPbDANUNliEb * 32f) + 1;
		CJdggygVHLNOqjDaJrMGjqSlFgWmc = new ThreadSafeObjectPool<bDhqYXAKMGOBwieTMlRJRVFkmpvB>(num, OpkdPVcdiLgDFxaXirKAXRAsGQfBA._003C_003E9.lvHALXennMPJrabSOrFvbCtbDWuxB);
		KGTDswPAIGIHEjSaELtAKAlxoHHLA = new ThreadSafeObjectPool<LlMtwYyPMjdYMAIZfiXNtbsqkPaM>(128, OpkdPVcdiLgDFxaXirKAXRAsGQfBA._003C_003E9.yNFeCLKpvJEyiEkdtCNZczEBLxccB);
		BAMvhiyCSvVRUwfKdFtJStWvPrjI = new RingBuffer<bDhqYXAKMGOBwieTMlRJRVFkmpvB>(num);
		ueinyejLnfgfLygwUrPPPWXEbpro = new RingBuffer<LlMtwYyPMjdYMAIZfiXNtbsqkPaM>(128);
		kiNzMfwNyJojUsOVrENugEEkIfxfA = new RingBuffer<bDhqYXAKMGOBwieTMlRJRVFkmpvB>(num);
		ZvgaWHiFukcbnSXEZmTBuytqftqu = new RingBuffer<LlMtwYyPMjdYMAIZfiXNtbsqkPaM>(128);
		IjjaNsTYgyWsWoGkfrdEwXNhabgW.quIaLTGKTunASUtobEYTTzVxvedeA += rcBWTtsOnGJNMqdyCZOffHRoKhrM;
		IjjaNsTYgyWsWoGkfrdEwXNhabgW.QsGFoMJhLxnSMTXfZEFDZnLKCPdqA += jaIdctfnEGWNrsuqqzGqciXjcYhIA;
		GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb.ThreadUpdateEvent += IuWinNSABJgQCaGoeUoxSolelmUbb;
		GGlKyqwtSRgaaWuZtxjwSYfoOckk.tRiPHogfXqTNFrlrzXWBLUlWuMgA.ThreadUpdateEvent += HEIWOidzMoRljhkciDTJbQghPwrYA;
		ReInput.ApplicationFocusChangedEvent += KjVrPwxBDfPRcKRxlVbqayPkwdHw;
		ReInput.ApplicationPauseChangedEvent += MCfcGbqNyjGzKNHMCsjkqDjbAqUg;
		IjjaNsTYgyWsWoGkfrdEwXNhabgW.LsJStnfEeuGTgcwloAIwbfyQHgSiA();
		dYNmvHLLZBboVNTSWIRvXlVyQeII();
	}

	public void qfyprJCmAqfTUvCTtIlbiCTvUnA()
	{
		bool flag = false;
		using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
		{
			if (ZNDqCBSFeQcaLSYuXjjLXyVrGPMV)
			{
				ZNDqCBSFeQcaLSYuXjjLXyVrGPMV = false;
				flag = true;
			}
		}
		if (flag)
		{
			dYNmvHLLZBboVNTSWIRvXlVyQeII();
		}
	}

	public void CNtdALddRwFMSkxkycUvcFKcZPAuB()
	{
		using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
		{
			MiscTools.Swap(ref BAMvhiyCSvVRUwfKdFtJStWvPrjI, ref kiNzMfwNyJojUsOVrENugEEkIfxfA);
		}
		while (BAMvhiyCSvVRUwfKdFtJStWvPrjI.Count > 0)
		{
			bDhqYXAKMGOBwieTMlRJRVFkmpvB bDhqYXAKMGOBwieTMlRJRVFkmpvB2 = BAMvhiyCSvVRUwfKdFtJStWvPrjI.Dequeue();
			int num = MniIMLWRJKmXcNyOHLJxPvuBPeRs(NKaFObvSTexhPbKmzKkWREDeboiiA, bDhqYXAKMGOBwieTMlRJRVFkmpvB2.YISokesrZjvRXWXmyooCeYrSOXIs);
			if (num >= 0)
			{
				NKaFObvSTexhPbKmzKkWREDeboiiA[num].AZKzwyLIwHDZSPMFUyQEKUobqtyd(bDhqYXAKMGOBwieTMlRJRVFkmpvB2.FUrFrAIfgIBGlfHTqCZAjpHOuLQBA, bDhqYXAKMGOBwieTMlRJRVFkmpvB2.pTkAbfaVOqatbAkDijHwmFyoKQkK);
			}
			bDhqYXAKMGOBwieTMlRJRVFkmpvB2.Return();
		}
	}

	private void GxsUGIiEOPacysPggviGYZYLFWal(IjjaNsTYgyWsWoGkfrdEwXNhabgW P_0, auQfmzpEFzGLnDtXtfBaakWheNKY P_1)
	{
		if (!FsonfjyHziovFjMuSrvrijBXqcNw)
		{
			return;
		}
		using (DjAqDErBIWLSrfObhHDHBctjbcAMA.Lock())
		{
			LlMtwYyPMjdYMAIZfiXNtbsqkPaM llMtwYyPMjdYMAIZfiXNtbsqkPaM = KGTDswPAIGIHEjSaELtAKAlxoHHLA.Get();
			llMtwYyPMjdYMAIZfiXNtbsqkPaM.JsTdkMenDqYuDTGmUYPtCgURAQNi = P_0;
			llMtwYyPMjdYMAIZfiXNtbsqkPaM.PzbacCnruPaVqchdCteHjnuifwiMb = P_1;
			ueinyejLnfgfLygwUrPPPWXEbpro.Enqueue(llMtwYyPMjdYMAIZfiXNtbsqkPaM);
		}
	}

	public IList<tNoWbaKqbSUoLubXNGsZYacBCvle> LwlshxzNqbsYIfcIoLuFPCiidvxeA()
	{
		return PMUeiDpdIeVBHzwGOFLsCVZHjpvq;
	}

	private void dYNmvHLLZBboVNTSWIRvXlVyQeII()
	{
		bool flag = false;
		List<IjjaNsTYgyWsWoGkfrdEwXNhabgW> list = cYHGZqJhbbxuxXvUiRiLqtazIJSx;
		using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
		{
			IjjaNsTYgyWsWoGkfrdEwXNhabgW.WHeFyykxmyeynTjkmCoMgvjOWhFb(list);
			for (int num = SDFUZWjNSQacAvbEjHsrgYsebDxS.Count - 1; num >= 0; num--)
			{
				if (!mUUCybHNHuUrhivCFAjgpElgqrUd(list, SDFUZWjNSQacAvbEjHsrgYsebDxS[num].kzdQPviJVWElsSwgKFgwCGsMoKoFb))
				{
					SDFUZWjNSQacAvbEjHsrgYsebDxS[num].kzdQPviJVWElsSwgKFgwCGsMoKoFb.hnNeDQdohWAYWTOrNrhFVpxBDDHlA();
					SDFUZWjNSQacAvbEjHsrgYsebDxS[num].Dispose();
					SDFUZWjNSQacAvbEjHsrgYsebDxS.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				IjjaNsTYgyWsWoGkfrdEwXNhabgW ijjaNsTYgyWsWoGkfrdEwXNhabgW = list[num2];
				if (IjjaNsTYgyWsWoGkfrdEwXNhabgW.YdErwNAQjqqjAMbIzDhEEoARQXVk(ijjaNsTYgyWsWoGkfrdEwXNhabgW, null))
				{
					list.RemoveAt(num2);
				}
				else
				{
					int num3 = MniIMLWRJKmXcNyOHLJxPvuBPeRs(SDFUZWjNSQacAvbEjHsrgYsebDxS, ijjaNsTYgyWsWoGkfrdEwXNhabgW);
					if (num3 >= 0)
					{
						list[num2].hnNeDQdohWAYWTOrNrhFVpxBDDHlA();
						list[num2] = SDFUZWjNSQacAvbEjHsrgYsebDxS[num3].kzdQPviJVWElsSwgKFgwCGsMoKoFb;
					}
					else
					{
						SDFUZWjNSQacAvbEjHsrgYsebDxS.Add(new tNoWbaKqbSUoLubXNGsZYacBCvle(ijjaNsTYgyWsWoGkfrdEwXNhabgW, BqsGsACvMCjkdlVaYxRuxjWyZXCg(), SyGbsFabduSDAUtyjexlWTdEWmXc));
						flag = true;
					}
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				IjjaNsTYgyWsWoGkfrdEwXNhabgW ijjaNsTYgyWsWoGkfrdEwXNhabgW2 = list[num4];
				int num5 = MniIMLWRJKmXcNyOHLJxPvuBPeRs(SDFUZWjNSQacAvbEjHsrgYsebDxS, ijjaNsTYgyWsWoGkfrdEwXNhabgW2);
				if (num5 >= 0)
				{
					tNoWbaKqbSUoLubXNGsZYacBCvle item = SDFUZWjNSQacAvbEjHsrgYsebDxS[num5];
					SDFUZWjNSQacAvbEjHsrgYsebDxS.RemoveAt(num5);
					SDFUZWjNSQacAvbEjHsrgYsebDxS.Insert(0, item);
				}
			}
			NKaFObvSTexhPbKmzKkWREDeboiiA.Clear();
			for (int i = 0; i < SDFUZWjNSQacAvbEjHsrgYsebDxS.Count; i++)
			{
				NKaFObvSTexhPbKmzKkWREDeboiiA.Add(SDFUZWjNSQacAvbEjHsrgYsebDxS[i]);
			}
		}
		list.Clear();
		if (flag)
		{
			this.eOyuNlqrvarnRFeQhCNWPQZDCbKz?.Invoke();
		}
	}

	private void KjVrPwxBDfPRcKRxlVbqayPkwdHw(bool P_0)
	{
		FsonfjyHziovFjMuSrvrijBXqcNw = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!FsonfjyHziovFjMuSrvrijBXqcNw)
		{
			using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
			{
				BAMvhiyCSvVRUwfKdFtJStWvPrjI.Clear();
			}
		}
	}

	private void MCfcGbqNyjGzKNHMCsjkqDjbAqUg(bool P_0)
	{
		FsonfjyHziovFjMuSrvrijBXqcNw = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!FsonfjyHziovFjMuSrvrijBXqcNw)
		{
			using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
			{
				BAMvhiyCSvVRUwfKdFtJStWvPrjI.Clear();
			}
		}
	}

	private void IuWinNSABJgQCaGoeUoxSolelmUbb()
	{
		if (FRHjTcMBCiffsFQIvCfKeTNilUlnA || !FsonfjyHziovFjMuSrvrijBXqcNw)
		{
			return;
		}
		using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
		{
			int count = SDFUZWjNSQacAvbEjHsrgYsebDxS.Count;
			for (int i = 0; i < count; i++)
			{
				bDhqYXAKMGOBwieTMlRJRVFkmpvB bDhqYXAKMGOBwieTMlRJRVFkmpvB2 = CJdggygVHLNOqjDaJrMGjqSlFgWmc.Get();
				bDhqYXAKMGOBwieTMlRJRVFkmpvB2.YISokesrZjvRXWXmyooCeYrSOXIs = SDFUZWjNSQacAvbEjHsrgYsebDxS[i].kzdQPviJVWElsSwgKFgwCGsMoKoFb;
				bDhqYXAKMGOBwieTMlRJRVFkmpvB2.FUrFrAIfgIBGlfHTqCZAjpHOuLQBA = bDhqYXAKMGOBwieTMlRJRVFkmpvB2.YISokesrZjvRXWXmyooCeYrSOXIs.HcRxouBcDpbsYzZrbAycfonpKCRX();
				bDhqYXAKMGOBwieTMlRJRVFkmpvB2.pTkAbfaVOqatbAkDijHwmFyoKQkK = ReInput.realTime;
				kiNzMfwNyJojUsOVrENugEEkIfxfA.Enqueue(bDhqYXAKMGOBwieTMlRJRVFkmpvB2);
			}
		}
	}

	private void HEIWOidzMoRljhkciDTJbQghPwrYA()
	{
		if (FRHjTcMBCiffsFQIvCfKeTNilUlnA)
		{
			return;
		}
		using (DjAqDErBIWLSrfObhHDHBctjbcAMA.Lock())
		{
			MiscTools.Swap(ref ueinyejLnfgfLygwUrPPPWXEbpro, ref ZvgaWHiFukcbnSXEZmTBuytqftqu);
		}
		while (ZvgaWHiFukcbnSXEZmTBuytqftqu.Count > 0)
		{
			LlMtwYyPMjdYMAIZfiXNtbsqkPaM llMtwYyPMjdYMAIZfiXNtbsqkPaM = ZvgaWHiFukcbnSXEZmTBuytqftqu.Dequeue();
			try
			{
				llMtwYyPMjdYMAIZfiXNtbsqkPaM.JsTdkMenDqYuDTGmUYPtCgURAQNi.azHOUFaOntscSkPWUeekkHFobDqu = llMtwYyPMjdYMAIZfiXNtbsqkPaM.PzbacCnruPaVqchdCteHjnuifwiMb;
			}
			catch
			{
			}
			llMtwYyPMjdYMAIZfiXNtbsqkPaM.Return();
		}
	}

	private void rcBWTtsOnGJNMqdyCZOffHRoKhrM(IjjaNsTYgyWsWoGkfrdEwXNhabgW P_0)
	{
		P_0.hnNeDQdohWAYWTOrNrhFVpxBDDHlA();
		if (FRHjTcMBCiffsFQIvCfKeTNilUlnA)
		{
			return;
		}
		using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
		{
			ZNDqCBSFeQcaLSYuXjjLXyVrGPMV = true;
		}
	}

	private void jaIdctfnEGWNrsuqqzGqciXjcYhIA(IjjaNsTYgyWsWoGkfrdEwXNhabgW P_0)
	{
		P_0.hnNeDQdohWAYWTOrNrhFVpxBDDHlA();
		if (FRHjTcMBCiffsFQIvCfKeTNilUlnA)
		{
			return;
		}
		using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
		{
			ZNDqCBSFeQcaLSYuXjjLXyVrGPMV = true;
		}
	}

	public void Dispose()
	{
		dmztTEWsVSFQQgAXMqekDYvaVGZj(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ZolCjXPbkjUPggCZwrsVgQfqWmDN()
	{
		try
		{
			dmztTEWsVSFQQgAXMqekDYvaVGZj(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void dmztTEWsVSFQQgAXMqekDYvaVGZj(bool P_0)
	{
		if (FRHjTcMBCiffsFQIvCfKeTNilUlnA)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= KjVrPwxBDfPRcKRxlVbqayPkwdHw;
			ReInput.ApplicationPauseChangedEvent -= MCfcGbqNyjGzKNHMCsjkqDjbAqUg;
			IjjaNsTYgyWsWoGkfrdEwXNhabgW.quIaLTGKTunASUtobEYTTzVxvedeA -= rcBWTtsOnGJNMqdyCZOffHRoKhrM;
			IjjaNsTYgyWsWoGkfrdEwXNhabgW.QsGFoMJhLxnSMTXfZEFDZnLKCPdqA -= jaIdctfnEGWNrsuqqzGqciXjcYhIA;
			GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb.ThreadUpdateEvent -= IuWinNSABJgQCaGoeUoxSolelmUbb;
			GGlKyqwtSRgaaWuZtxjwSYfoOckk.tRiPHogfXqTNFrlrzXWBLUlWuMgA.ThreadUpdateEvent -= HEIWOidzMoRljhkciDTJbQghPwrYA;
			using (iGRkIlwMRegWvmSPCwmxGHhPoPOX.Lock())
			{
				for (int i = 0; i < SDFUZWjNSQacAvbEjHsrgYsebDxS.Count; i++)
				{
					try
					{
						SDFUZWjNSQacAvbEjHsrgYsebDxS[i].Dispose();
						SDFUZWjNSQacAvbEjHsrgYsebDxS[i].kzdQPviJVWElsSwgKFgwCGsMoKoFb.hnNeDQdohWAYWTOrNrhFVpxBDDHlA();
					}
					catch
					{
					}
				}
				SDFUZWjNSQacAvbEjHsrgYsebDxS.Clear();
				NKaFObvSTexhPbKmzKkWREDeboiiA.Clear();
			}
			try
			{
				IjjaNsTYgyWsWoGkfrdEwXNhabgW.pQCGgcCVmMsELUQJpglDaFMnFLanA();
			}
			catch
			{
			}
		}
		FRHjTcMBCiffsFQIvCfKeTNilUlnA = true;
	}

	private static bool xYAfvivosIQuImDTHxyZUKfxxiBC(IList<tNoWbaKqbSUoLubXNGsZYacBCvle> P_0, IjjaNsTYgyWsWoGkfrdEwXNhabgW P_1)
	{
		return MniIMLWRJKmXcNyOHLJxPvuBPeRs(P_0, P_1) >= 0;
	}

	private static bool mUUCybHNHuUrhivCFAjgpElgqrUd(IList<IjjaNsTYgyWsWoGkfrdEwXNhabgW> P_0, IjjaNsTYgyWsWoGkfrdEwXNhabgW P_1)
	{
		return OppEdDmLEJDgKIjPUyXlUtEmhtEO(P_0, P_1) >= 0;
	}

	private static int MniIMLWRJKmXcNyOHLJxPvuBPeRs(IList<tNoWbaKqbSUoLubXNGsZYacBCvle> P_0, IjjaNsTYgyWsWoGkfrdEwXNhabgW P_1)
	{
		if (P_0 == null || IjjaNsTYgyWsWoGkfrdEwXNhabgW.YdErwNAQjqqjAMbIzDhEEoARQXVk(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && IjjaNsTYgyWsWoGkfrdEwXNhabgW.YdErwNAQjqqjAMbIzDhEEoARQXVk(P_0[i].kzdQPviJVWElsSwgKFgwCGsMoKoFb, P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int OppEdDmLEJDgKIjPUyXlUtEmhtEO(IList<IjjaNsTYgyWsWoGkfrdEwXNhabgW> P_0, IjjaNsTYgyWsWoGkfrdEwXNhabgW P_1)
	{
		if (P_0 == null || IjjaNsTYgyWsWoGkfrdEwXNhabgW.YdErwNAQjqqjAMbIzDhEEoARQXVk(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!IjjaNsTYgyWsWoGkfrdEwXNhabgW.YdErwNAQjqqjAMbIzDhEEoARQXVk(P_0[i], null) && IjjaNsTYgyWsWoGkfrdEwXNhabgW.YdErwNAQjqqjAMbIzDhEEoARQXVk(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static FKYcPWNUMoAdbCrNqFTAyfwrptpl()
	{
		nHdJOAUYErlVqoUTzXLQVmrkyNyf = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		OPsueuPUcKpoEKXApKBzUDnZDKcv = new string[1] { "Xbox Bluetooth Gamepad" };
		ITpbJqKyFEVJyECXlQtLIpRqGRFjA = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool qQwvPbyRzggLMdAzpPcYSkopbpTAA(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < OPsueuPUcKpoEKXApKBzUDnZDKcv.Length; i++)
			{
				if (P_1.Equals(OPsueuPUcKpoEKXApKBzUDnZDKcv[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < ITpbJqKyFEVJyECXlQtLIpRqGRFjA.Length; j++)
			{
				if (Regex.IsMatch(P_1, ITpbJqKyFEVJyECXlQtLIpRqGRFjA[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		string[] array = P_0.Split('#');
		if (array.Length < 2)
		{
			return false;
		}
		for (int k = 0; k < array.Length; k++)
		{
			string text = array[k].ToLower();
			if (text.Contains("pid_"))
			{
				int num = text.IndexOf("vid_");
				if (num >= 0 && text.IndexOf("ig_") >= num)
				{
					return true;
				}
			}
		}
		return false;
	}
}
