using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
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

		private void WWKTUJtLPaAZRcvxvlqfhRRXqFgS()
		{
		}

		private void iEFtIGULJbPUYHpTaavmqQKiAMTw()
		{
		}

		private void HLdoEqzqcjPoylyOSkjNSgataryk()
		{
		}

		private void ChSGQysrQdGIBXwKGwUXspnaSifV()
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

		private static void BIqHZUNWxZkeXyHwxqHvRhkOeNXz(object P_0)
		{
		}
	}
}
