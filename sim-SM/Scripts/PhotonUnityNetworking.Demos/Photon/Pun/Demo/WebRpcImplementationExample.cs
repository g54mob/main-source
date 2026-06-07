using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.Demo
{
	public class WebRpcImplementationExample : MonoBehaviour, IWebRpcCallback
	{
		public const string GetGameListWebRpcMethodName = "GetGameList";

		public void OnWebRpcResponse(OperationResponse response)
		{
		}

		public void WebRpcExampleCall()
		{
		}

		public static void WebRpcCall(string methodName, object parameters = null, bool sendAuthCookieIfAny = false)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
