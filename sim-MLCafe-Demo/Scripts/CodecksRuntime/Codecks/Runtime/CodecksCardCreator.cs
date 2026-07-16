using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Codecks.Runtime
{
	public class CodecksCardCreator : MonoBehaviour
	{
		public delegate void CardCreationResultDelegate(bool success, string result);

		public enum CodecksFileType
		{
			Binary = 0,
			PlainText = 1,
			JSON = 2,
			PNG = 3,
			JPG = 4
		}

		public enum CodecksSeverity
		{
			None = 0,
			Low = 1,
			High = 2,
			Critical = 3
		}

		public string codecksURL = "https://api.codecks.io/user-report/v1/create-report";

		public string defaultToken;

		private string loadedToken;

		private void IL2CPPCompatibility()
		{
			new List<CardCreateFileResponseData>();
			throw new Exception("Never call this!");
		}

		private void Start()
		{
			TextAsset textAsset = Resources.Load<TextAsset>("Codecks/codecksToken");
			if (textAsset != null)
			{
				loadedToken = textAsset.text;
			}
		}

		private static UnityWebRequest HttpPost(string url, string bodyJsonString)
		{
			UnityWebRequest unityWebRequest = new UnityWebRequest(url, "POST");
			byte[] bytes = Encoding.UTF8.GetBytes(bodyJsonString);
			unityWebRequest.uploadHandler = new UploadHandlerRaw(bytes);
			unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
			unityWebRequest.SetRequestHeader("Content-Type", "application/json");
			return unityWebRequest;
		}

		public void CreateNewCard(string text, Dictionary<string, (byte[], CodecksFileType)> files = null, CodecksSeverity severity = CodecksSeverity.None, string userEmail = null, CardCreationResultDelegate resultDelegate = null)
		{
			if (files != null && files.Any((KeyValuePair<string, (byte[], CodecksFileType)> f) => f.Value.Item1 == null))
			{
				throw new Exception("Null file in files list");
			}
			StartCoroutine(CreateNewCardCoroutine(text, files, severity, userEmail, resultDelegate));
		}

		public void CreateNewCard(string text, CodecksSeverity severity = CodecksSeverity.None, string userEmail = null, CardCreationResultDelegate resultDelegate = null)
		{
			StartCoroutine(CreateNewCardCoroutine(text, null, severity, userEmail, resultDelegate));
		}

		private IEnumerator CreateNewCardCoroutine(string text, Dictionary<string, (byte[], CodecksFileType)> files = null, CodecksSeverity severity = CodecksSeverity.None, string userEmail = null, CardCreationResultDelegate resultDelegate = null)
		{
			string text2 = (string.IsNullOrEmpty(loadedToken) ? defaultToken : loadedToken);
			if (string.IsNullOrEmpty(text2))
			{
				resultDelegate?.Invoke(success: false, "empty codecks token");
				yield break;
			}
			if (files == null)
			{
				files = new Dictionary<string, (byte[], CodecksFileType)>();
			}
			UnityWebRequest request;
			try
			{
				string url = codecksURL + "?token=" + text2;
				string severity2 = severity switch
				{
					CodecksSeverity.Low => "low", 
					CodecksSeverity.High => "high", 
					CodecksSeverity.Critical => "critical", 
					_ => null, 
				};
				string bodyJsonString = JsonConvert.SerializeObject(new CardCreateRequestData
				{
					content = text,
					fileNames = files.Keys.ToList(),
					severity = severity2,
					userEmail = userEmail
				}).Replace(",\"severity\":null", "");
				request = HttpPost(url, bodyJsonString);
			}
			catch (Exception arg)
			{
				resultDelegate?.Invoke(success: false, $"exception sending initial request: {arg}");
				yield break;
			}
			yield return request.SendWebRequest();
			if (request.result != UnityWebRequest.Result.Success)
			{
				resultDelegate?.Invoke(success: false, $"request unsuccessful: {request.result}  {request.error}");
				yield break;
			}
			string text3 = request.downloadHandler.text;
			CardCreateResponseData response;
			try
			{
				response = JsonConvert.DeserializeObject<CardCreateResponseData>(text3);
			}
			catch (Exception arg2)
			{
				resultDelegate?.Invoke(success: false, $"exception deserializing response: {arg2}");
				yield break;
			}
			if (!response.ok)
			{
				resultDelegate?.Invoke(success: true, "Codecks OK = false " + text3);
				yield break;
			}
			CardCreateFileResponseData[] uploadUrls = response.uploadUrls;
			for (int i = 0; i < uploadUrls.Length; i++)
			{
				CardCreateFileResponseData uploadUrl = uploadUrls[i];
				if (!files.ContainsKey(uploadUrl.fileName))
				{
					throw new Exception("Unexpected file in uploadUrls " + uploadUrl.fileName);
				}
				List<IMultipartFormSection> list = new List<IMultipartFormSection>();
				foreach (KeyValuePair<string, string> field in uploadUrl.fields)
				{
					list.Add(new MultipartFormDataSection(field.Key, field.Value));
				}
				(byte[], CodecksFileType) fileData = files[uploadUrl.fileName];
				string text4 = fileData.Item2 switch
				{
					CodecksFileType.PlainText => "text/plain", 
					CodecksFileType.JSON => "application/json", 
					CodecksFileType.PNG => "image/png", 
					CodecksFileType.JPG => "image/jpeg", 
					_ => "application/octet-stream", 
				};
				list.Add(new MultipartFormDataSection("Content-Type", text4));
				list.Add(new MultipartFormFileSection("file", fileData.Item1, uploadUrl.fileName, text4));
				UnityWebRequest uploadRequest = UnityWebRequest.Post(uploadUrl.url, list);
				yield return uploadRequest.SendWebRequest();
				if (uploadRequest.result != UnityWebRequest.Result.Success)
				{
					resultDelegate?.Invoke(success: false, "Error uploading file " + uploadUrl.fileName + " to " + uploadUrl.url + $" with {fileData.Item1.Length} bytes: {uploadRequest.error}");
					yield break;
				}
			}
			resultDelegate?.Invoke(success: true, response.cardId);
		}
	}
}
