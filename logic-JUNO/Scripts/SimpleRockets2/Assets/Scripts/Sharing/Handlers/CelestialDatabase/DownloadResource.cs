using System;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.CelestialDatabase
{
	public class DownloadResource : IRequestHandler
	{
		private Guid _id;

		public string Endpoint => $"/Client/DownloadResource?id={_id}";

		public bool ExpectClientResponse => false;

		public WWWForm Form => null;

		public bool IncludeClientData => false;

		public DownloadResource(Guid id)
		{
			_id = id;
		}

		public static WebsiteRequest CreateRequest(Guid id)
		{
			return new WebsiteRequest(new DownloadResource(id));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
