using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class MuCaqOKLImzDFKZmnoGiqohJrONV
		{
			public const long lQheXwaVzmTsdjXXcEpZKPCCEfC = 10000000L;

			private double ydZbZlNKdDyRepihaDUIzbZXAIiC;

			private bool amKXJATmwAaYrdgEOjXKXZHJqhA;

			private double GDWMTSwzuGkUWwACywQDZqHKQZyN;

			private double AjJeuISWNJMPTVnJLRsPHHHpzjFx;

			public bool UOffIuDCOuRBQvqCbZRyGMdmDrLh => amKXJATmwAaYrdgEOjXKXZHJqhA;

			public double gPTVzuYcJUyMgLMUQuiJlKdaKjMk
			{
				get
				{
					if (!amKXJATmwAaYrdgEOjXKXZHJqhA)
					{
						return AjJeuISWNJMPTVnJLRsPHHHpzjFx;
					}
					return (double)Time.realtimeSinceStartup - GDWMTSwzuGkUWwACywQDZqHKQZyN;
				}
			}

			public void CgNRuqoQcEDwgDqLIrXIcfeLDfGD()
			{
				ydZbZlNKdDyRepihaDUIzbZXAIiC = Time.realtimeSinceStartup;
			}

			public void HjFYpAFEUIQOfsXRnLviKWwfeJuF()
			{
				if (!amKXJATmwAaYrdgEOjXKXZHJqhA)
				{
					amKXJATmwAaYrdgEOjXKXZHJqhA = true;
					GDWMTSwzuGkUWwACywQDZqHKQZyN = ydZbZlNKdDyRepihaDUIzbZXAIiC;
				}
			}

			public void EiaIoJzylKQbHcjTHGMMTisQMwrd()
			{
				if (amKXJATmwAaYrdgEOjXKXZHJqhA)
				{
					amKXJATmwAaYrdgEOjXKXZHJqhA = false;
					AjJeuISWNJMPTVnJLRsPHHHpzjFx += ydZbZlNKdDyRepihaDUIzbZXAIiC - GDWMTSwzuGkUWwACywQDZqHKQZyN;
				}
			}

			public void hApBbBObaqznysEEMHmshIuhdnJeb()
			{
				GDWMTSwzuGkUWwACywQDZqHKQZyN = 0.0;
				AjJeuISWNJMPTVnJLRsPHHHpzjFx = 0.0;
				bool num = amKXJATmwAaYrdgEOjXKXZHJqhA;
				amKXJATmwAaYrdgEOjXKXZHJqhA = false;
				if (num)
				{
					HjFYpAFEUIQOfsXRnLviKWwfeJuF();
				}
			}
		}

		private const long NcMfGwZVkrgeQHcmAJxkYGjdhFrjb = 10000000L;

		private static UnityStopwatch mNPOLcPbNGeRMTiwkXuVfhdBHLNKA;

		private readonly MuCaqOKLImzDFKZmnoGiqohJrONV IitschrWrLYEhxzIpzzjvXPzMBUF;

		private readonly bool dsLVmOJhtKPJZhxpcczgPNaXQuYt;

		private double UQUEYgwnflEygCCuGIFUHqGcWFDEA;

		public static UnityStopwatch Global => mNPOLcPbNGeRMTiwkXuVfhdBHLNKA ?? (mNPOLcPbNGeRMTiwkXuVfhdBHLNKA = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		double StopwatchBase.offsetSeconds
		{
			get
			{
				return UQUEYgwnflEygCCuGIFUHqGcWFDEA;
			}
			set
			{
				UQUEYgwnflEygCCuGIFUHqGcWFDEA = value;
			}
		}

		long StopwatchBase.offsetTicks
		{
			get
			{
				return (long)(UQUEYgwnflEygCCuGIFUHqGcWFDEA * 10000000.0);
			}
			set
			{
				UQUEYgwnflEygCCuGIFUHqGcWFDEA = (double)value / 10000000.0;
			}
		}

		double StopwatchBase.elapsedSeconds => IitschrWrLYEhxzIpzzjvXPzMBUF.gPTVzuYcJUyMgLMUQuiJlKdaKjMk + offsetSeconds;

		double StopwatchBase.elapsedSecondsRaw => IitschrWrLYEhxzIpzzjvXPzMBUF.gPTVzuYcJUyMgLMUQuiJlKdaKjMk;

		long StopwatchBase.elapsedMilliseconds => (long)((IitschrWrLYEhxzIpzzjvXPzMBUF.gPTVzuYcJUyMgLMUQuiJlKdaKjMk + UQUEYgwnflEygCCuGIFUHqGcWFDEA) * 1000.0);

		long StopwatchBase.elapsedMillisecondsRaw => (long)(IitschrWrLYEhxzIpzzjvXPzMBUF.gPTVzuYcJUyMgLMUQuiJlKdaKjMk * 1000.0);

		long StopwatchBase.elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		long StopwatchBase.elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		bool StopwatchBase.isRunning => IitschrWrLYEhxzIpzzjvXPzMBUF.UOffIuDCOuRBQvqCbZRyGMdmDrLh;

		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		public UnityStopwatch()
			: this(false)
		{
		}

		private UnityStopwatch(bool P_0)
		{
			IitschrWrLYEhxzIpzzjvXPzMBUF = new MuCaqOKLImzDFKZmnoGiqohJrONV();
			fwZTBFheLmfpOjpGtlCddRDagnOmc();
			if (P_0)
			{
				Start();
			}
			dsLVmOJhtKPJZhxpcczgPNaXQuYt = P_0;
		}

		~UnityStopwatch()
		{
			CssDOHnacGeoAXuYPXjsDoWBbBohA();
		}

		public override void Stop()
		{
			if (dsLVmOJhtKPJZhxpcczgPNaXQuYt)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			IitschrWrLYEhxzIpzzjvXPzMBUF.EiaIoJzylKQbHcjTHGMMTisQMwrd();
		}

		public override void Start()
		{
			if (!dsLVmOJhtKPJZhxpcczgPNaXQuYt)
			{
				IitschrWrLYEhxzIpzzjvXPzMBUF.HjFYpAFEUIQOfsXRnLviKWwfeJuF();
			}
		}

		public override void Reset()
		{
			if (dsLVmOJhtKPJZhxpcczgPNaXQuYt)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			IitschrWrLYEhxzIpzzjvXPzMBUF.hApBbBObaqznysEEMHmshIuhdnJeb();
		}

		private void fwZTBFheLmfpOjpGtlCddRDagnOmc()
		{
			CssDOHnacGeoAXuYPXjsDoWBbBohA();
			ReInput.BeforeTimeManagerUpdateEvent += KnrWCwZfJXufGklXhBzuzfzhxyBu;
		}

		private void CssDOHnacGeoAXuYPXjsDoWBbBohA()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= KnrWCwZfJXufGklXhBzuzfzhxyBu;
		}

		private void KnrWCwZfJXufGklXhBzuzfzhxyBu(UpdateLoopType P_0)
		{
			IitschrWrLYEhxzIpzzjvXPzMBUF.CgNRuqoQcEDwgDqLIrXIcfeLDfGD();
		}
	}
}
