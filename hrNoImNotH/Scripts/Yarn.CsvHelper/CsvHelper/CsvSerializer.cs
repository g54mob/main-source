using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public class CsvSerializer : ISerializer, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWriteAsync_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CsvSerializer _003C_003E4__this;

			public string[] record;

			private int _003Ci_003E5__2;

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
		private struct _003CWriteLineAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CsvSerializer _003C_003E4__this;

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

		private WritingContext context;

		private bool disposed;

		public virtual WritingContext Context => null;

		public virtual ISerializerConfiguration Configuration => null;

		public CsvSerializer(TextWriter writer)
		{
		}

		public CsvSerializer(TextWriter writer, bool leaveOpen)
		{
		}

		public CsvSerializer(TextWriter writer, CsvHelper.Configuration.Configuration configuration)
		{
		}

		public CsvSerializer(TextWriter writer, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public virtual void Write(string[] record)
		{
		}

		[AsyncStateMachine(typeof(_003CWriteAsync_003Ed__11))]
		public virtual Task WriteAsync(string[] record)
		{
			return null;
		}

		public virtual void WriteLine()
		{
		}

		[AsyncStateMachine(typeof(_003CWriteLineAsync_003Ed__13))]
		public virtual Task WriteLineAsync()
		{
			return null;
		}

		public virtual void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		protected virtual string SanitizeForInjection(string field)
		{
			return null;
		}
	}
}
