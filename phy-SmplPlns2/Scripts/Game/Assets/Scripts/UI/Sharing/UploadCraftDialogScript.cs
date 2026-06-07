using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Net;
using Jundroo.Common.Pool;
using Jundroo.SocialPlatforms.Achievements;
using UnityEngine;
using Web.Client.Models;

namespace Assets.Scripts.UI.Sharing
{
	public class UploadCraftDialogScript : UploadDialogScript
	{
		private AircraftScript _aircraft;

		private OrthoScreenshotHelper _orthoHelper;

		public void Initialize(AircraftScript aircraft, IScreenshotDialogHandler handler)
		{
			Initialize(handler);
			_aircraft = aircraft;
			base.NameInput.Text = aircraft.Aircraft.Name;
		}

		protected override IEnumerator OnPrepareFormAsync()
		{
			yield return base.OnPrepareFormAsync();
			_orthoHelper = new OrthoScreenshotHelper(_aircraft);
			yield return _orthoHelper.TakeOrthoScreenshots();
		}

		protected override WebRequest OnSubmitRequest()
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("UserName", Game.Instance.Settings.App.UserName);
			wWWForm.AddField("ClientToken", Game.Instance.Settings.App.ClientToken);
			wWWForm.AddField("DeviceId", Game.Instance.Device.DeviceId);
			wWWForm.AddField("Platform", Application.platform.ToString());
			string text = base.NameInput.Text.Trim();
			if (text.Length > 100)
			{
				text = text.Substring(0, 100);
			}
			wWWForm.AddField("Name", text);
			string text2 = base.DescriptionInput.Text.Trim();
			if (text2.Length > 2000)
			{
				text2 = text2.Substring(0, 2000);
			}
			wWWForm.AddField("Description", text2);
			wWWForm.AddBinaryData("TopView", _orthoHelper.TopScreenshotTexture.EncodeToPNG(), "TopView.png", "image/png");
			wWWForm.AddBinaryData("SideView", _orthoHelper.SideScreenshotTexture.EncodeToPNG(), "SideView.png", "image/png");
			wWWForm.AddBinaryData("FrontView", _orthoHelper.FrontScreenshotTexture.EncodeToPNG(), "FrontView.png", "image/png");
			int num = 0;
			foreach (ScreenshotListItemScript userScreenshot in base.UserScreenshots)
			{
				wWWForm.AddBinaryData("UserView", userScreenshot.Texture.EncodeToPNG(), $"UserView_{num++}.png", "image/png");
			}
			wWWForm.AddField("RuntimeVersion", Game.Version.ToString());
			wWWForm.AddField("GameNumber", "2");
			string craftTags = GetCraftTags();
			wWWForm.AddField("AircraftXml", GenerateCraftXml(craftTags));
			wWWForm.AddField("Tags", craftTags);
			wWWForm.AddField("RequiredMods", RequiredModInfo.GenerateXml(_aircraft.GetRequiredMods()).ToString());
			wWWForm.AddField("ControlSurfaces", (int)_aircraft.GetStats(AircraftScript.AircraftStats.ControlSurfaceCount));
			wWWForm.AddField("Airfoils", "NA");
			wWWForm.AddField("Categories", "Prop, Military, Vintage");
			wWWForm.AddField("Fuel", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.FuelAmount) * 1000f));
			wWWForm.AddField("MaxSpeed", -1000);
			wWWForm.AddField("Drag", (int)_aircraft.GetStats(AircraftScript.AircraftStats.Drag));
			wWWForm.AddField("WingLoading", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.WingLoading) * 1000f));
			wWWForm.AddField("WingSpan", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.WingSpan) * 1000f));
			wWWForm.AddField("Height", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.Height) * 1000f));
			wWWForm.AddField("Length", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.Length) * 1000f));
			wWWForm.AddField("WingArea", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.WingArea) * 1000f));
			wWWForm.AddField("PowerToWeightRatio", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.PowerToWeightRatio) * 1000f));
			wWWForm.AddField("HorsePowerToWeightRatio", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.HorsePowerToWeightRatio) * 1000f));
			wWWForm.AddField("EmptyWeight", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.EmptyWeight) * 1000f));
			wWWForm.AddField("LoadedWeight", (int)(_aircraft.GetStats(AircraftScript.AircraftStats.LoadedWeight) * 1000f));
			wWWForm.AddField("TotalPartCount", (int)_aircraft.GetStats(AircraftScript.AircraftStats.PartCount));
			wWWForm.AddField("PerformanceCost", (int)_aircraft.GetStats(AircraftScript.AircraftStats.PerformanceCost));
			wWWForm.AddField("Public", base.UploadVisibilityPublic.ToString());
			wWWForm.AddField("Education", Game.Instance.Device.IsEducationBuild.ToString());
			AchievementHelper.UnlockAchievement(AchievementKey.WebsiteUploadPlane);
			return WebRequest.Post(Game.ClientControllerUrl + "/UploadCraft", wWWForm);
		}

		protected override void OnSuccessfulResponse(ClientResponse response)
		{
			string value = response.GetValue("UrlId");
			if (value != null && value.Length >= 6 && value.Length <= 8)
			{
				_aircraft.Aircraft.Url = value;
				string value2 = response.GetValue("Url");
				WebUtility.OpenUrl(Game.SimplePlanesWebsiteUrl + value2);
				Debug.Log("Aircraft URL Id: " + value + ", URL: " + value2);
			}
			else
			{
				WebUtility.OpenUrl("https://www.simpleplanes.com/Airplanes/Newest");
			}
		}

		protected override void ValidateForm(List<string> errorMessages)
		{
			base.ValidateForm(errorMessages);
		}

		private string GenerateCraftXml(string craftTags)
		{
			XElement xElement = _aircraft.Aircraft.GenerateXml(createRigidBodyGroups: true, serializeStats: true);
			xElement.SetAttributeValue("Tags", craftTags);
			return xElement.ToString();
		}

		private string GetCraftTags()
		{
			List<string> value;
			using (CollectionPool<List<string>, string>.Get(out value))
			{
				foreach (string tag in _aircraft.Aircraft.Tags)
				{
					if (CraftTags.WebsiteTags.Contains(tag, StringComparer.OrdinalIgnoreCase))
					{
						value.Add(tag);
					}
				}
				return string.Join(",", value);
			}
		}
	}
}
