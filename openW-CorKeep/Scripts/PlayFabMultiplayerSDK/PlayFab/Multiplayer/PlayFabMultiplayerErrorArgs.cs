using System;

namespace PlayFab.Multiplayer
{
	public class PlayFabMultiplayerErrorArgs : EventArgs
	{
		public int Code { get; protected set; }

		public string Message { get; protected set; }

		internal PlayFabMultiplayerErrorArgs(int code, string message)
		{
			Code = code;
			Message = message;
		}
	}
}
