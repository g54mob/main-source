using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;

namespace ZLinq.Linq
{
	[StructLayout(LayoutKind.Auto)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct AggregateBy2<TEnumerator, TSource, TKey, TAccumulate> : IValueEnumerator<KeyValuePair<TKey, TAccumulate>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private DictionarySlim<TKey, TAccumulate>? dictionary;

		private DictionarySlim<TKey, TAccumulate>.Enumerator enumerator;

		public AggregateBy2(TEnumerator source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer)
		{
			_003CkeySelector_003EP = keySelector;
			_003CseedSelector_003EP = seedSelector;
			_003Cfunc_003EP = func;
			_003CkeyComparer_003EP = keyComparer;
			dictionary = null;
			enumerator = default(DictionarySlim<TKey, TAccumulate>.Enumerator);
			this.source = source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<KeyValuePair<TKey, TAccumulate>> span)
		{
			span = default(ReadOnlySpan<KeyValuePair<TKey, TAccumulate>>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<KeyValuePair<TKey, TAccumulate>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out KeyValuePair<TKey, TAccumulate> current)
		{
			if (dictionary == null)
			{
				if (source.TryGetNonEnumeratedCount(out var count) && count == 0)
				{
					Unsafe.SkipInit<KeyValuePair<TKey, TAccumulate>>(out current);
					return false;
				}
				Initialize();
			}
			if (enumerator.TryGetNext(out current))
			{
				return true;
			}
			Unsafe.SkipInit<KeyValuePair<TKey, TAccumulate>>(out current);
			return false;
		}

		private void Initialize()
		{
			DictionarySlim<TKey, TAccumulate> dictionarySlim = ((_003CkeyComparer_003EP != null) ? new DictionarySlim<TKey, TAccumulate>(_003CkeyComparer_003EP) : new DictionarySlim<TKey, TAccumulate>());
			using (source)
			{
				if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
				{
					ReadOnlySpan<TSource> readOnlySpan = span;
					for (int i = 0; i < readOnlySpan.Length; i++)
					{
						TSource val = readOnlySpan[i];
						TKey val2 = _003CkeySelector_003EP(val);
						bool exists;
						ref TAccumulate valueRefOrAddDefault = ref dictionarySlim.GetValueRefOrAddDefault(val2, out exists);
						valueRefOrAddDefault = _003Cfunc_003EP(exists ? valueRefOrAddDefault : _003CseedSelector_003EP(val2), val);
					}
				}
				else
				{
					TSource current;
					while (source.TryGetNext(out current))
					{
						TKey val3 = _003CkeySelector_003EP(current);
						bool exists2;
						ref TAccumulate valueRefOrAddDefault2 = ref dictionarySlim.GetValueRefOrAddDefault(val3, out exists2);
						valueRefOrAddDefault2 = _003Cfunc_003EP(exists2 ? valueRefOrAddDefault2 : _003CseedSelector_003EP(val3), current);
					}
				}
			}
			dictionary = dictionarySlim;
			enumerator = dictionarySlim.GetEnumerator();
		}

		public void Dispose()
		{
			dictionary?.Dispose();
			source.Dispose();
		}
	}
}
