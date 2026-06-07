using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace Mirror.Discovery
{
	[DisallowMultipleComponent]
	public abstract class NetworkDiscoveryBase<Request, Response> : MonoBehaviour where Request : NetworkMessage where Response : NetworkMessage
	{
		[HideInInspector]
		public long secretHandshake;

		[SerializeField]
		protected int serverBroadcastListenPort;

		[SerializeField]
		public bool enableActiveDiscovery;

		[SerializeField]
		private float ActiveDiscoveryInterval;

		protected UdpClient serverUdpClient;

		protected UdpClient clientUdpClient;

		public static bool SupportedOnThisPlatform => false;

		public static long RandomLong()
		{
			return 0L;
		}

		public virtual void Start()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void Shutdown()
		{
		}

		public void AdvertiseServer()
		{
		}

		public Task ServerListenAsync()
		{
			return null;
		}

		private Task ReceiveRequestAsync(UdpClient udpClient)
		{
			return null;
		}

		protected virtual void ProcessClientRequest(Request request, IPEndPoint endpoint)
		{
		}

		protected abstract Response ProcessRequest(Request request, IPEndPoint endpoint);

		public void StartDiscovery()
		{
		}

		public void StopDiscovery()
		{
		}

		public Task ClientListenAsync()
		{
			return null;
		}

		public void BroadcastDiscoveryRequest()
		{
		}

		protected virtual Request GetRequest()
		{
			return default(Request);
		}

		private Task ReceiveGameBroadcastAsync(UdpClient udpClient)
		{
			return null;
		}

		protected abstract void ProcessResponse(Response response, IPEndPoint endpoint);
	}
}
