using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class CsvReader : IReader, IReaderRow, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CsvReader _003C_003E4__this;

			private TaskAwaiter<string[]> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetRecords_003Ed__63<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CsvReader _003C_003E4__this;

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
			public _003CGetRecords_003Ed__63(int _003C_003E1__state)
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
		private sealed class _003CGetRecords_003Ed__65 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CsvReader _003C_003E4__this;

			private Type type;

			public Type _003C_003E3__type;

			object IEnumerator<object>.Current
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
			public _003CGetRecords_003Ed__65(int _003C_003E1__state)
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
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
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
		private sealed class _003CEnumerateRecords_003Ed__66<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CsvReader _003C_003E4__this;

			private T record;

			public T _003C_003E3__record;

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
			public _003CEnumerateRecords_003Ed__66(int _003C_003E1__state)
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

		private readonly Lazy<RecordManager> recordManager;

		private ReadingContext context;

		private bool disposed;

		private IParser parser;

		public virtual ReadingContext Context => null;

		public virtual IReaderConfiguration Configuration => null;

		public virtual IParser Parser => null;

		public virtual string this[int index] => null;

		public virtual string this[string name] => null;

		public virtual string this[string name, int index] => null;

		public CsvReader(TextReader reader)
		{
		}

		public CsvReader(TextReader reader, bool leaveOpen)
		{
		}

		public CsvReader(TextReader reader, CsvHelper.Configuration.Configuration configuration)
		{
		}

		public CsvReader(TextReader reader, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public CsvReader(IParser parser)
		{
		}

		public virtual bool ReadHeader()
		{
			return false;
		}

		public virtual void ValidateHeader<T>()
		{
		}

		public virtual void ValidateHeader(Type type)
		{
		}

		protected virtual void ValidateHeader(ClassMap map)
		{
		}

		public virtual bool Read()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CReadAsync_003Ed__20))]
		public virtual Task<bool> ReadAsync()
		{
			return null;
		}

		public virtual string GetField(int index)
		{
			return null;
		}

		public virtual string GetField(string name)
		{
			return null;
		}

		public virtual string GetField(string name, int index)
		{
			return null;
		}

		public virtual object GetField(Type type, int index)
		{
			return null;
		}

		public virtual object GetField(Type type, string name)
		{
			return null;
		}

		public virtual object GetField(Type type, string name, int index)
		{
			return null;
		}

		public virtual object GetField(Type type, int index, ITypeConverter converter)
		{
			return null;
		}

		public virtual object GetField(Type type, string name, ITypeConverter converter)
		{
			return null;
		}

		public virtual object GetField(Type type, string name, int index, ITypeConverter converter)
		{
			return null;
		}

		public virtual T GetField<T>(int index)
		{
			return default(T);
		}

		public virtual T GetField<T>(string name)
		{
			return default(T);
		}

		public virtual T GetField<T>(string name, int index)
		{
			return default(T);
		}

		public virtual T GetField<T>(int index, ITypeConverter converter)
		{
			return default(T);
		}

		public virtual T GetField<T>(string name, ITypeConverter converter)
		{
			return default(T);
		}

		public virtual T GetField<T>(string name, int index, ITypeConverter converter)
		{
			return default(T);
		}

		public virtual T GetField<T, TConverter>(int index) where TConverter : ITypeConverter
		{
			return default(T);
		}

		public virtual T GetField<T, TConverter>(string name) where TConverter : ITypeConverter
		{
			return default(T);
		}

		public virtual T GetField<T, TConverter>(string name, int index) where TConverter : ITypeConverter
		{
			return default(T);
		}

		public virtual bool TryGetField(Type type, int index, out object field)
		{
			field = null;
			return false;
		}

		public virtual bool TryGetField(Type type, string name, out object field)
		{
			field = null;
			return false;
		}

		public virtual bool TryGetField(Type type, string name, int index, out object field)
		{
			field = null;
			return false;
		}

		public virtual bool TryGetField(Type type, int index, ITypeConverter converter, out object field)
		{
			field = null;
			return false;
		}

		public virtual bool TryGetField(Type type, string name, ITypeConverter converter, out object field)
		{
			field = null;
			return false;
		}

		public virtual bool TryGetField(Type type, string name, int index, ITypeConverter converter, out object field)
		{
			field = null;
			return false;
		}

		public virtual bool TryGetField<T>(int index, out T field)
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T>(string name, out T field)
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T>(string name, int index, out T field)
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T>(int index, ITypeConverter converter, out T field)
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T>(string name, ITypeConverter converter, out T field)
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T>(string name, int index, ITypeConverter converter, out T field)
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T, TConverter>(int index, out T field) where TConverter : ITypeConverter
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T, TConverter>(string name, out T field) where TConverter : ITypeConverter
		{
			field = default(T);
			return false;
		}

		public virtual bool TryGetField<T, TConverter>(string name, int index, out T field) where TConverter : ITypeConverter
		{
			field = default(T);
			return false;
		}

		public virtual T GetRecord<T>()
		{
			return default(T);
		}

		public virtual T GetRecord<T>(T anonymousTypeDefinition)
		{
			return default(T);
		}

		public virtual object GetRecord(Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetRecords_003Ed__63<>))]
		public virtual IEnumerable<T> GetRecords<T>()
		{
			return null;
		}

		public virtual IEnumerable<T> GetRecords<T>(T anonymousTypeDefinition)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetRecords_003Ed__65))]
		public virtual IEnumerable<object> GetRecords(Type type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEnumerateRecords_003Ed__66<>))]
		public virtual IEnumerable<T> EnumerateRecords<T>(T record)
		{
			return null;
		}

		public virtual int GetFieldIndex(string name, int index = 0, bool isTryGet = false)
		{
			return 0;
		}

		public virtual int GetFieldIndex(string[] names, int index = 0, bool isTryGet = false, bool isOptional = false)
		{
			return 0;
		}

		public virtual bool CanRead(MemberMap memberMap)
		{
			return false;
		}

		public virtual bool CanRead(MemberReferenceMap memberReferenceMap)
		{
			return false;
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		protected virtual void CheckHasBeenRead()
		{
		}

		protected virtual void ParseNamedIndexes()
		{
		}
	}
}
