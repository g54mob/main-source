using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttp
{
	public class SimpleHttpRequest
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDoGet_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SimpleHttpResponse> _003C_003Et__builder;

			public SimpleHttpRequest _003C_003E4__this;

			private TaskAwaiter<SimpleHttpResponse> _003C_003Eu__1;

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
		private struct _003CDoPost_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SimpleHttpResponse> _003C_003Et__builder;

			public SimpleHttpRequest _003C_003E4__this;

			public byte[] requestData;

			private TaskAwaiter<SimpleHttpResponse> _003C_003Eu__1;

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
		private struct _003CDoRequest_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SimpleHttpResponse> _003C_003Et__builder;

			public SimpleHttpRequest _003C_003E4__this;

			public byte[] requestData;

			private StringBuilder _003Cbuilder_003E5__2;

			private TcpClient _003Cclient_003E5__3;

			private int _003CconnectTimeoutInMs_003E5__4;

			private NetworkStream _003CnetStream_003E5__5;

			private Stream _003Cstream_003E5__6;

			private TaskAwaiter _003C_003Eu__1;

			private object _003C_003E7__wrap6;

			private int _003C_003E7__wrap7;

			private SimpleHttpResponse _003C_003E7__wrap8;

			private SslStream _003CsslStream_003E5__10;

			private MemoryStream _003CstreamToWrite_003E5__11;

			private byte[] _003CwriteBuffer_003E5__12;

			private long _003CbytesToWrite_003E5__13;

			private int _003Clength_003E5__14;

			private TaskAwaiter<int> _003C_003Eu__2;

			private TaskAwaiter<SimpleHttpResponse> _003C_003Eu__3;

			private ValueTaskAwaiter _003C_003Eu__4;

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

		private static string EOL;

		private static string HTTP_PROTO;

		private static int MAX_TRIES;

		private readonly Dictionary<string, List<string>> headers;

		private Uri uri;

		private int readTimeoutInMs;

		private int sendTimeoutInMs;

		private string method;

		private int tries;

		public void SetUrl(string url)
		{
		}

		public void SetSendTimeout(int timeoutInMs)
		{
		}

		public void SetReadTimeout(int timeoutInMs)
		{
		}

		public void AddHeader(string name, string value)
		{
		}

		[AsyncStateMachine(typeof(_003CDoGet_003Ed__13))]
		public Task<SimpleHttpResponse> DoGet()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDoPost_003Ed__14))]
		public Task<SimpleHttpResponse> DoPost(byte[] requestData)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDoRequest_003Ed__15))]
		private Task<SimpleHttpResponse> DoRequest(byte[] requestData = null)
		{
			return null;
		}

		private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}
	}
}
