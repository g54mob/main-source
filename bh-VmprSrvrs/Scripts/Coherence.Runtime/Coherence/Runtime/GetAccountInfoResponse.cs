using Newtonsoft.Json;

namespace Coherence.Runtime
{
	internal struct GetAccountInfoResponse : IPlayerAccountOperationResponse
	{
		[JsonProperty("id")]
		public string Id;

		[JsonProperty("username")]
		public string Username;

		[JsonProperty("email")]
		public string Email;

		[JsonProperty("display_name")]
		public string DisplayName;

		[JsonProperty("avatar_url")]
		public string AvatarUrl;

		[JsonProperty("identities")]
		public IdentityResponse[] Identities;

		[JsonProperty("verified")]
		public bool Verified;

		[JsonProperty("created_at")]
		public long CreatedAt;
	}
}
