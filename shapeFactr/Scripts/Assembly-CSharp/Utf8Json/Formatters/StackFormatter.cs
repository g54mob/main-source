using System.Collections.Generic;
using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
	public sealed class StackFormatter<T> : CollectionFormatterBase<T, ArrayBuffer<T>, Stack<T>.Enumerator, Stack<T>>
	{
		protected override void Add(ref ArrayBuffer<T> collection, int index, T value)
		{
		}

		protected override ArrayBuffer<T> Create()
		{
			return default(ArrayBuffer<T>);
		}

		protected override Stack<T>.Enumerator GetSourceEnumerator(Stack<T> source)
		{
			return default(Stack<T>.Enumerator);
		}

		protected override Stack<T> Complete(ref ArrayBuffer<T> intermediateCollection)
		{
			return null;
		}
	}
}
