using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public abstract class CollectionFormatterBase<TElement, TIntermediate, TEnumerator, TCollection> : IJsonFormatter<TCollection>, IJsonFormatter, IOverwriteJsonFormatter<TCollection> where TEnumerator : IEnumerator<TElement> where TCollection : class, IEnumerable<TElement>
	{
		protected virtual CollectionDeserializeToBehaviour? SupportedOverwriteBehaviour => null;

		public void Serialize(ref JsonWriter writer, TCollection value, IJsonFormatterResolver formatterResolver)
		{
		}

		public TCollection Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void DeserializeTo(ref TCollection value, ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
		}

		protected abstract TEnumerator GetSourceEnumerator(TCollection source);

		protected abstract TIntermediate Create();

		protected abstract void Add(ref TIntermediate collection, int index, TElement value);

		protected abstract TCollection Complete(ref TIntermediate intermediateCollection);

		protected virtual void ClearOnOverwriteDeserialize(ref TCollection value)
		{
		}

		protected virtual void AddOnOverwriteDeserialize(ref TCollection collection, int index, TElement value)
		{
		}
	}
	public abstract class CollectionFormatterBase<TElement, TIntermediate, TCollection> : CollectionFormatterBase<TElement, TIntermediate, IEnumerator<TElement>, TCollection> where TCollection : class, IEnumerable<TElement>
	{
		protected override IEnumerator<TElement> GetSourceEnumerator(TCollection source)
		{
			return null;
		}
	}
	public abstract class CollectionFormatterBase<TElement, TCollection> : CollectionFormatterBase<TElement, TCollection, TCollection> where TCollection : class, IEnumerable<TElement>
	{
		protected sealed override TCollection Complete(ref TCollection intermediateCollection)
		{
			return null;
		}
	}
}
