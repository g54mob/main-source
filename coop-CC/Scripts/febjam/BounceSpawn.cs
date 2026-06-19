using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class BounceSpawn : NetworkEntityBehaviourBase, ICollisionEnter
{
	public TagQuery tagQuery;

	public bool checkForPuddles = true;

	[Min(0f)]
	public float minDistanceFromOtherPuddles = 1.5f;

	public bool onlyWithGround = true;

	[Min(0f)]
	public float impulseThresholdForSpawn = 3f;

	[Space]
	public GameObject prefab;

	private static Collider[] _colliders;

	private const float DOT_UP_THRESHOLD = 0.9f;

	[Header("visuals")]
	public GameObject vfxPrefab;

	public void CollisionEnter(Collision collision)
	{
		if (!base.isServer || !tagQuery.Evaluate(base.entity) || (onlyWithGround && (!(collision.impulse.sqrMagnitude >= impulseThresholdForSpawn * impulseThresholdForSpawn) || collision.gameObject.layer != 16)) || !(math.dot(collision.impulse.normalized, Vector3.up) > 0.9f))
		{
			return;
		}
		Vector3 position = base.entity.transform.position;
		position.y = 0f;
		bool flag = true;
		if (checkForPuddles)
		{
			int num = Physics.OverlapSphereNonAlloc(position, 0f, _colliders, 131072);
			for (int i = 0; i < num; i++)
			{
				Vector3 center = _colliders[i].bounds.center;
				center.y = 0f;
				if (math.distancesq(position, center) < minDistanceFromOtherPuddles * minDistanceFromOtherPuddles)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			EntityUtil.Instantiate(prefab, position);
			RpcBounceSpawned();
		}
	}

	[ClientRpc]
	public void RpcBounceSpawned()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BounceSpawn::RpcBounceSpawned()", -1629384333, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	static BounceSpawn()
	{
		_colliders = new Collider[8];
		RemoteProcedureCalls.RegisterRpc(typeof(BounceSpawn), "System.Void BounceSpawn::RpcBounceSpawned()", InvokeUserCode_RpcBounceSpawned);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcBounceSpawned()
	{
		if (vfxPrefab != null)
		{
			Object.Instantiate(vfxPrefab, base.transform.position, Quaternion.identity);
		}
	}

	protected static void InvokeUserCode_RpcBounceSpawned(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcBounceSpawned called on server.");
		}
		else
		{
			((BounceSpawn)obj).UserCode_RpcBounceSpawned();
		}
	}
}
