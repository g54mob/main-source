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
		private const uint RMsxfTVjfBeEDEdqMXJjKazqYBrKA = 750u;

		private readonly Stopwatch RMtISfiHrjSaEhzWZjMrcyNISWD;

		private Thread XAEZftqIhONIoNZkKUBhIYVRUkGG;

		private ManualResetEvent CgdiHZHYWzRyRRVBEzTftdWxedSP;

		private ManualResetEvent gtzefMazutoKprlYnmJWoDwuuaKKA;

		private AutoResetEvent sFbohCIKjWRxJushFExjphezbwUC;

		private bool bYYzWEByjEGeeOcXTsibWqtQfezf;

		private bool ryMQCqScFhdapxworLmmHsfjcIuQ;

		private int aNHdgssmnzQoDcfRIkKTnkmwzyWs;

		private bool wZobsrJskbatHKyTLNWqGnVxPJLN;

		private int wigZkEZCgEDJkJVRsblEmCNlWJDO;

		private long DvTStONeDFZwcVgxGncbNjFYeHzx;

		private bool WjaEkbZsZpEtlirBwUPubzDrthKxA;

		private int sWBsvpRplUxYFsDXnimxHyWKIGj;

		private long ERMgqUvXvIDdRBxERifkrtOuUAecA;

		private uint ALopBfNNwUomqBLUysgZfxnTNGID;

		private readonly object PxxUswqLMDxyXDbsFWfcFQCEcuhd;

		private Queue<Action> QVzGPwaeYkzdzPmwmtTjHdhHFZil;

		private Queue<Action> JWyQuHjAUbSidBnEBAtLeVnyLbSR;

		private bool rQbeqXREONlfopKWdYuKwRgveFcD;

		private Action YLnzCKzcnzDplBWrOcGUvRGhIPUr;

		[CompilerGenerated]
		private Action PoQnMbdlUkyJUEiImaMrhdjdtnK;

		[CompilerGenerated]
		private Action JKOQDynAWMhVYnLopHukFkblMBDP;

		private bool vfgnrzmRBGNHWVAicPloqhMLtvar;

		public bool isRunning => false;

		public bool isStopped => false;

		public bool useHighPrecitionTimer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useFixedTimeStep => false;

		public int fixedTimeStepFPS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int timeoutMS
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public uint tick => 0u;

		public event Action ThreadUpdateEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event Action _ThreadStartedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ThreadStartedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event Action _ThreadPreStopEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ThreadPreStopEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public static ThreadHelper Create(bool fixedTimeStep = false, int fixedTimeStepFPS = 100, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			return null;
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
		{
			return null;
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			return null;
		}

		private ThreadHelper()
		{
		}

		private ThreadHelper(int P_0)
		{
		}

		private ThreadHelper(int P_0, bool P_1, int P_2)
		{
		}

		public bool Start(bool wait)
		{
			return false;
		}

		public void Stop(bool wait)
		{
		}

		public bool EnqueueAction(Action action)
		{
			return false;
		}

		public bool InvokeActionSync(Action action)
		{
			return false;
		}

		public void WaitForActionQueueToFinish()
		{
		}

		public void ResetTimeout()
		{
		}

		private void CGvobhyvDVclhVRACmlNpBsRFfZU()
		{
		}

		private void zOPTmaxmFYEkEZZeltpTViIxZNHD()
		{
		}

		private void zUXehRrwoyRJFNCueqoZLqXedfnl()
		{
		}

		private void qyNDZoifqDSceivBvLpiVbnctSPr()
		{
		}

		public void Dispose()
		{
		}

		~ThreadHelper()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void ZIUhpVlpIRMmwbhkhxzEYxcTxoub(object P_0)
		{
		}
	}
}
