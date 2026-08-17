using System;
using System.Collections.Generic;
using System.Text;
using PlayFab;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;

public class PlayFabApiException : Exception
{
	private PlayFabError _error;

	public override string Message
	{
		get
		{
			PlayFabError error = _error;
			if (_error != null)
			{
				return error.ErrorMessage;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private PlayFabApiException()
	{
		Init();
	}

	public static PlayFabApiException FromPlayFabError(PlayFabError error)
	{
		PlayFabApiException ex = new PlayFabApiException();
		((Exception)ex).Init();
		if (ex != null)
		{
			ex._error = error;
			return ex;
		}
		return (PlayFabApiException)(object)new NullReferenceException();
	}

	public int GetErrorCode()
	{
		//IL_0041: Expected I4, but got O
		PlayFabError error = _error;
		if (_error != null)
		{
			return (int)error.Error;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe string GetErrorMessage()
	{
		//IL_00a2: Expected O, but got Ref
		StringBuilder stringBuilder = new StringBuilder();
		PlayFabError error = _error;
		if (_error != null && stringBuilder != null)
		{
			StringBuilder stringBuilder2 = stringBuilder.Append(error.ErrorMessage);
			PlayFabError error2 = _error;
			if (_error != null)
			{
				if (error2.ErrorDetails != null)
				{
					Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
					Dictionary<string, List<string>> dictionary = default(Dictionary<string, List<string>>);
					List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
					while (enumerator.MoveNext())
					{
						bool flag = dictionary == null;
						StringBuilder stringBuilder3 = (StringBuilder)(&enumerator);
						if (flag)
						{
							throw new NullReferenceException();
						}
						while (enumerator2.MoveNext())
						{
							StringBuilder stringBuilder4 = stringBuilder.Append(": ");
							if (stringBuilder4 != null)
							{
								StringBuilder stringBuilder5 = stringBuilder4.Append((string)null);
								continue;
							}
							throw new NullReferenceException();
						}
					}
				}
				return stringBuilder.ToString();
			}
		}
		throw new NullReferenceException();
	}
}
