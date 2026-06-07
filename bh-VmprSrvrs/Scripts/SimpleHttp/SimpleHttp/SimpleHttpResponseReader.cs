using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SimpleHttp
{
	public class SimpleHttpResponseReader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRead_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<SimpleHttpResponse> _003C_003Et__builder;

			public SimpleHttpResponseReader _003C_003E4__this;

			public Stream stream;

			private SimpleHttpResponse _003Cresponse_003E5__2;

			private TaskAwaiter<string> _003C_003Eu__1;

			private SimpleHttpResponse _003C_003E7__wrap2;

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
		private struct _003CReadBody_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public int contentLength;

			public Stream stream;

			public SimpleHttpResponseReader _003C_003E4__this;

			private byte[] _003Cbuffer_003E5__2;

			private long _003CbytesRead_003E5__3;

			private MemoryStream _003CmemoryStream_003E5__4;

			private int _003CbytesThisRead_003E5__5;

			private TaskAwaiter<int> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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
		private struct _003CReadChunkedResponse_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public Stream stream;

			public SimpleHttpResponseReader _003C_003E4__this;

			private StreamReader _003Creader_003E5__2;

			private string _003Cresponse_003E5__3;

			private char[] _003CchunkBuffer_003E5__4;

			private TaskAwaiter<string> _003C_003Eu__1;

			private TaskAwaiter<int> _003C_003Eu__2;

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
		private struct _003CReadLine_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public Stream stream;

			public SimpleHttpResponseReader _003C_003E4__this;

			private List<byte> _003ClineBytes_003E5__2;

			private byte[] _003Cbuffer_003E5__3;

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

		private readonly int readTimeoutInMs;

		public SimpleHttpResponseReader(int readTimeoutInMs)
		{
		}

		[AsyncStateMachine(typeof(_003CRead_003Ed__2))]
		public Task<SimpleHttpResponse> Read(Stream stream)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadLine_003Ed__3))]
		private Task<string> ReadLine(Stream stream)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadBody_003Ed__4))]
		private Task<string> ReadBody(Stream stream, int contentLength)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CReadChunkedResponse_003Ed__5))]
		private Task<string> ReadChunkedResponse(Stream stream)
		{
			return null;
		}
	}
}
