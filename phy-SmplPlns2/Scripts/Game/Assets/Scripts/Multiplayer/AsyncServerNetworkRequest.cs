using Cysharp.Threading.Tasks;
using FishNet.Connection;

namespace Assets.Scripts.Multiplayer
{
	public class AsyncServerNetworkRequest<TRequestData, TResultData> : AsyncNetworkRequest<TRequestData, TResultData>
	{
		public AsyncServerNetworkRequest(int timeout, SendServerRequestDelegate sendRequestDelegate, SendClientResultDelegate sendResultDelegate = null)
			: base(timeout, sendRequestDelegate, sendResultDelegate)
		{
		}

		public UniTask<Result> SendRequest(TRequestData data)
		{
			return SendRequestAsync(data);
		}

		public void SendResult(int requestId, TResultData resultData, NetworkConnection targetClient)
		{
			SendNetworkResult(requestId, resultData, targetClient);
		}
	}
}
