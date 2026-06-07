using System;

namespace Yarn
{
	internal class Value
	{
		internal IConvertible InternalValue;

		public IType Type { get; internal set; }

		public Value(Value value)
		{
		}

		public Value(IBridgeableType<IConvertible> type)
		{
		}

		public Value(IType type, IConvertible internalValue)
		{
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public T ConvertTo<T>() where T : IConvertible
		{
			return default(T);
		}

		public object ConvertTo(Type targetType)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
