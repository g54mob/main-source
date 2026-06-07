using Cysharp.Threading.Tasks;
using FishNet.Connection;

namespace Assets.Scripts.Multiplayer
{
	public class AsyncClientNetworkRequest<TRequestData, TResultData> : AsyncNetworkRequest<TRequestData, TResultData>
	{
		public AsyncClientNetworkRequest(int timeout, SendClientRequestDelegate sendRequestDelegate, SendServerResultDelegate sendResultDelegate = null)
			: base(timeout, sendRequestDelegate, sendResultDelegate)
		{
		}

		public UniTask<Result> SendRequest(TRequestData data, NetworkConnection targetClient)
		{
			return SendRequestAsync(data, targetClient);
		}

		public void SendResult(int requestId, TResultData resultData)
		{
			SendNetworkResult(requestId, resultData);
		}
	}
}
