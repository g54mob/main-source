using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Google.Protobuf.Collections
{
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(RepeatedField<>.RepeatedFieldDebugView))]
	public sealed class RepeatedField<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IDeepCloneable<RepeatedField<T>>, IEquatable<RepeatedField<T>>, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		private sealed class RepeatedFieldDebugView
		{
			private readonly RepeatedField<T> list;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public T[] Items => null;

			public RepeatedFieldDebugView(RepeatedField<T> list)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__28 : IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			public RepeatedField<T> _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CGetEnumerator_003Ed__28(int _003C_003E1__state)
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

		private static readonly EqualityComparer<T> EqualityComparer;

		private static readonly T[] EmptyArray;

		private const int MinArraySize = 8;

		private T[] array;

		private int count;

		public int Capacity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Count => 0;

		public bool IsReadOnly => false;

		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		bool IList.IsFixedSize => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		object IList.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RepeatedField<T> Clone()
		{
			return null;
		}

		public void AddEntriesFrom(CodedInputStream input, FieldCodec<T> codec)
		{
		}

		public void AddEntriesFrom(ref ParseContext ctx, FieldCodec<T> codec)
		{
		}

		public int CalculateSize(FieldCodec<T> codec)
		{
			return 0;
		}

		private int CalculatePackedDataSize(FieldCodec<T> codec)
		{
			return 0;
		}

		public void WriteTo(CodedOutputStream output, FieldCodec<T> codec)
		{
		}

		public void WriteTo(ref WriteContext ctx, FieldCodec<T> codec)
		{
		}

		private void EnsureSize(int size)
		{
		}

		private void SetSize(int size)
		{
		}

		public void Add(T item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public bool Remove(T item)
		{
			return false;
		}

		public void AddRange(IEnumerable<T> values)
		{
		}

		public void Add(IEnumerable<T> values)
		{
		}

		[IteratorStateMachine(typeof(RepeatedField<>._003CGetEnumerator_003Ed__28))]
		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(RepeatedField<T> other)
		{
			return false;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public void Insert(int index, T item)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public override string ToString()
		{
			return null;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		int IList.Add(object value)
		{
			return 0;
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		int IList.IndexOf(object value)
		{
			return 0;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}
	}
}
