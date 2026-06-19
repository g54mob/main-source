using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class AchievementManager : NetworkAggroManagerBase<AchievementManager>
{
	public string[] achievementIds;

	private bool _hasSentFullShelfAchievement;

	private static List<GrabbableHolder> _holders;

	private static List<Entity> _shelves;

	public const string STAT_CRASHOUT_COUNT = "stat_crashout_count";

	public const string STAT_BOOST_COUNT = "stat_boost_count";

	public const string STAT_BOXES_SHIPPED = "stat_shipped_boxes";

	public const string STAT_EXPLOSIVES_SHIPPED = "stat_shipped_explosives";

	public const string STAT_ANIMALS_SHIPPED = "stat_shipped_animals";

	public const string STAT_DRIFT_DISTANCE = "stat_drift_distance";

	public const string STAT_FIRE_EXTINGUISHED = "stat_fires_extinguished";

	public const string STAT_TRASH_DESTROYED = "stat_junk_destroyed";

	public const string STAT_TRASH_MONEY = "stat_trash_money";

	public const string STAT_BONUS_SHIPPED = "stat_bonus_shipped";

	public const string STAT_BANANA_SLIPS = "stat_banana_slips";

	public const string STAT_MESSES_CLEANED = "stat_messes_cleaned";

	public const string STAT_TIPTAP_MINUTES = "stat_tiptap_minutes";

	public const string ACH_HOARDER = "ach_hoarder";

	public const string ACH_FORKLIFT_UPGRADED = "ach_forklift_upgraded";

	public const string ACH_FORKLIFT_SUPER_UPGRADED = "ach_forklift_superupgarded";

	public const string ACH_NO_CRASHOUT_SHIFT = "ach_nocrashout_shift";

	public const string ACH_NO_CRASHOUT_CONTRACT = "ach_nocrashout_contract";

	public const string ACH_BELLS_SOME = "ach_bells_50";

	public const string ACH_BELLS_ALL = "ach_bells_all";

	public const string ACH_UNLOCKED_CONTRACTS = "ach_unlocked_all_contracts";

	public const string ACH_UNLOCKED_COSTUMES = "ach_unlocked_all_costumes";

	public const string ACH_SRANK_FIRST = "ach_srank_first";

	public const string ACH_SRANK_LAST = "ach_srank_last";

	public const string ACH_SHELF_FULL = "ach_shelf_full";

	public const string ACH_ZOOKEEPER = "ach_zookeeper";

	public const string ACH_CHICKEN_JOCKEY = "ach_chicken_jockey";

	public const string ACH_BEE_KEEPAWAY = "ach_bee_keepaway";

	public const string ACH_BREAKROOM_GOAL = "ach_breakroom_goal";

	public const string ACH_TIPTAP_SHARE = "ach_tiptap_share";

	public const string ACH_TIPTAP_FIRST = "ach_tiptap_first";

	public const string ACH_TIPTAP_PRO = "ach_tiptap_pro";

	private Dictionary<string, short> _idToIndex = new Dictionary<string, short>();

	protected override void OnInitializeBehaviour()
	{
		for (int i = 0; i < achievementIds.Length; i++)
		{
			_idToIndex[achievementIds[i]] = (short)i;
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (!base.isServer || _hasSentFullShelfAchievement)
		{
			return;
		}
		_shelves.Clear();
		base.entityManager.GetAllEntitiesWith<StationShelf>(_shelves);
		for (int i = 0; i < _shelves.Count; i++)
		{
			if (_hasSentFullShelfAchievement)
			{
				break;
			}
			_holders.Clear();
			_shelves[i].GetObjects(_holders);
			if (_holders.Count <= 0)
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < _holders.Count; j++)
			{
				GrabbableHolder grabbableHolder = _holders[j];
				if (!grabbableHolder.serverHeldEntity.Exists())
				{
					flag = false;
					break;
				}
				if (grabbableHolder.serverHeldEntity.GetObject<Grabbable>().GetStackCount() < 4)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				_hasSentFullShelfAchievement = true;
				RpcSendFullShelfAchievement();
				break;
			}
		}
	}

	[ClientRpc]
	private void RpcSendFullShelfAchievement()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void AchievementManager::RpcSendFullShelfAchievement()", -94659278, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[DevCmd("platform", "Various cmds for interaction with the platform (Steam probably)\r\n\r\nUsage:\r\n    platform -reset\r\n        Reset all stats and achievements.\r\n\r\n    platform -flush\r\n        Flush current stats and achievements.\r\n", new string[] { "reset", "flush" })]
	[DevCmdVerify("^-reset+$")]
	[DevCmdVerify("^-flush+$")]
	private static void PlatformDevCmd(DevCmdArg[] args)
	{
		string text = args[0].name;
		if (!(text == "reset"))
		{
			if (text == "flush")
			{
				Platform.FlushStatsAndAchievements();
				Debug.Log("Flushed Stats and Achievements!");
			}
			else
			{
				Debug.LogWarning("Unknown argument! (" + args[0].name + ")");
			}
		}
		else
		{
			Platform.ResetStatsAndAchievements();
			Debug.Log("Reset Stats and Achievements!");
		}
	}

	[Server]
	public void ServerAddStat(string id, int count)
	{
		short value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AchievementManager::ServerAddStat(System.String,System.Int32)' called when server was not active");
		}
		else if (_idToIndex.TryGetValue(id, out value))
		{
			RpcAddCount(value, (short)count);
		}
		else
		{
			Debug.LogWarning("Achievement id not found! (" + id + ")");
		}
	}

	[Server]
	public void ServerAddStat(NetworkConnectionToClient target, string id, int count)
	{
		short value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AchievementManager::ServerAddStat(Mirror.NetworkConnectionToClient,System.String,System.Int32)' called when server was not active");
		}
		else if (_idToIndex.TryGetValue(id, out value))
		{
			RpcAddCount(target, value, (short)count);
		}
		else
		{
			Debug.LogWarning("Achievement id not found! (" + id + ")");
		}
	}

	[Server]
	public void ServerUnlockAchievement(string id)
	{
		short value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AchievementManager::ServerUnlockAchievement(System.String)' called when server was not active");
		}
		else if (_idToIndex.TryGetValue(id, out value))
		{
			RpcUnlockAchievement(value);
		}
		else
		{
			Debug.LogWarning("Achievement id not found! (" + id + ")");
		}
	}

	[Server]
	public void ServerUnlockAchievement(NetworkConnectionToClient target, string id)
	{
		short value;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AchievementManager::ServerUnlockAchievement(Mirror.NetworkConnectionToClient,System.String)' called when server was not active");
		}
		else if (_idToIndex.TryGetValue(id, out value))
		{
			RpcUnlockAchievement(target, value);
		}
		else
		{
			Debug.LogWarning("Achievement id not found! (" + id + ")");
		}
	}

	[ClientRpc]
	private void RpcAddCount(short index, short count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		writer.WriteShort(count);
		SendRPCInternal("System.Void AchievementManager::RpcAddCount(System.Int16,System.Int16)", 1414798432, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcAddCount(NetworkConnectionToClient target, short index, short count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		writer.WriteShort(count);
		SendTargetRPCInternal(target, "System.Void AchievementManager::RpcAddCount(Mirror.NetworkConnectionToClient,System.Int16,System.Int16)", 1025121289, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUnlockAchievement(short index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		SendRPCInternal("System.Void AchievementManager::RpcUnlockAchievement(System.Int16)", -97498964, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcUnlockAchievement(NetworkConnectionToClient target, short index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteShort(index);
		SendTargetRPCInternal(target, "System.Void AchievementManager::RpcUnlockAchievement(Mirror.NetworkConnectionToClient,System.Int16)", 514328445, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	static AchievementManager()
	{
		_holders = new List<GrabbableHolder>();
		_shelves = new List<Entity>();
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementManager), "System.Void AchievementManager::RpcSendFullShelfAchievement()", InvokeUserCode_RpcSendFullShelfAchievement);
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementManager), "System.Void AchievementManager::RpcAddCount(System.Int16,System.Int16)", InvokeUserCode_RpcAddCount__Int16__Int16);
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementManager), "System.Void AchievementManager::RpcUnlockAchievement(System.Int16)", InvokeUserCode_RpcUnlockAchievement__Int16);
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementManager), "System.Void AchievementManager::RpcAddCount(Mirror.NetworkConnectionToClient,System.Int16,System.Int16)", InvokeUserCode_RpcAddCount__NetworkConnectionToClient__Int16__Int16);
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementManager), "System.Void AchievementManager::RpcUnlockAchievement(Mirror.NetworkConnectionToClient,System.Int16)", InvokeUserCode_RpcUnlockAchievement__NetworkConnectionToClient__Int16);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcSendFullShelfAchievement()
	{
		Platform.UnlockAchievement("ach_shelf_full");
	}

	protected static void InvokeUserCode_RpcSendFullShelfAchievement(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSendFullShelfAchievement called on server.");
		}
		else
		{
			((AchievementManager)obj).UserCode_RpcSendFullShelfAchievement();
		}
	}

	protected void UserCode_RpcAddCount__Int16__Int16(short index, short count)
	{
		Platform.AddStat(achievementIds[index], count);
	}

	protected static void InvokeUserCode_RpcAddCount__Int16__Int16(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddCount called on server.");
		}
		else
		{
			((AchievementManager)obj).UserCode_RpcAddCount__Int16__Int16(reader.ReadShort(), reader.ReadShort());
		}
	}

	protected void UserCode_RpcAddCount__NetworkConnectionToClient__Int16__Int16(NetworkConnectionToClient target, short index, short count)
	{
		Platform.AddStat(achievementIds[index], count);
	}

	protected static void InvokeUserCode_RpcAddCount__NetworkConnectionToClient__Int16__Int16(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcAddCount called on server.");
		}
		else
		{
			((AchievementManager)obj).UserCode_RpcAddCount__NetworkConnectionToClient__Int16__Int16(null, reader.ReadShort(), reader.ReadShort());
		}
	}

	protected void UserCode_RpcUnlockAchievement__Int16(short index)
	{
		Platform.UnlockAchievement(achievementIds[index]);
	}

	protected static void InvokeUserCode_RpcUnlockAchievement__Int16(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUnlockAchievement called on server.");
		}
		else
		{
			((AchievementManager)obj).UserCode_RpcUnlockAchievement__Int16(reader.ReadShort());
		}
	}

	protected void UserCode_RpcUnlockAchievement__NetworkConnectionToClient__Int16(NetworkConnectionToClient target, short index)
	{
		Platform.UnlockAchievement(achievementIds[index]);
	}

	protected static void InvokeUserCode_RpcUnlockAchievement__NetworkConnectionToClient__Int16(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcUnlockAchievement called on server.");
		}
		else
		{
			((AchievementManager)obj).UserCode_RpcUnlockAchievement__NetworkConnectionToClient__Int16(null, reader.ReadShort());
		}
	}
}
