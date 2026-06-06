using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SQLite
{
	public class SQLiteCommand
	{
		private class Binding
		{
			public string Name { get; set; }

			public object Value { get; set; }

			public int Index { get; set; }
		}

		[CompilerGenerated]
		private sealed class _003CExecuteDeferredQuery_003Ed__12<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SQLiteCommand _003C_003E4__this;

			private TableMapping map;

			public TableMapping _003C_003E3__map;

			private IntPtr _003Cstmt_003E5__2;

			private TableMapping.Column[] _003Ccols_003E5__3;

			private Action<object, IntPtr, int>[] _003CfastColumnSetters_003E5__4;

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
			public _003CExecuteDeferredQuery_003Ed__12(int _003C_003E1__state)
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
		private sealed class _003CExecuteQueryScalars_003Ed__14<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SQLiteCommand _003C_003E4__this;

			private IntPtr _003Cstmt_003E5__2;

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
			public _003CExecuteQueryScalars_003Ed__14(int _003C_003E1__state)
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

		private SQLiteConnection _conn;

		private List<Binding> _bindings;

		private static IntPtr NegativePointer;

		public string CommandText { get; set; }

		public SQLiteCommand(SQLiteConnection conn)
		{
		}

		public int ExecuteNonQuery()
		{
			return 0;
		}

		public IEnumerable<T> ExecuteDeferredQuery<T>()
		{
			return null;
		}

		public List<T> ExecuteQuery<T>()
		{
			return null;
		}

		public List<T> ExecuteQuery<T>(TableMapping map)
		{
			return null;
		}

		protected virtual void OnInstanceCreated(object obj)
		{
		}

		[IteratorStateMachine(typeof(_003CExecuteDeferredQuery_003Ed__12<>))]
		public IEnumerable<T> ExecuteDeferredQuery<T>(TableMapping map)
		{
			return null;
		}

		public T ExecuteScalar<T>()
		{
			return default(T);
		}

		[IteratorStateMachine(typeof(_003CExecuteQueryScalars_003Ed__14<>))]
		public IEnumerable<T> ExecuteQueryScalars<T>()
		{
			return null;
		}

		public void Bind(string name, object val)
		{
		}

		public void Bind(object val)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private IntPtr Prepare()
		{
			return (IntPtr)0;
		}

		private void Finalize(IntPtr stmt)
		{
		}

		private void BindAll(IntPtr stmt)
		{
		}

		internal static void BindParameter(IntPtr stmt, int index, object value, bool storeDateTimeAsTicks, string dateTimeStringFormat, bool storeTimeSpanAsTicks)
		{
		}

		private object ReadCol(IntPtr stmt, int index, SQLite3.ColType type, Type clrType)
		{
			return null;
		}
	}
}
