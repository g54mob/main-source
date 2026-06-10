using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ModIO.Implementation.Platform
{
	internal class FileStreamWrapper : ModIOFileStream
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadAllBytesAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public FileStreamWrapper _003C_003E4__this;

			private byte[] _003Cdata_003E5__2;

			private TaskAwaiter<int> _003C_003Eu__1;

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
		private struct _003CWriteAllBytesAsync_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			public FileStreamWrapper _003C_003E4__this;

			public byte[] buffer;

			private TaskAwaiter _003C_003Eu__1;

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

		private FileStream fileStream;

		private Result result;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanTimeout => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int WriteTimeout
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override string FilePath => null;

		public FileStreamWrapper(FileStream internalStream)
		{
		}

		public Result GetLastResult()
		{
			return default(Result);
		}

		public override void Close()
		{
		}

		public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			return null;
		}

		public override void Flush()
		{
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return null;
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadAllBytesAsync_003Ed__32))]
		public override Task<ResultAnd<byte[]>> ReadAllBytesAsync()
		{
			return null;
		}

		public override ResultAnd<byte[]> ReadAllBytes()
		{
			return null;
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWriteAllBytesAsync_003Ed__39))]
		public override Task<Result> WriteAllBytesAsync(byte[] buffer)
		{
			return null;
		}

		public override Result WriteAllBytes(byte[] buffer)
		{
			return default(Result);
		}

		public override void WriteByte(byte value)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		[Obsolete("Use ReadAsync instead.")]
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		[Obsolete("Use WriteAsync instead.")]
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		[Obsolete]
		public override int EndRead(IAsyncResult asyncResult)
		{
			return 0;
		}

		[Obsolete]
		public override void EndWrite(IAsyncResult asyncResult)
		{
		}

		[Obsolete("CreateWaitHandle will be removed eventually.  Please use \"new ManualResetEvent(false)\" instead.")]
		protected override WaitHandle CreateWaitHandle()
		{
			return null;
		}
	}
}
