namespace CTS.BBT
{
	public static class StockItemSOExtensions
	{
		public static int GetCurrentPrice(this StockItemSO stockItemSO)
		{
			if ((object)stockItemSO == null)
			{
				return 0;
			}
			if (Stocks.BarStock.TryPeekFirst(stockItemSO, out var peekedStack))
			{
				return stockItemSO.GetUnitPrice(peekedStack.Quality);
			}
			return stockItemSO.GetUnitPrice(1f);
		}
	}
}
