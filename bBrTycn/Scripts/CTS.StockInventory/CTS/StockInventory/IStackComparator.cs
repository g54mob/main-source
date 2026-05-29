namespace CTS.StockInventory
{
	public interface IStackComparator<in TStack, TData> where TStack : struct, IStackable<TStack, TData> where TData : class
	{
		bool IsValidStack(TStack stack);
	}
}
