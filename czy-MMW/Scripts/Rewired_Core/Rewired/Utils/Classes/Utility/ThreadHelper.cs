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
		private const uint JvRsCBdrkWxSpVgTuqhQeIciwxqp = 750u;

		private readonly Stopwatch BWtUIAHjpglzWeGvojxvldATsOPd;

		private Thread DzhaFdODgLHbAbmJmyKQMhIFeBDl;

		private ManualResetEvent SCCKeRttXcIknxLaouXCxXVtKLDt;

		private ManualResetEvent eqEEGWJsxcVUJDilNLrxPZnqRWHp;

		private AutoResetEvent uUiFWCaZRvBnhULblmAnvehfPHWB;

		private bool pBtWWOnhaLMNSuyirIIYQnVYDmqE;

		private bool ldtjecqlGiafHZbNFfQVLGytuqrw;

		private int kNeGEgMggwbSpApkwaegfjzkNKHMA;

		private bool wdVNElbBliGvxujqhicBGOWrrnMK;

		private int wUFcmQlGzRuVEjnoMjDnjcIpkzACb;

		private long DJylUAxYnOFkSfYXuLMAHUHOltgd;

		private bool SUZjNtjLAcenXRwaEAtVipOdlLTNA;

		private int uyhirQLqhmEiulabjRjVldzGsiFg;

		private long QrpbTMDSuZvfbNWjhsNZzhTkCihfA;

		private uint MBGGlNbELLuOBtgCIGeUhsXunJkA;

		private readonly object FcUrToGCpMnTthMfjiQJJVmCQxoD;

		private Queue<Action> OIAhmgCzFbvhTrfPYDPOGDuNQlzSA;

		private Queue<Action> TIFmXPJfBkRuZfEdjfNsducifVJTA;

		private bool dMGDyYpZpMtTyPdERcJKuWgdOhaB;

		private Action IuSQeWNIuklvDdBUuykttVHzfNBJ;

		[CompilerGenerated]
		private Action FAVnOEBsSPwclsKHoWNnnasvPCqg;

		[CompilerGenerated]
		private Action DQrjfqDVFDBMoRmVXUVJFKsbxjUI;

		private bool nADUOjKMENWHcbdJShFNAoFRzBhvA;

		public bool isRunning => ldtjecqlGiafHZbNFfQVLGytuqrw;

		public bool isStopped
		{
			get
			{
				if (!ldtjecqlGiafHZbNFfQVLGytuqrw)
				{
					if (DzhaFdODgLHbAbmJmyKQMhIFeBDl == null)
					{
						return true;
					}
					return !DzhaFdODgLHbAbmJmyKQMhIFeBDl.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!wdVNElbBliGvxujqhicBGOWrrnMK)
				{
					return (long)wUFcmQlGzRuVEjnoMjDnjcIpkzACb >= 750L;
				}
				return true;
			}
			set
			{
				if (value != wdVNElbBliGvxujqhicBGOWrrnMK)
				{
					wdVNElbBliGvxujqhicBGOWrrnMK = value;
					tGyHhBTrnhXppbnZUImgBeMiHAoi();
				}
			}
		}

		public bool useFixedTimeStep => SUZjNtjLAcenXRwaEAtVipOdlLTNA;

		public int fixedTimeStepFPS
		{
			get
			{
				return wUFcmQlGzRuVEjnoMjDnjcIpkzACb;
			}
			set
			{
				wUFcmQlGzRuVEjnoMjDnjcIpkzACb = ((value > 0) ? value : 0);
				tGyHhBTrnhXppbnZUImgBeMiHAoi();
			}
		}

		public int timeoutMS
		{
			get
			{
				return uyhirQLqhmEiulabjRjVldzGsiFg;
			}
			set
			{
				uyhirQLqhmEiulabjRjVldzGsiFg = ((value > 0) ? value : 0);
				tGyHhBTrnhXppbnZUImgBeMiHAoi();
			}
		}

		public uint tick => MBGGlNbELLuOBtgCIGeUhsXunJkA;

		public event Action ThreadUpdateEvent
		{
			add
			{
				IuSQeWNIuklvDdBUuykttVHzfNBJ = (Action)Delegate.Combine(IuSQeWNIuklvDdBUuykttVHzfNBJ, value);
			}
			remove
			{
				IuSQeWNIuklvDdBUuykttVHzfNBJ = (Action)Delegate.Remove(IuSQeWNIuklvDdBUuykttVHzfNBJ, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = FAVnOEBsSPwclsKHoWNnnasvPCqg;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref FAVnOEBsSPwclsKHoWNnnasvPCqg, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = FAVnOEBsSPwclsKHoWNnnasvPCqg;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref FAVnOEBsSPwclsKHoWNnnasvPCqg, value2, action2);
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
				Action action = DQrjfqDVFDBMoRmVXUVJFKsbxjUI;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref DQrjfqDVFDBMoRmVXUVJFKsbxjUI, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = DQrjfqDVFDBMoRmVXUVJFKsbxjUI;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref DQrjfqDVFDBMoRmVXUVJFKsbxjUI, value2, action2);
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
			BWtUIAHjpglzWeGvojxvldATsOPd = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			uyhirQLqhmEiulabjRjVldzGsiFg = P_2;
			wUFcmQlGzRuVEjnoMjDnjcIpkzACb = P_0;
			wdVNElbBliGvxujqhicBGOWrrnMK = P_1;
			tGyHhBTrnhXppbnZUImgBeMiHAoi();
			SCCKeRttXcIknxLaouXCxXVtKLDt = new ManualResetEvent(initialState: false);
			eqEEGWJsxcVUJDilNLrxPZnqRWHp = new ManualResetEvent(initialState: false);
			uUiFWCaZRvBnhULblmAnvehfPHWB = new AutoResetEvent(initialState: false);
			FcUrToGCpMnTthMfjiQJJVmCQxoD = new object();
			OIAhmgCzFbvhTrfPYDPOGDuNQlzSA = new Queue<Action>();
			TIFmXPJfBkRuZfEdjfNsducifVJTA = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (ldtjecqlGiafHZbNFfQVLGytuqrw)
			{
				return false;
			}
			try
			{
				SCCKeRttXcIknxLaouXCxXVtKLDt.Reset();
				uUiFWCaZRvBnhULblmAnvehfPHWB.Reset();
				DzhaFdODgLHbAbmJmyKQMhIFeBDl = new Thread(SuOTZrAOAQeNHhIdefEcnCzJjJAn);
				DzhaFdODgLHbAbmJmyKQMhIFeBDl.Start();
				if (wait)
				{
					SCCKeRttXcIknxLaouXCxXVtKLDt.WaitOne();
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
			if (DzhaFdODgLHbAbmJmyKQMhIFeBDl != null && ldtjecqlGiafHZbNFfQVLGytuqrw && pBtWWOnhaLMNSuyirIIYQnVYDmqE)
			{
				SCCKeRttXcIknxLaouXCxXVtKLDt.Reset();
				pBtWWOnhaLMNSuyirIIYQnVYDmqE = false;
				uUiFWCaZRvBnhULblmAnvehfPHWB.Set();
				if (wait)
				{
					SCCKeRttXcIknxLaouXCxXVtKLDt.WaitOne();
				}
				ogkIaeYMxSpkWWweZhTVPvogPuMo();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!ldtjecqlGiafHZbNFfQVLGytuqrw)
			{
				return false;
			}
			if (!pBtWWOnhaLMNSuyirIIYQnVYDmqE)
			{
				return false;
			}
			ResetTimeout();
			lock (FcUrToGCpMnTthMfjiQJJVmCQxoD)
			{
				OIAhmgCzFbvhTrfPYDPOGDuNQlzSA.Enqueue(action);
				dMGDyYpZpMtTyPdERcJKuWgdOhaB = true;
				uUiFWCaZRvBnhULblmAnvehfPHWB.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!ldtjecqlGiafHZbNFfQVLGytuqrw)
			{
				return false;
			}
			if (!pBtWWOnhaLMNSuyirIIYQnVYDmqE)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!ldtjecqlGiafHZbNFfQVLGytuqrw || !pBtWWOnhaLMNSuyirIIYQnVYDmqE)
			{
				return;
			}
			ResetTimeout();
			lock (FcUrToGCpMnTthMfjiQJJVmCQxoD)
			{
				eqEEGWJsxcVUJDilNLrxPZnqRWHp.Reset();
				kNeGEgMggwbSpApkwaegfjzkNKHMA++;
			}
			uUiFWCaZRvBnhULblmAnvehfPHWB.Set();
			eqEEGWJsxcVUJDilNLrxPZnqRWHp.WaitOne();
			lock (FcUrToGCpMnTthMfjiQJJVmCQxoD)
			{
				kNeGEgMggwbSpApkwaegfjzkNKHMA--;
			}
		}

		public void ResetTimeout()
		{
			QrpbTMDSuZvfbNWjhsNZzhTkCihfA = ((uyhirQLqhmEiulabjRjVldzGsiFg > 0) ? (BWtUIAHjpglzWeGvojxvldATsOPd.elapsedMillisecondsRaw + uyhirQLqhmEiulabjRjVldzGsiFg) : 0);
		}

		private void SuOTZrAOAQeNHhIdefEcnCzJjJAn()
		{
			ResetTimeout();
			ldtjecqlGiafHZbNFfQVLGytuqrw = true;
			pBtWWOnhaLMNSuyirIIYQnVYDmqE = true;
			SCCKeRttXcIknxLaouXCxXVtKLDt.Set();
			if (FAVnOEBsSPwclsKHoWNnnasvPCqg != null)
			{
				lock (FAVnOEBsSPwclsKHoWNnnasvPCqg)
				{
					try
					{
						FAVnOEBsSPwclsKHoWNnnasvPCqg();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (pBtWWOnhaLMNSuyirIIYQnVYDmqE)
			{
				long num = BWtUIAHjpglzWeGvojxvldATsOPd.elapsedTicksRaw + DJylUAxYnOFkSfYXuLMAHUHOltgd;
				rpiwKgTIbRYcohYoXTpgTBfhfdEL();
				lock (FcUrToGCpMnTthMfjiQJJVmCQxoD)
				{
					if (!dMGDyYpZpMtTyPdERcJKuWgdOhaB && kNeGEgMggwbSpApkwaegfjzkNKHMA > 0)
					{
						eqEEGWJsxcVUJDilNLrxPZnqRWHp.Set();
					}
				}
				if (IuSQeWNIuklvDdBUuykttVHzfNBJ != null)
				{
					try
					{
						IuSQeWNIuklvDdBUuykttVHzfNBJ();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (SUZjNtjLAcenXRwaEAtVipOdlLTNA)
				{
					if (wdVNElbBliGvxujqhicBGOWrrnMK || (long)wUFcmQlGzRuVEjnoMjDnjcIpkzACb >= 750L)
					{
						while (BWtUIAHjpglzWeGvojxvldATsOPd.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - BWtUIAHjpglzWeGvojxvldATsOPd.elapsedTicksRaw;
						if (num2 > 0)
						{
							uUiFWCaZRvBnhULblmAnvehfPHWB.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				MBGGlNbELLuOBtgCIGeUhsXunJkA = ((MBGGlNbELLuOBtgCIGeUhsXunJkA != uint.MaxValue) ? (MBGGlNbELLuOBtgCIGeUhsXunJkA + 1) : 0u);
				if (uyhirQLqhmEiulabjRjVldzGsiFg > 0 && BWtUIAHjpglzWeGvojxvldATsOPd.elapsedMillisecondsRaw >= QrpbTMDSuZvfbNWjhsNZzhTkCihfA)
				{
					pBtWWOnhaLMNSuyirIIYQnVYDmqE = false;
				}
			}
			if (DQrjfqDVFDBMoRmVXUVJFKsbxjUI != null)
			{
				lock (DQrjfqDVFDBMoRmVXUVJFKsbxjUI)
				{
					try
					{
						DQrjfqDVFDBMoRmVXUVJFKsbxjUI();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			ldtjecqlGiafHZbNFfQVLGytuqrw = false;
			SCCKeRttXcIknxLaouXCxXVtKLDt.Set();
		}

		private void rpiwKgTIbRYcohYoXTpgTBfhfdEL()
		{
			if (!dMGDyYpZpMtTyPdERcJKuWgdOhaB)
			{
				return;
			}
			lock (FcUrToGCpMnTthMfjiQJJVmCQxoD)
			{
				MiscTools.Swap(ref OIAhmgCzFbvhTrfPYDPOGDuNQlzSA, ref TIFmXPJfBkRuZfEdjfNsducifVJTA);
				dMGDyYpZpMtTyPdERcJKuWgdOhaB = false;
			}
			while (TIFmXPJfBkRuZfEdjfNsducifVJTA.Count > 0)
			{
				Action action = TIFmXPJfBkRuZfEdjfNsducifVJTA.Dequeue();
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

		private void tGyHhBTrnhXppbnZUImgBeMiHAoi()
		{
			if (wUFcmQlGzRuVEjnoMjDnjcIpkzACb <= 0)
			{
				SUZjNtjLAcenXRwaEAtVipOdlLTNA = false;
			}
			else
			{
				SUZjNtjLAcenXRwaEAtVipOdlLTNA = true;
				DJylUAxYnOFkSfYXuLMAHUHOltgd = Stopwatch.frequency / wUFcmQlGzRuVEjnoMjDnjcIpkzACb;
			}
			ResetTimeout();
		}

		private void ogkIaeYMxSpkWWweZhTVPvogPuMo()
		{
			DzhaFdODgLHbAbmJmyKQMhIFeBDl = null;
			ldtjecqlGiafHZbNFfQVLGytuqrw = false;
			pBtWWOnhaLMNSuyirIIYQnVYDmqE = false;
			OIAhmgCzFbvhTrfPYDPOGDuNQlzSA.Clear();
			TIFmXPJfBkRuZfEdjfNsducifVJTA.Clear();
			dMGDyYpZpMtTyPdERcJKuWgdOhaB = false;
			kNeGEgMggwbSpApkwaegfjzkNKHMA = 0;
			SCCKeRttXcIknxLaouXCxXVtKLDt.Reset();
			eqEEGWJsxcVUJDilNLrxPZnqRWHp.Reset();
			QrpbTMDSuZvfbNWjhsNZzhTkCihfA = 0L;
			MBGGlNbELLuOBtgCIGeUhsXunJkA = 0u;
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
			if (!nADUOjKMENWHcbdJShFNAoFRzBhvA)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					pBtWWOnhaLMNSuyirIIYQnVYDmqE = false;
				}
				nADUOjKMENWHcbdJShFNAoFRzBhvA = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void JDjUAhZoMXCvQLEnSRfSGJgLDvrg(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
