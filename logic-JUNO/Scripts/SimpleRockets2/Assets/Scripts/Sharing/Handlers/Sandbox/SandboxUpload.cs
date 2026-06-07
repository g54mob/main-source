using System;
using System.Xml.Linq;
using Assets.Scripts.State;
using Assets.Scripts.Ui.Sharing.Upload;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.Sandbox
{
	public class SandboxUpload : IRequestHandler
	{
		private string _previousAncestryId;

		private bool _updateLocalAncestry;

		public string Endpoint => "/Client/UploadSandbox";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; private set; }

		public bool IncludeClientData { get; } = true;

		public SandboxUpload(XDocument sandboxXml)
		{
			Create(sandboxXml);
		}

		public SandboxUpload(UploadContentModel model)
		{
			Create(model);
		}

		public static string GetAncestryId(string gameStateId, string gameStateTag)
		{
			string gameStateFileName = Game.Instance.GameStateManager.GetGameStateFileName(gameStateId, gameStateTag);
			string result = null;
			XAttribute xAttribute = XDocument.Load(gameStateFileName).Root.Attribute("parent");
			if (xAttribute != null)
			{
				result = xAttribute.Value;
			}
			return result;
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
			if (_updateLocalAncestry)
			{
				UpdateAncestryId(_previousAncestryId);
			}
		}

		public void OnComplete(WebsiteRequest request)
		{
			if (!request.Success && _updateLocalAncestry)
			{
				UpdateAncestryId(_previousAncestryId);
			}
		}

		private static string UpdateAncestryId(string newAncestryId)
		{
			GameState gameState = Game.Instance.GameState;
			string parent = gameState.Parent;
			gameState.Parent = newAncestryId;
			gameState.Save();
			return parent;
		}

		private static string UpdateDocumentAncestryId(string gameStateFileLocation, string parentId)
		{
			string result = null;
			XDocument xDocument = XDocument.Load(gameStateFileLocation);
			XAttribute xAttribute = xDocument.Root.Attribute("parent");
			if (xAttribute == null)
			{
				xAttribute = new XAttribute("parent", null);
				xDocument.Root.Add(xAttribute);
			}
			else
			{
				result = xAttribute.Value;
			}
			xAttribute.Value = parentId;
			xDocument.Save(gameStateFileLocation);
			return result;
		}

		private WWWForm AddFormData(WWWForm form, SandboxFormData formData)
		{
			form.AddField("Name", formData.SandboxName);
			form.AddField("Description", formData.Description);
			form.AddField("Public", formData.IsPublic.ToString());
			form.AddField("AncestryId", formData.AncestryId);
			form.AddField("SandboxDetailsXml", formData.SandboxDetails.GenerateXml());
			form.AddField("ValidPhotoChecksums", formData.ValidPhotoChecksums.ToString());
			form.AddField("PlanetarySystemResourceHash", formData.PlanetarySystemId.ToString());
			form.AddOptionalField("ParentAncestryId", formData.ParentAncestryId);
			form.AddOptionalField("RequiredMods", formData.RequiredMods);
			form.AddBinaryData("SandboxContentZip", formData.ZipBytes, $"{formData.AncestryId}.zip", "application/zip, application/octet-stream");
			if (formData.Screenshots != null)
			{
				int num = 0;
				foreach (byte[] screenshot in formData.Screenshots)
				{
					form.AddBinaryData("UserView", screenshot, $"UserView_{num++}.{SandboxFormData.PictureExtension}", SandboxFormData.PictureExtensionMimeType);
				}
			}
			return form;
		}

		private void Create(XDocument sandboxDocument)
		{
			_updateLocalAncestry = false;
			Form = AddFormData(new WWWForm(), SandboxFormData.LoadFromXml(sandboxDocument));
		}

		private void Create(UploadContentModel model)
		{
			_updateLocalAncestry = true;
			string newAncestryId = Guid.NewGuid().ToString();
			_previousAncestryId = UpdateAncestryId(newAncestryId);
			SandboxFormData formData = SandboxFormData.CreateFromCurrentSandbox(model.Name, model.Description, model.IsPublic, model.ValidPhotoChecksums, model.Screenshots, newAncestryId, _previousAncestryId);
			Form = AddFormData(new WWWForm(), formData);
		}
	}
}
