using Mirror;
using UnityEngine;

namespace Aggro.Core.Networking
{
	public static class NetworkUtil
	{
		public static bool IsSimulatingLatency()
		{
			return Transport.active is LatencySimulation;
		}

		public static void EnableSimulatedLatency(float latency, float packetLoss)
		{
			LatencySimulation component = Transport.active.GetComponent<LatencySimulation>();
			component.latency = latency;
			component.unreliableLoss = packetLoss;
			component.unreliableScramble = packetLoss;
			Transport.active = component;
		}

		public static void DisableSimulatedLatency()
		{
			Transport.active = NetworkManager.singleton.transport;
		}

		public static bool TryGetEntity(this NetworkIdentity id, out Entity entity)
		{
			entity = id.GetEntity();
			if (entity.Exists())
			{
				return true;
			}
			entity = Entity.invalid;
			return false;
		}

		public static Entity GetEntity(this NetworkIdentity id)
		{
			if (id.TryGetComponent<EntityBehaviour>(out var component))
			{
				return component.entity;
			}
			return Entity.invalid;
		}

		public static bool TryGetEntity(this PredictedRigidbody predictedRigidbody, out Entity entity)
		{
			return predictedRigidbody.netIdentity.TryGetEntity(out entity);
		}

		public static Entity GetEntity(this PredictedRigidbody predictedRigidbody)
		{
			return predictedRigidbody.netIdentity.GetEntity();
		}

		[Server]
		public static double ServerGetPing(NetworkConnectionToClient conn)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Double Aggro.Core.Networking.NetworkUtil::ServerGetPing(Mirror.NetworkConnectionToClient)' called when server was not active");
				return default(double);
			}
			return conn.rtt;
		}

		public static void FindSetNetworkManagers()
		{
			MonoBehaviour[] array = Object.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is IAggroManager aggroManager)
				{
					aggroManager.SetAsManager();
				}
			}
		}
	}
}
