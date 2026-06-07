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
		private const uint FOUFJBiDpwXfyBRWSdMDQpIxMTSU = 750u;

		private readonly Stopwatch NtoJSUMQuUGWRaPxOOxaNVLKOXjC;

		private Thread HFqBzvTKjbdmXvBCYjXJcgaQaCzNA;

		private ManualResetEvent AJJXrTmUAMLNivQpQbwFDvtmkpnO;

		private ManualResetEvent qJZnJMEluEIvWDFstFAebnNfKmfFb;

		private AutoResetEvent ydHSMGvmMbwemWUUHJPZLEOoFzpS;

		private bool pyaXRGeZkppTTaTvLfyVscHXjMGj;

		private bool lwgcipNJSjBUJNApdbGfhCuVKJoA;

		private int ghdRuvVtXGlilQdMWBnnJBtzezeb;

		private bool gGIWvhmmlIQakwnJXHxUmoegJhkf;

		private int kyQnQCydydqaXzBdgutcShsyDDon;

		private long DgfiiEuBRifyHxJXKFgHnbgLmVKw;

		private bool KbKbKdeaREmKStRdmsWSRTmkdpdJA;

		private int kvsvCnIAfOAhlfypXbiQJrTHkQtM;

		private long EUkLGWKWdrGrmFgcFegYPstncOBO;

		private uint CoQHbvqOJhRtFliderrlXAOUINfr;

		private readonly object NIBgjkHERaHCejSNVLUGdAjRGeGV;

		private Queue<Action> WpPwzeLvIXvICpsSuocZzEIALNTm;

		private Queue<Action> JFCbCFaQYQZTYCzuHyctGCSpVztpA;

		private bool tjFEluqRYqOuCJxwdLuMUsyusYRJ;

		private Action EVOJSWulQYOUhpDWPueTgluFVnS;

		[CompilerGenerated]
		private Action RxKeBOGdfvkLqchCYwzmVqYmdhIy;

		[CompilerGenerated]
		private Action ZevawMbCncoddJCfnnYHjIwwLszA;

		private bool zxUEFtIJDfhsplfQajkYjGpSOfRQA;

		public bool isRunning => lwgcipNJSjBUJNApdbGfhCuVKJoA;

		public bool isStopped
		{
			get
			{
				if (!lwgcipNJSjBUJNApdbGfhCuVKJoA)
				{
					if (HFqBzvTKjbdmXvBCYjXJcgaQaCzNA == null)
					{
						return true;
					}
					return !HFqBzvTKjbdmXvBCYjXJcgaQaCzNA.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!gGIWvhmmlIQakwnJXHxUmoegJhkf)
				{
					return (long)kyQnQCydydqaXzBdgutcShsyDDon >= 750L;
				}
				return true;
			}
			set
			{
				if (value != gGIWvhmmlIQakwnJXHxUmoegJhkf)
				{
					gGIWvhmmlIQakwnJXHxUmoegJhkf = value;
					hknELrYgwXkuYdKuczpDlmIlvStc();
				}
			}
		}

		public bool useFixedTimeStep => KbKbKdeaREmKStRdmsWSRTmkdpdJA;

		public int fixedTimeStepFPS
		{
			get
			{
				return kyQnQCydydqaXzBdgutcShsyDDon;
			}
			set
			{
				kyQnQCydydqaXzBdgutcShsyDDon = ((value > 0) ? value : 0);
				hknELrYgwXkuYdKuczpDlmIlvStc();
			}
		}

		public int timeoutMS
		{
			get
			{
				return kvsvCnIAfOAhlfypXbiQJrTHkQtM;
			}
			set
			{
				kvsvCnIAfOAhlfypXbiQJrTHkQtM = ((value > 0) ? value : 0);
				hknELrYgwXkuYdKuczpDlmIlvStc();
			}
		}

		public uint tick => CoQHbvqOJhRtFliderrlXAOUINfr;

		public event Action ThreadUpdateEvent
		{
			add
			{
				EVOJSWulQYOUhpDWPueTgluFVnS = (Action)Delegate.Combine(EVOJSWulQYOUhpDWPueTgluFVnS, value);
			}
			remove
			{
				EVOJSWulQYOUhpDWPueTgluFVnS = (Action)Delegate.Remove(EVOJSWulQYOUhpDWPueTgluFVnS, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = RxKeBOGdfvkLqchCYwzmVqYmdhIy;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref RxKeBOGdfvkLqchCYwzmVqYmdhIy, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = RxKeBOGdfvkLqchCYwzmVqYmdhIy;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref RxKeBOGdfvkLqchCYwzmVqYmdhIy, value2, action2);
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
				Action action = ZevawMbCncoddJCfnnYHjIwwLszA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref ZevawMbCncoddJCfnnYHjIwwLszA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = ZevawMbCncoddJCfnnYHjIwwLszA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref ZevawMbCncoddJCfnnYHjIwwLszA, value2, action2);
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
			NtoJSUMQuUGWRaPxOOxaNVLKOXjC = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			kvsvCnIAfOAhlfypXbiQJrTHkQtM = P_2;
			kyQnQCydydqaXzBdgutcShsyDDon = P_0;
			gGIWvhmmlIQakwnJXHxUmoegJhkf = P_1;
			hknELrYgwXkuYdKuczpDlmIlvStc();
			AJJXrTmUAMLNivQpQbwFDvtmkpnO = new ManualResetEvent(initialState: false);
			qJZnJMEluEIvWDFstFAebnNfKmfFb = new ManualResetEvent(initialState: false);
			ydHSMGvmMbwemWUUHJPZLEOoFzpS = new AutoResetEvent(initialState: false);
			NIBgjkHERaHCejSNVLUGdAjRGeGV = new object();
			WpPwzeLvIXvICpsSuocZzEIALNTm = new Queue<Action>();
			JFCbCFaQYQZTYCzuHyctGCSpVztpA = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (lwgcipNJSjBUJNApdbGfhCuVKJoA)
			{
				return false;
			}
			try
			{
				AJJXrTmUAMLNivQpQbwFDvtmkpnO.Reset();
				ydHSMGvmMbwemWUUHJPZLEOoFzpS.Reset();
				HFqBzvTKjbdmXvBCYjXJcgaQaCzNA = new Thread(SXLWBtBBVmRjCtksCtfxVXjAtacC);
				HFqBzvTKjbdmXvBCYjXJcgaQaCzNA.Start();
				if (wait)
				{
					AJJXrTmUAMLNivQpQbwFDvtmkpnO.WaitOne();
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
			if (HFqBzvTKjbdmXvBCYjXJcgaQaCzNA != null && lwgcipNJSjBUJNApdbGfhCuVKJoA && pyaXRGeZkppTTaTvLfyVscHXjMGj)
			{
				AJJXrTmUAMLNivQpQbwFDvtmkpnO.Reset();
				pyaXRGeZkppTTaTvLfyVscHXjMGj = false;
				ydHSMGvmMbwemWUUHJPZLEOoFzpS.Set();
				if (wait)
				{
					AJJXrTmUAMLNivQpQbwFDvtmkpnO.WaitOne();
				}
				adbZbyDiuycZNEanxayCbtOlOMirA();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!lwgcipNJSjBUJNApdbGfhCuVKJoA)
			{
				return false;
			}
			if (!pyaXRGeZkppTTaTvLfyVscHXjMGj)
			{
				return false;
			}
			ResetTimeout();
			lock (NIBgjkHERaHCejSNVLUGdAjRGeGV)
			{
				WpPwzeLvIXvICpsSuocZzEIALNTm.Enqueue(action);
				tjFEluqRYqOuCJxwdLuMUsyusYRJ = true;
				ydHSMGvmMbwemWUUHJPZLEOoFzpS.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!lwgcipNJSjBUJNApdbGfhCuVKJoA)
			{
				return false;
			}
			if (!pyaXRGeZkppTTaTvLfyVscHXjMGj)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!lwgcipNJSjBUJNApdbGfhCuVKJoA || !pyaXRGeZkppTTaTvLfyVscHXjMGj)
			{
				return;
			}
			ResetTimeout();
			lock (NIBgjkHERaHCejSNVLUGdAjRGeGV)
			{
				qJZnJMEluEIvWDFstFAebnNfKmfFb.Reset();
				ghdRuvVtXGlilQdMWBnnJBtzezeb++;
			}
			ydHSMGvmMbwemWUUHJPZLEOoFzpS.Set();
			qJZnJMEluEIvWDFstFAebnNfKmfFb.WaitOne();
			lock (NIBgjkHERaHCejSNVLUGdAjRGeGV)
			{
				ghdRuvVtXGlilQdMWBnnJBtzezeb--;
			}
		}

		public void ResetTimeout()
		{
			EUkLGWKWdrGrmFgcFegYPstncOBO = ((kvsvCnIAfOAhlfypXbiQJrTHkQtM > 0) ? (NtoJSUMQuUGWRaPxOOxaNVLKOXjC.elapsedMillisecondsRaw + kvsvCnIAfOAhlfypXbiQJrTHkQtM) : 0);
		}

		private void SXLWBtBBVmRjCtksCtfxVXjAtacC()
		{
			ResetTimeout();
			lwgcipNJSjBUJNApdbGfhCuVKJoA = true;
			pyaXRGeZkppTTaTvLfyVscHXjMGj = true;
			AJJXrTmUAMLNivQpQbwFDvtmkpnO.Set();
			if (RxKeBOGdfvkLqchCYwzmVqYmdhIy != null)
			{
				lock (RxKeBOGdfvkLqchCYwzmVqYmdhIy)
				{
					try
					{
						RxKeBOGdfvkLqchCYwzmVqYmdhIy();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (pyaXRGeZkppTTaTvLfyVscHXjMGj)
			{
				long num = NtoJSUMQuUGWRaPxOOxaNVLKOXjC.elapsedTicksRaw + DgfiiEuBRifyHxJXKFgHnbgLmVKw;
				hmfdtqYnyvddvkjjtpufEtTeoDaKB();
				lock (NIBgjkHERaHCejSNVLUGdAjRGeGV)
				{
					if (!tjFEluqRYqOuCJxwdLuMUsyusYRJ && ghdRuvVtXGlilQdMWBnnJBtzezeb > 0)
					{
						qJZnJMEluEIvWDFstFAebnNfKmfFb.Set();
					}
				}
				if (EVOJSWulQYOUhpDWPueTgluFVnS != null)
				{
					try
					{
						EVOJSWulQYOUhpDWPueTgluFVnS();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (KbKbKdeaREmKStRdmsWSRTmkdpdJA)
				{
					if (gGIWvhmmlIQakwnJXHxUmoegJhkf || (long)kyQnQCydydqaXzBdgutcShsyDDon >= 750L)
					{
						while (NtoJSUMQuUGWRaPxOOxaNVLKOXjC.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - NtoJSUMQuUGWRaPxOOxaNVLKOXjC.elapsedTicksRaw;
						if (num2 > 0)
						{
							ydHSMGvmMbwemWUUHJPZLEOoFzpS.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				CoQHbvqOJhRtFliderrlXAOUINfr = ((CoQHbvqOJhRtFliderrlXAOUINfr != uint.MaxValue) ? (CoQHbvqOJhRtFliderrlXAOUINfr + 1) : 0u);
				if (kvsvCnIAfOAhlfypXbiQJrTHkQtM > 0 && NtoJSUMQuUGWRaPxOOxaNVLKOXjC.elapsedMillisecondsRaw >= EUkLGWKWdrGrmFgcFegYPstncOBO)
				{
					pyaXRGeZkppTTaTvLfyVscHXjMGj = false;
				}
			}
			if (ZevawMbCncoddJCfnnYHjIwwLszA != null)
			{
				lock (ZevawMbCncoddJCfnnYHjIwwLszA)
				{
					try
					{
						ZevawMbCncoddJCfnnYHjIwwLszA();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			lwgcipNJSjBUJNApdbGfhCuVKJoA = false;
			AJJXrTmUAMLNivQpQbwFDvtmkpnO.Set();
		}

		private void hmfdtqYnyvddvkjjtpufEtTeoDaKB()
		{
			if (!tjFEluqRYqOuCJxwdLuMUsyusYRJ)
			{
				return;
			}
			lock (NIBgjkHERaHCejSNVLUGdAjRGeGV)
			{
				MiscTools.Swap(ref WpPwzeLvIXvICpsSuocZzEIALNTm, ref JFCbCFaQYQZTYCzuHyctGCSpVztpA);
				tjFEluqRYqOuCJxwdLuMUsyusYRJ = false;
			}
			while (JFCbCFaQYQZTYCzuHyctGCSpVztpA.Count > 0)
			{
				Action action = JFCbCFaQYQZTYCzuHyctGCSpVztpA.Dequeue();
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

		private void hknELrYgwXkuYdKuczpDlmIlvStc()
		{
			if (kyQnQCydydqaXzBdgutcShsyDDon <= 0)
			{
				KbKbKdeaREmKStRdmsWSRTmkdpdJA = false;
			}
			else
			{
				KbKbKdeaREmKStRdmsWSRTmkdpdJA = true;
				DgfiiEuBRifyHxJXKFgHnbgLmVKw = Stopwatch.frequency / kyQnQCydydqaXzBdgutcShsyDDon;
			}
			ResetTimeout();
		}

		private void adbZbyDiuycZNEanxayCbtOlOMirA()
		{
			HFqBzvTKjbdmXvBCYjXJcgaQaCzNA = null;
			lwgcipNJSjBUJNApdbGfhCuVKJoA = false;
			pyaXRGeZkppTTaTvLfyVscHXjMGj = false;
			WpPwzeLvIXvICpsSuocZzEIALNTm.Clear();
			JFCbCFaQYQZTYCzuHyctGCSpVztpA.Clear();
			tjFEluqRYqOuCJxwdLuMUsyusYRJ = false;
			ghdRuvVtXGlilQdMWBnnJBtzezeb = 0;
			AJJXrTmUAMLNivQpQbwFDvtmkpnO.Reset();
			qJZnJMEluEIvWDFstFAebnNfKmfFb.Reset();
			EUkLGWKWdrGrmFgcFegYPstncOBO = 0L;
			CoQHbvqOJhRtFliderrlXAOUINfr = 0u;
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
			if (!zxUEFtIJDfhsplfQajkYjGpSOfRQA)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					pyaXRGeZkppTTaTvLfyVscHXjMGj = false;
				}
				zxUEFtIJDfhsplfQajkYjGpSOfRQA = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void FayHdzECftelVNHRwnkVowICWfRo(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
