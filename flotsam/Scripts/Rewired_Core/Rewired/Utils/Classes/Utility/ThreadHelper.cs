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
		private const uint PhUJRhgcdHimGzmCJUGiRyBgrhPX = 750u;

		private readonly Stopwatch FcasXqUKerWDfMnXLaSJKvCNdkaAA;

		private Thread DZcklJFqpAFvxZvIVzFotbnLmucr;

		private ManualResetEvent WzLlrduGOfYQSXKzNwFuAKubDsqH;

		private ManualResetEvent onXPEiWQmlkowdrioIOLuJKuEtiG;

		private AutoResetEvent imJMYizvYQgrScjUOzLiCVFfWNoU;

		private bool hfqDPewhsWmwvMnbAGrarBAGXPHx;

		private bool nfceyMHtLjlMoZxGyRppBaVhIwWAb;

		private int stteTQDHhrRiCwynJyDMUQAovYiqA;

		private bool eeQUWJctupmBEYznGIFbxipxDtfAA;

		private int oiSyxymqmQblhRopdfaLFRpnittaA;

		private long DbvHkqscFBLplXbLFcyacitQazTuA;

		private bool CeWSMBuIRpREslGbxEMtYOrbjZmv;

		private int uDwPjVMZrzQwFFZvWqctOWSWFyem;

		private long SmaAraCSpYXmCrQiAavbOncmeJWf;

		private uint OkEoTXolNCCAlDLfnLtQCSJTMzaab;

		private readonly object PdZHsMJkDJbLOVgFYvLdsPaOUQZr;

		private Queue<Action> ARBzPSRAtuJUkXOEzeNcoDsXhBAE;

		private Queue<Action> DWvUxtKKztIgJVaWpgERFFuIJyZA;

		private bool xrHMMMeKIJbVyBbkmoVxgDbxPIKvA;

		private Action KnDeRcHWntZBcSNHFCJDAUoibvgac;

		[CompilerGenerated]
		private Action VfYQawIYvYBCCAsONanZKNZvFNTJ;

		[CompilerGenerated]
		private Action XjeegUeKGATvVtlGqnxlHuRztxpw;

		private bool tXQNJIXPVAfVsNSkzehdTkWNBYKc;

		public bool isRunning => nfceyMHtLjlMoZxGyRppBaVhIwWAb;

		public bool isStopped
		{
			get
			{
				if (!nfceyMHtLjlMoZxGyRppBaVhIwWAb)
				{
					if (DZcklJFqpAFvxZvIVzFotbnLmucr == null)
					{
						return true;
					}
					return !DZcklJFqpAFvxZvIVzFotbnLmucr.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!eeQUWJctupmBEYznGIFbxipxDtfAA)
				{
					return (long)oiSyxymqmQblhRopdfaLFRpnittaA >= 750L;
				}
				return true;
			}
			set
			{
				if (value != eeQUWJctupmBEYznGIFbxipxDtfAA)
				{
					eeQUWJctupmBEYznGIFbxipxDtfAA = value;
					fVnZOrIRaynvWZaWzfNKeYtuFVTj();
				}
			}
		}

		public bool useFixedTimeStep => CeWSMBuIRpREslGbxEMtYOrbjZmv;

		public int fixedTimeStepFPS
		{
			get
			{
				return oiSyxymqmQblhRopdfaLFRpnittaA;
			}
			set
			{
				oiSyxymqmQblhRopdfaLFRpnittaA = ((value > 0) ? value : 0);
				fVnZOrIRaynvWZaWzfNKeYtuFVTj();
			}
		}

		public int timeoutMS
		{
			get
			{
				return uDwPjVMZrzQwFFZvWqctOWSWFyem;
			}
			set
			{
				uDwPjVMZrzQwFFZvWqctOWSWFyem = ((value > 0) ? value : 0);
				fVnZOrIRaynvWZaWzfNKeYtuFVTj();
			}
		}

		public uint tick => OkEoTXolNCCAlDLfnLtQCSJTMzaab;

		public event Action ThreadUpdateEvent
		{
			add
			{
				KnDeRcHWntZBcSNHFCJDAUoibvgac = (Action)Delegate.Combine(KnDeRcHWntZBcSNHFCJDAUoibvgac, value);
			}
			remove
			{
				KnDeRcHWntZBcSNHFCJDAUoibvgac = (Action)Delegate.Remove(KnDeRcHWntZBcSNHFCJDAUoibvgac, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = VfYQawIYvYBCCAsONanZKNZvFNTJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref VfYQawIYvYBCCAsONanZKNZvFNTJ, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = VfYQawIYvYBCCAsONanZKNZvFNTJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref VfYQawIYvYBCCAsONanZKNZvFNTJ, value2, action2);
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
				Action action = XjeegUeKGATvVtlGqnxlHuRztxpw;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref XjeegUeKGATvVtlGqnxlHuRztxpw, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = XjeegUeKGATvVtlGqnxlHuRztxpw;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref XjeegUeKGATvVtlGqnxlHuRztxpw, value2, action2);
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
			FcasXqUKerWDfMnXLaSJKvCNdkaAA = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			uDwPjVMZrzQwFFZvWqctOWSWFyem = P_2;
			oiSyxymqmQblhRopdfaLFRpnittaA = P_0;
			eeQUWJctupmBEYznGIFbxipxDtfAA = P_1;
			fVnZOrIRaynvWZaWzfNKeYtuFVTj();
			WzLlrduGOfYQSXKzNwFuAKubDsqH = new ManualResetEvent(initialState: false);
			onXPEiWQmlkowdrioIOLuJKuEtiG = new ManualResetEvent(initialState: false);
			imJMYizvYQgrScjUOzLiCVFfWNoU = new AutoResetEvent(initialState: false);
			PdZHsMJkDJbLOVgFYvLdsPaOUQZr = new object();
			ARBzPSRAtuJUkXOEzeNcoDsXhBAE = new Queue<Action>();
			DWvUxtKKztIgJVaWpgERFFuIJyZA = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (nfceyMHtLjlMoZxGyRppBaVhIwWAb)
			{
				return false;
			}
			try
			{
				WzLlrduGOfYQSXKzNwFuAKubDsqH.Reset();
				imJMYizvYQgrScjUOzLiCVFfWNoU.Reset();
				DZcklJFqpAFvxZvIVzFotbnLmucr = new Thread(OJVgKXfDDVXUcuTwFKtIFCMZNPxRA);
				DZcklJFqpAFvxZvIVzFotbnLmucr.Start();
				if (wait)
				{
					WzLlrduGOfYQSXKzNwFuAKubDsqH.WaitOne();
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
			if (DZcklJFqpAFvxZvIVzFotbnLmucr != null && nfceyMHtLjlMoZxGyRppBaVhIwWAb && hfqDPewhsWmwvMnbAGrarBAGXPHx)
			{
				WzLlrduGOfYQSXKzNwFuAKubDsqH.Reset();
				hfqDPewhsWmwvMnbAGrarBAGXPHx = false;
				imJMYizvYQgrScjUOzLiCVFfWNoU.Set();
				if (wait)
				{
					WzLlrduGOfYQSXKzNwFuAKubDsqH.WaitOne();
				}
				qstjjSRIgLIfhyYxcoKdinVgwFlK();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!nfceyMHtLjlMoZxGyRppBaVhIwWAb)
			{
				return false;
			}
			if (!hfqDPewhsWmwvMnbAGrarBAGXPHx)
			{
				return false;
			}
			ResetTimeout();
			lock (PdZHsMJkDJbLOVgFYvLdsPaOUQZr)
			{
				ARBzPSRAtuJUkXOEzeNcoDsXhBAE.Enqueue(action);
				xrHMMMeKIJbVyBbkmoVxgDbxPIKvA = true;
				imJMYizvYQgrScjUOzLiCVFfWNoU.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!nfceyMHtLjlMoZxGyRppBaVhIwWAb)
			{
				return false;
			}
			if (!hfqDPewhsWmwvMnbAGrarBAGXPHx)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!nfceyMHtLjlMoZxGyRppBaVhIwWAb || !hfqDPewhsWmwvMnbAGrarBAGXPHx)
			{
				return;
			}
			ResetTimeout();
			lock (PdZHsMJkDJbLOVgFYvLdsPaOUQZr)
			{
				onXPEiWQmlkowdrioIOLuJKuEtiG.Reset();
				stteTQDHhrRiCwynJyDMUQAovYiqA++;
			}
			imJMYizvYQgrScjUOzLiCVFfWNoU.Set();
			onXPEiWQmlkowdrioIOLuJKuEtiG.WaitOne();
			lock (PdZHsMJkDJbLOVgFYvLdsPaOUQZr)
			{
				stteTQDHhrRiCwynJyDMUQAovYiqA--;
			}
		}

		public void ResetTimeout()
		{
			SmaAraCSpYXmCrQiAavbOncmeJWf = ((uDwPjVMZrzQwFFZvWqctOWSWFyem > 0) ? (FcasXqUKerWDfMnXLaSJKvCNdkaAA.elapsedMillisecondsRaw + uDwPjVMZrzQwFFZvWqctOWSWFyem) : 0);
		}

		private void OJVgKXfDDVXUcuTwFKtIFCMZNPxRA()
		{
			ResetTimeout();
			nfceyMHtLjlMoZxGyRppBaVhIwWAb = true;
			hfqDPewhsWmwvMnbAGrarBAGXPHx = true;
			WzLlrduGOfYQSXKzNwFuAKubDsqH.Set();
			if (VfYQawIYvYBCCAsONanZKNZvFNTJ != null)
			{
				lock (VfYQawIYvYBCCAsONanZKNZvFNTJ)
				{
					try
					{
						VfYQawIYvYBCCAsONanZKNZvFNTJ();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (hfqDPewhsWmwvMnbAGrarBAGXPHx)
			{
				long num = FcasXqUKerWDfMnXLaSJKvCNdkaAA.elapsedTicksRaw + DbvHkqscFBLplXbLFcyacitQazTuA;
				ptdGrWWLsQwrZXZjoqnEuACvpdnH();
				lock (PdZHsMJkDJbLOVgFYvLdsPaOUQZr)
				{
					if (!xrHMMMeKIJbVyBbkmoVxgDbxPIKvA && stteTQDHhrRiCwynJyDMUQAovYiqA > 0)
					{
						onXPEiWQmlkowdrioIOLuJKuEtiG.Set();
					}
				}
				if (KnDeRcHWntZBcSNHFCJDAUoibvgac != null)
				{
					try
					{
						KnDeRcHWntZBcSNHFCJDAUoibvgac();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (CeWSMBuIRpREslGbxEMtYOrbjZmv)
				{
					if (eeQUWJctupmBEYznGIFbxipxDtfAA || (long)oiSyxymqmQblhRopdfaLFRpnittaA >= 750L)
					{
						while (FcasXqUKerWDfMnXLaSJKvCNdkaAA.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - FcasXqUKerWDfMnXLaSJKvCNdkaAA.elapsedTicksRaw;
						if (num2 > 0)
						{
							imJMYizvYQgrScjUOzLiCVFfWNoU.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				OkEoTXolNCCAlDLfnLtQCSJTMzaab = ((OkEoTXolNCCAlDLfnLtQCSJTMzaab != uint.MaxValue) ? (OkEoTXolNCCAlDLfnLtQCSJTMzaab + 1) : 0u);
				if (uDwPjVMZrzQwFFZvWqctOWSWFyem > 0 && FcasXqUKerWDfMnXLaSJKvCNdkaAA.elapsedMillisecondsRaw >= SmaAraCSpYXmCrQiAavbOncmeJWf)
				{
					hfqDPewhsWmwvMnbAGrarBAGXPHx = false;
				}
			}
			if (XjeegUeKGATvVtlGqnxlHuRztxpw != null)
			{
				lock (XjeegUeKGATvVtlGqnxlHuRztxpw)
				{
					try
					{
						XjeegUeKGATvVtlGqnxlHuRztxpw();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			nfceyMHtLjlMoZxGyRppBaVhIwWAb = false;
			WzLlrduGOfYQSXKzNwFuAKubDsqH.Set();
		}

		private void ptdGrWWLsQwrZXZjoqnEuACvpdnH()
		{
			if (!xrHMMMeKIJbVyBbkmoVxgDbxPIKvA)
			{
				return;
			}
			lock (PdZHsMJkDJbLOVgFYvLdsPaOUQZr)
			{
				MiscTools.Swap(ref ARBzPSRAtuJUkXOEzeNcoDsXhBAE, ref DWvUxtKKztIgJVaWpgERFFuIJyZA);
				xrHMMMeKIJbVyBbkmoVxgDbxPIKvA = false;
			}
			while (DWvUxtKKztIgJVaWpgERFFuIJyZA.Count > 0)
			{
				Action action = DWvUxtKKztIgJVaWpgERFFuIJyZA.Dequeue();
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

		private void fVnZOrIRaynvWZaWzfNKeYtuFVTj()
		{
			if (oiSyxymqmQblhRopdfaLFRpnittaA <= 0)
			{
				CeWSMBuIRpREslGbxEMtYOrbjZmv = false;
			}
			else
			{
				CeWSMBuIRpREslGbxEMtYOrbjZmv = true;
				DbvHkqscFBLplXbLFcyacitQazTuA = Stopwatch.frequency / oiSyxymqmQblhRopdfaLFRpnittaA;
			}
			ResetTimeout();
		}

		private void qstjjSRIgLIfhyYxcoKdinVgwFlK()
		{
			DZcklJFqpAFvxZvIVzFotbnLmucr = null;
			nfceyMHtLjlMoZxGyRppBaVhIwWAb = false;
			hfqDPewhsWmwvMnbAGrarBAGXPHx = false;
			ARBzPSRAtuJUkXOEzeNcoDsXhBAE.Clear();
			DWvUxtKKztIgJVaWpgERFFuIJyZA.Clear();
			xrHMMMeKIJbVyBbkmoVxgDbxPIKvA = false;
			stteTQDHhrRiCwynJyDMUQAovYiqA = 0;
			WzLlrduGOfYQSXKzNwFuAKubDsqH.Reset();
			onXPEiWQmlkowdrioIOLuJKuEtiG.Reset();
			SmaAraCSpYXmCrQiAavbOncmeJWf = 0L;
			OkEoTXolNCCAlDLfnLtQCSJTMzaab = 0u;
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
			if (!tXQNJIXPVAfVsNSkzehdTkWNBYKc)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					hfqDPewhsWmwvMnbAGrarBAGXPHx = false;
				}
				tXQNJIXPVAfVsNSkzehdTkWNBYKc = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void ZwuPRXUWtQkcztOBpgyqzOJHsTQm(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
