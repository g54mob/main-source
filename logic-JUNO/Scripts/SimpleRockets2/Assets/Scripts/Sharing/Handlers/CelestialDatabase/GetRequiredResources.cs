using System;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.CelestialDatabase
{
	public class GetRequiredResources : IRequestHandler
	{
		public string Endpoint => $"/Client/GetRequiredResources?id={ResourceId}";

		public bool ExpectClientResponse => true;

		public WWWForm Form => null;

		public bool IncludeClientData => false;

		public Guid ResourceId { get; }

		public GetRequiredResources(Guid id)
		{
			ResourceId = id;
		}

		public static WebsiteRequest CreateRequest(Guid id)
		{
			return new WebsiteRequest(new GetRequiredResources(id));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
