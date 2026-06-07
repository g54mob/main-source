using System;

namespace MiscUtil.Linq
{
	public interface IDataProducer<T>
	{
		event Action<T> DataProduced;

		event Action EndOfData;
	}
}
