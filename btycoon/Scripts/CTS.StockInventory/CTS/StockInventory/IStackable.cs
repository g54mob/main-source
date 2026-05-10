namespace CTS.StockInventory
{
	public interface IStackable<TSelf, TData> where TSelf : struct, IStackable<TSelf, TData> where TData : class
	{
		int StackCount { get; }

		TData ItemData { get; }

		bool CanAnythingBeAddedTo(TSelf other);

		TSelf AddStack(ref TSelf stack)
		{
			return AddStack(ref stack, stack.StackCount);
		}

		TSelf AddStack(ref TSelf stack, int maxCount);

		void SetupEmptyFrom(TSelf stack);

		void SetupEmptyFrom(TData data);
	}
}
