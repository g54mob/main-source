using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Expressions;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class CsvWriter : IWriter, IWriterRow, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFlushAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CsvWriter _003C_003E4__this;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CNextRecordAsync_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CsvWriter _003C_003E4__this;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__1;

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

		private readonly Lazy<RecordManager> recordManager;

		private WritingContext context;

		private bool disposed;

		private ISerializer serializer;

		public virtual WritingContext Context => null;

		public virtual IWriterConfiguration Configuration => null;

		public CsvWriter(TextWriter writer)
		{
		}

		public CsvWriter(TextWriter writer, bool leaveOpen)
		{
		}

		public CsvWriter(TextWriter writer, CsvHelper.Configuration.Configuration configuration)
		{
		}

		public CsvWriter(TextWriter writer, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public CsvWriter(ISerializer serializer)
		{
		}

		public virtual void WriteConvertedField(string field)
		{
		}

		public virtual void WriteField(string field)
		{
		}

		public virtual void WriteField(string field, bool shouldQuote)
		{
		}

		public virtual void WriteField<T>(T field)
		{
		}

		public virtual void WriteField<T>(T field, ITypeConverter converter)
		{
		}

		public virtual void WriteField<T, TConverter>(T field)
		{
		}

		public virtual void Flush()
		{
		}

		[AsyncStateMachine(typeof(_003CFlushAsync_003Ed__20))]
		public virtual Task FlushAsync()
		{
			return null;
		}

		public virtual void NextRecord()
		{
		}

		[AsyncStateMachine(typeof(_003CNextRecordAsync_003Ed__22))]
		public virtual Task NextRecordAsync()
		{
			return null;
		}

		public virtual void WriteComment(string comment)
		{
		}

		public virtual void WriteHeader<T>()
		{
		}

		public virtual void WriteHeader(Type type)
		{
		}

		public virtual void WriteDynamicHeader(IDynamicMetaObjectProvider record)
		{
		}

		public virtual void WriteRecord<T>(T record)
		{
		}

		public virtual void WriteRecords(IEnumerable records)
		{
		}

		public virtual void WriteRecords<T>(IEnumerable<T> records)
		{
		}

		public virtual bool CanWrite(MemberMap memberMap)
		{
			return false;
		}

		public virtual Type GetTypeForRecord<T>(T record)
		{
			return null;
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
