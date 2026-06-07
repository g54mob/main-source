using UnityEngine;

public class BrowserOAuthClient : IOAuthClient
{
	public void RequestAuthorization(string authorizationUrl, string callbackUrl, IOAuthClient.AuthorizationRequestDelegate callback)
	{
		Application.OpenURL(authorizationUrl);
		callback(OAuthAuthorizationResult.Unknown);
	}
}
