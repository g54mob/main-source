using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class WebRpcResponse
	{
		public string Name { get; private set; }

		public int ResultCode { get; private set; }

		[Obsolete("Use ResultCode instead")]
		public int ReturnCode => 0;

		public string Message { get; private set; }

		[Obsolete("Use Message instead")]
		public string DebugMessage => null;

		public Dictionary<string, object> Parameters { get; private set; }

		public WebRpcResponse(OperationResponse response)
		{
		}

		public string ToStringFull()
		{
			return null;
		}
	}
}
