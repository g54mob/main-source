using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CsvHelper.Expressions
{
	public abstract class RecordWriter
	{
		private readonly Dictionary<int, Delegate> typeActions = new Dictionary<int, Delegate>();

		protected CsvWriter Writer { get; private set; }

		protected ExpressionManager ExpressionManager { get; private set; }

		public RecordWriter(CsvWriter writer)
		{
			Writer = writer;
			ExpressionManager = ObjectResolver.Current.Resolve<ExpressionManager>(new object[1] { writer });
		}

		public void Write<T>(T record)
		{
			try
			{
				GetWriteDelegate(record)(record);
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
		}

		protected Action<T> GetWriteDelegate<T>(T record)
		{
			Type typeFromHandle = typeof(T);
			string text = typeFromHandle.AssemblyQualifiedName;
			if (typeFromHandle == typeof(object))
			{
				typeFromHandle = record.GetType();
				text = text + "|" + typeFromHandle.AssemblyQualifiedName;
			}
			int hashCode = text.GetHashCode();
			if (!typeActions.TryGetValue(hashCode, out var value))
			{
				value = (typeActions[hashCode] = CreateWriteDelegate(record));
			}
			return (Action<T>)value;
		}

		protected abstract Action<T> CreateWriteDelegate<T>(T record);

		protected virtual Action<T> CombineDelegates<T>(IEnumerable<Action<T>> delegates)
		{
			return (Action<T>)delegates.Aggregate<Delegate, Delegate>(null, Delegate.Combine);
		}
	}
}
