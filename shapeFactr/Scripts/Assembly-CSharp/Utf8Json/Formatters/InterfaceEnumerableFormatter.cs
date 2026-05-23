using System.Collections.Generic;
using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
	public sealed class InterfaceEnumerableFormatter<T> : CollectionFormatterBase<T, ArrayBuffer<T>, IEnumerable<T>>
	{
		protected override void Add(ref ArrayBuffer<T> collection, int index, T value)
		{
		}

		protected override ArrayBuffer<T> Create()
		{
			return default(ArrayBuffer<T>);
		}

		protected override IEnumerable<T> Complete(ref ArrayBuffer<T> intermediateCollection)
		{
			return null;
		}
	}
}
