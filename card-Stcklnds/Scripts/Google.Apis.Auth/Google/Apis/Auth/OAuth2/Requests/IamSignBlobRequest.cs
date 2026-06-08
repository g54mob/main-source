using System.Collections.Generic;
using Newtonsoft.Json;

namespace Google.Apis.Auth.OAuth2.Requests
{
	internal class IamSignBlobRequest
	{
		[JsonProperty("delegates")]
		public IEnumerable<string> DelegateAccounts { get; set; }

		[JsonProperty("payload")]
		public byte[] Payload { get; set; }
	}
}
