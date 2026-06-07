using System;
using PlayFab;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions
{
	public class PlayFabApiException : Exception
	{
		private PlayFabError _error;

		public override string Message => null;

		private PlayFabApiException()
		{
		}

		public static PlayFabApiException FromPlayFabError(PlayFabError error)
		{
			return null;
		}

		public int GetErrorCode()
		{
			return 0;
		}

		public string GetErrorMessage()
		{
			return null;
		}
	}
}
