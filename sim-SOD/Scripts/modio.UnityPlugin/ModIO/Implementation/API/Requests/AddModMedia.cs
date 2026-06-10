using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ModIO.Implementation.API.Requests
{
	internal static class AddModMedia
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRequest_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<WebRequestConfig>> _003C_003Et__builder;

			public ModProfileDetails details;

			private WebRequestConfig _003Crequest_003E5__2;

			private TaskAwaiter<ResultAnd<MemoryStream>> _003C_003Eu__1;

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

		[AsyncStateMachine(typeof(_003CRequest_003Ed__0))]
		public static Task<ResultAnd<WebRequestConfig>> Request(ModProfileDetails details)
		{
			return null;
		}
	}
}
