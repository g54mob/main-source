using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class BoxCollisionSfx : NetworkEntityBehaviourBase, ICollisionEnter
{
	public EventReference sfx;

	public EventReference destroySfx;

	[Min(0f)]
	public float impulseThreshold;

	protected override void OnEntityDestroyed()
	{
		PlayDestroySfx();
	}

	public void CollisionEnter(Collision collision)
	{
		if (!sfx.IsNull && collision.impulse.sqrMagnitude >= impulseThreshold * impulseThreshold)
		{
			PlaySfx();
		}
	}

	private void PlaySfx()
	{
		AudioManager.PlaySfx(sfx, base.entity.transform.position);
	}

	private void PlayDestroySfx()
	{
		AudioManager.PlaySfx((!destroySfx.IsNull) ? destroySfx : sfx, base.entity.transform.position);
	}

	[ClientRpc]
	public void RpcPlaySfx()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void BoxCollisionSfx::RpcPlaySfx()", 198639605, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPlaySfx()
	{
		PlaySfx();
	}

	protected static void InvokeUserCode_RpcPlaySfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlaySfx called on server.");
		}
		else
		{
			((BoxCollisionSfx)obj).UserCode_RpcPlaySfx();
		}
	}

	static BoxCollisionSfx()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(BoxCollisionSfx), "System.Void BoxCollisionSfx::RpcPlaySfx()", InvokeUserCode_RpcPlaySfx);
	}
}
