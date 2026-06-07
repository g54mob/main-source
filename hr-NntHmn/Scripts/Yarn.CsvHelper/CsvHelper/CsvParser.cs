using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public class CsvParser : IParser, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string[]> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private ConfiguredTaskAwaitable<string[]>.ConfiguredTaskAwaiter _003C_003Eu__1;

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
		private struct _003CReadLineAsync_003Ed__20 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string[]> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__2;

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
		private struct _003CReadBlankLineAsync_003Ed__22 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__2;

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
		private struct _003CReadFieldAsync_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private bool _003CinSpaces_003E5__2;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter _003C_003Eu__2;

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
		private struct _003CReadQuotedFieldAsync_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private bool _003CinQuotes_003E5__2;

			private int _003CquoteCount_003E5__3;

			private int _003CcPrev_003E5__4;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter _003C_003Eu__2;

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
		private struct _003CReadDelimiterAsync_003Ed__28 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private int _003Ci_003E5__2;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

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
		private struct _003CReadLineEndingAsync_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private int _003CfieldStartOffset_003E5__2;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

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
		private struct _003CReadSpacesAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public CsvParser _003C_003E4__this;

			private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter _003C_003Eu__1;

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

		private IFieldReader fieldReader;

		private bool disposed;

		private int c;

		public virtual ReadingContext Context => null;

		public virtual IParserConfiguration Configuration => null;

		public virtual IFieldReader FieldReader => null;

		public CsvParser(TextReader reader)
		{
		}

		public CsvParser(TextReader reader, bool leaveOpen)
		{
		}

		public CsvParser(TextReader reader, CsvHelper.Configuration.Configuration configuration)
		{
		}

		public CsvParser(TextReader reader, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public CsvParser(IFieldReader fieldReader)
		{
		}

		public virtual string[] Read()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadAsync_003Ed__16))]
		public virtual Task<string[]> ReadAsync()
		{
			return null;
		}

		public virtual void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		protected virtual string[] ReadLine()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadLineAsync_003Ed__20))]
		protected virtual Task<string[]> ReadLineAsync()
		{
			return null;
		}

		protected virtual void ReadBlankLine()
		{
		}

		[AsyncStateMachine(typeof(_003CReadBlankLineAsync_003Ed__22))]
		protected virtual Task ReadBlankLineAsync()
		{
			return null;
		}

		protected virtual bool ReadField()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CReadFieldAsync_003Ed__24))]
		protected virtual Task<bool> ReadFieldAsync()
		{
			return null;
		}

		protected virtual bool ReadQuotedField()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CReadQuotedFieldAsync_003Ed__26))]
		protected virtual Task<bool> ReadQuotedFieldAsync()
		{
			return null;
		}

		protected virtual bool ReadDelimiter()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CReadDelimiterAsync_003Ed__28))]
		protected virtual Task<bool> ReadDelimiterAsync()
		{
			return null;
		}

		protected virtual int ReadLineEnding()
		{
			return 0;
		}

		[AsyncStateMachine(typeof(_003CReadLineEndingAsync_003Ed__30))]
		protected virtual Task<int> ReadLineEndingAsync()
		{
			return null;
		}

		protected virtual bool ReadSpaces()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CReadSpacesAsync_003Ed__32))]
		protected virtual Task<bool> ReadSpacesAsync()
		{
			return null;
		}
	}
}
