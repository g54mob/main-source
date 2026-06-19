using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class StationTeleporter : NetworkEntityBehaviourBase
{
	public MeshRenderer screenRenderer;

	private static readonly int ScreenParamID;

	private static readonly int Teleport;

	public Animator animator;

	public ParticleSystem[] particles;

	public StudioEventEmitter loopSfx;

	public EventReference teleportSfx;

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			NetworkAggroManagerBase<StationTeleporterManager>.instance.ServerAddStation(this);
		}
	}

	protected override void OnEntityDestroyed()
	{
		if (base.isServer)
		{
			NetworkAggroManagerBase<StationTeleporterManager>.instance.ServerRemoveStation(this);
		}
	}

	public bool HasBoxes()
	{
		if (base.entity.TryGetObject<GrabbableHolder>(out var obj))
		{
			return obj.isHoldingAnItem;
		}
		return false;
	}

	protected override void OnUpdatePresentationLate()
	{
		float normalizedTeleportTime = NetworkAggroManagerBase<StationTeleporterManager>.instance.normalizedTeleportTime;
		loopSfx.SetParameter("build", normalizedTeleportTime);
		screenRenderer.SetPropertyBlockFloat(ScreenParamID, normalizedTeleportTime);
	}

	[ClientRpc]
	public void RpcOnTeleport()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void StationTeleporter::RpcOnTeleport()", -750374538, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	static StationTeleporter()
	{
		ScreenParamID = Shader.PropertyToID("_teleportLoadTime");
		Teleport = Animator.StringToHash("teleport");
		RemoteProcedureCalls.RegisterRpc(typeof(StationTeleporter), "System.Void StationTeleporter::RpcOnTeleport()", InvokeUserCode_RpcOnTeleport);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcOnTeleport()
	{
		animator.SetTrigger(Teleport);
		ParticleSystem[] array = particles;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
		AudioManager.PlaySfx(teleportSfx, base.transform.position);
	}

	protected static void InvokeUserCode_RpcOnTeleport(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnTeleport called on server.");
		}
		else
		{
			((StationTeleporter)obj).UserCode_RpcOnTeleport();
		}
	}
}
