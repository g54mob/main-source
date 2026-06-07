using BestHTTP.SignalR.Hubs;

namespace BestHTTP.SignalR.Messages
{
	public struct ClientMessage
	{
		public readonly Hub Hub;

		public readonly string Method;

		public readonly object[] Args;

		public readonly ulong CallIdx;

		public readonly OnMethodResultDelegate ResultCallback;

		public readonly OnMethodFailedDelegate ResultErrorCallback;

		public readonly OnMethodProgressDelegate ProgressCallback;

		public ClientMessage(Hub hub, string method, object[] args, ulong callIdx, OnMethodResultDelegate resultCallback, OnMethodFailedDelegate resultErrorCallback, OnMethodProgressDelegate progressCallback)
		{
			Hub = null;
			Method = null;
			Args = null;
			CallIdx = 0uL;
			ResultCallback = null;
			ResultErrorCallback = null;
			ProgressCallback = null;
		}
	}
}
