using ModIO;
using ModIO.Util;

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
		}

		public void SendEmail()
		{
		}

		public void SendRequestExternalAuthentication()
		{
		}

		public void ReceivedExternalAuthenticationToken(ResultAnd<ExternalAuthenticationToken> response)
		{
		}

		public void HyperLinkToExternalLogin()
		{
		}

		public void CancelExternalAuthenticationRequest()
		{
		}

		public void CopyExternalAuthenticationCodeToClipboard()
		{
		}

		public void SubmitAuthenticationCode()
		{
		}

		public void SubmitGogAuthenticationRequest()
		{
		}

		public void SubmitEpicAuthenticationRequest()
		{
		}

		public void SubmitSteamAuthenticationRequest()
		{
		}

		public void SubmitXboxAuthenticationRequest()
		{
		}

		public void SubmitSwitchAuthenticationRequest()
		{
		}

		internal void SubmitPlayStationAuthenticationRequest()
		{
		}

		public void Close()
		{
		}

		public void HyperLinkToTOS()
		{
		}

		public void HyperLinkToPrivacyPolicy()
		{
		}

		private void Logout()
		{
		}

		internal void EmailSent(Result result)
		{
		}

		internal void ReceiveTermsOfUse(ResultAnd<TermsOfUse> resultAndTermsOfUse)
		{
		}

		public void CodeSubmitted(Result result)
		{
		}

		private void CacheTermsOfUseAndLinks(TermsOfUse TOS)
		{
		}

		private void ThirdPartyAuthenticationSubmitted(Result result, UserPortal authenticationPortal)
		{
		}
	}
}
