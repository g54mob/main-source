using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using PlayFab.Json;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab
{
	public class PlayFabCloudScript
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CExecute_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<JsonObject> _003C_003Et__builder;

			public string fnName;

			public Dictionary<string, string> parameters;

			private int _003Cattempt_003E5__2;

			private TaskAwaiter<JsonObject> _003C_003Eu__1;

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

		[AsyncStateMachine(typeof(_003CExecute_003Ed__0))]
		public Task<JsonObject> Execute(string fnName, Dictionary<string, string> parameters = null)
		{
			return null;
		}

		private static Task<JsonObject> ExecuteCloudScript(string fnName, Dictionary<string, string> parameters)
		{
			return null;
		}
	}
}
