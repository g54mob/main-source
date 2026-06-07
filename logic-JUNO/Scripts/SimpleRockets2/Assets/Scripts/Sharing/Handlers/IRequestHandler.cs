using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers
{
	public interface IRequestHandler
	{
		string Endpoint { get; }

		bool ExpectClientResponse { get; }

		WWWForm Form { get; }

		bool IncludeClientData { get; }

		void OnCanceled(WebsiteRequest websiteRequest);

		void OnComplete(WebsiteRequest request);
	}
}
