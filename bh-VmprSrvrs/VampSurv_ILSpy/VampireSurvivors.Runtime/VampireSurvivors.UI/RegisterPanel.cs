using System;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.App.Scripts.UI;

namespace VampireSurvivors.UI;

public class RegisterPanel : BaseAccountPagePanel
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__2_4;

		public static Action _003C_003E9__2_5;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CBuild_003Eb__2_4()
		{
		}

		internal void _003CBuild_003Eb__2_5()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eb__2_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass2_0 _003C_003E4__this;

			private string _003CemailAddress_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_05e7: Expected O, but got I4
				//IL_05f6: Expected I4, but got I8
				//IL_05be: Expected O, but got I4
				//IL_05cd: Expected I4, but got I8
				//IL_058d: Expected O, but got I4
				//IL_059c: Expected I4, but got I8
				//IL_0e31: Expected O, but got I
				//IL_067c: Expected I, but got O
				//IL_06ab: Expected I, but got O
				//IL_07d0: Expected I, but got O
				//IL_02c1: Expected O, but got I
				//IL_009c: Expected O, but got Ref
				//IL_00b4: Expected O, but got Ref
				//IL_07ff: Expected I, but got O
				//IL_0300: Expected O, but got I
				//IL_0162: Expected O, but got I
				//IL_00cb: Expected O, but got Ref
				//IL_00d4: Expected O, but got I4
				//IL_0709: Expected O, but got I4
				//IL_0711: Unknown result type (might be due to invalid IL or missing references)
				//IL_0716: Expected O, but got Unknown
				//IL_071f: Expected O, but got I4
				//IL_0735: Expected I, but got O
				//IL_0e56: Expected I4, but got I8
				//IL_0e61: Expected O, but got Ref
				//IL_0bd3: Expected O, but got Ref
				//IL_085d: Expected O, but got I4
				//IL_0865: Unknown result type (might be due to invalid IL or missing references)
				//IL_086a: Expected O, but got Unknown
				//IL_0880: Expected I, but got O
				//IL_0bf9: Expected I, but got O
				//IL_098c: Expected O, but got I
				//IL_0b7e: Expected O, but got Ref
				//IL_0ba4: Expected I, but got O
				//IL_09c6: Expected O, but got I4
				//IL_0d02: Expected I, but got O
				//IL_09f5: Expected O, but got I
				//IL_03aa: Expected O, but got I
				//IL_03c9: Expected O, but got I
				//IL_0a25: Expected O, but got I
				//IL_0a4f: Expected O, but got I4
				//IL_0416: Expected O, but got I
				//IL_0a7e: Expected O, but got I
				//IL_0457: Expected O, but got I
				//IL_0aae: Expected O, but got I
				//IL_0afa: Expected I, but got O
				//IL_0b20: Expected O, but got I
				//IL_0501: Expected O, but got I4
				//IL_0509: Unknown result type (might be due to invalid IL or missing references)
				//IL_050e: Expected O, but got Unknown
				//IL_0524: Expected I, but got O
				//IL_0b48: Expected O, but got I4
				//IL_0f53: Expected I, but got O
				//IL_0552: Expected O, but got Ref
				//IL_0f85: Expected I, but got O
				_003C_003Ec__DisplayClass2_0 obj = _003C_003E4__this;
				if (_003C_003E1__state <= 2)
				{
					goto IL_01ff;
				}
				AgeGateService ageGateService = new AgeGateService();
				bool flag = ageGateService == null;
				AgeGateService ageGateService2 = ageGateService;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3028]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(ageGateService._key);
					string text = PlayerPrefs.GetString(userSpecificKey, "false");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE98]");
					ReadOnlySpan<char> readOnlySpan = (ReadOnlySpan<char>)0;
					if (text != null)
					{
						object obj2 = default(object);
						bool flag2 = bool.TryParse((ReadOnlySpan<char>)(&obj2), out var result);
						bool flag3 = !flag2;
						readOnlySpan = (ReadOnlySpan<char>)(&obj2);
						if (!flag3)
						{
							readOnlySpan = (ReadOnlySpan<char>)(&obj2);
							object obj3 = 0;
							if (result)
							{
								goto IL_01ff;
							}
						}
					}
					bool flag4 = _003C_003E4__this == null;
					ageGateService2 = (AgeGateService)readOnlySpan;
					if (!flag4)
					{
						string accountTranslation = AccountPage.GetAccountTranslation("age_gate_failed_title");
						string accountTranslation2 = AccountPage.GetAccountTranslation("age_gate_failed_description");
						bool flag5 = _003C_003E4__this == null;
						ageGateService2 = (AgeGateService)(object)"age_gate_failed_description";
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (VampireSurvivors.UI.RegisterPanel+<>c__DisplayClass2_0)+40]");
							Action callback = (Action)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (VampireSurvivors.UI.RegisterPanel+<>c__DisplayClass2_0)+40]");
							if ((nint)0 == 0)
							{
								Action action = delegate
								{
									RegisterPanel registerPanel = _003C_003E4__this._003C_003E4__this;
									AccountPage accountPage3 = ((BaseAccountPagePanel)registerPanel)._accountPage;
									accountPage3.accountPageState.ChangeStateTo(UIState.NOT_LOGGED_IN_HOME);
									accountPage3.ClearAndBuild();
								};
								bool flag6 = _003C_003E4__this == null;
								ageGateService2 = (AgeGateService)(object)action;
								if (flag6)
								{
									throw new NullReferenceException();
								}
								callback = action;
							}
							obj._003C_003E4__this.ShowOkPopup(accountTranslation, accountTranslation2, callback);
							goto IL_0e47;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_01ff:
				nint num = default(nint);
				bool flag7 = num == 0;
				Task task;
				Task task2;
				AccountPage accountPage = default(AccountPage);
				Task task4;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
				if (!flag7)
				{
					nint num2 = num - 1;
					if (flag7)
					{
						_003C_003Eu__1 = (TaskAwaiter<bool>)0;
						_003C_003E1__state = -1;
						task = (Task)_003C_003Eu__1;
						goto IL_0743;
					}
					if (num2 == 1)
					{
						_003C_003Eu__1 = (TaskAwaiter<bool>)0;
						_003C_003E1__state = -1;
						task2 = (Task)_003C_003Eu__1;
						nint num3 = num2;
						goto IL_088e;
					}
					bool flag8 = (object)accountPage == null;
					AccountPage accountPage2 = accountPage;
					if (flag8)
					{
						throw new NullReferenceException();
					}
					RectTransform content = ((BaseUIPage)accountPage)._content;
					bool flag9 = (object)((BaseUIPage)accountPage)._content == null;
					accountPage2 = accountPage;
					if (flag9)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v176 (UnityEngine.RectTransform)+28]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v176 (UnityEngine.RectTransform)+28]");
					bool flag10 = (nint)0 == 0;
					accountPage2 = accountPage;
					if (flag10)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rax_v177+210]");
					_003CemailAddress_003E5__2 = (string)0;
					ageGateService2 = (AgeGateService)(object)accountPage;
					if ((object)accountPage == null)
					{
						accountPage2 = (AccountPage)(object)ageGateService2;
						throw new NullReferenceException();
					}
					string[] array = new string[1];
					bool flag11 = array == null;
					ageGateService2 = (AgeGateService)(object)typeof(string[]);
					if (flag11)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string accountTranslation3 = AccountPage.GetAccountTranslation("register_register_loading", array);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_-B8_v37 (VampireSurvivors.UI.AccountPage)+20]");
					bool flag12 = (nint)0 == 0;
					ageGateService2 = (AgeGateService)(object)"register_register_loading";
					if (flag12)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_-B8_v37 (VampireSurvivors.UI.AccountPage)+20]");
					((BaseAccountPagePanel)0).ShowLoading(accountTranslation3);
					bool flag13 = (object)accountPage == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ stack_-B8_v37 (VampireSurvivors.UI.AccountPage)+20]");
					ageGateService2 = (AgeGateService)0;
					if (flag13)
					{
						throw new NullReferenceException();
					}
					ageGateService2 = (AgeGateService)(object)((BaseUIPage)accountPage)._scrollbar;
					if ((object)((BaseUIPage)accountPage)._scrollbar == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1167 @ rcx_v32 (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.AgeGateService)+28]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1167 @ rcx_v32 (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.AgeGateService)+28]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					string email = _003CemailAddress_003E5__2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1391 @ rax_v185+210]");
					Task<bool> task3 = BackendFacade.RegisterWithEmail(email, (string)0);
					bool flag14 = task3 == null;
					ageGateService2 = (AgeGateService)(object)_003CemailAddress_003E5__2;
					if (flag14)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					bool flag15 = (object)taskAwaiter == null;
					ageGateService2 = (AgeGateService)(object)task3;
					if (flag15)
					{
						throw new NullReferenceException();
					}
					int num4 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag16 = num4 == 0;
					bool flag17 = num4 < 0;
					bool flag18 = !flag17;
					object obj6 = !flag16;
					object obj7 = flag18 & obj6;
					task4 = (Task)taskAwaiter;
					nint num5 = (nint)typeof(Task);
					if (obj7 == null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						ageGateService2 = null;
						return;
					}
				}
				else
				{
					_003C_003Eu__1 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task4 = (Task)_003C_003Eu__1;
					nint num5 = num;
				}
				if (task4 != null)
				{
					int num6 = task4.m_stateFlags & 0x11000000;
					if (num6 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task4);
					}
					Task<bool> task5 = BackendFacade.SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.PASSED_DOB_GATE, "true");
					bool flag19 = task5 == null;
					nint num5 = unchecked((nint)null);
					if (!flag19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
						TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
						bool flag20 = (object)taskAwaiter2 == null;
						nint num2 = (nint)task5;
						if (!flag20)
						{
							int num7 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
							bool flag21 = num7 == 0;
							bool flag22 = num7 < 0;
							bool flag23 = !flag22;
							object obj8 = !flag23;
							object obj9 = obj8 | flag21;
							object obj3 = 0;
							task = (Task)taskAwaiter2;
							num2 = (nint)typeof(Task);
							if (obj9 == null)
							{
								goto IL_0743;
							}
							_003C_003E1__state = 1;
							_003C_003Eu__1 = taskAwaiter2;
							AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
							TaskAwaiter<bool> awaiter2 = default(TaskAwaiter<bool>);
							((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							num2 = unchecked((nint)null);
							return;
						}
						num5 = num2;
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_088e:
				if (task2 != null)
				{
					int num8 = task2.m_stateFlags & 0x11000000;
					if (num8 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
					}
					bool flag24 = (object)accountPage == null;
					nint num3 = 0;
					if (!flag24)
					{
						num3 = (((BaseUIPage)accountPage)._UseScreenSpaceCamera ? 1 : 0);
						if (((BaseUIPage)accountPage)._UseScreenSpaceCamera)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ rcx_v8 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
							bool flag25 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ rcx_v8 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
							num3 = 0;
							if (!flag25)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ rcx_v8 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
								((RememberEmailService)0).RememberEmail(_003CemailAddress_003E5__2);
								bool flag26 = (object)accountPage == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1539 @ rcx_v8 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
								num3 = 0;
								if (!flag26)
								{
									AccountPage accountPage2 = (AccountPage)((BaseUIPage)accountPage)._UseScreenSpaceCamera;
									if (((BaseUIPage)accountPage)._UseScreenSpaceCamera)
									{
										accountPage2 = (AccountPage)(nint)((UnityEngine.Object)accountPage2).m_CachedPtr;
										if (((UnityEngine.Object)accountPage2).m_CachedPtr != (IntPtr)0)
										{
											((AccountPage)(nint)((UnityEngine.Object)accountPage2).m_CachedPtr).SetLoggedInStatus();
											if ((object)accountPage != null)
											{
												accountPage2 = (AccountPage)((BaseUIPage)accountPage)._UseScreenSpaceCamera;
												if (((BaseUIPage)accountPage)._UseScreenSpaceCamera)
												{
													accountPage2 = (AccountPage)(nint)((UnityEngine.Object)accountPage2).m_CachedPtr;
													if (((UnityEngine.Object)accountPage2).m_CachedPtr != (IntPtr)0)
													{
														((AccountPage)(nint)((UnityEngine.Object)accountPage2).m_CachedPtr).GoHome();
														if ((object)accountPage != null)
														{
															string accountTranslation4 = AccountPage.GetAccountTranslation("registration_success_heading");
															string accountTranslation5 = AccountPage.GetAccountTranslation("registration_success_message");
															nint num9 = (nint)typeof(_003C_003Ec);
															Action callback2 = _003C_003Ec._003C_003E9__2_4;
															if (_003C_003Ec._003C_003E9__2_4 == null)
															{
																Action action2 = (_003C_003Ec._003C_003E9__2_4 = delegate
																{
																});
																nint num10 = (nint)typeof(_003C_003Ec);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2831 @ rax_v143 (Il2CppClass<VampireSurvivors.UI.RegisterPanel+<>c>)+B8]");
																num9 = (nint)0 + (nint)8;
																callback2 = action2;
															}
															bool flag27 = !((BaseUIPage)accountPage)._UseScreenSpaceCamera;
															accountPage2 = (AccountPage)num9;
															if (!flag27)
															{
																((BaseAccountPagePanel)((BaseUIPage)accountPage)._UseScreenSpaceCamera).ShowOkPopup(accountTranslation4, accountTranslation5, callback2);
																_003CemailAddress_003E5__2 = null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1877518C0");
																nint num5 = unchecked((nint)null);
																goto IL_0e47;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									num3 = (nint)accountPage2;
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0743:
				if (task != null)
				{
					int num11 = task.m_stateFlags & 0x11000000;
					if (num11 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					}
					Task<bool> task6 = BackendFacade.AddOrUpdateContactEmail(_003CemailAddress_003E5__2);
					bool flag28 = task6 == null;
					nint num2 = (nint)_003CemailAddress_003E5__2;
					if (!flag28)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
						TaskAwaiter<bool> taskAwaiter3 = default(TaskAwaiter<bool>);
						bool flag29 = (object)taskAwaiter3 == null;
						nint num3 = (nint)task6;
						if (!flag29)
						{
							int num12 = ((Task)taskAwaiter3).m_stateFlags & 0x1600000;
							bool flag30 = num12 == 0;
							bool flag31 = num12 < 0;
							bool flag32 = !flag31;
							object obj10 = !flag32;
							object obj11 = obj10 | flag30;
							task2 = (Task)taskAwaiter3;
							num3 = (nint)typeof(Task);
							if (obj11 == null)
							{
								goto IL_088e;
							}
							_003C_003E1__state = 2;
							_003C_003Eu__1 = taskAwaiter3;
							AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
							TaskAwaiter<bool> awaiter3 = default(TaskAwaiter<bool>);
							((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter3, ref this);
							asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
							num3 = unchecked((nint)null);
							return;
						}
						num2 = num3;
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0e47:
				_003C_003E1__state = -2;
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

		public LabeledButtonUI registerButton;

		public bool isEmailValid;

		public RegisterPanel _003C_003E4__this;

		public bool isPasswordValid;

		public LabeledInputUI email;

		public LabeledInputUI password;

		public Action _003C_003E9__3;

		internal void _003CBuild_003Eb__0(string emailValue)
		{
			LabeledButtonUI labeledButtonUI = registerButton;
			if ((object)registerButton != null && ((UnityEngine.Object)labeledButtonUI).m_CachedPtr != (IntPtr)0)
			{
				bool flag = _003C_003E4__this.IsValidEmail(emailValue);
				LabeledButtonUI labeledButtonUI2 = registerButton;
				isEmailValid = flag;
				bool interactable = isPasswordValid & flag;
				labeledButtonUI2._Button.interactable = interactable;
			}
		}

		internal void _003CBuild_003Eb__1(string passwordValue)
		{
			LabeledButtonUI labeledButtonUI = registerButton;
			if ((object)registerButton != null && ((UnityEngine.Object)labeledButtonUI).m_CachedPtr != (IntPtr)0)
			{
				int num = passwordValue._stringLength ^ passwordValue._stringLength;
				int num2 = passwordValue._stringLength & num;
				bool flag = num2 < 0;
				bool flag2 = passwordValue._stringLength < 0;
				bool flag3 = passwordValue._stringLength == 0;
				LabeledButtonUI labeledButtonUI2 = registerButton;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				bool flag6 = (isPasswordValid = flag5 & flag4);
				bool interactable = isEmailValid & flag6;
				labeledButtonUI2._Button.interactable = interactable;
			}
		}

		internal void _003CBuild_003Eb__2()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eb__2_003Ed stateMachine = default(_003C_003CBuild_003Eb__2_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}

		internal void _003CBuild_003Eb__3()
		{
			RegisterPanel registerPanel = _003C_003E4__this;
			AccountPage accountPage = ((BaseAccountPagePanel)registerPanel)._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.NOT_LOGGED_IN_HOME);
			accountPage.ClearAndBuild();
		}
	}

	private readonly RememberEmailService _rememberEmailService;

	public RegisterPanel(AccountPage accountPage)
		: base(accountPage)
	{
		RememberEmailService rememberEmailService = new RememberEmailService();
		_rememberEmailService = rememberEmailService;
	}

	public override void Build()
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals18._003C_003E4__this = this;
		string accountTranslation = AccountPage.GetAccountTranslation("register_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		CS_0024_003C_003E8__locals18.registerButton = null;
		CS_0024_003C_003E8__locals18.isEmailValid = false;
		CS_0024_003C_003E8__locals18.isPasswordValid = false;
		string accountTranslation2 = AccountPage.GetAccountTranslation("common_email_label");
		UnityAction<string> unityAction = delegate(string emailValue)
		{
			LabeledButtonUI registerButton2 = CS_0024_003C_003E8__locals18.registerButton;
			if ((object)CS_0024_003C_003E8__locals18.registerButton != null && ((UnityEngine.Object)registerButton2).m_CachedPtr != (IntPtr)0)
			{
				bool flag = CS_0024_003C_003E8__locals18._003C_003E4__this.IsValidEmail(emailValue);
				LabeledButtonUI registerButton3 = CS_0024_003C_003E8__locals18.registerButton;
				CS_0024_003C_003E8__locals18.isEmailValid = flag;
				bool interactable = CS_0024_003C_003E8__locals18.isPasswordValid & flag;
				registerButton3._Button.interactable = interactable;
			}
		};
		bool textIsLocalizationTerm = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		UnityAction<string> onChange = default(UnityAction<string>);
		LabeledInputUI email = ((ProgrammaticUI)base._accountPage).AddLabeledInput(accountTranslation2, "", "", textIsLocalizationTerm, contentType, onChange);
		CS_0024_003C_003E8__locals18.email = email;
		string accountTranslation3 = AccountPage.GetAccountTranslation("common_password_label");
		UnityAction<string> unityAction2 = delegate(string passwordValue)
		{
			LabeledButtonUI registerButton2 = CS_0024_003C_003E8__locals18.registerButton;
			if ((object)CS_0024_003C_003E8__locals18.registerButton != null && ((UnityEngine.Object)registerButton2).m_CachedPtr != (IntPtr)0)
			{
				int num = passwordValue._stringLength ^ passwordValue._stringLength;
				int num2 = passwordValue._stringLength & num;
				bool flag = num2 < 0;
				bool flag2 = passwordValue._stringLength < 0;
				bool flag3 = passwordValue._stringLength == 0;
				LabeledButtonUI registerButton3 = CS_0024_003C_003E8__locals18.registerButton;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				bool flag6 = (CS_0024_003C_003E8__locals18.isPasswordValid = flag5 & flag4);
				bool interactable = CS_0024_003C_003E8__locals18.isEmailValid & flag6;
				registerButton3._Button.interactable = interactable;
			}
		};
		LabeledInputUI password = ((ProgrammaticUI)base._accountPage).AddLabeledInput(accountTranslation3, "", "", textIsLocalizationTerm, contentType, onChange);
		CS_0024_003C_003E8__locals18.password = password;
		string accountTranslation4 = AccountPage.GetAccountTranslation("registration_verification_required_message");
		base._accountPage.AddLabel(accountTranslation4);
		string accountTranslation5 = AccountPage.GetAccountTranslation("register_register_button");
		Action callback = delegate
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003Ec__DisplayClass2_0._003C_003CBuild_003Eb__2_003Ed stateMachine = default(_003C_003Ec__DisplayClass2_0._003C_003CBuild_003Eb__2_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		};
		LabeledButtonUI registerButton = base._accountPage.AddLabeledButton("", accountTranslation5, callback, textIsLocalizationTerm, (byte)contentType != 0);
		CS_0024_003C_003E8__locals18.registerButton = registerButton;
		AddBackButtonListener();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
	}

	private bool IsValidEmail(string email)
	{
		//IL_0059: Expected I4, but got O
		if (email != null)
		{
			if (email._stringLength > 0)
			{
				MailAddress mailAddress = new MailAddress(email, null, null);
				return true;
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool IsPasswordValid(string password)
	{
		//IL_00b6: Expected I4, but got O
		if (password != null)
		{
			int num = password._stringLength ^ password._stringLength;
			int num2 = password._stringLength & num;
			bool flag = num2 < 0;
			bool flag2 = password._stringLength < 0;
			bool flag3 = password._stringLength == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
