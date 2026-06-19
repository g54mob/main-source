using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.MultiplayerModels
{
	[Serializable]
	public class ShutdownMultiplayerServerRequest : PlayFabRequestCommon
	{
		[Obsolete("No longer available", true)]
		public string BuildId;

		public Dictionary<string, string> CustomTags;

		[Obsolete("No longer available", true)]
		public string Region;

		public string SessionId;
	}
}
