using System;
using UnityEngine;
using UnityEngine.Networking;

public struct GameTesterResponse
{
	[Serializable]
	public class ResponseJson
	{
		public int code;

		public string message;
	}

	public GameTesterResponseCode Code { get; private set; }

	public string Message { get; private set; }

	public static GameTesterResponse Parse(UnityWebRequest request)
	{
		if (request.isNetworkError || request.isHttpError)
		{
			return HttpError(request.error);
		}
		return ParseResponse(request.downloadHandler.text);
	}

	public static GameTesterResponse ParseResponse(string webResult)
	{
		try
		{
			ResponseJson responseJson = JsonUtility.FromJson<ResponseJson>(webResult);
			return new GameTesterResponse
			{
				Code = (GameTesterResponseCode)responseJson.code,
				Message = responseJson.message
			};
		}
		catch (Exception ex)
		{
			return new GameTesterResponse
			{
				Code = GameTesterResponseCode.ResponseParseError,
				Message = ex.Message
			};
		}
	}

	public static GameTesterResponse HttpError(string error)
	{
		return new GameTesterResponse
		{
			Code = GameTesterResponseCode.HttpError,
			Message = error
		};
	}

	public override string ToString()
	{
		return $"[({(int)Code}){Enum.GetName(typeof(GameTesterResponseCode), Code)}] {Message}";
	}
}
