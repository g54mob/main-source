using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Logging;
using Assets.Scripts.Sharing.Handlers.Sandbox;
using Assets.Scripts.Ui.Sharing.Upload;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.BugReport
{
	public class BugReportUpload : IRequestHandler
	{
		private SandboxUpload _sandboxUpload;

		public string Endpoint => "/Client/UploadBugReport";

		public bool ExpectClientResponse => true;

		public WWWForm Form { get; private set; }

		public bool IncludeClientData { get; } = true;

		public BugReportUpload(XDocument sandboxData, string logFileContents, string inputState, Dictionary<string, byte[]> bugScreenshots)
		{
			WWWForm form;
			if (sandboxData != null)
			{
				_sandboxUpload = new SandboxUpload(sandboxData);
				form = _sandboxUpload.Form;
			}
			else
			{
				form = new WWWForm();
			}
			Form = AddBugFormData(form, BugReportFormData.CreateFromBugReport(logFileContents, inputState, bugScreenshots));
		}

		public BugReportUpload(UploadContentModel model, bool includeSandbox = true)
		{
			WWWForm wWWForm;
			if (includeSandbox)
			{
				_sandboxUpload = new SandboxUpload(model);
				wWWForm = _sandboxUpload.Form;
			}
			else
			{
				wWWForm = new WWWForm();
				wWWForm.AddField("Name", model.Name);
				wWWForm.AddField("Description", model.Description);
				wWWForm.AddField("Public", model.IsPublic.ToString());
				wWWForm.AddField("ValidPhotoChecksums", model.ValidPhotoChecksums.ToString());
				if (model.Screenshots != null)
				{
					int num = 0;
					foreach (Texture2D screenshot in model.Screenshots)
					{
						wWWForm.AddBinaryData("UserView", screenshot.EncodeToJPG(), $"UserView_{num++}.{SandboxFormData.PictureExtension}", SandboxFormData.PictureExtensionMimeType);
					}
				}
			}
			Form = AddBugFormData(wWWForm, BugReportFormData.CreateFromCurrentScene());
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
			_sandboxUpload?.OnComplete(request);
			if (request.Success)
			{
				LogHistory.Instance.Clear();
			}
		}

		private WWWForm AddBugFormData(WWWForm form, BugReportFormData bugReportFormData)
		{
			string.IsNullOrEmpty(bugReportFormData.LogContents);
			form.AddField("ContainsSandbox", (_sandboxUpload != null).ToString());
			form.AddBinaryData("Log.txt", Encoding.ASCII.GetBytes(bugReportFormData.LogContents), "Log.txt");
			form.AddField("AutoReport", bugReportFormData.AutoReport.ToString().ToLower());
			if (!string.IsNullOrEmpty(bugReportFormData.DesignerCraft))
			{
				form.AddBinaryData("DesignerCraft.xml", Encoding.UTF8.GetBytes(bugReportFormData.DesignerCraft), "DesignerCraft.xml");
			}
			if (!string.IsNullOrEmpty(bugReportFormData.CelestialBody))
			{
				form.AddBinaryData("CelestialBody.xml", Encoding.UTF8.GetBytes(bugReportFormData.CelestialBody), "CelestialBody.xml");
			}
			if (!string.IsNullOrEmpty(bugReportFormData.PlanetarySystem))
			{
				form.AddBinaryData("PlanetarySystem.xml", Encoding.UTF8.GetBytes(bugReportFormData.PlanetarySystem), "PlanetarySystem.xml");
			}
			if (!string.IsNullOrEmpty(bugReportFormData.Settings))
			{
				form.AddBinaryData("Settings.xml", Encoding.UTF8.GetBytes(bugReportFormData.Settings), "Settings.xml");
			}
			if (bugReportFormData.Screenshots != null)
			{
				foreach (KeyValuePair<string, byte[]> screenshot in bugReportFormData.Screenshots)
				{
					form.AddBinaryData(screenshot.Key, screenshot.Value);
				}
			}
			if (!string.IsNullOrEmpty(bugReportFormData.InputState))
			{
				form.AddBinaryData("Inputs.txt", Encoding.ASCII.GetBytes(bugReportFormData.InputState), "Inputs.txt");
			}
			return form;
		}
	}
}
