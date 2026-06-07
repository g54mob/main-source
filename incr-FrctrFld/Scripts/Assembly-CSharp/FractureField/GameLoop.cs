using Reactivity;

namespace FractureField
{
	public class GameLoop
	{
		private long _ticks;

		private long _timestamp;

		public static long ActualTicks => 0L;

		public long Ticks
		{
			get
			{
				return 0L;
			}
			private set
			{
			}
		}

		public static long ActualTimestamp => 0L;

		public long Timestamp
		{
			get
			{
				return 0L;
			}
			private set
			{
			}
		}

		public RTrigger OnUpdateTick { get; }

		public RTrigger OnStartFrameFixedTick { get; }

		public RTrigger OnMidFrameFixedTick { get; }

		public RTrigger OnEndFrameFixedTick { get; }

		public void SetTicks(long ticks)
		{
		}

		public void SetTimestamp(long timestamp)
		{
		}

		public void UpdateTick()
		{
		}

		public void FixedTick()
		{
		}
	}
}
