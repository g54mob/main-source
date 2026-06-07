using System;
using System.Collections.Generic;

namespace MiscUtil.Linq
{
	public class DataProducer<T> : IDataProducer<T>
	{
		private bool endReached;

		public event Action<T> DataProduced;

		public event Action EndOfData;

		public void Produce(T item)
		{
			if (endReached)
			{
				throw new InvalidOperationException("Cannot produce after end of data");
			}
			if (this.DataProduced != null)
			{
				this.DataProduced(item);
			}
		}

		public void ProduceAndEnd(params T[] items)
		{
			ProduceAndEnd((IEnumerable<T>)items);
		}

		public void ProduceAndEnd(IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				Produce(item);
			}
			End();
		}

		public IEnumerable<TResult> PumpProduceAndEnd<TResult>(IEnumerable<T> items, IDataProducer<TResult> pipeline)
		{
			bool stop = false;
			Queue<TResult> resultBuffer = new Queue<TResult>();
			pipeline.DataProduced += delegate(TResult result)
			{
				resultBuffer.Enqueue(result);
			};
			pipeline.EndOfData += delegate
			{
				stop = true;
			};
			foreach (T item in items)
			{
				Produce(item);
				while (resultBuffer.Count > 0)
				{
					yield return resultBuffer.Dequeue();
				}
				if (stop)
				{
					yield break;
				}
			}
			End();
			while (resultBuffer.Count > 0)
			{
				yield return resultBuffer.Dequeue();
			}
		}

		public void End()
		{
			if (endReached)
			{
				throw new InvalidOperationException("Cannot produce end twice");
			}
			endReached = true;
			if (this.EndOfData != null)
			{
				this.EndOfData();
			}
		}
	}
}
