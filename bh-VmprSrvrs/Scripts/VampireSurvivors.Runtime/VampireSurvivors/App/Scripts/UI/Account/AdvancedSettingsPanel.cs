using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI.Account
{
	public class AdvancedSettingsPanel : BaseAccountPagePanel
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBuild_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AdvancedSettingsPanel _003C_003E4__this;

			private DeletionStatusResponse _003CdeletionStatus_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter<DeletionStatusResponse> _003C_003Eu__2;

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
		private struct _003CLoadAccountDetail_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AdvancedSettingsPanel _003C_003E4__this;

			private TaskAwaiter<AccountDetails> _003C_003Eu__1;

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

		private readonly AccountDeletionService _accountDeletionService;

		private AccountDetails _accountDetails;

		public AdvancedSettingsPanel(AccountPage accountPage)
			: base(null)
		{
		}

		[AsyncStateMachine(typeof(_003CBuild_003Ed__3))]
		public override void Build()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAccountDetail_003Ed__4))]
		private Task<bool> LoadAccountDetail()
		{
			return null;
		}
	}
}
