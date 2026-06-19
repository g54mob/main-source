using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class VFXManager : NetworkAggroManagerBase<VFXManager>
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct VfxComp : IEntityStruct, IEntityTyped
	{
	}

	[Min(0f)]
	public int populateCount = 3;

	public GameObject[] prefabs;

	private Dictionary<GameObject, int> _prefabToIndex = new Dictionary<GameObject, int>();

	private StructQuery<VfxComp> _query;

	protected override void OnInitializeBehaviour()
	{
		for (int i = 0; i < prefabs.Length; i++)
		{
			GameObject gameObject = prefabs[i];
			if (gameObject != null)
			{
				gameObject.PopulateForPrefabPool(populateCount);
				_prefabToIndex[gameObject] = i;
			}
		}
		_query = base.entityManager.CreateStructQuery<VfxComp>();
	}

	public void Play(GameObject prefab, Vector3 position)
	{
		if (!(prefab == null))
		{
			if (_prefabToIndex.TryGetValue(prefab, out var value))
			{
				CmdPlay((short)value, position);
			}
			else
			{
				Debug.LogError("[VFX] Could not find vfx in the prefab list of VFXManager! (" + prefab.name + ")", prefab);
			}
		}
	}

	public void Play(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		if (!(prefab == null))
		{
			if (_prefabToIndex.TryGetValue(prefab, out var value))
			{
				CmdPlay((short)value, position, rotation);
			}
			else
			{
				Debug.LogError("[VFX] Could not find vfx in the prefab list of VFXManager! (" + prefab.name + ")", prefab);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdPlay(short index, Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendCommandInternal("System.Void VFXManager::CmdPlay(System.Int16,UnityEngine.Vector3,UnityEngine.Quaternion)", 2439495, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlay(short index, Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendRPCInternal("System.Void VFXManager::RpcPlay(System.Int16,UnityEngine.Vector3,UnityEngine.Quaternion)", -1321460606, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdPlay(short index, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		writer.WriteVector3(position);
		SendCommandInternal("System.Void VFXManager::CmdPlay(System.Int16,UnityEngine.Vector3)", -1599290588, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlay(short index, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		writer.WriteVector3(position);
		SendRPCInternal("System.Void VFXManager::RpcPlay(System.Int16,UnityEngine.Vector3)", 1589826975, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void PlayInternal(short index, Vector3 position, Quaternion rotation)
	{
		PoolableEntityReference entityFromPrefabPool = prefabs[index].GetEntityFromPrefabPool();
		entityFromPrefabPool.entity.AddStruct<VfxComp>();
		entityFromPrefabPool.entity.transform.SetPositionAndRotation(position, rotation);
	}

	public void ReleaseAll()
	{
		_query.Run();
		for (int i = 0; i < _query.count; i++)
		{
			if (_query.GetEntity(i).TryGetStruct<PoolableEntityReference>(out var comp))
			{
				comp.Release();
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlay__Int16__Vector3__Quaternion(short index, Vector3 position, Quaternion rotation)
	{
		RpcPlay(index, position, rotation);
	}

	protected static void InvokeUserCode_CmdPlay__Int16__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlay called on client.");
		}
		else
		{
			((VFXManager)obj).UserCode_CmdPlay__Int16__Vector3__Quaternion(reader.ReadShort(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcPlay__Int16__Vector3__Quaternion(short index, Vector3 position, Quaternion rotation)
	{
		PlayInternal(index, position, rotation);
	}

	protected static void InvokeUserCode_RpcPlay__Int16__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlay called on server.");
		}
		else
		{
			((VFXManager)obj).UserCode_RpcPlay__Int16__Vector3__Quaternion(reader.ReadShort(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdPlay__Int16__Vector3(short index, Vector3 position)
	{
		RpcPlay(index, position);
	}

	protected static void InvokeUserCode_CmdPlay__Int16__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlay called on client.");
		}
		else
		{
			((VFXManager)obj).UserCode_CmdPlay__Int16__Vector3(reader.ReadShort(), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcPlay__Int16__Vector3(short index, Vector3 position)
	{
		PlayInternal(index, position, Quaternion.identity);
	}

	protected static void InvokeUserCode_RpcPlay__Int16__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlay called on server.");
		}
		else
		{
			((VFXManager)obj).UserCode_RpcPlay__Int16__Vector3(reader.ReadShort(), reader.ReadVector3());
		}
	}

	static VFXManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(VFXManager), "System.Void VFXManager::CmdPlay(System.Int16,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdPlay__Int16__Vector3__Quaternion, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(VFXManager), "System.Void VFXManager::CmdPlay(System.Int16,UnityEngine.Vector3)", InvokeUserCode_CmdPlay__Int16__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(VFXManager), "System.Void VFXManager::RpcPlay(System.Int16,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcPlay__Int16__Vector3__Quaternion);
		RemoteProcedureCalls.RegisterRpc(typeof(VFXManager), "System.Void VFXManager::RpcPlay(System.Int16,UnityEngine.Vector3)", InvokeUserCode_RpcPlay__Int16__Vector3);
	}
}
