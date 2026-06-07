using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint ifwBoHsXcVQdFMpPnIiLTKoEhjOcA = 750u;

		private readonly Stopwatch coYOiUExxfSwejaQnAwmCyprKitT;

		private Thread woKFAxDegKnocuaBncbDabYzoudGA;

		private ManualResetEvent zphQRXeVqzHNLceNfSHBUANRHNrh;

		private ManualResetEvent HXpyaEUGnzbtrALfOAqodgfOaEhAb;

		private AutoResetEvent LpjsjCrOVIwgHPoRyNvLYhuNaHlaA;

		private bool IpQjmEwPdKvpqdZquWPZbMtaRTYq;

		private bool ITUdZwlkIpFXbiAVGdBSXmcROyXfb;

		private int JgLDeaBJslfpFADeBzzfFOvwYOtuB;

		private bool PtuvjncFftvKDhBycEtYDvANIheqA;

		private int PImvGIcmhODuobkgZOAunTUNAhoQA;

		private long oYNhZGgNOJTwykkWrIEToAQojfMr;

		private bool xFqdYlsCmjUgbQytByCCGgCDNQbI;

		private int JrGoUbCCcppfYgxqciEMAjjgmgpu;

		private long jzIlSSGrqMQwZUFleMpUMWLSkODJ;

		private uint pKyPsdgRCCCVeypaRZThOSgdbdbY;

		private readonly object gRrhTwXgMXDCNAcYmnpSgiXsuIKzA;

		private Queue<Action> tRpILoTJNgEyrwQTHEMTgxuxfPTJ;

		private Queue<Action> kUorNHKXDnJzywfKmMnSHckQJhHB;

		private bool AdjUduawLXDKxIKvOUnETISFMEJr;

		private Action xKtFgAaMsdZOzasKdqluWvRDalfaA;

		[CompilerGenerated]
		private Action cpsNLSCIeUGLFEhTtJJoAMuEXRCob;

		[CompilerGenerated]
		private Action oJYFFahMLYJqKCOTGGTGRqgHcduuA;

		private bool YJiylePWDIaGEkRZZYUWVTXzHHGB;

		public bool isRunning => ITUdZwlkIpFXbiAVGdBSXmcROyXfb;

		public bool isStopped
		{
			get
			{
				if (!ITUdZwlkIpFXbiAVGdBSXmcROyXfb)
				{
					if (woKFAxDegKnocuaBncbDabYzoudGA == null)
					{
						return true;
					}
					return !woKFAxDegKnocuaBncbDabYzoudGA.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!PtuvjncFftvKDhBycEtYDvANIheqA)
				{
					return (long)PImvGIcmhODuobkgZOAunTUNAhoQA >= 750L;
				}
				return true;
			}
			set
			{
				if (value != PtuvjncFftvKDhBycEtYDvANIheqA)
				{
					PtuvjncFftvKDhBycEtYDvANIheqA = value;
					AxNfnHKYpeeuRboTGPHlbgCtWPEcc();
				}
			}
		}

		public bool useFixedTimeStep => xFqdYlsCmjUgbQytByCCGgCDNQbI;

		public int fixedTimeStepFPS
		{
			get
			{
				return PImvGIcmhODuobkgZOAunTUNAhoQA;
			}
			set
			{
				PImvGIcmhODuobkgZOAunTUNAhoQA = ((value > 0) ? value : 0);
				AxNfnHKYpeeuRboTGPHlbgCtWPEcc();
			}
		}

		public int timeoutMS
		{
			get
			{
				return JrGoUbCCcppfYgxqciEMAjjgmgpu;
			}
			set
			{
				JrGoUbCCcppfYgxqciEMAjjgmgpu = ((value > 0) ? value : 0);
				AxNfnHKYpeeuRboTGPHlbgCtWPEcc();
			}
		}

		public uint tick => pKyPsdgRCCCVeypaRZThOSgdbdbY;

		public event Action ThreadUpdateEvent
		{
			add
			{
				xKtFgAaMsdZOzasKdqluWvRDalfaA = (Action)Delegate.Combine(xKtFgAaMsdZOzasKdqluWvRDalfaA, value);
			}
			remove
			{
				xKtFgAaMsdZOzasKdqluWvRDalfaA = (Action)Delegate.Remove(xKtFgAaMsdZOzasKdqluWvRDalfaA, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = cpsNLSCIeUGLFEhTtJJoAMuEXRCob;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref cpsNLSCIeUGLFEhTtJJoAMuEXRCob, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = cpsNLSCIeUGLFEhTtJJoAMuEXRCob;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref cpsNLSCIeUGLFEhTtJJoAMuEXRCob, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action ThreadStartedEvent
		{
			add
			{
				_ThreadStartedEvent += value;
			}
			remove
			{
				_ThreadStartedEvent -= value;
			}
		}

		private event Action _ThreadPreStopEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = oJYFFahMLYJqKCOTGGTGRqgHcduuA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref oJYFFahMLYJqKCOTGGTGRqgHcduuA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = oJYFFahMLYJqKCOTGGTGRqgHcduuA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref oJYFFahMLYJqKCOTGGTGRqgHcduuA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action ThreadPreStopEvent
		{
			add
			{
				_ThreadPreStopEvent += value;
			}
			remove
			{
				_ThreadPreStopEvent -= value;
			}
		}

		public static ThreadHelper Create(bool fixedTimeStep = false, int fixedTimeStepFPS = 100, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			if (fixedTimeStep)
			{
				return new ThreadHelper(fixedTimeStepFPS, useHighPrecisionTimer, timeoutMS);
			}
			return new ThreadHelper(timeoutMS);
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
		{
			return CreateFixedTimeStep(timeStepFPS, useHighPrecisionTimer: false, timeoutMS);
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			return new ThreadHelper(timeStepFPS, useHighPrecisionTimer, timeoutMS);
		}

		private ThreadHelper()
			: this(0)
		{
		}

		private ThreadHelper(int P_0)
			: this(0, false, P_0)
		{
		}

		private ThreadHelper(int P_0, bool P_1, int P_2)
		{
			coYOiUExxfSwejaQnAwmCyprKitT = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			JrGoUbCCcppfYgxqciEMAjjgmgpu = P_2;
			PImvGIcmhODuobkgZOAunTUNAhoQA = P_0;
			PtuvjncFftvKDhBycEtYDvANIheqA = P_1;
			AxNfnHKYpeeuRboTGPHlbgCtWPEcc();
			zphQRXeVqzHNLceNfSHBUANRHNrh = new ManualResetEvent(initialState: false);
			HXpyaEUGnzbtrALfOAqodgfOaEhAb = new ManualResetEvent(initialState: false);
			LpjsjCrOVIwgHPoRyNvLYhuNaHlaA = new AutoResetEvent(initialState: false);
			gRrhTwXgMXDCNAcYmnpSgiXsuIKzA = new object();
			tRpILoTJNgEyrwQTHEMTgxuxfPTJ = new Queue<Action>();
			kUorNHKXDnJzywfKmMnSHckQJhHB = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (ITUdZwlkIpFXbiAVGdBSXmcROyXfb)
			{
				return false;
			}
			try
			{
				zphQRXeVqzHNLceNfSHBUANRHNrh.Reset();
				LpjsjCrOVIwgHPoRyNvLYhuNaHlaA.Reset();
				woKFAxDegKnocuaBncbDabYzoudGA = new Thread(xjfEnxdBERCPxomxptBrWIzzvBkbA);
				woKFAxDegKnocuaBncbDabYzoudGA.Start();
				if (wait)
				{
					zphQRXeVqzHNLceNfSHBUANRHNrh.WaitOne();
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void Stop(bool wait)
		{
			if (woKFAxDegKnocuaBncbDabYzoudGA != null && ITUdZwlkIpFXbiAVGdBSXmcROyXfb && IpQjmEwPdKvpqdZquWPZbMtaRTYq)
			{
				zphQRXeVqzHNLceNfSHBUANRHNrh.Reset();
				IpQjmEwPdKvpqdZquWPZbMtaRTYq = false;
				LpjsjCrOVIwgHPoRyNvLYhuNaHlaA.Set();
				if (wait)
				{
					zphQRXeVqzHNLceNfSHBUANRHNrh.WaitOne();
				}
				DrBYnwZtZHTusDqwKItKqcREeDqD();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!ITUdZwlkIpFXbiAVGdBSXmcROyXfb)
			{
				return false;
			}
			if (!IpQjmEwPdKvpqdZquWPZbMtaRTYq)
			{
				return false;
			}
			ResetTimeout();
			lock (gRrhTwXgMXDCNAcYmnpSgiXsuIKzA)
			{
				tRpILoTJNgEyrwQTHEMTgxuxfPTJ.Enqueue(action);
				AdjUduawLXDKxIKvOUnETISFMEJr = true;
				LpjsjCrOVIwgHPoRyNvLYhuNaHlaA.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!ITUdZwlkIpFXbiAVGdBSXmcROyXfb)
			{
				return false;
			}
			if (!IpQjmEwPdKvpqdZquWPZbMtaRTYq)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!ITUdZwlkIpFXbiAVGdBSXmcROyXfb || !IpQjmEwPdKvpqdZquWPZbMtaRTYq)
			{
				return;
			}
			ResetTimeout();
			lock (gRrhTwXgMXDCNAcYmnpSgiXsuIKzA)
			{
				HXpyaEUGnzbtrALfOAqodgfOaEhAb.Reset();
				JgLDeaBJslfpFADeBzzfFOvwYOtuB++;
			}
			LpjsjCrOVIwgHPoRyNvLYhuNaHlaA.Set();
			HXpyaEUGnzbtrALfOAqodgfOaEhAb.WaitOne();
			lock (gRrhTwXgMXDCNAcYmnpSgiXsuIKzA)
			{
				JgLDeaBJslfpFADeBzzfFOvwYOtuB--;
			}
		}

		public void ResetTimeout()
		{
			jzIlSSGrqMQwZUFleMpUMWLSkODJ = ((JrGoUbCCcppfYgxqciEMAjjgmgpu > 0) ? (coYOiUExxfSwejaQnAwmCyprKitT.elapsedMillisecondsRaw + JrGoUbCCcppfYgxqciEMAjjgmgpu) : 0);
		}

		private void xjfEnxdBERCPxomxptBrWIzzvBkbA()
		{
			ResetTimeout();
			ITUdZwlkIpFXbiAVGdBSXmcROyXfb = true;
			IpQjmEwPdKvpqdZquWPZbMtaRTYq = true;
			zphQRXeVqzHNLceNfSHBUANRHNrh.Set();
			if (cpsNLSCIeUGLFEhTtJJoAMuEXRCob != null)
			{
				lock (cpsNLSCIeUGLFEhTtJJoAMuEXRCob)
				{
					try
					{
						cpsNLSCIeUGLFEhTtJJoAMuEXRCob();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (IpQjmEwPdKvpqdZquWPZbMtaRTYq)
			{
				long num = coYOiUExxfSwejaQnAwmCyprKitT.elapsedTicksRaw + oYNhZGgNOJTwykkWrIEToAQojfMr;
				CGLhQmKkpIIbGkoyAJMdSavDMzyeb();
				lock (gRrhTwXgMXDCNAcYmnpSgiXsuIKzA)
				{
					if (!AdjUduawLXDKxIKvOUnETISFMEJr && JgLDeaBJslfpFADeBzzfFOvwYOtuB > 0)
					{
						HXpyaEUGnzbtrALfOAqodgfOaEhAb.Set();
					}
				}
				if (xKtFgAaMsdZOzasKdqluWvRDalfaA != null)
				{
					try
					{
						xKtFgAaMsdZOzasKdqluWvRDalfaA();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (xFqdYlsCmjUgbQytByCCGgCDNQbI)
				{
					if (PtuvjncFftvKDhBycEtYDvANIheqA || (long)PImvGIcmhODuobkgZOAunTUNAhoQA >= 750L)
					{
						while (coYOiUExxfSwejaQnAwmCyprKitT.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - coYOiUExxfSwejaQnAwmCyprKitT.elapsedTicksRaw;
						if (num2 > 0)
						{
							LpjsjCrOVIwgHPoRyNvLYhuNaHlaA.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				pKyPsdgRCCCVeypaRZThOSgdbdbY = ((pKyPsdgRCCCVeypaRZThOSgdbdbY != uint.MaxValue) ? (pKyPsdgRCCCVeypaRZThOSgdbdbY + 1) : 0u);
				if (JrGoUbCCcppfYgxqciEMAjjgmgpu > 0 && coYOiUExxfSwejaQnAwmCyprKitT.elapsedMillisecondsRaw >= jzIlSSGrqMQwZUFleMpUMWLSkODJ)
				{
					IpQjmEwPdKvpqdZquWPZbMtaRTYq = false;
				}
			}
			if (oJYFFahMLYJqKCOTGGTGRqgHcduuA != null)
			{
				lock (oJYFFahMLYJqKCOTGGTGRqgHcduuA)
				{
					try
					{
						oJYFFahMLYJqKCOTGGTGRqgHcduuA();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			ITUdZwlkIpFXbiAVGdBSXmcROyXfb = false;
			zphQRXeVqzHNLceNfSHBUANRHNrh.Set();
		}

		private void CGLhQmKkpIIbGkoyAJMdSavDMzyeb()
		{
			if (!AdjUduawLXDKxIKvOUnETISFMEJr)
			{
				return;
			}
			lock (gRrhTwXgMXDCNAcYmnpSgiXsuIKzA)
			{
				MiscTools.Swap(ref tRpILoTJNgEyrwQTHEMTgxuxfPTJ, ref kUorNHKXDnJzywfKmMnSHckQJhHB);
				AdjUduawLXDKxIKvOUnETISFMEJr = false;
			}
			while (kUorNHKXDnJzywfKmMnSHckQJhHB.Count > 0)
			{
				Action action = kUorNHKXDnJzywfKmMnSHckQJhHB.Dequeue();
				try
				{
					action();
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while processing thread Action queue.\n" + ex, requiredThreadSafety: true);
				}
			}
		}

		private void AxNfnHKYpeeuRboTGPHlbgCtWPEcc()
		{
			if (PImvGIcmhODuobkgZOAunTUNAhoQA <= 0)
			{
				xFqdYlsCmjUgbQytByCCGgCDNQbI = false;
			}
			else
			{
				xFqdYlsCmjUgbQytByCCGgCDNQbI = true;
				oYNhZGgNOJTwykkWrIEToAQojfMr = Stopwatch.frequency / PImvGIcmhODuobkgZOAunTUNAhoQA;
			}
			ResetTimeout();
		}

		private void DrBYnwZtZHTusDqwKItKqcREeDqD()
		{
			woKFAxDegKnocuaBncbDabYzoudGA = null;
			ITUdZwlkIpFXbiAVGdBSXmcROyXfb = false;
			IpQjmEwPdKvpqdZquWPZbMtaRTYq = false;
			tRpILoTJNgEyrwQTHEMTgxuxfPTJ.Clear();
			kUorNHKXDnJzywfKmMnSHckQJhHB.Clear();
			AdjUduawLXDKxIKvOUnETISFMEJr = false;
			JgLDeaBJslfpFADeBzzfFOvwYOtuB = 0;
			zphQRXeVqzHNLceNfSHBUANRHNrh.Reset();
			HXpyaEUGnzbtrALfOAqodgfOaEhAb.Reset();
			jzIlSSGrqMQwZUFleMpUMWLSkODJ = 0L;
			pKyPsdgRCCCVeypaRZThOSgdbdbY = 0u;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~ThreadHelper()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!YJiylePWDIaGEkRZZYUWVTXzHHGB)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					IpQjmEwPdKvpqdZquWPZbMtaRTYq = false;
				}
				YJiylePWDIaGEkRZZYUWVTXzHHGB = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void iTCLotWMqAmnsUmQHxARhoypVNPt(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
