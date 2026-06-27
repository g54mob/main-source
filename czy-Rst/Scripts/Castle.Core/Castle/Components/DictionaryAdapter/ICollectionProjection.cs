using System.Collections;

namespace Castle.Components.DictionaryAdapter
{
	public interface ICollectionProjection : ICollection, IEnumerable
	{
		void Replace(IEnumerable source);

		void Clear();

		void ClearReferences();
	}
}
