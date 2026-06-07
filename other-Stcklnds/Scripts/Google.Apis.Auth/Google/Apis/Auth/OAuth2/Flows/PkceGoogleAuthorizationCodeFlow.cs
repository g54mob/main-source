using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;

namespace Google.Apis.Auth.OAuth2.Flows
{
	public class PkceGoogleAuthorizationCodeFlow : GoogleAuthorizationCodeFlow, IPkceAuthorizationCodeFlow, IAuthorizationCodeFlow, IDisposable
	{
		private const int CodeVerifierMaxLengthChars = 128;

		private const int CodeVerifierRandomNumberLengthBytes = 96;

		private const string ChallengeMethodSha256 = "S256";

		private const string ChallengeMethodPlain = "plain";

		public PkceGoogleAuthorizationCodeFlow(Initializer initializer)
			: base(initializer)
		{
		}

		public AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri, out string codeVerifier)
		{
			GoogleAuthorizationCodeRequestUrl obj = CreateAuthorizationCodeRequest(redirectUri) as GoogleAuthorizationCodeRequestUrl;
			codeVerifier = GenerateCodeVerifier();
			AddCodeChallenge(obj, codeVerifier);
			return obj;
		}

		public async Task<TokenResponse> ExchangeCodeForTokenAsync(string userId, string code, string codeVerifier, string redirectUri, CancellationToken taskCancellationToken)
		{
			AuthorizationCodeTokenRequest authorizationCodeTokenRequest = CreateAuthorizationCodeTokenRequest(userId, code, redirectUri);
			authorizationCodeTokenRequest.CodeVerifier = codeVerifier;
			return await ExchangeCodeForTokenAsync(userId, authorizationCodeTokenRequest, taskCancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private static string GenerateCodeVerifier()
		{
			byte[] array = new byte[96];
			using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(array);
			return TokenEncodingHelpers.UrlSafeBase64Encode(array);
		}

		private static void AddCodeChallenge(GoogleAuthorizationCodeRequestUrl request, string codeVerifier)
		{
			string codeChallenge;
			string codeChallengeMethod;
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(codeVerifier);
				using SHA256 sHA = SHA256.Create();
				codeChallenge = TokenEncodingHelpers.UrlSafeBase64Encode(sHA.ComputeHash(bytes));
				codeChallengeMethod = "S256";
			}
			catch (TargetInvocationException)
			{
				codeChallenge = codeVerifier;
				codeChallengeMethod = "plain";
			}
			request.CodeChallenge = codeChallenge;
			request.CodeChallengeMethod = codeChallengeMethod;
		}
	}
}
