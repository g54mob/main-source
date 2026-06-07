namespace MiscUtil.Linq
{
	public interface IProducerGrouping<TKey, TElement> : IDataProducer<TElement>
	{
		TKey Key { get; }
	}
}
