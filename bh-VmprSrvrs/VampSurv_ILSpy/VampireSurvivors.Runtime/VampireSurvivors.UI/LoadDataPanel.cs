using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class LoadDataPanel : BaseAccountPagePanel
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eb__9_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public bool confirm;

			public _003C_003Ec__DisplayClass4_0 _003C_003E4__this;

			private _003C_003Ec__DisplayClass4_1 _003C_003E8__1;

			private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_004f: Expected O, but got I4
				//IL_005e: Expected I4, but got I8
				//IL_006b: Expected O, but got I8
				//IL_085f: Expected I4, but got I8
				//IL_086a: Expected O, but got Ref
				//IL_00b4: Expected O, but got I
				//IL_0388: Expected O, but got I
				//IL_0a59: Expected I, but got O
				//IL_01c0: Expected O, but got I
				//IL_08c3: Expected I, but got O
				//IL_08ea: Expected I, but got O
				//IL_03cf: Expected O, but got I
				//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0404: Expected O, but got Unknown
				//IL_041e: Expected O, but got I
				//IL_043b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0440: Expected O, but got Unknown
				//IL_0248: Expected I, but got O
				//IL_02a6: Expected O, but got I4
				//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_02b3: Expected O, but got Unknown
				//IL_02c0: Expected O, but got I8
				//IL_02d6: Expected I, but got O
				//IL_0706: Expected O, but got Ref
				//IL_04b0: Expected I, but got O
				//IL_04cb: Expected O, but got I4
				//IL_072c: Expected I, but got O
				//IL_06d7: Expected O, but got I
				//IL_0a1e: Expected I, but got O
				//IL_09c2: Expected O, but got I4
				//IL_094d: Expected O, but got I4
				//IL_0647: Unknown result type (might be due to invalid IL or missing references)
				//IL_064c: Expected O, but got Unknown
				//IL_06b0: Expected I, but got O
				//IL_05ea: Expected I, but got O
				if (_003C_003E1__state == 0 || confirm)
				{
					object obj = default(object);
					object obj2;
					Task task;
					_003C_003Ec__DisplayClass4_0 obj5 = default(_003C_003Ec__DisplayClass4_0);
					nint num;
					if (obj == null)
					{
						_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)0;
						_003C_003E1__state = -1;
						obj2 = 6442450944L;
						task = (Task)_003C_003Eu__1;
						num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
					}
					else
					{
						_003C_003Ec__DisplayClass4_1 obj3 = new _003C_003Ec__DisplayClass4_1();
						_003C_003E8__1 = obj3;
						_003C_003Ec__DisplayClass4_1 obj4 = _003C_003E8__1;
						if (_003C_003E8__1 == null)
						{
							throw new NullReferenceException();
						}
						obj4.CS_0024_003C_003E8__locals1 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
						string text = (string)0;
						if (obj5 == null)
						{
							throw new NullReferenceException();
						}
						string accountTranslation = AccountPage.GetAccountTranslation("load_data_cloud_load_loading");
						bool flag = obj5._003C_003E4__this == null;
						text = "load_data_cloud_load_loading";
						if (flag)
						{
							throw new NullReferenceException();
						}
						obj5._003C_003E4__this.ShowLoading(accountTranslation);
						bool flag2 = obj5 == null;
						text = (string)(object)obj5._003C_003E4__this;
						if (flag2)
						{
							throw new NullReferenceException();
						}
						text = (string)(object)obj5._003C_003E4__this;
						if (obj5._003C_003E4__this == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v9 (System.String)+18]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v9 (System.String)+18]");
						num = 0;
						if (flag3)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rcx_v9 (System.String)+18]");
						PlayerOptionsData config = ((PlayerOptions)0).Config;
						nint num2 = (nint)typeof(SaveBackupService);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ rax_v154 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.SaveBackupService>)+B8]");
						nint num3 = 0;
						SaveBackupService._backupSaveData = config;
						nint num4 = (nint)typeof(SaveBackupService);
						num = num3;
						if (obj5 == null)
						{
							throw new NullReferenceException();
						}
						Task<PlayerOptionsData> slotSaveData = BackendFacade.GetSlotSaveData(obj5.slot);
						bool flag4 = slotSaveData == null;
						num = obj5.slot;
						if (flag4)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
						TaskAwaiter<PlayerOptionsData> taskAwaiter = default(TaskAwaiter<PlayerOptionsData>);
						bool flag5 = (object)taskAwaiter == null;
						num = (nint)slotSaveData;
						if (flag5)
						{
							throw new NullReferenceException();
						}
						int num5 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
						bool flag6 = num5 == 0;
						bool flag7 = num5 < 0;
						bool flag8 = !flag7;
						object obj6 = !flag8;
						object obj7 = obj6 | flag6;
						obj2 = 6442450944L;
						task = (Task)taskAwaiter;
						num = (nint)typeof(Task);
						if (obj7 != null)
						{
							_003C_003E1__state = 0;
							_003C_003Eu__1 = taskAwaiter;
							AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
							TaskAwaiter<PlayerOptionsData> awaiter = default(TaskAwaiter<PlayerOptionsData>);
							((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
							AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
							asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							num = unchecked((nint)null);
							return;
						}
					}
					if (task == null)
					{
						throw new NullReferenceException();
					}
					int num6 = task.m_stateFlags & 0x11000000;
					if (num6 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					}
					_003C_003Ec__DisplayClass4_1 obj8 = _003C_003E8__1;
					bool flag9 = _003C_003E8__1 == null;
					num = 0;
					if (flag9)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rbx_v15 (System.Threading.Tasks.Task)+50]");
					obj8.loadedData = (PlayerOptionsData)0;
					num = (nint)SystemPlatform.sInstance;
					if (SystemPlatform.sInstance == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rcx_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rcx_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					object obj9 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1189 @ rdx_v22+1C8] (should have been resolved before IL gen)");
					object obj10 = default(object);
					if (obj10 == null)
					{
						throw new NullReferenceException();
					}
					object obj11 = obj10 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
					LoadDataPanel loadDataPanel = (LoadDataPanel)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj12 = default(object);
					loadDataPanel = (LoadDataPanel)(obj12 + 32);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj13 = default(object);
					IntPtr intPtr = default(IntPtr);
					nint num7;
					if ((nint)obj13 == (nint)intPtr)
					{
						if (obj5 == null)
						{
							throw new NullReferenceException();
						}
						_003C_003Ec__DisplayClass4_1 obj14 = _003C_003E8__1;
						obj5._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(obj14.loadedData, allowAchievements: true, syncRetroactively: false);
						num7 = unchecked((nint)null);
						Action action = null;
						string loadedData = (string)(object)obj14.loadedData;
						string text2 = (string)1;
					}
					else
					{
						_003C_003Ec__DisplayClass4_1 obj15 = _003C_003E8__1;
						if (_003C_003E8__1 == null)
						{
							throw new NullReferenceException();
						}
						if (obj15.loadedData == null)
						{
							throw new NullReferenceException();
						}
						Action noCallback = default(Action);
						if (!obj15.loadedData.PlatformAchievementsAllowed())
						{
							if (obj5 == null)
							{
								throw new NullReferenceException();
							}
							string accountTranslation2 = AccountPage.GetAccountTranslation("achievement_blocked_title");
							string accountTranslation3 = AccountPage.GetAccountTranslation("achievement_blocked_description_generic");
							object obj16 = SystemPlatform.Platform + -2;
							bool flag10 = (nint)obj16 > 1;
							string text3 = accountTranslation3;
							if (!flag10)
							{
								string accountTranslation4 = AccountPage.GetAccountTranslation("achievement_blocked_description_playstation");
								text3 = accountTranslation4;
							}
							Action action2 = delegate
							{
								_003C_003Ec__DisplayClass4_0 obj19 = _003C_003E8__1.CS_0024_003C_003E8__locals1;
								obj19._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(_003C_003E8__1.loadedData, allowAchievements: false, syncRetroactively: false);
							};
							if (obj5 == null)
							{
								throw new NullReferenceException();
							}
							Action action3 = delegate
							{
								((BaseAccountPagePanel)obj5._003C_003E4__this)._accountPage.Clear();
								obj5._003C_003E4__this.Build();
							};
							if (obj5._003C_003E4__this == null)
							{
								throw new NullReferenceException();
							}
							obj5._003C_003E4__this.ShowYesNoPopup(accountTranslation2, text3, action2, noCallback);
							num7 = unchecked((nint)null);
							Action action = action2;
							string loadedData = accountTranslation2;
							string text2 = text3;
						}
						else
						{
							if (obj5 == null)
							{
								throw new NullReferenceException();
							}
							string accountTranslation5 = AccountPage.GetAccountTranslation("achievement_sync_title");
							string accountTranslation6 = AccountPage.GetAccountTranslation("achievement_sync_description_generic");
							object obj17 = SystemPlatform.Platform + -2;
							Action action4 = default(Action);
							Action action5 = default(Action);
							if ((nint)obj17 <= 5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r15_v15+7617D48+v1956 @ rax_v91*4]");
								object obj18 = 0 + obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v362 @ rcx_v61 (should have been resolved before IL gen)");
							}
							else
							{
								action4 = delegate
								{
									_003C_003Ec__DisplayClass4_0 obj19 = _003C_003E8__1.CS_0024_003C_003E8__locals1;
									obj19._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(_003C_003E8__1.loadedData, allowAchievements: true, syncRetroactively: true);
								};
								action5 = delegate
								{
									_003C_003Ec__DisplayClass4_0 obj19 = _003C_003E8__1.CS_0024_003C_003E8__locals1;
									obj19._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(_003C_003E8__1.loadedData, allowAchievements: false, syncRetroactively: false);
								};
							}
							action5._002Ector(_003C_003E8__1, (nint)__ldftn(_003C_003Ec__DisplayClass4_1._003CBuild_003Eb__11));
							if (obj5._003C_003E4__this == null)
							{
								throw new NullReferenceException();
							}
							obj5._003C_003E4__this.ShowYesNoPopup(accountTranslation5, accountTranslation6, action4, noCallback);
							num7 = unchecked((nint)null);
							Action action = action4;
							string loadedData = accountTranslation5;
							string text2 = accountTranslation6;
						}
					}
					_003C_003E8__1 = (_003C_003Ec__DisplayClass4_1)num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187614240");
					nint num8 = unchecked((nint)null);
				}
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

		public int slot;

		public LoadDataPanel _003C_003E4__this;

		public Action<bool> _003C_003E9__9;

		internal void _003CBuild_003Eb__8()
		{
			//IL_0014: Expected I4, but got O
			string accountTranslation = AccountPage.GetAccountTranslation("common_are_you_sure");
			string accountTranslation2 = AccountPage.GetAccountTranslation("load_data_load_confirm_message");
			Action<bool> callback = _003C_003E9__9;
			if (_003C_003E9__9 == null)
			{
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass4_0)(object)action)._003CBuild_003Eb__9((byte)(int)this != 0);
				_003C_003E9__9 = action;
				callback = action;
			}
			bool textIsLocalizationTerm = default(bool);
			PopupManager.CreateOKCancelPopup("load-data-popup", accountTranslation, accountTranslation2, callback, textIsLocalizationTerm);
		}

		internal void _003CBuild_003Eb__9(bool confirm)
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eb__9_003Ed stateMachine = default(_003C_003CBuild_003Eb__9_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public PlayerOptionsData loadedData;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal void _003CBuild_003Eb__10()
		{
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
			obj._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(loadedData, allowAchievements: true, syncRetroactively: true);
		}

		internal void _003CBuild_003Eb__11()
		{
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
			obj._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(loadedData, allowAchievements: false, syncRetroactively: false);
		}

		internal void _003CBuild_003Eb__12()
		{
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
			obj._003C_003E4__this._003CBuild_003Eg__ApplyLoadedSave_007C4_5(loadedData, allowAchievements: false, syncRetroactively: false);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CBuild_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LoadDataPanel _003C_003E4__this;

		private TaskAwaiter<string> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_05ad: Expected O, but got I
			//IL_05b2: Expected O, but got Ref
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
			//IL_060f: Expected I4, but got I8
			//IL_061a: Expected O, but got Ref
			//IL_044c: Expected I4, but got O
			LoadDataPanel loadDataPanel = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			IntPtr intPtr = default(IntPtr);
			string text = (string)(nint)intPtr;
			BaseAccountPagePanel baseAccountPagePanel = (BaseAccountPagePanel)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			if (!flag)
			{
				string accountTranslation = AccountPage.GetAccountTranslation("load_data_title");
				bool flag2 = _003C_003E4__this == null;
				string text2 = "load_data_title";
				if (flag2)
				{
					throw new NullReferenceException();
				}
				text2 = (string)(object)((BaseAccountPagePanel)loadDataPanel)._accountPage;
				if ((object)((BaseAccountPagePanel)loadDataPanel)._accountPage == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v24 (System.String)+E0]");
				text2 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rcx_v24 (System.String)+E0]");
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
			LoadDataPanel CS_0024_003C_003E8__locals16 = default(LoadDataPanel);
			if (obj2 == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				int num = (int)text;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (CS_0024_003C_003E8__locals16 == null)
				{
					throw new NullReferenceException();
				}
				if (CS_0024_003C_003E8__locals16._cloudDataService == null)
				{
					throw new NullReferenceException();
				}
				Task<string> slotSummary = CS_0024_003C_003E8__locals16._cloudDataService.GetSlotSummary(1);
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
				PlayerOptionsData config = CS_0024_003C_003E8__locals16._playerOptions.Config;
				string savedata = CS_0024_003C_003E8__locals16._cloudDataService.PlayerOptionsDataToSummaryString(config);
				string accountTranslation3 = AccountPage.GetAccountTranslation("load_data_local_data_label");
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.AddLabel(accountTranslation3);
				string accountTranslation4 = AccountPage.GetAccountTranslation("load_data_local_label");
				Action action = default(Action);
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.AddSaveSlot(accountTranslation4, savedata, "", action);
				string accountTranslation5 = AccountPage.GetAccountTranslation("load_data_cloud_data_label");
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.AddLabel(accountTranslation5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rbx_v27 (System.Threading.Tasks.Task)+50]");
				CS_0024_003C_003E8__locals16._003CBuild_003Eg__BuildLoadButton_007C4_1((string)0, 1);
				if ((nint)SaveBackupService._backupSaveData > 0)
				{
					string accountTranslation6 = AccountPage.GetAccountTranslation("load_data_undo_load_label");
					string accountTranslation7 = AccountPage.GetAccountTranslation("load_data_undo_load_button");
					Action action2 = delegate
					{
						bool onlineClientWithRunData = default(bool);
						CS_0024_003C_003E8__locals16._playerOptions.ApplyConfig(SaveBackupService._backupSaveData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
						SaveSystem.Save(SaveBackupService._backupSaveData);
						SaveBackupService.ClearBackup();
						((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.Clear();
						CS_0024_003C_003E8__locals16.Build();
					};
					action2._002Ector(CS_0024_003C_003E8__locals16, (nint)__ldftn(LoadDataPanel._003CBuild_003Eb__4_6));
					bool isEnabledByDefault = default(bool);
					LabeledButtonUI labeledButtonUI = ((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.AddLabeledButton(accountTranslation6, accountTranslation7, action2, (byte)(int)action != 0, isEnabledByDefault);
				}
				CS_0024_003C_003E8__locals16.AddBackButtonListener();
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.GenerateNavigation();
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals16)._accountPage.SelectFirstSelectable();
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

	private AchievementManager _achievementManager;

	public LoadDataPanel(AccountPage accountPage, PlayerOptions playerOptions, AchievementManager achievementManager)
		: base(accountPage)
	{
		_playerOptions = playerOptions;
		_cloudDataService = new CloudDataService();
		_achievementManager = achievementManager;
	}

	public override void Build()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CBuild_003Ed__4 stateMachine = default(_003CBuild_003Ed__4);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private unsafe void _003CBuild_003Eg__BuildUndoButton_007C4_0()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("load_data_undo_load_label");
		string accountTranslation2 = AccountPage.GetAccountTranslation("load_data_undo_load_button");
		Action action = delegate
		{
			bool onlineClientWithRunData = default(bool);
			_playerOptions.ApplyConfig(SaveBackupService._backupSaveData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
			SaveSystem.Save(SaveBackupService._backupSaveData);
			SaveBackupService.ClearBackup();
			base._accountPage.Clear();
			Build();
		};
		action._002Ector(this, (nint)__ldftn(LoadDataPanel._003CBuild_003Eb__4_6));
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = base._accountPage.AddLabeledButton(accountTranslation, accountTranslation2, action, textIsLocalizationTerm, isEnabledByDefault);
	}

	private void _003CBuild_003Eb__4_6()
	{
		bool onlineClientWithRunData = default(bool);
		_playerOptions.ApplyConfig(SaveBackupService._backupSaveData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
		SaveSystem.Save(SaveBackupService._backupSaveData);
		SaveBackupService.ClearBackup();
		base._accountPage.Clear();
		Build();
	}

	private void _003CBuild_003Eb__4_7()
	{
		SaveBackupService.ClearBackup();
		base._accountPage.Clear();
		Build();
	}

	private unsafe void _003CBuild_003Eg__BuildLoadButton_007C4_1(string slotSummary, int slot)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Ref, but got Unknown
		//IL_00ce: Expected I8, but got I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Ref, but got Unknown
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.slot = slot;
		CloudDataService cloudDataService = _cloudDataService;
		string nO_DATA_LABEL = cloudDataService.NO_DATA_LABEL;
		if ((object)slotSummary == cloudDataService.NO_DATA_LABEL)
		{
			goto IL_016a;
		}
		if (cloudDataService.NO_DATA_LABEL != null && slotSummary._stringLength == nO_DATA_LABEL._stringLength)
		{
			ref byte first = ref *(byte*)(slotSummary + 20);
			ulong length = (ulong)(slotSummary._stringLength + slotSummary._stringLength);
			if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(cloudDataService.NO_DATA_LABEL + 20), length))
			{
				goto IL_016a;
			}
		}
		string accountTranslation = AccountPage.GetAccountTranslation("load_data_cloud_slot");
		string accountTranslation2 = AccountPage.GetAccountTranslation("load_data_load_button");
		Action action = delegate
		{
			//IL_0014: Expected I4, but got O
			string accountTranslation4 = AccountPage.GetAccountTranslation("common_are_you_sure");
			string accountTranslation5 = AccountPage.GetAccountTranslation("load_data_load_confirm_message");
			Action<bool> callback2 = CS_0024_003C_003E8__locals6._003C_003E9__9;
			if (CS_0024_003C_003E8__locals6._003C_003E9__9 == null)
			{
				Action<bool> action2 = null;
				((_003C_003Ec__DisplayClass4_0)(object)action2)._003CBuild_003Eb__9((byte)(int)CS_0024_003C_003E8__locals6 != 0);
				CS_0024_003C_003E8__locals6._003C_003E9__9 = action2;
				callback2 = action2;
			}
			bool textIsLocalizationTerm = default(bool);
			PopupManager.CreateOKCancelPopup("load-data-popup", accountTranslation4, accountTranslation5, callback2, textIsLocalizationTerm);
		};
		ProgrammaticUI accountPage = base._accountPage;
		string buttonText = accountTranslation2;
		string title = accountTranslation;
		string savedata = slotSummary;
		goto IL_01b3;
		IL_01b3:
		Action callback = default(Action);
		accountPage.AddSaveSlot(title, savedata, buttonText, callback);
		return;
		IL_016a:
		string accountTranslation3 = AccountPage.GetAccountTranslation("load_data_cloud_slot");
		accountPage = base._accountPage;
		buttonText = "";
		title = accountTranslation3;
		savedata = slotSummary;
		goto IL_01b3;
	}

	private void _003CBuild_003Eb__4_13()
	{
		base._accountPage.Clear();
		Build();
	}

	internal static string _003CBuild_003Eg__GetSyncPlatformDescription_007C4_2()
	{
		//IL_0058: Expected O, but got I4
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		string accountTranslation = AccountPage.GetAccountTranslation("achievement_sync_description_generic");
		object obj = SystemPlatform.Platform + -2;
		if ((nint)obj <= 5)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v1+7616BB4+v38 @ rcx_v5*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ rdx_v4 (should have been resolved before IL gen)");
		}
		return accountTranslation;
	}

	internal static string _003CBuild_003Eg__GetBlockedPlatformDescription_007C4_3()
	{
		//IL_003a: Expected O, but got I4
		string accountTranslation = AccountPage.GetAccountTranslation("achievement_blocked_description_generic");
		object obj = SystemPlatform.Platform - 2;
		if ((nint)obj <= 1)
		{
			return AccountPage.GetAccountTranslation("achievement_blocked_description_playstation");
		}
		return accountTranslation;
	}

	internal static bool _003CBuild_003Eg__IsAnAchievementPlatform_007C4_4()
	{
		//IL_00d5: Expected I4, but got O
		//IL_003c: Expected I, but got O
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		SystemPlatform sInstance = SystemPlatform.sInstance;
		if (SystemPlatform.sInstance != null)
		{
			IBaseAccount currentSystem = sInstance.m_CurrentSystem;
			if (sInstance.m_CurrentSystem != null)
			{
				nint num = (nint)currentSystem;
				IPlatformAchievementsManager achievementsManager = sInstance.m_CurrentSystem.AchievementsManager;
				if (achievementsManager != null)
				{
					object obj = achievementsManager + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj3 = default(object);
					object obj2 = obj3 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj5 = default(object);
					object obj6 = default(object);
					object obj4 = obj5 - obj6;
					bool flag = obj4 == null;
					return !flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void _003CBuild_003Eg__ApplyLoadedSave_007C4_5(PlayerOptionsData loadedData, bool allowAchievements, bool syncRetroactively)
	{
		loadedData._003CSaveSyncPlatformAchievements_003Ek__BackingField = allowAchievements;
		bool onlineClientWithRunData = default(bool);
		_playerOptions.ApplyConfig(loadedData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
		SaveSystem.Save(loadedData);
		if (syncRetroactively)
		{
			_achievementManager.ApplyPlatformAchievementsRetroactively();
		}
		string accountTranslation = AccountPage.GetAccountTranslation("load_data_cloud_load_success");
		Action callback = delegate
		{
			base._accountPage.Clear();
			Build();
		};
		ShowOkPopupForSuccess(accountTranslation, callback);
	}

	private void _003CBuild_003Eb__4_14()
	{
		base._accountPage.Clear();
		Build();
	}
}
