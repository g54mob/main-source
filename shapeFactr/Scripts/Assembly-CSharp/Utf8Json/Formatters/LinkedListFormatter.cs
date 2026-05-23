using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class LinkedListFormatter<T> : CollectionFormatterBase<T, LinkedList<T>, LinkedList<T>.Enumerator, LinkedList<T>>
	{
		private readonly CollectionDeserializeToBehaviour deserializeToBehaviour;

		protected override CollectionDeserializeToBehaviour? SupportedOverwriteBehaviour => null;

		public LinkedListFormatter()
		{
		}

		public LinkedListFormatter(CollectionDeserializeToBehaviour deserializeToBehaviour)
		{
		}

		protected override void Add(ref LinkedList<T> collection, int index, T value)
		{
		}

		protected override LinkedList<T> Complete(ref LinkedList<T> intermediateCollection)
		{
			return null;
		}

		protected override LinkedList<T> Create()
		{
			return null;
		}

		protected override LinkedList<T>.Enumerator GetSourceEnumerator(LinkedList<T> source)
		{
			return default(LinkedList<T>.Enumerator);
		}

		protected override void AddOnOverwriteDeserialize(ref LinkedList<T> collection, int index, T value)
		{
		}

		protected override void ClearOnOverwriteDeserialize(ref LinkedList<T> value)
		{
		}
	}
}
