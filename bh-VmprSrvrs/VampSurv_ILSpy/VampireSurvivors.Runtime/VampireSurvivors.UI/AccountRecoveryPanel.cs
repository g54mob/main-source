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
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.UI;

namespace VampireSurvivors.UI;

public class AccountRecoveryPanel : BaseAccountPagePanel
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuild_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass1_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0047: Expected O, but got Ref
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_00a6: Expected O, but got I
				//IL_00c5: Expected O, but got I
				//IL_025b: Expected O, but got I
				//IL_0296: Expected I, but got O
				//IL_00e3: Expected O, but got I
				//IL_02ee: Expected O, but got I
				//IL_0311: Expected O, but got I
				//IL_014d: Expected O, but got I
				//IL_0473: Expected O, but got I4
				//IL_039d: Expected O, but got I
				//IL_04ad: Expected I4, but got I8
				//IL_04b8: Expected O, but got Ref
				//IL_01e3: Expected O, but got I4
				//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f0: Expected O, but got Unknown
				//IL_0206: Expected I, but got O
				//IL_033b: Expected O, but got Ref
				//IL_0361: Expected I, but got O
				object obj = default(object);
				Task task;
				IntPtr intPtr = default(IntPtr);
				nint num;
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				else
				{
					bool flag = intPtr == (IntPtr)0;
					_003C_003CBuild_003Eb__1_003Ed obj2 = (_003C_003CBuild_003Eb__1_003Ed)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
					if (flag)
					{
						throw new NullReferenceException();
					}
					string accountTranslation = AccountPage.GetAccountTranslation("account_recovery_send_recovery_loading");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					bool flag2 = (nint)0 == 0;
					obj2 = (_003C_003CBuild_003Eb__1_003Ed)"account_recovery_send_recovery_loading";
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					((BaseAccountPagePanel)0).ShowLoading(accountTranslation);
					bool flag3 = intPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
					obj2 = (_003C_003CBuild_003Eb__1_003Ed)0;
					if (flag3)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+20]");
					obj2 = (_003C_003CBuild_003Eb__1_003Ed)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+20]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					_003C_003Ec__DisplayClass1_0 obj3 = obj2._003C_003E4__this;
					if (obj2._003C_003E4__this == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v61 (VampireSurvivors.UI.AccountRecoveryPanel+<>c__DisplayClass1_0)+210]");
					Task task2 = BackendFacade.SendPasswordReset((string)0);
					bool flag4 = task2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v61 (VampireSurvivors.UI.AccountRecoveryPanel+<>c__DisplayClass1_0)+210]");
					num = 0;
					if (flag4)
					{
						obj2 = (_003C_003CBuild_003Eb__1_003Ed)num;
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v61 (VampireSurvivors.UI.AccountRecoveryPanel+<>c__DisplayClass1_0)+210]");
					num = 0;
					if (task2 == null)
					{
						throw new NullReferenceException();
					}
					int num2 = task2.m_stateFlags & 0x1600000;
					bool flag5 = num2 == 0;
					bool flag6 = num2 < 0;
					bool flag7 = !flag6;
					object obj4 = !flag7;
					object obj5 = obj4 | flag5;
					task = task2;
					num = (nint)typeof(Task);
					if (obj5 != null)
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
					bool flag8 = num3 == 16777216;
					Task task3 = (Task)num;
					if (!flag8)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
						task3 = task;
					}
					bool flag9 = intPtr == (IntPtr)0;
					num = (nint)task3;
					if (!flag9)
					{
						string accountTranslation2 = AccountPage.GetAccountTranslation("account_recovery_send_recovery_success");
						bool flag10 = intPtr == (IntPtr)0;
						num = intPtr;
						if (!flag10)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
							Action callback = ((BaseAccountPagePanel)0).GoHome;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_20_v2 (Il2CppClass<System.Threading.Tasks.Task>)+18]");
							((BaseAccountPagePanel)0).ShowOkPopupForSuccess(accountTranslation2, callback);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187614240");
							_003C_003CBuild_003Eb__1_003Ed obj2 = (_003C_003CBuild_003Eb__1_003Ed)0;
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

		public LabeledButtonUI button;

		public AccountRecoveryPanel _003C_003E4__this;

		public LabeledInputUI email;

		internal void _003CBuild_003Eb__0(string value)
		{
			LabeledButtonUI labeledButtonUI = button;
			if ((object)button != null && ((UnityEngine.Object)labeledButtonUI).m_CachedPtr != (IntPtr)0)
			{
				bool flag = _003C_003E4__this.IsValidEmail(value);
				LabeledButtonUI labeledButtonUI2 = button;
				Selectable selectable;
				bool interactable;
				if (!flag)
				{
					selectable = labeledButtonUI2._Button;
					interactable = false;
				}
				else
				{
					selectable = labeledButtonUI2._Button;
					interactable = true;
				}
				selectable.interactable = interactable;
			}
		}

		internal void _003CBuild_003Eb__1()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuild_003Eb__1_003Ed stateMachine = default(_003C_003CBuild_003Eb__1_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
	}

	public AccountRecoveryPanel(AccountPage accountPage)
		: base(accountPage)
	{
	}

	public override void Build()
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		string accountTranslation = AccountPage.GetAccountTranslation("account_recovery_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		CS_0024_003C_003E8__locals8.button = null;
		string accountTranslation2 = AccountPage.GetAccountTranslation("common_email_label");
		UnityAction<string> unityAction = delegate(string value)
		{
			LabeledButtonUI button2 = CS_0024_003C_003E8__locals8.button;
			if ((object)CS_0024_003C_003E8__locals8.button != null && ((UnityEngine.Object)button2).m_CachedPtr != (IntPtr)0)
			{
				bool flag = CS_0024_003C_003E8__locals8._003C_003E4__this.IsValidEmail(value);
				LabeledButtonUI button3 = CS_0024_003C_003E8__locals8.button;
				Selectable button4;
				bool interactable;
				if (!flag)
				{
					button4 = button3._Button;
					interactable = false;
				}
				else
				{
					button4 = button3._Button;
					interactable = true;
				}
				button4.interactable = interactable;
			}
		};
		bool textIsLocalizationTerm = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		UnityAction<string> onChange = default(UnityAction<string>);
		LabeledInputUI email = ((ProgrammaticUI)base._accountPage).AddLabeledInput(accountTranslation2, "", "", textIsLocalizationTerm, contentType, onChange);
		CS_0024_003C_003E8__locals8.email = email;
		string accountTranslation3 = AccountPage.GetAccountTranslation("account_recovery_send_recovery_label");
		string accountTranslation4 = AccountPage.GetAccountTranslation("account_recovery_send_recovery_button");
		Action callback = delegate
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003Ec__DisplayClass1_0._003C_003CBuild_003Eb__1_003Ed stateMachine = default(_003C_003Ec__DisplayClass1_0._003C_003CBuild_003Eb__1_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		};
		LabeledButtonUI button = base._accountPage.AddLabeledButton(accountTranslation3, accountTranslation4, callback, textIsLocalizationTerm, (byte)contentType != 0);
		CS_0024_003C_003E8__locals8.button = button;
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
}
