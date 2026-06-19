using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerEnvironmentCollision : NetworkEntityBehaviourBase
{
	public LayerMask stressCollisionLayers;

	[Min(0f)]
	public float speedThreshold = 8f;

	[Min(0f)]
	public float debounceTimeSeconds = 0.5f;

	[Min(0f)]
	public float sfxImpulseThreshold = 20f;

	[Min(0f)]
	public GameObject collisionDustVfxPrefab;

	private Timer _debounceTimer;

	private Vector3 _velocity;

	private bool _collided;

	private Entity _bonked;

	private float _impulseSqr;

	public PlayerAnimation playerAnimation;

	public PlayerColorManagerNetwork PlayerColorManagerNetwork;

	public StudioEventEmitter collisionSFX;

	[UpdateInGroup(typeof(PhysicsSystemGroup), UpdatePriority.Normal)]
	protected override void OnUpdateSimulation()
	{
		if (base.isLocalPlayer)
		{
			_debounceTimer.DecrementTimer();
			if (!base.entity.rigidbody.isKinematic)
			{
				_velocity = base.entity.rigidbody.velocity;
				_velocity.y = 0f;
			}
			_collided = false;
			_bonked = Entity.invalid;
			_impulseSqr = 0f;
		}
	}

	protected override void OnUpdateSimulationLate()
	{
		if (!base.isLocalPlayer || !_collided || base.entity.rigidbody.isKinematic)
		{
			return;
		}
		float magnitude = _velocity.magnitude;
		Vector3 vector = _velocity / magnitude;
		Vector3 velocity = base.entity.rigidbody.velocity;
		velocity.y = 0f;
		Vector3 lhs = Vector3.Project(velocity, vector);
		float magnitude2 = lhs.magnitude;
		float num = ((!(Vector3.Dot(lhs, vector) >= 0f)) ? (magnitude + magnitude2) : (magnitude - magnitude2));
		if (num >= speedThreshold && magnitude >= speedThreshold)
		{
			base.entity.GetObject<PlayerStress>().RequestBumpStress();
			NetworkAggroManagerBase<VFXManager>.instance.Play(collisionDustVfxPrefab, base.transform.position);
			playerAnimation.PlayBonk();
			PlayerColorManagerNetwork.CmdPlayFlash();
			base.entity.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
			if (_bonked.TryGetObject<Bonkable>(out var obj))
			{
				obj.RequestBonk();
			}
			_debounceTimer.SetTimer(debounceTimeSeconds);
		}
		else if (_impulseSqr >= sfxImpulseThreshold * sfxImpulseThreshold)
		{
			CmdPlayCollisionSfx();
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (base.isLocalPlayer && _debounceTimer.IsFinished() && (int)stressCollisionLayers == ((int)stressCollisionLayers | (1 << collision.collider.gameObject.layer)))
		{
			_collided = true;
			_impulseSqr = math.max(_impulseSqr, collision.impulse.sqrMagnitude);
			if (_bonked == Entity.invalid && collision.collider.TryGetEntity(out var bonked) && bonked.HasObject<Bonkable>())
			{
				_bonked = bonked;
			}
		}
	}

	[Command]
	private void CmdPlayCollisionSfx()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerEnvironmentCollision::CmdPlayCollisionSfx()", -1778816092, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayCollisionSfx()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerEnvironmentCollision::RpcPlayCollisionSfx()", 1307874047, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlayCollisionSfx()
	{
		RpcPlayCollisionSfx();
	}

	protected static void InvokeUserCode_CmdPlayCollisionSfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayCollisionSfx called on client.");
		}
		else
		{
			((PlayerEnvironmentCollision)obj).UserCode_CmdPlayCollisionSfx();
		}
	}

	protected void UserCode_RpcPlayCollisionSfx()
	{
		collisionSFX.Play();
	}

	protected static void InvokeUserCode_RpcPlayCollisionSfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayCollisionSfx called on server.");
		}
		else
		{
			((PlayerEnvironmentCollision)obj).UserCode_RpcPlayCollisionSfx();
		}
	}

	static PlayerEnvironmentCollision()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerEnvironmentCollision), "System.Void PlayerEnvironmentCollision::CmdPlayCollisionSfx()", InvokeUserCode_CmdPlayCollisionSfx, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerEnvironmentCollision), "System.Void PlayerEnvironmentCollision::RpcPlayCollisionSfx()", InvokeUserCode_RpcPlayCollisionSfx);
	}
}
