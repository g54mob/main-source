using System;
using System.Collections.Generic;
using Assets.Scripts.Ui.Sharing.Upload;
using ModApi.Planet;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Sharing.Handlers.PlanetarySystem
{
	public class PlanetarySystemUpload : IRequestHandler
	{
		public string Endpoint => "/Client/UploadPlanetarySystem";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; private set; }

		public bool IncludeClientData => true;

		public PlanetarySystemUpload(PlanetarySystemFormData formData)
		{
			Form = new WWWForm();
			formData.UpdateFormData(Form);
		}

		public static WebsiteRequest CreateRequest(UploadContentModel model, string parentAncestryId, SolarSystemDataScript planetarySystem, Dictionary<string, Guid> celestialBodyIds, CreateResourceFileModel resourceFileModel, string resourceFilePath, string resourceFileName)
		{
			return new WebsiteRequest(new PlanetarySystemUpload(new PlanetarySystemFormData(model, parentAncestryId, planetarySystem, celestialBodyIds, resourceFileModel, resourceFilePath, resourceFileName)));
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
		}
	}
}
