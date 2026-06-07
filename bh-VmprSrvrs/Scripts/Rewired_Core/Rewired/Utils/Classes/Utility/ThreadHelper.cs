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
		private const uint JxWZopwvKeeZVEGtEpNEJKnbDXfhA = 750u;

		private readonly Stopwatch ZAyoEkWlVIqwyvSmOZXzAnwUClIH;

		private Thread ZByCFLVMRjKSkonoAAgWpBkMGQYC;

		private ManualResetEvent UcLRQlaUbSgrXgmKCorQUvAmFzIO;

		private ManualResetEvent cQZWwoUqBATBbIuBvWPbehqpWyMU;

		private AutoResetEvent wwFxscblGnUGZNdLNAEWMdVexFCG;

		private bool nckscNwRDhHmIjYLDyYLpgxPjnSb;

		private bool lfaXqCfjcABhxAXdxDkDaodwHEgP;

		private int isndgWNvGSURFVOWCeKsKSenCoCEb;

		private bool sgOxUFiGLQqmJrAAFQZNnaDwTnFH;

		private int uvOAxqiwHjQugkrYsvadDPVwZZBD;

		private long FzaFcstwanCkcCmYDtEowPNeJfIA;

		private bool QzWQvFqAyCUurGpKciTTMbJulhQx;

		private int wXwUiFEIMEXbYwFMNcjPGjyLPWOM;

		private long ORgubeOEWhdaBGSRLkbNcMMKrQqLb;

		private uint OQGmpBewsrhFqscAkamcChfGEHIr;

		private readonly object DNFrGDEaaytFwpuXWILsgATkvpG;

		private Queue<Action> OKZoYMROfFBmjaFtkanKbufQaXuUA;

		private Queue<Action> PLYelbMhvUGnzIcDLNpkHDflqrEBb;

		private bool hJFjGMkahwqLdUmVvWoPDmTeyXoh;

		private Action MrBeQiOjOEFiboxuCIIlWNAmaLIS;

		[CompilerGenerated]
		private Action JXUBmqMQrhpERnKnWcpdUDfokrny;

		[CompilerGenerated]
		private Action BvgROWUwbrIlWAYzlwQHothiPEVL;

		private bool jDMnaNPOendAMuCzkwnZJKQGnzqP;

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

		private void SwVCpHNAywAtvikBOZwuuEuWlxTPA()
		{
		}

		private void rnbSbGQXQnLjAcUCltMicyvyBGVE()
		{
		}

		private void tIhtQfGdPXaSNmIpahksDoDpIdfNA()
		{
		}

		private void mKtPGQRLRoGdsBTEjmlPbmfhjQVdb()
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
		private static void JFqaiHOEvlVxgUmMkrBYvfvYzdyj(object P_0)
		{
		}
	}
}
