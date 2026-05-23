using System;
using UnityEngine;
using UnityEngine.Networking;

public struct GameTesterAuthResponse
{
	[Serializable]
	public class ResponseJson
	{
		public int code;

		public string message;

		public string playerToken;

		public string playerName;
	}

	public GameTesterResponseCode Code { get; private set; }

	public string Message { get; private set; }

	public string PlayerToken { get; private set; }

	public string PlayerName { get; private set; }

	public static GameTesterAuthResponse Parse(UnityWebRequest request)
	{
		if (request.isNetworkError || request.isHttpError)
		{
			return HttpError(request.error);
		}
		return ParseResponse(request.downloadHandler.text);
	}

	public static GameTesterAuthResponse ParseResponse(string webResult)
	{
		try
		{
			ResponseJson responseJson = JsonUtility.FromJson<ResponseJson>(webResult);
			return new GameTesterAuthResponse
			{
				Code = (GameTesterResponseCode)responseJson.code,
				Message = responseJson.message,
				PlayerToken = responseJson.playerToken,
				PlayerName = responseJson.playerName
			};
		}
		catch (Exception ex)
		{
			return new GameTesterAuthResponse
			{
				Code = GameTesterResponseCode.ResponseParseError,
				Message = ex.Message,
				PlayerToken = null,
				PlayerName = null
			};
		}
	}

	public static GameTesterAuthResponse HttpError(string error)
	{
		return new GameTesterAuthResponse
		{
			Code = GameTesterResponseCode.HttpError,
			Message = error
		};
	}

	public override string ToString()
	{
		return $"[({(int)Code}){Enum.GetName(typeof(GameTesterResponseCode), Code)}] PlayerName: {PlayerName}, {Message}";
	}
}
