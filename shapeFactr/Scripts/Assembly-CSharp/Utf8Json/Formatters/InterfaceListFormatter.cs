using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class InterfaceListFormatter<T> : CollectionFormatterBase<T, List<T>, IList<T>>
	{
		protected override void Add(ref List<T> collection, int index, T value)
		{
		}

		protected override List<T> Create()
		{
			return null;
		}

		protected override IList<T> Complete(ref List<T> intermediateCollection)
		{
			return null;
		}
	}
}
