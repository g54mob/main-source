using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NatSuite.Recorders.Clocks
{
	public sealed class RealtimeClock : IClock
	{
		private readonly Stopwatch stopwatch;

		public long timestamp
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				long result = stopwatch.Elapsed.Ticks * 100;
				if (!stopwatch.IsRunning)
				{
					stopwatch.Start();
				}
				return result;
			}
		}

		public bool paused
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return !stopwatch.IsRunning;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				(value ? new Action(stopwatch.Stop) : new Action(stopwatch.Start))();
			}
		}

		public RealtimeClock()
		{
			stopwatch = new Stopwatch();
		}
	}
}
