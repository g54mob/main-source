using System;
using Unity.Collections;
using ZLinq.Linq;

namespace ZLinq
{
	public static class UnityCollectionsExtensions
	{
		public static ValueEnumerable<FromNativeList<T>, T> AsValueEnumerable<T>(this NativeList<T> source) where T : unmanaged
		{
			return new ValueEnumerable<FromNativeList<T>, T>(new FromNativeList<T>(source));
		}

		public static ValueEnumerable<FromNativeQueue<T>, T> AsValueEnumerable<T>(this NativeQueue<T>.ReadOnly source) where T : unmanaged
		{
			return new ValueEnumerable<FromNativeQueue<T>, T>(new FromNativeQueue<T>(source));
		}

		public static ValueEnumerable<FromNativeHashSet<T>, T> AsValueEnumerable<T>(this NativeHashSet<T> source) where T : unmanaged, IEquatable<T>
		{
			return new ValueEnumerable<FromNativeHashSet<T>, T>(new FromNativeHashSet<T>(source.AsReadOnly()));
		}

		public static ValueEnumerable<FromNativeHashSet<T>, T> AsValueEnumerable<T>(this NativeHashSet<T>.ReadOnly source) where T : unmanaged, IEquatable<T>
		{
			return new ValueEnumerable<FromNativeHashSet<T>, T>(new FromNativeHashSet<T>(source));
		}

		public static ValueEnumerable<FromNativeHashMap<TKey, TValue>, KVPair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this NativeHashMap<TKey, TValue> source) where TKey : unmanaged, IEquatable<TKey> where TValue : unmanaged
		{
			return new ValueEnumerable<FromNativeHashMap<TKey, TValue>, KVPair<TKey, TValue>>(new FromNativeHashMap<TKey, TValue>(source.AsReadOnly()));
		}

		public static ValueEnumerable<FromNativeHashMap<TKey, TValue>, KVPair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this NativeHashMap<TKey, TValue>.ReadOnly source) where TKey : unmanaged, IEquatable<TKey> where TValue : unmanaged
		{
			return new ValueEnumerable<FromNativeHashMap<TKey, TValue>, KVPair<TKey, TValue>>(new FromNativeHashMap<TKey, TValue>(source));
		}

		public static ValueEnumerable<FromNativeText, Unicode.Rune> AsValueEnumerable(this NativeText source)
		{
			return new ValueEnumerable<FromNativeText, Unicode.Rune>(new FromNativeText(source.AsReadOnly()));
		}

		public static ValueEnumerable<FromNativeText, Unicode.Rune> AsValueEnumerable(this NativeText.ReadOnly source)
		{
			return new ValueEnumerable<FromNativeText, Unicode.Rune>(new FromNativeText(source));
		}

		public static ValueEnumerable<FromFixedList32Bytes<T>, T> AsValueEnumerable<T>(this FixedList32Bytes<T> source) where T : unmanaged
		{
			return new ValueEnumerable<FromFixedList32Bytes<T>, T>(new FromFixedList32Bytes<T>(source));
		}

		public static ValueEnumerable<FromFixedList64Bytes<T>, T> AsValueEnumerable<T>(this FixedList64Bytes<T> source) where T : unmanaged
		{
			return new ValueEnumerable<FromFixedList64Bytes<T>, T>(new FromFixedList64Bytes<T>(source));
		}

		public static ValueEnumerable<FromFixedList128Bytes<T>, T> AsValueEnumerable<T>(this FixedList128Bytes<T> source) where T : unmanaged
		{
			return new ValueEnumerable<FromFixedList128Bytes<T>, T>(new FromFixedList128Bytes<T>(source));
		}

		public static ValueEnumerable<FromFixedList512Bytes<T>, T> AsValueEnumerable<T>(this FixedList512Bytes<T> source) where T : unmanaged
		{
			return new ValueEnumerable<FromFixedList512Bytes<T>, T>(new FromFixedList512Bytes<T>(source));
		}

		public static ValueEnumerable<FromFixedList4096Bytes<T>, T> AsValueEnumerable<T>(this FixedList4096Bytes<T> source) where T : unmanaged
		{
			return new ValueEnumerable<FromFixedList4096Bytes<T>, T>(new FromFixedList4096Bytes<T>(source));
		}

		public static ValueEnumerable<FromFixedString32Bytes, Unicode.Rune> AsValueEnumerable(this FixedString32Bytes source)
		{
			return new ValueEnumerable<FromFixedString32Bytes, Unicode.Rune>(new FromFixedString32Bytes(source));
		}

		public static ValueEnumerable<FromFixedString64Bytes, Unicode.Rune> AsValueEnumerable(this FixedString64Bytes source)
		{
			return new ValueEnumerable<FromFixedString64Bytes, Unicode.Rune>(new FromFixedString64Bytes(source));
		}

		public static ValueEnumerable<FromFixedString128Bytes, Unicode.Rune> AsValueEnumerable(this FixedString128Bytes source)
		{
			return new ValueEnumerable<FromFixedString128Bytes, Unicode.Rune>(new FromFixedString128Bytes(source));
		}

		public static ValueEnumerable<FromFixedString512Bytes, Unicode.Rune> AsValueEnumerable(this FixedString512Bytes source)
		{
			return new ValueEnumerable<FromFixedString512Bytes, Unicode.Rune>(new FromFixedString512Bytes(source));
		}

		public static ValueEnumerable<FromFixedString4096Bytes, Unicode.Rune> AsValueEnumerable(this FixedString4096Bytes source)
		{
			return new ValueEnumerable<FromFixedString4096Bytes, Unicode.Rune>(new FromFixedString4096Bytes(source));
		}
	}
}
