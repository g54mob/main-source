using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenBLive.Runtime.Data
{
	public class AppStartInfo
	{
		[JsonProperty("code")]
		public int Code;

		[JsonProperty("message")]
		public string Message;

		[JsonProperty("data")]
		public AppStartInfoData Data;

		public string GetGameId()
		{
			return Data?.GameInfo?.GameId;
		}

		public IList<string> GetWssLink()
		{
			return Data?.WebsocketInfo?.WssLink;
		}

		public string GetAuthBody()
		{
			return Data?.WebsocketInfo?.AuthBody;
		}
	}
}
