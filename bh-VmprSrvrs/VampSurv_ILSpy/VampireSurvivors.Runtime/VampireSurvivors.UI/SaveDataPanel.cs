using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class SaveDataPanel : BaseAccountPagePanel
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eg__TrySave_007C1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass4_0 _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_004f: Expected O, but got Ref
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_0027: Expected O, but got Ref
				//IL_00ae: Expected O, but got I
				//IL_00cd: Expected O, but got I
				//IL_00eb: Expected O, but got I
				//IL_0146: Expected O, but got I
				//IL_030d: Expected O, but got I
				//IL_0330: Expected O, but got I
				//IL_044e: Expected O, but got I4
				//IL_0488: Expected I4, but got I8
				//IL_0493: Expected O, but got Ref
				//IL_020e: Expected O, but got I4
				//IL_0216: Unknown result type (might be due to invalid IL or missing references)
				//IL_021b: Expected O, but got Unknown
				//IL_0224: Expected O, but got I4
				//IL_023a: Expected I, but got O
				//IL_035a: Expected O, but got Ref
				//IL_0380: Expected I, but got O
				object obj = default(object);
				Task task;
				IntPtr intPtr = default(IntPtr);
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
					task = (Task)_003C_003Eu__1;
					nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				else
				{
					bool flag = intPtr == (IntPtr)0;
					_003C_003CBuild_003Eg__TrySave_007C1_003Ed obj2 = (_003C_003CBuild_003Eg__TrySave_007C1_003Ed)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
					if (flag)
					{
						throw new NullReferenceException();
					}
					string accountTranslation = AccountPage.GetAccountTranslation("save_data_cloud_save_loading");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					bool flag2 = (nint)0 == 0;
					obj2 = (_003C_003CBuild_003Eg__TrySave_007C1_003Ed)"save_data_cloud_save_loading";
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					((BaseAccountPagePanel)0).ShowLoading(accountTranslation);
					bool flag3 = intPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					obj2 = (_003C_003CBuild_003Eg__TrySave_007C1_003Ed)0;
					if (flag3)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					obj2 = (_003C_003CBuild_003Eg__TrySave_007C1_003Ed)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v2 (VampireSurvivors.UI.SaveDataPanel+<>c__DisplayClass4_0+<<Build>g__TrySave|1>d)+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v2 (VampireSurvivors.UI.SaveDataPanel+<>c__DisplayClass4_0+<<Build>g__TrySave|1>d)+18]");
					PlayerOptionsData config = ((PlayerOptions)0).Config;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
					BackendFacade._003CSetSlotSaveData_003Ed__41 stateMachine = default(BackendFacade._003CSetSlotSaveData_003Ed__41);
					asyncTaskMethodBuilder.Start(ref stateMachine);
					Task<bool> task2 = asyncTaskMethodBuilder.Task;
					if (task2 == null)
					{
						throw new NullReferenceException();
					}
					((AsyncTaskMethodBuilder<bool>*)task2)->Start(ref *(BackendFacade._003CSetSlotSaveData_003Ed__41*)null);
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					if ((object)taskAwaiter == null)
					{
						throw new NullReferenceException();
					}
					int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag4 = num2 == 0;
					bool flag5 = num2 < 0;
					bool flag6 = !flag5;
					object obj3 = !flag6;
					object obj4 = obj3 | flag4;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)0;
					task = (Task)taskAwaiter;
					nint num = (nint)typeof(Task);
					if (obj4 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = default(AsyncVoidMethodBuilder);
						asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref awaiter, ref this);
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
					bool flag7 = intPtr == (IntPtr)0;
					nint num = 0;
					if (!flag7)
					{
						string accountTranslation2 = AccountPage.GetAccountTranslation("save_data_cloud_save_success");
						if (intPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
							Action callback = ((BaseAccountPagePanel)0).GoHome;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
							((BaseAccountPagePanel)0).ShowOkPopupForSuccess(accountTranslation2, callback);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187614240");
							_003C_003CBuild_003Eg__TrySave_007C1_003Ed obj2 = (_003C_003CBuild_003Eg__TrySave_007C1_003Ed)0;
							_003C_003E1__state = -2;
							AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
							if (asyncVoidMethodBuilder4.m_synchronizationContext != null)
							{
								((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->NotifySynchronizationContextOfCompletion();
							}
							return;
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

		public int slot;

		public bool isSlotEmpty;

		public SaveDataPanel _003C_003E4__this;

		public Action<bool> _003C_003E9__3;

		internal void _003CBuild_003Eg__TrySave_007C1()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eg__TrySave_007C1_003Ed stateMachine = default(_003C_003CBuild_003Eg__TrySave_007C1_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}

		internal void _003CBuild_003Eb__2()
		{
			//IL_0061: Expected I4, but got O
			if (!isSlotEmpty)
			{
				string accountTranslation = AccountPage.GetAccountTranslation("common_are_you_sure");
				string accountTranslation2 = AccountPage.GetAccountTranslation("save_data_save_confirm_message");
				Action<bool> callback = _003C_003E9__3;
				if (_003C_003E9__3 == null)
				{
					Action<bool> action = null;
					((_003C_003Ec__DisplayClass4_0)(object)action)._003CBuild_003Eb__3((byte)(int)this != 0);
					_003C_003E9__3 = action;
					callback = action;
				}
				bool textIsLocalizationTerm = default(bool);
				PopupManager.CreateOKCancelPopup("save-data-popup", accountTranslation, accountTranslation2, callback, textIsLocalizationTerm);
			}
			else
			{
				_003CBuild_003Eg__TrySave_007C1();
			}
		}

		internal void _003CBuild_003Eb__3(bool confirm)
		{
			if (confirm)
			{
				_003CBuild_003Eg__TrySave_007C1();
			}
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CBuild_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public SaveDataPanel _003C_003E4__this;

		private TaskAwaiter<string> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_054f: Expected O, but got I
			//IL_0554: Expected O, but got Ref
			//IL_0116: Expected O, but got I4
			//IL_0125: Expected I4, but got I8
			//IL_012d: Expected I4, but got O
			//IL_007a: Expected O, but got I
			//IL_00d4: Expected O, but got I4
			//IL_0226: Expected O, but got I4
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Expected O, but got Unknown
			//IL_023c: Expected O, but got I4
			//IL_025b: Expected I, but got O
			//IL_0310: Expected O, but got Ref
			//IL_0336: Expected I, but got O
			//IL_0408: Expected O, but got I
			//IL_05b1: Expected I4, but got I8
			//IL_05bc: Expected O, but got Ref
			SaveDataPanel saveDataPanel = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			IntPtr intPtr = default(IntPtr);
			string text = (string)(nint)intPtr;
			BaseAccountPagePanel baseAccountPagePanel = (BaseAccountPagePanel)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			if (!flag)
			{
				string accountTranslation = AccountPage.GetAccountTranslation("save_data_title");
				bool flag2 = _003C_003E4__this == null;
				string text2 = "save_data_title";
				if (flag2)
				{
					throw new NullReferenceException();
				}
				text2 = (string)(object)((BaseAccountPagePanel)saveDataPanel)._accountPage;
				if ((object)((BaseAccountPagePanel)saveDataPanel)._accountPage == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v22 (System.String)+E0]");
				text2 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v22 (System.String)+E0]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				string accountTranslation2 = AccountPage.GetAccountTranslation("load_data_cloud_load_loading");
				_003C_003E4__this.ShowLoading(accountTranslation2);
				object obj = 0;
				text = accountTranslation2;
				baseAccountPagePanel = _003C_003E4__this;
			}
			object obj2 = default(object);
			Task task;
			SaveDataPanel saveDataPanel2 = default(SaveDataPanel);
			if (obj2 == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				int num = (int)text;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (saveDataPanel2 == null)
				{
					throw new NullReferenceException();
				}
				if (saveDataPanel2._cloudDataService == null)
				{
					throw new NullReferenceException();
				}
				Task<string> slotSummary = saveDataPanel2._cloudDataService.GetSlotSummary(1);
				if (slotSummary == null)
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
				bool flag3 = num2 == 0;
				bool flag4 = num2 < 0;
				bool flag5 = !flag4;
				object obj3 = !flag5;
				object obj4 = obj3 | flag3;
				object obj = 0;
				int num = 1;
				task = (Task)taskAwaiter;
				nint num3 = (nint)typeof(Task);
				if (obj4 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
					asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num3 = unchecked((nint)null);
					return;
				}
			}
			if (task != null)
			{
				int num4 = task.m_stateFlags & 0x11000000;
				if (num4 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					int num = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
				string text2 = null;
				PlayerOptionsData config = saveDataPanel2._playerOptions.Config;
				string savedata = saveDataPanel2._cloudDataService.PlayerOptionsDataToSummaryString(config);
				string accountTranslation3 = AccountPage.GetAccountTranslation("save_data_local_data_label");
				((BaseAccountPagePanel)saveDataPanel2)._accountPage.AddLabel(accountTranslation3);
				string accountTranslation4 = AccountPage.GetAccountTranslation("save_data_local_label");
				object callback = default(object);
				((BaseAccountPagePanel)saveDataPanel2)._accountPage.AddSaveSlot(accountTranslation4, savedata, "", (Action)callback);
				string accountTranslation5 = AccountPage.GetAccountTranslation("save_data_cloud_data_label");
				((BaseAccountPagePanel)saveDataPanel2)._accountPage.AddLabel(accountTranslation5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v25 (System.Threading.Tasks.Task)+50]");
				saveDataPanel2._003CBuild_003Eg__BuildSaveButton_007C4_0((string)0, 1);
				saveDataPanel2.AddBackButtonListener();
				((BaseAccountPagePanel)saveDataPanel2)._accountPage.GenerateNavigation();
				((BaseAccountPagePanel)saveDataPanel2)._accountPage.SelectFirstSelectable();
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

	private PlayerOptions _playerOptions;

	private CloudDataService _cloudDataService;

	private AccountPage _accountPage;

	public SaveDataPanel(AccountPage accountPage, PlayerOptions playerOptions)
		: base(accountPage)
	{
		_playerOptions = playerOptions;
		_cloudDataService = new CloudDataService();
		_accountPage = accountPage;
	}

	public override void Build()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CBuild_003Ed__4 stateMachine = default(_003CBuild_003Ed__4);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private unsafe void _003CBuild_003Eg__BuildSaveButton_007C4_0(string slotSummary, int slot)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Ref, but got Unknown
		//IL_00ce: Expected I8, but got I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Ref, but got Unknown
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		CS_0024_003C_003E8__locals11.slot = slot;
		CloudDataService cloudDataService = _cloudDataService;
		string nO_DATA_LABEL = cloudDataService.NO_DATA_LABEL;
		string text;
		if ((object)slotSummary != cloudDataService.NO_DATA_LABEL)
		{
			if (cloudDataService.NO_DATA_LABEL != null && slotSummary._stringLength == nO_DATA_LABEL._stringLength)
			{
				ref byte first = ref *(byte*)(slotSummary + 20);
				ulong length = (ulong)(slotSummary._stringLength + slotSummary._stringLength);
				if (CS_0024_003C_003E8__locals11.isSlotEmpty = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(cloudDataService.NO_DATA_LABEL + 20), length))
				{
					goto IL_0198;
				}
			}
			else
			{
				CS_0024_003C_003E8__locals11.isSlotEmpty = false;
			}
			text = "overwrite_button";
			goto IL_01a6;
		}
		CS_0024_003C_003E8__locals11.isSlotEmpty = true;
		goto IL_0198;
		IL_01a6:
		string key = "save_data_" + text;
		string accountTranslation = AccountPage.GetAccountTranslation(key);
		string accountTranslation2 = AccountPage.GetAccountTranslation("save_data_cloud_slot");
		Action action = delegate
		{
			//IL_0061: Expected I4, but got O
			if (!CS_0024_003C_003E8__locals11.isSlotEmpty)
			{
				string accountTranslation3 = AccountPage.GetAccountTranslation("common_are_you_sure");
				string accountTranslation4 = AccountPage.GetAccountTranslation("save_data_save_confirm_message");
				Action<bool> callback2 = CS_0024_003C_003E8__locals11._003C_003E9__3;
				if (CS_0024_003C_003E8__locals11._003C_003E9__3 == null)
				{
					Action<bool> action2 = null;
					((_003C_003Ec__DisplayClass4_0)(object)action2)._003CBuild_003Eb__3((byte)(int)CS_0024_003C_003E8__locals11 != 0);
					CS_0024_003C_003E8__locals11._003C_003E9__3 = action2;
					callback2 = action2;
				}
				bool textIsLocalizationTerm = default(bool);
				PopupManager.CreateOKCancelPopup("save-data-popup", accountTranslation3, accountTranslation4, callback2, textIsLocalizationTerm);
			}
			else
			{
				CS_0024_003C_003E8__locals11._003CBuild_003Eg__TrySave_007C1();
			}
		};
		Action callback = default(Action);
		base._accountPage.AddSaveSlot(accountTranslation2, slotSummary, accountTranslation, callback);
		return;
		IL_0198:
		text = "save_button";
		goto IL_01a6;
	}
}
