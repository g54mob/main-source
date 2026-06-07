using System;

namespace CsvHelper.Expressions
{
	public abstract class RecordCreator
	{
		protected CsvReader Reader { get; private set; }

		protected ExpressionManager ExpressionManager { get; private set; }

		public RecordCreator(CsvReader reader)
		{
		}

		public T Create<T>()
		{
			return default(T);
		}

		public object Create(Type recordType)
		{
			return null;
		}

		protected virtual Delegate GetCreateRecordDelegate(Type recordType)
		{
			return null;
		}

		protected abstract Delegate CreateCreateRecordDelegate(Type recordType);
	}
}
