using System;

namespace CTS.Utilities
{
	public class DayCheck : EventCheck
	{
		public DayCheck(Func<bool> func)
			: base(func)
		{
		}

		protected override void RegisterTick()
		{
			CalendarHandlers.NewDay += OnTick;
		}

		protected override void UnregisterTick()
		{
			CalendarHandlers.NewDay -= OnTick;
		}
	}
	public class DayCheck<TArg> : EventCheck<TArg>
	{
		public DayCheck(Func<TArg, bool> func)
			: base(func)
		{
		}

		protected override void RegisterTick()
		{
			CalendarHandlers.NewDay += OnTick;
		}

		protected override void UnregisterTick()
		{
			CalendarHandlers.NewDay -= OnTick;
		}
	}
	public class DayCheck<TArg1, TArg2> : EventCheck<TArg1, TArg2>
	{
		public DayCheck(Func<TArg1, TArg2, bool> func)
			: base(func)
		{
		}

		protected override void RegisterTick()
		{
			CalendarHandlers.NewDay += OnTick;
		}

		protected override void UnregisterTick()
		{
			CalendarHandlers.NewDay -= OnTick;
		}
	}
}
