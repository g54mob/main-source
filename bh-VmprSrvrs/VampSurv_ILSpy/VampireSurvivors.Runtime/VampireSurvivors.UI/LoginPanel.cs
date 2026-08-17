using System;
using System.Collections;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class LoginPanel : BaseAccountPagePanel
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__2_8;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CBuild_003Eb__2_8()
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

			private _003C_003Ec__DisplayClass2_3 _003C_003E8__1;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_007a: Expected O, but got I4
				//IL_0089: Expected I4, but got I8
				//IL_01e6: Expected O, but got I4
				//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f3: Expected O, but got Unknown
				//IL_03f9: Expected I4, but got I8
				//IL_0404: Expected O, but got Ref
				//IL_0382: Expected O, but got Ref
				_003C_003Ec__DisplayClass2_0 obj = _003C_003E4__this;
				if (_003C_003E1__state != 0)
				{
					string[] args = new string[1];
					LabeledInputUI email = obj.email;
					TMP_InputField input = email._Input;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string accountTranslation = AccountPage.GetAccountTranslation("login_login_loading", args);
					obj._003C_003E4__this.ShowLoading(accountTranslation);
				}
				Task task;
				if (_003C_003E1__state == 0)
				{
					_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
				}
				else
				{
					_003C_003Ec__DisplayClass2_3 obj2 = new _003C_003Ec__DisplayClass2_3();
					_003C_003E8__1 = obj2;
					if (obj == null)
					{
						throw new NullReferenceException();
					}
					LoginPanel loginPanel = obj._003C_003E4__this;
					LabeledInputUI email2 = obj.email;
					TMP_InputField input2 = email2._Input;
					loginPanel._rememberEmailService.RememberEmail(input2.m_Text);
					LabeledInputUI email3 = obj.email;
					TMP_InputField input3 = email3._Input;
					LabeledInputUI password = obj.password;
					TMP_InputField input4 = password._Input;
					Task<ILoginResult> task2 = BackendFacade.LoginWithEmail(input3.m_Text, input4.m_Text);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<ILoginResult> taskAwaiter = default(TaskAwaiter<ILoginResult>);
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag = num == 0;
					bool flag2 = num < 0;
					bool flag3 = !flag2;
					object obj3 = !flag3;
					object obj4 = obj3 | flag;
					task = (Task)taskAwaiter;
					if (obj4 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				int num2 = task.m_stateFlags & 0x11000000;
				if (num2 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				LoginPanel loginPanel2 = obj._003C_003E4__this;
				((BaseAccountPagePanel)loginPanel2)._accountPage.SetLoggedInStatus();
				LoginPanel loginPanel3 = obj._003C_003E4__this;
				((BaseAccountPagePanel)loginPanel3)._accountPage.GoHome();
				_003C_003Ec__DisplayClass2_3 obj5 = _003C_003E8__1;
				RememberMeService rememberMeService = new RememberMeService();
				obj5.rememberMeService = rememberMeService;
				string accountTranslation2 = AccountPage.GetAccountTranslation("login_remember_me_title");
				string accountTranslation3 = AccountPage.GetAccountTranslation("login_remember_me_label");
				Action yesCallback = delegate
				{
					SynchronizationContext.CurrentNoFlow?.OperationStarted();
					AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = default(AsyncVoidMethodBuilder);
					_003C_003Ec__DisplayClass2_3._003C_003CBuild_003Eb__6_003Ed stateMachine = default(_003C_003Ec__DisplayClass2_3._003C_003CBuild_003Eb__6_003Ed);
					asyncVoidMethodBuilder3.Start(ref stateMachine);
				};
				Action action = delegate
				{
					RememberMeService rememberMeService2 = _003C_003E8__1.rememberMeService;
					string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(rememberMeService2.key);
					PlayerPrefs.DeleteKey(userSpecificKey);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					/*Error: End of method reached without returning.*/;
				};
				object noCallback = default(object);
				IEnumerator routine = ((BaseAccountPagePanel)obj._003C_003E4__this).ShowYesNoRoutine(accountTranslation2, accountTranslation3, yesCallback, (Action)noCallback);
				Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
				_003C_003E8__1 = null;
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

		public LoginPanel _003C_003E4__this;

		public LabeledButtonUI loginButton;

		public bool isEmailValid;

		public bool isPasswordValid;

		public LabeledInputUI email;

		public LabeledInputUI password;

		internal void _003CBuild_003Eb__0(string emailValue)
		{
			LabeledButtonUI labeledButtonUI = loginButton;
			if ((object)loginButton != null && ((UnityEngine.Object)labeledButtonUI).m_CachedPtr != (IntPtr)0)
			{
				bool flag = _003C_003E4__this.IsValidEmail(emailValue);
				LabeledButtonUI labeledButtonUI2 = loginButton;
				isEmailValid = flag;
				bool interactable = isPasswordValid & flag;
				labeledButtonUI2._Button.interactable = interactable;
			}
		}

		internal void _003CBuild_003Eb__1(string passwordValue)
		{
			LabeledButtonUI labeledButtonUI = loginButton;
			if ((object)loginButton != null && ((UnityEngine.Object)labeledButtonUI).m_CachedPtr != (IntPtr)0)
			{
				int num = passwordValue._stringLength ^ passwordValue._stringLength;
				int num2 = passwordValue._stringLength & num;
				bool flag = num2 < 0;
				bool flag2 = passwordValue._stringLength < 0;
				bool flag3 = passwordValue._stringLength == 0;
				LabeledButtonUI labeledButtonUI2 = loginButton;
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
	}

	private sealed class _003C_003Ec__DisplayClass2_1
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eb__3_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass2_1 _003C_003E4__this;

			private _003C_003Ec__DisplayClass2_2 _003C_003E8__1;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_0097: Expected I, but got O
				//IL_00e4: Expected I, but got O
				//IL_0304: Expected O, but got I
				//IL_0312: Expected I, but got O
				//IL_0322: Expected O, but got I
				//IL_0426: Expected I, but got O
				//IL_039e: Expected I, but got O
				//IL_010f: Expected I, but got O
				//IL_0926: Expected I, but got O
				//IL_035e: Expected O, but got I
				//IL_0458: Expected O, but got I
				//IL_015e: Expected I, but got O
				//IL_0181: Expected O, but got I
				//IL_04c3: Expected O, but got I
				//IL_01a3: Expected I, but got O
				//IL_04fd: Expected I, but got O
				//IL_0943: Expected I4, but got I8
				//IL_094e: Expected O, but got Ref
				//IL_01d2: Expected I, but got O
				//IL_052f: Expected O, but got I
				//IL_0230: Expected O, but got I4
				//IL_0238: Unknown result type (might be due to invalid IL or missing references)
				//IL_023d: Expected O, but got Unknown
				//IL_0253: Expected I, but got O
				//IL_059a: Expected O, but got I
				//IL_0730: Expected O, but got Ref
				//IL_05cc: Expected I, but got O
				//IL_0756: Expected I, but got O
				//IL_079e: Expected I, but got O
				//IL_06df: Expected O, but got I
				//IL_09a6: Expected I, but got O
				object obj = default(object);
				Task task;
				_003C_003Ec__DisplayClass2_1 obj4 = default(_003C_003Ec__DisplayClass2_1);
				nint num;
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				else
				{
					_003C_003Ec__DisplayClass2_2 obj2 = new _003C_003Ec__DisplayClass2_2();
					_003C_003E8__1 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					nint num2 = 0;
					_003C_003Ec__DisplayClass2_2 obj3 = _003C_003E8__1;
					if (_003C_003E8__1 == null)
					{
						throw new NullReferenceException();
					}
					obj3.CS_0024_003C_003E8__locals2 = obj4;
					if (obj4 == null)
					{
						throw new NullReferenceException();
					}
					nint num3 = (nint)obj4.CS_0024_003C_003E8__locals1;
					if (obj4.CS_0024_003C_003E8__locals1 == null)
					{
						num2 = num3;
						throw new NullReferenceException();
					}
					string[] array = new string[1];
					bool flag = obj4 == null;
					num3 = (nint)typeof(string[]);
					if (flag)
					{
						throw new NullReferenceException();
					}
					bool flag2 = array == null;
					num3 = (nint)typeof(string[]);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string accountTranslation = AccountPage.GetAccountTranslation("login_login_loading", array);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rcx_v10 (Il2CppClass<System.String[]>)+10]");
					bool flag3 = (nint)0 == 0;
					num = unchecked((nint)"login_login_loading");
					if (flag3)
					{
						num3 = num;
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rcx_v10 (Il2CppClass<System.String[]>)+10]");
					((BaseAccountPagePanel)0).ShowLoading(accountTranslation);
					Task<ILoginResult> task2 = BackendFacade.Login();
					bool flag4 = task2 == null;
					num = unchecked((nint)null);
					if (flag4)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<ILoginResult> taskAwaiter = default(TaskAwaiter<ILoginResult>);
					bool flag5 = (object)taskAwaiter == null;
					num = (nint)task2;
					if (flag5)
					{
						throw new NullReferenceException();
					}
					int num4 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag6 = num4 == 0;
					bool flag7 = num4 < 0;
					bool flag8 = !flag7;
					object obj5 = !flag8;
					object obj6 = obj5 | flag6;
					task = (Task)taskAwaiter;
					num = (nint)typeof(Task);
					if (obj6 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
						asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						num = unchecked((nint)null);
						return;
					}
				}
				nint num7;
				if (task != null)
				{
					int num5 = task.m_stateFlags & 0x11000000;
					if (num5 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v13 (System.Threading.Tasks.Task)+50]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v13 (System.Threading.Tasks.Task)+50]");
					bool flag9 = (nint)0 == 0;
					num7 = 0;
					if (flag9)
					{
						goto IL_03f4;
					}
					object obj7 = num6;
					nint num8 = (nint)typeof(PlayFabLoginAborted);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r8_v43 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginAborted>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ r9_v31+130]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r8_v43 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginAborted>)+130]");
					if (num9 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ r9_v31+C8]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rax_v122+FFFFFFF8+v572 @ rax_v114*8]");
						if (0 == (nint)typeof(PlayFabLoginAborted))
						{
							num7 = 1;
							goto IL_0912;
						}
					}
					num7 = unchecked((nint)null);
					goto IL_0912;
				}
				throw new NullReferenceException();
				IL_0912:
				bool flag10 = num7 == 0;
				nint num10 = unchecked((nint)null);
				if (!flag10)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v13 (System.Threading.Tasks.Task)+50]");
					num10 = 0;
				}
				if (num10 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rax_v117 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18761BD70");
						goto IL_0934;
					}
				}
				goto IL_03f4;
				IL_03f4:
				bool flag11 = obj4 == null;
				num = num7;
				if (!flag11)
				{
					num = (nint)obj4.CS_0024_003C_003E8__locals1;
					if (obj4.CS_0024_003C_003E8__locals1 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rcx_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rcx_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v80+10]");
							bool flag12 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v80+10]");
							num = 0;
							if (!flag12)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v80+10]");
								((AccountPage)0).SetLoggedInStatus();
								bool flag13 = obj4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v80+10]");
								num = 0;
								if (!flag13)
								{
									num = (nint)obj4.CS_0024_003C_003E8__locals1;
									if (obj4.CS_0024_003C_003E8__locals1 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rcx_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ rcx_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v83+10]");
											bool flag14 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v83+10]");
											num = 0;
											if (!flag14)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ rax_v83+10]");
												((AccountPage)0).GoHome();
												_003C_003Ec__DisplayClass2_2 obj12 = _003C_003E8__1;
												RememberMeService rememberMeService = new RememberMeService();
												bool flag15 = _003C_003E8__1 == null;
												num = (nint)rememberMeService;
												if (!flag15)
												{
													obj12.rememberMeService = rememberMeService;
													MonoBehaviour monoBehaviour = (MonoBehaviour)(object)rememberMeService;
													if (obj4 != null)
													{
														monoBehaviour = (MonoBehaviour)(object)obj4.CS_0024_003C_003E8__locals1;
														if (obj4.CS_0024_003C_003E8__locals1 != null)
														{
															string accountTranslation2 = AccountPage.GetAccountTranslation("login_remember_me_title");
															string accountTranslation3 = AccountPage.GetAccountTranslation("login_remember_me_label");
															Action yesCallback = delegate
															{
																SynchronizationContext.CurrentNoFlow?.OperationStarted();
																AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = default(AsyncVoidMethodBuilder);
																_003C_003Ec__DisplayClass2_2._003C_003CBuild_003Eb__4_003Ed stateMachine = default(_003C_003Ec__DisplayClass2_2._003C_003CBuild_003Eb__4_003Ed);
																asyncVoidMethodBuilder4.Start(ref stateMachine);
															};
															Action action = delegate
															{
																RememberMeService rememberMeService2 = _003C_003E8__1.rememberMeService;
																string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(rememberMeService2.key);
																PlayerPrefs.DeleteKey(userSpecificKey);
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
																/*Error: End of method reached without returning.*/;
															};
															bool flag16 = ((UnityEngine.Object)(object)action).m_CachedPtr == (IntPtr)0;
															monoBehaviour = (MonoBehaviour)(object)action;
															if (!flag16)
															{
																object noCallback = default(object);
																IEnumerator routine = ((BaseAccountPagePanel)(nint)((UnityEngine.Object)(object)action).m_CachedPtr).ShowYesNoRoutine(accountTranslation2, accountTranslation3, yesCallback, (Action)noCallback);
																monoBehaviour = CoroutineRunner.Instance;
																if ((object)CoroutineRunner.Instance != null)
																{
																	Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
																	_003C_003E8__1 = null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18761BD70");
																	nint num2 = unchecked((nint)null);
																	goto IL_0934;
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													num = (nint)monoBehaviour;
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
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0934:
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

		public string platformName;

		public _003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals1;

		internal void _003CBuild_003Eb__3()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eb__3_003Ed stateMachine = default(_003C_003CBuild_003Eb__3_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_2
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eb__4_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass2_2 _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0047: Expected O, but got Ref
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_0065: Expected O, but got I
				//IL_009a: Expected O, but got I
				//IL_0108: Expected O, but got I
				//IL_0322: Expected O, but got I
				//IL_047d: Expected O, but got I4
				//IL_04db: Expected I4, but got I8
				//IL_04e6: Expected O, but got Ref
				//IL_018b: Expected I, but got O
				//IL_03ae: Expected O, but got I
				//IL_01ae: Expected O, but got I
				//IL_01d0: Expected I, but got O
				//IL_01ff: Expected I, but got O
				//IL_025d: Expected O, but got I4
				//IL_0265: Unknown result type (might be due to invalid IL or missing references)
				//IL_026a: Expected O, but got Unknown
				//IL_0280: Expected I, but got O
				//IL_034c: Expected O, but got Ref
				//IL_0372: Expected I, but got O
				object obj = default(object);
				Task task;
				object obj2 = default(object);
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				else
				{
					bool flag = obj2 == null;
					_003C_003CBuild_003Eb__4_003Ed obj3 = (_003C_003CBuild_003Eb__4_003Ed)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
					if (flag)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_20_v2+18]");
					obj3 = (_003C_003CBuild_003Eb__4_003Ed)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_20_v2+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v2 (VampireSurvivors.UI.LoginPanel+<>c__DisplayClass2_2+<<Build>b__4>d)+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rcx_v2 (VampireSurvivors.UI.LoginPanel+<>c__DisplayClass2_2+<<Build>b__4>d)+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					string[] array = new string[1];
					bool flag2 = obj2 == null;
					obj3 = (_003C_003CBuild_003Eb__4_003Ed)typeof(string[]);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_20_v2+18]");
					obj3 = (_003C_003CBuild_003Eb__4_003Ed)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_20_v2+18]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					if (array == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string accountTranslation = AccountPage.GetAccountTranslation("login_login_loading", array);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v58+10]");
					bool flag3 = (nint)0 == 0;
					nint num = unchecked((nint)"login_login_loading");
					if (flag3)
					{
						obj3 = (_003C_003CBuild_003Eb__4_003Ed)num;
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v58+10]");
					((BaseAccountPagePanel)0).ShowLoading(accountTranslation);
					Task<bool> task2 = BackendFacade.LinkDeviceId();
					bool flag4 = task2 == null;
					num = unchecked((nint)null);
					if (flag4)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					bool flag5 = (object)taskAwaiter == null;
					num = (nint)task2;
					if (flag5)
					{
						throw new NullReferenceException();
					}
					int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag6 = num2 == 0;
					bool flag7 = num2 < 0;
					bool flag8 = !flag7;
					object obj5 = !flag8;
					object obj6 = obj5 | flag6;
					task = (Task)taskAwaiter;
					num = (nint)typeof(Task);
					if (obj6 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
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
					bool flag9 = obj2 == null;
					nint num = 0;
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_20_v2+10]");
						((RememberMeService)0).StayLoggedIn();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18761C3E0");
						_003C_003CBuild_003Eb__4_003Ed obj3 = (_003C_003CBuild_003Eb__4_003Ed)0;
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

		public RememberMeService rememberMeService;

		public _003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals2;

		internal void _003CBuild_003Eb__4()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eb__4_003Ed stateMachine = default(_003C_003CBuild_003Eb__4_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}

		internal void _003CBuild_003Eb__5()
		{
			RememberMeService rememberMeService = this.rememberMeService;
			string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(rememberMeService.key);
			PlayerPrefs.DeleteKey(userSpecificKey);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_3
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eb__6_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass2_3 _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_0123: Expected I4, but got I8
				//IL_012e: Expected O, but got Ref
				//IL_00a0: Expected O, but got I4
				//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ad: Expected O, but got Unknown
				//IL_0184: Expected O, but got Ref
				_003C_003Ec__DisplayClass2_3 obj = _003C_003E4__this;
				Task task;
				if (_003C_003E1__state == 0)
				{
					_003C_003Eu__1 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
				}
				else
				{
					Task<bool> task2 = BackendFacade.LinkDeviceId();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag = num == 0;
					bool flag2 = num < 0;
					bool flag3 = !flag2;
					object obj2 = !flag3;
					object obj3 = obj2 | flag;
					task = (Task)taskAwaiter;
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				int num2 = task.m_stateFlags & 0x11000000;
				if (num2 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				obj.rememberMeService.StayLoggedIn();
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

		public RememberMeService rememberMeService;

		internal void _003CBuild_003Eb__6()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eb__6_003Ed stateMachine = default(_003C_003CBuild_003Eb__6_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}

		internal void _003CBuild_003Eb__7()
		{
			RememberMeService rememberMeService = this.rememberMeService;
			string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(rememberMeService.key);
			PlayerPrefs.DeleteKey(userSpecificKey);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private readonly RememberEmailService _rememberEmailService;

	public LoginPanel(AccountPage accountPage)
		: base(accountPage)
	{
		RememberEmailService rememberEmailService = new RememberEmailService();
		_rememberEmailService = rememberEmailService;
	}

	public unsafe override void Build()
	{
		//IL_005c: Expected I, but got O
		//IL_010a: Expected O, but got I
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I
		//IL_045e: Expected O, but got Ref
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals22._003C_003E4__this = this;
		string accountTranslation = AccountPage.GetAccountTranslation("login_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		PlatformType platformType = BackendFacade.GetPlatformType();
		nint num = (nint)typeof(PlatformType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rbx_v2 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+28]");
		object o;
		if ((nint)0 >= (nint)0)
		{
			o = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rbx_v2 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+60]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rbx_v2 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+135]");
				object obj = (nint)0 & (nint)8;
				if (obj != null)
				{
					o = null;
					goto IL_0451;
				}
			}
			object obj2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rbx_v2 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+F8]");
			object obj3 = -16;
			object obj4 = obj2 + 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			o = obj2;
		}
		goto IL_0451;
		IL_0451:
		IntPtr intPtr = default(IntPtr);
		bool textIsLocalizationTerm = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		if (!ValueType.DefaultEquals((object)(&intPtr), o))
		{
			_003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass2_1();
			CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals22;
			string platformAsString = BackendFacade.GetPlatformAsString();
			CS_0024_003C_003E8__locals5.platformName = platformAsString;
			string[] args = new string[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string accountTranslation2 = AccountPage.GetAccountTranslation("login_platform_login_label", args);
			string[] args2 = new string[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string accountTranslation3 = AccountPage.GetAccountTranslation("login_platform_login_button", args2);
			Action callback = delegate
			{
				SynchronizationContext.CurrentNoFlow?.OperationStarted();
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
				_003C_003Ec__DisplayClass2_1._003C_003CBuild_003Eb__3_003Ed stateMachine = default(_003C_003Ec__DisplayClass2_1._003C_003CBuild_003Eb__3_003Ed);
				asyncVoidMethodBuilder.Start(ref stateMachine);
			};
			LabeledButtonUI labeledButtonUI = base._accountPage.AddLabeledButton(accountTranslation2, accountTranslation3, callback, textIsLocalizationTerm, (byte)contentType != 0);
			string accountTranslation4 = AccountPage.GetAccountTranslation("login_seperator");
			base._accountPage.AddLabel(accountTranslation4);
		}
		CS_0024_003C_003E8__locals22.loginButton = null;
		CS_0024_003C_003E8__locals22.isEmailValid = false;
		RememberEmailService rememberEmailService = _rememberEmailService;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3033]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(rememberEmailService.key);
		string text = PlayerPrefs.GetString(userSpecificKey, "");
		string message = "Rehydrating remembered email address: " + text;
		Debug.Log(message);
		if (text != null && text._stringLength > 0)
		{
			bool isEmailValid = IsValidEmail(text);
			CS_0024_003C_003E8__locals22.isEmailValid = isEmailValid;
		}
		string accountTranslation5 = AccountPage.GetAccountTranslation("common_email_label");
		UnityAction<string> unityAction = delegate(string emailValue)
		{
			LabeledButtonUI loginButton2 = CS_0024_003C_003E8__locals22.loginButton;
			if ((object)CS_0024_003C_003E8__locals22.loginButton != null && ((UnityEngine.Object)loginButton2).m_CachedPtr != (IntPtr)0)
			{
				bool flag = CS_0024_003C_003E8__locals22._003C_003E4__this.IsValidEmail(emailValue);
				LabeledButtonUI loginButton3 = CS_0024_003C_003E8__locals22.loginButton;
				CS_0024_003C_003E8__locals22.isEmailValid = flag;
				bool interactable = CS_0024_003C_003E8__locals22.isPasswordValid & flag;
				loginButton3._Button.interactable = interactable;
			}
		};
		UnityAction<string> onChange = default(UnityAction<string>);
		LabeledInputUI email = ((ProgrammaticUI)base._accountPage).AddLabeledInput(accountTranslation5, text, "", textIsLocalizationTerm, contentType, onChange);
		CS_0024_003C_003E8__locals22.email = email;
		string accountTranslation6 = AccountPage.GetAccountTranslation("common_password_label");
		UnityAction<string> unityAction2 = delegate(string passwordValue)
		{
			LabeledButtonUI loginButton2 = CS_0024_003C_003E8__locals22.loginButton;
			if ((object)CS_0024_003C_003E8__locals22.loginButton != null && ((UnityEngine.Object)loginButton2).m_CachedPtr != (IntPtr)0)
			{
				int num2 = passwordValue._stringLength ^ passwordValue._stringLength;
				int num3 = passwordValue._stringLength & num2;
				bool flag = num3 < 0;
				bool flag2 = passwordValue._stringLength < 0;
				bool flag3 = passwordValue._stringLength == 0;
				LabeledButtonUI loginButton3 = CS_0024_003C_003E8__locals22.loginButton;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				bool flag6 = (CS_0024_003C_003E8__locals22.isPasswordValid = flag5 & flag4);
				bool interactable = CS_0024_003C_003E8__locals22.isEmailValid & flag6;
				loginButton3._Button.interactable = interactable;
			}
		};
		LabeledInputUI password = ((ProgrammaticUI)base._accountPage).AddLabeledInput(accountTranslation6, "", "", textIsLocalizationTerm, contentType, onChange);
		CS_0024_003C_003E8__locals22.password = password;
		string accountTranslation7 = AccountPage.GetAccountTranslation("login_email_login_button");
		Action callback2 = delegate
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003Ec__DisplayClass2_0._003C_003CBuild_003Eb__2_003Ed stateMachine = default(_003C_003Ec__DisplayClass2_0._003C_003CBuild_003Eb__2_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		};
		LabeledButtonUI loginButton = base._accountPage.AddLabeledButton("", accountTranslation7, callback2, textIsLocalizationTerm, (byte)contentType != 0);
		CS_0024_003C_003E8__locals22.loginButton = loginButton;
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
