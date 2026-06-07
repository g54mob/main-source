using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Events;

namespace VampireSurvivors.UI
{
	public abstract class BaseAccountPagePanel
	{
		[CompilerGenerated]
		private sealed class _003CAccountErrorPopupRoutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseAccountPagePanel _003C_003E4__this;

			public string title;

			public string description;

			public string helpText;

			public Action callback;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAccountErrorPopupRoutine_003Ed__13(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLogout_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BaseAccountPagePanel _003C_003E4__this;

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

		[CompilerGenerated]
		private sealed class _003CShowLoadingRoutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseAccountPagePanel _003C_003E4__this;

			public string message;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CShowLoadingRoutine_003Ed__6(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CShowOKRoutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseAccountPagePanel _003C_003E4__this;

			public string title;

			public string description;

			public Action callback;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CShowOKRoutine_003Ed__8(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CShowYesNoRoutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BaseAccountPagePanel _003C_003E4__this;

			public string title;

			public string description;

			public Action yesCallback;

			public Action noCallback;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CShowYesNoRoutine_003Ed__10(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private AccountPage _accountPage;

		protected BaseAccountPagePanel(AccountPage accountPage)
		{
		}

		public abstract void Build();

		protected void HideLoading()
		{
		}

		protected void ShowLoading(string message)
		{
		}

		protected void ShowLoadingImmediate(string message)
		{
		}

		[IteratorStateMachine(typeof(_003CShowLoadingRoutine_003Ed__6))]
		private IEnumerator ShowLoadingRoutine(string message)
		{
			return null;
		}

		protected void ShowOkPopup(string title, string description, Action callback)
		{
		}

		[IteratorStateMachine(typeof(_003CShowOKRoutine_003Ed__8))]
		private IEnumerator ShowOKRoutine(string title, string description, Action callback)
		{
			return null;
		}

		protected void ShowYesNoPopup(string title, string description, Action yesCallback, Action noCallback)
		{
		}

		[IteratorStateMachine(typeof(_003CShowYesNoRoutine_003Ed__10))]
		private IEnumerator ShowYesNoRoutine(string title, string description, Action yesCallback, Action noCallback)
		{
			return null;
		}

		protected void ShowOkPopupForSuccess(string description, Action callback)
		{
		}

		protected void ShowAccountErrorPopup(string title, string description, string helpText, Action callback)
		{
		}

		[IteratorStateMachine(typeof(_003CAccountErrorPopupRoutine_003Ed__13))]
		private IEnumerator AccountErrorPopupRoutine(string title, string description, string helpText, Action callback)
		{
			return null;
		}

		protected void ShowOkPopupForError(string description, Exception e, Action callback)
		{
		}

		protected bool GetFlag(string key)
		{
			return false;
		}

		protected void SetFlag(string key, bool value)
		{
		}

		protected void ChangeStateTo(UIState uiState)
		{
		}

		protected void ClearAndBuild()
		{
		}

		protected void GoHome()
		{
		}

		protected void HideLoggedInStatus()
		{
		}

		protected void SetGenericLoggedInStatus()
		{
		}

		protected void SetLoggedInStatus()
		{
		}

		protected void SetTitle(string title)
		{
		}

		[AsyncStateMachine(typeof(_003CLogout_003Ed__24))]
		protected void Logout()
		{
		}

		protected void AddBackButtonListener()
		{
		}

		protected void AddLogoutButton()
		{
		}

		protected LabeledButtonUI AddLabeledButton(string labelText, string buttonText, Action callback, bool textIsLocalizationTerm = true, bool isEnabledByDefault = true)
		{
			return null;
		}

		protected LabeledInputUI AddLabeledEmailInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
		{
			return null;
		}

		protected LabeledInputUI AddLabeledPasswordInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
		{
			return null;
		}

		protected void AddLabel(string labelText)
		{
		}

		protected void AddSaveSlot(string title, string savedata, string buttonText = "", Action callback = null)
		{
		}

		protected void AddAccountDetail(bool linked, string account, string detail, string buttonText = "", Action callback = null)
		{
		}

		protected void AddPrivacyPolicyGate(string warningMessage, string centerButtonText, Action centerButtonCallback)
		{
		}

		protected void AddPrivacyPolicyScroller(string leftButtonText, Action leftButtonCallback, string rightButtonText, Action rightButtonCallback)
		{
		}

		protected DateOfBirthField AddDateOfBirth(string label, Action onAllFieldsFilled)
		{
			return null;
		}

		protected void AddHelpAndSupport(string helpText, string privacyPolicyText)
		{
		}

		protected void PostBuildGeneration()
		{
		}
	}
}
