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
	public struct CountBy<TEnumerator, TSource, TKey> : IValueEnumerator<KeyValuePair<TKey, int>>, IDisposable where TEnumerator : struct, IValueEnumerator<TSource>
	{
		private TEnumerator source;

		private DictionarySlim<TKey, int>? dictionary;

		private DictionarySlim<TKey, int>.Enumerator enumerator;

		public CountBy(TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer)
		{
			_003CkeySelector_003EP = keySelector;
			_003CkeyComparer_003EP = keyComparer;
			dictionary = null;
			enumerator = default(DictionarySlim<TKey, int>.Enumerator);
			this.source = source;
		}

		public bool TryGetNonEnumeratedCount(out int count)
		{
			count = 0;
			return false;
		}

		public bool TryGetSpan(out ReadOnlySpan<KeyValuePair<TKey, int>> span)
		{
			span = default(ReadOnlySpan<KeyValuePair<TKey, int>>);
			return false;
		}

		public bool TryCopyTo([ScopedRef] Span<KeyValuePair<TKey, int>> destination, Index offset)
		{
			return false;
		}

		public bool TryGetNext(out KeyValuePair<TKey, int> current)
		{
			if (dictionary == null)
			{
				if (source.TryGetNonEnumeratedCount(out var count) && count == 0)
				{
					Unsafe.SkipInit<KeyValuePair<TKey, int>>(out current);
					return false;
				}
				Initialize();
			}
			if (enumerator.TryGetNext(out current))
			{
				return true;
			}
			Unsafe.SkipInit<KeyValuePair<TKey, int>>(out current);
			return false;
		}

		private void Initialize()
		{
			DictionarySlim<TKey, int> dictionarySlim = ((_003CkeyComparer_003EP != null) ? new DictionarySlim<TKey, int>(_003CkeyComparer_003EP) : new DictionarySlim<TKey, int>());
			checked
			{
				using (source)
				{
					if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
					{
						ReadOnlySpan<TSource> readOnlySpan = span;
						for (int i = 0; i < readOnlySpan.Length; i = unchecked(i + 1))
						{
							TSource arg = readOnlySpan[i];
							dictionarySlim.GetValueRefOrAddDefault(_003CkeySelector_003EP(arg), out var _)++;
						}
					}
					else
					{
						TSource current;
						while (source.TryGetNext(out current))
						{
							dictionarySlim.GetValueRefOrAddDefault(_003CkeySelector_003EP(current), out var _)++;
						}
					}
				}
				dictionary = dictionarySlim;
				enumerator = dictionary.GetEnumerator();
			}
		}

		public void Dispose()
		{
			dictionary?.Dispose();
			source.Dispose();
		}
	}
}
