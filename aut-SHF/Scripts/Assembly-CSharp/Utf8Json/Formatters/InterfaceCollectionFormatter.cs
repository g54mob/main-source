using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class InterfaceCollectionFormatter<T> : CollectionFormatterBase<T, List<T>, ICollection<T>>
	{
		protected override void Add(ref List<T> collection, int index, T value)
		{
		}

		protected override List<T> Create()
		{
			return null;
		}

		protected override ICollection<T> Complete(ref List<T> intermediateCollection)
		{
			return null;
		}
	}
}
