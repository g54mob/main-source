using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint NtYxJQCPDqgzjaDabhGrPSWHSV = 750u;

		private readonly Stopwatch nsccCulnFCKMYKDcFJODTBYgbr;

		private Thread DqnUqVhDclGkKLxpVvbwKhaLZRK;

		private ManualResetEvent rCijISvbeGezhEIWnVritiKKiFf;

		private ManualResetEvent inUhfRWwXCvRdXmwwVGJBBwIspG;

		private AutoResetEvent lfXpwByrCaTcKvHbkeQEhCixjICs;

		private bool HnwuepehrEDQxEmaWKVHMOjKljKm;

		private bool WjdpMBxNVyOzrqfOOsntuMfMJRT;

		private int gfdsFmqEiXqqGSQZcyliHCWMvAU;

		private bool GTAdSDrNPbjrogcXyeobeyPuOaig;

		private int RGDcFaPwcclFutBqgeErIqEzuTB;

		private long iQlNSRQHHfdttyyLBZQuHNGCzpw;

		private bool OwIavuNABomcBLgSzmHoUPEXyaq;

		private int LCbSHXEQqWKZjlGFCejKsQmlsdt;

		private long MULycdhOTpDXlUfCkhMUhLNTUII;

		private uint qlSTxbFOIxBxzEfpMKrnvfrqAXY;

		private readonly object hoRwsMzBtvIJkOZIWkcMbwQleyN;

		private Queue<Action> dFXLnpxGxZGVODLUGiEcchyQXFNc;

		private Queue<Action> SERoiUjKKMqpbqfdhIxOATwuOqd;

		private bool wErhkuIjkFJjHKYMNazvFkOdoFeh;

		private Action RJNIsqleUNehnBlisCzDeVDeuWKQ;

		private Action uopCmajwoLgAExMqMykeGTNIMYo;

		private Action crGzCgWTFJAHbIsRrgTAzRfjdVG;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

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
			add
			{
			}
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
			add
			{
			}
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

		private ThreadHelper(int timeoutMS)
		{
		}

		private ThreadHelper(int fixedTimeStepFPS, bool useHighPrecisionTimer, int timeoutMS)
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

		private void OISPVEnOXSTBluLHkuYepByEggvB()
		{
		}

		private void csNpTDUgVXDQsEVljMXfByrGdnCR()
		{
		}

		private void LYnzxddmwJLHWvweLSTUILNkBSn()
		{
		}

		private void AXCGXnecMDjAzKFwPLqYuwAfbLic()
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
		private static void NXcfWNdJddgoffmABubgcFHzHaCJ(object P_0)
		{
		}
	}
}
