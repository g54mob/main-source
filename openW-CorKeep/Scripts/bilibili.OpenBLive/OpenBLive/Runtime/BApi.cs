using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenBLive.Runtime.Data;
using OpenBLive.Runtime.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenBLive.Runtime
{
	public static class BApi
	{
		public static bool isTestEnv;

		private const string k_InteractivePlayStart = "/v2/app/start";

		private const string k_InteractivePlayEnd = "/v2/app/end";

		private const string k_InteractivePlayHeartBeat = "/v2/app/heartbeat";

		private const string k_InteractivePlayBatchHeartBeat = "/v2/app/batchHeartbeat";

		private const string k_Post = "POST";

		private static string OpenLiveDomain
		{
			get
			{
				if (!isTestEnv)
				{
					return "https://live-open.biliapi.com";
				}
				return "http://test-live-open.biliapi.net";
			}
		}

		public static async Task<string> StartInteractivePlay(string code, string appId)
		{
			string url = OpenLiveDomain + "/v2/app/start";
			string param = "{\"code\":\"" + code + "\",\"app_id\":" + appId + "}";
			return await RequestWebUTF8(url, "POST", param);
		}

		public static async Task<string> EndInteractivePlay(string appId, string gameId)
		{
			string url = OpenLiveDomain + "/v2/app/end";
			string param = "{\"app_id\":" + appId + ",\"game_id\":\"" + gameId + "\"}";
			return await RequestWebUTF8(url, "POST", param);
		}

		public static async Task<string> HeartBeatInteractivePlay(string gameId)
		{
			string url = OpenLiveDomain + "/v2/app/heartbeat";
			string param = "";
			if (gameId != null)
			{
				param = "{\"game_id\":\"" + gameId + "\"}";
			}
			return await RequestWebUTF8(url, "POST", param);
		}

		public static async Task<string> BatchHeartBeatInteractivePlay(string[] gameIds)
		{
			string url = OpenLiveDomain + "/v2/app/batchHeartbeat";
			string param = JsonConvert.SerializeObject(new GameIds
			{
				gameIds = gameIds
			});
			return await RequestWebUTF8(url, "POST", param);
		}

		private static async Task<string> RequestWebUTF8(string url, string method, string param, string cookie = null)
		{
			UnityWebRequest webRequest = new UnityWebRequest(url)
			{
				method = method
			};
			if (param != null)
			{
				SignUtility.SetReqHeader(webRequest, param, cookie);
			}
			webRequest.downloadHandler = new DownloadHandlerBuffer();
			webRequest.disposeUploadHandlerOnDispose = true;
			webRequest.disposeDownloadHandlerOnDispose = true;
			await webRequest.SendWebRequest();
			string text = webRequest.downloadHandler.text;
			webRequest.Dispose();
			return text;
		}

		private static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			asyncOp.completed += delegate
			{
				tcs.SetResult(null);
			};
			return ((Task)tcs.Task).GetAwaiter();
		}
	}
}
