using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint JspaHAGVJzcaBxLhzPLTvEhVQjMn = 750u;

		private readonly Stopwatch jUqrsDggbviCoWsphvjFZmkVJMcp;

		private Thread FBhTBCloRTksrXPdIRhzYVUCiBYB;

		private ManualResetEvent bSoBBJzRwqblLgAesPDzGndDRqymA;

		private ManualResetEvent maCknMUdRkxDNLXShjwIDlHHFjLH;

		private AutoResetEvent rTVXpYaIQQbwcrXPpIwDWITkNnBu;

		private bool ZYgoxauGvkPUDaRCBKzWSEOVmOXM;

		private bool QWrXDKvVVUfbZepgRxFscxCRguIx;

		private int aUttOpcyClosmMDavQCfPxzHIeZf;

		private bool KEQJYCdRUTzMAynqbQsRggApLhpB;

		private int PvTjpxDwwMrDYzzAjOImGEbqaDEM;

		private long aEdIKWCPHPfpFiltEhBzJlUPWbjG;

		private bool SWIcpLPPQjibFRcsqljTUbKMJtpA;

		private int FsjXHQMeUeCXxvyiDChHagbaLTyJ;

		private long ShNPjelvBDvBXORmnmcDzhiOgpHDA;

		private uint uySNooRqGDxRLKUDViuktBQbocHu;

		private readonly object pcTbIRpUdBOUGMfsDSYZvrpkLqEi;

		private Queue<Action> juJxoaxgprmRuRkoJhgvzORLGoIV;

		private Queue<Action> ArZlqDpHKysqJkZTmgpTWeZtdVwj;

		private bool aqrhpdzbyntpjAfuOuVmmmpqyszS;

		private Action ZXDbhjEfYpwnLVfWdlPUJNunyrPqA;

		[CompilerGenerated]
		private Action sCdVqprZyhsjwfqcPIbtOygXlOPj;

		[CompilerGenerated]
		private Action iDKoJdUXDzwHHWZfwpfVpqAgmgZn;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool isRunning => QWrXDKvVVUfbZepgRxFscxCRguIx;

		public bool isStopped
		{
			get
			{
				if (!QWrXDKvVVUfbZepgRxFscxCRguIx)
				{
					if (FBhTBCloRTksrXPdIRhzYVUCiBYB == null)
					{
						return true;
					}
					return !FBhTBCloRTksrXPdIRhzYVUCiBYB.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!KEQJYCdRUTzMAynqbQsRggApLhpB)
				{
					return (long)PvTjpxDwwMrDYzzAjOImGEbqaDEM >= 750L;
				}
				return true;
			}
			set
			{
				if (value != KEQJYCdRUTzMAynqbQsRggApLhpB)
				{
					KEQJYCdRUTzMAynqbQsRggApLhpB = value;
					HLdoEqzqcjPoylyOSkjNSgataryk();
				}
			}
		}

		public bool useFixedTimeStep => SWIcpLPPQjibFRcsqljTUbKMJtpA;

		public int fixedTimeStepFPS
		{
			get
			{
				return PvTjpxDwwMrDYzzAjOImGEbqaDEM;
			}
			set
			{
				PvTjpxDwwMrDYzzAjOImGEbqaDEM = ((value > 0) ? value : 0);
				HLdoEqzqcjPoylyOSkjNSgataryk();
			}
		}

		public int timeoutMS
		{
			get
			{
				return FsjXHQMeUeCXxvyiDChHagbaLTyJ;
			}
			set
			{
				FsjXHQMeUeCXxvyiDChHagbaLTyJ = ((value > 0) ? value : 0);
				HLdoEqzqcjPoylyOSkjNSgataryk();
			}
		}

		public uint tick => uySNooRqGDxRLKUDViuktBQbocHu;

		public event Action ThreadUpdateEvent
		{
			add
			{
				ZXDbhjEfYpwnLVfWdlPUJNunyrPqA = (Action)Delegate.Combine(ZXDbhjEfYpwnLVfWdlPUJNunyrPqA, value);
			}
			remove
			{
				ZXDbhjEfYpwnLVfWdlPUJNunyrPqA = (Action)Delegate.Remove(ZXDbhjEfYpwnLVfWdlPUJNunyrPqA, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = sCdVqprZyhsjwfqcPIbtOygXlOPj;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref sCdVqprZyhsjwfqcPIbtOygXlOPj, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = sCdVqprZyhsjwfqcPIbtOygXlOPj;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref sCdVqprZyhsjwfqcPIbtOygXlOPj, value2, action2);
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
				Action action = iDKoJdUXDzwHHWZfwpfVpqAgmgZn;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref iDKoJdUXDzwHHWZfwpfVpqAgmgZn, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = iDKoJdUXDzwHHWZfwpfVpqAgmgZn;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref iDKoJdUXDzwHHWZfwpfVpqAgmgZn, value2, action2);
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
			jUqrsDggbviCoWsphvjFZmkVJMcp = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			FsjXHQMeUeCXxvyiDChHagbaLTyJ = P_2;
			PvTjpxDwwMrDYzzAjOImGEbqaDEM = P_0;
			KEQJYCdRUTzMAynqbQsRggApLhpB = P_1;
			HLdoEqzqcjPoylyOSkjNSgataryk();
			bSoBBJzRwqblLgAesPDzGndDRqymA = new ManualResetEvent(initialState: false);
			maCknMUdRkxDNLXShjwIDlHHFjLH = new ManualResetEvent(initialState: false);
			rTVXpYaIQQbwcrXPpIwDWITkNnBu = new AutoResetEvent(initialState: false);
			pcTbIRpUdBOUGMfsDSYZvrpkLqEi = new object();
			juJxoaxgprmRuRkoJhgvzORLGoIV = new Queue<Action>();
			ArZlqDpHKysqJkZTmgpTWeZtdVwj = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (QWrXDKvVVUfbZepgRxFscxCRguIx)
			{
				return false;
			}
			try
			{
				bSoBBJzRwqblLgAesPDzGndDRqymA.Reset();
				rTVXpYaIQQbwcrXPpIwDWITkNnBu.Reset();
				FBhTBCloRTksrXPdIRhzYVUCiBYB = new Thread(WWKTUJtLPaAZRcvxvlqfhRRXqFgS);
				FBhTBCloRTksrXPdIRhzYVUCiBYB.Start();
				if (wait)
				{
					bSoBBJzRwqblLgAesPDzGndDRqymA.WaitOne();
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
			if (FBhTBCloRTksrXPdIRhzYVUCiBYB != null && QWrXDKvVVUfbZepgRxFscxCRguIx && ZYgoxauGvkPUDaRCBKzWSEOVmOXM)
			{
				bSoBBJzRwqblLgAesPDzGndDRqymA.Reset();
				ZYgoxauGvkPUDaRCBKzWSEOVmOXM = false;
				rTVXpYaIQQbwcrXPpIwDWITkNnBu.Set();
				if (wait)
				{
					bSoBBJzRwqblLgAesPDzGndDRqymA.WaitOne();
				}
				ChSGQysrQdGIBXwKGwUXspnaSifV();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!QWrXDKvVVUfbZepgRxFscxCRguIx)
			{
				return false;
			}
			if (!ZYgoxauGvkPUDaRCBKzWSEOVmOXM)
			{
				return false;
			}
			ResetTimeout();
			lock (pcTbIRpUdBOUGMfsDSYZvrpkLqEi)
			{
				juJxoaxgprmRuRkoJhgvzORLGoIV.Enqueue(action);
				aqrhpdzbyntpjAfuOuVmmmpqyszS = true;
				rTVXpYaIQQbwcrXPpIwDWITkNnBu.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!QWrXDKvVVUfbZepgRxFscxCRguIx)
			{
				return false;
			}
			if (!ZYgoxauGvkPUDaRCBKzWSEOVmOXM)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!QWrXDKvVVUfbZepgRxFscxCRguIx || !ZYgoxauGvkPUDaRCBKzWSEOVmOXM)
			{
				return;
			}
			ResetTimeout();
			lock (pcTbIRpUdBOUGMfsDSYZvrpkLqEi)
			{
				maCknMUdRkxDNLXShjwIDlHHFjLH.Reset();
				aUttOpcyClosmMDavQCfPxzHIeZf++;
			}
			rTVXpYaIQQbwcrXPpIwDWITkNnBu.Set();
			maCknMUdRkxDNLXShjwIDlHHFjLH.WaitOne();
			lock (pcTbIRpUdBOUGMfsDSYZvrpkLqEi)
			{
				aUttOpcyClosmMDavQCfPxzHIeZf--;
			}
		}

		public void ResetTimeout()
		{
			ShNPjelvBDvBXORmnmcDzhiOgpHDA = ((FsjXHQMeUeCXxvyiDChHagbaLTyJ > 0) ? (jUqrsDggbviCoWsphvjFZmkVJMcp.elapsedMillisecondsRaw + FsjXHQMeUeCXxvyiDChHagbaLTyJ) : 0);
		}

		private void WWKTUJtLPaAZRcvxvlqfhRRXqFgS()
		{
			ResetTimeout();
			QWrXDKvVVUfbZepgRxFscxCRguIx = true;
			ZYgoxauGvkPUDaRCBKzWSEOVmOXM = true;
			bSoBBJzRwqblLgAesPDzGndDRqymA.Set();
			if (sCdVqprZyhsjwfqcPIbtOygXlOPj != null)
			{
				lock (sCdVqprZyhsjwfqcPIbtOygXlOPj)
				{
					try
					{
						sCdVqprZyhsjwfqcPIbtOygXlOPj();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (ZYgoxauGvkPUDaRCBKzWSEOVmOXM)
			{
				long num = jUqrsDggbviCoWsphvjFZmkVJMcp.elapsedTicksRaw + aEdIKWCPHPfpFiltEhBzJlUPWbjG;
				iEFtIGULJbPUYHpTaavmqQKiAMTw();
				lock (pcTbIRpUdBOUGMfsDSYZvrpkLqEi)
				{
					if (!aqrhpdzbyntpjAfuOuVmmmpqyszS && aUttOpcyClosmMDavQCfPxzHIeZf > 0)
					{
						maCknMUdRkxDNLXShjwIDlHHFjLH.Set();
					}
				}
				if (ZXDbhjEfYpwnLVfWdlPUJNunyrPqA != null)
				{
					try
					{
						ZXDbhjEfYpwnLVfWdlPUJNunyrPqA();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (SWIcpLPPQjibFRcsqljTUbKMJtpA)
				{
					if (KEQJYCdRUTzMAynqbQsRggApLhpB || (long)PvTjpxDwwMrDYzzAjOImGEbqaDEM >= 750L)
					{
						while (jUqrsDggbviCoWsphvjFZmkVJMcp.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - jUqrsDggbviCoWsphvjFZmkVJMcp.elapsedTicksRaw;
						if (num2 > 0)
						{
							rTVXpYaIQQbwcrXPpIwDWITkNnBu.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				uySNooRqGDxRLKUDViuktBQbocHu = ((uySNooRqGDxRLKUDViuktBQbocHu != uint.MaxValue) ? (uySNooRqGDxRLKUDViuktBQbocHu + 1) : 0u);
				if (FsjXHQMeUeCXxvyiDChHagbaLTyJ > 0 && jUqrsDggbviCoWsphvjFZmkVJMcp.elapsedMillisecondsRaw >= ShNPjelvBDvBXORmnmcDzhiOgpHDA)
				{
					ZYgoxauGvkPUDaRCBKzWSEOVmOXM = false;
				}
			}
			if (iDKoJdUXDzwHHWZfwpfVpqAgmgZn != null)
			{
				lock (iDKoJdUXDzwHHWZfwpfVpqAgmgZn)
				{
					try
					{
						iDKoJdUXDzwHHWZfwpfVpqAgmgZn();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			QWrXDKvVVUfbZepgRxFscxCRguIx = false;
			bSoBBJzRwqblLgAesPDzGndDRqymA.Set();
		}

		private void iEFtIGULJbPUYHpTaavmqQKiAMTw()
		{
			if (!aqrhpdzbyntpjAfuOuVmmmpqyszS)
			{
				return;
			}
			lock (pcTbIRpUdBOUGMfsDSYZvrpkLqEi)
			{
				MiscTools.Swap(ref juJxoaxgprmRuRkoJhgvzORLGoIV, ref ArZlqDpHKysqJkZTmgpTWeZtdVwj);
				aqrhpdzbyntpjAfuOuVmmmpqyszS = false;
			}
			while (ArZlqDpHKysqJkZTmgpTWeZtdVwj.Count > 0)
			{
				Action action = ArZlqDpHKysqJkZTmgpTWeZtdVwj.Dequeue();
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

		private void HLdoEqzqcjPoylyOSkjNSgataryk()
		{
			if (PvTjpxDwwMrDYzzAjOImGEbqaDEM <= 0)
			{
				SWIcpLPPQjibFRcsqljTUbKMJtpA = false;
			}
			else
			{
				SWIcpLPPQjibFRcsqljTUbKMJtpA = true;
				aEdIKWCPHPfpFiltEhBzJlUPWbjG = Stopwatch.frequency / PvTjpxDwwMrDYzzAjOImGEbqaDEM;
			}
			ResetTimeout();
		}

		private void ChSGQysrQdGIBXwKGwUXspnaSifV()
		{
			FBhTBCloRTksrXPdIRhzYVUCiBYB = null;
			QWrXDKvVVUfbZepgRxFscxCRguIx = false;
			ZYgoxauGvkPUDaRCBKzWSEOVmOXM = false;
			juJxoaxgprmRuRkoJhgvzORLGoIV.Clear();
			ArZlqDpHKysqJkZTmgpTWeZtdVwj.Clear();
			aqrhpdzbyntpjAfuOuVmmmpqyszS = false;
			aUttOpcyClosmMDavQCfPxzHIeZf = 0;
			bSoBBJzRwqblLgAesPDzGndDRqymA.Reset();
			maCknMUdRkxDNLXShjwIDlHHFjLH.Reset();
			ShNPjelvBDvBXORmnmcDzhiOgpHDA = 0L;
			uySNooRqGDxRLKUDViuktBQbocHu = 0u;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~ThreadHelper()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					ZYgoxauGvkPUDaRCBKzWSEOVmOXM = false;
				}
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void BIqHZUNWxZkeXyHwxqHvRhkOeNXz(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
