using System;

namespace CsvHelper.Expressions
{
	public class RecordHydrator
	{
		private readonly CsvReader reader;

		private readonly ExpressionManager expressionManager;

		public RecordHydrator(CsvReader reader)
		{
		}

		public void Hydrate<T>(T record)
		{
		}

		protected virtual Action<T> GetHydrateRecordAction<T>()
		{
			return null;
		}

		protected virtual Action<T> CreateHydrateRecordAction<T>()
		{
			return null;
		}
	}
}
