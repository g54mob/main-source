using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.CelestialDatabase
{
	public class CheckResourcesExist : IRequestHandler
	{
		public string Endpoint => "/Client/CheckResourcesExist";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; }

		public bool IncludeClientData => false;

		public CheckResourcesExist(IEnumerable<Guid> ids)
		{
			Form = new WWWForm();
			Form.AddField("ResourceHashes", string.Join(",", ids));
		}

		public static WebsiteRequest CreateRequest(IEnumerable<Guid> ids)
		{
			return new WebsiteRequest(new CheckResourcesExist(ids));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
