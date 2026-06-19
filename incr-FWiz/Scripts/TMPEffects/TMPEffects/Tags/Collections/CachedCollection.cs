using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TMPEffects.Tags.Collections
{
	internal class CachedCollection<T> : IEnumerable<T>, IEnumerable where T : ITagWrapper
	{
		public class MinMax
		{
			public int MaxIndex;

			public int MinIndex;

			public MinMax(int textIndex)
			{
			}
		}

		public struct StructReversedContainingEnumerable
		{
			private readonly List<T> pool;

			private int containedIndex;

			private int minIndex;

			private int maxIndex;

			public StructReversedContainingEnumerable(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = null;
				this.containedIndex = 0;
				this.minIndex = 0;
				this.maxIndex = 0;
			}

			public StructReversedContainingEnumerator GetEnumerator()
			{
				return default(StructReversedContainingEnumerator);
			}
		}

		public struct StructContainingEnumerable
		{
			private readonly List<T> pool;

			private int containedIndex;

			private int minIndex;

			private int maxIndex;

			public StructContainingEnumerable(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = null;
				this.containedIndex = 0;
				this.minIndex = 0;
				this.maxIndex = 0;
			}

			public StructContainingEnumerator GetEnumerator()
			{
				return default(StructContainingEnumerator);
			}
		}

		public struct StructReversedContainingEnumerator
		{
			private readonly List<T> pool;

			private readonly int containedIndex;

			private readonly int maxIndex;

			private readonly int minIndex;

			private int index;

			public T Current => default(T);

			internal StructReversedContainingEnumerator(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = null;
				this.containedIndex = 0;
				this.maxIndex = 0;
				this.minIndex = 0;
				index = 0;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		public struct StructContainingEnumerator
		{
			private readonly List<T> pool;

			private readonly int containedIndex;

			private readonly int maxIndex;

			private readonly int minIndex;

			private int index;

			public T Current => default(T);

			internal StructContainingEnumerator(List<T> pool, int containedIndex, int maxIndex, int minIndex)
			{
				this.pool = null;
				this.containedIndex = 0;
				this.maxIndex = 0;
				this.minIndex = 0;
				index = 0;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAt_003Ed__11 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CachedCollection<T> _003C_003E4__this;

			private int textIndex;

			public int _003C_003E3__textIndex;

			private MinMax _003Cmm_003E5__2;

			private int _003Ci_003E5__3;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
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
			public _003CGetAt_003Ed__11(int _003C_003E1__state)
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
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
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
		private sealed class _003CGetContaining_003Ed__10 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CachedCollection<T> _003C_003E4__this;

			private int textIndex;

			public int _003C_003E3__textIndex;

			private MinMax _003Cmm_003E5__2;

			private int _003Ci_003E5__3;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
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
			public _003CGetContaining_003Ed__10(int _003C_003E1__state)
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
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private Dictionary<int, MinMax> minMax;

		private List<T> cache;

		private ITagCacher<T> cacher;

		private int max;

		private int min;

		public int Count => 0;

		public T this[int index] => default(T);

		public CachedCollection(ITagCacher<T> cacher, ObservableTagCollection tagCollection)
		{
		}

		public MinMax MinMaxAt(int textIndex)
		{
			return null;
		}

		public bool HasAny()
		{
			return false;
		}

		public bool HasAnyContaining(int textIndex)
		{
			return false;
		}

		public bool HasAnyAt(int index)
		{
			return false;
		}

		[IteratorStateMachine(typeof(CachedCollection<>._003CGetContaining_003Ed__10))]
		public IEnumerable<T> GetContaining(int textIndex)
		{
			return null;
		}

		[IteratorStateMachine(typeof(CachedCollection<>._003CGetAt_003Ed__11))]
		public IEnumerable<T> GetAt(int textIndex)
		{
			return null;
		}

		public StructContainingEnumerable GetContaining_NonAlloc(int textIndex)
		{
			return default(StructContainingEnumerable);
		}

		public StructReversedContainingEnumerable GetContainingReversed_NonAlloc(int textIndex)
		{
			return default(StructReversedContainingEnumerable);
		}

		private void Add(int cachedIndex, T tuple)
		{
		}

		private void Remove(int cachedIndex)
		{
		}

		private void Set(int cachedIndex, T tuple)
		{
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
