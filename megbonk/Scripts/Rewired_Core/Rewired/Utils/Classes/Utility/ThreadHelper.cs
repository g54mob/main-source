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
		private const uint MdjdqFSDISvKXHhdrbGFmAhYVHcH = 750u;

		private readonly Stopwatch SrPFfUIiKaQUkccsGfzokrgEnUBFc;

		private Thread WbRXTfdNPZViidFzdKsDYuRtERJK;

		private ManualResetEvent RwaBWLIIkiiNLpLEjfBJExKJovVJA;

		private ManualResetEvent xwHxKGmOfmrzsBXqAvuyZaSGyTdB;

		private AutoResetEvent lqeCiKCPaVtoHFIreGyPfbrdPhTSb;

		private bool mlDwvYKpWZvmauiOiDEHAggyYroy;

		private bool ovRLGwTBnwBPfaBlEBSALXtDjAvqA;

		private int tYCrnobiLcjtNDCQdImxFpyDUmTAc;

		private bool pwdfglGnUwwEJqeYkSkYGWTLqTWn;

		private int hRnKJEQgSXNsgtKCZUVykYNJKTWm;

		private long SOKtYMOupUaSyvWcfFPFZKJyPkwi;

		private bool XStdofAQrwgKvTXOLCfOlQNTwbVw;

		private int joBgTpieNaMfGElSaaHKMteawQJub;

		private long RLNgAoSHJgQNiBLqnJCOnMKTUrJA;

		private uint JhlBjhFUtDOBslVSTzCjjSrnFDLS;

		private readonly object QwgtMsfazONSFrmqkFiUkBMcrkurA;

		private Queue<Action> NeuAFkxpmlPQtpRlDQJXTLdlsDrP;

		private Queue<Action> CPlqhPenueTVhpwHiFelagnMtTXl;

		private bool mzeasyDEkUmIvMFXAoaSGcBZEglwA;

		private Action NeqLpGqENqcWrhjszCwiXlUHqHJUA;

		[CompilerGenerated]
		private Action OnvGCWbeZZHXDaejDtSmKrtUTjkSb;

		[CompilerGenerated]
		private Action SHLLAsmisRHeSBcdSDKUHVvBIZUX;

		private bool gnnfXtjsrHkXAbbnVRPIqHQfhtvO;

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

		private void BTiquhfMtSaDtgpRrMSfkdihCrOQA()
		{
		}

		private void mxOYTcsVKHbTCnhAYBHhPKqTXZSl()
		{
		}

		private void wEUOqHaCWfmwVvqpLmGzRwRSudss()
		{
		}

		private void luGaBmbBSYENySxCIFFAEDfOCAOGb()
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
		private static void EVJDntcsRPGbgePiROPZkOdjorlMA(object P_0)
		{
		}
	}
}
