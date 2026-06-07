using FishNet.Transporting;

namespace Assets.Scripts.Multiplayer.Utils
{
	public static class ProfilerUtils
	{
		public static string GetPacketCategory(PacketId id)
		{
			switch (id)
			{
			case PacketId.ServerRpc:
			case PacketId.ObserversRpc:
			case PacketId.TargetRpc:
				return "RPC";
			case PacketId.ObjectSpawn:
			case PacketId.ObjectDespawn:
			case PacketId.PredictedSpawnResult:
			case PacketId.BulkSpawnOrDespawn:
				return "Spawning / Despawning";
			case PacketId.Replicate:
				return "State Sync (Replication)";
			case PacketId.Reconcile:
				return "State Sync (Reconcile)";
			case PacketId.SyncType:
				return "State Sync (SyncTypes)";
			case PacketId.StateUpdate:
				return "State Sync (State Update)";
			case PacketId.Broadcast:
				return "Broadcast";
			case PacketId.PingPong:
				return "Connection (Ping)";
			case PacketId.TimingUpdate:
				return "Connection (Timing)";
			case PacketId.Authenticated:
			case PacketId.OwnershipChange:
			case PacketId.Disconnect:
			case PacketId.Version:
				return "Connection (Management)";
			default:
				return "Internal / Unset";
			}
		}
	}
}
