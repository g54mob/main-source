using System.Collections;
using System.Collections.Generic;

namespace TMPEffects.Tags.Collections
{
	public interface IReadOnlyTagCollection : IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable
	{
		int TagCount { get; }

		private int System_002ECollections_002EGeneric_002EIReadOnlyCollection_003CTMPEffects_002ETags_002ETMPEffectTagTuple_003E_002ECount => 0;

		bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null);

		TMPEffectTagIndices? IndicesOf(TMPEffectTag tag);

		int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0);

		IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex);

		TMPEffectTag TagAt(int startIndex, int? order = null);
	}
}
