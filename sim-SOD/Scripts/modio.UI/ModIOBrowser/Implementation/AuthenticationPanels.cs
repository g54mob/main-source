using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class AuthenticationPanels : SelfInstancingMonoSingleton<AuthenticationPanels>
	{
		[CompilerGenerated]
		private sealed class _003CDisplayTimeRemainingForValidCodeAndGetNewCodeWhenExpiredAndCheckIfAuthenticationSucceeded_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AuthenticationPanels _003C_003E4__this;

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
			public _003CDisplayTimeRemainingForValidCodeAndGetNewCodeWhenExpiredAndCheckIfAuthenticationSucceeded_003Ed__58(int _003C_003E1__state)
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
		private sealed class _003CNextFrameSelectionChange_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Selectable selectable;

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
			public _003CNextFrameSelectionChange_003Ed__65(int _003C_003E1__state)
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

		internal Translation BrowserFeaturedSubscribeTranslation;

		internal Translation BrowserAuthenticationPanelTitle;

		internal Translation BrowserAuthenticationPanelInfo;

		internal Translation AuthenticationPanelBackButtonTextTranslation;

		internal Translation AuthenticationPanelInfoTextTranslation;

		internal Translation AuthenticationPanelTitleTextTranslation;

		[Header("Authentication Panel")]
		[SerializeField]
		public GameObject AuthenticationPanel;

		[SerializeField]
		public GameObject AuthenticationMainPanel;

		[SerializeField]
		public GameObject AuthenticationPanelWaitingForResponseAnimation;

		[SerializeField]
		public GameObject AuthenticationPanelEnterEmail;

		[SerializeField]
		public GameObject AuthenticationPanelExternalLogin;

		[SerializeField]
		public GameObject AuthenticationPanelLogo;

		[SerializeField]
		public TMP_InputField AuthenticationPanelEmailField;

		[SerializeField]
		public GameObject AuthenticationPanelEnterCode;

		[SerializeField]
		public TMP_InputField[] AuthenticationPanelCodeFields;

		[SerializeField]
		public TMP_InputField AuthenticationPanelHiddenInputField;

		[SerializeField]
		public Button AuthenticationPanelConnectViaSteamButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaEpicButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaGOGButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaXboxButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaSwitchButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaPlayStationButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaEmailButton;

		[SerializeField]
		public Button AuthenticationPanelConnectViaExternalButton;

		[SerializeField]
		public Button AuthenticationPanelBackButton;

		[SerializeField]
		public TMP_Text AuthenticationPanelBackButtonText;

		[SerializeField]
		public TMP_Text AuthenticationPanelExternalCode;

		[SerializeField]
		public TMP_Text AuthenticationPanelExternalUrl;

		[SerializeField]
		public TMP_Text AuthenticationPanelExternalCodeTimer;

		[SerializeField]
		public Image AuthenticationPanelExternalQRCode;

		[SerializeField]
		public Button AuthenticationPanelExternalCancelButton;

		[SerializeField]
		public Button AuthenticationPanelAgreeButton;

		[SerializeField]
		public Button AuthenticationPanelSendCodeButton;

		[SerializeField]
		public Button AuthenticationPanelSubmitButton;

		[SerializeField]
		public Button AuthenticationPanelCompletedButton;

		[SerializeField]
		public Button AuthenticationPanelLogoutButton;

		[SerializeField]
		public Button AuthenticationPanelTOSButton;

		[SerializeField]
		public Button AuthenticationPanelPrivacyPolicyButton;

		[SerializeField]
		public Button AuthenticationPanelCancelButton;

		[SerializeField]
		public GameObject AuthenticationPanelTermsOfUseLinks;

		[SerializeField]
		public TMP_Text AuthenticationPanelTitleText;

		[SerializeField]
		public TMP_Text AuthenticationPanelInfoText;

		private Action authenticationMethodAfterAgreeingToTheTOS;

		public void Close()
		{
		}

		private void Logout()
		{
		}

		public void Open()
		{
		}

		private bool SkippedIntoTheOnlyExistingAuthenticationOption()
		{
			return false;
		}

		private void OpenConnectionTypePanel()
		{
		}

		private void HideAllPanels()
		{
		}

		public void HyperLinkToTOS()
		{
		}

		public void HyperLinkToPrivacyPolicy()
		{
		}

		public void OpenPanel_Waiting()
		{
		}

		public void OpenPanel_Logout(Action onBack = null)
		{
		}

		public void OpenPanel_Problem(string problemTranslationKey = null, string titleTranslationKey = null, Action onBack = null)
		{
		}

		public void OpenPanel_TermsOfUse()
		{
		}

		public void OpenPanel_TermsOfUse(string TOS = null)
		{
		}

		public void OpenPanel_ExternalAuthentication(ExternalAuthenticationToken token)
		{
		}

		private void GenerateQRCodeForLogin(ExternalAuthenticationToken token)
		{
		}

		[IteratorStateMachine(typeof(_003CDisplayTimeRemainingForValidCodeAndGetNewCodeWhenExpiredAndCheckIfAuthenticationSucceeded_003Ed__58))]
		private IEnumerator DisplayTimeRemainingForValidCodeAndGetNewCodeWhenExpiredAndCheckIfAuthenticationSucceeded()
		{
			return null;
		}

		public void OpenPanel_Email()
		{
		}

		public void OpenPanel_Code()
		{
		}

		private void OpenPanel_CodeSentNoticeForVirtualKeyboardUser()
		{
		}

		private void SelectHiddenInputFieldForVirtualKeyboardUser()
		{
		}

		public void OnEndEditHiddenInput()
		{
		}

		private void CodeDigitFieldOnValueChangeBehaviour(Selectable previous, Selectable next, string field)
		{
		}

		[IteratorStateMachine(typeof(_003CNextFrameSelectionChange_003Ed__65))]
		private IEnumerator NextFrameSelectionChange(Selectable selectable)
		{
			return null;
		}

		public void OpenPanel_Complete()
		{
		}
	}
}
