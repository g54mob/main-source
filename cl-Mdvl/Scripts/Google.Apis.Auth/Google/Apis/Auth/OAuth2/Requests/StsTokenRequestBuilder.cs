using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Google.Apis.Json;

namespace Google.Apis.Auth.OAuth2.Requests
{
	internal class StsTokenRequestBuilder
	{
		public string GrantType { get; set; }

		public string Audience { get; set; }

		public IEnumerable<string> Scopes { get; set; }

		public string RequestedTokenType { get; set; }

		public string SubjectToken { get; set; }

		public string SubjectTokenType { get; set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string WorkforcePoolUserProject { get; set; }

		public StsTokenRequest Build()
		{
			AuthenticationHeaderValue authenticationHeaderValue = ((ClientId != null && ClientSecret != null) ? new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret))) : null);
			string googleOptions = ((authenticationHeaderValue == null && WorkforcePoolUserProject != null) ? NewtonsoftJsonSerializer.Instance.Serialize(new
			{
				userProject = WorkforcePoolUserProject
			}) : null);
			IEnumerable<string> scopes = Scopes;
			string scope = ((scopes != null && scopes.Any()) ? string.Join(" ", Scopes) : null);
			return new StsTokenRequest(GrantType, Audience, scope, RequestedTokenType, SubjectToken, SubjectTokenType, googleOptions, authenticationHeaderValue);
		}
	}
}
