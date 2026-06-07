using JetBrains.Annotations;

public interface IOAuthClient
{
	public delegate void AuthorizationRequestDelegate(OAuthAuthorizationResult result);

	void RequestAuthorization([NotNull] string authorizationUrl, [CanBeNull] string callbackUrl, AuthorizationRequestDelegate callback);
}
