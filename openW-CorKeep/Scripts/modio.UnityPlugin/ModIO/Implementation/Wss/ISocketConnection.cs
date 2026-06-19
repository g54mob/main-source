using System;
using System.Threading.Tasks;
using ModIO.Implementation.Wss.Messages;

namespace ModIO.Implementation.Wss
{
	internal interface ISocketConnection
	{
		bool Connected();

		Task<Result> SendData(WssMessages message);

		Task<Result> SetupConnection(string url, Action<WssMessages> onReceiveMessage, Action onDisconnect);

		Task CloseConnection();
	}
}
