using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.CelestialDatabase
{
	public class GetRequiredResourcesForPost : IRequestHandler
	{
		public string Endpoint => "/Client/GetRequiredResourcesForPost?id=" + PostId;

		public bool ExpectClientResponse => true;

		public WWWForm Form => null;

		public bool IncludeClientData => false;

		public string PostId { get; }

		public GetRequiredResourcesForPost(string postId)
		{
			PostId = postId;
		}

		public static WebsiteRequest CreateRequest(string postId)
		{
			return new WebsiteRequest(new GetRequiredResourcesForPost(postId));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
