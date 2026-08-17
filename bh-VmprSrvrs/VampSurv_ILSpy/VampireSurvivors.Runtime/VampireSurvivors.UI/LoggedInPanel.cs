using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.UI;

namespace VampireSurvivors.UI;

public class LoggedInPanel : BaseAccountPagePanel
{
	[StructLayout((LayoutKind)3)]
	private struct _003C_003CBuild_003Eb__1_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LoggedInPanel _003C_003E4__this;

		private unsafe void MoveNext()
		{
			//IL_0051: Expected I4, but got I8
			//IL_005c: Expected O, but got Ref
			LoggedInPanel loggedInPanel = _003C_003E4__this;
			AccountPage accountPage = ((BaseAccountPagePanel)loggedInPanel)._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_DATA);
			accountPage.ClearAndBuild();
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CBuild_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LoggedInPanel _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0051: Expected O, but got I
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_008e: Expected I, but got O
			//IL_04e5: Expected I4, but got I8
			//IL_04f0: Expected O, but got Ref
			//IL_031d: Expected O, but got I4
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Expected O, but got Unknown
			//IL_03d7: Expected O, but got Ref
			//IL_0139: Expected O, but got I
			//IL_01a1: Expected O, but got I
			//IL_0209: Expected O, but got I
			//IL_022c: Expected O, but got I
			//IL_023c: Expected O, but got I
			object CS_0024_003C_003E8__locals3 = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string accountTranslation = AccountPage.GetAccountTranslation("logged_in_title");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
				AccountInformation accountInformation = default(AccountInformation);
				IPlayerProfile playerProfile = accountInformation.GetPlayerProfile();
				nint num = (nint)playerProfile;
				if (playerProfile.HasContactEmailAddress())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
					AccountInformation accountInformation2 = default(AccountInformation);
					string accountEmailAddress = accountInformation2.GetAccountEmailAddress();
					string accountTranslation2 = AccountPage.GetAccountTranslation("logged_in_manage_data_label");
					string accountTranslation3 = AccountPage.GetAccountTranslation("logged_in_manage_data_button");
					Action callback = delegate
					{
						SynchronizationContext.CurrentNoFlow?.OperationStarted();
						AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = default(AsyncVoidMethodBuilder);
						_003C_003CBuild_003Eb__1_0_003Ed stateMachine2 = default(_003C_003CBuild_003Eb__1_0_003Ed);
						asyncVoidMethodBuilder4.Start(ref stateMachine2);
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
					bool textIsLocalizationTerm = default(bool);
					bool isEnabledByDefault = default(bool);
					LabeledButtonUI labeledButtonUI = ((ProgrammaticUI)0).AddLabeledButton(accountTranslation2, accountTranslation3, callback, textIsLocalizationTerm, isEnabledByDefault);
					string accountTranslation4 = AccountPage.GetAccountTranslation("logged_in_manage_account_label");
					string accountTranslation5 = AccountPage.GetAccountTranslation("logged_in_manage_account_button");
					Action callback2 = delegate
					{
						AccountPage accountPage = ((BaseAccountPagePanel)CS_0024_003C_003E8__locals3)._accountPage;
						accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
						accountPage.ClearAndBuild();
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
					LabeledButtonUI labeledButtonUI2 = ((ProgrammaticUI)0).AddLabeledButton(accountTranslation4, accountTranslation5, callback2, textIsLocalizationTerm, isEnabledByDefault);
					string accountTranslation6 = AccountPage.GetAccountTranslation("logged_in_help_label");
					string accountTranslation7 = AccountPage.GetAccountTranslation("logged_in_help_button");
					Action callback3 = delegate
					{
						AccountPage accountPage = ((BaseAccountPagePanel)CS_0024_003C_003E8__locals3)._accountPage;
						accountPage.accountPageState.ChangeStateTo(UIState.HELP);
						accountPage.ClearAndBuild();
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
					LabeledButtonUI labeledButtonUI3 = ((ProgrammaticUI)0).AddLabeledButton(accountTranslation6, accountTranslation7, callback3, textIsLocalizationTerm, isEnabledByDefault);
					((BaseAccountPagePanel)CS_0024_003C_003E8__locals3).AddLogoutButton();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
					((ProgrammaticUI)0).GenerateNavigation();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
					object obj2 = 0;
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1275 @ rdx_v53+238] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						PopupManager.ClosePopup("account-loading");
						goto IL_04d6;
					}
					throw new NullReferenceException();
				}
				Task<bool> task2 = BackendFacade.UnlinkAccount();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num2 == 0;
				bool flag2 = num2 < 0;
				bool flag3 = !flag2;
				object obj4 = !flag3;
				object obj5 = obj4 | flag;
				task = (Task)taskAwaiter;
				if (obj5 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
			BaseAccountPagePanel._003CLogout_003Ed__24 stateMachine = default(BaseAccountPagePanel._003CLogout_003Ed__24);
			asyncVoidMethodBuilder2.Start(ref stateMachine);
			goto IL_04d6;
			IL_04d6:
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder3.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public LoggedInPanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CBuild_003Ed__1 stateMachine = default(_003CBuild_003Ed__1);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void _003CBuild_003Eb__1_0()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003C_003CBuild_003Eb__1_0_003Ed stateMachine = default(_003C_003CBuild_003Eb__1_0_003Ed);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void _003CBuild_003Eb__1_1()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
		accountPage.ClearAndBuild();
	}

	private void _003CBuild_003Eb__1_2()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.HELP);
		accountPage.ClearAndBuild();
	}
}
