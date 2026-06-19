using System;
using System.Runtime.InteropServices;
using System.Text;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class ShopHolder : NetworkEntityBehaviourBase, IFloaterPopulator
{
	[Tooltip("Only needs to be set if there's more than one holder in an entity!")]
	[Min(0f)]
	public int id;

	[Range(0f, 1f)]
	public float saleMultiplier = 0.5f;

	[Space]
	public Transform itemContainer;

	public Collider trigger;

	[Header("Throw")]
	public Transform spawnPos;

	public Transform spawnThrowDir;

	[Min(0f)]
	public float spawnThrowForce = 20f;

	[Header("VFX")]
	public GameObject transactionVFX;

	public GameObject purchaseVFX;

	[Header("UI")]
	public FloaterUI _floaterUI;

	[SyncVar]
	private NetScrobId _syncItem;

	[SyncVar]
	private bool _syncOnSale;

	private Action<ShopItemObject> _onPurchased;

	private Entity _shopItemEntity;

	private int _cachedCost = -1;

	private static StringBuilder _builder;

	public GameObject rerollVFX;

	public EventReference purchaseDeniedSfx;

	public bool OnSale => _syncOnSale;

	public NetScrobId Network_syncItem
	{
		get
		{
			return _syncItem;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncItem, 1uL, null);
		}
	}

	public bool Network_syncOnSale
	{
		get
		{
			return _syncOnSale;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncOnSale, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<ButtonRerollShop.EvShopReroll>(OnShopReroll);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<ButtonRerollShop.EvShopReroll>(OnShopReroll);
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && player.TryGetObject<PlayerGrabber>(out var obj) && obj.TryGetShopHolderGrabTarget(out var holder) && holder == this)
		{
			AggroManagerBase<ShopPanelUI>.instance.SetVisibleThisFrame();
			if (TryGetShopItem(out var item))
			{
				ShopPanelUI.Data data = new ShopPanelUI.Data
				{
					holder = this,
					itemDesc = item.itemDescription,
					itemName = item.itemName,
					itemIcon = item.icon,
					itemPrice = GetCost(item.cost)
				};
				AggroManagerBase<ShopPanelUI>.instance.SetData(data);
			}
		}
	}

	private int GetCost(int cost)
	{
		if (_syncOnSale)
		{
			return Mathf.RoundToInt((float)cost * saleMultiplier);
		}
		return cost;
	}

	protected override void OnUpdatePresentation()
	{
		if (_syncItem.isValid)
		{
			trigger.enabled = true;
		}
		else
		{
			trigger.enabled = false;
		}
		if (!(_floaterUI != null))
		{
			return;
		}
		_floaterUI.extrasVisible = _syncItem.isValid;
		if (_floaterUI.entity.TryGetObject<ShopInfoFloaterUI>(out var obj) && TryGetShopItem(out var item))
		{
			obj.saleGameObject.SetActive(_syncOnSale);
			if (_cachedCost != GetCost(item.cost))
			{
				_cachedCost = GetCost(item.cost);
				_builder.Clear();
				_builder.Append('$');
				_builder.Append(GetCost(item.cost));
				obj.costText.text = _builder.ToString();
			}
			if (NetworkAggroManagerBase<ShiftManager>.instance.GetMoney() < GetCost(item.cost))
			{
				obj.costText.color = AggroManagerBase<ShopPanelUI>.instance.cannotAffordColor;
			}
			else
			{
				obj.costText.color = AggroManagerBase<ShopPanelUI>.instance.canAffordColor;
			}
		}
	}

	[Server]
	public void ServerSetItem(ShopItemObject item, Action<ShopItemObject> onPurchased)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShopHolder::ServerSetItem(ShopItemObject,System.Action`1<ShopItemObject>)' called when server was not active");
			return;
		}
		if (_shopItemEntity.Exists())
		{
			EntityUtil.Destroy(_shopItemEntity);
		}
		if ((object)item == null)
		{
			Network_syncItem = NetScrobId.invalid;
			return;
		}
		Network_syncItem = item.networkId;
		_shopItemEntity = EntityUtil.Instantiate(item.shopItemPrefab);
		_shopItemEntity.transform.SetParentAndReset(itemContainer);
		_onPurchased = onPurchased;
		Network_syncOnSale = false;
	}

	[Server]
	public void ServerSetOnSale()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ShopHolder::ServerSetOnSale()' called when server was not active");
		}
		else
		{
			Network_syncOnSale = true;
		}
	}

	public bool TryGetShopItem(out ShopItemObject item)
	{
		if (_syncItem.TryGet<ShopItemObject>(out item))
		{
			return true;
		}
		return false;
	}

	public void RequestPurchase()
	{
		if (LocalPlayerCanPurchase())
		{
			CmdRequestPurchase();
		}
	}

	public bool LocalPlayerCanPurchase()
	{
		if (!_syncItem.isValid)
		{
			return false;
		}
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return false;
		}
		ShopItemObject shopItemObject = _syncItem.Get<ShopItemObject>();
		if (shopItemObject.type == ShopItemType.Upgrade && player.GetObject<PlayerUpgrades>().HasUpgrade(shopItemObject.upgrade))
		{
			return false;
		}
		return true;
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestPurchase(NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShopHolder::CmdRequestPurchase(Mirror.NetworkConnectionToClient)", 1976930340, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcItemPurchased(int price)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(price);
		SendRPCInternal("System.Void ShopHolder::RpcItemPurchased(System.Int32)", 466533861, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcRequestDenied(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void ShopHolder::RpcRequestDenied(Mirror.NetworkConnectionToClient)", -964096463, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void AddedFloater(FloaterUI floaterAdded)
	{
		_floaterUI = floaterAdded;
	}

	public void RemovedFloater()
	{
	}

	public void OnShopReroll(ButtonRerollShop.EvShopReroll evShopReroll)
	{
		NetworkAggroManagerBase<VFXManager>.instance.Play(rerollVFX, base.transform.position + Vector3.up * 0.5f, base.transform.rotation);
	}

	static ShopHolder()
	{
		_builder = new StringBuilder();
		RemoteProcedureCalls.RegisterCommand(typeof(ShopHolder), "System.Void ShopHolder::CmdRequestPurchase(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestPurchase__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ShopHolder), "System.Void ShopHolder::RpcItemPurchased(System.Int32)", InvokeUserCode_RpcItemPurchased__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(ShopHolder), "System.Void ShopHolder::RpcRequestDenied(Mirror.NetworkConnectionToClient)", InvokeUserCode_RpcRequestDenied__NetworkConnectionToClient);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestPurchase__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		if (!_syncItem.isValid || !_shopItemEntity.Exists())
		{
			return;
		}
		ShopItemObject shopItemObject = _syncItem.Get<ShopItemObject>();
		int cost = GetCost(shopItemObject.cost);
		if (cost <= NetworkAggroManagerBase<ShiftManager>.instance.GetMoney())
		{
			NetworkAggroManagerBase<ShiftManager>.instance.ServerAddMoney(-cost);
			RpcItemPurchased(cost);
			EntityUtil.Destroy(_shopItemEntity);
			switch (shopItemObject.type)
			{
			case ShopItemType.Station:
				EntityUtil.Instantiate(shopItemObject.worldItemPrefab, spawnPos.position, spawnPos.rotation).rigidbody.AddForceAtPosition(spawnThrowDir.forward * spawnThrowForce, spawnThrowDir.position, ForceMode.Impulse);
				break;
			case ShopItemType.Upgrade:
			{
				if (conn.identity.TryGetEntity(out var entity))
				{
					entity.GetObject<PlayerUpgrades>().ServerSetUpgrade(shopItemObject.upgrade);
				}
				break;
			}
			default:
				throw new InvalidEnumException();
			}
			_onPurchased(shopItemObject);
			Network_syncItem = NetScrobId.invalid;
			_shopItemEntity = Entity.invalid;
		}
		else
		{
			RpcRequestDenied(conn);
		}
	}

	protected static void InvokeUserCode_CmdRequestPurchase__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestPurchase called on client.");
		}
		else
		{
			((ShopHolder)obj).UserCode_CmdRequestPurchase__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcItemPurchased__Int32(int price)
	{
		transactionVFX.GetEntityFromPrefabPool().gameObject.GetComponent<TransactionUI>().amount = -price;
		UnityEngine.Object.Instantiate(purchaseVFX, spawnThrowDir.position, spawnThrowDir.rotation);
	}

	protected static void InvokeUserCode_RpcItemPurchased__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcItemPurchased called on server.");
		}
		else
		{
			((ShopHolder)obj).UserCode_RpcItemPurchased__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcRequestDenied__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		AudioManager.PlaySfx(purchaseDeniedSfx, base.transform.position);
	}

	protected static void InvokeUserCode_RpcRequestDenied__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcRequestDenied called on server.");
		}
		else
		{
			((ShopHolder)obj).UserCode_RpcRequestDenied__NetworkConnectionToClient(null);
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteNetworkScrob(_syncItem);
			writer.WriteBool(_syncOnSale);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteNetworkScrob(_syncItem);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(_syncOnSale);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncItem, null, reader.ReadNetworkScrob());
			GeneratedSyncVarDeserialize(ref _syncOnSale, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncItem, null, reader.ReadNetworkScrob());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncOnSale, null, reader.ReadBool());
		}
	}
}
