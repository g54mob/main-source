using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class GrabbableHolder : NetworkEntityBehaviourBase
{
	[Tooltip("Only needs to be set if there's more than one holder in an entity!")]
	[Min(0f)]
	public int id;

	public bool canBePlacedInByPlayer = true;

	public TagQuery tagQuery;

	[Range(1f, 4f)]
	public int maximumStackHeight = 4;

	[Space]
	public GameObject holdingVisual;

	public Transform container;

	[SyncVar]
	public bool isHoldingAnItem;

	[SyncVar]
	public int holderLevel;

	[SyncVar]
	public bool isInteractable;

	[SyncVar]
	private Entity _syncOnlyCanHold;

	private Entity _serverHeldEntity;

	private static List<Grabbable> _grabbables = new List<Grabbable>();

	public PlacementHintVisuals placementHintVisuals;

	public Entity serverHeldEntity => _serverHeldEntity;

	public bool NetworkisHoldingAnItem
	{
		get
		{
			return isHoldingAnItem;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isHoldingAnItem, 1uL, null);
		}
	}

	public int NetworkholderLevel
	{
		get
		{
			return holderLevel;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref holderLevel, 2uL, null);
		}
	}

	public bool NetworkisInteractable
	{
		get
		{
			return isInteractable;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isInteractable, 4uL, null);
		}
	}

	public Entity Network_syncOnlyCanHold
	{
		get
		{
			return _syncOnlyCanHold;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncOnlyCanHold, 8uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		if (base.authority)
		{
			NetworkisInteractable = true;
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.authority)
		{
			NetworkisHoldingAnItem = _serverHeldEntity.Exists();
			if (container.position.y < 1f)
			{
				NetworkholderLevel = 1;
			}
			else
			{
				NetworkholderLevel = 2;
			}
		}
	}

	protected override void OnUpdatePresentation()
	{
		holdingVisual.SetActive(isHoldingAnItem);
	}

	public bool CanSetItem(Grabbable item, bool fromPlayer)
	{
		if (fromPlayer && !canBePlacedInByPlayer)
		{
			return false;
		}
		if (item.GetStackCount() > maximumStackHeight)
		{
			return false;
		}
		if (_syncOnlyCanHold != Entity.invalid && item.entity != _syncOnlyCanHold)
		{
			return false;
		}
		if (!tagQuery.Evaluate(item.entity))
		{
			return false;
		}
		return true;
	}

	[Server]
	public bool ServerTrySetItem(Grabbable item, bool fromPlayer)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean GrabbableHolder::ServerTrySetItem(Grabbable,System.Boolean)' called when server was not active");
			return default(bool);
		}
		if (_serverHeldEntity.Exists())
		{
			return false;
		}
		if (CanSetItem(item, fromPlayer))
		{
			_serverHeldEntity = item.entity;
			NetworkisHoldingAnItem = true;
			return true;
		}
		return false;
	}

	[Server]
	public void ServerRemoveItem()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GrabbableHolder::ServerRemoveItem()' called when server was not active");
		}
		else
		{
			_serverHeldEntity = Entity.invalid;
		}
	}

	[Server]
	public void ServerOnlyHold(Entity item)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void GrabbableHolder::ServerOnlyHold(Aggro.Core.Entity)' called when server was not active");
		}
		else
		{
			Network_syncOnlyCanHold = item;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isHoldingAnItem);
			writer.WriteVarInt(holderLevel);
			writer.WriteBool(isInteractable);
			writer.WriteEntity(_syncOnlyCanHold);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isHoldingAnItem);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(holderLevel);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(isInteractable);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteEntity(_syncOnlyCanHold);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isHoldingAnItem, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref holderLevel, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref isInteractable, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref _syncOnlyCanHold, null, reader.ReadEntity());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isHoldingAnItem, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref holderLevel, null, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isInteractable, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncOnlyCanHold, null, reader.ReadEntity());
		}
	}
}
