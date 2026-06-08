using System.Collections.Generic;
using System.IO;
using MLAPI.Connection;
using MLAPI.Messaging;
using MLAPI.Serialization.Pooled;
using UnityEngine;
using UnityEngine.AI;

namespace MLAPI.Prototyping
{
	[AddComponentMenu("MLAPI/NetworkedNavMeshAgent")]
	public class NetworkedNavMeshAgent : NetworkedBehaviour
	{
		private NavMeshAgent agent;

		public bool EnableProximity;

		public float ProximityRange = 50f;

		public float CorrectionDelay = 3f;

		[Tooltip("Everytime a correction packet is received. This is the percentage (between 0 & 1) that we will move towards the goal.")]
		public float DriftCorrectionPercentage = 0.1f;

		public bool WarpOnDestinationChange;

		private Vector3 lastDestination = Vector3.zero;

		private float lastCorrectionTime;

		private void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			if (!base.IsOwner)
			{
				return;
			}
			if (agent.destination != lastDestination)
			{
				lastDestination = agent.destination;
				using PooledBitStream stream = PooledBitStream.Get();
				using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
				pooledBitWriter.WriteSinglePacked(agent.destination.x);
				pooledBitWriter.WriteSinglePacked(agent.destination.y);
				pooledBitWriter.WriteSinglePacked(agent.destination.z);
				pooledBitWriter.WriteSinglePacked(agent.velocity.x);
				pooledBitWriter.WriteSinglePacked(agent.velocity.y);
				pooledBitWriter.WriteSinglePacked(agent.velocity.z);
				pooledBitWriter.WriteSinglePacked(base.transform.position.x);
				pooledBitWriter.WriteSinglePacked(base.transform.position.y);
				pooledBitWriter.WriteSinglePacked(base.transform.position.z);
				if (!EnableProximity)
				{
					InvokeClientRpcOnEveryonePerformance(OnNavMeshStateUpdate, stream);
				}
				else
				{
					List<ulong> list = new List<ulong>();
					foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in NetworkingManager.Singleton.ConnectedClients)
					{
						if (connectedClient.Value.PlayerObject == null || Vector3.Distance(connectedClient.Value.PlayerObject.transform.position, base.transform.position) <= ProximityRange)
						{
							list.Add(connectedClient.Key);
						}
					}
					InvokeClientRpcPerformance(OnNavMeshStateUpdate, list, stream);
				}
			}
			if (!(NetworkingManager.Singleton.NetworkTime - lastCorrectionTime >= CorrectionDelay))
			{
				return;
			}
			using (PooledBitStream stream2 = PooledBitStream.Get())
			{
				using PooledBitWriter pooledBitWriter2 = PooledBitWriter.Get(stream2);
				pooledBitWriter2.WriteSinglePacked(agent.velocity.x);
				pooledBitWriter2.WriteSinglePacked(agent.velocity.y);
				pooledBitWriter2.WriteSinglePacked(agent.velocity.z);
				pooledBitWriter2.WriteSinglePacked(base.transform.position.x);
				pooledBitWriter2.WriteSinglePacked(base.transform.position.y);
				pooledBitWriter2.WriteSinglePacked(base.transform.position.z);
				if (!EnableProximity)
				{
					InvokeClientRpcOnEveryonePerformance(OnNavMeshCorrectionUpdate, stream2);
				}
				else
				{
					List<ulong> list2 = new List<ulong>();
					foreach (KeyValuePair<ulong, NetworkedClient> connectedClient2 in NetworkingManager.Singleton.ConnectedClients)
					{
						if (connectedClient2.Value.PlayerObject == null || Vector3.Distance(connectedClient2.Value.PlayerObject.transform.position, base.transform.position) <= ProximityRange)
						{
							list2.Add(connectedClient2.Key);
						}
					}
					InvokeClientRpcPerformance(OnNavMeshCorrectionUpdate, list2, stream2);
				}
			}
			lastCorrectionTime = NetworkingManager.Singleton.NetworkTime;
		}

		[ClientRPC]
		private void OnNavMeshStateUpdate(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			float x = pooledBitReader.ReadSinglePacked();
			float y = pooledBitReader.ReadSinglePacked();
			float z = pooledBitReader.ReadSinglePacked();
			float x2 = pooledBitReader.ReadSinglePacked();
			float y2 = pooledBitReader.ReadSinglePacked();
			float z2 = pooledBitReader.ReadSinglePacked();
			float x3 = pooledBitReader.ReadSinglePacked();
			float y3 = pooledBitReader.ReadSinglePacked();
			float z3 = pooledBitReader.ReadSinglePacked();
			Vector3 destination = new Vector3(x, y, z);
			Vector3 velocity = new Vector3(x2, y2, z2);
			Vector3 vector = new Vector3(x3, y3, z3);
			if (WarpOnDestinationChange)
			{
				agent.Warp(vector);
			}
			else
			{
				agent.Warp(Vector3.Lerp(base.transform.position, vector, DriftCorrectionPercentage));
			}
			agent.SetDestination(destination);
			agent.velocity = velocity;
		}

		[ClientRPC]
		private void OnNavMeshCorrectionUpdate(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			float x = pooledBitReader.ReadSinglePacked();
			float y = pooledBitReader.ReadSinglePacked();
			float z = pooledBitReader.ReadSinglePacked();
			float x2 = pooledBitReader.ReadSinglePacked();
			float y2 = pooledBitReader.ReadSinglePacked();
			float z2 = pooledBitReader.ReadSinglePacked();
			Vector3 velocity = new Vector3(x, y, z);
			Vector3 b = new Vector3(x2, y2, z2);
			agent.Warp(Vector3.Lerp(base.transform.position, b, DriftCorrectionPercentage));
			agent.velocity = velocity;
		}
	}
}
