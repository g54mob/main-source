using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

namespace VampireSurvivors.UI
{
	public class ManageAccountPanel : BaseAccountPagePanel
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAcceptMergeConflict_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ManageAccountPanel _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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
		private struct _003CBuild_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ManageAccountPanel _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDoForceLink_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AccountDetailsType platform;

			public ManageAccountPanel _003C_003E4__this;

			private TaskAwaiter<ILinkResult> _003C_003Eu__1;

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
		private struct _003CDoLink_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public AccountDetailsType platform;

			public ManageAccountPanel _003C_003E4__this;

			private TaskAwaiter<ILinkResult> _003C_003Eu__1;

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
		private struct _003CLinkPlatform_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ManageAccountPanel _003C_003E4__this;

			public AccountDetailsType platform;

			public string platformAsString;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadAccountDetail_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public ManageAccountPanel _003C_003E4__this;

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

		private AccountDetails _accountDetails;

		private readonly AccountLinkService _accountLinkService;

		private readonly AccountDeletionService _accountDeletionService;

		private readonly SecretObscurer _secretObscurer;

		public ManageAccountPanel(AccountPage accountPage)
			: base(null)
		{
		}

		[AsyncStateMachine(typeof(_003CBuild_003Ed__5))]
		public override void Build()
		{
		}

		private void BuildAccountDetailsForCurrentPlatform()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadAccountDetail_003Ed__7))]
		private Task<bool> LoadAccountDetail()
		{
			return null;
		}

		private void BuildAccountDetailsForEmail()
		{
		}

		private void BuildAccountDetailsForPlatform(AccountDetailsType platform)
		{
		}

		[AsyncStateMachine(typeof(_003CLinkPlatform_003Ed__10))]
		private Task LinkPlatform(AccountDetailsType platform, string platformAsString)
		{
			return null;
		}

		private void AddAccountAndEnvInfo()
		{
		}

		[AsyncStateMachine(typeof(_003CDoLink_003Ed__12))]
		private Task<bool> DoLink(AccountDetailsType platform)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDoForceLink_003Ed__13))]
		private Task DoForceLink(AccountDetailsType platform)
		{
			return null;
		}

		private void ShowAlreadyLinkedPopup(AccountDetailsType platform)
		{
		}

		private Task<int> ShowSaveDataConflictChoicePopup(ForceLinkConflictResponse conflictResponse)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CAcceptMergeConflict_003Ed__16))]
		private Task AcceptMergeConflict()
		{
			return null;
		}

		private void HandleUnlink(AccountDetailsType platform)
		{
		}
	}
}
