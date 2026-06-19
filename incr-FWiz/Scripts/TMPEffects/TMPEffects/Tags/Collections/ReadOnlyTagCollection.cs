using System.Collections;
using System.Collections.Generic;

namespace TMPEffects.Tags.Collections
{
	public class ReadOnlyTagCollection : IReadOnlyTagCollection, IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable
	{
		private IReadOnlyTagCollection collection;

		public int TagCount => 0;

		internal ReadOnlyTagCollection(List<TMPEffectTagTuple> tags)
		{
		}

		internal ReadOnlyTagCollection(IReadOnlyTagCollection collection)
		{
		}

		public bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return false;
		}

		public IEnumerator<TMPEffectTagTuple> GetEnumerator()
		{
			return null;
		}

		public TMPEffectTagIndices? IndicesOf(TMPEffectTag tag)
		{
			return null;
		}

		public TMPEffectTag TagAt(int startIndex, int? order = null)
		{
			return null;
		}

		public int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0)
		{
			return 0;
		}

		public IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex)
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
