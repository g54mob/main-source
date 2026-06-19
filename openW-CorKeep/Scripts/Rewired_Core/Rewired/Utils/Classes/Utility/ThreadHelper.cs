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
		private const uint XIKNDqWLELixiUewKJsLGZcXseDf = 750u;

		private readonly Stopwatch LfytHrmjUbhBJhtxKMBoFNWwIhsLA;

		private Thread LemCrGFbDKRfZbauDYAVIsdNcjgXB;

		private ManualResetEvent KDHfLwYqmzEeywFVMEhPFEwQRYil;

		private ManualResetEvent cPBNepeEKxyzGMPGbFuaddULFVef;

		private AutoResetEvent mJJXKlFHeUUpqDoyDMKRDOTGgMciA;

		private bool tDuFTbbEKKTgVOdTJpwVecCdUMHWA;

		private bool zAqLgBDenvBMQAMydZwWJrVOMbKqA;

		private int wNnENTpfLxIqcERPMAKlvXWRGXgrA;

		private bool qZSrGAKRUrwHcdFNRVKEsuxQrsrn;

		private int kKKnjtScSUNvDgJTetpsQDrItszm;

		private long BbzHwnaMdHUnVtsjEZvRahztLcDJA;

		private bool OGCAgUOStbJvYKLFaHSYXoxWCuwh;

		private int iikTvYwZZlQivwyTZqvCNgWxRbcn;

		private long QogKLzeDNSNboWeIVGxUVEyDlzMl;

		private uint QpMzLEApxUPENoUJeacnTZDsGcaS;

		private readonly object DDVHkXbttJYTkKqtTcYIFfoFpHPqb;

		private Queue<Action> QvBhtTzsqkBhWsQcqlSZnTFywwAg;

		private Queue<Action> RuADEuyWqjSUIsnGJrfhAKFJZMcQ;

		private bool zwJvUVAmsHpLAOsObCSIUsnWPLYx;

		private Action SOTjPrubNxcZSiwpUrAwZWwSFimiA;

		[CompilerGenerated]
		private Action BIEUetsYNIcEebnkYMeuBdTSmQPv;

		[CompilerGenerated]
		private Action FlmjaFaNsKHhlOAgdcoYebNMwypX;

		private bool bCKVJQrEpYbtreymyTxCYlqmWSWO;

		public bool isRunning => zAqLgBDenvBMQAMydZwWJrVOMbKqA;

		public bool isStopped
		{
			get
			{
				if (!zAqLgBDenvBMQAMydZwWJrVOMbKqA)
				{
					if (LemCrGFbDKRfZbauDYAVIsdNcjgXB == null)
					{
						return true;
					}
					return !LemCrGFbDKRfZbauDYAVIsdNcjgXB.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!qZSrGAKRUrwHcdFNRVKEsuxQrsrn)
				{
					return (long)kKKnjtScSUNvDgJTetpsQDrItszm >= 750L;
				}
				return true;
			}
			set
			{
				if (value != qZSrGAKRUrwHcdFNRVKEsuxQrsrn)
				{
					qZSrGAKRUrwHcdFNRVKEsuxQrsrn = value;
					nxbHQsaeWcmzmipwqkwfdulPVCNs();
				}
			}
		}

		public bool useFixedTimeStep => OGCAgUOStbJvYKLFaHSYXoxWCuwh;

		public int fixedTimeStepFPS
		{
			get
			{
				return kKKnjtScSUNvDgJTetpsQDrItszm;
			}
			set
			{
				kKKnjtScSUNvDgJTetpsQDrItszm = ((value > 0) ? value : 0);
				nxbHQsaeWcmzmipwqkwfdulPVCNs();
			}
		}

		public int timeoutMS
		{
			get
			{
				return iikTvYwZZlQivwyTZqvCNgWxRbcn;
			}
			set
			{
				iikTvYwZZlQivwyTZqvCNgWxRbcn = ((value > 0) ? value : 0);
				nxbHQsaeWcmzmipwqkwfdulPVCNs();
			}
		}

		public uint tick => QpMzLEApxUPENoUJeacnTZDsGcaS;

		public event Action ThreadUpdateEvent
		{
			add
			{
				SOTjPrubNxcZSiwpUrAwZWwSFimiA = (Action)Delegate.Combine(SOTjPrubNxcZSiwpUrAwZWwSFimiA, value);
			}
			remove
			{
				SOTjPrubNxcZSiwpUrAwZWwSFimiA = (Action)Delegate.Remove(SOTjPrubNxcZSiwpUrAwZWwSFimiA, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = BIEUetsYNIcEebnkYMeuBdTSmQPv;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref BIEUetsYNIcEebnkYMeuBdTSmQPv, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = BIEUetsYNIcEebnkYMeuBdTSmQPv;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref BIEUetsYNIcEebnkYMeuBdTSmQPv, value2, action2);
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
				Action action = FlmjaFaNsKHhlOAgdcoYebNMwypX;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref FlmjaFaNsKHhlOAgdcoYebNMwypX, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = FlmjaFaNsKHhlOAgdcoYebNMwypX;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref FlmjaFaNsKHhlOAgdcoYebNMwypX, value2, action2);
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
			LfytHrmjUbhBJhtxKMBoFNWwIhsLA = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			iikTvYwZZlQivwyTZqvCNgWxRbcn = P_2;
			kKKnjtScSUNvDgJTetpsQDrItszm = P_0;
			qZSrGAKRUrwHcdFNRVKEsuxQrsrn = P_1;
			nxbHQsaeWcmzmipwqkwfdulPVCNs();
			KDHfLwYqmzEeywFVMEhPFEwQRYil = new ManualResetEvent(initialState: false);
			cPBNepeEKxyzGMPGbFuaddULFVef = new ManualResetEvent(initialState: false);
			mJJXKlFHeUUpqDoyDMKRDOTGgMciA = new AutoResetEvent(initialState: false);
			DDVHkXbttJYTkKqtTcYIFfoFpHPqb = new object();
			QvBhtTzsqkBhWsQcqlSZnTFywwAg = new Queue<Action>();
			RuADEuyWqjSUIsnGJrfhAKFJZMcQ = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (zAqLgBDenvBMQAMydZwWJrVOMbKqA)
			{
				return false;
			}
			try
			{
				KDHfLwYqmzEeywFVMEhPFEwQRYil.Reset();
				mJJXKlFHeUUpqDoyDMKRDOTGgMciA.Reset();
				LemCrGFbDKRfZbauDYAVIsdNcjgXB = new Thread(QJTDUGxPtVaESGaSGUqxsTWiPSnEA);
				LemCrGFbDKRfZbauDYAVIsdNcjgXB.Start();
				if (wait)
				{
					KDHfLwYqmzEeywFVMEhPFEwQRYil.WaitOne();
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
			if (LemCrGFbDKRfZbauDYAVIsdNcjgXB != null && zAqLgBDenvBMQAMydZwWJrVOMbKqA && tDuFTbbEKKTgVOdTJpwVecCdUMHWA)
			{
				KDHfLwYqmzEeywFVMEhPFEwQRYil.Reset();
				tDuFTbbEKKTgVOdTJpwVecCdUMHWA = false;
				mJJXKlFHeUUpqDoyDMKRDOTGgMciA.Set();
				if (wait)
				{
					KDHfLwYqmzEeywFVMEhPFEwQRYil.WaitOne();
				}
				wvprcNrvYFQULTvZhvIMbuVPrPpm();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!zAqLgBDenvBMQAMydZwWJrVOMbKqA)
			{
				return false;
			}
			if (!tDuFTbbEKKTgVOdTJpwVecCdUMHWA)
			{
				return false;
			}
			ResetTimeout();
			lock (DDVHkXbttJYTkKqtTcYIFfoFpHPqb)
			{
				QvBhtTzsqkBhWsQcqlSZnTFywwAg.Enqueue(action);
				zwJvUVAmsHpLAOsObCSIUsnWPLYx = true;
				mJJXKlFHeUUpqDoyDMKRDOTGgMciA.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!zAqLgBDenvBMQAMydZwWJrVOMbKqA)
			{
				return false;
			}
			if (!tDuFTbbEKKTgVOdTJpwVecCdUMHWA)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!zAqLgBDenvBMQAMydZwWJrVOMbKqA || !tDuFTbbEKKTgVOdTJpwVecCdUMHWA)
			{
				return;
			}
			ResetTimeout();
			lock (DDVHkXbttJYTkKqtTcYIFfoFpHPqb)
			{
				cPBNepeEKxyzGMPGbFuaddULFVef.Reset();
				wNnENTpfLxIqcERPMAKlvXWRGXgrA++;
			}
			mJJXKlFHeUUpqDoyDMKRDOTGgMciA.Set();
			cPBNepeEKxyzGMPGbFuaddULFVef.WaitOne();
			lock (DDVHkXbttJYTkKqtTcYIFfoFpHPqb)
			{
				wNnENTpfLxIqcERPMAKlvXWRGXgrA--;
			}
		}

		public void ResetTimeout()
		{
			QogKLzeDNSNboWeIVGxUVEyDlzMl = ((iikTvYwZZlQivwyTZqvCNgWxRbcn > 0) ? (LfytHrmjUbhBJhtxKMBoFNWwIhsLA.elapsedMillisecondsRaw + iikTvYwZZlQivwyTZqvCNgWxRbcn) : 0);
		}

		private void QJTDUGxPtVaESGaSGUqxsTWiPSnEA()
		{
			ResetTimeout();
			zAqLgBDenvBMQAMydZwWJrVOMbKqA = true;
			tDuFTbbEKKTgVOdTJpwVecCdUMHWA = true;
			KDHfLwYqmzEeywFVMEhPFEwQRYil.Set();
			if (BIEUetsYNIcEebnkYMeuBdTSmQPv != null)
			{
				lock (BIEUetsYNIcEebnkYMeuBdTSmQPv)
				{
					try
					{
						BIEUetsYNIcEebnkYMeuBdTSmQPv();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (tDuFTbbEKKTgVOdTJpwVecCdUMHWA)
			{
				long num = LfytHrmjUbhBJhtxKMBoFNWwIhsLA.elapsedTicksRaw + BbzHwnaMdHUnVtsjEZvRahztLcDJA;
				pSnbrPBiWSEmlYsVxFxjulOWuulJA();
				lock (DDVHkXbttJYTkKqtTcYIFfoFpHPqb)
				{
					if (!zwJvUVAmsHpLAOsObCSIUsnWPLYx && wNnENTpfLxIqcERPMAKlvXWRGXgrA > 0)
					{
						cPBNepeEKxyzGMPGbFuaddULFVef.Set();
					}
				}
				if (SOTjPrubNxcZSiwpUrAwZWwSFimiA != null)
				{
					try
					{
						SOTjPrubNxcZSiwpUrAwZWwSFimiA();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (OGCAgUOStbJvYKLFaHSYXoxWCuwh)
				{
					if (qZSrGAKRUrwHcdFNRVKEsuxQrsrn || (long)kKKnjtScSUNvDgJTetpsQDrItszm >= 750L)
					{
						while (LfytHrmjUbhBJhtxKMBoFNWwIhsLA.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - LfytHrmjUbhBJhtxKMBoFNWwIhsLA.elapsedTicksRaw;
						if (num2 > 0)
						{
							mJJXKlFHeUUpqDoyDMKRDOTGgMciA.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				QpMzLEApxUPENoUJeacnTZDsGcaS = ((QpMzLEApxUPENoUJeacnTZDsGcaS != uint.MaxValue) ? (QpMzLEApxUPENoUJeacnTZDsGcaS + 1) : 0u);
				if (iikTvYwZZlQivwyTZqvCNgWxRbcn > 0 && LfytHrmjUbhBJhtxKMBoFNWwIhsLA.elapsedMillisecondsRaw >= QogKLzeDNSNboWeIVGxUVEyDlzMl)
				{
					tDuFTbbEKKTgVOdTJpwVecCdUMHWA = false;
				}
			}
			if (FlmjaFaNsKHhlOAgdcoYebNMwypX != null)
			{
				lock (FlmjaFaNsKHhlOAgdcoYebNMwypX)
				{
					try
					{
						FlmjaFaNsKHhlOAgdcoYebNMwypX();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			zAqLgBDenvBMQAMydZwWJrVOMbKqA = false;
			KDHfLwYqmzEeywFVMEhPFEwQRYil.Set();
		}

		private void pSnbrPBiWSEmlYsVxFxjulOWuulJA()
		{
			if (!zwJvUVAmsHpLAOsObCSIUsnWPLYx)
			{
				return;
			}
			lock (DDVHkXbttJYTkKqtTcYIFfoFpHPqb)
			{
				MiscTools.Swap(ref QvBhtTzsqkBhWsQcqlSZnTFywwAg, ref RuADEuyWqjSUIsnGJrfhAKFJZMcQ);
				zwJvUVAmsHpLAOsObCSIUsnWPLYx = false;
			}
			while (RuADEuyWqjSUIsnGJrfhAKFJZMcQ.Count > 0)
			{
				Action action = RuADEuyWqjSUIsnGJrfhAKFJZMcQ.Dequeue();
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

		private void nxbHQsaeWcmzmipwqkwfdulPVCNs()
		{
			if (kKKnjtScSUNvDgJTetpsQDrItszm <= 0)
			{
				OGCAgUOStbJvYKLFaHSYXoxWCuwh = false;
			}
			else
			{
				OGCAgUOStbJvYKLFaHSYXoxWCuwh = true;
				BbzHwnaMdHUnVtsjEZvRahztLcDJA = Stopwatch.frequency / kKKnjtScSUNvDgJTetpsQDrItszm;
			}
			ResetTimeout();
		}

		private void wvprcNrvYFQULTvZhvIMbuVPrPpm()
		{
			LemCrGFbDKRfZbauDYAVIsdNcjgXB = null;
			zAqLgBDenvBMQAMydZwWJrVOMbKqA = false;
			tDuFTbbEKKTgVOdTJpwVecCdUMHWA = false;
			QvBhtTzsqkBhWsQcqlSZnTFywwAg.Clear();
			RuADEuyWqjSUIsnGJrfhAKFJZMcQ.Clear();
			zwJvUVAmsHpLAOsObCSIUsnWPLYx = false;
			wNnENTpfLxIqcERPMAKlvXWRGXgrA = 0;
			KDHfLwYqmzEeywFVMEhPFEwQRYil.Reset();
			cPBNepeEKxyzGMPGbFuaddULFVef.Reset();
			QogKLzeDNSNboWeIVGxUVEyDlzMl = 0L;
			QpMzLEApxUPENoUJeacnTZDsGcaS = 0u;
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
			if (!bCKVJQrEpYbtreymyTxCYlqmWSWO)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					tDuFTbbEKKTgVOdTJpwVecCdUMHWA = false;
				}
				bCKVJQrEpYbtreymyTxCYlqmWSWO = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void BAowPCenVOieTKJxoQrRwyFouUUN(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
