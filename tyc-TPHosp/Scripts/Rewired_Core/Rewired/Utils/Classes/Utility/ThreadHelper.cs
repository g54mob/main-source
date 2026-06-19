using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint fJlDKKDkREnQwUFFRvEEQHIzmlgx = 750u;

		private readonly Stopwatch XQucoPWvfKAwRktHPAoAAjPtEEWF;

		private Thread byleSGZFcwgUJDntkRImTcwmoehC;

		private ManualResetEvent DJgdYDLusVqTgsmSAAWcPSOfOuK;

		private ManualResetEvent IBAolKinNTXJozyyNckDjpshrNz;

		private AutoResetEvent VqZeXGUKKbMBNZBrLcfWiAgADrrC;

		private bool jkycZmApKTuCqWwffadDmEvlSwx;

		private bool sFnYxABJDbPleWSKfAybWTjhabq;

		private int KRtGcdKCWCeITMyUPINwczSncSvY;

		private bool aTQGAYViLwkNzYMFXCFrKQJRUFZq;

		private int lTTGsvKnaxhNlZVuTXDdVaUWoHui;

		private long AifyTKuoPsUZyKUZeqsqzNCjBKVb;

		private bool idALljpXHpKVKrDGGyResXIqJYN;

		private int pujfKAJiOLeyWyRAbZTCMTESiBYh;

		private long kELmTcRIZivQawHQTpRKRTTovux;

		private uint SnWbXotCJgpfmqvzdftzXvdLejn;

		private readonly object LKZXiPBtduVyxgYAtFiSDmYKTZc;

		private Queue<Action> HjFtTiPlrKnTFxQYljwuPAqbmuo;

		private Queue<Action> cvZmoLBoWFSkcCXlEjQUoJwDrUC;

		private bool MTnehQLulODWpqQduAFxESvCeJP;

		private Action nqRckvFlGCfVubVcRvQBgbNXnzjp;

		private Action YZdGGzEXuEaIXWBUlVNefmJjZhjo;

		private Action WFISmfggDGhkymgHUuJYJblYkqx;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public bool isRunning => sFnYxABJDbPleWSKfAybWTjhabq;

		public bool isStopped
		{
			get
			{
				if (!sFnYxABJDbPleWSKfAybWTjhabq)
				{
					if (byleSGZFcwgUJDntkRImTcwmoehC == null)
					{
						return true;
					}
					return !byleSGZFcwgUJDntkRImTcwmoehC.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!aTQGAYViLwkNzYMFXCFrKQJRUFZq)
				{
					return (long)lTTGsvKnaxhNlZVuTXDdVaUWoHui >= 750L;
				}
				return true;
			}
			set
			{
				if (value != aTQGAYViLwkNzYMFXCFrKQJRUFZq)
				{
					aTQGAYViLwkNzYMFXCFrKQJRUFZq = value;
					dpzYzmVmuMfUTXvqcrXKacLViNU();
				}
			}
		}

		public bool useFixedTimeStep => idALljpXHpKVKrDGGyResXIqJYN;

		public int fixedTimeStepFPS
		{
			get
			{
				return lTTGsvKnaxhNlZVuTXDdVaUWoHui;
			}
			set
			{
				lTTGsvKnaxhNlZVuTXDdVaUWoHui = ((value > 0) ? value : 0);
				dpzYzmVmuMfUTXvqcrXKacLViNU();
			}
		}

		public int timeoutMS
		{
			get
			{
				return pujfKAJiOLeyWyRAbZTCMTESiBYh;
			}
			set
			{
				pujfKAJiOLeyWyRAbZTCMTESiBYh = ((value > 0) ? value : 0);
				dpzYzmVmuMfUTXvqcrXKacLViNU();
			}
		}

		public uint tick => SnWbXotCJgpfmqvzdftzXvdLejn;

		public event Action ThreadUpdateEvent
		{
			add
			{
				nqRckvFlGCfVubVcRvQBgbNXnzjp = (Action)Delegate.Combine(nqRckvFlGCfVubVcRvQBgbNXnzjp, value);
			}
			remove
			{
				nqRckvFlGCfVubVcRvQBgbNXnzjp = (Action)Delegate.Remove(nqRckvFlGCfVubVcRvQBgbNXnzjp, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			add
			{
				Action action = YZdGGzEXuEaIXWBUlVNefmJjZhjo;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref YZdGGzEXuEaIXWBUlVNefmJjZhjo, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = YZdGGzEXuEaIXWBUlVNefmJjZhjo;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref YZdGGzEXuEaIXWBUlVNefmJjZhjo, value2, action2);
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
			add
			{
				Action action = WFISmfggDGhkymgHUuJYJblYkqx;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref WFISmfggDGhkymgHUuJYJblYkqx, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = WFISmfggDGhkymgHUuJYJblYkqx;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref WFISmfggDGhkymgHUuJYJblYkqx, value2, action2);
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

		private ThreadHelper(int timeoutMS)
			: this(0, useHighPrecisionTimer: false, timeoutMS)
		{
		}

		private ThreadHelper(int fixedTimeStepFPS, bool useHighPrecisionTimer, int timeoutMS)
		{
			XQucoPWvfKAwRktHPAoAAjPtEEWF = Stopwatch.Global;
			if (fixedTimeStepFPS < 0)
			{
				fixedTimeStepFPS = 0;
			}
			if (timeoutMS < 0)
			{
				timeoutMS = 0;
			}
			pujfKAJiOLeyWyRAbZTCMTESiBYh = timeoutMS;
			lTTGsvKnaxhNlZVuTXDdVaUWoHui = fixedTimeStepFPS;
			aTQGAYViLwkNzYMFXCFrKQJRUFZq = useHighPrecisionTimer;
			dpzYzmVmuMfUTXvqcrXKacLViNU();
			DJgdYDLusVqTgsmSAAWcPSOfOuK = new ManualResetEvent(initialState: false);
			IBAolKinNTXJozyyNckDjpshrNz = new ManualResetEvent(initialState: false);
			VqZeXGUKKbMBNZBrLcfWiAgADrrC = new AutoResetEvent(initialState: false);
			LKZXiPBtduVyxgYAtFiSDmYKTZc = new object();
			HjFtTiPlrKnTFxQYljwuPAqbmuo = new Queue<Action>();
			cvZmoLBoWFSkcCXlEjQUoJwDrUC = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (sFnYxABJDbPleWSKfAybWTjhabq)
			{
				return false;
			}
			try
			{
				DJgdYDLusVqTgsmSAAWcPSOfOuK.Reset();
				VqZeXGUKKbMBNZBrLcfWiAgADrrC.Reset();
				byleSGZFcwgUJDntkRImTcwmoehC = new Thread(coKJbTFgVRGfoITRBEpaDxanrTO);
				byleSGZFcwgUJDntkRImTcwmoehC.Start();
				if (wait)
				{
					DJgdYDLusVqTgsmSAAWcPSOfOuK.WaitOne();
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
			if (byleSGZFcwgUJDntkRImTcwmoehC != null && sFnYxABJDbPleWSKfAybWTjhabq && jkycZmApKTuCqWwffadDmEvlSwx)
			{
				DJgdYDLusVqTgsmSAAWcPSOfOuK.Reset();
				jkycZmApKTuCqWwffadDmEvlSwx = false;
				VqZeXGUKKbMBNZBrLcfWiAgADrrC.Set();
				if (wait)
				{
					DJgdYDLusVqTgsmSAAWcPSOfOuK.WaitOne();
				}
				sQOZyACQNEauvjgVcNCmUCXMaLX();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!sFnYxABJDbPleWSKfAybWTjhabq)
			{
				return false;
			}
			if (!jkycZmApKTuCqWwffadDmEvlSwx)
			{
				return false;
			}
			ResetTimeout();
			lock (LKZXiPBtduVyxgYAtFiSDmYKTZc)
			{
				HjFtTiPlrKnTFxQYljwuPAqbmuo.Enqueue(action);
				MTnehQLulODWpqQduAFxESvCeJP = true;
				VqZeXGUKKbMBNZBrLcfWiAgADrrC.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!sFnYxABJDbPleWSKfAybWTjhabq)
			{
				return false;
			}
			if (!jkycZmApKTuCqWwffadDmEvlSwx)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!sFnYxABJDbPleWSKfAybWTjhabq || !jkycZmApKTuCqWwffadDmEvlSwx)
			{
				return;
			}
			ResetTimeout();
			lock (LKZXiPBtduVyxgYAtFiSDmYKTZc)
			{
				IBAolKinNTXJozyyNckDjpshrNz.Reset();
				KRtGcdKCWCeITMyUPINwczSncSvY++;
			}
			VqZeXGUKKbMBNZBrLcfWiAgADrrC.Set();
			IBAolKinNTXJozyyNckDjpshrNz.WaitOne();
			lock (LKZXiPBtduVyxgYAtFiSDmYKTZc)
			{
				KRtGcdKCWCeITMyUPINwczSncSvY--;
			}
		}

		public void ResetTimeout()
		{
			kELmTcRIZivQawHQTpRKRTTovux = ((pujfKAJiOLeyWyRAbZTCMTESiBYh > 0) ? (XQucoPWvfKAwRktHPAoAAjPtEEWF.elapsedMillisecondsRaw + pujfKAJiOLeyWyRAbZTCMTESiBYh) : 0);
		}

		private void coKJbTFgVRGfoITRBEpaDxanrTO()
		{
			ResetTimeout();
			sFnYxABJDbPleWSKfAybWTjhabq = true;
			jkycZmApKTuCqWwffadDmEvlSwx = true;
			DJgdYDLusVqTgsmSAAWcPSOfOuK.Set();
			if (YZdGGzEXuEaIXWBUlVNefmJjZhjo != null)
			{
				lock (YZdGGzEXuEaIXWBUlVNefmJjZhjo)
				{
					try
					{
						YZdGGzEXuEaIXWBUlVNefmJjZhjo();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (jkycZmApKTuCqWwffadDmEvlSwx)
			{
				long elapsedTicksRaw = XQucoPWvfKAwRktHPAoAAjPtEEWF.elapsedTicksRaw;
				long num = elapsedTicksRaw + AifyTKuoPsUZyKUZeqsqzNCjBKVb;
				CVFJzAeUNWowjnVnGqPvOIvQQjf();
				lock (LKZXiPBtduVyxgYAtFiSDmYKTZc)
				{
					if (!MTnehQLulODWpqQduAFxESvCeJP && KRtGcdKCWCeITMyUPINwczSncSvY > 0)
					{
						IBAolKinNTXJozyyNckDjpshrNz.Set();
					}
				}
				if (nqRckvFlGCfVubVcRvQBgbNXnzjp != null)
				{
					try
					{
						nqRckvFlGCfVubVcRvQBgbNXnzjp();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (idALljpXHpKVKrDGGyResXIqJYN)
				{
					if (aTQGAYViLwkNzYMFXCFrKQJRUFZq || (long)lTTGsvKnaxhNlZVuTXDdVaUWoHui >= 750L)
					{
						while (XQucoPWvfKAwRktHPAoAAjPtEEWF.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - XQucoPWvfKAwRktHPAoAAjPtEEWF.elapsedTicksRaw;
						if (num2 > 0)
						{
							VqZeXGUKKbMBNZBrLcfWiAgADrrC.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				SnWbXotCJgpfmqvzdftzXvdLejn = ((SnWbXotCJgpfmqvzdftzXvdLejn != uint.MaxValue) ? (SnWbXotCJgpfmqvzdftzXvdLejn + 1) : 0u);
				if (pujfKAJiOLeyWyRAbZTCMTESiBYh > 0 && XQucoPWvfKAwRktHPAoAAjPtEEWF.elapsedMillisecondsRaw >= kELmTcRIZivQawHQTpRKRTTovux)
				{
					jkycZmApKTuCqWwffadDmEvlSwx = false;
				}
			}
			if (WFISmfggDGhkymgHUuJYJblYkqx != null)
			{
				lock (WFISmfggDGhkymgHUuJYJblYkqx)
				{
					try
					{
						WFISmfggDGhkymgHUuJYJblYkqx();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			sFnYxABJDbPleWSKfAybWTjhabq = false;
			DJgdYDLusVqTgsmSAAWcPSOfOuK.Set();
		}

		private void CVFJzAeUNWowjnVnGqPvOIvQQjf()
		{
			if (!MTnehQLulODWpqQduAFxESvCeJP)
			{
				return;
			}
			lock (LKZXiPBtduVyxgYAtFiSDmYKTZc)
			{
				MiscTools.Swap(ref HjFtTiPlrKnTFxQYljwuPAqbmuo, ref cvZmoLBoWFSkcCXlEjQUoJwDrUC);
				MTnehQLulODWpqQduAFxESvCeJP = false;
			}
			while (cvZmoLBoWFSkcCXlEjQUoJwDrUC.Count > 0)
			{
				Action action = cvZmoLBoWFSkcCXlEjQUoJwDrUC.Dequeue();
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

		private void dpzYzmVmuMfUTXvqcrXKacLViNU()
		{
			if (lTTGsvKnaxhNlZVuTXDdVaUWoHui <= 0)
			{
				idALljpXHpKVKrDGGyResXIqJYN = false;
			}
			else
			{
				idALljpXHpKVKrDGGyResXIqJYN = true;
				AifyTKuoPsUZyKUZeqsqzNCjBKVb = Stopwatch.frequency / lTTGsvKnaxhNlZVuTXDdVaUWoHui;
			}
			ResetTimeout();
		}

		private void sQOZyACQNEauvjgVcNCmUCXMaLX()
		{
			byleSGZFcwgUJDntkRImTcwmoehC = null;
			sFnYxABJDbPleWSKfAybWTjhabq = false;
			jkycZmApKTuCqWwffadDmEvlSwx = false;
			HjFtTiPlrKnTFxQYljwuPAqbmuo.Clear();
			cvZmoLBoWFSkcCXlEjQUoJwDrUC.Clear();
			MTnehQLulODWpqQduAFxESvCeJP = false;
			KRtGcdKCWCeITMyUPINwczSncSvY = 0;
			DJgdYDLusVqTgsmSAAWcPSOfOuK.Reset();
			IBAolKinNTXJozyyNckDjpshrNz.Reset();
			kELmTcRIZivQawHQTpRKRTTovux = 0L;
			SnWbXotCJgpfmqvzdftzXvdLejn = 0u;
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
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					jkycZmApKTuCqWwffadDmEvlSwx = false;
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void friSOwjhseYceSUsZOqfjRVcHvr(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
