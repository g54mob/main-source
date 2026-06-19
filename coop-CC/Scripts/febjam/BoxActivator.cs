using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class BoxActivator : NetworkEntityBehaviourBase, ICollisionEnter
{
	public bool onlyActivateOnce = true;

	public bool destroySelfOnActivation;

	public ActivationContextMask activationMask;

	public float activationCooldown = 10f;

	[Space]
	[Min(0f)]
	public float slowDownActivateSpeedThreshold = 10f;

	[Range(-1f, 1f)]
	public float softPaddingVelocityMultiplier = 0.35f;

	[SyncVar]
	private bool _syncActivated;

	private Vector3 _velocity;

	private bool _serverIsActivatable;

	private bool _serverIgnoreActivation;

	private int _serverFrameCanActivate;

	private static List<IBoxActivated> _activations;

	private static Collider[] _colliders;

	public GameObject boxDestructionVFX;

	public bool activated => _syncActivated;

	private bool hasActivationCooldown
	{
		get
		{
			if (!onlyActivateOnce)
			{
				return !destroySelfOnActivation;
			}
			return false;
		}
	}

	public bool Network_syncActivated
	{
		get
		{
			return _syncActivated;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncActivated, 1uL, null);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			_serverIsActivatable = true;
			if (!base.entity.rigidbody.isKinematic)
			{
				_velocity = base.entity.rigidbody.velocity;
			}
		}
	}

	protected override void OnUpdateSimulationLate()
	{
		if (!base.isServer)
		{
			return;
		}
		if (!base.entity.rigidbody.isKinematic && !_serverIgnoreActivation && _velocity.sqrMagnitude > 0f && _velocity.sqrMagnitude >= slowDownActivateSpeedThreshold * slowDownActivateSpeedThreshold && TimeUtil.frame >= _serverFrameCanActivate && (!onlyActivateOnce || !_syncActivated) && base.entity.GetObject<Grabbable>().isBase)
		{
			float magnitude = _velocity.magnitude;
			Vector3 vector = _velocity / magnitude;
			Vector3 lhs = Vector3.Project(base.entity.rigidbody.velocity, vector);
			float magnitude2 = lhs.magnitude;
			float num = ((!(Vector3.Dot(lhs, vector) >= 0f)) ? (magnitude + magnitude2) : (magnitude - magnitude2));
			if (num >= slowDownActivateSpeedThreshold)
			{
				RequestActivate(new ActivationContext(ActivationContextType.Impact));
			}
		}
		_serverIgnoreActivation = false;
	}

	[Server]
	public void ServerSetActivatable(bool activatable)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxActivator::ServerSetActivatable(System.Boolean)' called when server was not active");
		}
		else
		{
			_serverIsActivatable = activatable;
		}
	}

	public void RequestActivate(ActivationContext context)
	{
		if (base.isServer)
		{
			context.connection = NetworkServer.localConnection;
			ServerActivate(context);
		}
		else
		{
			CmdActivate(context);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdActivate(ActivationContext context, NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ActivationContext(writer, context);
		SendCommandInternal("System.Void BoxActivator::CmdActivate(ActivationContext,Mirror.NetworkConnectionToClient)", 1916350346, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerActivate(ActivationContext context)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxActivator::ServerActivate(ActivationContext)' called when server was not active");
		}
		else
		{
			if (base.entity.GetObject<BoxProps>().serverIsSafe || base.entity.GetObject<Grabbable>().serverIsOutbounding)
			{
				return;
			}
			if (context.type == ActivationContextType.Kicked)
			{
				Grabbable grabbable = base.entity.GetObject<Grabbable>();
				if (grabbable.isInStack)
				{
					base.entity.GetObject<Grabbable>().ServerBreakEntireStack();
				}
				if (grabbable.entity.TryGetObject<BoxCollisionSfx>(out var obj))
				{
					obj.RpcPlaySfx();
				}
			}
			if ((onlyActivateOnce && _syncActivated) || !_serverIsActivatable || TimeUtil.frame < _serverFrameCanActivate || ((uint)(1 << (int)context.type) & (uint)activationMask) == 0 || (base.entity.TryGetStruct<EntityContextComp>(out var comp) && comp.roomType != GameUtil.GetCurrentRoomType()))
			{
				return;
			}
			Vector3 position = base.entity.transform.position;
			int num = Physics.OverlapSphereNonAlloc(position, 20f, _colliders, 524288);
			for (int i = 0; i < num; i++)
			{
				if (_colliders[i].TryGetEntity(out var entity) && entity.TryGetObject<StationEMP>(out var obj2) && math.distancesq(position, entity.transform.position) <= obj2.radius * obj2.radius)
				{
					obj2.ServerPrevented(position);
					return;
				}
			}
			if (!onlyActivateOnce && !destroySelfOnActivation)
			{
				_serverFrameCanActivate = TimeUtil.frame + TimeUtil.FramesForTime(activationCooldown);
			}
			Network_syncActivated = true;
			_activations.Clear();
			base.entity.GetObjects(_activations);
			for (int j = 0; j < _activations.Count; j++)
			{
				_activations[j].ServerBoxActivated(context);
			}
			if (destroySelfOnActivation)
			{
				if (boxDestructionVFX != null)
				{
					NetworkAggroManagerBase<VFXManager>.instance.Play(boxDestructionVFX, base.transform.position);
				}
				EntityUtil.Destroy(base.entity);
			}
		}
	}

	[DevCmd("activate", "Activate a box.\r\n\r\nUsage:\r\n    activate <box>\r\n        Activate the supplied box.\r\n\r\n    activate -all", new string[] { "all" })]
	[DevCmdVerify("^[\\S]+$")]
	[DevCmdVerify("^-all$")]
	private static void ActivateDevCmd(DevCmdArg[] args)
	{
		if (!GameUtil.isReady)
		{
			Debug.LogWarning("Entity world is not ready!");
			return;
		}
		string text = args[0].name;
		Entity box;
		if (text == null || text.Length != 0)
		{
			if (text == "all")
			{
				NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdAllBoxesActivate();
			}
			else
			{
				Debug.LogWarning("Unknown argument! (" + args[0].name + ")");
			}
		}
		else if (DevCmdUtil.TryGetEntityFromDevCmdName(args[0].value, out box))
		{
			NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdBoxActivate(box);
		}
		else
		{
			Debug.LogWarning("Could not find an entity with dev cmd name! (" + args[0].value + ")");
		}
	}

	[DevCmdCompleteFunction("activate", "", DevCmdCompleteFlags.Sort)]
	private static string[] ActivateBoxDevComplete()
	{
		return DevCmdUtil.GetEntityNames<BoxActivator>();
	}

	public void CollisionEnter(Collision collision)
	{
		if (base.isServer && !_serverIgnoreActivation)
		{
			if (collision.collider.gameObject.layer == 21)
			{
				_serverIgnoreActivation = true;
				base.entity.rigidbody.velocity *= softPaddingVelocityMultiplier;
			}
			else if (collision.collider.gameObject.layer == 13)
			{
				_velocity.x = 0f;
				_velocity.z = 0f;
			}
		}
	}

	static BoxActivator()
	{
		_activations = new List<IBoxActivated>();
		_colliders = new Collider[32];
		RemoteProcedureCalls.RegisterCommand(typeof(BoxActivator), "System.Void BoxActivator::CmdActivate(ActivationContext,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdActivate__ActivationContext__NetworkConnectionToClient, requiresAuthority: false);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdActivate__ActivationContext__NetworkConnectionToClient(ActivationContext context, NetworkConnectionToClient conn)
	{
		context.connection = conn;
		ServerActivate(context);
	}

	protected static void InvokeUserCode_CmdActivate__ActivationContext__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdActivate called on client.");
		}
		else
		{
			((BoxActivator)obj).UserCode_CmdActivate__ActivationContext__NetworkConnectionToClient(GeneratedNetworkCode._Read_ActivationContext(reader), senderConnection);
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_syncActivated);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_syncActivated);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncActivated, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncActivated, null, reader.ReadBool());
		}
	}
}
