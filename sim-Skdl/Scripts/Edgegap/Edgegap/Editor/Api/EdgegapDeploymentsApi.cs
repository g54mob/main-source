using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Edgegap.Editor.Api.Models.Requests;
using Edgegap.Editor.Api.Models.Results;

namespace Edgegap.Editor.Api
{
	public class EdgegapDeploymentsApi : EdgegapApiBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAwaitReadyStatusAsync_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<GetDeploymentStatusResult>> _003C_003Et__builder;

			public TimeSpan pollInterval;

			public EdgegapDeploymentsApi _003C_003E4__this;

			public string requestId;

			private CancellationTokenSource _003Ccts_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<EdgegapHttpResult<GetDeploymentStatusResult>> _003C_003Eu__2;

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
		private struct _003CAwaitTerminatedDeleteStatusAsync_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<StopActiveDeploymentResult>> _003C_003Et__builder;

			public TimeSpan pollInterval;

			public EdgegapDeploymentsApi _003C_003E4__this;

			public string requestId;

			private CancellationTokenSource _003Ccts_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<EdgegapHttpResult<StopActiveDeploymentResult>> _003C_003Eu__2;

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
		private struct _003CCreateDeploymentAsync_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<CreateDeploymentResult>> _003C_003Et__builder;

			public EdgegapDeploymentsApi _003C_003E4__this;

			public CreateDeploymentRequest request;

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
		private struct _003CCreateDeploymentAwaitReadyStatusAsync_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<CreateDeploymentResult>> _003C_003Et__builder;

			public EdgegapDeploymentsApi _003C_003E4__this;

			public CreateDeploymentRequest request;

			public TimeSpan pollInterval;

			private EdgegapHttpResult<CreateDeploymentResult> _003CcreateResponse_003E5__2;

			private TaskAwaiter<EdgegapHttpResult<CreateDeploymentResult>> _003C_003Eu__1;

			private TaskAwaiter<EdgegapHttpResult<GetDeploymentStatusResult>> _003C_003Eu__2;

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
		private struct _003CGetDeploymentStatusAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<GetDeploymentStatusResult>> _003C_003Et__builder;

			public EdgegapDeploymentsApi _003C_003E4__this;

			public string requestId;

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
		private struct _003CStopActiveDeploymentAsync_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<StopActiveDeploymentResult>> _003C_003Et__builder;

			public EdgegapDeploymentsApi _003C_003E4__this;

			public string requestId;

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

		public EdgegapDeploymentsApi(ApiEnvironment apiEnvironment, string apiToken, EdgegapWindowMetadata.LogLevel logLevel = EdgegapWindowMetadata.LogLevel.Error)
			: base(default(ApiEnvironment), null, default(EdgegapWindowMetadata.LogLevel))
		{
		}

		[AsyncStateMachine(typeof(_003CCreateDeploymentAsync_003Ed__1))]
		public Task<EdgegapHttpResult<CreateDeploymentResult>> CreateDeploymentAsync(CreateDeploymentRequest request)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetDeploymentStatusAsync_003Ed__2))]
		public Task<EdgegapHttpResult<GetDeploymentStatusResult>> GetDeploymentStatusAsync(string requestId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CStopActiveDeploymentAsync_003Ed__3))]
		public Task<EdgegapHttpResult<StopActiveDeploymentResult>> StopActiveDeploymentAsync(string requestId)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCreateDeploymentAwaitReadyStatusAsync_003Ed__4))]
		public Task<EdgegapHttpResult<CreateDeploymentResult>> CreateDeploymentAwaitReadyStatusAsync(CreateDeploymentRequest request, TimeSpan pollInterval)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitReadyStatusAsync_003Ed__5))]
		public Task<EdgegapHttpResult<GetDeploymentStatusResult>> AwaitReadyStatusAsync(string requestId, TimeSpan pollInterval)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAwaitTerminatedDeleteStatusAsync_003Ed__6))]
		public Task<EdgegapHttpResult<StopActiveDeploymentResult>> AwaitTerminatedDeleteStatusAsync(string requestId, TimeSpan pollInterval)
		{
			return null;
		}
	}
}
