using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FishNet.Managing.Statistic
{
	[Serializable]
	public class NetworkTraficStatistics
	{
		[SerializeField]
		[Range(0f, 10f)]
		[Tooltip("How often to update traffic statistics.")]
		private float _updateInteval;

		[SerializeField]
		[Tooltip("True to update client statistics.")]
		private bool _updateClient;

		[Tooltip("True to update server statistics.")]
		[SerializeField]
		private bool _updateServer;

		private NetworkManager _networkManager;

		private ulong _client_toServerBytes;

		private ulong _client_fromServerBytes;

		private ulong _server_toClientsBytes;

		private ulong _server_fromClientsBytes;

		private float _nextUpdateTime;

		private static readonly string[] _sizeSuffixes;

		public bool UpdateClient
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool UpdateServer
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public event Action<NetworkTrafficArgs> OnClientNetworkTraffic
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<NetworkTrafficArgs> OnServerNetworkTraffic
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SetUpdateClient(bool update)
		{
		}

		public void SetUpdateServer(bool update)
		{
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}

		private void TimeManager_OnPreTick()
		{
		}

		internal void LocalClientSentData(ulong dataLength)
		{
		}

		public void LocalClientReceivedData(ulong dataLength)
		{
		}

		internal void LocalServerSentData(ulong dataLength)
		{
		}

		public void LocalServerReceivedData(ulong dataLength)
		{
		}

		public static string FormatBytesToLargest(ulong bytes)
		{
			return null;
		}
	}
}
