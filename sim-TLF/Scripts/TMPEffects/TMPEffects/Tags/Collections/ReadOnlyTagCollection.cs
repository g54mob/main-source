using System.Collections;
using System.Collections.Generic;

namespace TMPEffects.Tags.Collections
{
	public class ReadOnlyTagCollection : IReadOnlyTagCollection, IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable
	{
		private IReadOnlyTagCollection collection;

		public int TagCount => collection.TagCount;

		internal ReadOnlyTagCollection(List<TMPEffectTagTuple> tags)
		{
			collection = new TagCollection(tags);
		}

		internal ReadOnlyTagCollection(IReadOnlyTagCollection collection)
		{
			this.collection = collection;
		}

		public bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return collection.Contains(tag, indices);
		}

		public IEnumerator<TMPEffectTagTuple> GetEnumerator()
		{
			return collection.GetEnumerator();
		}

		public TMPEffectTagIndices? IndicesOf(TMPEffectTag tag)
		{
			return collection.IndicesOf(tag);
		}

		public TMPEffectTag TagAt(int startIndex, int? order = null)
		{
			return collection.TagAt(startIndex, order);
		}

		public int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0)
		{
			return collection.TagsAt(startIndex, buffer, bufferIndex);
		}

		public IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex)
		{
			return collection.TagsAt(startIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return collection.GetEnumerator();
		}
	}
}
