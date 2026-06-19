using System.Runtime.InteropServices;
using System.Text;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ButtonRerollShop : NetworkEntityBehaviourBase, IWarehouseButton, IFloaterPopulator
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct EvShopReroll : IEntityEvent, IEntityTyped
	{
	}

	[Min(0f)]
	public int costForReroll = 100;

	[Min(0f)]
	public int rerollCostIncrement = 50;

	[Min(0f)]
	public float rerollCooldown = 1f;

	[SyncVar]
	private int _syncTimesRerolled;

	private FloaterUI _floaterUI;

	private Timer _serverTimer;

	private static StringBuilder _builder;

	private int _prevCost = -1;

	public int Network_syncTimesRerolled
	{
		get
		{
			return _syncTimesRerolled;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncTimesRerolled, 1uL, null);
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (!(_floaterUI != null))
		{
			return;
		}
		_floaterUI.SetVisibleThisFrame();
		if (_floaterUI.entity.TryGetObject<ShopInfoFloaterUI>(out var obj))
		{
			if (NetworkAggroManagerBase<ShiftManager>.instance.GetMoney() < costForReroll)
			{
				obj.costText.color = AggroManagerBase<ShopPanelUI>.instance.cannotAffordColor;
			}
			else
			{
				obj.costText.color = AggroManagerBase<ShopPanelUI>.instance.canAffordColor;
			}
			int num = costForReroll + _syncTimesRerolled * rerollCostIncrement;
			if (_prevCost != num)
			{
				_prevCost = num;
				_builder.Clear();
				_builder.Append('$');
				_builder.Append(num);
				obj.costText.text = _builder.ToString();
			}
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer)
		{
			_serverTimer.DecrementTimer();
		}
	}

	public WarehouseButtonState ServerGetButtonState()
	{
		if (!_serverTimer.IsFinished())
		{
			return WarehouseButtonState.Pressed;
		}
		if (NetworkAggroManagerBase<ShiftManager>.instance.GetMoney() >= costForReroll + _syncTimesRerolled * rerollCostIncrement)
		{
			return WarehouseButtonState.Unpressed;
		}
		return WarehouseButtonState.Pressed;
	}

	public void ServerButtonPressed(NetworkConnectionToClient conn)
	{
		NetworkAggroManagerBase<ShiftManager>.instance.ServerAddMoney(-(costForReroll + _syncTimesRerolled * rerollCostIncrement));
		Network_syncTimesRerolled = _syncTimesRerolled + 1;
		NetworkAggroManagerBase<Shop>.instance.ServerReroll();
		RPCShopRerolled();
		_serverTimer.SetTimer(rerollCooldown);
	}

	[ClientRpc]
	public void RPCShopRerolled()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ButtonRerollShop::RPCShopRerolled()", -584995223, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ClientButtonPressed()
	{
	}

	public void AddedFloater(FloaterUI floaterAdded)
	{
		_floaterUI = floaterAdded;
	}

	public void RemovedFloater()
	{
	}

	static ButtonRerollShop()
	{
		_builder = new StringBuilder();
		RemoteProcedureCalls.RegisterRpc(typeof(ButtonRerollShop), "System.Void ButtonRerollShop::RPCShopRerolled()", InvokeUserCode_RPCShopRerolled);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RPCShopRerolled()
	{
		base.eventManager.QueueGlobalEvent(default(EvShopReroll));
	}

	protected static void InvokeUserCode_RPCShopRerolled(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCShopRerolled called on server.");
		}
		else
		{
			((ButtonRerollShop)obj).UserCode_RPCShopRerolled();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_syncTimesRerolled);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_syncTimesRerolled);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncTimesRerolled, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncTimesRerolled, null, reader.ReadVarInt());
		}
	}
}
