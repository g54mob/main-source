using Timberborn.Goods;

namespace Timberborn.Yielding
{
	public class YieldReservationCompletedEventArgs
	{
		public GoodAmount Yield { get; }

		public YieldReservationCompletedEventArgs(GoodAmount yield)
		{
			Yield = yield;
		}
	}
}
