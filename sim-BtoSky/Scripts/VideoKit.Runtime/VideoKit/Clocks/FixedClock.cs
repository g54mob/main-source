using System.Runtime.CompilerServices;

namespace VideoKit.Clocks
{
	public sealed class FixedClock : IClock
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

		public FixedClock(float framerate, bool autoTick = true)
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
