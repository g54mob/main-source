using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Muna;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace VideoKit.Internal
{
	[DefaultExecutionOrder(-10000)]
	public sealed class VideoKitClient : ScriptableObject
	{
		[SerializeField]
		[HideInInspector]
		public string url = "https://www.videokit.ai/api";

		public const string Version = "1.0.11";

		[SerializeField]
		[HideInInspector]
		private string? authToken = string.Empty;

		private global::Muna.Muna? _muna;

		private string? sessionToken;

		public const string URL = "https://www.videokit.ai/api";

		private const string SessionTokenKey = "ai.videokit.session";

		public global::Muna.Muna muna => _muna ?? (_muna = MunaUnity.Create(authToken, url + "/muna"));

		public static VideoKitClient? Instance { get; internal set; }

		public async Task<VideoKit.Status> CheckSession()
		{
			try
			{
				if (VideoKit.SetSessionToken(sessionToken) == VideoKit.Status.Ok)
				{
					return VideoKit.Status.Ok;
				}
				string value = await CreateSessionToken();
				VideoKit.Status num = VideoKit.SetSessionToken(value);
				if (num == VideoKit.Status.Ok)
				{
					sessionToken = value;
					PlayerPrefs.SetString("ai.videokit.session", value);
				}
				return num;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("VideoKit: Failed to check session with error: " + ex.Message);
				return VideoKit.Status.InvalidOperation;
			}
		}

		public static VideoKitClient Create(string? token, string? url = null)
		{
			VideoKitClient videoKitClient = ScriptableObject.CreateInstance<VideoKitClient>();
			videoKitClient.authToken = token;
			videoKitClient.url = ((!string.IsNullOrEmpty(url)) ? url : videoKitClient.url);
			return videoKitClient;
		}

		private void Awake()
		{
			if (!Application.isEditor)
			{
				Instance = (Instance ? Instance : this);
				sessionToken = (PlayerPrefs.HasKey("ai.videokit.session") ? PlayerPrefs.GetString("ai.videokit.session") : null);
			}
		}

		internal static async Task<string> CreateAuthToken(string platform, string apiKey, string? url = "https://www.videokit.ai/api")
		{
			using HttpClient request = new HttpClient();
			request.DefaultRequestHeaders.Authorization = ((!string.IsNullOrEmpty(apiKey)) ? new AuthenticationHeaderValue("Bearer", apiKey) : null);
			string value = Marshal.PtrToStringUTF8(VideoKit.GetVersion());
			string content = JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				["platform"] = platform,
				["version"] = value
			});
			using StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			using HttpResponseMessage response = await request.PostAsync(url + "/build", content2);
			string text = await response.Content.ReadAsStringAsync();
			Dictionary<string, string> dictionary;
			try
			{
				dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
			}
			catch
			{
				throw new InvalidOperationException($"Failed to create build token with status {response.StatusCode} and error: {text}");
			}
			if (dictionary.TryGetValue("error", out var value2))
			{
				throw new InvalidOperationException(value2);
			}
			return dictionary["token"];
		}

		private async Task<string?> CreateSessionToken()
		{
			StringBuilder stringBuilder = new StringBuilder(2048);
			VideoKit.GetSessionIdentifier(stringBuilder, stringBuilder.Capacity);
			string s = JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				["buildToken"] = authToken,
				["sessionId"] = stringBuilder.ToString()
			});
			using UnityWebRequest request = new UnityWebRequest(url + "/session/v3", "POST")
			{
				uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(s)),
				downloadHandler = new DownloadHandlerBuffer(),
				disposeDownloadHandlerOnDispose = true,
				disposeUploadHandlerOnDispose = true,
				timeout = 20
			};
			request.SetRequestHeader("Content-Type", "application/json");
			request.SendWebRequest();
			while (!request.isDone)
			{
				await Task.Yield();
			}
			Dictionary<string, string> dictionary;
			try
			{
				dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.downloadHandler.text);
			}
			catch
			{
				throw new InvalidOperationException($"Failed to create session token with status {request.responseCode} and error: {request.downloadHandler.text}");
			}
			if (dictionary.TryGetValue("error", out var value))
			{
				throw new InvalidOperationException(value);
			}
			return dictionary["token"];
		}
	}
}
