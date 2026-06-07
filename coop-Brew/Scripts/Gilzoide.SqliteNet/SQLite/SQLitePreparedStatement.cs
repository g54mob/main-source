using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SQLite
{
	public class SQLitePreparedStatement : IDisposable
	{
		[CompilerGenerated]
		private sealed class _003CEnumerateColumnNames_003Ed__24 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SQLitePreparedStatement _003C_003E4__this;

			private int _003Ci_003E5__2;

			private int _003CcolumnCount_003E5__3;

			string IEnumerator<string>.Current
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
			public _003CEnumerateColumnNames_003Ed__24(int _003C_003E1__state)
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
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
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
		private sealed class _003CEnumerateColumnsAsText_003Ed__25 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SQLitePreparedStatement _003C_003E4__this;

			private int _003Ci_003E5__2;

			private int _003CcolumnCount_003E5__3;

			string IEnumerator<string>.Current
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
			public _003CEnumerateColumnsAsText_003Ed__25(int _003C_003E1__state)
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
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static readonly IntPtr SQLITE_STATIC;

		private SQLiteConnection _db;

		private IntPtr _preparedStatement;

		public SQLitePreparedStatement(SQLiteConnection db, string statement)
		{
		}

		~SQLitePreparedStatement()
		{
		}

		public SQLite3.Result Reset()
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, bool value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, bool value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, int value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, int value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, long value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, long value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, float value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, float value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, double value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, double value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, string value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, string value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(int index, byte[] value)
		{
			return default(SQLite3.Result);
		}

		public SQLite3.Result Bind(string name, byte[] value)
		{
			return default(SQLite3.Result);
		}

		public int BindParameterIndex(string name)
		{
			return 0;
		}

		public SQLite3.Result Step()
		{
			return default(SQLite3.Result);
		}

		public int GetColumnCount()
		{
			return 0;
		}

		public string GetColumnName(int column)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEnumerateColumnNames_003Ed__24))]
		public IEnumerable<string> EnumerateColumnNames()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEnumerateColumnsAsText_003Ed__25))]
		public IEnumerable<string> EnumerateColumnsAsText()
		{
			return null;
		}

		public bool GetBool(int column)
		{
			return false;
		}

		public int GetInt(int column)
		{
			return 0;
		}

		public long GetLong(int column)
		{
			return 0L;
		}

		public float GetFloat(int column)
		{
			return 0f;
		}

		public double GetDouble(int column)
		{
			return 0.0;
		}

		public string GetString(int column)
		{
			return null;
		}

		public byte[] GetBytes(int column)
		{
			return null;
		}

		public void Dispose()
		{
		}

		private void ThrowIfDisposed()
		{
		}
	}
}
