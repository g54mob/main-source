using System.Collections.Generic;
using Assets.Scripts.Ui.Sharing.Upload;
using ModApi.Planet;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Sharing.Handlers.CelestialBody
{
	public class CelestialBodyUpload : IRequestHandler
	{
		public string Endpoint => "/Client/UploadCelestialBody";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; private set; }

		public bool IncludeClientData => true;

		public CelestialBodyUpload(CelestialBodyFormData formData)
		{
			Form = new WWWForm();
			formData.UpdateFormData(Form);
		}

		public static WebsiteRequest CreateRequest(UploadContentModel model, string parentAncestryId, PlanetDataScript celestialBody, List<BinaryDataUploadContent> additionalBinaryData, CreateResourceFileModel resourceFileModel, string resourceFilePath, string resourceFileName)
		{
			return new WebsiteRequest(new CelestialBodyUpload(new CelestialBodyFormData(model, parentAncestryId, celestialBody, additionalBinaryData, resourceFileModel, resourceFilePath, resourceFileName)));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
