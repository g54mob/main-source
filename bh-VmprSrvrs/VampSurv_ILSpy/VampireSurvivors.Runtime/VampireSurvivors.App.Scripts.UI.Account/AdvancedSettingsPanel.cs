using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI.Account;

public class AdvancedSettingsPanel : BaseAccountPagePanel
{
	[StructLayout((LayoutKind)3)]
	private struct _003C_003CBuild_003Eb__3_2_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AdvancedSettingsPanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_00a9: Expected O, but got I
			//IL_00ef: Expected O, but got I4
			//IL_0110: Expected O, but got I4
			//IL_044b: Expected I4, but got I8
			//IL_0456: Expected O, but got Ref
			//IL_0153: Expected I, but got O
			//IL_048b: Expected O, but got I
			//IL_01a8: Expected O, but got I4
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_01cb: Expected I, but got O
			//IL_0288: Expected O, but got Ref
			//IL_02ae: Expected I, but got O
			object obj = default(object);
			Task task;
			BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
				nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}
			else
			{
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_reset_password_loading");
				bool flag = baseAccountPagePanel == null;
				string text = "manage_account_reset_password_loading";
				if (flag)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel.ShowLoading(accountTranslation);
				bool flag2 = baseAccountPagePanel == null;
				text = (string)(object)baseAccountPagePanel;
				if (flag2)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_20_v2 (VampireSurvivors.UI.BaseAccountPagePanel)+20]");
				text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_20_v2 (VampireSurvivors.UI.BaseAccountPagePanel)+20]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				bool flag3 = text._stringLength == 0;
				text = (string)text._stringLength;
				if (flag3)
				{
					throw new NullReferenceException();
				}
				object obj2 = ((Dictionary<System.Int32Enum, object>)text._stringLength).get_Item((System.Int32Enum)0);
				Task task2 = BackendFacade.SendPasswordReset((string)obj2);
				bool flag4 = task2 == null;
				text = (string)obj2;
				if (flag4)
				{
					throw new NullReferenceException();
				}
				nint num = (nint)obj2;
				if (task2 == null)
				{
					text = (string)num;
					throw new NullReferenceException();
				}
				int num2 = task2.m_stateFlags & 0x1600000;
				bool flag5 = num2 == 0;
				bool flag6 = num2 < 0;
				bool flag7 = !flag6;
				object obj3 = !flag7;
				object obj4 = obj3 | flag5;
				task = task2;
				num = (nint)typeof(Task);
				if (obj4 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter)task2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
					asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num = unchecked((nint)null);
					return;
				}
			}
			if (task != null)
			{
				int num3 = task.m_stateFlags & 0x11000000;
				if (num3 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_reset_password_success");
				Action callback = _003C_003Ec._003C_003E9__3_10;
				if (_003C_003Ec._003C_003E9__3_10 == null)
				{
					callback = (_003C_003Ec._003C_003E9__3_10 = delegate
					{
					});
				}
				baseAccountPagePanel.ShowOkPopupForSuccess(accountTranslation2, callback);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
				string text = null;
				_003C_003E1__state = -2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				if (asyncVoidMethodBuilder3.m_synchronizationContext != null)
				{
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->NotifySynchronizationContextOfCompletion();
				}
				return;
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

	[StructLayout((LayoutKind)3)]
	private struct _003C_003CBuild_003Eb__3_4_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public bool confirm;

		public AdvancedSettingsPanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_004f: Expected O, but got I4
			//IL_005e: Expected I4, but got I8
			//IL_0070: Expected O, but got Ref
			//IL_0358: Expected I4, but got I8
			//IL_0363: Expected O, but got Ref
			//IL_0138: Expected O, but got Ref
			//IL_01bd: Expected O, but got I4
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01db: Expected O, but got I4
			//IL_01e9: Expected I, but got O
			//IL_02b9: Expected O, but got Ref
			//IL_02df: Expected I, but got O
			if (_003C_003E1__state == 0 || confirm)
			{
				object obj = default(object);
				Task task;
				BaseAccountPagePanel CS_0024_003C_003E8__locals4 = default(BaseAccountPagePanel);
				string text;
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
				}
				else
				{
					string accountTranslation = AccountPage.GetAccountTranslation("settings_delete_loading");
					bool flag = CS_0024_003C_003E8__locals4 == null;
					text = "settings_delete_loading";
					if (flag)
					{
						throw new NullReferenceException();
					}
					CS_0024_003C_003E8__locals4.ShowLoading(accountTranslation);
					if (CS_0024_003C_003E8__locals4 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_20_v4 (VampireSurvivors.UI.BaseAccountPagePanel)+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
					AccountDeletionService._003CMarkForDeletion_003Ed__1 stateMachine = default(AccountDeletionService._003CMarkForDeletion_003Ed__1);
					asyncTaskMethodBuilder.Start(ref stateMachine);
					Task<System.Threading.Tasks.VoidTaskResult> task2 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
					bool flag2 = task2 == null;
					text = (string)(&asyncTaskMethodBuilder);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					TaskAwaiter taskAwaiter = default(TaskAwaiter);
					if ((object)taskAwaiter == null)
					{
						throw new NullReferenceException();
					}
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag3 = num == 0;
					bool flag4 = num < 0;
					bool flag5 = !flag4;
					object obj2 = !flag5;
					object obj3 = obj2 | flag3;
					task = (Task)taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)0;
					nint num2 = (nint)typeof(Task);
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter awaiter = default(TaskAwaiter);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = default(AsyncVoidMethodBuilder);
						asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						num2 = unchecked((nint)null);
						return;
					}
				}
				if (task == null)
				{
					throw new NullReferenceException();
				}
				int num3 = task.m_stateFlags & 0x11000000;
				if (num3 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				string accountTranslation2 = AccountPage.GetAccountTranslation("settings_delete_success");
				Action callback = delegate
				{
					AccountPage accountPage = CS_0024_003C_003E8__locals4._accountPage;
					accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
					accountPage.ClearAndBuild();
				};
				CS_0024_003C_003E8__locals4.ShowOkPopupForSuccess(accountTranslation2, callback);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
				text = null;
			}
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder4.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->NotifySynchronizationContextOfCompletion();
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
	private struct _003C_003CBuild_003Eb__3_7_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public bool confirm;

		public AdvancedSettingsPanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_004f: Expected O, but got I4
			//IL_005e: Expected I4, but got I8
			//IL_0070: Expected O, but got Ref
			//IL_0358: Expected I4, but got I8
			//IL_0363: Expected O, but got Ref
			//IL_0138: Expected O, but got Ref
			//IL_01bd: Expected O, but got I4
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01db: Expected O, but got I4
			//IL_01e9: Expected I, but got O
			//IL_02b9: Expected O, but got Ref
			//IL_02df: Expected I, but got O
			if (_003C_003E1__state == 0 || confirm)
			{
				object obj = default(object);
				Task task;
				BaseAccountPagePanel CS_0024_003C_003E8__locals4 = default(BaseAccountPagePanel);
				string text;
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
				}
				else
				{
					string accountTranslation = AccountPage.GetAccountTranslation("settings_cancel_delete_loading");
					bool flag = CS_0024_003C_003E8__locals4 == null;
					text = "settings_cancel_delete_loading";
					if (flag)
					{
						throw new NullReferenceException();
					}
					CS_0024_003C_003E8__locals4.ShowLoading(accountTranslation);
					if (CS_0024_003C_003E8__locals4 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_20_v4 (VampireSurvivors.UI.BaseAccountPagePanel)+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
					AccountDeletionService._003CCancelDeletion_003Ed__2 stateMachine = default(AccountDeletionService._003CCancelDeletion_003Ed__2);
					asyncTaskMethodBuilder.Start(ref stateMachine);
					Task<System.Threading.Tasks.VoidTaskResult> task2 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
					bool flag2 = task2 == null;
					text = (string)(&asyncTaskMethodBuilder);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					TaskAwaiter taskAwaiter = default(TaskAwaiter);
					if ((object)taskAwaiter == null)
					{
						throw new NullReferenceException();
					}
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag3 = num == 0;
					bool flag4 = num < 0;
					bool flag5 = !flag4;
					object obj2 = !flag5;
					object obj3 = obj2 | flag3;
					task = (Task)taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)0;
					nint num2 = (nint)typeof(Task);
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter awaiter = default(TaskAwaiter);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = default(AsyncVoidMethodBuilder);
						asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						num2 = unchecked((nint)null);
						return;
					}
				}
				if (task == null)
				{
					throw new NullReferenceException();
				}
				int num3 = task.m_stateFlags & 0x11000000;
				if (num3 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				string accountTranslation2 = AccountPage.GetAccountTranslation("settings_cancel_delete_success");
				Action callback = delegate
				{
					AccountPage accountPage = CS_0024_003C_003E8__locals4._accountPage;
					accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
					accountPage.ClearAndBuild();
				};
				CS_0024_003C_003E8__locals4.ShowOkPopupForSuccess(accountTranslation2, callback);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
				text = null;
			}
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder4.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->NotifySynchronizationContextOfCompletion();
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

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__3_3;

		public static Action _003C_003E9__3_6;

		public static Action _003C_003E9__3_9;

		public static Action _003C_003E9__3_10;

		public static Action _003C_003E9__3_11;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CBuild_003Eb__3_3()
		{
		}

		internal void _003CBuild_003Eb__3_6()
		{
		}

		internal void _003CBuild_003Eb__3_9()
		{
		}

		internal void _003CBuild_003Eb__3_10()
		{
		}

		internal void _003CBuild_003Eb__3_11()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CBuild_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public AdvancedSettingsPanel _003C_003E4__this;

		private DeletionStatusResponse _003CdeletionStatus_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<DeletionStatusResponse> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_02c9: Expected O, but got I4
			//IL_02d8: Expected I4, but got I8
			//IL_02e0: Expected O, but got Ref
			//IL_0245: Expected I, but got O
			//IL_0921: Expected I4, but got I8
			//IL_070e: Expected O, but got Ref
			//IL_04d8: Expected O, but got I
			//IL_04bc: Expected I, but got O
			//IL_03b2: Expected O, but got Ref
			//IL_03cf: Expected O, but got Ref
			//IL_06c6: Expected I4, but got O
			//IL_014e: Expected O, but got Ref
			//IL_03ef: Expected O, but got I
			//IL_0427: Expected O, but got I4
			//IL_042f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Expected O, but got Unknown
			//IL_043d: Expected O, but got I4
			//IL_09d1: Expected I4, but got O
			//IL_0507: Expected O, but got Ref
			//IL_01d4: Expected O, but got I4
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Expected O, but got Unknown
			//IL_02a6: Expected O, but got Ref
			AdvancedSettingsPanel advancedSettingsPanel = _003C_003E4__this;
			nint num;
			nint num2 = default(nint);
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				num = num2;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					goto IL_08f2;
				}
				string accountTranslation = AccountPage.GetAccountTranslation("advanced_settings_title");
				bool flag = _003C_003E4__this == null;
				string text = "advanced_settings_title";
				if (flag)
				{
					throw new NullReferenceException();
				}
				AccountPage accountPage = ((BaseAccountPagePanel)advancedSettingsPanel)._accountPage;
				bool flag2 = (object)((BaseAccountPagePanel)advancedSettingsPanel)._accountPage == null;
				text = "advanced_settings_title";
				if (flag2)
				{
					throw new NullReferenceException();
				}
				if ((object)((ProgrammaticUI)accountPage)._Title == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				if (_003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
				_003CLoadAccountDetail_003Ed__4 stateMachine = default(_003CLoadAccountDetail_003Ed__4);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<bool> task2 = asyncTaskMethodBuilder.Task;
				bool flag3 = task2 == null;
				text = (string)(&asyncTaskMethodBuilder);
				if (flag3)
				{
					throw new NullReferenceException();
				}
				((AsyncTaskMethodBuilder<bool>*)task2)->Start(ref *(_003CLoadAccountDetail_003Ed__4*)null);
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				if ((object)taskAwaiter == null)
				{
					throw new NullReferenceException();
				}
				int num3 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag4 = num3 == 0;
				bool flag5 = num3 < 0;
				bool flag6 = !flag5;
				object obj = !flag6;
				object obj2 = obj | flag4;
				num = 0;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num4 = task.m_stateFlags & 0x11000000;
			bool flag7 = num4 == 16777216;
			num2 = num;
			if (!flag7)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				num2 = unchecked((nint)null);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v45 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				_003CdeletionStatus_003E5__2 = null;
				goto IL_08f2;
			}
			goto IL_0912;
			IL_08f2:
			object obj3 = default(object);
			Task task3;
			BaseAccountPagePanel CS_0024_003C_003E8__locals11 = default(BaseAccountPagePanel);
			AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = default(AsyncVoidMethodBuilder);
			if ((nint)obj3 == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<DeletionStatusResponse>)0;
				_003C_003E1__state = -1;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)(&obj3);
				task3 = (Task)_003C_003Eu__2;
			}
			else
			{
				string accountTranslation2 = AccountPage.GetAccountTranslation("settings_status_loading");
				bool flag8 = CS_0024_003C_003E8__locals11 == null;
				string text = "settings_status_loading";
				if (flag8)
				{
					throw new NullReferenceException();
				}
				CS_0024_003C_003E8__locals11.ShowLoading(accountTranslation2);
				if (CS_0024_003C_003E8__locals11 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ stack_-E8_v7 (VampireSurvivors.UI.BaseAccountPagePanel)+18]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<object>);
				AccountDeletionService._003CGetDeletionStatus_003Ed__0 stateMachine2 = default(AccountDeletionService._003CGetDeletionStatus_003Ed__0);
				asyncTaskMethodBuilder2.Start(ref stateMachine2);
				Task<object> task4 = asyncTaskMethodBuilder2.Task;
				bool flag9 = task4 == null;
				text = (string)(&asyncTaskMethodBuilder2);
				if (flag9)
				{
					throw new NullReferenceException();
				}
				num2 = 0;
				text = (string)(&asyncTaskMethodBuilder2);
				if (task4 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2375 @ rax_v89 (System.Threading.Tasks.Task`1<System.Object>)+38]");
				object obj4 = (nint)0 & (nint)0x1600000;
				bool flag10 = obj4 == null;
				bool flag11 = (nint)obj4 < 0;
				bool flag12 = !flag11;
				object obj5 = !flag12;
				object obj6 = obj5 | flag10;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)0;
				task3 = task4;
				text = (string)(object)typeof(Task);
				if (obj6 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (TaskAwaiter<DeletionStatusResponse>)task4;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<DeletionStatusResponse> awaiter2 = default(TaskAwaiter<DeletionStatusResponse>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					asyncVoidMethodBuilder4.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					text = null;
					return;
				}
			}
			if (task3 != null)
			{
				int num5 = task3.m_stateFlags & 0x11000000;
				if (num5 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
					num2 = unchecked((nint)null);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
				_003CdeletionStatus_003E5__2 = (DeletionStatusResponse)0;
				((AsyncTaskMethodBuilder<bool>*)(&asyncVoidMethodBuilder4))->Start(ref *(_003CLoadAccountDetail_003Ed__4*)num2);
				string text = null;
				object obj7 = default(object);
				bool isEnabledByDefault = default(bool);
				if (_003CdeletionStatus_003E5__2 != null)
				{
					DeletionStatusResponse deletionStatusResponse = _003CdeletionStatus_003E5__2;
					ProgrammaticUI accountPage2;
					Action callback;
					string buttonText;
					string labelText;
					if (deletionStatusResponse.Status != DeletionStatus.NOT_PENDING)
					{
						string[] args = new string[2];
						int num6 = default(int);
						string text2 = num6.ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8\"");
						int num7 = default(int);
						string text3 = num7.ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						string accountTranslation3 = AccountPage.GetAccountTranslation("settings_delete_status_message", args);
						CS_0024_003C_003E8__locals11._accountPage.AddLabel(accountTranslation3);
						string accountTranslation4 = AccountPage.GetAccountTranslation("settings_cancel_delete_label");
						string accountTranslation5 = AccountPage.GetAccountTranslation("settings_cancel_delete_button");
						Action action = delegate
						{
							//IL_000f: Expected I4, but got O
							string accountTranslation10 = AccountPage.GetAccountTranslation("common_are_you_sure");
							string accountTranslation11 = AccountPage.GetAccountTranslation("settings_cancel_delete_confirm_message");
							Action<bool> action3 = null;
							((AdvancedSettingsPanel)(object)action3)._003CBuild_003Eb__3_7((byte)(int)CS_0024_003C_003E8__locals11 != 0);
							bool textIsLocalizationTerm = default(bool);
							PopupManager.CreateOKCancelPopup("confirm-cancel-delete", accountTranslation10, accountTranslation11, action3, textIsLocalizationTerm);
						};
						accountPage2 = CS_0024_003C_003E8__locals11._accountPage;
						callback = action;
						buttonText = accountTranslation5;
						labelText = accountTranslation4;
					}
					else
					{
						string accountTranslation6 = AccountPage.GetAccountTranslation("settings_delete_label");
						string accountTranslation7 = AccountPage.GetAccountTranslation("settings_delete_button");
						Action action2 = delegate
						{
							//IL_000f: Expected I4, but got O
							string accountTranslation10 = AccountPage.GetAccountTranslation("common_are_you_sure");
							string accountTranslation11 = AccountPage.GetAccountTranslation("settings_delete_confirm_message");
							Action<bool> action3 = null;
							((AdvancedSettingsPanel)(object)action3)._003CBuild_003Eb__3_4((byte)(int)CS_0024_003C_003E8__locals11 != 0);
							bool textIsLocalizationTerm = default(bool);
							PopupManager.CreateOKCancelPopup("confirm-delete", accountTranslation10, accountTranslation11, action3, textIsLocalizationTerm);
						};
						accountPage2 = CS_0024_003C_003E8__locals11._accountPage;
						callback = action2;
						buttonText = accountTranslation7;
						labelText = accountTranslation6;
					}
					LabeledButtonUI labeledButtonUI = accountPage2.AddLabeledButton(labelText, buttonText, callback, (byte)(int)obj7 != 0, isEnabledByDefault);
				}
				string accountTranslation8 = AccountPage.GetAccountTranslation("manage_account_reset_password_label");
				string accountTranslation9 = AccountPage.GetAccountTranslation("manage_account_reset_password_button");
				Action callback2 = delegate
				{
					SynchronizationContext.CurrentNoFlow?.OperationStarted();
					AsyncVoidMethodBuilder asyncVoidMethodBuilder6 = default(AsyncVoidMethodBuilder);
					_003C_003CBuild_003Eb__3_2_003Ed stateMachine3 = default(_003C_003CBuild_003Eb__3_2_003Ed);
					asyncVoidMethodBuilder6.Start(ref stateMachine3);
				};
				LabeledButtonUI labeledButtonUI2 = CS_0024_003C_003E8__locals11._accountPage.AddLabeledButton(accountTranslation8, accountTranslation9, callback2, (byte)(int)obj7 != 0, isEnabledByDefault);
				CS_0024_003C_003E8__locals11.AddBackButtonListener();
				CS_0024_003C_003E8__locals11._accountPage.GenerateNavigation();
				CS_0024_003C_003E8__locals11._accountPage.SelectFirstSelectable();
				goto IL_0912;
			}
			throw new NullReferenceException();
			IL_0912:
			_003C_003E1__state = -2;
			_003CdeletionStatus_003E5__2 = null;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder5 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder5.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder5)->NotifySynchronizationContextOfCompletion();
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
	private struct _003CLoadAccountDetail_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public AdvancedSettingsPanel _003C_003E4__this;

		private TaskAwaiter<AccountDetails> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0027: Expected O, but got I
			//IL_011e: Expected O, but got I4
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_0149: Expected I, but got O
			//IL_02fb: Expected I4, but got I8
			//IL_022f: Expected O, but got Ref
			//IL_026a: Expected O, but got Ref
			//IL_0255: Expected I, but got O
			object obj = default(object);
			Task task;
			BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<AccountDetails>)0;
				_003C_003E1__state = -1;
				IntPtr intPtr = default(IntPtr);
				string text = (string)(nint)intPtr;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_account_details_loading");
				bool flag = baseAccountPagePanel == null;
				string text2 = "manage_account_account_details_loading";
				if (flag)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel.ShowLoading(accountTranslation);
				Task<AccountDetails> accountDetails = BackendFacade.GetAccountDetails();
				bool flag2 = accountDetails == null;
				text2 = null;
				if (flag2)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<AccountDetails> taskAwaiter = default(TaskAwaiter<AccountDetails>);
				if ((object)taskAwaiter == null)
				{
					throw new NullReferenceException();
				}
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag3 = num == 0;
				bool flag4 = num < 0;
				bool flag5 = !flag4;
				object obj2 = !flag5;
				object obj3 = obj2 | flag3;
				string text = accountTranslation;
				task = (Task)taskAwaiter;
				nint num2 = (nint)typeof(Task);
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<AccountDetails> awaiter = default(TaskAwaiter<AccountDetails>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<bool>);
					asyncTaskMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num2 = unchecked((nint)null);
					return;
				}
			}
			if (task != null)
			{
				int num3 = task.m_stateFlags & 0x11000000;
				if (num3 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					string text = null;
				}
				bool flag6 = baseAccountPagePanel == null;
				nint num2 = 0;
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
					_003C_003E1__state = -2;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(result: true);
					return;
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
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
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
		: base(accountPage)
	{
		AccountDeletionService accountDeletionService = new AccountDeletionService();
		_accountDeletionService = accountDeletionService;
	}

	public override void Build()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CBuild_003Ed__3 stateMachine = default(_003CBuild_003Ed__3);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private Task<bool> LoadAccountDetail()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CLoadAccountDetail_003Ed__4 stateMachine = default(_003CLoadAccountDetail_003Ed__4);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	private void _003CBuild_003Eb__3_0()
	{
		//IL_000f: Expected I4, but got O
		string accountTranslation = AccountPage.GetAccountTranslation("common_are_you_sure");
		string accountTranslation2 = AccountPage.GetAccountTranslation("settings_delete_confirm_message");
		Action<bool> action = null;
		((AdvancedSettingsPanel)(object)action)._003CBuild_003Eb__3_4((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("confirm-delete", accountTranslation, accountTranslation2, action, textIsLocalizationTerm);
	}

	private void _003CBuild_003Eb__3_4(bool confirm)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003C_003CBuild_003Eb__3_4_003Ed stateMachine = default(_003C_003CBuild_003Eb__3_4_003Ed);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void _003CBuild_003Eb__3_5()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
		accountPage.ClearAndBuild();
	}

	private void _003CBuild_003Eb__3_1()
	{
		//IL_000f: Expected I4, but got O
		string accountTranslation = AccountPage.GetAccountTranslation("common_are_you_sure");
		string accountTranslation2 = AccountPage.GetAccountTranslation("settings_cancel_delete_confirm_message");
		Action<bool> action = null;
		((AdvancedSettingsPanel)(object)action)._003CBuild_003Eb__3_7((byte)(int)this != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("confirm-cancel-delete", accountTranslation, accountTranslation2, action, textIsLocalizationTerm);
	}

	private void _003CBuild_003Eb__3_7(bool confirm)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003C_003CBuild_003Eb__3_7_003Ed stateMachine = default(_003C_003CBuild_003Eb__3_7_003Ed);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void _003CBuild_003Eb__3_8()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
		accountPage.ClearAndBuild();
	}

	private void _003CBuild_003Eb__3_2()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003C_003CBuild_003Eb__3_2_003Ed stateMachine = default(_003C_003CBuild_003Eb__3_2_003Ed);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}
}
