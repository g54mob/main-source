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
		private const uint JDRpdkHmqLDlsKMhYMMNTNvLVdKF = 750u;

		private readonly Stopwatch jbYoHftSYRpRTpOpMAwBhkqZnWq;

		private Thread TOLvxyiiNhqpXirBdtAdqoJEeaJ;

		private ManualResetEvent bxGpSdoBDIwZkvsqPIYrPbwFwam;

		private ManualResetEvent mRcCIigZaKLoqccAUXaSBpBTsTRw;

		private AutoResetEvent vtFuHlvcsbHvOVgCtTfaTGmfiB;

		private bool TWCXiAvgMSHHyZsUuIiQaMWLcCXC;

		private bool GTSnoVqwoWkmoBesRSutKEZJuEs;

		private int avFrLNbmbHxfHpJgQDLzjjlVcGPH;

		private bool OjqXrqgbuttuzVilAJRaBKcxjNvH;

		private int LWfrBXEvHgnkbUHYWkTekdjoqZO;

		private long msZgweRUoxTqyVZvdugvlanTnAj;

		private bool UpcyGPWpqkAzQwAsNCwjwRdGjXd;

		private int XxHQjqHcdUHLACEoikPLsAbqOLom;

		private long WQbaHOwLyvIMuzImIinDcLiWUjFw;

		private uint uZyUhMEDbldCynVBsPnmBPGljqJH;

		private readonly object zutgNxeNYjGFjApwcTDHPTriuPCA;

		private Queue<Action> fCzMMOkOsBORAmyZknrpRBtBoUO;

		private Queue<Action> OhhBHrFirAktqPFJXutFiaFbzdmL;

		private bool waZTdLyFDVgvUxbchIueYIzqFoj;

		private Action BudHvVirWLodsAgYKOLYzSotjGB;

		private Action ySVrpJylHRbvNAEacdXpwWkBHtJG;

		private Action isenuHPYyDUOafBvJcKDBuKugQP;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public bool isRunning => GTSnoVqwoWkmoBesRSutKEZJuEs;

		public bool isStopped
		{
			get
			{
				if (!GTSnoVqwoWkmoBesRSutKEZJuEs)
				{
					if (TOLvxyiiNhqpXirBdtAdqoJEeaJ == null)
					{
						return true;
					}
					return !TOLvxyiiNhqpXirBdtAdqoJEeaJ.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!OjqXrqgbuttuzVilAJRaBKcxjNvH)
				{
					return (long)LWfrBXEvHgnkbUHYWkTekdjoqZO >= 750L;
				}
				return true;
			}
			set
			{
				if (value != OjqXrqgbuttuzVilAJRaBKcxjNvH)
				{
					OjqXrqgbuttuzVilAJRaBKcxjNvH = value;
					TcDnYOaEBFnQZCQQhMdDoNihrig();
				}
			}
		}

		public bool useFixedTimeStep => UpcyGPWpqkAzQwAsNCwjwRdGjXd;

		public int fixedTimeStepFPS
		{
			get
			{
				return LWfrBXEvHgnkbUHYWkTekdjoqZO;
			}
			set
			{
				LWfrBXEvHgnkbUHYWkTekdjoqZO = ((value > 0) ? value : 0);
				TcDnYOaEBFnQZCQQhMdDoNihrig();
			}
		}

		public int timeoutMS
		{
			get
			{
				return XxHQjqHcdUHLACEoikPLsAbqOLom;
			}
			set
			{
				XxHQjqHcdUHLACEoikPLsAbqOLom = ((value > 0) ? value : 0);
				TcDnYOaEBFnQZCQQhMdDoNihrig();
			}
		}

		public uint tick => uZyUhMEDbldCynVBsPnmBPGljqJH;

		public event Action ThreadUpdateEvent
		{
			add
			{
				BudHvVirWLodsAgYKOLYzSotjGB = (Action)Delegate.Combine(BudHvVirWLodsAgYKOLYzSotjGB, value);
			}
			remove
			{
				BudHvVirWLodsAgYKOLYzSotjGB = (Action)Delegate.Remove(BudHvVirWLodsAgYKOLYzSotjGB, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			add
			{
				Action action = ySVrpJylHRbvNAEacdXpwWkBHtJG;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref ySVrpJylHRbvNAEacdXpwWkBHtJG, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = ySVrpJylHRbvNAEacdXpwWkBHtJG;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref ySVrpJylHRbvNAEacdXpwWkBHtJG, value2, action2);
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
				Action action = isenuHPYyDUOafBvJcKDBuKugQP;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref isenuHPYyDUOafBvJcKDBuKugQP, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = isenuHPYyDUOafBvJcKDBuKugQP;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref isenuHPYyDUOafBvJcKDBuKugQP, value2, action2);
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
			jbYoHftSYRpRTpOpMAwBhkqZnWq = Stopwatch.Global;
			if (fixedTimeStepFPS < 0)
			{
				fixedTimeStepFPS = 0;
			}
			if (timeoutMS < 0)
			{
				timeoutMS = 0;
			}
			XxHQjqHcdUHLACEoikPLsAbqOLom = timeoutMS;
			LWfrBXEvHgnkbUHYWkTekdjoqZO = fixedTimeStepFPS;
			OjqXrqgbuttuzVilAJRaBKcxjNvH = useHighPrecisionTimer;
			TcDnYOaEBFnQZCQQhMdDoNihrig();
			bxGpSdoBDIwZkvsqPIYrPbwFwam = new ManualResetEvent(initialState: false);
			mRcCIigZaKLoqccAUXaSBpBTsTRw = new ManualResetEvent(initialState: false);
			vtFuHlvcsbHvOVgCtTfaTGmfiB = new AutoResetEvent(initialState: false);
			zutgNxeNYjGFjApwcTDHPTriuPCA = new object();
			fCzMMOkOsBORAmyZknrpRBtBoUO = new Queue<Action>();
			OhhBHrFirAktqPFJXutFiaFbzdmL = new Queue<Action>();
		}

		public bool Start(bool wait)
		{
			if (GTSnoVqwoWkmoBesRSutKEZJuEs)
			{
				return false;
			}
			try
			{
				bxGpSdoBDIwZkvsqPIYrPbwFwam.Reset();
				vtFuHlvcsbHvOVgCtTfaTGmfiB.Reset();
				TOLvxyiiNhqpXirBdtAdqoJEeaJ = new Thread(CroiKvoiyOMjkHzIOhEpVDLTJOe);
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start();
				if (wait)
				{
					bxGpSdoBDIwZkvsqPIYrPbwFwam.WaitOne();
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
			if (TOLvxyiiNhqpXirBdtAdqoJEeaJ != null && GTSnoVqwoWkmoBesRSutKEZJuEs && TWCXiAvgMSHHyZsUuIiQaMWLcCXC)
			{
				bxGpSdoBDIwZkvsqPIYrPbwFwam.Reset();
				TWCXiAvgMSHHyZsUuIiQaMWLcCXC = false;
				vtFuHlvcsbHvOVgCtTfaTGmfiB.Set();
				if (wait)
				{
					bxGpSdoBDIwZkvsqPIYrPbwFwam.WaitOne();
				}
				WGomWYfshVDHmufUxNmTGIleoCd();
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!GTSnoVqwoWkmoBesRSutKEZJuEs)
			{
				return false;
			}
			if (!TWCXiAvgMSHHyZsUuIiQaMWLcCXC)
			{
				return false;
			}
			ResetTimeout();
			lock (zutgNxeNYjGFjApwcTDHPTriuPCA)
			{
				fCzMMOkOsBORAmyZknrpRBtBoUO.Enqueue(action);
				waZTdLyFDVgvUxbchIueYIzqFoj = true;
				vtFuHlvcsbHvOVgCtTfaTGmfiB.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!GTSnoVqwoWkmoBesRSutKEZJuEs)
			{
				return false;
			}
			if (!TWCXiAvgMSHHyZsUuIiQaMWLcCXC)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!GTSnoVqwoWkmoBesRSutKEZJuEs || !TWCXiAvgMSHHyZsUuIiQaMWLcCXC)
			{
				return;
			}
			ResetTimeout();
			lock (zutgNxeNYjGFjApwcTDHPTriuPCA)
			{
				mRcCIigZaKLoqccAUXaSBpBTsTRw.Reset();
				avFrLNbmbHxfHpJgQDLzjjlVcGPH++;
			}
			vtFuHlvcsbHvOVgCtTfaTGmfiB.Set();
			mRcCIigZaKLoqccAUXaSBpBTsTRw.WaitOne();
			lock (zutgNxeNYjGFjApwcTDHPTriuPCA)
			{
				avFrLNbmbHxfHpJgQDLzjjlVcGPH--;
			}
		}

		public void ResetTimeout()
		{
			WQbaHOwLyvIMuzImIinDcLiWUjFw = ((XxHQjqHcdUHLACEoikPLsAbqOLom > 0) ? (jbYoHftSYRpRTpOpMAwBhkqZnWq.elapsedMillisecondsRaw + XxHQjqHcdUHLACEoikPLsAbqOLom) : 0);
		}

		private void CroiKvoiyOMjkHzIOhEpVDLTJOe()
		{
			ResetTimeout();
			GTSnoVqwoWkmoBesRSutKEZJuEs = true;
			TWCXiAvgMSHHyZsUuIiQaMWLcCXC = true;
			bxGpSdoBDIwZkvsqPIYrPbwFwam.Set();
			if (ySVrpJylHRbvNAEacdXpwWkBHtJG != null)
			{
				lock (ySVrpJylHRbvNAEacdXpwWkBHtJG)
				{
					try
					{
						ySVrpJylHRbvNAEacdXpwWkBHtJG();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			while (TWCXiAvgMSHHyZsUuIiQaMWLcCXC)
			{
				long elapsedTicksRaw = jbYoHftSYRpRTpOpMAwBhkqZnWq.elapsedTicksRaw;
				long num = elapsedTicksRaw + msZgweRUoxTqyVZvdugvlanTnAj;
				gPxsakXqKLHkbaRoXgCcMKFcCbT();
				lock (zutgNxeNYjGFjApwcTDHPTriuPCA)
				{
					if (!waZTdLyFDVgvUxbchIueYIzqFoj && avFrLNbmbHxfHpJgQDLzjjlVcGPH > 0)
					{
						mRcCIigZaKLoqccAUXaSBpBTsTRw.Set();
					}
				}
				if (BudHvVirWLodsAgYKOLYzSotjGB != null)
				{
					try
					{
						BudHvVirWLodsAgYKOLYzSotjGB();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (UpcyGPWpqkAzQwAsNCwjwRdGjXd)
				{
					if (OjqXrqgbuttuzVilAJRaBKcxjNvH || (long)LWfrBXEvHgnkbUHYWkTekdjoqZO >= 750L)
					{
						while (jbYoHftSYRpRTpOpMAwBhkqZnWq.elapsedTicksRaw < num)
						{
						}
					}
					else
					{
						long num2 = num - jbYoHftSYRpRTpOpMAwBhkqZnWq.elapsedTicksRaw;
						if (num2 > 0)
						{
							vtFuHlvcsbHvOVgCtTfaTGmfiB.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num2)));
						}
					}
				}
				uZyUhMEDbldCynVBsPnmBPGljqJH = ((uZyUhMEDbldCynVBsPnmBPGljqJH != uint.MaxValue) ? (uZyUhMEDbldCynVBsPnmBPGljqJH + 1) : 0u);
				if (XxHQjqHcdUHLACEoikPLsAbqOLom > 0 && jbYoHftSYRpRTpOpMAwBhkqZnWq.elapsedMillisecondsRaw >= WQbaHOwLyvIMuzImIinDcLiWUjFw)
				{
					TWCXiAvgMSHHyZsUuIiQaMWLcCXC = false;
				}
			}
			if (isenuHPYyDUOafBvJcKDBuKugQP != null)
			{
				lock (isenuHPYyDUOafBvJcKDBuKugQP)
				{
					try
					{
						isenuHPYyDUOafBvJcKDBuKugQP();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			GTSnoVqwoWkmoBesRSutKEZJuEs = false;
			bxGpSdoBDIwZkvsqPIYrPbwFwam.Set();
		}

		private void gPxsakXqKLHkbaRoXgCcMKFcCbT()
		{
			if (!waZTdLyFDVgvUxbchIueYIzqFoj)
			{
				return;
			}
			lock (zutgNxeNYjGFjApwcTDHPTriuPCA)
			{
				MiscTools.Swap(ref fCzMMOkOsBORAmyZknrpRBtBoUO, ref OhhBHrFirAktqPFJXutFiaFbzdmL);
				waZTdLyFDVgvUxbchIueYIzqFoj = false;
			}
			while (OhhBHrFirAktqPFJXutFiaFbzdmL.Count > 0)
			{
				Action action = OhhBHrFirAktqPFJXutFiaFbzdmL.Dequeue();
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

		private void TcDnYOaEBFnQZCQQhMdDoNihrig()
		{
			if (LWfrBXEvHgnkbUHYWkTekdjoqZO <= 0)
			{
				UpcyGPWpqkAzQwAsNCwjwRdGjXd = false;
			}
			else
			{
				UpcyGPWpqkAzQwAsNCwjwRdGjXd = true;
				msZgweRUoxTqyVZvdugvlanTnAj = Stopwatch.frequency / LWfrBXEvHgnkbUHYWkTekdjoqZO;
			}
			ResetTimeout();
		}

		private void WGomWYfshVDHmufUxNmTGIleoCd()
		{
			TOLvxyiiNhqpXirBdtAdqoJEeaJ = null;
			GTSnoVqwoWkmoBesRSutKEZJuEs = false;
			TWCXiAvgMSHHyZsUuIiQaMWLcCXC = false;
			fCzMMOkOsBORAmyZknrpRBtBoUO.Clear();
			OhhBHrFirAktqPFJXutFiaFbzdmL.Clear();
			waZTdLyFDVgvUxbchIueYIzqFoj = false;
			avFrLNbmbHxfHpJgQDLzjjlVcGPH = 0;
			bxGpSdoBDIwZkvsqPIYrPbwFwam.Reset();
			mRcCIigZaKLoqccAUXaSBpBTsTRw.Reset();
			WQbaHOwLyvIMuzImIinDcLiWUjFw = 0L;
			uZyUhMEDbldCynVBsPnmBPGljqJH = 0u;
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				if (disposing)
				{
					Stop(wait: true);
				}
				else
				{
					TWCXiAvgMSHHyZsUuIiQaMWLcCXC = false;
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void XHOfcyIvYtleiPGgWfAnfHuEjFR(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
