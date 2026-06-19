using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class StationBox : NetworkEntityBehaviourBase, IShiftChanged, IStation
{
	public GameObject boxPrefab;

	public bool destroyAndRecreate;

	public bool spawnImmediatelyWhenDestroyed;

	public GameObject boxDestructionVFX;

	private Entity _serverBox;

	[Server]
	public void ServerPlaced()
	{
		StationData comp;
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StationBox::ServerPlaced()' called when server was not active");
		}
		else if (!base.entity.TryGetStruct<StationData>(out comp) || !comp.hasSpawnedBox)
		{
			ServerSpawnBox();
		}
	}

	[Server]
	public void ServerIsBeingPickedUp()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StationBox::ServerIsBeingPickedUp()' called when server was not active");
		}
		else if (_serverBox.Exists())
		{
			if (boxDestructionVFX != null)
			{
				NetworkAggroManagerBase<VFXManager>.instance.Play(boxDestructionVFX, _serverBox.transform.position);
			}
			EntityUtil.Destroy(_serverBox);
			base.entity.TryGetStruct<StationData>(out var comp);
			comp.hasSpawnedBox = false;
			base.entity.SetStruct(comp);
		}
	}

	protected override void OnEntityDestroyed()
	{
		if (!GameUtil.isUnloadingScene && base.isServer && _serverBox.Exists())
		{
			EntityUtil.Destroy(_serverBox);
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isServer && spawnImmediatelyWhenDestroyed && !_serverBox.Exists())
		{
			ServerSpawnBox();
		}
	}

	public void OnShiftChanged(ShiftPhase phase, int shift, int outboundsRequired)
	{
		if (!base.isServer || phase != ShiftPhase.Organizational)
		{
			return;
		}
		if (destroyAndRecreate)
		{
			if (_serverBox.Exists())
			{
				EntityUtil.Destroy(_serverBox);
			}
			ServerSpawnBox();
		}
		else if (_serverBox.Exists())
		{
			GrabbableHolder grabbableHolder = base.entity.GetObject<GrabbableHolder>();
			if (!grabbableHolder.isHoldingAnItem)
			{
				Grabbable grabbable = _serverBox.GetObject<Grabbable>();
				grabbable.ServerBreakStackAtMe();
				grabbableHolder.ServerTrySetItem(grabbable, fromPlayer: false);
				grabbable.ServerPlaceInHolder(grabbableHolder);
			}
			base.entity.TryGetStruct<StationData>(out var comp);
			comp.hasSpawnedBox = true;
			base.entity.SetStruct(comp);
		}
		else
		{
			ServerSpawnBox();
		}
	}

	[Server]
	private void ServerSpawnBox()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void StationBox::ServerSpawnBox()' called when server was not active");
			return;
		}
		_serverBox = EntityUtil.Instantiate(boxPrefab);
		if (base.entity.TryGetStruct<EntityContextComp>(out var comp))
		{
			_serverBox.SetOrAddStruct(comp);
		}
		GrabbableHolder grabbableHolder = base.entity.GetObject<GrabbableHolder>();
		grabbableHolder.ServerOnlyHold(_serverBox);
		Grabbable grabbable = _serverBox.GetObject<Grabbable>();
		grabbableHolder.ServerTrySetItem(grabbable, fromPlayer: false);
		grabbable.ServerPlaceInHolder(grabbableHolder);
		base.entity.TryGetStruct<StationData>(out var comp2);
		comp2.hasSpawnedBox = true;
		base.entity.SetStruct(comp2);
	}

	public override bool Weaved()
	{
		return true;
	}
}
