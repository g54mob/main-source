using System;
using System.Collections;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Ludenio.Operator
{
	public class OperatorTools : MonoBehaviour
	{
		private const string GOOGLE_FORM_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfCIsGtWHjV-2g88hvNgvhpZ9BT5yDP0ZMwOLTkhfRz-CP0Fg/formResponse?usp=pp_url&entry.1261588415={0}&entry.757568208={1}&entry.306494734={2}&entry.1878107320={3}&entry.606271907={4}&entry.2070643435={5}&submit=Submit";

		private const string CONFIG_URL = "https://ludenio.github.io/a3/index.html";

		private const string UPLOADED_FILE_URL = "https://feedback.luden.io/{0}/{1}";

		private const string CATEGORY = "a3";

		public SuccessEvent OnConfigReceived = new SuccessEvent();

		public SuccessEvent OnFeedbackSent = new SuccessEvent();

		public OperatorConfig Config;

		private bool _isConfigHealthy;

		private bool _isConfigLoading;

		public bool IsNextDateInFuture
		{
			get
			{
				if (Config != null)
				{
					return Config.IsNextDateInFuture;
				}
				return true;
			}
		}

		public bool IsConfigHealthy => _isConfigHealthy;

		public void TryDonwloadConfig()
		{
			if (IsConfigHealthy)
			{
				Debug.Log("trying to download operator config, but it's already received and healthy");
				return;
			}
			if (_isConfigLoading)
			{
				Debug.Log("trying to download operator config, but loading is already in progress");
				return;
			}
			Debug.Log("downloading config...");
			_isConfigLoading = true;
			StartCoroutine(GetRequest("https://ludenio.github.io/a3/index.html", ConfigDownloaded));
		}

		private string GetConfigPart(ref string[] data, int defPosition, string type, string define, string lang = "")
		{
			string text = type + "_" + define;
			if (lang.Length > 0)
			{
				text = text + "_" + lang;
			}
			text += "=";
			string[] array = data;
			foreach (string text2 in array)
			{
				if (text2.StartsWith(text))
				{
					string text3 = text2.Replace(text, string.Empty);
					Debug.LogError(text3);
					return text3;
				}
			}
			if (lang.Length > 0)
			{
				return GetConfigPart(ref data, defPosition, type, define);
			}
			return data[defPosition];
		}

		private void ConfigDownloaded(bool success, DownloadHandler downloadHandler)
		{
			_isConfigLoading = false;
			Debug.Log($"downloading config... success={success}");
			if (success)
			{
				Config = new OperatorConfig();
				string[] data = downloadHandler.text.Split('\n');
				if (data.Length < 4)
				{
					Debug.LogError($"downloaded config contains less than 4 required lines, only {data.Length}");
					OnConfigReceived.Invoke(arg0: false);
				}
				else
				{
					GetConfig(ref data, "STEAM");
				}
			}
			else
			{
				OnConfigReceived.Invoke(arg0: false);
			}
		}

		private string GetLang(int langId)
		{
			return (new string[66]
			{
				"EN", "RU", "ZH_CH", "ZH_TW", "KO", "EL", "PT_BR", "DE", "PL", "FR",
				"HU", "CZ", "FI", "HE", "IT", "JA", "ES_ES", "DA", "TR", "NL",
				"UK", "UK", "EN_US", "VI", "KO", "EL", "PT_BR", "DE", "PL", "FR",
				"HU", "CZ", "FI", "HE", "IT", "JA", "ES_ES", "DA", "TR", "NL",
				"UK", "VI", "AR", "ID", "SV", "RO", "MS", "PT_PT", "BG", "NO",
				"EN", "EN", "EN", "EN", "EN", "EN", "EN", "EN", "EN", "EN",
				"EN", "EN", "EN", "EN", "EN", "EN"
			})[langId];
		}

		private void GetConfig(ref string[] data, string define = "")
		{
			string lang = GetLang(Logic.GetModel().globalSaves.lang);
			Config.Title = GetConfigPart(ref data, 0, "TITLE", define, lang);
			Config.URL = GetConfigPart(ref data, 1, "URL", define, lang);
			string configPart = GetConfigPart(ref data, 3, "TIME", define, lang);
			CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-us");
			try
			{
				Config.NextDate = DateTime.Parse(configPart, cultureInfo);
			}
			catch
			{
				Debug.LogError($"datetime in operator config is in invalid format '{configPart}'");
			}
			string configPart2 = GetConfigPart(ref data, 2, "IMAGE", define, lang);
			if (!string.IsNullOrEmpty(configPart2))
			{
				StartCoroutine(DownloadTexture(configPart2, OnTextureDownloadeded));
				return;
			}
			_isConfigHealthy = true;
			OnConfigReceived.Invoke(arg0: true);
		}

		private void OnTextureDownloadeded(bool success, DownloadHandler downloadHandler)
		{
			if (success)
			{
				try
				{
					Texture2D texture = ((DownloadHandlerTexture)downloadHandler).texture;
					Config.Sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
				}
				catch
				{
					Debug.LogError("unable to parse downloaded texture");
					Config.Sprite = null;
				}
			}
			_isConfigHealthy = success;
			OnConfigReceived.Invoke(success);
		}

		public void SendFeedback(Texture2D screenshot, byte[] saveFile, string message, string type, string userParam, string version, string specs)
		{
			string arg = DateTime.UtcNow.ToString("dd_MM_yyyy_HH_mm_ss");
			string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
			string text = $"{version}_{deviceUniqueIdentifier}_{arg}";
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char oldChar in invalidFileNameChars)
			{
				text = text.Replace(oldChar, '_');
			}
			string text2 = text + ".png";
			string text3 = text + ".save";
			if (screenshot != null)
			{
				StartCoroutine(UploadFile(screenshot.EncodeToPNG(), "a3", text2));
			}
			if (saveFile.Length != 0)
			{
				StartCoroutine(UploadFile(saveFile, "a3", text3));
			}
			string screenshotUrl = string.Format("https://feedback.luden.io/{0}/{1}", "a3", text2);
			string saveFileUrl = string.Format("https://feedback.luden.io/{0}/{1}", "a3", text3);
			if (saveFile.Length == 0)
			{
				saveFileUrl = string.Empty;
			}
			string text4 = message;
			if (text4.Length > 4000)
			{
				text4 = text4.Substring(0, 4000);
			}
			if (screenshot != null)
			{
				WriteToWebForm(message, screenshotUrl, saveFileUrl, type, userParam, version, specs);
			}
			else
			{
				WriteToWebForm(message, string.Empty, saveFileUrl, type, userParam, version, specs);
			}
		}

		private void WriteToWebForm(string message, string screenshotUrl, string saveFileUrl, string type, string userParam, string version, string specs)
		{
			Debug.Log("writing to web form...");
			string uri = string.Format("https://docs.google.com/forms/d/e/1FAIpQLSfCIsGtWHjV-2g88hvNgvhpZ9BT5yDP0ZMwOLTkhfRz-CP0Fg/formResponse?usp=pp_url&entry.1261588415={0}&entry.757568208={1}&entry.306494734={2}&entry.1878107320={3}&entry.606271907={4}&entry.2070643435={5}&submit=Submit", UnityWebRequest.EscapeURL(message), UnityWebRequest.EscapeURL(screenshotUrl), UnityWebRequest.EscapeURL(saveFileUrl), UnityWebRequest.EscapeURL(type), UnityWebRequest.EscapeURL(userParam), UnityWebRequest.EscapeURL(version), UnityWebRequest.EscapeURL(specs));
			StartCoroutine(GetRequest(uri, OnWebFormResponded));
		}

		private void OnWebFormResponded(bool success, DownloadHandler downloadHandler)
		{
			Debug.Log($"writing to web form... success={success}");
			OnFeedbackSent.Invoke(success);
		}

		private IEnumerator DownloadTexture(string url, Action<bool, DownloadHandler> onResult)
		{
			Debug.Log("downloading texture...");
			Debug.Log(url);
			using UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
			yield return webRequest.SendWebRequest();
			bool flag = webRequest.isNetworkError || webRequest.isHttpError;
			if (flag)
			{
				Debug.Log("downloading texture... error " + webRequest.error);
			}
			else
			{
				Debug.Log("downloading texture... ok");
			}
			onResult?.Invoke(!flag, webRequest.downloadHandler);
		}

		private IEnumerator GetRequest(string uri, Action<bool, DownloadHandler> onResult)
		{
			using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
			Debug.Log("sending web request...");
			yield return webRequest.SendWebRequest();
			bool flag = webRequest.isNetworkError || webRequest.isHttpError;
			if (flag)
			{
				Debug.Log("sending web request... error: " + webRequest.error);
			}
			else
			{
				Debug.Log("sending web request... ok");
			}
			onResult?.Invoke(!flag, webRequest.downloadHandler);
		}

		private IEnumerator UploadFile(byte[] bytes, string category, string fileName)
		{
			Debug.Log("uploading file...");
			float t = Time.time;
			_ = SystemInfo.deviceUniqueIdentifier;
			WWWForm wWWForm = new WWWForm();
			wWWForm.AddField("category", category);
			wWWForm.AddBinaryData("png_image", bytes, fileName);
			using UnityWebRequest webRequest = UnityWebRequest.Post("https://feedback.luden.io/cgi-bin/upload.cgi", wWWForm);
			yield return webRequest.SendWebRequest();
			if (webRequest.isNetworkError || webRequest.isHttpError)
			{
				Debug.Log("uploading file... error " + webRequest.error);
			}
			else
			{
				Debug.Log($"uploading file... done in {Time.time - t:0.00}s");
			}
		}
	}
}
