using Timberborn.Goods;

namespace Timberborn.Carrying
{
	public struct CarriedGoodsChangedEventArgs
	{
		public GoodAmount CarriedGoods { get; }

		public CarriedGoodsChangedEventArgs(GoodAmount carriedGoods)
		{
			CarriedGoods = carriedGoods;
		}
	}
}
