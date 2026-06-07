using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Logging;
using Google.Apis.Util;
using Google.Apis.Util.Store;

namespace Google.Apis.Auth.OAuth2
{
	public class AuthorizationCodeInstalledApp : IAuthorizationCodeInstalledApp
	{
		private class NoOpPckeAuthorizationFlow : IPkceAuthorizationCodeFlow, IAuthorizationCodeFlow, IDisposable
		{
			private readonly IAuthorizationCodeFlow flow;

			public IAccessMethod AccessMethod => flow.AccessMethod;

			public IClock Clock => flow.Clock;

			public IDataStore DataStore => flow.DataStore;

			internal NoOpPckeAuthorizationFlow(IAuthorizationCodeFlow flow)
			{
				this.flow = flow;
			}

			public AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri, out string codeVerifier)
			{
				codeVerifier = "invalid+*/";
				return flow.CreateAuthorizationCodeRequest(redirectUri);
			}

			public AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
			{
				return flow.CreateAuthorizationCodeRequest(redirectUri);
			}

			public Task DeleteTokenAsync(string userId, CancellationToken taskCancellationToken)
			{
				return flow.DeleteTokenAsync(userId, taskCancellationToken);
			}

			public void Dispose()
			{
				flow.Dispose();
			}

			public Task<TokenResponse> ExchangeCodeForTokenAsync(string userId, string code, string codeVerifier, string redirectUri, CancellationToken taskCancellationToken)
			{
				return flow.ExchangeCodeForTokenAsync(userId, code, redirectUri, taskCancellationToken);
			}

			public Task<TokenResponse> ExchangeCodeForTokenAsync(string userId, string code, string redirectUri, CancellationToken taskCancellationToken)
			{
				return flow.ExchangeCodeForTokenAsync(userId, code, redirectUri, taskCancellationToken);
			}

			public Task<TokenResponse> LoadTokenAsync(string userId, CancellationToken taskCancellationToken)
			{
				return flow.LoadTokenAsync(userId, taskCancellationToken);
			}

			public Task<TokenResponse> RefreshTokenAsync(string userId, string refreshToken, CancellationToken taskCancellationToken)
			{
				return flow.RefreshTokenAsync(userId, refreshToken, taskCancellationToken);
			}

			public Task RevokeTokenAsync(string userId, string token, CancellationToken taskCancellationToken)
			{
				return flow.RevokeTokenAsync(userId, token, taskCancellationToken);
			}

			public bool ShouldForceTokenRetrieval()
			{
				return flow.ShouldForceTokenRetrieval();
			}
		}

		private static readonly ILogger Logger = ApplicationContext.Logger.ForType<AuthorizationCodeInstalledApp>();

		private readonly IPkceAuthorizationCodeFlow flow;

		private readonly ICodeReceiver codeReceiver;

		public IAuthorizationCodeFlow Flow => flow;

		public ICodeReceiver CodeReceiver => codeReceiver;

		public AuthorizationCodeInstalledApp(IAuthorizationCodeFlow flow, ICodeReceiver codeReceiver)
		{
			this.flow = ((!(flow is IPkceAuthorizationCodeFlow pkceAuthorizationCodeFlow)) ? new NoOpPckeAuthorizationFlow(flow) : pkceAuthorizationCodeFlow);
			this.codeReceiver = codeReceiver;
		}

		public async Task<UserCredential> AuthorizeAsync(string userId, CancellationToken taskCancellationToken)
		{
			TokenResponse token = await Flow.LoadTokenAsync(userId, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (ShouldRequestAuthorizationCode(token))
			{
				string redirectUri = CodeReceiver.RedirectUri;
				string codeVerifier;
				AuthorizationCodeRequestUrl url = flow.CreateAuthorizationCodeRequest(redirectUri, out codeVerifier);
				AuthorizationCodeResponseUrl authorizationCodeResponseUrl = await CodeReceiver.ReceiveCodeAsync(url, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (string.IsNullOrEmpty(authorizationCodeResponseUrl.Code))
				{
					TokenErrorResponse tokenErrorResponse = new TokenErrorResponse(authorizationCodeResponseUrl);
					Logger.Info("Received an error. The response is: {0}", tokenErrorResponse);
					throw new TokenResponseException(tokenErrorResponse);
				}
				Logger.Debug("Received \"{0}\" code", authorizationCodeResponseUrl.Code);
				token = await flow.ExchangeCodeForTokenAsync(userId, authorizationCodeResponseUrl.Code, codeVerifier, redirectUri, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return new UserCredential(flow, userId, token);
		}

		public bool ShouldRequestAuthorizationCode(TokenResponse token)
		{
			if (!Flow.ShouldForceTokenRetrieval() && token != null)
			{
				if (token.RefreshToken == null)
				{
					return token.ShouldBeRefreshed(flow.Clock);
				}
				return false;
			}
			return true;
		}
	}
}
