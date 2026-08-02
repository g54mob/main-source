using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GRP
{
	public class Workshop : Domain<WorkshopConfig>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnLoaded_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Workshop _003C_003E4__this;

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

		public ProjectContainer projectContainer;

		public override void OnContext()
		{
		}

		[AsyncStateMachine(typeof(_003COnLoaded_003Ed__2))]
		protected override void OnLoaded()
		{
		}

		public void OpenMainMenu()
		{
		}
	}
}
