using System.Runtime.CompilerServices;

namespace NatSuite.Recorders.Clocks
{
	public sealed class FixedIntervalClock : IClock
	{
		public readonly double interval;

		private readonly bool autoTick;

		private long ticks;

		public long timestamp
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return (long)((double)(autoTick ? ticks++ : ticks) * interval * 1000000000.0);
			}
		}

		public FixedIntervalClock(float framerate, bool autoTick = true)
		{
			interval = 1.0 / (double)framerate;
			ticks = 0L;
			this.autoTick = autoTick;
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Tick()
		{
			ticks++;
		}
	}
}
