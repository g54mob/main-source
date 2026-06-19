using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class Authentication : SelfInstancingMonoSingleton<Authentication>
	{
		public bool IsAuthenticated;

		internal static string optionalThirdPartyEmailAddressUsedForAuthentication;

		internal static PlayStationEnvironment PSEnvironment;

		internal static Browser.RetrieveAuthenticationCodeDelegate getSteamAppTicket;

		internal static Browser.RetrieveAuthenticationCodeDelegate getXboxToken;

		internal static Browser.RetrieveAuthenticationCodeDelegate getSwitchToken;

		internal static Browser.RetrieveAuthenticationCodeDelegate getPlayStationAuthCode;

		internal static Browser.RetrieveAuthenticationCodeDelegate getEpicAuthCode;

		internal static Browser.RetrieveAuthenticationCodeDelegate getGogAuthCode;

		public ExternalAuthenticationToken currentAuthToken;

		public UserProfile currentUserProfile;

		public TermsOfUse LastReceivedTermsOfUse;

		public string privacyPolicyURL;

		public string termsOfUseURL;

		public UserPortal currentAuthenticationPortal;

		public void GetTermsOfUse()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			ModIOUnity.GetTermsOfUse(ReceiveTermsOfUse);
		}

		public void SendEmail()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			ModIOUnity.RequestAuthenticationEmail(SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.AuthenticationPanelEmailField.text, EmailSent);
		}

		public void SendRequestExternalAuthentication()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			ModIOUnity.RequestExternalAuthentication(ReceivedExternalAuthenticationToken);
		}

		public void ReceivedExternalAuthenticationToken(ResultAnd<ExternalAuthenticationToken> response)
		{
			if (response.result.Succeeded())
			{
				currentAuthToken = response.value;
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_ExternalAuthentication(response.value);
			}
			else
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem(null, "could not connect", SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_TermsOfUse);
			}
		}

		public void HyperLinkToExternalLogin()
		{
			WebBrowser.OpenWebPage(currentAuthToken.url + "?code=" + currentAuthToken.code);
		}

		public void CancelExternalAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.Close();
			currentAuthToken.Cancel();
		}

		public void CopyExternalAuthenticationCodeToClipboard()
		{
			GUIUtility.systemCopyBuffer = currentAuthToken.code;
			SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
			{
				title = "Copied",
				description = "Code copied to clipboard",
				positiveAccent = true
			});
		}

		public void SubmitAuthenticationCode()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			string text = "";
			TMP_InputField[] authenticationPanelCodeFields = SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.AuthenticationPanelCodeFields;
			foreach (TMP_InputField tMP_InputField in authenticationPanelCodeFields)
			{
				text += tMP_InputField.text;
			}
			ModIOUnity.SubmitEmailSecurityCode(text, CodeSubmitted);
		}

		public void SubmitGogAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			getGogAuthCode(delegate(string token)
			{
				SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
				{
					if (string.IsNullOrEmpty(token))
					{
						currentAuthenticationPortal = UserPortal.None;
						SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
					}
					else
					{
						ModIOUnity.AuthenticateUserViaGOG(token, optionalThirdPartyEmailAddressUsedForAuthentication, LastReceivedTermsOfUse.hash, delegate(Result result)
						{
							ThirdPartyAuthenticationSubmitted(result, UserPortal.GOG);
						});
					}
				});
			});
		}

		public void SubmitEpicAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			getEpicAuthCode(delegate(string token)
			{
				SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
				{
					if (string.IsNullOrEmpty(token))
					{
						currentAuthenticationPortal = UserPortal.None;
						SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
					}
					else
					{
						ModIOUnity.AuthenticateUserViaEpic(token, optionalThirdPartyEmailAddressUsedForAuthentication, LastReceivedTermsOfUse.hash, delegate(Result result)
						{
							ThirdPartyAuthenticationSubmitted(result, UserPortal.EpicGamesStore);
						});
					}
				});
			});
		}

		public void SubmitSteamAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			getSteamAppTicket(delegate(string appTicket)
			{
				SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
				{
					if (string.IsNullOrEmpty(appTicket))
					{
						currentAuthenticationPortal = UserPortal.None;
						SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
					}
					else
					{
						ModIOUnity.AuthenticateUserViaSteam(appTicket, optionalThirdPartyEmailAddressUsedForAuthentication, LastReceivedTermsOfUse.hash, delegate(Result result)
						{
							ThirdPartyAuthenticationSubmitted(result, UserPortal.Steam);
						});
					}
				});
			});
		}

		public void SubmitXboxAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			getXboxToken(delegate(string token)
			{
				SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
				{
					if (string.IsNullOrEmpty(token))
					{
						currentAuthenticationPortal = UserPortal.None;
						SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
					}
					else
					{
						ModIOUnity.AuthenticateUserViaXbox(token, optionalThirdPartyEmailAddressUsedForAuthentication, LastReceivedTermsOfUse.hash, delegate(Result result)
						{
							ThirdPartyAuthenticationSubmitted(result, UserPortal.XboxLive);
						});
					}
				});
			});
		}

		public void SubmitSwitchAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			getSwitchToken(delegate(string token)
			{
				SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
				{
					if (string.IsNullOrEmpty(token))
					{
						currentAuthenticationPortal = UserPortal.None;
						SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
					}
					else
					{
						ModIOUnity.AuthenticateUserViaSwitch(token, optionalThirdPartyEmailAddressUsedForAuthentication, LastReceivedTermsOfUse.hash, delegate(Result result)
						{
							ThirdPartyAuthenticationSubmitted(result, UserPortal.Nintendo);
						});
					}
				});
			});
		}

		internal void SubmitPlayStationAuthenticationRequest()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Waiting();
			getPlayStationAuthCode(delegate(string authCode)
			{
				SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
				{
					if (string.IsNullOrEmpty(authCode))
					{
						currentAuthenticationPortal = UserPortal.None;
						SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
					}
					else
					{
						ModIOUnity.AuthenticateUserViaPlayStation(authCode, optionalThirdPartyEmailAddressUsedForAuthentication, LastReceivedTermsOfUse.hash, PSEnvironment, delegate(Result result)
						{
							ThirdPartyAuthenticationSubmitted(result, UserPortal.PlayStationNetwork);
						});
					}
				});
			});
		}

		public void Close()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.Close();
		}

		public void HyperLinkToTOS()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.HyperLinkToTOS();
		}

		public void HyperLinkToPrivacyPolicy()
		{
			SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.HyperLinkToPrivacyPolicy();
		}

		private void Logout()
		{
			if (ModIOUnity.LogOutCurrentUser().Succeeded())
			{
				SelfInstancingMonoSingleton<Avatar>.Instance.Avatar_Main.gameObject.SetActive(value: false);
				IsAuthenticated = false;
				Close();
			}
		}

		internal void EmailSent(Result result)
		{
			if (result.Succeeded())
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Code();
			}
			else if (result.IsInvalidEmailAddress())
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("That does not appear to be a valid email. Please check your email address and try again.", "Invalid email address", SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Email);
			}
			else
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("Make sure you entered a valid email address and that you are still connected to the internet before trying again.", "Something went wrong", SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Email);
			}
		}

		internal void ReceiveTermsOfUse(ResultAnd<TermsOfUse> resultAndTermsOfUse)
		{
			if (resultAndTermsOfUse.result.Succeeded())
			{
				CacheTermsOfUseAndLinks(resultAndTermsOfUse.value);
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_TermsOfUse(resultAndTermsOfUse.value.termsOfUse);
			}
			else
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("Unable to connect to the mod.io server. Please check your internet connection before retrying.", "Something went wrong", Close);
			}
		}

		public void CodeSubmitted(Result result)
		{
			if (result.Succeeded())
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Complete();
				ModIOUnity.EnableModManagement(Mods.ModManagementEvent);
				ModIOUnity.FetchUpdates(delegate
				{
					if (Details.IsOn())
					{
						SelfInstancingMonoSingleton<Details>.Instance.UpdateSubscribeButtonText();
					}
					if (Collection.IsOn())
					{
						SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
					}
				});
			}
			else if (result.IsInvalidSecurityCode())
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("The code that you entered did not match the one sent to the email address you provided. Please check you entered the code correctly.", "Invalid code", SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Code);
			}
			else
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem();
			}
		}

		private void CacheTermsOfUseAndLinks(TermsOfUse TOS)
		{
			LastReceivedTermsOfUse = TOS;
			TermsOfUseLink[] links = TOS.links;
			for (int i = 0; i < links.Length; i++)
			{
				TermsOfUseLink termsOfUseLink = links[i];
				if (termsOfUseLink.name == "Terms of Use")
				{
					termsOfUseURL = termsOfUseLink.url;
				}
				else if (termsOfUseLink.name == "Privacy Policy")
				{
					privacyPolicyURL = termsOfUseLink.url;
				}
			}
		}

		private void ThirdPartyAuthenticationSubmitted(Result result, UserPortal authenticationPortal)
		{
			if (result.Succeeded())
			{
				currentAuthenticationPortal = authenticationPortal;
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Complete();
				ModIOUnity.EnableModManagement(Mods.ModManagementEvent);
				ModIOUnity.FetchUpdates(delegate
				{
					if (Details.IsOn())
					{
						SelfInstancingMonoSingleton<Details>.Instance.UpdateSubscribeButtonText();
					}
					if (Collection.IsOn())
					{
						SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
					}
				});
			}
			else
			{
				currentAuthenticationPortal = UserPortal.None;
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.OpenPanel_Problem("We were unable to validate your credentials with the mod.io server.");
			}
		}
	}
}
