namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryEqualityHashCodeStrategy
	{
		bool Equals(IDictionaryAdapter adapter1, IDictionaryAdapter adapter2);

		bool GetHashCode(IDictionaryAdapter adapter, out int hashCode);
	}
}
