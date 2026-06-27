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
		private const uint IwvpTmdRqPHApNYGwslicNABBDeCA = 750u;

		private readonly Stopwatch SdDLvfHInnfvWqNTiBxXCrZsIKHUA;

		private Thread EDPzZGKccMJUChrAauVuGcigOSBh;

		private ManualResetEvent DJoZrmbyHdkizltjmsTizGzURdXT;

		private ManualResetEvent tPuIJxPgfbJKXcZyLVnZPvRPAeBq;

		private AutoResetEvent dymcCpeLJYSZjQyKtloezoUUFjPz;

		private bool ayLBctpZtIUFOqPpjGdwSbNpvrgK;

		private bool kyXiwVyCJfihRDENTQDjZGyOOWle;

		private int tKMNzNGirlORfSbAaueYdTLVmZJC;

		private bool lzvQQCtzfjnIhoxHhmwfEksEBDQh;

		private int ppTbtqbtMKVIibnERHLPyoCRPOEA;

		private long CGOesxjlGFFmExTFoPTuPDebTGcJ;

		private bool NbxDKMzuQjdfDbDlWXnnoxkMdzROA;

		private int ffBArCNimnhIokzdjCDnRxVrqYJFA;

		private long VrHhEhTicOjvteLwdQHvFdnJUYtPA;

		private uint TYvTxGnyUUeHWlybEUJIlCGqBWFH;

		private readonly object MzmmGHMUUTfNrhBVdaGfJcnlkhok;

		private Queue<Action> RnughZBINmTvNtzASQJkPZUwITbsA;

		private Queue<Action> YitYUaFTRvQwBjzuzPTWqVIHnrDW;

		private bool wQocEXrcVJZfTZzeNbopsPkAqkbp;

		private Action XVwBwbToalnOZlXSiigBlbBQRcFg;

		[CompilerGenerated]
		private Action KevaivBryAjupeOAsBQBxCUOmxop;

		[CompilerGenerated]
		private Action GUVqvRPVVOHxsNCzBYEjNSwUJaAd;

		private bool ofrvHGSmWUjZyxoAIvLxulpqWtvx;

		public bool isRunning => kyXiwVyCJfihRDENTQDjZGyOOWle;

		public bool isStopped
		{
			get
			{
				if (!kyXiwVyCJfihRDENTQDjZGyOOWle)
				{
					if (EDPzZGKccMJUChrAauVuGcigOSBh == null)
					{
						return true;
					}
					return !EDPzZGKccMJUChrAauVuGcigOSBh.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!lzvQQCtzfjnIhoxHhmwfEksEBDQh)
				{
					return (long)ppTbtqbtMKVIibnERHLPyoCRPOEA >= 750L;
				}
				return true;
			}
			set
			{
				if (value != lzvQQCtzfjnIhoxHhmwfEksEBDQh)
				{
					lzvQQCtzfjnIhoxHhmwfEksEBDQh = value;
					sHMURgVdxsNXrbBKYOKCFKqNplmm();
				}
			}
		}

		public bool useFixedTimeStep => NbxDKMzuQjdfDbDlWXnnoxkMdzROA;

		public int fixedTimeStepFPS
		{
			get
			{
				return ppTbtqbtMKVIibnERHLPyoCRPOEA;
			}
			set
			{
				ppTbtqbtMKVIibnERHLPyoCRPOEA = ((value > 0) ? value : 0);
				sHMURgVdxsNXrbBKYOKCFKqNplmm();
			}
		}

		public int timeoutMS
		{
			get
			{
				return ffBArCNimnhIokzdjCDnRxVrqYJFA;
			}
			set
			{
				ffBArCNimnhIokzdjCDnRxVrqYJFA = ((value > 0) ? value : 0);
				sHMURgVdxsNXrbBKYOKCFKqNplmm();
			}
		}

		public uint tick => TYvTxGnyUUeHWlybEUJIlCGqBWFH;

		public event Action ThreadUpdateEvent
		{
			add
			{
				XVwBwbToalnOZlXSiigBlbBQRcFg = (Action)Delegate.Combine(XVwBwbToalnOZlXSiigBlbBQRcFg, value);
			}
			remove
			{
				XVwBwbToalnOZlXSiigBlbBQRcFg = (Action)Delegate.Remove(XVwBwbToalnOZlXSiigBlbBQRcFg, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = KevaivBryAjupeOAsBQBxCUOmxop;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref KevaivBryAjupeOAsBQBxCUOmxop, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = KevaivBryAjupeOAsBQBxCUOmxop;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref KevaivBryAjupeOAsBQBxCUOmxop, value2, action2);
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
				Action action = GUVqvRPVVOHxsNCzBYEjNSwUJaAd;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref GUVqvRPVVOHxsNCzBYEjNSwUJaAd, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = GUVqvRPVVOHxsNCzBYEjNSwUJaAd;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref GUVqvRPVVOHxsNCzBYEjNSwUJaAd, value2, action2);
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
			SdDLvfHInnfvWqNTiBxXCrZsIKHUA = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			ffBArCNimnhIokzdjCDnRxVrqYJFA = P_2;
			ppTbtqbtMKVIibnERHLPyoCRPOEA = P_0;
			lzvQQCtzfjnIhoxHhmwfEksEBDQh = P_1;
			sHMURgVdxsNXrbBKYOKCFKqNplmm();
			DJoZrmbyHdkizltjmsTizGzURdXT = new ManualResetEvent(initialState: false);
			tPuIJxPgfbJKXcZyLVnZPvRPAeBq = new ManualResetEvent(initialState: false);
			dymcCpeLJYSZjQyKtloezoUUFjPz = new AutoResetEvent(initialState: false);
			MzmmGHMUUTfNrhBVdaGfJcnlkhok = new object();
			RnughZBINmTvNtzASQJkPZUwITbsA = new Queue<Action>();
			YitYUaFTRvQwBjzuzPTWqVIHnrDW = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (kyXiwVyCJfihRDENTQDjZGyOOWle)
			{
				return false;
			}
			try
			{
				DJoZrmbyHdkizltjmsTizGzURdXT.Reset();
				dymcCpeLJYSZjQyKtloezoUUFjPz.Reset();
				EDPzZGKccMJUChrAauVuGcigOSBh = new Thread(JVaKRSASwXaFsjcAsCFQhLludBME);
				EDPzZGKccMJUChrAauVuGcigOSBh.Start();
				if (wait)
				{
					DJoZrmbyHdkizltjmsTizGzURdXT.WaitOne();
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
			if (EDPzZGKccMJUChrAauVuGcigOSBh != null && kyXiwVyCJfihRDENTQDjZGyOOWle && ayLBctpZtIUFOqPpjGdwSbNpvrgK)
			{
				DJoZrmbyHdkizltjmsTizGzURdXT.Reset();
				ayLBctpZtIUFOqPpjGdwSbNpvrgK = false;
				dymcCpeLJYSZjQyKtloezoUUFjPz.Set();
				if (wait)
				{
					DJoZrmbyHdkizltjmsTizGzURdXT.WaitOne();
				}
				tmGBxBEWfBoeQqUxFYLhPNELgWQVA();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!kyXiwVyCJfihRDENTQDjZGyOOWle)
			{
				return false;
			}
			if (!ayLBctpZtIUFOqPpjGdwSbNpvrgK)
			{
				return false;
			}
			ResetTimeout();
			lock (MzmmGHMUUTfNrhBVdaGfJcnlkhok)
			{
				RnughZBINmTvNtzASQJkPZUwITbsA.Enqueue(action);
				wQocEXrcVJZfTZzeNbopsPkAqkbp = true;
				dymcCpeLJYSZjQyKtloezoUUFjPz.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!kyXiwVyCJfihRDENTQDjZGyOOWle)
			{
				return false;
			}
			if (!ayLBctpZtIUFOqPpjGdwSbNpvrgK)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!kyXiwVyCJfihRDENTQDjZGyOOWle || !ayLBctpZtIUFOqPpjGdwSbNpvrgK)
			{
				return;
			}
			ResetTimeout();
			lock (MzmmGHMUUTfNrhBVdaGfJcnlkhok)
			{
				tPuIJxPgfbJKXcZyLVnZPvRPAeBq.Reset();
				tKMNzNGirlORfSbAaueYdTLVmZJC++;
			}
			dymcCpeLJYSZjQyKtloezoUUFjPz.Set();
			tPuIJxPgfbJKXcZyLVnZPvRPAeBq.WaitOne();
			lock (MzmmGHMUUTfNrhBVdaGfJcnlkhok)
			{
				tKMNzNGirlORfSbAaueYdTLVmZJC--;
			}
		}

		public void ResetTimeout()
		{
			VrHhEhTicOjvteLwdQHvFdnJUYtPA = ((ffBArCNimnhIokzdjCDnRxVrqYJFA > 0) ? (SdDLvfHInnfvWqNTiBxXCrZsIKHUA.elapsedMillisecondsRaw + ffBArCNimnhIokzdjCDnRxVrqYJFA) : 0);
		}

		private void JVaKRSASwXaFsjcAsCFQhLludBME()
		{
			ResetTimeout();
			kyXiwVyCJfihRDENTQDjZGyOOWle = true;
			ayLBctpZtIUFOqPpjGdwSbNpvrgK = true;
			DJoZrmbyHdkizltjmsTizGzURdXT.Set();
			if (KevaivBryAjupeOAsBQBxCUOmxop != null)
			{
				lock (KevaivBryAjupeOAsBQBxCUOmxop)
				{
					try
					{
						KevaivBryAjupeOAsBQBxCUOmxop();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (ayLBctpZtIUFOqPpjGdwSbNpvrgK)
			{
				long num = SdDLvfHInnfvWqNTiBxXCrZsIKHUA.elapsedTicksRaw + CGOesxjlGFFmExTFoPTuPDebTGcJ;
				ioExSZZSfSUzodcfRXqIPkFAZUEf();
				lock (MzmmGHMUUTfNrhBVdaGfJcnlkhok)
				{
					if (!wQocEXrcVJZfTZzeNbopsPkAqkbp && tKMNzNGirlORfSbAaueYdTLVmZJC > 0)
					{
						tPuIJxPgfbJKXcZyLVnZPvRPAeBq.Set();
					}
				}
				if (XVwBwbToalnOZlXSiigBlbBQRcFg != null)
				{
					try
					{
						XVwBwbToalnOZlXSiigBlbBQRcFg();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (NbxDKMzuQjdfDbDlWXnnoxkMdzROA)
				{
					if (lzvQQCtzfjnIhoxHhmwfEksEBDQh || (long)ppTbtqbtMKVIibnERHLPyoCRPOEA >= 750L)
					{
						while (SdDLvfHInnfvWqNTiBxXCrZsIKHUA.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - SdDLvfHInnfvWqNTiBxXCrZsIKHUA.elapsedTicksRaw;
						if (num2 > 0)
						{
							dymcCpeLJYSZjQyKtloezoUUFjPz.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				TYvTxGnyUUeHWlybEUJIlCGqBWFH = ((TYvTxGnyUUeHWlybEUJIlCGqBWFH != uint.MaxValue) ? (TYvTxGnyUUeHWlybEUJIlCGqBWFH + 1) : 0u);
				if (ffBArCNimnhIokzdjCDnRxVrqYJFA > 0 && SdDLvfHInnfvWqNTiBxXCrZsIKHUA.elapsedMillisecondsRaw >= VrHhEhTicOjvteLwdQHvFdnJUYtPA)
				{
					ayLBctpZtIUFOqPpjGdwSbNpvrgK = false;
				}
			}
			if (GUVqvRPVVOHxsNCzBYEjNSwUJaAd != null)
			{
				lock (GUVqvRPVVOHxsNCzBYEjNSwUJaAd)
				{
					try
					{
						GUVqvRPVVOHxsNCzBYEjNSwUJaAd();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			kyXiwVyCJfihRDENTQDjZGyOOWle = false;
			DJoZrmbyHdkizltjmsTizGzURdXT.Set();
		}

		private void ioExSZZSfSUzodcfRXqIPkFAZUEf()
		{
			if (!wQocEXrcVJZfTZzeNbopsPkAqkbp)
			{
				return;
			}
			lock (MzmmGHMUUTfNrhBVdaGfJcnlkhok)
			{
				MiscTools.Swap(ref RnughZBINmTvNtzASQJkPZUwITbsA, ref YitYUaFTRvQwBjzuzPTWqVIHnrDW);
				wQocEXrcVJZfTZzeNbopsPkAqkbp = false;
			}
			while (YitYUaFTRvQwBjzuzPTWqVIHnrDW.Count > 0)
			{
				Action action = YitYUaFTRvQwBjzuzPTWqVIHnrDW.Dequeue();
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

		private void sHMURgVdxsNXrbBKYOKCFKqNplmm()
		{
			if (ppTbtqbtMKVIibnERHLPyoCRPOEA <= 0)
			{
				NbxDKMzuQjdfDbDlWXnnoxkMdzROA = false;
			}
			else
			{
				NbxDKMzuQjdfDbDlWXnnoxkMdzROA = true;
				CGOesxjlGFFmExTFoPTuPDebTGcJ = Stopwatch.frequency / ppTbtqbtMKVIibnERHLPyoCRPOEA;
			}
			ResetTimeout();
		}

		private void tmGBxBEWfBoeQqUxFYLhPNELgWQVA()
		{
			EDPzZGKccMJUChrAauVuGcigOSBh = null;
			kyXiwVyCJfihRDENTQDjZGyOOWle = false;
			ayLBctpZtIUFOqPpjGdwSbNpvrgK = false;
			RnughZBINmTvNtzASQJkPZUwITbsA.Clear();
			YitYUaFTRvQwBjzuzPTWqVIHnrDW.Clear();
			wQocEXrcVJZfTZzeNbopsPkAqkbp = false;
			tKMNzNGirlORfSbAaueYdTLVmZJC = 0;
			DJoZrmbyHdkizltjmsTizGzURdXT.Reset();
			tPuIJxPgfbJKXcZyLVnZPvRPAeBq.Reset();
			VrHhEhTicOjvteLwdQHvFdnJUYtPA = 0L;
			TYvTxGnyUUeHWlybEUJIlCGqBWFH = 0u;
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
			if (!ofrvHGSmWUjZyxoAIvLxulpqWtvx)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					ayLBctpZtIUFOqPpjGdwSbNpvrgK = false;
				}
				ofrvHGSmWUjZyxoAIvLxulpqWtvx = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void EHFXoYHGqGfUCPpNKiDcIKEiGndeA(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
