using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
	internal static class CollectionsMarshal
	{
		internal sealed class FillCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : notnull
		{
			[CompilerGenerated]
			private sealed class _003CGetEnumerator_003Ed__13 : IEnumerator<T>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private T _003C_003E2__current;

				public FillCollection<T> _003C_003E4__this;

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
				public _003CGetEnumerator_003Ed__13(int _003C_003E1__state)
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

			[ThreadStatic]
			public static FillCollection<T>? Instance;

			public int Count { get; set; }

			public bool IsReadOnly => false;

			public FillCollection(int count)
			{
			}

			public void CopyTo(T[] array, int arrayIndex)
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

			[IteratorStateMachine(typeof(FillCollection<>._003CGetEnumerator_003Ed__13))]
			public IEnumerator<T> GetEnumerator()
			{
				return null;
			}

			public bool Remove(T item)
			{
				return false;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		internal static readonly int ListSize;

		static CollectionsMarshal()
		{
		}

		internal static Span<T?> AsSpan<T>(this List<T>? list)
		{
			return default(Span<T>);
		}

		internal static void UnsafeSetCount<T>(this List<T>? list, int count)
		{
		}
	}
}
