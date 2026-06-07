using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public class CloudDataService
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetSlotSummary_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public int slot;

			public CloudDataService _003C_003E4__this;

			private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

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

		private string NO_DATA_LABEL;

		[AsyncStateMachine(typeof(_003CGetSlotSummary_003Ed__1))]
		public Task<string> GetSlotSummary(int slot)
		{
			return null;
		}

		public string PlayerOptionsDataToSummaryString(PlayerOptionsData playerOptionsData)
		{
			return null;
		}

		public bool IsEmpty(string slotSummary)
		{
			return false;
		}
	}
}
