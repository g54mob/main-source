using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.Common
{
	public class ValidateClientIdentity : IRequestHandler
	{
		public string Endpoint => "/Client/ValidateClientIdentity";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; }

		public bool IncludeClientData => true;

		public ValidateClientIdentity()
		{
			Form = new WWWForm();
		}

		public static WebsiteRequest CreateRequest()
		{
			return new WebsiteRequest(new ValidateClientIdentity());
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
