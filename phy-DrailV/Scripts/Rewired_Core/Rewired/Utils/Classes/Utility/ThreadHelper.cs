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
		private const uint cpxEEHbyfvBHjGSZiKjhhuGMQfQpb = 750u;

		private readonly Stopwatch YreggMjCHbVzMOrXOzZrDERYDKyEb;

		private Thread uytkADRVWPHFEiqlxjbRBVqXkmPwA;

		private ManualResetEvent IjwYTCRIQcjAhjoWZknLqJOAfoiv;

		private ManualResetEvent ZWKRtDsShmBEzgpeGcBeWngAcPVw;

		private AutoResetEvent WWJiQLWwaAVnQWDdYeUtXNmfctDM;

		private bool gPiurbONvqfcvRyToPeeZglQGSFg;

		private bool favUaRLffWEtzVZYwbKYfPxMiLIi;

		private int RrjdkeAAyvlNANvEWxwRGYKGkAVnA;

		private bool doEFSNFunPREsXYBYSwKlxFqkDfO;

		private int esJdaqdpSEvGqMYcMLsKOXOdKTKqA;

		private long XNvuNHsCtZPUjRNNzPJTImSMqQjN;

		private bool beQHrqhJbCrPZmyAPbDJDrSZcRdw;

		private int qOxDSPkXgwGzXQLQkActidSzkXaGA;

		private long zkDcsvRnXLgRvpScQStxoFEFdvXC;

		private uint ZOGdtxhywByehzFteYSAkKnsuTHf;

		private readonly object CLPucALIHXQhifHCgNizeqIfTBMx;

		private Queue<Action> UKRxWzFJBnquIiSEqWxJgkqImEKm;

		private Queue<Action> taJqgSBioiAVhAFtHpKtWTsyBbsjb;

		private bool TfPuwjDAzMGZqxYrVfGPbYdSurJA;

		private Action yoHaroDDatIObCUoGifsCDHmpbBM;

		[CompilerGenerated]
		private Action FZvaMmhZAtlDSgAEskaFmRTIjvJZA;

		[CompilerGenerated]
		private Action PGYAUmexXnemhdXNTVfhmxctyyFd;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public bool isRunning => favUaRLffWEtzVZYwbKYfPxMiLIi;

		public bool isStopped
		{
			get
			{
				if (!favUaRLffWEtzVZYwbKYfPxMiLIi)
				{
					if (uytkADRVWPHFEiqlxjbRBVqXkmPwA == null)
					{
						return true;
					}
					return !uytkADRVWPHFEiqlxjbRBVqXkmPwA.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!doEFSNFunPREsXYBYSwKlxFqkDfO)
				{
					return (long)esJdaqdpSEvGqMYcMLsKOXOdKTKqA >= 750L;
				}
				return true;
			}
			set
			{
				if (value != doEFSNFunPREsXYBYSwKlxFqkDfO)
				{
					doEFSNFunPREsXYBYSwKlxFqkDfO = value;
					sipvrpVkGtaaSkGufmGvcVTqkkihA();
				}
			}
		}

		public bool useFixedTimeStep => beQHrqhJbCrPZmyAPbDJDrSZcRdw;

		public int fixedTimeStepFPS
		{
			get
			{
				return esJdaqdpSEvGqMYcMLsKOXOdKTKqA;
			}
			set
			{
				esJdaqdpSEvGqMYcMLsKOXOdKTKqA = ((value > 0) ? value : 0);
				sipvrpVkGtaaSkGufmGvcVTqkkihA();
			}
		}

		public int timeoutMS
		{
			get
			{
				return qOxDSPkXgwGzXQLQkActidSzkXaGA;
			}
			set
			{
				qOxDSPkXgwGzXQLQkActidSzkXaGA = ((value > 0) ? value : 0);
				sipvrpVkGtaaSkGufmGvcVTqkkihA();
			}
		}

		public uint tick => ZOGdtxhywByehzFteYSAkKnsuTHf;

		public event Action ThreadUpdateEvent
		{
			add
			{
				yoHaroDDatIObCUoGifsCDHmpbBM = (Action)Delegate.Combine(yoHaroDDatIObCUoGifsCDHmpbBM, value);
			}
			remove
			{
				yoHaroDDatIObCUoGifsCDHmpbBM = (Action)Delegate.Remove(yoHaroDDatIObCUoGifsCDHmpbBM, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = FZvaMmhZAtlDSgAEskaFmRTIjvJZA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref FZvaMmhZAtlDSgAEskaFmRTIjvJZA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = FZvaMmhZAtlDSgAEskaFmRTIjvJZA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref FZvaMmhZAtlDSgAEskaFmRTIjvJZA, value2, action2);
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
				Action action = PGYAUmexXnemhdXNTVfhmxctyyFd;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref PGYAUmexXnemhdXNTVfhmxctyyFd, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = PGYAUmexXnemhdXNTVfhmxctyyFd;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref PGYAUmexXnemhdXNTVfhmxctyyFd, value2, action2);
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
			YreggMjCHbVzMOrXOzZrDERYDKyEb = Stopwatch.Global;
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			qOxDSPkXgwGzXQLQkActidSzkXaGA = P_2;
			esJdaqdpSEvGqMYcMLsKOXOdKTKqA = P_0;
			doEFSNFunPREsXYBYSwKlxFqkDfO = P_1;
			sipvrpVkGtaaSkGufmGvcVTqkkihA();
			IjwYTCRIQcjAhjoWZknLqJOAfoiv = new ManualResetEvent(initialState: false);
			ZWKRtDsShmBEzgpeGcBeWngAcPVw = new ManualResetEvent(initialState: false);
			WWJiQLWwaAVnQWDdYeUtXNmfctDM = new AutoResetEvent(initialState: false);
			CLPucALIHXQhifHCgNizeqIfTBMx = new object();
			UKRxWzFJBnquIiSEqWxJgkqImEKm = new Queue<Action>();
			taJqgSBioiAVhAFtHpKtWTsyBbsjb = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (favUaRLffWEtzVZYwbKYfPxMiLIi)
			{
				return false;
			}
			try
			{
				IjwYTCRIQcjAhjoWZknLqJOAfoiv.Reset();
				WWJiQLWwaAVnQWDdYeUtXNmfctDM.Reset();
				uytkADRVWPHFEiqlxjbRBVqXkmPwA = new Thread(jNARjONuhyaUpBtNOYxNyqcQHzaj);
				uytkADRVWPHFEiqlxjbRBVqXkmPwA.Start();
				if (wait)
				{
					IjwYTCRIQcjAhjoWZknLqJOAfoiv.WaitOne();
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
			if (uytkADRVWPHFEiqlxjbRBVqXkmPwA != null && favUaRLffWEtzVZYwbKYfPxMiLIi && gPiurbONvqfcvRyToPeeZglQGSFg)
			{
				IjwYTCRIQcjAhjoWZknLqJOAfoiv.Reset();
				gPiurbONvqfcvRyToPeeZglQGSFg = false;
				WWJiQLWwaAVnQWDdYeUtXNmfctDM.Set();
				if (wait)
				{
					IjwYTCRIQcjAhjoWZknLqJOAfoiv.WaitOne();
				}
				jOzDnUFgdpxtcCytponbUMtjonO();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!favUaRLffWEtzVZYwbKYfPxMiLIi)
			{
				return false;
			}
			if (!gPiurbONvqfcvRyToPeeZglQGSFg)
			{
				return false;
			}
			ResetTimeout();
			lock (CLPucALIHXQhifHCgNizeqIfTBMx)
			{
				UKRxWzFJBnquIiSEqWxJgkqImEKm.Enqueue(action);
				TfPuwjDAzMGZqxYrVfGPbYdSurJA = true;
				WWJiQLWwaAVnQWDdYeUtXNmfctDM.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!favUaRLffWEtzVZYwbKYfPxMiLIi)
			{
				return false;
			}
			if (!gPiurbONvqfcvRyToPeeZglQGSFg)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!favUaRLffWEtzVZYwbKYfPxMiLIi || !gPiurbONvqfcvRyToPeeZglQGSFg)
			{
				return;
			}
			ResetTimeout();
			lock (CLPucALIHXQhifHCgNizeqIfTBMx)
			{
				ZWKRtDsShmBEzgpeGcBeWngAcPVw.Reset();
				RrjdkeAAyvlNANvEWxwRGYKGkAVnA++;
			}
			WWJiQLWwaAVnQWDdYeUtXNmfctDM.Set();
			ZWKRtDsShmBEzgpeGcBeWngAcPVw.WaitOne();
			lock (CLPucALIHXQhifHCgNizeqIfTBMx)
			{
				RrjdkeAAyvlNANvEWxwRGYKGkAVnA--;
			}
		}

		public void ResetTimeout()
		{
			zkDcsvRnXLgRvpScQStxoFEFdvXC = ((qOxDSPkXgwGzXQLQkActidSzkXaGA > 0) ? (YreggMjCHbVzMOrXOzZrDERYDKyEb.elapsedMillisecondsRaw + qOxDSPkXgwGzXQLQkActidSzkXaGA) : 0);
		}

		private void jNARjONuhyaUpBtNOYxNyqcQHzaj()
		{
			ResetTimeout();
			favUaRLffWEtzVZYwbKYfPxMiLIi = true;
			gPiurbONvqfcvRyToPeeZglQGSFg = true;
			IjwYTCRIQcjAhjoWZknLqJOAfoiv.Set();
			if (FZvaMmhZAtlDSgAEskaFmRTIjvJZA != null)
			{
				lock (FZvaMmhZAtlDSgAEskaFmRTIjvJZA)
				{
					try
					{
						FZvaMmhZAtlDSgAEskaFmRTIjvJZA();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (gPiurbONvqfcvRyToPeeZglQGSFg)
			{
				long num = YreggMjCHbVzMOrXOzZrDERYDKyEb.elapsedTicksRaw + XNvuNHsCtZPUjRNNzPJTImSMqQjN;
				RvVHDLgudtjjmkXhLRdWjFthaIJR();
				lock (CLPucALIHXQhifHCgNizeqIfTBMx)
				{
					if (!TfPuwjDAzMGZqxYrVfGPbYdSurJA && RrjdkeAAyvlNANvEWxwRGYKGkAVnA > 0)
					{
						ZWKRtDsShmBEzgpeGcBeWngAcPVw.Set();
					}
				}
				if (yoHaroDDatIObCUoGifsCDHmpbBM != null)
				{
					try
					{
						yoHaroDDatIObCUoGifsCDHmpbBM();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (beQHrqhJbCrPZmyAPbDJDrSZcRdw)
				{
					if (doEFSNFunPREsXYBYSwKlxFqkDfO || (long)esJdaqdpSEvGqMYcMLsKOXOdKTKqA >= 750L)
					{
						while (YreggMjCHbVzMOrXOzZrDERYDKyEb.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - YreggMjCHbVzMOrXOzZrDERYDKyEb.elapsedTicksRaw;
						if (num2 > 0)
						{
							WWJiQLWwaAVnQWDdYeUtXNmfctDM.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				ZOGdtxhywByehzFteYSAkKnsuTHf = ((ZOGdtxhywByehzFteYSAkKnsuTHf != uint.MaxValue) ? (ZOGdtxhywByehzFteYSAkKnsuTHf + 1) : 0u);
				if (qOxDSPkXgwGzXQLQkActidSzkXaGA > 0 && YreggMjCHbVzMOrXOzZrDERYDKyEb.elapsedMillisecondsRaw >= zkDcsvRnXLgRvpScQStxoFEFdvXC)
				{
					gPiurbONvqfcvRyToPeeZglQGSFg = false;
				}
			}
			if (PGYAUmexXnemhdXNTVfhmxctyyFd != null)
			{
				lock (PGYAUmexXnemhdXNTVfhmxctyyFd)
				{
					try
					{
						PGYAUmexXnemhdXNTVfhmxctyyFd();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			favUaRLffWEtzVZYwbKYfPxMiLIi = false;
			IjwYTCRIQcjAhjoWZknLqJOAfoiv.Set();
		}

		private void RvVHDLgudtjjmkXhLRdWjFthaIJR()
		{
			if (!TfPuwjDAzMGZqxYrVfGPbYdSurJA)
			{
				return;
			}
			lock (CLPucALIHXQhifHCgNizeqIfTBMx)
			{
				MiscTools.Swap(ref UKRxWzFJBnquIiSEqWxJgkqImEKm, ref taJqgSBioiAVhAFtHpKtWTsyBbsjb);
				TfPuwjDAzMGZqxYrVfGPbYdSurJA = false;
			}
			while (taJqgSBioiAVhAFtHpKtWTsyBbsjb.Count > 0)
			{
				Action action = taJqgSBioiAVhAFtHpKtWTsyBbsjb.Dequeue();
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

		private void sipvrpVkGtaaSkGufmGvcVTqkkihA()
		{
			if (esJdaqdpSEvGqMYcMLsKOXOdKTKqA <= 0)
			{
				beQHrqhJbCrPZmyAPbDJDrSZcRdw = false;
			}
			else
			{
				beQHrqhJbCrPZmyAPbDJDrSZcRdw = true;
				XNvuNHsCtZPUjRNNzPJTImSMqQjN = Stopwatch.frequency / esJdaqdpSEvGqMYcMLsKOXOdKTKqA;
			}
			ResetTimeout();
		}

		private void jOzDnUFgdpxtcCytponbUMtjonO()
		{
			uytkADRVWPHFEiqlxjbRBVqXkmPwA = null;
			favUaRLffWEtzVZYwbKYfPxMiLIi = false;
			gPiurbONvqfcvRyToPeeZglQGSFg = false;
			UKRxWzFJBnquIiSEqWxJgkqImEKm.Clear();
			taJqgSBioiAVhAFtHpKtWTsyBbsjb.Clear();
			TfPuwjDAzMGZqxYrVfGPbYdSurJA = false;
			RrjdkeAAyvlNANvEWxwRGYKGkAVnA = 0;
			IjwYTCRIQcjAhjoWZknLqJOAfoiv.Reset();
			ZWKRtDsShmBEzgpeGcBeWngAcPVw.Reset();
			zkDcsvRnXLgRvpScQStxoFEFdvXC = 0L;
			ZOGdtxhywByehzFteYSAkKnsuTHf = 0u;
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
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					gPiurbONvqfcvRyToPeeZglQGSFg = false;
				}
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void oefKJfbBTmVdDVSDIdHKWJRVXHoB(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
