using System;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Mono.Security.Interface;

namespace Mono.Net.Security
{
	internal abstract class MobileAuthenticatedStream : AuthenticatedStream, IDisposable
	{
		private enum Operation
		{
			None = 0,
			Handshake = 1,
			Authenticated = 2,
			Renegotiate = 3,
			Read = 4,
			Write = 5,
			Close = 6
		}

		private enum OperationType
		{
			Read = 0,
			Write = 1,
			Renegotiate = 2,
			Shutdown = 3
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CProcessAuthentication_003Ed__48 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public MonoSslAuthenticationOptions options;

			public MobileAuthenticatedStream _003C_003E4__this;

			public bool runSynchronously;

			public CancellationToken cancellationToken;

			private ConfiguredTaskAwaitable<AsyncProtocolResult>.ConfiguredTaskAwaiter _003C_003Eu__1;

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
		private struct _003CStartOperation_003Ed__57 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

			public MobileAuthenticatedStream _003C_003E4__this;

			public OperationType type;

			public AsyncProtocolRequest asyncRequest;

			public CancellationToken cancellationToken;

			private ConfiguredTaskAwaitable<AsyncProtocolResult>.ConfiguredTaskAwaiter _003C_003Eu__1;

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
		private struct _003CInnerRead_003Ed__66 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

			public MobileAuthenticatedStream _003C_003E4__this;

			public CancellationToken cancellationToken;

			public int requestedSize;

			public bool sync;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInnerWrite_003Ed__67 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public CancellationToken cancellationToken;

			public MobileAuthenticatedStream _003C_003E4__this;

			public bool sync;

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

		private MobileTlsContext xobileTlsContext;

		private ExceptionDispatchInfo lastException;

		private AsyncProtocolRequest asyncHandshakeRequest;

		private AsyncProtocolRequest asyncReadRequest;

		private AsyncProtocolRequest asyncWriteRequest;

		private BufferOffsetSize2 readBuffer;

		private BufferOffsetSize2 writeBuffer;

		private object ioLock;

		private int closeRequested;

		private bool shutdown;

		private Operation operation;

		private static int uniqueNameInteger;

		private static int nextId;

		internal readonly int ID;

		public SslStream SslStream { get; }

		public MonoTlsSettings Settings { get; }

		public MobileTlsProvider Provider { get; }

		internal string TargetHost { get; private set; }

		public override bool IsAuthenticated => false;

		public X509Certificate LocalCertificate => null;

		public X509Certificate InternalLocalCertificate => null;

		public override bool CanRead => false;

		public override bool CanTimeout => false;

		public override bool CanWrite => false;

		public override bool CanSeek => false;

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

		public MobileAuthenticatedStream(Stream innerStream, bool leaveInnerStreamOpen, SslStream owner, MonoTlsSettings settings, MobileTlsProvider provider)
			: base(null, leaveInnerStreamOpen: false)
		{
		}

		internal void CheckThrow(bool authSuccessCheck, bool shutdownCheck = false)
		{
		}

		internal static Exception GetSSPIException(Exception e)
		{
			return null;
		}

		internal static Exception GetIOException(Exception e, string message)
		{
			return null;
		}

		internal static Exception GetInternalError()
		{
			return null;
		}

		internal static Exception GetInvalidNestedCallException()
		{
			return null;
		}

		internal ExceptionDispatchInfo SetException(Exception e)
		{
			return null;
		}

		public void AuthenticateAsClient(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation)
		{
		}

		public Task AuthenticateAsClientAsync(string targetHost, X509CertificateCollection clientCertificates, SslProtocols enabledSslProtocols, bool checkCertificateRevocation)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CProcessAuthentication_003Ed__48))]
		private Task ProcessAuthentication(bool runSynchronously, MonoSslAuthenticationOptions options, CancellationToken cancellationToken)
		{
			return null;
		}

		protected abstract MobileTlsContext CreateContext(MonoSslAuthenticationOptions options);

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return null;
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CStartOperation_003Ed__57))]
		private Task<int> StartOperation(OperationType type, AsyncProtocolRequest asyncRequest, CancellationToken cancellationToken)
		{
			return null;
		}

		internal int InternalRead(byte[] buffer, int offset, int size, out bool outWantMore)
		{
			outWantMore = default(bool);
			return 0;
		}

		private (int, bool) InternalRead(AsyncProtocolRequest asyncRequest, BufferOffsetSize internalBuffer, byte[] buffer, int offset, int size)
		{
			return default((int, bool));
		}

		internal bool InternalWrite(byte[] buffer, int offset, int size)
		{
			return false;
		}

		private bool InternalWrite(AsyncProtocolRequest asyncRequest, BufferOffsetSize2 internalBuffer, byte[] buffer, int offset, int size)
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CInnerRead_003Ed__66))]
		internal Task<int> InnerRead(bool sync, int requestedSize, CancellationToken cancellationToken)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CInnerWrite_003Ed__67))]
		internal Task InnerWrite(bool sync, CancellationToken cancellationToken)
		{
			return null;
		}

		internal AsyncOperationStatus ProcessHandshake(AsyncOperationStatus status, bool renegotiate)
		{
			return default(AsyncOperationStatus);
		}

		internal (int, bool) ProcessRead(BufferOffsetSize userBuffer)
		{
			return default((int, bool));
		}

		internal (int, bool) ProcessWrite(BufferOffsetSize userBuffer)
		{
			return default((int, bool));
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}
	}
}
