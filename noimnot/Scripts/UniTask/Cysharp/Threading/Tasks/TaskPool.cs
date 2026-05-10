using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cysharp.Threading.Tasks
{
	public static class TaskPool
	{
		[CompilerGenerated]
		private sealed class _003CGetCacheSizeInfo_003Ed__4 : IEnumerable<(Type, int)>, IEnumerable, IEnumerator<(Type, int)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (Type, int) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Dictionary<Type, Func<int>> _003C_003E7__wrap1;

			private bool _003C_003E7__wrap2;

			private Dictionary<Type, Func<int>>.Enumerator _003C_003E7__wrap3;

			(Type, int) IEnumerator<(Type, int)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((Type, int));
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
			public _003CGetCacheSizeInfo_003Ed__4(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<(Type, int)> IEnumerable<(Type, int)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		internal static int MaxPoolSize;

		private static Dictionary<Type, Func<int>> sizes;

		static TaskPool()
		{
		}

		public static void SetMaxPoolSize(int maxPoolSize)
		{
		}

		[IteratorStateMachine(typeof(_003CGetCacheSizeInfo_003Ed__4))]
		public static IEnumerable<(Type, int)> GetCacheSizeInfo()
		{
			return null;
		}

		public static void RegisterSizeGetter(Type type, Func<int> getSize)
		{
		}
	}
	[StructLayout((LayoutKind)3)]
	public struct TaskPool<T> where T : class, ITaskPoolNode<T>
	{
		private int gate;

		private int size;

		private T root;

		public int Size => 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPop(out T result)
		{
			result = null;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPush(T item)
		{
			return false;
		}
	}
}
