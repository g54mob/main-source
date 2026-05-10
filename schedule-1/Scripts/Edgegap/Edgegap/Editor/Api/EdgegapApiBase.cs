using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Edgegap.Editor.Api
{
	public abstract class EdgegapApiBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDeleteAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<HttpResponseMessage> _003C_003Et__builder;

			public EdgegapApiBase _003C_003E4__this;

			public string relativePath;

			public string customQuery;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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
		private struct _003CExecuteRequestAsync_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<HttpResponseMessage> _003C_003Et__builder;

			public Func<Task<HttpResponseMessage>> requestFunc;

			public CancellationToken cancellationToken;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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
		private struct _003CGetAsync_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<HttpResponseMessage> _003C_003Et__builder;

			public EdgegapApiBase _003C_003E4__this;

			public string relativePath;

			public string customQuery;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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
		private struct _003CPatchAsync_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<HttpResponseMessage> _003C_003Et__builder;

			public EdgegapApiBase _003C_003E4__this;

			public string json;

			public string relativePath;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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
		private struct _003CPostAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<HttpResponseMessage> _003C_003Et__builder;

			public EdgegapApiBase _003C_003E4__this;

			public string json;

			public string relativePath;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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

		private readonly HttpClient _httpClient;

		protected ApiEnvironment SelectedApiEnvironment { get; }

		protected EdgegapWindowMetadata.LogLevel LogLevel { get; set; }

		protected bool IsLogLevelDebug => false;

		private string GetBaseUrl()
		{
			return null;
		}

		protected EdgegapApiBase(ApiEnvironment apiEnvironment, string apiToken, EdgegapWindowMetadata.LogLevel logLevel = EdgegapWindowMetadata.LogLevel.Error)
		{
		}

		[AsyncStateMachine(typeof(_003CPostAsync_003Ed__12))]
		protected Task<HttpResponseMessage> PostAsync(string relativePath = "", string json = "{}")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPatchAsync_003Ed__13))]
		protected Task<HttpResponseMessage> PatchAsync(string relativePath = "", string json = "{}")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAsync_003Ed__14))]
		protected Task<HttpResponseMessage> GetAsync(string relativePath = "", string customQuery = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDeleteAsync_003Ed__15))]
		protected Task<HttpResponseMessage> DeleteAsync(string relativePath = "", string customQuery = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CExecuteRequestAsync_003Ed__16))]
		private static Task<HttpResponseMessage> ExecuteRequestAsync(Func<Task<HttpResponseMessage>> requestFunc, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		private StringContent CreateStringContent(string json = "{}")
		{
			return null;
		}

		private static HttpResponseMessage CreateUnknown500Err()
		{
			return null;
		}

		private string prepareEdgegapUriWithQuery(string relativePath, string customQuery)
		{
			return null;
		}
	}
}
