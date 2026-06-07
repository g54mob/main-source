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

internal class JzdveMZUVasJFkcSCCrAJjOwdxJOA : IDisposable
{
	private abstract class CAvKbEXtDPVlxTPEqIOOJzJatbkPA : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool KMaCgZrxtDEaxpDtKdqJWqvrFmIT;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return KMaCgZrxtDEaxpDtKdqJWqvrFmIT;
			}
			[CompilerGenerated]
			set
			{
				KMaCgZrxtDEaxpDtKdqJWqvrFmIT = value;
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

	private class rhMlPUUJXGkmpWQxgmJPUpbzzeXp : CAvKbEXtDPVlxTPEqIOOJzJatbkPA
	{
		public QXMSgcVznodSmSMxPAPQfqnygfQgA MfyHiAqSfmbbEcpdGUYnnPhTTwCc;

		public tvQgtDzBXDagmkAWojrVhCYhBEWs FiOOaAGKnGcqXjFISatEoEdNxTkn;

		public double rNVchxkqJkNOTbmAEOJabtAPlSAzb;

		protected virtual void rBtvSpbbQuBsGltxwxbYeWPwOMRL()
		{
			MfyHiAqSfmbbEcpdGUYnnPhTTwCc = null;
			FiOOaAGKnGcqXjFISatEoEdNxTkn = default(tvQgtDzBXDagmkAWojrVhCYhBEWs);
			rNVchxkqJkNOTbmAEOJabtAPlSAzb = 0.0;
		}
	}

	private sealed class DWxHqGaCJdKmckbGLcEHaoWbTNWnA : CAvKbEXtDPVlxTPEqIOOJzJatbkPA
	{
		public QXMSgcVznodSmSMxPAPQfqnygfQgA NVeGYMyrEkcshidpyOiznJuOnKrz;

		public kmfvAbnsAlybBleITzlofpcycRap NpAXRQrtxFGfADSakbORosGayeGn;

		protected void lLYXPdpaYjyiNPoNhKnXaPLkLaTK()
		{
			NVeGYMyrEkcshidpyOiznJuOnKrz = null;
			NpAXRQrtxFGfADSakbORosGayeGn = default(kmfvAbnsAlybBleITzlofpcycRap);
		}
	}

	[Serializable]
	private sealed class CRHVADopzJIndBKIInqQAlgrCQJM
	{
		public static readonly CRHVADopzJIndBKIInqQAlgrCQJM _003C_003E9 = new CRHVADopzJIndBKIInqQAlgrCQJM();

		public static Func<rhMlPUUJXGkmpWQxgmJPUpbzzeXp> _003C_003E9__19_0;

		public static Func<DWxHqGaCJdKmckbGLcEHaoWbTNWnA> _003C_003E9__19_1;

		internal rhMlPUUJXGkmpWQxgmJPUpbzzeXp zhaitBjQwSddVNlDclVzJoTCAtIk()
		{
			return new rhMlPUUJXGkmpWQxgmJPUpbzzeXp();
		}

		internal DWxHqGaCJdKmckbGLcEHaoWbTNWnA gLezETAKyRGTWIuMXjVHsmlApzUD()
		{
			return new DWxHqGaCJdKmckbGLcEHaoWbTNWnA();
		}
	}

	private readonly List<dsXpdqMEhGdwtHOaddkDMBIIySZOA> NyBbNfzEIiXIjLdxLYKAGvhjgDIm;

	private readonly ReadOnlyCollection<dsXpdqMEhGdwtHOaddkDMBIIySZOA> VXxDuTdRqkhOnPJakbrmJvMGtlNe;

	private readonly List<QXMSgcVznodSmSMxPAPQfqnygfQgA> wmosRmXcRfIiZtVtYKGZvMOsLbyF;

	private readonly Func<int> JWJDnQKCNOUVROJpcEVoMeyrKZqQA;

	private readonly Rewired.Utils.Classes.Utility.SpinLock kRcnodgFGqqGRSoGyWDxVuFKRtij = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock BvxufAnVdSqaTFDsHjZRvIFuqziG = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<rhMlPUUJXGkmpWQxgmJPUpbzzeXp> NfjEEgwkPnedmKMNJijPFHmEoJPdc;

	private RingBuffer<DWxHqGaCJdKmckbGLcEHaoWbTNWnA> oaXLmDtundLlUErDqjNBWdbRxBRe;

	private bool RLHCdRkspmLpwTpIuBjLbdDSgClC;

	private readonly ThreadSafeObjectPool<rhMlPUUJXGkmpWQxgmJPUpbzzeXp> GtWNSgFLQReRWvFzZmeWnCsMhgcx;

	private readonly ThreadSafeObjectPool<DWxHqGaCJdKmckbGLcEHaoWbTNWnA> GeaJfwXDLQjBuwKfwTZEHmJmZqni;

	private readonly List<dsXpdqMEhGdwtHOaddkDMBIIySZOA> EXuEtIGdTCzAoSXVJHObRxEtpBJaA;

	private RingBuffer<rhMlPUUJXGkmpWQxgmJPUpbzzeXp> mtyBhrmptFtHkSBKXzpuvrczAzVL;

	private RingBuffer<DWxHqGaCJdKmckbGLcEHaoWbTNWnA> JNXzXHgpzwtLDmkDtHtFrnZfPpYu;

	private bool DUuCVREAjWGGllgznLHLDKbitNaGb;

	private Action<QXMSgcVznodSmSMxPAPQfqnygfQgA, kmfvAbnsAlybBleITzlofpcycRap> SnVmMuccaoRixmhsPhGdLwtFQOAY;

	[CompilerGenerated]
	private Action m_mmJkWdehmoDVzbePVtvAEhjKcdiR;

	private bool VrazQgYXRwTXIrCVTlLYIynrQKLr;

	private static Guid[] tZAtuMIUFdLBEIbQFnhCAhNrskEu;

	private static string[] QRNwReDIrMBJchkFXlafcDNAySQTA;

	private static string[] CIKYkiUYOUBpCePGPXZBLKrvaLbs;

	public event Action mmJkWdehmoDVzbePVtvAEhjKcdiR
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_mmJkWdehmoDVzbePVtvAEhjKcdiR;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_mmJkWdehmoDVzbePVtvAEhjKcdiR, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_mmJkWdehmoDVzbePVtvAEhjKcdiR;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_mmJkWdehmoDVzbePVtvAEhjKcdiR, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public JzdveMZUVasJFkcSCCrAJjOwdxJOA(Func<int> P_0)
	{
		JWJDnQKCNOUVROJpcEVoMeyrKZqQA = P_0;
		SnVmMuccaoRixmhsPhGdLwtFQOAY = KLLupEaNRRDSAHChIMKAfPqOcDMyA;
		NyBbNfzEIiXIjLdxLYKAGvhjgDIm = new List<dsXpdqMEhGdwtHOaddkDMBIIySZOA>();
		EXuEtIGdTCzAoSXVJHObRxEtpBJaA = new List<dsXpdqMEhGdwtHOaddkDMBIIySZOA>();
		VXxDuTdRqkhOnPJakbrmJvMGtlNe = new ReadOnlyCollection<dsXpdqMEhGdwtHOaddkDMBIIySZOA>(NyBbNfzEIiXIjLdxLYKAGvhjgDIm);
		wmosRmXcRfIiZtVtYKGZvMOsLbyF = new List<QXMSgcVznodSmSMxPAPQfqnygfQgA>();
		RLHCdRkspmLpwTpIuBjLbdDSgClC = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)MROXnswaFDYJOaQMZFuqDWLdEBUH.QLOtUfyZkbAhGxDQNPvrDkbJpnUT * 32f) + 1;
		GtWNSgFLQReRWvFzZmeWnCsMhgcx = new ThreadSafeObjectPool<rhMlPUUJXGkmpWQxgmJPUpbzzeXp>(num, CRHVADopzJIndBKIInqQAlgrCQJM._003C_003E9.zhaitBjQwSddVNlDclVzJoTCAtIk);
		GeaJfwXDLQjBuwKfwTZEHmJmZqni = new ThreadSafeObjectPool<DWxHqGaCJdKmckbGLcEHaoWbTNWnA>(128, CRHVADopzJIndBKIInqQAlgrCQJM._003C_003E9.gLezETAKyRGTWIuMXjVHsmlApzUD);
		NfjEEgwkPnedmKMNJijPFHmEoJPdc = new RingBuffer<rhMlPUUJXGkmpWQxgmJPUpbzzeXp>(num);
		oaXLmDtundLlUErDqjNBWdbRxBRe = new RingBuffer<DWxHqGaCJdKmckbGLcEHaoWbTNWnA>(128);
		mtyBhrmptFtHkSBKXzpuvrczAzVL = new RingBuffer<rhMlPUUJXGkmpWQxgmJPUpbzzeXp>(num);
		JNXzXHgpzwtLDmkDtHtFrnZfPpYu = new RingBuffer<DWxHqGaCJdKmckbGLcEHaoWbTNWnA>(128);
		QXMSgcVznodSmSMxPAPQfqnygfQgA.sgdkqZWNIgaKgJEbXmPRcOlymjLk += bGgAxtutgIbdmFMdqEtnqqfllxXbA;
		QXMSgcVznodSmSMxPAPQfqnygfQgA.OrxHPCjuQjiKejKghvXVmjuPVeZE += jIzDErtPVUlQBCQzOotanojmQeVh;
		MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm.ThreadUpdateEvent += WpvIMNSDGTsPemJlOKKhbsPnwnwI;
		MROXnswaFDYJOaQMZFuqDWLdEBUH.vLuOaJcYwVMvlDPcDIdIOawkciegA.ThreadUpdateEvent += TctvhejAVcANDZWpWihHDeMgzgBQ;
		ReInput.ApplicationFocusChangedEvent += YvsmamfWRfbVQesmVBJkhlxrxunE;
		ReInput.ApplicationPauseChangedEvent += MgSdBbhudtPesrrSqQKeLfHkTAoJA;
		QXMSgcVznodSmSMxPAPQfqnygfQgA.VnmaAhhlbuAvAWieWUkwqPMXUuuV();
		vEsgFZgLYFFXlgnXgmudiMlmnOwtB();
	}

	public void KeLoRfDFJkxCDiuaiuVMspEJZhym()
	{
		bool flag = false;
		using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
		{
			if (DUuCVREAjWGGllgznLHLDKbitNaGb)
			{
				DUuCVREAjWGGllgznLHLDKbitNaGb = false;
				flag = true;
			}
		}
		if (flag)
		{
			vEsgFZgLYFFXlgnXgmudiMlmnOwtB();
		}
	}

	public void MZKVtJfHYkOiyZCxKNarSqoKrDet()
	{
		using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
		{
			MiscTools.Swap(ref NfjEEgwkPnedmKMNJijPFHmEoJPdc, ref mtyBhrmptFtHkSBKXzpuvrczAzVL);
		}
		while (NfjEEgwkPnedmKMNJijPFHmEoJPdc.Count > 0)
		{
			rhMlPUUJXGkmpWQxgmJPUpbzzeXp rhMlPUUJXGkmpWQxgmJPUpbzzeXp2 = NfjEEgwkPnedmKMNJijPFHmEoJPdc.Dequeue();
			int num = EXRrdHEjAYdyQzmVhtjnAQQYmKri(NyBbNfzEIiXIjLdxLYKAGvhjgDIm, rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.MfyHiAqSfmbbEcpdGUYnnPhTTwCc);
			if (num >= 0)
			{
				NyBbNfzEIiXIjLdxLYKAGvhjgDIm[num].InnbMigVHFEduBtVauWWnJkdogIGD(rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.FiOOaAGKnGcqXjFISatEoEdNxTkn, rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.rNVchxkqJkNOTbmAEOJabtAPlSAzb);
			}
			rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.Return();
		}
	}

	private void KLLupEaNRRDSAHChIMKAfPqOcDMyA(QXMSgcVznodSmSMxPAPQfqnygfQgA P_0, kmfvAbnsAlybBleITzlofpcycRap P_1)
	{
		if (!RLHCdRkspmLpwTpIuBjLbdDSgClC)
		{
			return;
		}
		using (BvxufAnVdSqaTFDsHjZRvIFuqziG.Lock())
		{
			DWxHqGaCJdKmckbGLcEHaoWbTNWnA dWxHqGaCJdKmckbGLcEHaoWbTNWnA = GeaJfwXDLQjBuwKfwTZEHmJmZqni.Get();
			dWxHqGaCJdKmckbGLcEHaoWbTNWnA.NVeGYMyrEkcshidpyOiznJuOnKrz = P_0;
			dWxHqGaCJdKmckbGLcEHaoWbTNWnA.NpAXRQrtxFGfADSakbORosGayeGn = P_1;
			oaXLmDtundLlUErDqjNBWdbRxBRe.Enqueue(dWxHqGaCJdKmckbGLcEHaoWbTNWnA);
		}
	}

	public IList<dsXpdqMEhGdwtHOaddkDMBIIySZOA> JcEQExxxPdoWiLNnUOxBUCnxpALd()
	{
		return VXxDuTdRqkhOnPJakbrmJvMGtlNe;
	}

	private void vEsgFZgLYFFXlgnXgmudiMlmnOwtB()
	{
		bool flag = false;
		List<QXMSgcVznodSmSMxPAPQfqnygfQgA> list = wmosRmXcRfIiZtVtYKGZvMOsLbyF;
		using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
		{
			QXMSgcVznodSmSMxPAPQfqnygfQgA.YJsLioqLwcYOSblyAGcyipPqfURdb(list);
			for (int num = EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Count - 1; num >= 0; num--)
			{
				if (!uFvlleZzYuKqVQiiriomkiojRcsVA(list, EXuEtIGdTCzAoSXVJHObRxEtpBJaA[num].yfQggfgUaIRYQspjaAYyJEhNSCYd))
				{
					EXuEtIGdTCzAoSXVJHObRxEtpBJaA[num].yfQggfgUaIRYQspjaAYyJEhNSCYd.ftegaMeUwYaicakwpFDRaQBWDKzE();
					EXuEtIGdTCzAoSXVJHObRxEtpBJaA[num].Dispose();
					EXuEtIGdTCzAoSXVJHObRxEtpBJaA.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				QXMSgcVznodSmSMxPAPQfqnygfQgA qXMSgcVznodSmSMxPAPQfqnygfQgA = list[num2];
				if (QXMSgcVznodSmSMxPAPQfqnygfQgA.UEjIAJCUaukCefmHeLVGEReUOMtOb(qXMSgcVznodSmSMxPAPQfqnygfQgA, null))
				{
					list.RemoveAt(num2);
				}
				else
				{
					int num3 = EXRrdHEjAYdyQzmVhtjnAQQYmKri(EXuEtIGdTCzAoSXVJHObRxEtpBJaA, qXMSgcVznodSmSMxPAPQfqnygfQgA);
					if (num3 >= 0)
					{
						list[num2].ftegaMeUwYaicakwpFDRaQBWDKzE();
						list[num2] = EXuEtIGdTCzAoSXVJHObRxEtpBJaA[num3].yfQggfgUaIRYQspjaAYyJEhNSCYd;
					}
					else
					{
						EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Add(new dsXpdqMEhGdwtHOaddkDMBIIySZOA(qXMSgcVznodSmSMxPAPQfqnygfQgA, JWJDnQKCNOUVROJpcEVoMeyrKZqQA(), SnVmMuccaoRixmhsPhGdLwtFQOAY));
						flag = true;
					}
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				QXMSgcVznodSmSMxPAPQfqnygfQgA qXMSgcVznodSmSMxPAPQfqnygfQgA2 = list[num4];
				int num5 = EXRrdHEjAYdyQzmVhtjnAQQYmKri(EXuEtIGdTCzAoSXVJHObRxEtpBJaA, qXMSgcVznodSmSMxPAPQfqnygfQgA2);
				if (num5 >= 0)
				{
					dsXpdqMEhGdwtHOaddkDMBIIySZOA item = EXuEtIGdTCzAoSXVJHObRxEtpBJaA[num5];
					EXuEtIGdTCzAoSXVJHObRxEtpBJaA.RemoveAt(num5);
					EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Insert(0, item);
				}
			}
			NyBbNfzEIiXIjLdxLYKAGvhjgDIm.Clear();
			for (int i = 0; i < EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Count; i++)
			{
				NyBbNfzEIiXIjLdxLYKAGvhjgDIm.Add(EXuEtIGdTCzAoSXVJHObRxEtpBJaA[i]);
			}
		}
		list.Clear();
		if (flag)
		{
			this.mmJkWdehmoDVzbePVtvAEhjKcdiR?.Invoke();
		}
	}

	private void YvsmamfWRfbVQesmVBJkhlxrxunE(bool P_0)
	{
		RLHCdRkspmLpwTpIuBjLbdDSgClC = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!RLHCdRkspmLpwTpIuBjLbdDSgClC)
		{
			using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
			{
				NfjEEgwkPnedmKMNJijPFHmEoJPdc.Clear();
			}
		}
	}

	private void MgSdBbhudtPesrrSqQKeLfHkTAoJA(bool P_0)
	{
		RLHCdRkspmLpwTpIuBjLbdDSgClC = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!RLHCdRkspmLpwTpIuBjLbdDSgClC)
		{
			using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
			{
				NfjEEgwkPnedmKMNJijPFHmEoJPdc.Clear();
			}
		}
	}

	private void WpvIMNSDGTsPemJlOKKhbsPnwnwI()
	{
		if (VrazQgYXRwTXIrCVTlLYIynrQKLr || !RLHCdRkspmLpwTpIuBjLbdDSgClC)
		{
			return;
		}
		using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
		{
			int count = EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Count;
			for (int i = 0; i < count; i++)
			{
				rhMlPUUJXGkmpWQxgmJPUpbzzeXp rhMlPUUJXGkmpWQxgmJPUpbzzeXp2 = GtWNSgFLQReRWvFzZmeWnCsMhgcx.Get();
				rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.MfyHiAqSfmbbEcpdGUYnnPhTTwCc = EXuEtIGdTCzAoSXVJHObRxEtpBJaA[i].yfQggfgUaIRYQspjaAYyJEhNSCYd;
				rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.FiOOaAGKnGcqXjFISatEoEdNxTkn = rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.MfyHiAqSfmbbEcpdGUYnnPhTTwCc.NgiFEgjJKvFEsUNiJOOgwuViTWjRA();
				rhMlPUUJXGkmpWQxgmJPUpbzzeXp2.rNVchxkqJkNOTbmAEOJabtAPlSAzb = ReInput.realTime;
				mtyBhrmptFtHkSBKXzpuvrczAzVL.Enqueue(rhMlPUUJXGkmpWQxgmJPUpbzzeXp2);
			}
		}
	}

	private void TctvhejAVcANDZWpWihHDeMgzgBQ()
	{
		if (VrazQgYXRwTXIrCVTlLYIynrQKLr)
		{
			return;
		}
		using (BvxufAnVdSqaTFDsHjZRvIFuqziG.Lock())
		{
			MiscTools.Swap(ref oaXLmDtundLlUErDqjNBWdbRxBRe, ref JNXzXHgpzwtLDmkDtHtFrnZfPpYu);
		}
		while (JNXzXHgpzwtLDmkDtHtFrnZfPpYu.Count > 0)
		{
			DWxHqGaCJdKmckbGLcEHaoWbTNWnA dWxHqGaCJdKmckbGLcEHaoWbTNWnA = JNXzXHgpzwtLDmkDtHtFrnZfPpYu.Dequeue();
			try
			{
				dWxHqGaCJdKmckbGLcEHaoWbTNWnA.NVeGYMyrEkcshidpyOiznJuOnKrz.kdigdVjwyxdGuxCNaKKmXnrzbBCVA = dWxHqGaCJdKmckbGLcEHaoWbTNWnA.NpAXRQrtxFGfADSakbORosGayeGn;
			}
			catch
			{
			}
			dWxHqGaCJdKmckbGLcEHaoWbTNWnA.Return();
		}
	}

	private void bGgAxtutgIbdmFMdqEtnqqfllxXbA(QXMSgcVznodSmSMxPAPQfqnygfQgA P_0)
	{
		P_0.ftegaMeUwYaicakwpFDRaQBWDKzE();
		if (VrazQgYXRwTXIrCVTlLYIynrQKLr)
		{
			return;
		}
		using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
		{
			DUuCVREAjWGGllgznLHLDKbitNaGb = true;
		}
	}

	private void jIzDErtPVUlQBCQzOotanojmQeVh(QXMSgcVznodSmSMxPAPQfqnygfQgA P_0)
	{
		P_0.ftegaMeUwYaicakwpFDRaQBWDKzE();
		if (VrazQgYXRwTXIrCVTlLYIynrQKLr)
		{
			return;
		}
		using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
		{
			DUuCVREAjWGGllgznLHLDKbitNaGb = true;
		}
	}

	public void Dispose()
	{
		zcAgACCKQIWdcNIEmeSaUWBrOXvkA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void PtGvKZPyvrKnCSSEGzSFpWXzkknl()
	{
		try
		{
			zcAgACCKQIWdcNIEmeSaUWBrOXvkA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void zcAgACCKQIWdcNIEmeSaUWBrOXvkA(bool P_0)
	{
		if (VrazQgYXRwTXIrCVTlLYIynrQKLr)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= YvsmamfWRfbVQesmVBJkhlxrxunE;
			ReInput.ApplicationPauseChangedEvent -= MgSdBbhudtPesrrSqQKeLfHkTAoJA;
			QXMSgcVznodSmSMxPAPQfqnygfQgA.sgdkqZWNIgaKgJEbXmPRcOlymjLk -= bGgAxtutgIbdmFMdqEtnqqfllxXbA;
			QXMSgcVznodSmSMxPAPQfqnygfQgA.OrxHPCjuQjiKejKghvXVmjuPVeZE -= jIzDErtPVUlQBCQzOotanojmQeVh;
			MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm.ThreadUpdateEvent -= WpvIMNSDGTsPemJlOKKhbsPnwnwI;
			MROXnswaFDYJOaQMZFuqDWLdEBUH.vLuOaJcYwVMvlDPcDIdIOawkciegA.ThreadUpdateEvent -= TctvhejAVcANDZWpWihHDeMgzgBQ;
			using (kRcnodgFGqqGRSoGyWDxVuFKRtij.Lock())
			{
				for (int i = 0; i < EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Count; i++)
				{
					try
					{
						EXuEtIGdTCzAoSXVJHObRxEtpBJaA[i].Dispose();
						EXuEtIGdTCzAoSXVJHObRxEtpBJaA[i].yfQggfgUaIRYQspjaAYyJEhNSCYd.ftegaMeUwYaicakwpFDRaQBWDKzE();
					}
					catch
					{
					}
				}
				EXuEtIGdTCzAoSXVJHObRxEtpBJaA.Clear();
				NyBbNfzEIiXIjLdxLYKAGvhjgDIm.Clear();
			}
			try
			{
				QXMSgcVznodSmSMxPAPQfqnygfQgA.hxvVJeNTfCkOfsqYRHGNCciaFkOL();
			}
			catch
			{
			}
		}
		VrazQgYXRwTXIrCVTlLYIynrQKLr = true;
	}

	private static bool hdpgMihzhMBwiFWWcjXXOPuuqbpnB(IList<dsXpdqMEhGdwtHOaddkDMBIIySZOA> P_0, QXMSgcVznodSmSMxPAPQfqnygfQgA P_1)
	{
		return EXRrdHEjAYdyQzmVhtjnAQQYmKri(P_0, P_1) >= 0;
	}

	private static bool uFvlleZzYuKqVQiiriomkiojRcsVA(IList<QXMSgcVznodSmSMxPAPQfqnygfQgA> P_0, QXMSgcVznodSmSMxPAPQfqnygfQgA P_1)
	{
		return IkYGxXkVNDYqTsAgidbbXeudnjuE(P_0, P_1) >= 0;
	}

	private static int EXRrdHEjAYdyQzmVhtjnAQQYmKri(IList<dsXpdqMEhGdwtHOaddkDMBIIySZOA> P_0, QXMSgcVznodSmSMxPAPQfqnygfQgA P_1)
	{
		if (P_0 == null || QXMSgcVznodSmSMxPAPQfqnygfQgA.UEjIAJCUaukCefmHeLVGEReUOMtOb(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && QXMSgcVznodSmSMxPAPQfqnygfQgA.UEjIAJCUaukCefmHeLVGEReUOMtOb(P_0[i].yfQggfgUaIRYQspjaAYyJEhNSCYd, P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int IkYGxXkVNDYqTsAgidbbXeudnjuE(IList<QXMSgcVznodSmSMxPAPQfqnygfQgA> P_0, QXMSgcVznodSmSMxPAPQfqnygfQgA P_1)
	{
		if (P_0 == null || QXMSgcVznodSmSMxPAPQfqnygfQgA.UEjIAJCUaukCefmHeLVGEReUOMtOb(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!QXMSgcVznodSmSMxPAPQfqnygfQgA.UEjIAJCUaukCefmHeLVGEReUOMtOb(P_0[i], null) && QXMSgcVznodSmSMxPAPQfqnygfQgA.UEjIAJCUaukCefmHeLVGEReUOMtOb(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static JzdveMZUVasJFkcSCCrAJjOwdxJOA()
	{
		tZAtuMIUFdLBEIbQFnhCAhNrskEu = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		QRNwReDIrMBJchkFXlafcDNAySQTA = new string[1] { "Xbox Bluetooth Gamepad" };
		CIKYkiUYOUBpCePGPXZBLKrvaLbs = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool oOFoqrkewkbrqJgqFgGQDuGcErzdA(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < QRNwReDIrMBJchkFXlafcDNAySQTA.Length; i++)
			{
				if (P_1.Equals(QRNwReDIrMBJchkFXlafcDNAySQTA[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < CIKYkiUYOUBpCePGPXZBLKrvaLbs.Length; j++)
			{
				if (Regex.IsMatch(P_1, CIKYkiUYOUBpCePGPXZBLKrvaLbs[j], RegexOptions.IgnoreCase))
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
