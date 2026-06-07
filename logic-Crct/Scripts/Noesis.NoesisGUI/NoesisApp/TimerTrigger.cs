using Noesis;

namespace NoesisApp
{
	public class TimerTrigger : EventTrigger
	{
		public static readonly DependencyProperty MillisecondsPerTickProperty;

		public static readonly DependencyProperty TotalTicksProperty;

		private int _timer;

		private int _tickCount;

		public int MillisecondsPerTick
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int TotalTicks
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public new TimerTrigger Clone()
		{
			return null;
		}

		public new TimerTrigger CloneCurrentValue()
		{
			return null;
		}

		protected override void OnDetaching()
		{
		}

		protected override void OnEvent(object parameter)
		{
		}

		private void StartTimer()
		{
		}

		private void StopTimer()
		{
		}

		private int OnTimerTick()
		{
			return 0;
		}
	}
}
