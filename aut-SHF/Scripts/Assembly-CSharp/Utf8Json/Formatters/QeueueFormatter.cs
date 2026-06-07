using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class QeueueFormatter<T> : CollectionFormatterBase<T, Queue<T>, Queue<T>.Enumerator, Queue<T>>
	{
		private readonly CollectionDeserializeToBehaviour deserializeToBehaviour;

		protected override CollectionDeserializeToBehaviour? SupportedOverwriteBehaviour => null;

		public QeueueFormatter()
		{
		}

		public QeueueFormatter(CollectionDeserializeToBehaviour deserializeToBehaviour)
		{
		}

		protected override void Add(ref Queue<T> collection, int index, T value)
		{
		}

		protected override Queue<T> Create()
		{
			return null;
		}

		protected override Queue<T>.Enumerator GetSourceEnumerator(Queue<T> source)
		{
			return default(Queue<T>.Enumerator);
		}

		protected override Queue<T> Complete(ref Queue<T> intermediateCollection)
		{
			return null;
		}

		protected override void AddOnOverwriteDeserialize(ref Queue<T> collection, int index, T value)
		{
		}

		protected override void ClearOnOverwriteDeserialize(ref Queue<T> value)
		{
		}
	}
}
