using System;
using Unity.Collections;

public interface gu
{
	void eiu(IDisposable a);

	void eiv<T>(NativeList<T> a) where T : struct;

	void eiw<T>(NativeHashSet<T> a) where T : struct, IEquatable<T>;

	void eix<TKey, TValue>(NativeHashMap<TKey, TValue> a) where TKey : struct, IEquatable<TKey> where TValue : struct;

	void eiy<T>(NativeArray<T> a) where T : struct;
}
