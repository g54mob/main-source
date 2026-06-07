using System;
using System.Collections.Generic;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class ThreadHelper : IDisposable
	{
		private const uint IPMgiyHknnjpnqxLaNYoMTfjCWVp = 750u;

		private readonly Stopwatch esPEGfaQPvoLOAANdaokMpkidjbX;

		private Thread OXKjqyZFILzrIBIvHbQKIuLweHWx;

		private ManualResetEvent cINAghJWYijgrAYWnfCSTkfpFNnb;

		private ManualResetEvent twdQDskKhefovVtymEodgvNzkeGY;

		private AutoResetEvent qwsWjwSnqKtUUldnidGuoYBCWOO;

		private bool MqBSNOKgHyFjvwgsCcEnwHMfxTI;

		private bool LAMwVwBJhYkEjmdYCMhLEYAbJAX;

		private int lQQeKBICsjYbSFAEqSHGzSxlvfA;

		private bool XnxeyoNshTfkaqOTolBTGzyHSgg;

		private int KSqeURgnUKmqoXtgsoVPemziKuJN;

		private long rnEtbsoVvDOolqxFZLmAvwxpRxm;

		private bool VdbGJFxTjWPjZFOYzQwGsaloAqq;

		private int KoGCcikiumVRFLzKOFXwOUpGUyxa;

		private long TJkYUYLrYVClnMIHchHwFiSyAUs;

		private uint torZJSbjsTOHhQrjObcLVdWRdFI;

		private readonly object wKySKpDQZXnBoMhAWVNaHCfGdaZd;

		private Queue<Action> okgHGKZELjcCQVhWYftUCTJbeNRF;

		private Queue<Action> ZAyrGdZqqkDlnkJvtazigqBNKCp;

		private bool nWoKXwPSlPcRHEGHeKZDStgCVko;

		private Action EpwGXNDBqbgVfbXqeAEndQeDWkU;

		private Action laAeiPBXYjfhWRdGKsTWgyqtKUWt;

		private Action jgjeNDsjhjIonCDHlghqPkASXRS;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

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

		private void DnjvobVmtgOwzcVtajZCDPipocn()
		{
		}

		private void xVevaagstvDLyRGzbqRPEDIAvPA()
		{
		}

		private void YIEWBGRrYbeOKvHeFipiFgoFvLvd()
		{
		}

		private void PfAjYfGerfHnoFuRPDkIKdAOHyC()
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

		private static void IXDcyenXFllvQuWyLMYCtoheeQM(object P_0)
		{
		}
	}
}
