using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class AccountPage : ProgrammaticUI
{
	[StructLayout((LayoutKind)3)]
	private struct _003C_003CAddLogoutButton_003Eb__22_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AccountPage _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0175: Expected I4, but got I8
			//IL_0180: Expected O, but got Ref
			//IL_0097: Expected O, but got I4
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_012c: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task task2 = _003C_003E4__this.DoLogout();
				int num = task2.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task2;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter)task2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
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

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public RememberMeService rememberMeService;

		internal void _003COnShowStart_003Eb__0()
		{
			RememberMeService rememberMeService = this.rememberMeService;
			string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(rememberMeService.key);
			PlayerPrefs.DeleteKey(userSpecificKey);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public Action action;

		internal void _003CEnableSpecialButton_003Eb__0()
		{
			Action action = this.action;
			if (this.action != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CDoLogout_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AccountPage _003C_003E4__this;

		private RememberMeService _003CrememberMeService_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_04d6: Expected O, but got Ref
			//IL_0169: Expected O, but got I4
			//IL_0178: Expected I4, but got I8
			//IL_0060: Expected O, but got I4
			//IL_0065: Expected I, but got O
			//IL_0130: Expected I, but got O
			//IL_0086: Expected O, but got Ref
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected I, but got Unknown
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_05d4: Expected O, but got I4
			//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e9: Expected O, but got Unknown
			//IL_01f9: Expected O, but got I4
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Expected O, but got Unknown
			//IL_0622: Expected I, but got O
			//IL_032d: Expected O, but got I
			//IL_02ec: Expected O, but got Ref
			//IL_05ba: Expected I4, but got I8
			//IL_04ab: Expected O, but got Ref
			//IL_0579->IL053b: Incompatible stack heights: 1 vs 0
			//IL_04b9->IL04b9: Incompatible stack heights: 8 vs 0
			bool flag = _003C_003E1__state == 0;
			RememberMeService rememberMeService = (RememberMeService)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			if (!flag)
			{
				string accountTranslation = GetAccountTranslation("common_logging_out");
				_003C_003E4__this.ShowLoading(accountTranslation);
				RememberMeService rememberMeService2 = (_003CrememberMeService_003E5__2 = new RememberMeService());
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				object obj = 0;
				nint num = unchecked((nint)null);
				rememberMeService = rememberMeService2;
				if (!flag2)
				{
					object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 40));
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj5 * 8;
					num = (nint)(6603577472L + obj6);
					obj = obj4 & 0x3F;
					nint num3;
					do
					{
						object obj7 = 1 << (int)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v24 (Il2CppMethodInfo)+462E0]");
						rememberMeService = (RememberMeService)(0 | obj7);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v24 (Il2CppMethodInfo)+462E0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v24 (Il2CppMethodInfo)+462E0]");
						if (num2 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v24 (Il2CppMethodInfo)+462E0]");
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v24 (Il2CppMethodInfo)+462E0]");
					}
					while (num3 != 0);
				}
			}
			object obj8 = default(object);
			if (obj8 != null)
			{
				if (_003CrememberMeService_003E5__2 == null)
				{
					throw new NullReferenceException();
				}
				bool flag3 = _003CrememberMeService_003E5__2.ShouldAutoLogin();
				bool flag4 = !flag3;
				nint num = unchecked((nint)null);
				if (flag4)
				{
					goto IL_0349;
				}
			}
			Task task;
			if (obj8 == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<bool> task2 = BackendFacade.UnlinkDeviceId();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				int num4 = task3.m_stateFlags & 0x1600000;
				bool flag5 = num4 == 0;
				bool flag6 = num4 < 0;
				bool flag7 = !flag6;
				object obj9 = !flag7;
				object obj10 = obj9 | flag5;
				task = task3;
				rememberMeService = (RememberMeService)(object)typeof(Task);
				if (obj10 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<bool>)task3;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rbx_v16 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>);
					asyncTaskMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					rememberMeService = null;
					return;
				}
			}
			if (task != null)
			{
				int num6 = task.m_stateFlags & 0x11000000;
				if (num6 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				nint num7 = (nint)_003CrememberMeService_003E5__2;
				bool flag8 = _003CrememberMeService_003E5__2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rcx_v49 (Il2CppStaticFields<VampireSurvivors.UI.AccountInformation>)+10]");
				string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey((string)0);
				PlayerPrefs.DeleteKey(userSpecificKey);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [189999028] (should have been resolved before IL gen)");
				goto IL_0349;
			}
			throw new NullReferenceException();
			IL_0349:
			AccountInformation accountInformation = AccountInformation._accountInformation;
			bool flag9 = AccountInformation._accountInformation == null;
			accountInformation._003CAccountEmailAddress_003Ek__BackingField = null;
			accountInformation._003CPlayerProfile_003Ek__BackingField = null;
			BackendFacade.Logout();
			SaveBackupService.ClearBackup();
			AccountPage accountPage = default(AccountPage);
			bool flag10 = (object)accountPage == null;
			AccountPageState accountPageState = accountPage.accountPageState;
			bool flag11 = accountPage.accountPageState == null;
			bool flag12 = accountPageState.stateHistory == null;
			accountPageState.stateHistory.Clear();
			bool flag13 = (object)accountPage == null;
			bool flag14 = accountPage.accountPageState == null;
			accountPage.accountPageState.ChangeStateTo(UIState.NOT_LOGGED_IN_HOME);
			accountPage.ClearAndBuild();
			bool flag15 = (object)accountPage == null;
			accountPage.SetLoggedOutStatus();
			bool flag16 = (object)accountPage == null;
			accountPage.GoHome();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187612BE0");
			_003C_003E1__state = -2;
			_003CrememberMeService_003E5__2 = null;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003COnShowStart_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AccountPage _003C_003E4__this;

		public GameObject g;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private TaskAwaiter<string> _003C_003Eu__1;

		private TaskAwaiter<ILoginResult> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0479: Expected O, but got I4
			//IL_0488: Expected I4, but got I8
			//IL_00be: Expected I, but got O
			//IL_0263: Expected O, but got I
			//IL_053f: Expected O, but got I4
			//IL_0547: Unknown result type (might be due to invalid IL or missing references)
			//IL_054c: Expected O, but got Unknown
			//IL_060e: Expected O, but got Ref
			//IL_029f: Expected O, but got I
			//IL_06c3: Expected I4, but got I8
			//IL_06da: Expected O, but got Ref
			//IL_0193: Expected O, but got I4
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_0416: Expected O, but got Ref
			AccountPage accountPage = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					goto IL_0825;
				}
				_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
				_003C_003E8__1 = obj;
				if ((object)_003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				((BaseUIPage)_003C_003E4__this).OnShowStart(g);
				if ((object)_003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				nint num = (nint)accountPage;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v791 @ rdx_v51 (Il2CppClass<VampireSurvivors.UI.BaseUIPage>)+228] (should have been resolved before IL gen)");
				if (!BackendFacade.IsLoggedIn())
				{
					goto IL_0233;
				}
				Task<string> accountEmailAddress = BackendFacade.GetAccountEmailAddress();
				if (accountEmailAddress == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<string> taskAwaiter = default(TaskAwaiter<string>);
				if ((object)taskAwaiter == null)
				{
					throw new NullReferenceException();
				}
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num2 == 0;
				bool flag2 = num2 < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = (Task)taskAwaiter;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v35 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 == 0)
			{
				BackendFacade.Logout();
			}
			goto IL_0233;
			IL_06ab:
			AccountPage accountPage2;
			accountPage2.GoHome();
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
			return;
			IL_069e:
			AccountPage accountPage3;
			accountPage2 = accountPage3;
			goto IL_06ab;
			IL_0825:
			object obj4 = default(object);
			Task task2;
			if ((nint)obj4 == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				task2 = (Task)_003C_003Eu__2;
			}
			else
			{
				Task<ILoginResult> task3 = BackendFacade.LoginWithDeviceId();
				bool flag4 = task3 == null;
				Task<ILoginResult> task4 = null;
				if (flag4)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<ILoginResult> taskAwaiter2 = default(TaskAwaiter<ILoginResult>);
				if ((object)taskAwaiter2 == null)
				{
					throw new NullReferenceException();
				}
				int num4 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
				bool flag5 = num4 == 0;
				bool flag6 = num4 < 0;
				bool flag7 = !flag6;
				object obj5 = !flag7;
				object obj6 = obj5 | flag5;
				task2 = (Task)taskAwaiter2;
				if (obj6 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = taskAwaiter2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILoginResult> awaiter2 = default(TaskAwaiter<ILoginResult>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = default(AsyncVoidMethodBuilder);
					asyncVoidMethodBuilder4.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					AccountPage accountPage4 = null;
					return;
				}
			}
			if (task2 != null)
			{
				int num5 = task2.m_stateFlags & 0x11000000;
				if (num5 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
				}
				AccountPage accountPage5 = default(AccountPage);
				if ((object)accountPage5 != null)
				{
					accountPage5.SetLoggedInStatus();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187612BE0");
					Task<ILoginResult> task4 = null;
					AccountPageState accountPageState = accountPage5.accountPageState;
					bool flag8 = accountPageState.loginState != LoginType.LOGGED_IN;
					accountPage2 = accountPage5;
					if (!flag8)
					{
						Debug.Log("already logged in so skipping remember me login");
						accountPage3 = accountPage5;
						goto IL_069e;
					}
					goto IL_06ab;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_0233:
			if ((object)_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (VampireSurvivors.UI.AccountPage)+190]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (VampireSurvivors.UI.AccountPage)+190]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rbx_v32+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rbx_v32+18]");
					((LinkedList<UIState>)0).Clear();
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.SetLoggedOutStatus();
						_003C_003Ec__DisplayClass14_0 obj8 = _003C_003E8__1;
						RememberMeService rememberMeService = new RememberMeService();
						if (_003C_003E8__1 != null)
						{
							obj8.rememberMeService = rememberMeService;
							if (!BackendFacade.IsLoggedIn())
							{
								_003C_003Ec__DisplayClass14_0 obj9 = _003C_003E8__1;
								if (_003C_003E8__1 == null)
								{
									throw new NullReferenceException();
								}
								if (obj9.rememberMeService == null)
								{
									throw new NullReferenceException();
								}
								bool flag9 = obj9.rememberMeService.ShouldAutoLogin();
								bool flag10 = !flag9;
								accountPage3 = _003C_003E4__this;
								if (!flag10)
								{
									string accountTranslation = GetAccountTranslation("login_logging_in_generic");
									if ((object)_003C_003E4__this != null)
									{
										_003C_003E4__this.ShowLoading(accountTranslation);
										goto IL_0825;
									}
									throw new NullReferenceException();
								}
							}
							else
							{
								if ((object)_003C_003E4__this == null)
								{
									throw new NullReferenceException();
								}
								_003C_003E4__this.SetLoggedInStatus();
								accountPage3 = _003C_003E4__this;
							}
							goto IL_069e;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
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

	private TextMeshProUGUI _AccountStatus;

	private Button _SpecialButton;

	private Image _SpecialButtonIcon;

	private Sprite _showHideSprite;

	private Sprite _infoSprite;

	private PlayerOptions _playerOptions;

	private AccountPageState accountPageState;

	private AchievementManager _achievementManager;

	private bool _backBeingBlockedByInput;

	private const bool ACCOUNT_VERIFICATION_REQUIRED = true;

	private void Construct(PlayerOptions player, AchievementManager achievementManager)
	{
		_playerOptions = player;
		_achievementManager = achievementManager;
		DisableSpecialButton();
	}

	protected override void Awake()
	{
		base.Awake();
		_AutoSizeAfterParse = true;
		if ((object)_Slider != null)
		{
			Transform transform = _Slider.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 61 ConditionalJump @-1, v113 @ ZF_v7 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}

	private void ClearAndBuild()
	{
		Clear();
		Action b = BackButtonPress;
		BackButtonController.TryRemoveListener(b);
		AccountPageState accountPageState = this.accountPageState;
		UIState state = Enumerable.First(accountPageState.stateHistory);
		BaseAccountPagePanel panelForState = GetPanelForState(state);
		panelForState.Build();
	}

	private void Build()
	{
		AccountPageState accountPageState = this.accountPageState;
		UIState state = Enumerable.First(accountPageState.stateHistory);
		BaseAccountPagePanel panelForState = GetPanelForState(state);
		panelForState.Build();
	}

	protected override void OnShowStart(GameObject g)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003COnShowStart_003Ed__14 stateMachine = default(_003COnShowStart_003Ed__14);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	protected override void OnHideStart(GameObject g)
	{
		ResetBackButtonNavigation();
	}

	public unsafe void LateUpdate()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		_backBeingBlockedByInput = false;
		List<ISelectableUI>.Enumerator enumerator = default(List<ISelectableUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<ISelectableUI>.Enumerator enumerator2 = (List<ISelectableUI>.Enumerator)0;
			List<ISelectableUI>.Enumerator enumerator3 = (List<ISelectableUI>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public void AddBackButtonListener()
	{
		Action b = BackButtonPress;
		BackButtonController.AddListener(b);
	}

	public bool GetFlag(string key)
	{
		//IL_0057: Expected O, but got I
		//IL_00df: Expected I4, but got O
		//IL_0091: Expected O, but got I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		AccountPageState accountPageState = this.accountPageState;
		Dictionary<string, bool> flags = accountPageState.flags;
		int num = accountPageState.flags.FindEntry(key);
		if (num >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v4 (System.Collections.Generic.Dictionary`2<System.String, System.Boolean>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v6+18]");
			if ((nint)num < (nint)0)
			{
				object obj2 = num + 2;
				object obj3 = obj2 * 2;
				object obj4 = obj2 + obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v6+v157 @ rax_v11*8]");
				return false;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public void SetFlag(string key, bool value)
	{
		AccountPageState accountPageState = this.accountPageState;
		bool flag = ((Dictionary<object, bool>)(object)accountPageState.flags).TryInsert((object)key, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	private void BackButtonPress()
	{
		if (!_backBeingBlockedByInput)
		{
			AccountPageState accountPageState = this.accountPageState;
			LinkedList<UIState> stateHistory = accountPageState.stateHistory;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v6 (System.Collections.Generic.LinkedList`1<VampireSurvivors.UI.UIState>)+18]");
			if ((nint)0 <= (nint)1)
			{
				Action b = BackButtonPress;
				BackButtonController.TryRemoveListener(b);
				BackButtonController.GoBack();
			}
			else
			{
				this.accountPageState.GoBack();
				ClearAndBuild();
			}
		}
	}

	private void ClearHistory()
	{
		AccountPageState accountPageState = this.accountPageState;
		accountPageState.stateHistory.Clear();
	}

	public void AddLogoutButton()
	{
		string accountTranslation = GetAccountTranslation("common_logout_button");
		Action callback = delegate
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CAddLogoutButton_003Eb__22_0_003Ed stateMachine = default(_003C_003CAddLogoutButton_003Eb__22_0_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		};
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = AddLabeledButton("", accountTranslation, callback, textIsLocalizationTerm, isEnabledByDefault);
	}

	public unsafe Task DoLogout()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CDoLogout_003Ed__23 stateMachine = default(_003CDoLogout_003Ed__23);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	public void ChangeStateTo(UIState uiState)
	{
		accountPageState.ChangeStateTo(uiState);
		ClearAndBuild();
	}

	public void GoHome()
	{
		//IL_0066: Expected O, but got I4
		AccountPageState accountPageState = this.accountPageState;
		accountPageState.stateHistory.Clear();
		AccountPageState accountPageState2 = this.accountPageState;
		bool flag = accountPageState2.loginState == LoginType.LOGGED_OUT;
		if (flag)
		{
			goto IL_00b0;
		}
		object obj = accountPageState2.loginState - 1;
		UIState uiState;
		if (!flag)
		{
			if ((nint)obj != 1)
			{
				goto IL_00b0;
			}
			uiState = UIState.UNVERIFIED_HOME;
		}
		else
		{
			uiState = UIState.LOGGED_IN_HOME;
		}
		goto IL_00be;
		IL_00b0:
		uiState = UIState.NOT_LOGGED_IN_HOME;
		goto IL_00be;
		IL_00be:
		accountPageState2.ChangeStateTo(uiState);
		ClearAndBuild();
	}

	public void SetTitle(string title)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public void HideLoggedInStatus()
	{
		_AccountStatus.enabled = false;
	}

	public static bool IsAccountVerificationRequired()
	{
		return true;
	}

	public void SetLoggedInStatus()
	{
		IPlayerProfile playerProfile = AccountInformation._accountInformation.GetPlayerProfile();
		bool flag = playerProfile.IsContactEmailAddressVerified();
		bool flag2 = !flag;
		AccountPage accountPage = this;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 114 Invalid \"Jump target not found in method: 0x1876106C0\"");
			AccountPage accountPage2 = default(AccountPage);
			accountPage = accountPage2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D7C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AccountPageState accountPageState = accountPage.accountPageState;
		accountPageState.loginState = LoginType.UNVERIFIED;
		string accountTranslation = GetAccountTranslation("verification_not_verified_message");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		accountPage._AccountStatus.enabled = true;
	}

	public void SetGenericUnverifiedStatus()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D7C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AccountPageState accountPageState = this.accountPageState;
		accountPageState.loginState = LoginType.UNVERIFIED;
		string accountTranslation = GetAccountTranslation("verification_not_verified_message");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		_AccountStatus.enabled = true;
	}

	public void SetGenericLoggedInStatus()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D7D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AccountPageState accountPageState = this.accountPageState;
		accountPageState.loginState = LoginType.LOGGED_IN;
		string accountTranslation = GetAccountTranslation("common_logged_in");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		_AccountStatus.enabled = true;
	}

	private void SetLoggedOutStatus()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D7E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AccountPageState accountPageState = this.accountPageState;
		accountPageState.loginState = LoginType.LOGGED_OUT;
		string accountTranslation = GetAccountTranslation("common_logged_out");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		_AccountStatus.enabled = true;
	}

	private BaseAccountPagePanel GetPanelForState(UIState state)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 86 Invalid \"Jump target not found in method: 0x187610FE0\"");
		BaseAccountPagePanel result = default(BaseAccountPagePanel);
		return result;
	}

	public static string GetTranslation(string key)
	{
		string term = "lang/" + key;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public static string GetAccountTranslation(string key)
	{
		string term = "lang/account_" + key;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public unsafe static string GetAccountTranslation(string key, string[] args)
	{
		//IL_0089: Expected O, but got Ref
		string term = "lang/account_" + key;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text = translation;
		int num = 0;
		int num2 = 0;
		object obj = default(object);
		while (true)
		{
			if (num < args.Length)
			{
				string text2 = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj), null);
				string oldValue = "%" + text2;
				if (num2 >= args.Length)
				{
					break;
				}
				string text3 = text.Replace(oldValue, args[num2]);
				num2++;
				text = text3;
				num = num2;
				continue;
			}
			return text;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public void ShowSpecialButtonForShowHide(Action action)
	{
		EnableSpecialButton(action, _showHideSprite);
	}

	public void ShowSpecialButtonForInformation(Action action)
	{
		EnableSpecialButton(action, _infoSprite);
	}

	public void DisableSpecialButton()
	{
		GameObject gameObject = _SpecialButton.gameObject;
		gameObject.SetActive(value: false);
		ButtonUI component = _SpecialButton.GetComponent<ButtonUI>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2380");
			object obj = default(object);
			if (obj != null)
			{
				bool flag = ((List<object>)(object)_spawnedSelectables).Remove((object)component);
			}
		}
	}

	private void EnableSpecialButton(Action action, Sprite sprite)
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals3.action = action;
		GameObject gameObject = _SpecialButton.gameObject;
		gameObject.SetActive(value: true);
		_SpecialButtonIcon.sprite = sprite;
		Button specialButton = _SpecialButton;
		specialButton.m_OnClick.RemoveAllListeners();
		Button specialButton2 = _SpecialButton;
		UnityAction call = delegate
		{
			Action action2 = CS_0024_003C_003E8__locals3.action;
			if (CS_0024_003C_003E8__locals3.action != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		specialButton2.m_OnClick.AddListener(call);
		ButtonUI component = _SpecialButton.GetComponent<ButtonUI>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
		}
		GenerateNavigation();
		SelectFirstSelectable();
	}

	public void ReAddSpecialButtonNavigation()
	{
		ButtonUI component = _SpecialButton.GetComponent<ButtonUI>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
		}
		GenerateNavigation();
		SelectFirstSelectable();
	}

	public override void Clear()
	{
		Button specialButton = _SpecialButton;
		if ((object)_SpecialButton != null && ((UnityEngine.Object)specialButton).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _SpecialButton.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				ButtonUI component = _SpecialButton.GetComponent<ButtonUI>();
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2380");
					object obj = default(object);
					if (obj != null)
					{
						bool flag = ((List<object>)(object)_spawnedSelectables).Remove((object)component);
					}
				}
			}
		}
		base.Clear();
	}

	public override void SelectFirstSelectable()
	{
		List<GameObject> ignoreObjects = new List<GameObject>();
		GameObject gameObject = _SpecialButton.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
		SelectFirstSelectable(ignoreObjects);
	}

	public AccountPage()
	{
		AccountPageState accountPageState = new AccountPageState();
		LinkedList<UIState> stateHistory = null;
		accountPageState.stateHistory = stateHistory;
		accountPageState.flags = new Dictionary<string, bool>();
		this.accountPageState = accountPageState;
		List<ISelectableUI> spawnedSelectables = new List<ISelectableUI>();
		_spawnedSelectables = spawnedSelectables;
		_spawnedUnselectables = new List<IUIObject>();
		((BaseUIPage)this)._002Ector();
	}

	private void _003C_003En__0(GameObject g)
	{
		base.OnShowStart(g);
	}

	private void _003CAddLogoutButton_003Eb__22_0()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003C_003CAddLogoutButton_003Eb__22_0_003Ed stateMachine = default(_003C_003CAddLogoutButton_003Eb__22_0_003Ed);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}
}
