using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VampireSurvivors.UI
{
	public class LoggedInPanel : BaseAccountPagePanel
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBuild_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LoggedInPanel _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		public LoggedInPanel(AccountPage accountPage)
			: base(null)
		{
		}

		[AsyncStateMachine(typeof(_003CBuild_003Ed__1))]
		public override void Build()
		{
		}
	}
}
