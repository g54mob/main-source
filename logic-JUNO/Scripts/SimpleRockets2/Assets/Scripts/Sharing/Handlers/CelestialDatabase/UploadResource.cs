using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Sharing.Handlers.CelestialDatabase
{
	public class UploadResource : IRequestHandler
	{
		public string Endpoint => "/Client/UploadResourceFile";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; }

		public bool IncludeClientData => true;

		public UploadResource(CreateResourceFileModel model, byte[] data, string fileName)
		{
			Form = new WWWForm();
			string value = model.GenerateXml();
			Form.AddField("CreateResourceFileXml", value);
			Form.AddBinaryData("resourceFile", data, fileName, "application/octet-stream");
		}

		public static WebsiteRequest CreateRequest(CreateResourceFileModel model, byte[] data, string fileName)
		{
			return new WebsiteRequest(new UploadResource(model, data, fileName));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
