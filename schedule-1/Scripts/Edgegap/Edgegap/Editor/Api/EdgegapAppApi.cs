using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Edgegap.Editor.Api.Models.Requests;
using Edgegap.Editor.Api.Models.Results;

namespace Edgegap.Editor.Api
{
	public class EdgegapAppApi : EdgegapApiBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateApp_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<GetCreateAppResult>> _003C_003Et__builder;

			public EdgegapAppApi _003C_003E4__this;

			public CreateAppRequest request;

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
		private struct _003CCreateAppVersion_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<UpsertAppVersionResult>> _003C_003Et__builder;

			public CreateAppVersionRequest request;

			public EdgegapAppApi _003C_003E4__this;

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
		private struct _003CGetApp_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<GetCreateAppResult>> _003C_003Et__builder;

			public EdgegapAppApi _003C_003E4__this;

			public string appName;

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
		private struct _003CUpdateAppVersion_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<UpsertAppVersionResult>> _003C_003Et__builder;

			public UpdateAppVersionRequest request;

			public EdgegapAppApi _003C_003E4__this;

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
		private struct _003CUpsertAppVersion_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<UpsertAppVersionResult>> _003C_003Et__builder;

			public EdgegapAppApi _003C_003E4__this;

			public UpdateAppVersionRequest request;

			private TaskAwaiter<EdgegapHttpResult<UpsertAppVersionResult>> _003C_003Eu__1;

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

		public EdgegapAppApi(ApiEnvironment apiEnvironment, string apiToken, EdgegapWindowMetadata.LogLevel logLevel = EdgegapWindowMetadata.LogLevel.Error)
			: base(default(ApiEnvironment), null, default(EdgegapWindowMetadata.LogLevel))
		{
		}

		[AsyncStateMachine(typeof(_003CCreateApp_003Ed__1))]
		public Task<EdgegapHttpResult<GetCreateAppResult>> CreateApp(CreateAppRequest request)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetApp_003Ed__2))]
		public Task<EdgegapHttpResult<GetCreateAppResult>> GetApp(string appName)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUpdateAppVersion_003Ed__3))]
		public Task<EdgegapHttpResult<UpsertAppVersionResult>> UpdateAppVersion(UpdateAppVersionRequest request)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CCreateAppVersion_003Ed__4))]
		public Task<EdgegapHttpResult<UpsertAppVersionResult>> CreateAppVersion(CreateAppVersionRequest request)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CUpsertAppVersion_003Ed__5))]
		public Task<EdgegapHttpResult<UpsertAppVersionResult>> UpsertAppVersion(UpdateAppVersionRequest request)
		{
			return null;
		}
	}
}
