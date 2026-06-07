using System;

namespace MiscUtil.Linq
{
	public class ProducerGrouping<TKey, TElement> : IProducerGrouping<TKey, TElement>, IDataProducer<TElement>
	{
		private readonly IDataProducer<TElement> source;

		private readonly TKey key;

		public TKey Key => key;

		public event Action<TElement> DataProduced
		{
			add
			{
				source.DataProduced += value;
			}
			remove
			{
				source.DataProduced -= value;
			}
		}

		public event Action EndOfData
		{
			add
			{
				source.EndOfData += value;
			}
			remove
			{
				source.EndOfData -= value;
			}
		}

		public ProducerGrouping(TKey key, IDataProducer<TElement> source)
		{
			this.key = key;
			this.source = source;
		}
	}
}
