using System.Collections.Generic;

namespace MiscUtil.Linq
{
	public interface IOrderedDataProducer<T> : IDataProducer<T>
	{
		IDataProducer<T> BaseProducer { get; }

		IComparer<T> Comparer { get; }
	}
}
