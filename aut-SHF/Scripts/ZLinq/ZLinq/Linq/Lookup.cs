using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal static class Lookup
	{
		public static Lookup<TKey, TSource> CreateForJoin<TEnumerator, TSource, TKey>(ref TEnumerator source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return null;
		}
	}
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(LookupDebugView<, >))]
	public sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>, IEnumerable<IGrouping<TKey, TElement>>, IEnumerable, ICollection<IGrouping<TKey, TElement>>, IReadOnlyCollection<IGrouping<TKey, TElement>> where TKey : notnull where TElement : notnull
	{
		[CompilerGenerated]
		private sealed class _003CApplyResultSelector_003Ed__11<TResult> : IEnumerable<TResult>, IEnumerable, IEnumerator<TResult>, IEnumerator, IDisposable where TResult : notnull
		{
			private int _003C_003E1__state;

			private TResult _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<TKey, IEnumerable<TElement>, TResult> resultSelector;

			public Func<TKey, IEnumerable<TElement>, TResult> _003C_003E3__resultSelector;

			public Lookup<TKey, TElement> _003C_003E4__this;

			private Grouping<TKey, TElement> _003Cgroup_003E5__2;

			private Grouping<TKey, TElement> _003Cfirst_003E5__3;

			TResult IEnumerator<TResult>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(TResult);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CApplyResultSelector_003Ed__11(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__14 : IEnumerator<IGrouping<TKey, TElement>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private IGrouping<TKey, TElement> _003C_003E2__current;

			public Lookup<TKey, TElement> _003C_003E4__this;

			private Grouping<TKey, TElement> _003Cgroup_003E5__2;

			private Grouping<TKey, TElement> _003Cfirst_003E5__3;

			IGrouping<TKey, TElement> IEnumerator<IGrouping<TKey, TElement>>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetEnumerator_003Ed__14(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		internal static readonly Lookup<TKey, TElement> Empty;

		private readonly Grouping<TKey, TElement>?[]? groups;

		private readonly Grouping<TKey, TElement>? last;

		private readonly int count;

		private readonly IEqualityComparer<TKey> comparer;

		public IEnumerable<TElement> this[TKey key] => null;

		public int Count => 0;

		bool ICollection<IGrouping<TKey, TElement>>.IsReadOnly => false;

		private Lookup()
		{
		}

		internal Lookup(Grouping<TKey, TElement>[]? groupings, Grouping<TKey, TElement>? last, int count, IEqualityComparer<TKey> comparer)
		{
		}

		[IteratorStateMachine(typeof(_003CApplyResultSelector_003Ed__11<>))]
		public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IEnumerable<TElement>, TResult> resultSelector) where TResult : notnull
		{
			return null;
		}

		public bool Contains(TKey key)
		{
			return false;
		}

		internal Grouping<TKey, TElement> GetGroup(TKey key)
		{
			return null;
		}

		[IteratorStateMachine(typeof(Lookup<, >._003CGetEnumerator_003Ed__14))]
		public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetBucketIndex(uint hashCode)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private uint InternalGetHashCode(TKey key)
		{
			return 0u;
		}

		void ICollection<IGrouping<TKey, TElement>>.Add(IGrouping<TKey, TElement> item)
		{
		}

		bool ICollection<IGrouping<TKey, TElement>>.Remove(IGrouping<TKey, TElement> item)
		{
			return false;
		}

		void ICollection<IGrouping<TKey, TElement>>.Clear()
		{
		}

		bool ICollection<IGrouping<TKey, TElement>>.Contains(IGrouping<TKey, TElement> item)
		{
			return false;
		}

		void ICollection<IGrouping<TKey, TElement>>.CopyTo(IGrouping<TKey, TElement>[] array, int arrayIndex)
		{
		}
	}
}
