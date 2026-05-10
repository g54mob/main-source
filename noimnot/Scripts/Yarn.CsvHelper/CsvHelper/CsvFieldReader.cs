using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public class CsvFieldReader : IFieldReader, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFillBufferAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CsvFieldReader _003C_003E4__this;

			private ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter _003C_003Eu__1;

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

		private ReadingContext context;

		private bool disposed;

		public virtual ReadingContext Context => null;

		public virtual bool IsBufferEmpty => false;

		public virtual bool FillBuffer()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CFillBufferAsync_003Ed__7))]
		public virtual Task<bool> FillBufferAsync()
		{
			return null;
		}

		public CsvFieldReader(TextReader reader, CsvHelper.Configuration.Configuration configuration)
		{
		}

		public CsvFieldReader(TextReader reader, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public virtual int GetChar()
		{
			return 0;
		}

		public virtual string GetField()
		{
			return null;
		}

		public virtual void AppendField()
		{
		}

		public virtual void SetBufferPosition(int offset = 0)
		{
		}

		public virtual void SetFieldStart(int offset = 0)
		{
		}

		public virtual void SetFieldEnd(int offset = 0)
		{
		}

		public virtual void SetRawRecordStart(int offset)
		{
		}

		public virtual void SetRawRecordEnd(int offset)
		{
		}

		public virtual void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
