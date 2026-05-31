using System;
using System.Collections.Generic;

namespace CsvHelper.Expressions
{
	public abstract class RecordWriter
	{
		protected CsvWriter Writer { get; private set; }

		protected ExpressionManager ExpressionManager { get; private set; }

		public RecordWriter(CsvWriter writer)
		{
		}

		public void Write<T>(T record)
		{
		}

		protected Action<T> GetWriteDelegate<T>(T record)
		{
			return null;
		}

		protected abstract Action<T> CreateWriteDelegate<T>(T record);

		protected virtual Action<T> CombineDelegates<T>(IEnumerable<Action<T>> delegates)
		{
			return null;
		}
	}
}
