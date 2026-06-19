using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PuddleManager : NetworkAggroManagerBase<PuddleManager>
{
	private struct Blob
	{
		public Entity entity;

		public Transform transform;

		public GameObject prefab;

		public GameObject vfx;

		public bool isWater;

		public float minDistanceFromOtherPuddles;

		public Vector3 velocity;
	}

	[Min(0f)]
	public float distanceThresholdForBlob = 1f;

	[Min(0f)]
	public float breakBlobYThreshold = 0.5f;

	private List<Blob> _blobs = new List<Blob>();

	private static Collider[] _colliders;

	public static int puddleVersion { get; private set; }

	protected override void OnUpdateSimulation()
	{
		for (int i = 0; i < _blobs.Count; i++)
		{
			Blob value = _blobs[i];
			value.velocity += Physics.gravity * (1f / 60f);
			Vector3 position = value.transform.position;
			position += value.velocity * (1f / 60f);
			if (value.transform.position.y < breakBlobYThreshold)
			{
				if (base.isServer)
				{
					ServerSpawnPuddleInternal(value.prefab, position, value.isWater, value.minDistanceFromOtherPuddles, value.vfx);
				}
				EntityUtil.Destroy(value.entity);
				_blobs.RemoveAtSwapBack(i);
				i--;
			}
			else
			{
				value.transform.position = position;
				_blobs[i] = value;
			}
		}
	}

	[Server]
	private void ServerSpawnPuddleInternal(GameObject prefab, Vector3 pos, bool isWater, float minDistanceFromOtherPuddles, GameObject vfx)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PuddleManager::ServerSpawnPuddleInternal(UnityEngine.GameObject,UnityEngine.Vector3,System.Boolean,System.Single,UnityEngine.GameObject)' called when server was not active");
			return;
		}
		pos.y = 0f;
		bool flag = true;
		int num = Physics.OverlapSphereNonAlloc(pos, 0f, _colliders, 131072);
		for (int i = 0; i < num; i++)
		{
			Collider collider = _colliders[i];
			Vector3 center = collider.bounds.center;
			center.y = 0f;
			if (math.distancesq(pos, center) < minDistanceFromOtherPuddles * minDistanceFromOtherPuddles)
			{
				if (!isWater)
				{
					flag = false;
					break;
				}
				if (collider.TryGetEntity(out var entity) && entity.TryGetObject<Puddle>(out var obj) && !obj.canBeWashedAway)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			EntityUtil.Instantiate(prefab, pos);
		}
		NetworkAggroManagerBase<VFXManager>.instance.Play(vfx, pos);
	}

	[Server]
	public void ServerSpawnPuddle(GameObject prefab, Vector3 position)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PuddleManager::ServerSpawnPuddle(UnityEngine.GameObject,UnityEngine.Vector3)' called when server was not active");
		}
		else if (position.y < distanceThresholdForBlob)
		{
			Puddle component = prefab.GetComponent<Puddle>();
			ServerSpawnPuddleInternal(prefab, position, component.isWater, component.minDistanceFromOtherPuddles, component.splashVfxPrefab);
		}
		else
		{
			RpcSpawnBlob(prefab, position);
		}
	}

	[ClientRpc]
	private void RpcSpawnBlob(GameObject prefab, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(prefab);
		writer.WriteVector3(position);
		SendRPCInternal("System.Void PuddleManager::RpcSpawnBlob(UnityEngine.GameObject,UnityEngine.Vector3)", 1088176800, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public static void BumpVersion()
	{
		puddleVersion++;
	}

	static PuddleManager()
	{
		_colliders = new Collider[32];
		RemoteProcedureCalls.RegisterRpc(typeof(PuddleManager), "System.Void PuddleManager::RpcSpawnBlob(UnityEngine.GameObject,UnityEngine.Vector3)", InvokeUserCode_RpcSpawnBlob__GameObject__Vector3);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcSpawnBlob__GameObject__Vector3(GameObject prefab, Vector3 position)
	{
		Puddle component = prefab.GetComponent<Puddle>();
		Blob item = default(Blob);
		item.entity = EntityUtil.Instantiate(component.blobPrefab, position);
		item.transform = item.entity.transform;
		item.prefab = prefab;
		item.vfx = component.splashVfxPrefab;
		item.isWater = component.isWater;
		item.minDistanceFromOtherPuddles = component.minDistanceFromOtherPuddles;
		_blobs.Add(item);
	}

	protected static void InvokeUserCode_RpcSpawnBlob__GameObject__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSpawnBlob called on server.");
		}
		else
		{
			((PuddleManager)obj).UserCode_RpcSpawnBlob__GameObject__Vector3(reader.ReadGameObject(), reader.ReadVector3());
		}
	}
}
