using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/Entity Info")]
	public sealed class EntityInfo : NetworkBehaviour
	{
		[Tooltip("The maximum and thus initial hitpoints.")]
		public float MaxHitpoints = 3f;

		[Tooltip("If true, the objects respawns at a random position instead of being destroyed.")]
		public bool RespawnOnDeath;

		public List<Vector3> SpawnPoints = new List<Vector3>();

		[SyncVar]
		private float hitpoints = 3f;

		public float CurrentHitpoints => hitpoints;

		public float Networkhitpoints
		{
			get
			{
				return hitpoints;
			}
			[param: In]
			set
			{
				GeneratedSyncVarSetter(value, ref hitpoints, 1uL, null);
			}
		}

		public void TakeDamge(float amount)
		{
			if (!base.isServer)
			{
				return;
			}
			Networkhitpoints = hitpoints - amount;
			if (hitpoints <= 0f)
			{
				if (RespawnOnDeath)
				{
					RpcRespawn();
				}
				else
				{
					Object.Destroy(base.gameObject);
				}
			}
		}

		[ClientRpc]
		private void RpcRespawn()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendRPCInternal("System.Void Polarith.AI.Package.Net.EntityInfo::RpcRespawn()", -263668023, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_RpcRespawn()
		{
			if (base.isLocalPlayer)
			{
				int num = (int)Random.Range(0f, SpawnPoints.Count);
				if (num > SpawnPoints.Count - 1)
				{
					num = SpawnPoints.Count - 1;
				}
				base.transform.position = SpawnPoints[num];
				Networkhitpoints = MaxHitpoints;
			}
		}

		protected static void InvokeUserCode_RpcRespawn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcRespawn called on server.");
			}
			else
			{
				((EntityInfo)obj).UserCode_RpcRespawn();
			}
		}

		static EntityInfo()
		{
			RemoteProcedureCalls.RegisterRpc(typeof(EntityInfo), "System.Void Polarith.AI.Package.Net.EntityInfo::RpcRespawn()", InvokeUserCode_RpcRespawn);
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			base.SerializeSyncVars(writer, forceAll);
			if (forceAll)
			{
				writer.WriteFloat(hitpoints);
				return;
			}
			writer.WriteULong(base.syncVarDirtyBits);
			if ((base.syncVarDirtyBits & 1L) != 0L)
			{
				writer.WriteFloat(hitpoints);
			}
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
			base.DeserializeSyncVars(reader, initialState);
			if (initialState)
			{
				GeneratedSyncVarDeserialize(ref hitpoints, null, reader.ReadFloat());
				return;
			}
			long num = (long)reader.ReadULong();
			if ((num & 1L) != 0L)
			{
				GeneratedSyncVarDeserialize(ref hitpoints, null, reader.ReadFloat());
			}
		}
	}
}
