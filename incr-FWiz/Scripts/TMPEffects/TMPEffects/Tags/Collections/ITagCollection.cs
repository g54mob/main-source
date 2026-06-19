using System.Collections;
using System.Collections.Generic;

namespace TMPEffects.Tags.Collections
{
	public interface ITagCollection : IReadOnlyTagCollection, IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable
	{
		bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices);

		bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null);

		int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0);

		bool RemoveAt(int startIndex, int? order = null);

		bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null);

		void Clear();
	}
}
