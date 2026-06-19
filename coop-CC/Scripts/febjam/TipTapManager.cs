using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class TipTapManager : NetworkAggroManagerBase<TipTapManager>, IShiftChanged
{
	[Min(1f)]
	public int tipTapsPerShift = 3;

	public List<TipTapObject> _available = new List<TipTapObject>();

	public List<TipTapObject> _availableSeen = new List<TipTapObject>();

	public List<TipTapObject> _availableUnseen = new List<TipTapObject>();

	public List<TipTapObject> sharedTipTaps = new List<TipTapObject>();

	public List<TipTapObject> collectedTipTaps = new List<TipTapObject>();

	public List<TipTapObject> liveTipTaps = new List<TipTapObject>();

	private double _tipTapSeconds;

	private double _tipTapSecondsThisShift;

	public override void OnStartClient()
	{
		foreach (TipTapObject asset in GlobalScriptableObject<TipTapGlobalData>.instance.tipTaps.assets)
		{
			if (asset != null)
			{
				_available.Add(asset);
			}
		}
		GenerateCollectedTipTaps();
	}

	private void GenerateCollectedTipTaps()
	{
		_available.Randomize(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		_availableUnseen.Clear();
		_availableSeen.Clear();
		foreach (TipTapObject item in _available)
		{
			if (SaveManager.data.IsTipTapSeen(item))
			{
				_availableSeen.Add(item);
			}
			else
			{
				_availableUnseen.Add(item);
			}
		}
		_availableSeen.Randomize(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		_availableUnseen.Randomize(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		collectedTipTaps.Clear();
		int num = math.min(_available.Count, tipTapsPerShift);
		while (collectedTipTaps.Count < num)
		{
			if ((collectedTipTaps.Count < 2 && _availableUnseen.Count > 0) || _availableSeen.Count < num - collectedTipTaps.Count)
			{
				TipTapObject tipTapObject = _availableUnseen[0];
				collectedTipTaps.Add(tipTapObject);
				tipTapObject.activeIndex = UnityEngine.Random.Range(0, tipTapObject.videoClips.Count);
				_availableUnseen.Remove(tipTapObject);
			}
			else
			{
				TipTapObject tipTapObject2 = _availableSeen[0];
				collectedTipTaps.Add(tipTapObject2);
				tipTapObject2.activeIndex = UnityEngine.Random.Range(0, tipTapObject2.videoClips.Count);
				_availableSeen.Remove(tipTapObject2);
			}
		}
		collectedTipTaps.Randomize(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
	}

	public void RefreshLiveFeed()
	{
		liveTipTaps.Clear();
		for (int i = 0; i < collectedTipTaps.Count; i++)
		{
			liveTipTaps.Add(collectedTipTaps[i]);
		}
		for (int j = 0; j < sharedTipTaps.Count; j++)
		{
			liveTipTaps.Insert(0, sharedTipTaps[j]);
			collectedTipTaps.Insert(0, sharedTipTaps[j]);
			sharedTipTaps.RemoveAt(j);
		}
	}

	public void RequestShareTipTap(TipTapObject tipTap)
	{
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Shift)
		{
			if (SaveManager.isInitialized)
			{
				SaveManager.data.TipTapShared(tipTap);
			}
			CmdShareTipTap(tipTap.networkId);
			Platform.UnlockAchievement("ach_tiptap_share");
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdShareTipTap(NetScrobId id, NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkScrob(id);
		SendCommandInternal("System.Void TipTapManager::CmdShareTipTap(Aggro.Core.Networking.NetScrobId,Mirror.NetworkConnectionToClient)", 10102088, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcTipTapShared(NetworkConnectionToClient target, Entity sharer, NetScrobId id)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(sharer);
		writer.WriteNetworkScrob(id);
		SendTargetRPCInternal(target, "System.Void TipTapManager::RpcTipTapShared(Mirror.NetworkConnectionToClient,Aggro.Core.Entity,Aggro.Core.Networking.NetScrobId)", 1985941963, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void LocalTipTapShared(Entity sharer, NetScrobId id)
	{
		TipTapObject tipTapObject = id.Get<TipTapObject>();
		if (collectedTipTaps.Contains(tipTapObject))
		{
			collectedTipTaps.Remove(tipTapObject);
		}
		if (sharedTipTaps.Contains(tipTapObject))
		{
			sharedTipTaps.Remove(tipTapObject);
		}
		sharedTipTaps.Insert(0, tipTapObject);
		AggroManagerBase<TipTapNotificationManager>.instance.SpawnNotification(sharer, tipTapObject);
	}

	public void TestTipTapShared()
	{
		TipTapObject tipTapObject = _available[UnityEngine.Random.Range(0, _available.Count)];
		LocalTipTapShared(GameUtil.GetLocalPlayer(), tipTapObject.networkId);
	}

	public void Like(TipTapObject tipTap)
	{
		if (SaveManager.isInitialized && !SaveManager.data.IsTipTapLiked(tipTap))
		{
			SaveManager.data.TipTapLiked(tipTap);
		}
	}

	public void Seen(TipTapObject tipTap)
	{
		if (SaveManager.isInitialized)
		{
			SaveManager.data.TipTapSeen(tipTap);
		}
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (phase == ShiftPhase.BreakRoom && !GameUtil.isGym && !GameUtil.isTutorial)
		{
			GenerateCollectedTipTaps();
		}
	}

	public void ShiftCompleted(bool contractCompleted, bool wonContract)
	{
		AggroManagerBase<TipTapPhoneVisual>.instance.CloseTipTap();
		Platform.AddStat("stat_tiptap_minutes", (float)(_tipTapSecondsThisShift / 60.0));
		_tipTapSecondsThisShift = 0.0;
		if (contractCompleted && wonContract && _tipTapSeconds >= 180.0)
		{
			Platform.UnlockAchievement("ach_tiptap_pro");
		}
	}

	public void AddToTipTapSeconds(float dt)
	{
		if (!GameUtil.isTutorial && GameUtil.isRun && NetworkAggroManagerBase<ShiftManager>.ManagerExists() && NetworkAggroManagerBase<ShiftManager>.instance.GetShiftPhase() == ShiftPhase.Shift)
		{
			_tipTapSecondsThisShift += dt;
			_tipTapSeconds += dt;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdShareTipTap__NetScrobId__NetworkConnectionToClient(NetScrobId id, NetworkConnectionToClient conn)
	{
		if (conn == null || !(conn.identity != null) || !conn.identity.TryGetEntity(out var sharer))
		{
			return;
		}
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			if (connection.Value != conn)
			{
				RpcTipTapShared(connection.Value, sharer, id);
			}
		}
	}

	protected static void InvokeUserCode_CmdShareTipTap__NetScrobId__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdShareTipTap called on client.");
		}
		else
		{
			((TipTapManager)obj).UserCode_CmdShareTipTap__NetScrobId__NetworkConnectionToClient(reader.ReadNetworkScrob(), senderConnection);
		}
	}

	protected void UserCode_RpcTipTapShared__NetworkConnectionToClient__Entity__NetScrobId(NetworkConnectionToClient target, Entity sharer, NetScrobId id)
	{
		LocalTipTapShared(sharer, id);
	}

	protected static void InvokeUserCode_RpcTipTapShared__NetworkConnectionToClient__Entity__NetScrobId(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcTipTapShared called on server.");
		}
		else
		{
			((TipTapManager)obj).UserCode_RpcTipTapShared__NetworkConnectionToClient__Entity__NetScrobId(null, reader.ReadEntity(), reader.ReadNetworkScrob());
		}
	}

	static TipTapManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TipTapManager), "System.Void TipTapManager::CmdShareTipTap(Aggro.Core.Networking.NetScrobId,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdShareTipTap__NetScrobId__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TipTapManager), "System.Void TipTapManager::RpcTipTapShared(Mirror.NetworkConnectionToClient,Aggro.Core.Entity,Aggro.Core.Networking.NetScrobId)", InvokeUserCode_RpcTipTapShared__NetworkConnectionToClient__Entity__NetScrobId);
	}
}
