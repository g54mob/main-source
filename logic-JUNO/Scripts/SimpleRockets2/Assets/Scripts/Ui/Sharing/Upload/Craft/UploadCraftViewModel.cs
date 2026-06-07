using System;
using System.Collections;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Design;
using Assets.Scripts.Sharing;
using Assets.Scripts.Sharing.Handlers;
using ModApi.Craft;
using ModApi.Mods;
using UnityEngine;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Upload.Craft
{
	public class UploadCraftViewModel : UploadContentSimpleViewModel, IRequestHandler
	{
		private ICraftScript _craftScript;

		private DesignerScript _designerScript;

		private OrthoScreenshotHelper _orthoHelper;

		private string _previousParentAncestryId;

		public static bool CompressCraftXml { get; set; } = true;

		public string Endpoint => "/Client/UploadCraft";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; private set; }

		public bool IncludeClientData => true;

		public UploadCraftViewModel(ICraftScript craftScript, DesignerScript designerScript)
		{
			_designerScript = designerScript;
			_craftScript = craftScript;
			base.Title = "Upload Craft";
			base.NameLabel = "Craft Name";
			base.DescriptionLabel = "Craft Description";
		}

		public override WebsiteRequest CreateWebRequest(UploadContentModel model)
		{
			_craftScript.Data.Name = model.Name;
			_previousParentAncestryId = _craftScript.Data.ParentAncestryId;
			_craftScript.Data.ParentAncestryId = Guid.NewGuid().ToString();
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("Name", model.Name);
			wWWForm.AddField("Description", model.Description);
			wWWForm.AddField("Education", Game.Instance.Device.IsEducationBuild.ToString());
			wWWForm.AddField("Public", model.IsPublic.ToString());
			wWWForm.AddField("ValidPhotoChecksums", model.ValidPhotoChecksums.ToString());
			wWWForm.AddField("ParentAncestryId", _previousParentAncestryId);
			wWWForm.AddField("AncestryId", _craftScript.Data.ParentAncestryId);
			wWWForm.AddField("TotalPartCount", _craftScript.Data.Assembly.Parts.Count);
			_designerScript.PerformanceAnalysis.ConfigureForVacuum();
			CraftDetailsModel craftDetailsModel = CraftDetailsHelper.GenerateCraftDetails(_craftScript);
			wWWForm.AddField("CraftDetailsXml", craftDetailsModel.GenerateXml());
			XElement xElement = _designerScript.GenerateCraftXml(undoStep: false, optimizeXml: true);
			if (CompressCraftXml)
			{
				wWWForm.AddBinaryData("Craft.zip", CraftLoaderScript.CompressCraftXml(xElement), "Craft.zip", "application/zip");
			}
			else
			{
				wWWForm.AddBinaryData("Craft.Xml", Encoding.UTF8.GetBytes(xElement.ToString()), "Craft.xml", "text/xml");
			}
			RequiredModsData requiredModsData = new RequiredModsData(xElement.Element("RequiredMods"));
			if (requiredModsData.Mods.Count > 0)
			{
				wWWForm.AddField("RequiredMods", requiredModsData.GenerateXml().ToString());
			}
			wWWForm.AddBinaryData("OrthoView", _orthoHelper.TopScreenshotTexture.EncodeToJPG(), "Ortho_1.jpg", "image/jpeg");
			wWWForm.AddBinaryData("OrthoView", _orthoHelper.SideScreenshotTexture.EncodeToJPG(), "Ortho_2.jpg", "image/jpeg");
			wWWForm.AddBinaryData("OrthoView", _orthoHelper.FrontScreenshotTexture.EncodeToJPG(), "Ortho_3.jpg", "image/jpeg");
			int num = 0;
			foreach (Texture2D screenshot in model.Screenshots)
			{
				wWWForm.AddBinaryData("UserView", screenshot.EncodeToJPG(), $"UserView_{num++}.jpg", "image/jpeg");
			}
			Form = wWWForm;
			return new WebsiteRequest(Game.SimpleRocketsWebsiteUrl, this);
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
			_craftScript.Data.ParentAncestryId = _previousParentAncestryId;
		}

		public void OnComplete(WebsiteRequest request)
		{
			if (request.Response == null || !request.Response.Succeeded)
			{
				_craftScript.Data.ParentAncestryId = _previousParentAncestryId;
			}
		}

		public override IEnumerator PrepareToSend()
		{
			yield return base.PrepareToSend();
			_orthoHelper = new OrthoScreenshotHelper();
			yield return _orthoHelper.RenderScreenshots(_craftScript);
		}
	}
}
