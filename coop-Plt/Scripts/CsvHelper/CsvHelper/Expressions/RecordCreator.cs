using System;
using System.Collections.Generic;
using System.Reflection;

namespace CsvHelper.Expressions
{
	public abstract class RecordCreator
	{
		private readonly Dictionary<Type, Delegate> createRecordFuncs = new Dictionary<Type, Delegate>();

		protected CsvReader Reader { get; private set; }

		protected ExpressionManager ExpressionManager { get; private set; }

		public RecordCreator(CsvReader reader)
		{
			Reader = reader;
			ExpressionManager = new ExpressionManager(reader);
		}

		public T Create<T>()
		{
			try
			{
				return ((Func<T>)GetCreateRecordDelegate(typeof(T)))();
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		public object Create(Type recordType)
		{
			try
			{
				return GetCreateRecordDelegate(recordType).DynamicInvoke();
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		protected virtual Delegate GetCreateRecordDelegate(Type recordType)
		{
			if (!createRecordFuncs.TryGetValue(recordType, out var value))
			{
				value = (createRecordFuncs[recordType] = CreateCreateRecordDelegate(recordType));
			}
			return value;
		}

		protected abstract Delegate CreateCreateRecordDelegate(Type recordType);
	}
}
