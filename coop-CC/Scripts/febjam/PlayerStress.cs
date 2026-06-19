using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerStress : NetworkEntityBehaviourBase, IShiftChanged
{
	[Min(0f)]
	public float stressDecayCooldown = 3f;

	[Min(0f)]
	public float stressDecayRate = 0.25f;

	[Min(0f)]
	public float stressCrashOutDuration = 6f;

	[Min(0f)]
	public float stressBumpAddAmount = 0.25f;

	[Min(0f)]
	public float crashOutInvulnerableDuration = 1f;

	[SyncVar]
	private float _syncStressValue;

	[SyncVar]
	private float _syncStressNormalizedValue;

	[SyncVar]
	private bool _syncCrashingOut;

	private float _localPlayerStressRate;

	private Timer _localPlayerTimer;

	private Timer _localInvulTimer;

	[SyncVar]
	public bool syncInvulnerable;

	public ShakeStrength collisionShakeStrength;

	[Header("obj refs")]
	public VehicleController vc;

	public PlayerEffects playerEffects;

	public EventReference crashOutSfx;

	private EventInstance _crashOutSfxInstance;

	public EventReference crashoutVO;

	private bool _pauseDecay;

	public float stressNormalizedValue => _syncStressNormalizedValue;

	public bool crashingOut => _syncCrashingOut;

	public int crashOutCount { get; private set; }

	public int shiftCrashOutCount { get; private set; }

	public float Network_syncStressValue
	{
		get
		{
			return _syncStressValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncStressValue, 1uL, null);
		}
	}

	public float Network_syncStressNormalizedValue
	{
		get
		{
			return _syncStressNormalizedValue;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncStressNormalizedValue, 2uL, null);
		}
	}

	public bool Network_syncCrashingOut
	{
		get
		{
			return _syncCrashingOut;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncCrashingOut, 4uL, null);
		}
	}

	public bool NetworksyncInvulnerable
	{
		get
		{
			return syncInvulnerable;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncInvulnerable, 8uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_crashOutSfxInstance = RuntimeManager.CreateInstance(crashOutSfx);
	}

	protected override void OnEntityDestroyed()
	{
		_crashOutSfxInstance.release();
	}

	[UpdateInGroup(-100)]
	protected override void OnUpdateSimulationEarly()
	{
		if (base.isLocalPlayer)
		{
			_localPlayerStressRate = 0f;
		}
	}

	[UpdateInGroup(10110)]
	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		NetworksyncInvulnerable = !_localInvulTimer.IsFinished();
		_localInvulTimer.DecrementTimer();
		if (NetworkAggroManagerBase<ShiftManager>.instance.playersLockedIn)
		{
			Network_syncStressValue = 0f;
			if (_syncCrashingOut)
			{
				Network_syncCrashingOut = false;
				_localInvulTimer.SetTimer(crashOutInvulnerableDuration);
				base.entity.GetObject<VehicleController>().CrashingOutFinished();
			}
			return;
		}
		if (_syncCrashingOut)
		{
			_localPlayerTimer.DecrementTimer();
			Network_syncStressValue = Mathf.Clamp01(_localPlayerTimer.GetSecondsRemaining() / stressCrashOutDuration) * LocalPlayerGetStressBarAmount();
			if (_localPlayerTimer.IsFinished())
			{
				Network_syncCrashingOut = false;
				_localInvulTimer.SetTimer(crashOutInvulnerableDuration);
				base.entity.GetObject<VehicleController>().CrashingOutFinished();
			}
			return;
		}
		float localPlayerStressRate = _localPlayerStressRate;
		localPlayerStressRate += playerEffects.GetStressChangeRate();
		if (localPlayerStressRate <= 0f)
		{
			_localPlayerTimer.DecrementTimer();
			if (_localPlayerTimer.IsFinished() && !_pauseDecay)
			{
				localPlayerStressRate -= stressDecayRate;
			}
		}
		LocalPlayerAddStress(localPlayerStressRate * (1f / 60f), sendEvent: false);
	}

	protected override void OnUpdatePresentationEarly()
	{
		Network_syncStressNormalizedValue = math.saturate(_syncStressValue / LocalPlayerGetStressBarAmount());
	}

	public void RequestBumpStress()
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerBumpStress();
		}
		else
		{
			ServerBumpStress();
		}
	}

	private void LocalPlayerBumpStress()
	{
		LocalPlayerAddStress(stressBumpAddAmount, sendEvent: true);
		base.entity.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
	}

	public void TutorialPrepareForStress()
	{
		_pauseDecay = true;
		Network_syncStressValue = 0f;
		Network_syncCrashingOut = false;
		Network_syncStressNormalizedValue = 0f;
	}

	public void TutorialFinishedWithStress()
	{
		_pauseDecay = false;
	}

	[Server]
	private void ServerBumpStress()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerStress::ServerBumpStress()' called when server was not active");
		}
		else
		{
			RpcBumpStress();
		}
	}

	[TargetRpc]
	private void RpcBumpStress()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(null, "System.Void PlayerStress::RpcBumpStress()", -1642313217, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void RequestAddStress(float value, bool sendEvent)
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerAddStress(value, sendEvent);
		}
		else
		{
			ServerAddStress(value, sendEvent);
		}
	}

	private void LocalPlayerAddStress(float value, bool sendEvent)
	{
		if (_syncCrashingOut || !_localInvulTimer.IsFinished() || NetworkAggroManagerBase<ShiftManager>.instance.playersLockedIn || NetworkAggroManagerBase<ShiftManager>.instance.isTransitioning)
		{
			return;
		}
		PlayerUpgrades playerUpgrades = base.entity.GetObject<PlayerUpgrades>();
		if (value > 0f)
		{
			if (playerUpgrades.HasUpgrade(PlayerUpgrade.StressDecayUp))
			{
				_localPlayerTimer.SetTimerIfGreater(playerUpgrades.stressDecayCooldownUpgraded);
			}
			else
			{
				_localPlayerTimer.SetTimerIfGreater(stressDecayCooldown);
			}
			if (sendEvent)
			{
				base.eventManager.QueueGlobalEvent(default(EvLocalPlayerStressAdded));
			}
		}
		Network_syncStressValue = _syncStressValue + value;
		float num = LocalPlayerGetStressBarAmount();
		if (_syncStressValue >= num)
		{
			LocalPlayerCrashOut();
		}
		Network_syncStressValue = math.clamp(_syncStressValue, 0f, num);
	}

	private float LocalPlayerGetStressBarAmount()
	{
		PlayerUpgrades playerUpgrades = base.entity.GetObject<PlayerUpgrades>();
		float result = 1f;
		if (playerUpgrades.HasUpgrade(PlayerUpgrade.StressAmountUp))
		{
			result = playerUpgrades.stressBarUpAmount;
		}
		return result;
	}

	[Server]
	private void ServerAddStress(float value, bool sendEvent)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerStress::ServerAddStress(System.Single,System.Boolean)' called when server was not active");
		}
		else
		{
			RpcAddStress(value, sendEvent);
		}
	}

	[TargetRpc]
	private void RpcAddStress(float value, bool sendEvent)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(value);
		writer.WriteBool(sendEvent);
		SendTargetRPCInternal(null, "System.Void PlayerStress::RpcAddStress(System.Single,System.Boolean)", 1071573648, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void RequestCrashOut()
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerCrashOut();
		}
		else
		{
			ServerCrashOut();
		}
	}

	private void LocalPlayerCrashOut()
	{
		if (!_syncCrashingOut && !NetworkAggroManagerBase<ShiftManager>.instance.playersLockedIn)
		{
			crashOutCount++;
			shiftCrashOutCount++;
			Aggro.Core.Platform.AddStat("stat_crashout_count", 1);
			NetworkAggroManagerBase<VoiceOverManager>.instance.RequestPlayCrashOut();
			AggroManagerBase<CameraShake>.instance.AddShakeFromPosition(collisionShakeStrength, base.transform.position);
			Network_syncCrashingOut = true;
			_localPlayerTimer.SetTimer(stressCrashOutDuration);
			base.entity.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
			CmdAddCrashOut();
			_crashOutSfxInstance.set3DAttributes(base.entity.transform.To3DAttributes());
			RuntimeManager.AttachInstanceToGameObject(_crashOutSfxInstance, base.entity.transform);
			_crashOutSfxInstance.start();
			vc.CrashingOut();
			base.entity.GetObject<NitroController>().LocalPlayerStopNitro();
		}
	}

	[Server]
	private void ServerCrashOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerStress::ServerCrashOut()' called when server was not active");
		}
		else
		{
			RpcCrashOut();
		}
	}

	[TargetRpc]
	private void RpcCrashOut()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(null, "System.Void PlayerStress::RpcCrashOut()", 1611850814, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void LocalPlayerAddStressRate(float rate)
	{
		_localPlayerStressRate += rate;
	}

	public void RequestStopCrashOut()
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerStopCrashOut();
		}
		else
		{
			ServerStopCrashOut();
		}
	}

	private void LocalPlayerStopCrashOut()
	{
		if (_syncCrashingOut)
		{
			Network_syncStressValue = 0f;
			Network_syncCrashingOut = false;
			base.entity.GetObject<VehicleController>().CrashingOutFinished();
		}
	}

	[Server]
	private void ServerStopCrashOut()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerStress::ServerStopCrashOut()' called when server was not active");
		}
		else
		{
			RpcStopCrashOut();
		}
	}

	[TargetRpc]
	private void RpcStopCrashOut()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(null, "System.Void PlayerStress::RpcStopCrashOut()", -789058186, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void RequestClearStress()
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerClearStress();
		}
		else
		{
			ServerClearStress();
		}
	}

	private void LocalPlayerClearStress()
	{
		if (_syncCrashingOut)
		{
			LocalPlayerStopCrashOut();
		}
		else
		{
			Network_syncStressValue = 0f;
		}
	}

	[Server]
	private void ServerClearStress()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerStress::ServerClearStress()' called when server was not active");
		}
		else
		{
			RpcClearStress();
		}
	}

	[TargetRpc]
	private void RpcClearStress()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(null, "System.Void PlayerStress::RpcClearStress()", 940977734, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdAddCrashOut()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerStress::CmdAddCrashOut()", -1113856624, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc(includeOwner = false)]
	private void RpcCrashedOut()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerStress::RpcCrashedOut()", -1709368515, writer, 0, includeOwner: false);
		NetworkWriterPool.Return(writer);
	}

	[DevCmd("stress", "Various dev cmds for interaction with the PlayerStress.\r\n\r\nUsage:\r\n    stress\r\n        Show current stress level of the local player.\r\n\r\n    stress -crashout\r\n        Start a crashout on the local player with the default duration.\r\n\r\n    stress -reset\r\n        Resets local player's stress level to 0.\r\n", new string[] { "crashout", "reset" })]
	private static void StressDevCmd(DevCmdArg[] args)
	{
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return;
		}
		PlayerStress playerStress = player.GetObject<PlayerStress>();
		if (args.Length == 0)
		{
			Debug.Log($"Current Stress Level: {playerStress._syncStressValue:F1}");
			return;
		}
		string text = args[0].name;
		if (!(text == "crashout"))
		{
			if (text == "reset")
			{
				playerStress.LocalPlayerClearStress();
			}
			else
			{
				Debug.LogWarning("Unknown argument " + args[0].name);
			}
		}
		else
		{
			playerStress.LocalPlayerCrashOut();
		}
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		shiftCrashOutCount = 0;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcBumpStress()
	{
		LocalPlayerBumpStress();
	}

	protected static void InvokeUserCode_RpcBumpStress(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcBumpStress called on server.");
		}
		else
		{
			((PlayerStress)obj).UserCode_RpcBumpStress();
		}
	}

	protected void UserCode_RpcAddStress__Single__Boolean(float value, bool sendEvent)
	{
		LocalPlayerAddStress(value, sendEvent);
	}

	protected static void InvokeUserCode_RpcAddStress__Single__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcAddStress called on server.");
		}
		else
		{
			((PlayerStress)obj).UserCode_RpcAddStress__Single__Boolean(reader.ReadFloat(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcCrashOut()
	{
		LocalPlayerCrashOut();
	}

	protected static void InvokeUserCode_RpcCrashOut(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcCrashOut called on server.");
		}
		else
		{
			((PlayerStress)obj).UserCode_RpcCrashOut();
		}
	}

	protected void UserCode_RpcStopCrashOut()
	{
		LocalPlayerStopCrashOut();
	}

	protected static void InvokeUserCode_RpcStopCrashOut(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcStopCrashOut called on server.");
		}
		else
		{
			((PlayerStress)obj).UserCode_RpcStopCrashOut();
		}
	}

	protected void UserCode_RpcClearStress()
	{
		LocalPlayerStopCrashOut();
	}

	protected static void InvokeUserCode_RpcClearStress(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcClearStress called on server.");
		}
		else
		{
			((PlayerStress)obj).UserCode_RpcClearStress();
		}
	}

	protected void UserCode_CmdAddCrashOut()
	{
		RpcCrashedOut();
	}

	protected static void InvokeUserCode_CmdAddCrashOut(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddCrashOut called on client.");
		}
		else
		{
			((PlayerStress)obj).UserCode_CmdAddCrashOut();
		}
	}

	protected void UserCode_RpcCrashedOut()
	{
		_crashOutSfxInstance.set3DAttributes(base.entity.transform.To3DAttributes());
		RuntimeManager.AttachInstanceToGameObject(_crashOutSfxInstance, base.entity.transform);
		_crashOutSfxInstance.start();
	}

	protected static void InvokeUserCode_RpcCrashedOut(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCrashedOut called on server.");
		}
		else
		{
			((PlayerStress)obj).UserCode_RpcCrashedOut();
		}
	}

	static PlayerStress()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerStress), "System.Void PlayerStress::CmdAddCrashOut()", InvokeUserCode_CmdAddCrashOut, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStress), "System.Void PlayerStress::RpcCrashedOut()", InvokeUserCode_RpcCrashedOut);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStress), "System.Void PlayerStress::RpcBumpStress()", InvokeUserCode_RpcBumpStress);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStress), "System.Void PlayerStress::RpcAddStress(System.Single,System.Boolean)", InvokeUserCode_RpcAddStress__Single__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStress), "System.Void PlayerStress::RpcCrashOut()", InvokeUserCode_RpcCrashOut);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStress), "System.Void PlayerStress::RpcStopCrashOut()", InvokeUserCode_RpcStopCrashOut);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStress), "System.Void PlayerStress::RpcClearStress()", InvokeUserCode_RpcClearStress);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(_syncStressValue);
			writer.WriteFloat(_syncStressNormalizedValue);
			writer.WriteBool(_syncCrashingOut);
			writer.WriteBool(syncInvulnerable);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(_syncStressValue);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(_syncStressNormalizedValue);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(_syncCrashingOut);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(syncInvulnerable);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncStressValue, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncStressNormalizedValue, null, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref _syncCrashingOut, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncInvulnerable, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncStressValue, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncStressNormalizedValue, null, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncCrashingOut, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncInvulnerable, null, reader.ReadBool());
		}
	}
}
