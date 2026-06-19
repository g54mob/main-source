using System;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerUpgrades : NetworkEntityBehaviourBase
{
	[Range(-100f, 100f)]
	public int speedUpVehicleSpeedPercentage = 50;

	[Range(-100f, 100f)]
	public int nitroChargePercentage = 50;

	[Range(0f, 1f)]
	public float blastProtectedStressAddAmount = 0.5f;

	[Min(0f)]
	public float stressBarUpAmount = 1.5f;

	[Min(0f)]
	public float stressDecayCooldownUpgraded = 2.5f;

	[Space]
	public ParticleSystem vfxSystem;

	[Space]
	[Min(1f)]
	public int achievementSuperUpgradedCount = 5;

	[SyncVar]
	private int _syncUpgrades;

	public int upgradeCount { get; private set; }

	public int Network_syncUpgrades
	{
		get
		{
			return _syncUpgrades;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncUpgrades, 1uL, null);
		}
	}

	public bool HasUpgrade(PlayerUpgrade upgrade)
	{
		return (_syncUpgrades & (1 << (int)upgrade)) != 0;
	}

	[Server]
	public void ServerSetUpgrade(PlayerUpgrade upgrade)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerUpgrades::ServerSetUpgrade(PlayerUpgrade)' called when server was not active");
			return;
		}
		Network_syncUpgrades = _syncUpgrades | (1 << (int)upgrade);
		RpcUpgradeReceived();
	}

	[Command]
	private void CmdAddUpgrade(PlayerUpgrade upgrade)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PlayerUpgrade(writer, upgrade);
		SendCommandInternal("System.Void PlayerUpgrades::CmdAddUpgrade(PlayerUpgrade)", -1701691135, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdRemoveUpgrade(PlayerUpgrade upgrade)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PlayerUpgrade(writer, upgrade);
		SendCommandInternal("System.Void PlayerUpgrades::CmdRemoveUpgrade(PlayerUpgrade)", 1235684118, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUpgradeReceived()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PlayerUpgrades::RpcUpgradeReceived()", 1251062897, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected override void OnUpdateSimulationEarly()
	{
		if (base.isLocalPlayer)
		{
			PlayerEffects playerEffects = base.entity.GetObject<PlayerEffects>();
			if (HasUpgrade(PlayerUpgrade.SpeedUp))
			{
				playerEffects.AddVehicleSpeedPercentageRaw(speedUpVehicleSpeedPercentage);
			}
			if (HasUpgrade(PlayerUpgrade.NitroChargeUp))
			{
				playerEffects.AddNitroChargePercentageRaw(nitroChargePercentage);
			}
		}
	}

	[DevCmd("upgrade", "Enable or disable forklift upgrades.\r\n\r\nUsage:\r\n    upgrade\r\n        Prints the current upgrades.\r\n\r\n    upgrade <upgrade_name>\r\n        Toggles the supplied forklift upgrade.", new string[] { })]
	[DevCmdVerify("^[\\S]+$")]
	[DevCmdVerify("^$")]
	[DevCmdComplete("", DevCmdCompleteFlags.ValueCaseInsensitive, typeof(PlayerUpgrade))]
	private static void UpgradeDevCmd(DevCmdArg[] args)
	{
		if (GameUtil.isLobby)
		{
			Debug.LogWarning("Can't interact with upgrades in the lobby!");
			return;
		}
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			Debug.LogWarning("No local player!");
			return;
		}
		string[] names = Enum.GetNames(typeof(PlayerUpgrade));
		PlayerUpgrades playerUpgrades = player.GetObject<PlayerUpgrades>();
		if (args.Length != 0)
		{
			if (Enum.TryParse<PlayerUpgrade>(args[0].value, ignoreCase: true, out var result))
			{
				if (playerUpgrades.HasUpgrade(result))
				{
					playerUpgrades.CmdRemoveUpgrade(result);
				}
				else
				{
					playerUpgrades.CmdAddUpgrade(result);
				}
			}
			else
			{
				Debug.LogWarning("Unknown upgrade! " + args[0].value);
			}
			return;
		}
		int syncUpgrades = playerUpgrades._syncUpgrades;
		string text = "Upgrades:";
		for (int i = 0; i < names.Length; i++)
		{
			if ((syncUpgrades & (1 << i)) != 0)
			{
				text = text + " " + names[i];
			}
		}
		Debug.Log(text);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddUpgrade__PlayerUpgrade(PlayerUpgrade upgrade)
	{
		ServerSetUpgrade(upgrade);
	}

	protected static void InvokeUserCode_CmdAddUpgrade__PlayerUpgrade(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddUpgrade called on client.");
		}
		else
		{
			((PlayerUpgrades)obj).UserCode_CmdAddUpgrade__PlayerUpgrade(GeneratedNetworkCode._Read_PlayerUpgrade(reader));
		}
	}

	protected void UserCode_CmdRemoveUpgrade__PlayerUpgrade(PlayerUpgrade upgrade)
	{
		Network_syncUpgrades = _syncUpgrades & ~(1 << (int)upgrade);
	}

	protected static void InvokeUserCode_CmdRemoveUpgrade__PlayerUpgrade(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemoveUpgrade called on client.");
		}
		else
		{
			((PlayerUpgrades)obj).UserCode_CmdRemoveUpgrade__PlayerUpgrade(GeneratedNetworkCode._Read_PlayerUpgrade(reader));
		}
	}

	protected void UserCode_RpcUpgradeReceived()
	{
		upgradeCount++;
		vfxSystem.Play();
		if (base.isLocalPlayer)
		{
			Platform.UnlockAchievement("ach_forklift_upgraded");
			if (upgradeCount >= achievementSuperUpgradedCount)
			{
				Platform.UnlockAchievement("ach_forklift_superupgarded");
			}
		}
	}

	protected static void InvokeUserCode_RpcUpgradeReceived(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpgradeReceived called on server.");
		}
		else
		{
			((PlayerUpgrades)obj).UserCode_RpcUpgradeReceived();
		}
	}

	static PlayerUpgrades()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerUpgrades), "System.Void PlayerUpgrades::CmdAddUpgrade(PlayerUpgrade)", InvokeUserCode_CmdAddUpgrade__PlayerUpgrade, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerUpgrades), "System.Void PlayerUpgrades::CmdRemoveUpgrade(PlayerUpgrade)", InvokeUserCode_CmdRemoveUpgrade__PlayerUpgrade, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerUpgrades), "System.Void PlayerUpgrades::RpcUpgradeReceived()", InvokeUserCode_RpcUpgradeReceived);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_syncUpgrades);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_syncUpgrades);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncUpgrades, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncUpgrades, null, reader.ReadVarInt());
		}
	}
}
