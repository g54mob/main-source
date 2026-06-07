using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Net;
using Assets.Scripts.Settings;
using Jundroo.Common.Utils;
using UnityEngine;
using Web.Client.Models;

namespace Assets.Scripts.UI.Sharing
{
	public class UploadBugReportDialogScript : UploadDialogScript
	{
		private XElement _aircraftXml;

		public override bool IsModal => false;

		public void Initialize(XElement aircraftXml, IScreenshotDialogHandler handler)
		{
			Initialize(handler);
			_aircraftXml = aircraftXml;
		}

		protected override WebRequest OnSubmitRequest()
		{
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("UserName", Game.Instance.Settings.App.UserName);
			wWWForm.AddField("ClientToken", Game.Instance.Settings.App.ClientToken);
			wWWForm.AddField("DeviceId", Game.Instance.Device.DeviceId);
			wWWForm.AddField("Platform", Application.platform.ToString());
			wWWForm.AddField("Name", StringUtility.ClampString(base.NameInput.Text.Trim(), 100));
			wWWForm.AddField("Description", StringUtility.ClampString(base.DescriptionInput.Text.Trim(), 10000));
			int num = 0;
			foreach (ScreenshotListItemScript userScreenshot in base.UserScreenshots)
			{
				wWWForm.AddBinaryData("UserView", userScreenshot.Texture.EncodeToPNG(), $"UserView_{num++}.png", "image/png");
			}
			wWWForm.AddField("ClientVersion", Game.Version.ToString());
			wWWForm.AddField("GameNumber", "2");
			if (_aircraftXml != null)
			{
				wWWForm.AddBinaryData("Craft.xml", Encoding.UTF8.GetBytes(_aircraftXml.ToString()), "Craft.xml");
			}
			Game.Instance.Settings.SaveIfNecessary();
			AddFile(wWWForm, "CharacterSettings.xml", SettingsManager.PathForCharacterSettings);
			AddFile(wWWForm, "CloudSettings.xml", SettingsManager.PathForCloudSettings);
			AddFile(wWWForm, "ControlInputData.xml", SettingsManager.PathForControlSettings);
			AddFile(wWWForm, "GameplaySettings.xml", SettingsManager.PathForGameplaySettings);
			AddFile(wWWForm, "QualitySettings.xml", SettingsManager.PathForQualitySettings);
			AddFile(wWWForm, "Log.txt", GetLogPath("Player.log"));
			AddFile(wWWForm, "Log-prev.txt", GetLogPath("Player-prev.log"));
			return WebRequest.Post(Game.ClientControllerUrl + "/UploadBugReport", wWWForm);
		}

		protected override void OnSuccessfulResponse(ClientResponse response)
		{
			string value = response.GetValue("Url");
			if (value != null)
			{
				WebUtility.OpenUrl(Game.SimplePlanesWebsiteUrl + value);
				Debug.Log("Response URL: " + value);
			}
			else
			{
				WebUtility.OpenUrl("https://www.simpleplanes.com/Airplanes/Newest");
			}
		}

		protected override void ValidateForm(List<string> errorMessages)
		{
			base.ValidateForm(errorMessages);
			if (base.DescriptionInput.Text.Length < 20)
			{
				errorMessages.Add("Please provide a more detailed description. More context helps us understand the bug, and including steps to reproduce it is especially useful.");
			}
		}

		private static string GetLogPath(string logFileName)
		{
			string directoryName = Path.GetDirectoryName(Application.consoleLogPath);
			if (directoryName != null)
			{
				return Path.Combine(directoryName, logFileName);
			}
			return null;
		}

		private void AddFile(WWWForm form, string fileName, string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			try
			{
				if (!File.Exists(path))
				{
					return;
				}
				using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				using StreamReader streamReader = new StreamReader(stream);
				string s = streamReader.ReadToEnd();
				form.AddBinaryData(fileName, Encoding.UTF8.GetBytes(s), fileName);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
