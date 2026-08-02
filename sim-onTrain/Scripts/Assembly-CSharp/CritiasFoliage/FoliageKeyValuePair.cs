namespace CritiasFoliage
{
	public struct FoliageKeyValuePair<T, V>
	{
		public T Key;

		public V Value;

		public FoliageKeyValuePair(T key, V value)
		{
			Key = key;
			Value = value;
		}
	}
}
