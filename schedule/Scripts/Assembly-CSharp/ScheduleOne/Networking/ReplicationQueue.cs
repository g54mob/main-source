using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.Networking
{
	public class ReplicationQueue : NetworkSingleton<ReplicationQueue>
	{
		public class ReplicationRequest
		{
			public string TaskName;

			public NetworkConnection Target;

			public Action<NetworkConnection> Callback;

			public int ApproximateSizeBytes;

			public bool IsValid()
			{
				return false;
			}
		}

		public const int RATE_LIMIT_BYTES_PER_SECOND = 51200;

		public const int MAX_REPLICATION_DURATION = 45;

		private Dictionary<NetworkConnection, List<ReplicationRequest>> requestsByConnection;

		private List<ReplicationRequest> queue;

		private int currentByteBudget;

		private float timeOnLastReplicationTaskRPC;

		private float timeOnReplicationStart;

		private bool NetworkInitialize___EarlyScheduleOne_002ENetworking_002EReplicationQueueAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENetworking_002EReplicationQueueAssembly_002DCSharp_002Edll_Excuted;

		public bool ReplicationDoneForLocalPlayer { get; private set; }

		public bool LocalPlayerReplicationTimedOut => false;

		public string CurrentReplicationTask { get; private set; }

		public static void Enqueue(string taskName, NetworkConnection target, Action<NetworkConnection> callback, int approximateSizeBytes = 32)
		{
		}

		public static float GetReplicationDuration(int approximateSizeBytes)
		{
			return 0f;
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		[TargetRpc]
		private void SetReplicationDone(NetworkConnection conn)
		{
		}

		[TargetRpc]
		private void SetReplicationTask(NetworkConnection conn, string task)
		{
		}

		private void Enqueue_(string taskName, NetworkConnection target, Action<NetworkConnection> callback, int approximateSizeBytes = 32)
		{
		}

		private void Update()
		{
		}

		private void NotifyActiveReplicationTask(ReplicationRequest request)
		{
		}

		public List<ReplicationRequest> GetRequestsForConnection(NetworkConnection conn)
		{
			return null;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Target_SetReplicationDone_328543758(NetworkConnection conn)
		{
		}

		private void RpcLogic___SetReplicationDone_328543758(NetworkConnection conn)
		{
		}

		private void RpcReader___Target_SetReplicationDone_328543758(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_SetReplicationTask_2971853958(NetworkConnection conn, string task)
		{
		}

		private void RpcLogic___SetReplicationTask_2971853958(NetworkConnection conn, string task)
		{
		}

		private void RpcReader___Target_SetReplicationTask_2971853958(PooledReader PooledReader0, Channel channel)
		{
		}

		public override void Awake()
		{
		}
	}
}
