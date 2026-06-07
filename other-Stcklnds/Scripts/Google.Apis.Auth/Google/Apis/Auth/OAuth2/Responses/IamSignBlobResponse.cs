using Newtonsoft.Json;

namespace Google.Apis.Auth.OAuth2.Responses
{
	internal class IamSignBlobResponse
	{
		[JsonProperty("signedBlob")]
		public string SignedBlob { get; set; }
	}
}
