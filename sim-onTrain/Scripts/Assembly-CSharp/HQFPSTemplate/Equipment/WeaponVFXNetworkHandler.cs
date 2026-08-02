using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class WeaponVFXNetworkHandler : NetworkBehaviour
	{
		private static WeaponVFXNetworkHandler m_Instance;

		public static WeaponVFXNetworkHandler Instance => m_Instance;

		private void Awake()
		{
			if (m_Instance == null)
			{
				m_Instance = this;
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void RequestSpawnEffects(NetworkIdentity playerIdentity, Vector3[] hitPoints, string weaponId)
		{
			if (!(playerIdentity == null) && playerIdentity.isLocalPlayer)
			{
				if (base.isServer)
				{
					RpcSpawnEffects(hitPoints, weaponId, playerIdentity.netId);
				}
				else
				{
					CmdSpawnEffects(hitPoints, weaponId, playerIdentity.netId);
				}
			}
		}

		public void RequestSpawnMagazine(NetworkIdentity playerIdentity, string weaponId)
		{
			if (!(playerIdentity == null) && playerIdentity.isLocalPlayer)
			{
				if (base.isServer)
				{
					RpcSpawnMagazine(weaponId, playerIdentity.netId);
				}
				else
				{
					CmdSpawnMagazine(weaponId, playerIdentity.netId);
				}
			}
		}

		[Command(requiresAuthority = false)]
		private void CmdSpawnEffects(Vector3[] hitPoints, string weaponId, uint playerId)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			GeneratedNetworkCode._Write_UnityEngine_002EVector3_005B_005D(writer, hitPoints);
			writer.WriteString(weaponId);
			writer.WriteUInt(playerId);
			SendCommandInternal("System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::CmdSpawnEffects(UnityEngine.Vector3[],System.String,System.UInt32)", 1877990677, writer, 0, requiresAuthority: false);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcSpawnEffects(Vector3[] hitPoints, string weaponId, uint playerId)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			GeneratedNetworkCode._Write_UnityEngine_002EVector3_005B_005D(writer, hitPoints);
			writer.WriteString(weaponId);
			writer.WriteUInt(playerId);
			SendRPCInternal("System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::RpcSpawnEffects(UnityEngine.Vector3[],System.String,System.UInt32)", 328612618, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[Command(requiresAuthority = false)]
		private void CmdSpawnMagazine(string weaponId, uint playerId)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteString(weaponId);
			writer.WriteUInt(playerId);
			SendCommandInternal("System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::CmdSpawnMagazine(System.String,System.UInt32)", 1400187344, writer, 0, requiresAuthority: false);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		private void RpcSpawnMagazine(string weaponId, uint playerId)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteString(weaponId);
			writer.WriteUInt(playerId);
			SendRPCInternal("System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::RpcSpawnMagazine(System.String,System.UInt32)", -966501189, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		private ProjectileWeaponVFX FindWeaponVFX(GameObject playerObj, string weaponId)
		{
			ProjectileWeaponVFX[] componentsInChildren = playerObj.GetComponentsInChildren<ProjectileWeaponVFX>(includeInactive: true);
			foreach (ProjectileWeaponVFX projectileWeaponVFX in componentsInChildren)
			{
				if (projectileWeaponVFX.gameObject.name == weaponId)
				{
					return projectileWeaponVFX;
				}
			}
			return null;
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdSpawnEffects__Vector3_005B_005D__String__UInt32(Vector3[] hitPoints, string weaponId, uint playerId)
		{
			RpcSpawnEffects(hitPoints, weaponId, playerId);
		}

		protected static void InvokeUserCode_CmdSpawnEffects__Vector3_005B_005D__String__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdSpawnEffects called on client.");
			}
			else
			{
				((WeaponVFXNetworkHandler)obj).UserCode_CmdSpawnEffects__Vector3_005B_005D__String__UInt32(GeneratedNetworkCode._Read_UnityEngine_002EVector3_005B_005D(reader), reader.ReadString(), reader.ReadUInt());
			}
		}

		protected void UserCode_RpcSpawnEffects__Vector3_005B_005D__String__UInt32(Vector3[] hitPoints, string weaponId, uint playerId)
		{
			NetworkIdentity networkIdentity = NetworkClient.spawned[playerId];
			if (networkIdentity != null)
			{
				ProjectileWeaponVFX projectileWeaponVFX = FindWeaponVFX(networkIdentity.gameObject, weaponId);
				if (projectileWeaponVFX != null)
				{
					projectileWeaponVFX.SpawnEffectsLocal(hitPoints);
				}
			}
		}

		protected static void InvokeUserCode_RpcSpawnEffects__Vector3_005B_005D__String__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSpawnEffects called on server.");
			}
			else
			{
				((WeaponVFXNetworkHandler)obj).UserCode_RpcSpawnEffects__Vector3_005B_005D__String__UInt32(GeneratedNetworkCode._Read_UnityEngine_002EVector3_005B_005D(reader), reader.ReadString(), reader.ReadUInt());
			}
		}

		protected void UserCode_CmdSpawnMagazine__String__UInt32(string weaponId, uint playerId)
		{
			RpcSpawnMagazine(weaponId, playerId);
		}

		protected static void InvokeUserCode_CmdSpawnMagazine__String__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdSpawnMagazine called on client.");
			}
			else
			{
				((WeaponVFXNetworkHandler)obj).UserCode_CmdSpawnMagazine__String__UInt32(reader.ReadString(), reader.ReadUInt());
			}
		}

		protected void UserCode_RpcSpawnMagazine__String__UInt32(string weaponId, uint playerId)
		{
			NetworkIdentity networkIdentity = NetworkClient.spawned[playerId];
			if (networkIdentity != null)
			{
				ProjectileWeaponVFX projectileWeaponVFX = FindWeaponVFX(networkIdentity.gameObject, weaponId);
				if (projectileWeaponVFX != null)
				{
					projectileWeaponVFX.SpawnMagazineLocal();
				}
			}
		}

		protected static void InvokeUserCode_RpcSpawnMagazine__String__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSpawnMagazine called on server.");
			}
			else
			{
				((WeaponVFXNetworkHandler)obj).UserCode_RpcSpawnMagazine__String__UInt32(reader.ReadString(), reader.ReadUInt());
			}
		}

		static WeaponVFXNetworkHandler()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(WeaponVFXNetworkHandler), "System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::CmdSpawnEffects(UnityEngine.Vector3[],System.String,System.UInt32)", InvokeUserCode_CmdSpawnEffects__Vector3_005B_005D__String__UInt32, requiresAuthority: false);
			RemoteProcedureCalls.RegisterCommand(typeof(WeaponVFXNetworkHandler), "System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::CmdSpawnMagazine(System.String,System.UInt32)", InvokeUserCode_CmdSpawnMagazine__String__UInt32, requiresAuthority: false);
			RemoteProcedureCalls.RegisterRpc(typeof(WeaponVFXNetworkHandler), "System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::RpcSpawnEffects(UnityEngine.Vector3[],System.String,System.UInt32)", InvokeUserCode_RpcSpawnEffects__Vector3_005B_005D__String__UInt32);
			RemoteProcedureCalls.RegisterRpc(typeof(WeaponVFXNetworkHandler), "System.Void HQFPSTemplate.Equipment.WeaponVFXNetworkHandler::RpcSpawnMagazine(System.String,System.UInt32)", InvokeUserCode_RpcSpawnMagazine__String__UInt32);
		}
	}
}
