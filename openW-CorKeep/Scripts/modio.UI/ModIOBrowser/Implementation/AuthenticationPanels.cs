using System;
using System.Collections;
using ModIO;
using ModIO.Util;
using QRCoder;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class AuthenticationPanels : SelfInstancingMonoSingleton<AuthenticationPanels>
	{
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
			AuthenticationPanel.SetActive(value: false);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectPreviousView();
		}

		private void Logout()
		{
			if (ModIOUnity.LogOutCurrentUser().Succeeded())
			{
				SelfInstancingMonoSingleton<Avatar>.Instance.Avatar_Main.gameObject.SetActive(value: false);
				SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated = false;
				Close();
			}
		}

		public void Open()
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.AuthPanel);
			if (!SkippedIntoTheOnlyExistingAuthenticationOption())
			{
				OpenConnectionTypePanel();
			}
		}

		private bool SkippedIntoTheOnlyExistingAuthenticationOption()
		{
			int num = 0;
			num = (Browser.allowEmailAuthentication ? (num + 1) : num);
			num = (Browser.allowExternalAuthentication ? (num + 1) : num);
			num = ((Authentication.getSteamAppTicket != null) ? (num + 1) : num);
			num = ((Authentication.getXboxToken != null) ? (num + 1) : num);
			num = ((Authentication.getSwitchToken != null) ? (num + 1) : num);
			num = ((Authentication.getPlayStationAuthCode != null) ? (num + 1) : num);
			num = ((Authentication.getGogAuthCode != null) ? (num + 1) : num);
			num = ((Authentication.getEpicAuthCode != null) ? (num + 1) : num);
			if (num > 1)
			{
				return false;
			}
			SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
			if (Authentication.getSteamAppTicket == null)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitSteamAuthenticationRequest;
			}
			else if (Authentication.getXboxToken == null)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitXboxAuthenticationRequest;
			}
			else if (Authentication.getSwitchToken == null)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitSwitchAuthenticationRequest;
			}
			else if (Authentication.getPlayStationAuthCode == null)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitPlayStationAuthenticationRequest;
			}
			else if (Authentication.getGogAuthCode == null)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitGogAuthenticationRequest;
			}
			else if (Authentication.getEpicAuthCode == null)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitEpicAuthenticationRequest;
			}
			else if (Browser.allowExternalAuthentication)
			{
				authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SendRequestExternalAuthentication;
			}
			else if (Browser.allowEmailAuthentication)
			{
				authenticationMethodAfterAgreeingToTheTOS = OpenPanel_Email;
			}
			return true;
		}

		private void OpenConnectionTypePanel()
		{
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			AuthenticationPanelLogo.SetActive(value: true);
			Translation.Get(BrowserAuthenticationPanelTitle, "Authentication", AuthenticationPanelTitleText);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			Translation.Get(BrowserAuthenticationPanelInfo, "mod.io is a 3rd party utility that provides access to a mod workshop. Choose how you wish to be authenticated.", AuthenticationPanelInfoText);
			AuthenticationPanelBackButton.gameObject.SetActive(value: true);
			AuthenticationPanelBackButton.onClick.RemoveAllListeners();
			AuthenticationPanelBackButton.onClick.AddListener(Close);
			Selectable selectable = null;
			Selectable selectable2 = null;
			Selectable selectable3 = null;
			if (Browser.allowEmailAuthentication)
			{
				AuthenticationPanelConnectViaEmailButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaEmailButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaEmailButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = OpenPanel_Email;
				});
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaEmailButton);
				selectable3 = AuthenticationPanelConnectViaEmailButton;
			}
			if (Browser.allowExternalAuthentication)
			{
				AuthenticationPanelConnectViaExternalButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaExternalButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaExternalButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SendRequestExternalAuthentication;
				});
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaExternalButton);
				if (selectable3 == null)
				{
					selectable3 = AuthenticationPanelConnectViaExternalButton;
				}
				else
				{
					selectable2 = AuthenticationPanelConnectViaExternalButton;
				}
			}
			if (Authentication.getGogAuthCode != null)
			{
				AuthenticationPanelConnectViaGOGButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaGOGButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaGOGButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitGogAuthenticationRequest;
				});
				selectable = AuthenticationPanelConnectViaGOGButton;
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaGOGButton);
			}
			else if (Authentication.getEpicAuthCode != null)
			{
				AuthenticationPanelConnectViaEpicButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaEpicButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaEpicButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitEpicAuthenticationRequest;
				});
				selectable = AuthenticationPanelConnectViaEpicButton;
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaEpicButton);
			}
			else if (Authentication.getSteamAppTicket != null)
			{
				AuthenticationPanelConnectViaSteamButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaSteamButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaSteamButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitSteamAuthenticationRequest;
				});
				selectable = AuthenticationPanelConnectViaSteamButton;
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaSteamButton);
			}
			else if (Authentication.getXboxToken != null)
			{
				AuthenticationPanelConnectViaXboxButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaXboxButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaXboxButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitXboxAuthenticationRequest;
				});
				selectable = AuthenticationPanelConnectViaXboxButton;
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaXboxButton);
			}
			else if (Authentication.getSwitchToken != null)
			{
				AuthenticationPanelConnectViaSwitchButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaSwitchButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaSwitchButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitSwitchAuthenticationRequest;
				});
				selectable = AuthenticationPanelConnectViaSwitchButton;
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaSwitchButton);
			}
			else if (Authentication.getPlayStationAuthCode != null)
			{
				AuthenticationPanelConnectViaPlayStationButton.gameObject.SetActive(value: true);
				AuthenticationPanelConnectViaPlayStationButton.onClick.RemoveAllListeners();
				AuthenticationPanelConnectViaPlayStationButton.onClick.AddListener(delegate
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.GetTermsOfUse();
					authenticationMethodAfterAgreeingToTheTOS = SelfInstancingMonoSingleton<Authentication>.Instance.SubmitPlayStationAuthenticationRequest;
				});
				selectable = AuthenticationPanelConnectViaPlayStationButton;
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelConnectViaPlayStationButton);
			}
			AuthenticationPanelBackButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = ((selectable == null) ? selectable3 : selectable)
			};
			if (selectable != null)
			{
				selectable.navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit,
					selectOnLeft = AuthenticationPanelBackButton,
					selectOnRight = selectable3
				};
			}
			if (selectable3 != null)
			{
				selectable3.navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit,
					selectOnLeft = ((selectable == null) ? AuthenticationPanelBackButton : selectable),
					selectOnRight = selectable2
				};
			}
			if (selectable2 != null)
			{
				selectable2.navigation = new Navigation
				{
					mode = Navigation.Mode.Explicit,
					selectOnLeft = selectable3
				};
			}
		}

		private void HideAllPanels()
		{
			AuthenticationPanelTitleText.gameObject.SetActive(value: false);
			AuthenticationPanelInfoText.gameObject.SetActive(value: false);
			TextAlignmentOptions alignment = AuthenticationPanelInfoText.alignment;
			alignment = TextAlignmentOptions.Left;
			AuthenticationPanelInfoText.alignment = alignment;
			Translation.Get(AuthenticationPanelBackButtonTextTranslation, "Back", AuthenticationPanelBackButtonText);
			AuthenticationPanelEnterCode.SetActive(value: false);
			AuthenticationPanelEnterEmail.SetActive(value: false);
			AuthenticationPanelExternalLogin.SetActive(value: false);
			AuthenticationPanelTermsOfUseLinks.SetActive(value: false);
			AuthenticationPanelWaitingForResponseAnimation.SetActive(value: false);
			AuthenticationPanelAgreeButton.gameObject.SetActive(value: false);
			AuthenticationPanelBackButton.gameObject.SetActive(value: false);
			AuthenticationPanelSubmitButton.gameObject.SetActive(value: false);
			AuthenticationPanelSendCodeButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaEmailButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaSteamButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaXboxButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaSwitchButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaPlayStationButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaGOGButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaEpicButton.gameObject.SetActive(value: false);
			AuthenticationPanelConnectViaExternalButton.gameObject.SetActive(value: false);
			AuthenticationPanelCompletedButton.gameObject.SetActive(value: false);
			AuthenticationPanelLogoutButton.gameObject.SetActive(value: false);
			AuthenticationPanelLogo.SetActive(value: false);
			AuthenticationPanelCancelButton.gameObject.SetActive(value: false);
		}

		public void HyperLinkToTOS()
		{
			if (string.IsNullOrWhiteSpace(SelfInstancingMonoSingleton<Authentication>.Instance.termsOfUseURL) || SelfInstancingMonoSingleton<Authentication>.Instance.LastReceivedTermsOfUse.links == null)
			{
				WebBrowser.OpenWebPage("https://mod.io/terms");
			}
			else
			{
				WebBrowser.OpenWebPage(SelfInstancingMonoSingleton<Authentication>.Instance.termsOfUseURL);
			}
		}

		public void HyperLinkToPrivacyPolicy()
		{
			if (string.IsNullOrWhiteSpace(SelfInstancingMonoSingleton<Authentication>.Instance.privacyPolicyURL) || SelfInstancingMonoSingleton<Authentication>.Instance.LastReceivedTermsOfUse.links == null)
			{
				WebBrowser.OpenWebPage("https://mod.io/privacy");
			}
			else
			{
				WebBrowser.OpenWebPage(SelfInstancingMonoSingleton<Authentication>.Instance.privacyPolicyURL);
			}
		}

		public void OpenPanel_Waiting()
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: false);
			AuthenticationPanelWaitingForResponseAnimation.SetActive(value: true);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelInfoTextTranslation, "Waiting for response...", AuthenticationPanelInfoText);
			TextAlignmentOptions alignment = AuthenticationPanelInfoText.alignment;
			alignment = TextAlignmentOptions.Center;
			AuthenticationPanelInfoText.alignment = alignment;
		}

		public void OpenPanel_Logout(Action onBack = null)
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelTitleTextTranslation, "Are you sure you'd like to log out?", AuthenticationPanelTitleText);
			AuthenticationPanelLogo.SetActive(value: true);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelInfoTextTranslation, "LogOutMessage", AuthenticationPanelInfoText);
			AuthenticationPanelBackButton.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelBackButtonTextTranslation, "Cancel", AuthenticationPanelBackButtonText);
			AuthenticationPanelBackButton.onClick.RemoveAllListeners();
			AuthenticationPanelBackButton.onClick.AddListener(delegate
			{
				Close();
				onBack?.Invoke();
			});
			AuthenticationPanelBackButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = AuthenticationPanelLogoutButton
			};
			AuthenticationPanelLogoutButton.gameObject.SetActive(value: true);
			AuthenticationPanelLogoutButton.onClick.RemoveAllListeners();
			AuthenticationPanelLogoutButton.onClick.AddListener(Logout);
			AuthenticationPanelLogoutButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = AuthenticationPanelBackButton
			};
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.AuthPanel_LogOut);
			LayoutRebuilder.ForceRebuildLayoutImmediate(AuthenticationPanelInfoText.transform as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(AuthenticationPanel.transform as RectTransform);
		}

		public void OpenPanel_Problem(string problemTranslationKey = null, string titleTranslationKey = null, Action onBack = null)
		{
			titleTranslationKey = titleTranslationKey ?? "Something went wrong!";
			problemTranslationKey = problemTranslationKey ?? "We were unable to connect to the mod.io server. Check you have a stable internet connection and try again.";
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelTitleTextTranslation, titleTranslationKey, AuthenticationPanelTitleText);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelInfoTextTranslation, problemTranslationKey, AuthenticationPanelInfoText);
			AuthenticationPanelCancelButton.gameObject.SetActive(value: true);
			AuthenticationPanelBackButton.gameObject.SetActive(value: true);
			AuthenticationPanelBackButton.onClick.RemoveAllListeners();
			if (onBack == null)
			{
				onBack = Close;
			}
			AuthenticationPanelBackButton.onClick.AddListener(delegate
			{
				onBack();
			});
			AuthenticationPanelCancelButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = AuthenticationPanelBackButton
			};
			AuthenticationPanelBackButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = AuthenticationPanelCancelButton
			};
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelBackButton);
		}

		public void OpenPanel_TermsOfUse()
		{
			OpenPanel_TermsOfUse(null);
		}

		public void OpenPanel_TermsOfUse(string TOS = null)
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			AuthenticationPanelTermsOfUseLinks.SetActive(value: true);
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelTitleTextTranslation, "Terms of use", AuthenticationPanelTitleText);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			if (TOS != null)
			{
				AuthenticationPanelInfoText.text = TOS;
			}
			AuthenticationPanelBackButton.gameObject.SetActive(value: true);
			AuthenticationPanelBackButton.onClick.RemoveAllListeners();
			AuthenticationPanelBackButton.onClick.AddListener(Close);
			AuthenticationPanelBackButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = AuthenticationPanelAgreeButton,
				selectOnUp = AuthenticationPanelTOSButton
			};
			AuthenticationPanelAgreeButton.gameObject.SetActive(value: true);
			AuthenticationPanelAgreeButton.onClick.RemoveAllListeners();
			AuthenticationPanelAgreeButton.onClick.AddListener(delegate
			{
				authenticationMethodAfterAgreeingToTheTOS();
			});
			AuthenticationPanelAgreeButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = AuthenticationPanelBackButton,
				selectOnUp = AuthenticationPanelPrivacyPolicyButton
			};
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelAgreeButton);
		}

		public void OpenPanel_ExternalAuthentication(ExternalAuthenticationToken token)
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationPanelExternalLogin.SetActive(value: true);
			AuthenticationPanelExternalCode.text = token.code;
			AuthenticationPanelExternalUrl.text = token.url.Replace("https://", "");
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelExternalCancelButton);
			GenerateQRCodeForLogin(token);
			StartCoroutine(DisplayTimeRemainingForValidCodeAndGetNewCodeWhenExpiredAndCheckIfAuthenticationSucceeded());
		}

		private void GenerateQRCodeForLogin(ExternalAuthenticationToken token)
		{
			PayloadGenerator.Url url = new PayloadGenerator.Url(token.url + "?code=" + token.code);
			PngByteQRCode pngByteQRCode = new PngByteQRCode(new QRCodeGenerator().CreateQrCode(url.ToString(), QRCodeGenerator.ECCLevel.Q));
			Texture2D texture2D = new Texture2D(0, 0);
			texture2D.LoadImage(pngByteQRCode.GetGraphic(10), markNonReadable: false);
			Sprite sprite = Sprite.Create(texture2D, new Rect(Vector2.zero, new Vector2(texture2D.width, texture2D.height)), Vector2.zero);
			AuthenticationPanelExternalQRCode.sprite = sprite;
		}

		private IEnumerator DisplayTimeRemainingForValidCodeAndGetNewCodeWhenExpiredAndCheckIfAuthenticationSucceeded()
		{
			while (AuthenticationPanelExternalLogin.activeSelf)
			{
				if (SelfInstancingMonoSingleton<Authentication>.Instance.currentAuthToken.task.IsCompleted)
				{
					if (SelfInstancingMonoSingleton<Authentication>.Instance.currentAuthToken.task.Result.Succeeded())
					{
						OpenPanel_Complete();
						ModIOUnity.EnableModManagement(Mods.ModManagementEvent);
					}
					else
					{
						OpenPanel_Problem(null, "Failed to connect account", Close);
					}
					break;
				}
				double totalSeconds = (SelfInstancingMonoSingleton<Authentication>.Instance.currentAuthToken.expiryTime - DateTime.UtcNow).TotalSeconds;
				if (totalSeconds < 1.0)
				{
					AuthenticationPanelExternalCodeTimer.text = "0 secs";
					ModIOUnity.RequestExternalAuthentication(SelfInstancingMonoSingleton<Authentication>.Instance.ReceivedExternalAuthenticationToken);
					break;
				}
				AuthenticationPanelExternalCodeTimer.text = $"{totalSeconds:0} secs";
				yield return null;
			}
		}

		public void OpenPanel_Email()
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			AuthenticationPanelEnterEmail.SetActive(value: true);
			AuthenticationPanelEmailField.text = "";
			AuthenticationPanelEmailField.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnDown = AuthenticationPanelSendCodeButton
			};
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelTitleTextTranslation, "Email authentication", AuthenticationPanelTitleText);
			AuthenticationPanelInfoText.gameObject.SetActive(value: false);
			AuthenticationPanelBackButton.gameObject.SetActive(value: true);
			AuthenticationPanelBackButton.onClick.RemoveAllListeners();
			AuthenticationPanelBackButton.onClick.AddListener(OpenPanel_TermsOfUse);
			AuthenticationPanelBackButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnRight = AuthenticationPanelSendCodeButton,
				selectOnUp = AuthenticationPanelEmailField
			};
			AuthenticationPanelSendCodeButton.gameObject.SetActive(value: true);
			AuthenticationPanelSendCodeButton.onClick.RemoveAllListeners();
			AuthenticationPanelSendCodeButton.onClick.AddListener(SelfInstancingMonoSingleton<Authentication>.Instance.SendEmail);
			AuthenticationPanelSendCodeButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = AuthenticationPanelBackButton,
				selectOnUp = AuthenticationPanelEmailField,
				selectOnRight = AuthenticationPanelCancelButton
			};
			AuthenticationPanelCancelButton.gameObject.SetActive(value: true);
			AuthenticationPanelCancelButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = AuthenticationPanelSendCodeButton,
				selectOnUp = AuthenticationPanelEmailField
			};
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelEmailField);
		}

		public void OpenPanel_Code()
		{
			HideAllPanels();
			if (true)
			{
				SelfInstancingMonoSingleton<KeyInput5DigitsUi>.Instance.Open(delegate(string code)
				{
					OpenPanel_Waiting();
					ModIOUnity.SubmitEmailSecurityCode(code, SelfInstancingMonoSingleton<Authentication>.Instance.CodeSubmitted);
				}, AuthenticationPanelEmailField.text, OpenPanel_Email);
			}
			else
			{
				OpenPanel_CodeSentNoticeForVirtualKeyboardUser();
			}
		}

		private void OpenPanel_CodeSentNoticeForVirtualKeyboardUser()
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelTitleTextTranslation, "Code sent", AuthenticationPanelTitleText);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelInfoTextTranslation, "Please check your email {email} for your 5 digit code to verify it below.", AuthenticationPanelInfoText, AuthenticationPanelEmailField.text);
			AuthenticationPanelBackButton.gameObject.SetActive(value: true);
			AuthenticationPanelBackButton.onClick.RemoveAllListeners();
			Translation.Get(AuthenticationPanelBackButtonTextTranslation, "Enter code", AuthenticationPanelBackButtonText);
			AuthenticationPanelBackButton.onClick.AddListener(SelectHiddenInputFieldForVirtualKeyboardUser);
			AuthenticationPanelBackButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit
			};
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelBackButton);
		}

		private void SelectHiddenInputFieldForVirtualKeyboardUser()
		{
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: false);
			AuthenticationPanelHiddenInputField.Select();
		}

		public void OnEndEditHiddenInput()
		{
			OpenPanel_Waiting();
			ModIOUnity.SubmitEmailSecurityCode(AuthenticationPanelHiddenInputField.text, SelfInstancingMonoSingleton<Authentication>.Instance.CodeSubmitted);
		}

		private void CodeDigitFieldOnValueChangeBehaviour(Selectable previous, Selectable next, string field)
		{
			if (field.Length == 5)
			{
				for (int i = 0; i < AuthenticationPanelCodeFields.Length && i < field.Length; i++)
				{
					AuthenticationPanelCodeFields[i].SetTextWithoutNotify(field[i].ToString());
				}
				StartCoroutine(NextFrameSelectionChange(AuthenticationPanelSubmitButton));
			}
			else if (field.Length < 2)
			{
				if (string.IsNullOrEmpty(field))
				{
					SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(previous);
				}
				else
				{
					SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(next);
				}
			}
		}

		private IEnumerator NextFrameSelectionChange(Selectable selectable)
		{
			yield return null;
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(selectable);
		}

		public void OpenPanel_Complete()
		{
			SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated = true;
			HideAllPanels();
			AuthenticationPanel.SetActive(value: true);
			AuthenticationMainPanel.SetActive(value: true);
			AuthenticationPanelTitleText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelTitleTextTranslation, "Authentication completed", AuthenticationPanelTitleText);
			AuthenticationPanelInfoText.gameObject.SetActive(value: true);
			Translation.Get(AuthenticationPanelInfoTextTranslation, "You are now connected to the mod.io browser. You can now subscribe to mods to use in your game and track them in your Collection.", AuthenticationPanelInfoText);
			AuthenticationPanelCompletedButton.gameObject.SetActive(value: true);
			AuthenticationPanelCompletedButton.navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit
			};
			SelfInstancingMonoSingleton<Avatar>.Instance.SetupUser();
			SelfInstancingMonoSingleton<Home>.Instance.RefreshModListItems();
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(AuthenticationPanelCompletedButton);
		}
	}
}
