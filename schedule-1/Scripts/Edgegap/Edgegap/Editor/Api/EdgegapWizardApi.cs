using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Edgegap.Editor.Api.Models.Results;

namespace Edgegap.Editor.Api
{
	public class EdgegapWizardApi : EdgegapApiBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetRegistryCredentials_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<GetRegistryCredentialsResult>> _003C_003Et__builder;

			public EdgegapWizardApi _003C_003E4__this;

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
		private struct _003CInitQuickStart_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult> _003C_003Et__builder;

			public EdgegapWizardApi _003C_003E4__this;

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

		public EdgegapWizardApi(ApiEnvironment apiEnvironment, string apiToken, EdgegapWindowMetadata.LogLevel logLevel = EdgegapWindowMetadata.LogLevel.Error)
			: base(default(ApiEnvironment), null, default(EdgegapWindowMetadata.LogLevel))
		{
		}

		[AsyncStateMachine(typeof(_003CInitQuickStart_003Ed__1))]
		public Task<EdgegapHttpResult> InitQuickStart()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetRegistryCredentials_003Ed__2))]
		public Task<EdgegapHttpResult<GetRegistryCredentialsResult>> GetRegistryCredentials()
		{
			return null;
		}
	}
}
