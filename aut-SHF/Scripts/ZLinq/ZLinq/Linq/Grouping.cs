using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	[DebuggerDisplay("Key = {Key}")]
	[DebuggerTypeProxy(typeof(GroupingDebugView<, >))]
	internal sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable, IList<TElement>, ICollection<TElement>, IReadOnlyList<TElement>, IReadOnlyCollection<TElement> where TKey : notnull where TElement : notnull
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__20 : IEnumerator<TElement>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TElement _003C_003E2__current;

			public Grouping<TKey, TElement> _003C_003E4__this;

			private int _003Ci_003E5__2;

			TElement IEnumerator<TElement>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(TElement);
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
			public _003CGetEnumerator_003Ed__20(int _003C_003E1__state)
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

		private TKey key;

		private uint hashCode;

		private TElement[] elements;

		private int count;

		public Grouping<TKey, TElement>? NextGroupInAddOrder;

		public Grouping<TKey, TElement>? NextGroupInSameHashCode;

		public TKey Key => default(TKey);

		public uint HashCode => 0u;

		public int Count => 0;

		public bool IsReadOnly => false;

		public TElement this[int index]
		{
			get
			{
				return default(TElement);
			}
			set
			{
			}
		}

		public Grouping(TKey key, uint hashCode, TElement value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(TElement value)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(Grouping<, >._003CGetEnumerator_003Ed__20))]
		public IEnumerator<TElement> GetEnumerator()
		{
			return null;
		}

		public int IndexOf(TElement item)
		{
			return 0;
		}

		public void Insert(int index, TElement item)
		{
		}

		public void RemoveAt(int index)
		{
		}

		void ICollection<TElement>.Add(TElement item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(TElement item)
		{
			return false;
		}

		public void CopyTo(TElement[] array, int arrayIndex)
		{
		}

		public bool Remove(TElement item)
		{
			return false;
		}
	}
}
