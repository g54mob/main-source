using HQFPSTemplate;
using HQFPSTemplate.Equipment;
using HQFPSTemplate.Pooling;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerWeaponVFXRelay : NetworkBehaviour
{
	private bool _isLocal;

	private int _targetLayer;

	public override void OnStartClient()
	{
		_isLocal = base.isLocalPlayer;
		_targetLayer = (_isLocal ? LayerMask.NameToLayer("FpsParts") : 0);
	}

	[Command]
	public void CmdSpawnEffects(string weaponName, Vector3[] hitPoints, Vector3 muzzlePos, Vector3 tracerOffset, uint shooterNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(weaponName);
		GeneratedNetworkCode._Write_UnityEngine_002EVector3_005B_005D(writer, hitPoints);
		writer.WriteVector3(muzzlePos);
		writer.WriteVector3(tracerOffset);
		writer.WriteUInt(shooterNetId);
		SendCommandInternal("System.Void PlayerWeaponVFXRelay::CmdSpawnEffects(System.String,UnityEngine.Vector3[],UnityEngine.Vector3,UnityEngine.Vector3,System.UInt32)", 260522613, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSpawnEffects(string weaponName, Vector3[] hitPoints, Vector3 muzzlePos, Vector3 tracerOffset, uint shooterNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(weaponName);
		GeneratedNetworkCode._Write_UnityEngine_002EVector3_005B_005D(writer, hitPoints);
		writer.WriteVector3(muzzlePos);
		writer.WriteVector3(tracerOffset);
		writer.WriteUInt(shooterNetId);
		SendRPCInternal("System.Void PlayerWeaponVFXRelay::RpcSpawnEffects(System.String,UnityEngine.Vector3[],UnityEngine.Vector3,UnityEngine.Vector3,System.UInt32)", 1511376746, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private static void SetLayerRecursively(Transform parent, int layer)
	{
		parent.gameObject.layer = layer;
		for (int i = 0; i < parent.childCount; i++)
		{
			SetLayerRecursively(parent.GetChild(i), layer);
		}
	}

	[Command]
	public void CmdSpawnMagazine(string weaponName, uint shooterNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(weaponName);
		writer.WriteUInt(shooterNetId);
		SendCommandInternal("System.Void PlayerWeaponVFXRelay::CmdSpawnMagazine(System.String,System.UInt32)", -1140411626, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSpawnMagazine(string weaponName, uint shooterNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(weaponName);
		writer.WriteUInt(shooterNetId);
		SendRPCInternal("System.Void PlayerWeaponVFXRelay::RpcSpawnMagazine(System.String,System.UInt32)", 787867137, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32(string weaponName, Vector3[] hitPoints, Vector3 muzzlePos, Vector3 tracerOffset, uint shooterNetId)
	{
		RpcSpawnEffects(weaponName, hitPoints, muzzlePos, tracerOffset, shooterNetId);
	}

	protected static void InvokeUserCode_CmdSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnEffects called on client.");
		}
		else
		{
			((PlayerWeaponVFXRelay)obj).UserCode_CmdSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32(reader.ReadString(), GeneratedNetworkCode._Read_UnityEngine_002EVector3_005B_005D(reader), reader.ReadVector3(), reader.ReadVector3(), reader.ReadUInt());
		}
	}

	protected void UserCode_RpcSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32(string weaponName, Vector3[] hitPoints, Vector3 muzzlePos, Vector3 tracerOffset, uint shooterNetId)
	{
		if (!NetworkClient.spawned.TryGetValue(shooterNetId, out var value))
		{
			return;
		}
		ProjectileWeaponVFX[] componentsInChildren = value.GetComponentsInChildren<ProjectileWeaponVFX>(includeInactive: true);
		foreach (ProjectileWeaponVFX projectileWeaponVFX in componentsInChildren)
		{
			if (!(projectileWeaponVFX.gameObject.name == weaponName))
			{
				continue;
			}
			Vector3 vector = (_isLocal ? projectileWeaponVFX.GetLocalMuzzlePos() : projectileWeaponVFX.GetTPSMuzzlePos());
			Quaternion rotation = (_isLocal ? projectileWeaponVFX.GetLocalMuzzleRotation() : projectileWeaponVFX.GetTPSMuzzleRotation());
			Vector3 vector2 = (_isLocal ? projectileWeaponVFX.GetViewmodelAlignedMuzzlePos() : vector);
			for (int j = 0; j < hitPoints.Length; j++)
			{
				if (!(projectileWeaponVFX.TracerPrefab != null))
				{
					continue;
				}
				PoolableObject objectLocal = HQFPSTemplate.Singleton<PoolingManager>.Instance.GetObjectLocal(projectileWeaponVFX.TracerPrefab, vector2 + tracerOffset, Quaternion.LookRotation(hitPoints[j] - vector2));
				if (!(objectLocal != null))
				{
					continue;
				}
				objectLocal.gameObject.layer = LayerMask.NameToLayer("Bullet");
				ParticleSystem component = objectLocal.GetComponent<ParticleSystem>();
				if (component != null)
				{
					float num = Vector3.Distance(vector2, hitPoints[j]);
					ParticleSystem.MainModule main = component.main;
					float constant = main.startSpeed.constant;
					if (constant > 0.01f)
					{
						main.startLifetime = num / constant;
					}
				}
			}
			if (projectileWeaponVFX.MuzzleFlashPrefab != null)
			{
				Transform parent = (_isLocal ? projectileWeaponVFX.GetLocalMuzzle() : projectileWeaponVFX.GetTPSMuzzle());
				PoolableObject objectLocal2 = HQFPSTemplate.Singleton<PoolingManager>.Instance.GetObjectLocal(projectileWeaponVFX.MuzzleFlashPrefab, vector, rotation, parent);
				if (objectLocal2 != null)
				{
					SetLayerRecursively(objectLocal2.transform, _targetLayer);
				}
			}
			projectileWeaponVFX.PlayLightEffect();
			projectileWeaponVFX.SpawnCasingLocal(_targetLayer);
			break;
		}
	}

	protected static void InvokeUserCode_RpcSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSpawnEffects called on server.");
		}
		else
		{
			((PlayerWeaponVFXRelay)obj).UserCode_RpcSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32(reader.ReadString(), GeneratedNetworkCode._Read_UnityEngine_002EVector3_005B_005D(reader), reader.ReadVector3(), reader.ReadVector3(), reader.ReadUInt());
		}
	}

	protected void UserCode_CmdSpawnMagazine__String__UInt32(string weaponName, uint shooterNetId)
	{
		RpcSpawnMagazine(weaponName, shooterNetId);
	}

	protected static void InvokeUserCode_CmdSpawnMagazine__String__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnMagazine called on client.");
		}
		else
		{
			((PlayerWeaponVFXRelay)obj).UserCode_CmdSpawnMagazine__String__UInt32(reader.ReadString(), reader.ReadUInt());
		}
	}

	protected void UserCode_RpcSpawnMagazine__String__UInt32(string weaponName, uint shooterNetId)
	{
		if (!NetworkClient.spawned.TryGetValue(shooterNetId, out var value))
		{
			return;
		}
		ProjectileWeaponVFX[] componentsInChildren = value.GetComponentsInChildren<ProjectileWeaponVFX>(includeInactive: true);
		foreach (ProjectileWeaponVFX projectileWeaponVFX in componentsInChildren)
		{
			if (projectileWeaponVFX.gameObject.name == weaponName)
			{
				projectileWeaponVFX.SpawnMagazineLocal(_targetLayer);
				break;
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
			((PlayerWeaponVFXRelay)obj).UserCode_RpcSpawnMagazine__String__UInt32(reader.ReadString(), reader.ReadUInt());
		}
	}

	static PlayerWeaponVFXRelay()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVFXRelay), "System.Void PlayerWeaponVFXRelay::CmdSpawnEffects(System.String,UnityEngine.Vector3[],UnityEngine.Vector3,UnityEngine.Vector3,System.UInt32)", InvokeUserCode_CmdSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerWeaponVFXRelay), "System.Void PlayerWeaponVFXRelay::CmdSpawnMagazine(System.String,System.UInt32)", InvokeUserCode_CmdSpawnMagazine__String__UInt32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerWeaponVFXRelay), "System.Void PlayerWeaponVFXRelay::RpcSpawnEffects(System.String,UnityEngine.Vector3[],UnityEngine.Vector3,UnityEngine.Vector3,System.UInt32)", InvokeUserCode_RpcSpawnEffects__String__Vector3_005B_005D__Vector3__Vector3__UInt32);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerWeaponVFXRelay), "System.Void PlayerWeaponVFXRelay::RpcSpawnMagazine(System.String,System.UInt32)", InvokeUserCode_RpcSpawnMagazine__String__UInt32);
	}
}
