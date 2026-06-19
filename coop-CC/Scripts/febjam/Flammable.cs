using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class Flammable : NetworkEntityBehaviourBase, IBoxActivated, IShiftChanged, IFlammable
{
	public float spreadRadius;

	public bool destroySelfAfterOnFire;

	[Min(0f)]
	public float heatingUpDuration = 1f;

	[Min(0f)]
	public float smokingDuration = 5f;

	[Min(0f)]
	public float onFireDuration = 10f;

	[Min(0f)]
	public float onFireSavableDuration = 1f;

	[Header("Puddles")]
	[Min(0f)]
	public float puddleSetFireRadius = 0.5f;

	[Min(0f)]
	public float puddleSetFireCheckEvery = 0.5f;

	[Header("Player")]
	[Min(0f)]
	public float playerSpreadRadius = 4f;

	[Min(0f)]
	public float stressValueRate = 0.25f;

	[Header("Visuals")]
	public ParticleSystem[] smokingParticles;

	public ParticleSystem[] onFireParticles;

	[SyncVar]
	private FireState _state;

	private bool _serverIsBeingSpreadTo;

	private int _serverSpeedPercentage;

	private bool _viewPlaying;

	private Timer _timer;

	private Timer _puddleTimer;

	private static Collider[] _colliders;

	public StudioEventEmitter fireIgniteSFX;

	public StudioEventEmitter fireLoopSFX;

	private const float PUDDLE_HEIGHT_THRESHOLD = 0.75f;

	public FireState fireState => _state;

	public bool isOnFire
	{
		get
		{
			if (_state != FireState.OnFireBurnt)
			{
				return _state == FireState.OnFireSavable;
			}
			return true;
		}
	}

	public FireState Network_state
	{
		get
		{
			return _state;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _state, 1uL, null);
		}
	}

	protected override void OnEntityDestroyed()
	{
		if (fireLoopSFX.IsPlaying())
		{
			fireLoopSFX.Stop();
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		_serverIsBeingSpreadTo = false;
		_serverSpeedPercentage = 0;
	}

	[Server]
	public void ServerSystemProcessHeatSurrounding()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Flammable::ServerSystemProcessHeatSurrounding()' called when server was not active");
		}
		else
		{
			if (_state != FireState.OnFireSavable && _state != FireState.OnFireBurnt)
			{
				return;
			}
			int num = Physics.OverlapSphereNonAlloc(base.entity.transform.position, spreadRadius, _colliders, 147464);
			for (int i = 0; i < num; i++)
			{
				if (_colliders[i].GetEntity().TryGetObject<Flammable>(out var obj))
				{
					obj.ServerIsBeingSpreadTo();
				}
			}
		}
	}

	[Server]
	public void ServerSystemProcessFire()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Flammable::ServerSystemProcessFire()' called when server was not active");
			return;
		}
		if (base.entity.TryGetObject<Grabbable>(out var obj) && obj.serverIsOutbounding)
		{
			Network_state = FireState.None;
			_serverIsBeingSpreadTo = false;
		}
		switch (_state)
		{
		case FireState.None:
			if (_serverIsBeingSpreadTo)
			{
				_timer.SetTimer(heatingUpDuration);
				Network_state = FireState.HeatingUp;
			}
			break;
		case FireState.HeatingUp:
			if (_serverIsBeingSpreadTo)
			{
				_timer.DecrementTimer(_serverSpeedPercentage);
				if (_timer.IsFinished())
				{
					Network_state = FireState.Smoking;
					_timer.SetTimer(smokingDuration);
				}
			}
			else
			{
				Network_state = FireState.None;
			}
			break;
		case FireState.Smoking:
			if (_serverIsBeingSpreadTo)
			{
				_timer.DecrementTimer(_serverSpeedPercentage);
				if (_timer.IsFinished())
				{
					RequestSetFire();
				}
			}
			else
			{
				Network_state = FireState.None;
			}
			break;
		case FireState.OnFireSavable:
			_puddleTimer.DecrementTimer();
			if (_puddleTimer.IsFinished() && ServerTryCheckForPuddles())
			{
				_puddleTimer.SetTimer(puddleSetFireCheckEvery);
			}
			_timer.DecrementTimer();
			if (_timer.IsFinished())
			{
				Network_state = FireState.OnFireBurnt;
				_timer.SetTimer(onFireDuration - onFireSavableDuration);
				if (base.entity.TryGetObject<BoxHealth>(out var obj3))
				{
					obj3.RequestTakeDamage(DamageType.Burnt);
				}
				if (base.entity.TryGetObject<BoxActivator>(out var obj4))
				{
					obj4.RequestActivate(new ActivationContext(ActivationContextType.Fire));
				}
			}
			break;
		case FireState.OnFireBurnt:
			_puddleTimer.DecrementTimer();
			if (_puddleTimer.IsFinished() && ServerTryCheckForPuddles())
			{
				_puddleTimer.SetTimer(puddleSetFireCheckEvery);
			}
			_timer.DecrementTimer();
			if (!_timer.IsFinished())
			{
				break;
			}
			Network_state = FireState.Burnt;
			if (destroySelfAfterOnFire)
			{
				if (base.entity.TryGetObject<Puddle>(out var obj2))
				{
					obj2.DestroyPuddle(Puddle.PuddleDestroyStyle.Lava);
				}
				else
				{
					EntityUtil.Destroy(base.entity);
				}
			}
			break;
		default:
			throw new InvalidEnumException();
		case FireState.Burnt:
			break;
		}
	}

	[Server]
	private bool ServerTryCheckForPuddles()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean Flammable::ServerTryCheckForPuddles()' called when server was not active");
			return default(bool);
		}
		Vector3 position = base.entity.transform.position;
		if (position.y > 0.75f)
		{
			return false;
		}
		position.y = 0f;
		int num = Physics.OverlapSphereNonAlloc(base.entity.transform.position, puddleSetFireRadius, _colliders, 131072);
		for (int i = 0; i < num; i++)
		{
			if (_colliders[i].GetEntity().TryGetObject<Flammable>(out var obj))
			{
				obj.RequestSetFire();
			}
		}
		return true;
	}

	[ClientRpc]
	private void RpcIgnited()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Flammable::RpcIgnited()", -1380911549, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnUpdatePresentation()
	{
		switch (_state)
		{
		case FireState.None:
		case FireState.Burnt:
			if (smokingParticles[0].isPlaying)
			{
				smokingParticles[0].Stop();
			}
			if (onFireParticles[0].isPlaying)
			{
				onFireParticles[0].Stop();
			}
			if (onFireParticles[1].isPlaying)
			{
				onFireParticles[1].Stop();
			}
			if (fireLoopSFX.IsPlaying())
			{
				fireLoopSFX.Stop();
			}
			break;
		case FireState.HeatingUp:
			if (!smokingParticles[0].isPlaying)
			{
				smokingParticles[0].Play();
			}
			break;
		case FireState.OnFireSavable:
			if (!onFireParticles[0].isPlaying)
			{
				onFireParticles[0].Play();
			}
			if (!onFireParticles[1].isPlaying)
			{
				onFireParticles[1].Play();
			}
			if (!fireLoopSFX.IsPlaying())
			{
				fireLoopSFX.Play();
			}
			break;
		default:
			throw new InvalidEnumException();
		case FireState.Smoking:
		case FireState.OnFireBurnt:
			break;
		}
	}

	public void RequestSetFire()
	{
		if (base.isServer)
		{
			ServerSetFire();
		}
		else
		{
			CmdSetFire();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetFire()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Flammable::CmdSetFire()", 1176900428, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetFire()
	{
		BoxProps obj;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Flammable::ServerSetFire()' called when server was not active");
		}
		else if (NetworkAggroManagerBase<SprinklerManager>.instance.state == SprinklerManager.State.Inert && (!base.entity.TryGetObject<BoxProps>(out obj) || !obj.serverIsSafe) && _state != FireState.OnFireSavable && _state != FireState.OnFireBurnt && _state != FireState.Burnt)
		{
			Network_state = FireState.OnFireSavable;
			_timer.SetTimer(onFireSavableDuration);
			_puddleTimer.SetTimer(puddleSetFireCheckEvery);
			RpcIgnited();
		}
	}

	public void RequestClearFire()
	{
		if (base.isServer)
		{
			ServerClearFire();
		}
		else
		{
			CmdClearFire();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdClearFire()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Flammable::CmdClearFire()", -102160191, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerClearFire()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Flammable::ServerClearFire()' called when server was not active");
		}
		else if (CanBePutOut())
		{
			if (_state == FireState.OnFireBurnt)
			{
				Network_state = FireState.Burnt;
			}
			else
			{
				Network_state = FireState.None;
			}
		}
	}

	public bool CanBePutOut()
	{
		if (_state != FireState.OnFireSavable)
		{
			return _state == FireState.OnFireBurnt;
		}
		return true;
	}

	[Server]
	public void ServerIsBeingSpreadTo(int speedPercentage = 0)
	{
		BoxProps obj;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Flammable::ServerIsBeingSpreadTo(System.Int32)' called when server was not active");
		}
		else if (NetworkAggroManagerBase<SprinklerManager>.instance.state == SprinklerManager.State.Inert && (!base.entity.TryGetObject<BoxProps>(out obj) || !obj.serverIsSafe) && _state != FireState.Burnt)
		{
			_serverSpeedPercentage = math.max(_serverSpeedPercentage, speedPercentage);
			_serverIsBeingSpreadTo = true;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1f, 0.5f, 0f);
		Gizmos.DrawWireSphere(base.transform.position, spreadRadius);
	}

	[DevCmd("fire", "Set boxes on fire, or stop it I guess.\r\n\r\nUsage:\r\n    fire <box> -set\r\n        Sets the box on fire.\r\n\r\n    fire <box> -clear\r\n        Reset the box's fire state.\r\n\r\n    fire -all -set\r\n        Sets all boxes on fire.\r\n\r\n    fire -all -clear\r\n        Resets all boxes fire state.", new string[] { "all", "set", "clear" })]
	[DevCmdVerify("^[\\S]+ -set$")]
	[DevCmdVerify("^[\\S]+ -clear$")]
	[DevCmdVerify("^-all -set$")]
	[DevCmdVerify("^-all -clear$")]
	private static void FireDevCmd(DevCmdArg[] args)
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
				string text2 = args[1].name;
				if (!(text2 == "set"))
				{
					if (text2 == "clear")
					{
						NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdAllBoxesClearFire();
					}
					else
					{
						Debug.LogWarning("Unknown argument! (" + args[1].name + ")");
					}
				}
				else
				{
					NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdAllBoxesSetFire();
				}
			}
			else
			{
				Debug.LogWarning("Unknown argument! (" + args[0].name + ")");
			}
		}
		else if (DevCmdUtil.TryGetEntityFromDevCmdName(args[0].value, out box))
		{
			string text2 = args[1].name;
			if (!(text2 == "set"))
			{
				if (text2 == "clear")
				{
					NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdBoxClearFire(box);
				}
				else
				{
					Debug.LogWarning("Unknown argument! (" + args[1].name + ")");
				}
			}
			else
			{
				NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdBoxSetFire(box);
			}
		}
		else
		{
			Debug.LogWarning("Could not find an entity with dev cmd name! (" + args[0].value + ")");
		}
	}

	[DevCmdCompleteFunction("fire", "", DevCmdCompleteFlags.Sort)]
	private static string[] FireBoxDevComplete()
	{
		return DevCmdUtil.GetEntityNames<Flammable>();
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (base.entity.tags.Has(CCTags.TAG_VOLATILE))
		{
			ServerSetFire();
		}
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (base.isServer)
		{
			ServerClearFire();
		}
	}

	[Server]
	public bool ServerFlammableCanBePutOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean Flammable::ServerFlammableCanBePutOut()' called when server was not active");
			return default(bool);
		}
		return CanBePutOut();
	}

	[Server]
	public void ServerFlammablePutOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Flammable::ServerFlammablePutOut()' called when server was not active");
		}
		else
		{
			RequestClearFire();
		}
	}

	static Flammable()
	{
		_colliders = new Collider[128];
		RemoteProcedureCalls.RegisterCommand(typeof(Flammable), "System.Void Flammable::CmdSetFire()", InvokeUserCode_CmdSetFire, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Flammable), "System.Void Flammable::CmdClearFire()", InvokeUserCode_CmdClearFire, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Flammable), "System.Void Flammable::RpcIgnited()", InvokeUserCode_RpcIgnited);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcIgnited()
	{
		fireIgniteSFX.Play();
	}

	protected static void InvokeUserCode_RpcIgnited(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcIgnited called on server.");
		}
		else
		{
			((Flammable)obj).UserCode_RpcIgnited();
		}
	}

	protected void UserCode_CmdSetFire()
	{
		ServerSetFire();
	}

	protected static void InvokeUserCode_CmdSetFire(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetFire called on client.");
		}
		else
		{
			((Flammable)obj).UserCode_CmdSetFire();
		}
	}

	protected void UserCode_CmdClearFire()
	{
		ServerClearFire();
	}

	protected static void InvokeUserCode_CmdClearFire(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdClearFire called on client.");
		}
		else
		{
			((Flammable)obj).UserCode_CmdClearFire();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_FireState(writer, _state);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_FireState(writer, _state);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _state, null, GeneratedNetworkCode._Read_FireState(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _state, null, GeneratedNetworkCode._Read_FireState(reader));
		}
	}
}
