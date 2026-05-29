using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Edgegap.Editor.Api.Models.Results;

namespace Edgegap.Editor.Api
{
	public class EdgegapIpApi : EdgegapApiBase
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetYourPublicIp_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<EdgegapHttpResult<GetYourPublicIpResult>> _003C_003Et__builder;

			public EdgegapIpApi _003C_003E4__this;

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

		public EdgegapIpApi(ApiEnvironment apiEnvironment, string apiToken, EdgegapWindowMetadata.LogLevel logLevel = EdgegapWindowMetadata.LogLevel.Error)
			: base(default(ApiEnvironment), null, default(EdgegapWindowMetadata.LogLevel))
		{
		}

		[AsyncStateMachine(typeof(_003CGetYourPublicIp_003Ed__1))]
		public Task<EdgegapHttpResult<GetYourPublicIpResult>> GetYourPublicIp()
		{
			return null;
		}
	}
}
