using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;

namespace TwitchIntegration
{
	public class TwitchAuthenticator : MonoBehaviour
	{
		private TwitchSettings settings;

		private static HttpListener listener;

		private static Thread listenerThread;

		private OAuth oauth;

		private const float Timeout = 10f;

		public bool IsAuthenticated { get; private set; }

		private void Awake()
		{
			ClearHttpListener();
			settings = Resources.Load<TwitchSettings>("TwitchSettings");
			IsAuthenticated = CheckAuthenticationStatus();
		}

		private void OnDestroy()
		{
			ClearHttpListener();
		}

		private void ClearHttpListener()
		{
			if (listener != null)
			{
				if (listener.IsListening)
				{
					listener.Stop();
				}
				listener.Close();
				listener = null;
			}
			if (listenerThread != null)
			{
				listenerThread.Abort();
				listenerThread = null;
			}
		}

		public void Deauth()
		{
			IsAuthenticated = false;
			PlayerPrefs.DeleteKey("TwitchAuth__Username");
			PlayerPrefs.DeleteKey("TwitchAuth__ChannelName");
			PlayerPrefs.DeleteKey("TwitchAuth__OAuthToken");
			PlayerPrefs.DeleteKey("TwitchAuth__Authenticated");
		}

		public string GetClientId()
		{
			return settings.clientId;
		}

		public string GetAccessToken()
		{
			if (!IsAuthenticated)
			{
				return null;
			}
			return oauth.accessToken;
		}

		private bool CheckAuthenticationStatus()
		{
			if (!PlayerPrefs.HasKey("TwitchAuth__OAuthToken"))
			{
				Log("Twitch client unauthenticated", "yellow");
				return false;
			}
			try
			{
				oauth = JsonUtility.FromJson<OAuth>(PlayerPrefs.GetString("TwitchAuth__OAuthToken"));
				if (string.IsNullOrEmpty(oauth.accessToken))
				{
					throw new TwitchCommandException("Invalid Twitch client access token");
				}
				IsAuthenticated = true;
				Log("Twitch client authenticated", "green");
			}
			catch (TwitchCommandException ex)
			{
				Log(ex.Message, "red");
			}
			return IsAuthenticated;
		}

		internal void TryAuthenticate(string username, string channelName, Action<bool> onComplete)
		{
			if (listener == null && listenerThread == null)
			{
				PlayerPrefs.SetString("TwitchAuth__Username", username);
				PlayerPrefs.SetString("TwitchAuth__ChannelName", channelName);
				StartCoroutine(TryAuthenticateCoroutine(onComplete));
			}
		}

		private IEnumerator TryAuthenticateCoroutine(Action<bool> onComplete)
		{
			string redirectUri = settings.redirectUri;
			int port = new Uri(redirectUri).Port;
			listener = new HttpListener();
			listener.Prefixes.Add($"http://*:{port}/");
			listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
			listener.Start();
			listenerThread = new Thread(StartListener);
			listenerThread.Start();
			IsAuthenticated = false;
			Application.OpenURL("https://id.twitch.tv/oauth2/authorize?client_id=" + settings.clientId + "&redirect_uri=" + redirectUri + "&response_type=token&scope=chat:read");
			float processStartTime = Time.realtimeSinceStartup;
			while (!IsAuthenticated)
			{
				if (Time.realtimeSinceStartup - processStartTime >= 10f)
				{
					Log("Authentication timed out", "red");
					onComplete(obj: false);
					ClearHttpListener();
					yield break;
				}
				yield return null;
			}
			onComplete?.Invoke(IsAuthenticated);
			ClearHttpListener();
			PlayerPrefs.SetString("TwitchAuth__OAuthToken", JsonUtility.ToJson(oauth));
			if (!PlayerPrefs.HasKey("TwitchAuth__Authenticated"))
			{
				PlayerPrefs.SetInt("TwitchAuth__Authenticated", 1);
			}
		}

		private void StartListener()
		{
			while (!IsAuthenticated)
			{
				HttpListener httpListener = listener;
				if (httpListener != null && httpListener.IsListening)
				{
					listener.BeginGetContext(GetContextCallback, listener).AsyncWaitHandle.WaitOne();
					continue;
				}
				break;
			}
		}

		private void GetContextCallback(IAsyncResult asyncResult)
		{
			HttpListenerContext httpListenerContext = listener.EndGetContext(asyncResult);
			if (httpListenerContext.Request.HttpMethod == "POST")
			{
				string json = new StreamReader(httpListenerContext.Request.InputStream, httpListenerContext.Request.ContentEncoding).ReadToEnd();
				oauth = JsonUtility.FromJson<OAuth>(json);
				IsAuthenticated = true;
			}
			listener.BeginGetContext(GetContextCallback, null);
			byte[] bytes = Encoding.UTF8.GetBytes("<html><head>\n            <script src=\"https://unpkg.com/axios/dist/axios.min.js\"></script>\n            <script>if (window.location.hash)\n            {\n                let fragments = window.location.hash.substring(1).split('&').map(x => x.split('=')[1]);\n\n                let data =\n                {\n                    accessToken: fragments[0],\n                    scope: fragments[1],\n                    state: fragments[2]\n                };\n\n                axios.post('/', data).then(function(response) {console.log(response); window.close();}).catch(function(error) {console.log(error); window.close();});\n            }\n            </script></head>");
			HttpListenerResponse response = httpListenerContext.Response;
			response.ContentType = "text/html";
			response.ContentLength64 = bytes.Length;
			response.StatusCode = 200;
			response.OutputStream.Write(bytes, 0, bytes.Length);
			response.OutputStream.Close();
		}

		private void Log(string message, string color)
		{
			if (settings.isDebugMode)
			{
				MonoBehaviour.print("<color=" + color + ">" + message + "</color>");
			}
		}
	}
}
