using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.Common
{
	public class GetUploadSettings : IRequestHandler
	{
		public string Endpoint => "/Client/GetUploadSettings";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; }

		public bool IncludeClientData => true;

		public GetUploadSettings()
		{
			Form = new WWWForm();
		}

		public static WebsiteRequest CreateRequest()
		{
			return new WebsiteRequest(new GetUploadSettings());
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
