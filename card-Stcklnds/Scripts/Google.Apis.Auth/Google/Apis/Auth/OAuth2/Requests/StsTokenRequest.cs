using System.Net.Http.Headers;
using Google.Apis.Util;

namespace Google.Apis.Auth.OAuth2.Requests
{
	internal class StsTokenRequest
	{
		[RequestParameter("grant_type")]
		public string GrantType { get; }

		[RequestParameter("audience")]
		public string Audience { get; }

		[RequestParameter("scope")]
		public string Scope { get; }

		[RequestParameter("requested_token_type")]
		public string RequestedTokenType { get; }

		[RequestParameter("subject_token")]
		public string SubjectToken { get; }

		[RequestParameter("subject_token_type")]
		public string SubjectTokenType { get; }

		[RequestParameter("options")]
		public string GoogleOptions { get; }

		public AuthenticationHeaderValue AuthenticationHeader { get; }

		internal StsTokenRequest(string grantType, string audience, string scope, string requestedTokenType, string subjectToken, string subjectTokenType, string googleOptions, AuthenticationHeaderValue authenticationHeader)
		{
			GrantType = grantType;
			Audience = audience;
			Scope = scope;
			RequestedTokenType = requestedTokenType;
			SubjectToken = subjectToken;
			SubjectTokenType = subjectTokenType;
			GoogleOptions = googleOptions;
			AuthenticationHeader = authenticationHeader;
		}
	}
}
