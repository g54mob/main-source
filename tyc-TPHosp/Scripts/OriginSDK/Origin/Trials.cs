using System;
using System.Threading;
using Origin.Data;

namespace Origin
{
	public class Trials
	{
		private const int MAX_SLEEP = 1800000;

		private const int TIMEOUT = 15000;

		private const int TICKET_ENGINE_TYPE = 2;

		private const string REQUEST_TICKET = "";

		private Thread t;

		private AutoResetEvent autoReset = new AutoResetEvent(initialState: false);

		private ExtendTrialResponseT respCopy = new ExtendTrialResponseT();

		private int retryCount = 5;

		private bool threadExit;

		private int sleepPeriod = 2000;

		public bool ThreadExit => threadExit;

		public int SleepPeriod => sleepPeriod;

		public int MaxSleep => 1800000;

		public Trials()
		{
			t = new Thread(Run);
		}

		public void Start()
		{
			if (!t.IsAlive)
			{
				t.Start();
			}
		}

		public void Stop()
		{
			if (t.IsAlive)
			{
				t.Join();
			}
		}

		public void extendTrialResponseCallback(ExtendTrialResponseT resp, OriginErrorT err)
		{
			if (resp == null || err != OriginErrorT.ORIGIN_SUCCESS)
			{
				CheckIfRetry();
			}
			else
			{
				if (resp.TimeGranted == resp.TotalTimeRemaining || resp.TimeGranted == 0)
				{
					sleepPeriod = resp.TimeGranted * 1000;
					if (resp.TimeGranted == 0)
					{
						sleepPeriod += resp.SleepBeforeNukeSec * 1000;
						threadExit = true;
					}
				}
				else
				{
					sleepPeriod = resp.TimeGranted * 1000 - resp.ExtendBeforeExpireSec * 1000;
				}
				if (resp.TotalTimeRemaining < 0 || sleepPeriod < 0 || sleepPeriod > 1800000)
				{
					CheckIfRetry();
				}
				else
				{
					respCopy = resp;
					retryCount = resp.RetryCount;
				}
			}
			autoReset.Set();
		}

		private void Run()
		{
			if (OriginSDK.sdk == null)
			{
				return;
			}
			while (!threadExit)
			{
				Thread.Sleep(sleepPeriod);
				if (OriginSDK.sdk.ExtendTrial(OriginSDK.sdk.DefaultUser, "", 2, 15000, extendTrialResponseCallback) != OriginErrorT.ORIGIN_SUCCESS)
				{
					CheckIfRetry();
				}
				else
				{
					autoReset.WaitOne();
				}
			}
			Thread.Sleep(sleepPeriod);
			Environment.Exit(Environment.ExitCode);
		}

		private void CheckIfRetry()
		{
			retryCount--;
			if (retryCount <= 0)
			{
				sleepPeriod = respCopy.SleepBeforeNukeSec * 1000;
				threadExit = true;
			}
			else
			{
				sleepPeriod = respCopy.RetryAfterFailSec * 1000;
			}
		}
	}
}
