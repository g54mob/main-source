using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class GameTester
{
	public static class Api
	{
		public static IEnumerator Auth(Action<GameTesterAuthResponse> callback)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("developerToken", developerToken);
			if (PlayerAuthenticationMode == GameTesterPlayerAuthenticationMode.Pin)
			{
				dictionary.Add("playerPin", connectTokenOrPin);
			}
			else
			{
				dictionary.Add("connectToken", connectTokenOrPin);
			}
			return doPost("/auth", dictionary, delegate(GameTesterAuthResponse o)
			{
				if (doLogging)
				{
					Debug.Log(o);
				}
				if (o.Code == GameTesterResponseCode.Success)
				{
					playerToken = o.PlayerToken;
					PlayerName = o.PlayerName;
					PlayerAuthenticated = true;
				}
				callback(o);
			}, GameTesterAuthResponse.Parse);
		}

		public static IEnumerator Datapoint(int datapointId, Action<GameTesterResponse> callback)
		{
			Dictionary<string, object> dictionary = createApiObject();
			dictionary.Add("datapointId", datapointId);
			if (doLogging)
			{
				return doPost(string.Empty, dictionary, delegate(GameTesterResponse o)
				{
					Debug.Log(o);
					callback(o);
				}, GameTesterResponse.Parse);
			}
			return doPost(string.Empty, dictionary, callback, GameTesterResponse.Parse);
		}

		public static IEnumerator UnlockTest(Action<GameTesterResponse> callback)
		{
			Dictionary<string, object> body = createApiObject();
			if (doLogging)
			{
				return doPost("/unlock", body, delegate(GameTesterResponse o)
				{
					Debug.Log(o);
					callback(o);
				}, GameTesterResponse.Parse);
			}
			return doPost("/unlock", body, callback, GameTesterResponse.Parse);
		}
	}

	private static Dictionary<GameTesterMode, string> serverUrls;

	private static string developerToken;

	private static string connectTokenOrPin;

	private static string playerToken;

	private static bool doLogging;

	private static string serverUrl => serverUrls[Mode];

	public static bool Initialized { get; private set; }

	public static GameTesterMode Mode { get; private set; }

	public static bool PlayerAuthenticated { get; private set; }

	public static GameTesterPlayerAuthenticationMode PlayerAuthenticationMode { get; private set; }

	public static string PlayerName { get; private set; }

	static GameTester()
	{
		serverUrls = new Dictionary<GameTesterMode, string>
		{
			{
				GameTesterMode.Production,
				"https://server.gametester.gg/dev-api/v1"
			},
			{
				GameTesterMode.Sandbox,
				"https://server.gametester.gg/dev-api/v1/sandbox"
			}
		};
		Initialized = false;
		Mode = GameTesterMode.Sandbox;
		PlayerAuthenticated = false;
		PlayerAuthenticationMode = GameTesterPlayerAuthenticationMode.Pin;
	}

	public static void Initialize(GameTesterMode mode, string developerToken, bool debugLogging = false)
	{
		Mode = mode;
		GameTester.developerToken = developerToken;
		Initialized = true;
		doLogging = debugLogging;
	}

	private static Dictionary<string, object> createApiObject()
	{
		return new Dictionary<string, object>
		{
			{ "developerToken", developerToken },
			{ "playerToken", playerToken }
		};
	}

	private static IEnumerator doPost<T>(string subUrl, Dictionary<string, object> body, Action<T> callback, Func<UnityWebRequest, T> parser)
	{
		string text = $"{serverUrl}{subUrl}";
		using UnityWebRequest request = new UnityWebRequest(text, "POST");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('{');
		int num = 0;
		foreach (KeyValuePair<string, object> item in body)
		{
			stringBuilder.Append('"');
			stringBuilder.Append(item.Key);
			stringBuilder.Append('"');
			stringBuilder.Append(':');
			if (item.Value is string)
			{
				stringBuilder.Append('"');
				stringBuilder.Append(item.Value);
				stringBuilder.Append('"');
			}
			else
			{
				stringBuilder.Append(item.Value);
			}
			if (num < body.Count - 1)
			{
				stringBuilder.Append(',');
			}
			num++;
		}
		stringBuilder.Append('}');
		string text2 = stringBuilder.ToString();
		if (doLogging)
		{
			Debug.Log("POST (" + text + "): " + text2);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(text2);
		request.uploadHandler = new UploadHandlerRaw(bytes);
		request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");
		yield return request.SendWebRequest();
		T obj = parser(request);
		callback(obj);
	}

	public static void SetPlayerPin(string pin)
	{
		connectTokenOrPin = pin;
		PlayerAuthenticationMode = GameTesterPlayerAuthenticationMode.Pin;
	}

	public static void SetPlayerToken(string token)
	{
		connectTokenOrPin = token;
		PlayerAuthenticationMode = GameTesterPlayerAuthenticationMode.ConnectToken;
	}
}
