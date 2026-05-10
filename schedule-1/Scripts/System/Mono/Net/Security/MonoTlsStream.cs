using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Mono.Security.Interface;

namespace Mono.Net.Security
{
	internal class MonoTlsStream : IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateStream_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Stream> _003C_003Et__builder;

			public MonoTlsStream _003C_003E4__this;

			public WebConnectionTunnel tunnel;

			public CancellationToken cancellationToken;

			private Socket _003Csocket_003E5__2;

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

		private readonly MobileTlsProvider provider;

		private readonly NetworkStream networkStream;

		private readonly HttpWebRequest request;

		private readonly MonoTlsSettings settings;

		private SslStream sslStream;

		private readonly object sslStreamLock;

		private WebExceptionStatus status;

		internal HttpWebRequest Request => null;

		internal WebExceptionStatus ExceptionStatus => default(WebExceptionStatus);

		internal bool CertificateValidationFailed { get; set; }

		public MonoTlsStream(HttpWebRequest request, NetworkStream networkStream)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateStream_003Ed__18))]
		internal Task<Stream> CreateStream(WebConnectionTunnel tunnel, CancellationToken cancellationToken)
		{
			return null;
		}

		public void Dispose()
		{
		}

		private void CloseSslStream()
		{
		}
	}
}
