namespace TripledoseLibs.Collections
{
	public readonly struct NativeKeyValuePair<TKey, TValue> where TKey : struct where TValue : struct
	{
		public readonly TKey Key;

		public readonly TValue Value;

		public NativeKeyValuePair(TKey keyParam, TValue valueParam)
		{
			Key = default(TKey);
			Value = default(TValue);
		}

		public void eoz(out TKey a, out TValue b)
		{
			a = default(TKey);
			b = default(TValue);
		}
	}
}
