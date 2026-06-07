using System;
using System.Collections.Generic;
using MiscUtil.Extensions;

namespace MiscUtil.Linq
{
	internal class OrderedDataProducer<T> : IOrderedDataProducer<T>, IDataProducer<T>
	{
		private bool dataHasEnded;

		private readonly IDataProducer<T> baseProducer;

		private readonly IComparer<T> comparer;

		private List<T> buffer;

		public IDataProducer<T> BaseProducer => baseProducer;

		public IComparer<T> Comparer => comparer;

		public event Action<T> DataProduced;

		public event Action EndOfData;

		public OrderedDataProducer(IDataProducer<T> baseProducer, IComparer<T> comparer)
		{
			baseProducer.ThrowIfNull("baseProducer");
			this.baseProducer = baseProducer;
			this.comparer = comparer ?? Comparer<T>.Default;
			baseProducer.DataProduced += OriginalDataProduced;
			baseProducer.EndOfData += EndOfOriginalData;
		}

		private void OriginalDataProduced(T item)
		{
			if (dataHasEnded)
			{
				throw new InvalidOperationException("EndOfData already occurred");
			}
			if (this.DataProduced != null)
			{
				if (buffer == null)
				{
					buffer = new List<T>();
				}
				buffer.Add(item);
			}
		}

		private void EndOfOriginalData()
		{
			if (dataHasEnded)
			{
				throw new InvalidOperationException("EndOfData already occurred");
			}
			dataHasEnded = true;
			if (this.DataProduced != null && buffer != null)
			{
				buffer.Sort(Comparer);
				foreach (T item in buffer)
				{
					OnDataProduced(item);
				}
			}
			buffer = null;
			OnEndOfData();
		}

		private void OnEndOfData()
		{
			if (this.EndOfData != null)
			{
				this.EndOfData();
			}
		}

		private void OnDataProduced(T item)
		{
			if (this.DataProduced != null)
			{
				this.DataProduced(item);
			}
		}
	}
}
