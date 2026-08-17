using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public abstract class BaseAccountPagePanel
{
	private sealed class _003CAccountErrorPopupRoutine_003Ed__13(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseAccountPagePanel _003C_003E4__this;

		public string title;

		public string description;

		public string helpText;

		public Action callback;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00fa: Expected I4, but got I8
			//IL_018a: Expected I4, but got O
			BaseAccountPagePanel baseAccountPagePanel = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null && (object)baseAccountPagePanel._accountPage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
					if ((nint)0 == _003C_003E1__state)
					{
						_ = 1;
					}
					PopupManager.ClosePopup("account-loading");
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_017c;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this == null || (object)baseAccountPagePanel._accountPage == null)
				{
					goto IL_017c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6F]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Action action = default(Action);
				bool titleIsLocalizationTerm = default(bool);
				bool descriptionIsLocalizationTerm = default(bool);
				bool helpTextIsLocalizationTerm = default(bool);
				PopupManager.CreateAccountErrorPopup("programmatic-ui-account-error-popup", title, description, helpText, action, titleIsLocalizationTerm, descriptionIsLocalizationTerm, helpTextIsLocalizationTerm);
			}
			return false;
			IL_017c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CLogout_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public BaseAccountPagePanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0182: Expected I4, but got I8
			//IL_018d: Expected O, but got Ref
			//IL_009a: Expected O, but got I4
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_012f: Expected O, but got Ref
			BaseAccountPagePanel baseAccountPagePanel = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task task2 = baseAccountPagePanel._accountPage.DoLogout();
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

	private sealed class _003CShowLoadingRoutine_003Ed__6(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseAccountPagePanel _003C_003E4__this;

		public string message;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00f2: Expected I4, but got I8
			//IL_0160: Expected I4, but got O
			BaseAccountPagePanel baseAccountPagePanel = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null && (object)baseAccountPagePanel._accountPage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
					if ((nint)0 == _003C_003E1__state)
					{
						_ = 1;
					}
					PopupManager.ClosePopup("account-loading");
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_0152;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this == null || (object)baseAccountPagePanel._accountPage == null)
				{
					goto IL_0152;
				}
				baseAccountPagePanel._accountPage.ShowLoading(message);
			}
			return false;
			IL_0152:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CShowOKRoutine_003Ed__8(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseAccountPagePanel _003C_003E4__this;

		public string title;

		public string description;

		public Action callback;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00f2: Expected I4, but got I8
			//IL_016c: Expected I4, but got O
			BaseAccountPagePanel baseAccountPagePanel = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null && (object)baseAccountPagePanel._accountPage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
					if ((nint)0 == _003C_003E1__state)
					{
						_ = 1;
					}
					PopupManager.ClosePopup("account-loading");
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_015e;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this == null || (object)baseAccountPagePanel._accountPage == null)
				{
					goto IL_015e;
				}
				baseAccountPagePanel._accountPage.ShowOkPopup(title, description, callback);
			}
			return false;
			IL_015e:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CShowYesNoRoutine_003Ed__10(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BaseAccountPagePanel _003C_003E4__this;

		public string title;

		public string description;

		public Action yesCallback;

		public Action noCallback;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00fa: Expected I4, but got I8
			//IL_018a: Expected I4, but got O
			//IL_01fb: Expected I4, but got O
			//IL_01fb: Expected I4, but got O
			//IL_01fb: Expected I4, but got O
			BaseAccountPagePanel baseAccountPagePanel = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this != null && (object)baseAccountPagePanel._accountPage != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
					if ((nint)0 == _003C_003E1__state)
					{
						_ = 1;
					}
					PopupManager.ClosePopup("account-loading");
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_017c;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if (_003C_003E4__this == null || (object)baseAccountPagePanel._accountPage == null)
				{
					goto IL_017c;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E70]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				string translation = AccountPage.GetTranslation("options_yes");
				string translation2 = AccountPage.GetTranslation("options_no");
				string button2Text = default(string);
				Action button1Callback = default(Action);
				Action button2Callback = default(Action);
				bool titleIsLocalizationTerm = default(bool);
				PopupManager.CreateTwoButtonPopup("programmatic-ui-two-btn-popup", title, description, translation, button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)translation2 != 0, (byte)(int)yesCallback != 0, (byte)(int)noCallback != 0);
			}
			return false;
			IL_017c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private AccountPage _accountPage;

	protected BaseAccountPagePanel(AccountPage accountPage)
	{
		_accountPage = accountPage;
		_accountPage.DisableSpecialButton();
	}

	public abstract void Build();

	protected void HideLoading()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("account-loading");
	}

	protected void ShowLoading(string message)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("account-loading");
		_accountPage.ShowLoading(message);
	}

	protected void ShowLoadingImmediate(string message)
	{
		_accountPage.ShowLoading(message);
	}

	private IEnumerator ShowLoadingRoutine(string message)
	{
		_003CShowLoadingRoutine_003Ed__6 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.message = message;
		return obj;
	}

	protected void ShowOkPopup(string title, string description, Action callback)
	{
		IEnumerator routine = ShowOKRoutine(title, description, callback);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	private IEnumerator ShowOKRoutine(string title, string description, Action callback)
	{
		_003CShowOKRoutine_003Ed__8 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.title = title;
		obj.description = description;
		obj.callback = callback;
		return obj;
	}

	protected void ShowYesNoPopup(string title, string description, Action yesCallback, Action noCallback)
	{
		Action noCallback2 = default(Action);
		IEnumerator routine = ShowYesNoRoutine(title, description, yesCallback, noCallback2);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	private IEnumerator ShowYesNoRoutine(string title, string description, Action yesCallback, Action noCallback)
	{
		_003CShowYesNoRoutine_003Ed__10 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.title = title;
		obj.description = description;
		obj.yesCallback = yesCallback;
		Action noCallback2 = default(Action);
		obj.noCallback = noCallback2;
		return obj;
	}

	protected void ShowOkPopupForSuccess(string description, Action callback)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5D96]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string accountTranslation = AccountPage.GetAccountTranslation("popup_success_title");
		IEnumerator routine = ShowOKRoutine(accountTranslation, description, callback);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	protected void ShowAccountErrorPopup(string title, string description, string helpText, Action callback)
	{
		Action callback2 = default(Action);
		IEnumerator routine = AccountErrorPopupRoutine(title, description, helpText, callback2);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	private IEnumerator AccountErrorPopupRoutine(string title, string description, string helpText, Action callback)
	{
		_003CAccountErrorPopupRoutine_003Ed__13 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.title = title;
		obj.description = description;
		obj.helpText = helpText;
		Action callback2 = default(Action);
		obj.callback = callback2;
		return obj;
	}

	protected unsafe void ShowOkPopupForError(string description, Exception e, Action callback)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_010f: Expected O, but got Ref
		nint num = (nint)typeof(PlayFabApiException);
		nint num2 = (nint)e;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v2 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions.PlayFabApiException>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v2 (Il2CppClass<System.Exception>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v2 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions.PlayFabApiException>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v2 (Il2CppClass<System.Exception>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v23+FFFFFFF8+v58 @ rax_v4*8]");
			if (0 == (nint)typeof(PlayFabApiException))
			{
				obj3 = 1;
				goto IL_016b;
			}
		}
		obj3 = 0;
		goto IL_016b;
		IL_016b:
		bool flag = obj3 == null;
		Exception ex = null;
		if (!flag)
		{
			ex = e;
		}
		string description2;
		if (ex == null)
		{
			description2 = e.Message;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			string errorMessage = ((PlayFabApiException)ex).GetErrorMessage();
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(description, arg, errorMessage);
			object obj4 = default(object);
			description2 = string.FormatHelper((IFormatProvider)null, "{0}\n[{1}] {2}", (System.ParamsArray)(&obj4));
		}
		string accountTranslation = AccountPage.GetAccountTranslation("popup_error_title");
		string accountTranslation2 = AccountPage.GetAccountTranslation("popup_error_help_text");
		Action callback2 = default(Action);
		IEnumerator routine = AccountErrorPopupRoutine(accountTranslation, description2, accountTranslation2, callback2);
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(routine);
	}

	protected bool GetFlag(string key)
	{
		//IL_0069: Expected O, but got I
		//IL_00f1: Expected I4, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		AccountPage accountPage = _accountPage;
		AccountPageState accountPageState = accountPage.accountPageState;
		Dictionary<string, bool> flags = accountPageState.flags;
		int num = accountPageState.flags.FindEntry(key);
		if (num >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v5 (System.Collections.Generic.Dictionary`2<System.String, System.Boolean>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v6+18]");
			if ((nint)num < (nint)0)
			{
				object obj2 = num + 2;
				object obj3 = obj2 * 2;
				object obj4 = obj2 + obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v6+v168 @ rax_v11*8]");
				return false;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	protected void SetFlag(string key, bool value)
	{
		AccountPage accountPage = _accountPage;
		AccountPageState accountPageState = accountPage.accountPageState;
		bool flag = ((Dictionary<object, bool>)(object)accountPageState.flags).TryInsert((object)key, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	protected void ChangeStateTo(UIState uiState)
	{
		AccountPage accountPage = _accountPage;
		accountPage.accountPageState.ChangeStateTo(uiState);
		accountPage.ClearAndBuild();
	}

	protected void ClearAndBuild()
	{
		_accountPage.Clear();
		Build();
	}

	protected void GoHome()
	{
		_accountPage.GoHome();
	}

	protected void HideLoggedInStatus()
	{
		AccountPage accountPage = _accountPage;
		accountPage._AccountStatus.enabled = false;
	}

	protected void SetGenericLoggedInStatus()
	{
		_accountPage.SetGenericLoggedInStatus();
	}

	protected void SetLoggedInStatus()
	{
		_accountPage.SetLoggedInStatus();
	}

	protected void SetTitle(string title)
	{
		AccountPage accountPage = _accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	protected void Logout()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CLogout_003Ed__24 stateMachine = default(_003CLogout_003Ed__24);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	protected void AddBackButtonListener()
	{
		Action b = _accountPage.BackButtonPress;
		BackButtonController.AddListener(b);
	}

	protected void AddLogoutButton()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("common_logout_button");
		Action callback = delegate
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			AccountPage._003C_003CAddLogoutButton_003Eb__22_0_003Ed stateMachine = default(AccountPage._003C_003CAddLogoutButton_003Eb__22_0_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		};
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = _accountPage.AddLabeledButton("", accountTranslation, callback, textIsLocalizationTerm, isEnabledByDefault);
	}

	protected LabeledButtonUI AddLabeledButton(string labelText, string buttonText, Action callback, bool textIsLocalizationTerm = true, bool isEnabledByDefault = true)
	{
		if ((object)_accountPage != null)
		{
			return _accountPage.AddLabeledButton(labelText, buttonText, callback, textIsLocalizationTerm, isEnabledByDefault);
		}
		return (LabeledButtonUI)(object)new NullReferenceException();
	}

	protected LabeledInputUI AddLabeledEmailInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
	{
		bool textIsLocalizationTerm2 = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		UnityAction<string> onChange2 = default(UnityAction<string>);
		if ((object)_accountPage != null)
		{
			return ((ProgrammaticUI)_accountPage).AddLabeledInput(labelText, defaultValue, placeholder, textIsLocalizationTerm2, contentType, onChange2);
		}
		return (LabeledInputUI)(object)new NullReferenceException();
	}

	protected LabeledInputUI AddLabeledPasswordInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
	{
		bool textIsLocalizationTerm2 = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		UnityAction<string> onChange2 = default(UnityAction<string>);
		if ((object)_accountPage != null)
		{
			return ((ProgrammaticUI)_accountPage).AddLabeledInput(labelText, defaultValue, placeholder, textIsLocalizationTerm2, contentType, onChange2);
		}
		return (LabeledInputUI)(object)new NullReferenceException();
	}

	protected void AddLabel(string labelText)
	{
		_accountPage.AddLabel(labelText);
	}

	protected void AddSaveSlot(string title, string savedata, string buttonText = "", Action callback = null)
	{
		_accountPage.AddSaveSlot(title, savedata, buttonText, callback);
	}

	protected void AddAccountDetail(bool linked, string account, string detail, string buttonText = "", Action callback = null)
	{
		_accountPage.AddAccountDetail(linked, account, detail, buttonText, callback);
	}

	protected void AddPrivacyPolicyGate(string warningMessage, string centerButtonText, Action centerButtonCallback)
	{
		bool textIsLocalizationTerm = default(bool);
		_accountPage.AddPrivacyPolicyGate(warningMessage, centerButtonText, centerButtonCallback, textIsLocalizationTerm);
	}

	protected void AddPrivacyPolicyScroller(string leftButtonText, Action leftButtonCallback, string rightButtonText, Action rightButtonCallback)
	{
		Action rightButtonCallback2 = default(Action);
		bool textIsLocalizationTerm = default(bool);
		_accountPage.AddPrivacyPolicyScroller(leftButtonText, leftButtonCallback, rightButtonText, rightButtonCallback2, textIsLocalizationTerm);
	}

	protected DateOfBirthField AddDateOfBirth(string label, Action onAllFieldsFilled)
	{
		//IL_00a3: Expected I, but got O
		AccountPage accountPage = _accountPage;
		if ((object)_accountPage != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(((ProgrammaticUI)accountPage)._DateOfBirthPrefab, ((ProgrammaticUI)accountPage)._Content);
			if ((object)gameObject != null)
			{
				DateOfBirthField component = gameObject.GetComponent<DateOfBirthField>();
				if ((object)component != null)
				{
					TextMeshProUGUI label2 = component._Label;
					if ((object)component._Label != null)
					{
						nint num = (nint)label2;
						component._Label.text = label;
						if (((ProgrammaticUI)accountPage)._spawnedSelectables != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
							DateOfBirthField component2 = gameObject.GetComponent<DateOfBirthField>();
							if ((object)component2 != null)
							{
								component2.Initialize();
								return component2;
							}
						}
					}
				}
			}
		}
		return (DateOfBirthField)(object)new NullReferenceException();
	}

	protected void AddHelpAndSupport(string helpText, string privacyPolicyText)
	{
		AccountHelpAndSupportUI accountHelpAndSupportUI = _accountPage.AddHelpAndSupport(helpText, privacyPolicyText);
	}

	protected void PostBuildGeneration()
	{
		_accountPage.GenerateNavigation();
		_accountPage.SelectFirstSelectable();
	}
}
