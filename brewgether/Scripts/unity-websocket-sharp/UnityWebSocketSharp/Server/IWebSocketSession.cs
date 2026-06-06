using System;

namespace UnityWebSocketSharp.Server
{
	internal interface IWebSocketSession
	{
		string ID { get; }

		DateTime StartTime { get; }

		WebSocket WebSocket { get; }
	}
}
