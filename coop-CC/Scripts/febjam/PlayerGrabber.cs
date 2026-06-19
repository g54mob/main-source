using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMOD.Studio;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerGrabber : NetworkEntityBehaviourBase
{
	private struct PlayerGrabberData
	{
		public bool grabReleaseRequested;

		public bool raisedHeld;

		public PlayerGrabState grabState;

		public PlayerLiftState liftState;

		public Entity grabTarget;

		public int grabId;

		public int gradLevel;

		public Entity hintTarget;

		public int hintId;

		public int hintLevel;

		public Timer timer;
	}

	[Header("Grab")]
	[Min(0f)]
	public float grabCandidateCheckRadius = 0.5f;

	[Min(0f)]
	public float grabShopCheckRadius = 5f;

	[Range(0f, 180f)]
	public float grabCandidateCheckAngle = 90f;

	[Min(0f)]
	public float grabCandidatePriorityProjectedDistance = 1f;

	public Transform grabbedContainer;

	public Transform checkThrowFrom;

	[Space]
	[Range(0f, 90f)]
	public float grabReleaseVelocityUpwardsModifierLowered = 45f;

	[Range(0f, 90f)]
	public float grabReleaseVelocityUpwardsModifierRaised = 15f;

	[Min(1f)]
	public float grabReleaseVelocityForwardMultiplier = 1.5f;

	[Min(0f)]
	public float grabReleaseVelocityBackwardsMultiplier = 0.5f;

	[Header("Lift")]
	private PlayerGrabberData _data;

	private static Collider[] _collidersArray;

	private static List<Collider> _colliders;

	public Entity serverGrabbed;

	[NonSerialized]
	[SyncVar]
	public bool syncLiftRaised;

	[NonSerialized]
	[SyncVar]
	public Entity syncGrabTarget;

	public PlayerAnimation playerAnimation;

	public bool hasCandidate;

	[Header("Audio")]
	public EventReference upBoopRef;

	[Header("Audio")]
	public EventReference downBoopRef;

	[Header("Audio")]
	public EventReference emptyBoopRef;

	[Header("Audio")]
	public EventReference slideNoiseRef;

	[Header("Achievement")]
	public GameObject[] zookeeperStack;

	public GameObject[] chickenJockeyStack;

	private EventInstance upInstance;

	private EventInstance downInstance;

	private EventInstance emptyInstance;

	private EventInstance slideNoiseInstance;

	private static List<Grabbable> _grabbables;

	private static List<GrabbableHolder> _holders;

	private static List<ShopHolder> _shopHolders;

	private static List<Entity> _entities;

	private static HashSet<Entity> _entitySet;

	private static HashSet<uint> _ids;

	private bool _sentZookeeperAchievement;

	private HashSet<NetworkConnectionToClient> _serverChickenJockeySent = new HashSet<NetworkConnectionToClient>();

	private List<Vector3> _debugGrabCandidates = new List<Vector3>();

	private const float MAX_RTT = 0.3f;

	private const float HINT_CHECK_HEIGHT = 10f;

	private const float OVERLAP_CHECK_DIST_SQR = 0.010000001f;

	public PlayerGrabState grabState => _data.grabState;

	public Entity localPlayerGrabTarget => _data.grabTarget;

	public Entity localPlayerHintTarget => _data.hintTarget;

	public int localPlayerHintId => _data.hintId;

	public bool NetworksyncLiftRaised
	{
		get
		{
			return syncLiftRaised;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncLiftRaised, 1uL, null);
		}
	}

	public Entity NetworksyncGrabTarget
	{
		get
		{
			return syncGrabTarget;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncGrabTarget, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_data = default(PlayerGrabberData);
		upInstance = RuntimeManager.CreateInstance(upBoopRef);
		downInstance = RuntimeManager.CreateInstance(downBoopRef);
		emptyInstance = RuntimeManager.CreateInstance(emptyBoopRef);
		slideNoiseInstance = RuntimeManager.CreateInstance(slideNoiseRef);
		slideNoiseInstance.set3DAttributes(base.transform.To3DAttributes());
	}

	protected override void OnEntityDestroyed()
	{
		upInstance.release();
		downInstance.release();
		emptyInstance.release();
		slideNoiseInstance.release();
	}

	protected override void OnUpdatePresentation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		if (AggroInputManager.input.Game.GrabRelease.WasPressedThisFrame() && !AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
		{
			_data.grabReleaseRequested = true;
		}
		_data.raisedHeld = AggroInputManager.input.Game.RaiseLower.IsPressed() && !AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen;
		if (!_data.hintTarget.Exists())
		{
			return;
		}
		if (_data.hintTarget.TryGetObject<Grabbable>(out var obj))
		{
			PlacementHintVisuals obj3;
			if (obj.canPutBoxOn && obj.CanAddToStack(_data.grabTarget.GetObject<Grabbable>()))
			{
				if (_data.hintTarget.TryGetObject<PlacementHintVisuals>(out var obj2))
				{
					obj2.hintObject.SetActive(value: true);
				}
			}
			else if (_data.hintTarget.TryGetObject<PlacementHintVisuals>(out obj3))
			{
				obj3.hintCannotPlaceObject.SetActive(value: true);
			}
			return;
		}
		_holders.Clear();
		_data.hintTarget.GetObjects(_holders);
		for (int i = 0; i < _holders.Count; i++)
		{
			GrabbableHolder grabbableHolder = _holders[i];
			if (grabbableHolder.id == _data.hintId)
			{
				if (grabbableHolder.CanSetItem(_data.grabTarget.GetObject<Grabbable>(), fromPlayer: true))
				{
					grabbableHolder.placementHintVisuals.hintObject.SetActive(value: true);
				}
				else
				{
					grabbableHolder.placementHintVisuals.hintCannotPlaceObject.SetActive(value: true);
				}
			}
		}
	}

	protected override void OnUpdateSimulation()
	{
		if (base.isLocalPlayer)
		{
			UpdateInput();
			UpdateGrab();
			UpdateLift();
			if (_data.grabState == PlayerGrabState.Grabbed)
			{
				NetworksyncGrabTarget = _data.grabTarget;
			}
			else
			{
				NetworksyncGrabTarget = Entity.invalid;
			}
		}
	}

	protected override void OnUpdatePresentationLate()
	{
		if (base.isLocalPlayer && _data.grabState == PlayerGrabState.Grabbed && !_data.grabTarget.Exists())
		{
			LocalPlayerDropBoxes(breakStack: true, checkUpgrade: false);
		}
	}

	public void RequestPlayerDropBoxes(bool breakStack, bool checkUpgrade)
	{
		if (base.isLocalPlayer)
		{
			LocalPlayerDropBoxes(breakStack, checkUpgrade);
		}
		else
		{
			RpcPlayerDropBoxes(breakStack, checkUpgrade);
		}
	}

	private void LocalPlayerDropBoxes(bool breakStack, bool checkUpgrade)
	{
		if (checkUpgrade && base.entity.GetObject<PlayerUpgrades>().HasUpgrade(PlayerUpgrade.StrongGrabbers))
		{
			if (_data.grabState == PlayerGrabState.Grabbed || _data.grabState == PlayerGrabState.Requested || _data.grabState == PlayerGrabState.RequestGranted)
			{
				if (_data.grabTarget.Exists())
				{
					CmdReleaseGrabLocationOthers(_data.grabTarget, grabbedContainer.position, checkThrowFrom.position, grabbedContainer.rotation, GetReleaseVelocity(), breakStack);
				}
			}
			else
			{
				_data.grabTarget = Entity.invalid;
			}
		}
		else if (_data.grabState == PlayerGrabState.Grabbed || _data.grabState == PlayerGrabState.Requested || _data.grabState == PlayerGrabState.RequestGranted)
		{
			if (_data.grabTarget.Exists())
			{
				LocalPlayerSetKickDebounce(_data.grabTarget);
				CmdReleaseGrabLocation(_data.grabTarget, grabbedContainer.position, checkThrowFrom.position, grabbedContainer.rotation, GetReleaseVelocity(), breakStack);
			}
			downInstance.start();
			_data.grabState = PlayerGrabState.ReleasingGrab;
			_data.grabTarget = Entity.invalid;
			_data.hintTarget = Entity.invalid;
			_data.hintId = -1;
		}
		else
		{
			_data.grabTarget = Entity.invalid;
		}
	}

	[TargetRpc]
	private void RpcPlayerDropBoxes(bool breakStack, bool checkUpgrade)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(breakStack);
		writer.WriteBool(checkUpgrade);
		SendTargetRPCInternal(null, "System.Void PlayerGrabber::RpcPlayerDropBoxes(System.Boolean,System.Boolean)", -1980459979, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerDropBoxesSimple()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerGrabber::ServerDropBoxesSimple()' called when server was not active");
			return;
		}
		serverGrabbed = Entity.invalid;
		RpcDropBoxesSimple();
	}

	[TargetRpc]
	private void RpcDropBoxesSimple()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(null, "System.Void PlayerGrabber::RpcDropBoxesSimple()", 1764632506, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void UpdateGrab()
	{
		hasCandidate = false;
		switch (_data.grabState)
		{
		case PlayerGrabState.NotGrabbing:
		{
			UpgradeGrabTarget();
			if (_data.grabTarget.TryGetObject<Grabbable>(out var obj4))
			{
				_grabbables.Clear();
				obj4.GetStack(_grabbables);
				for (int k = math.max(obj4.syncStackIndex, 0); k < _grabbables.Count; k++)
				{
					_grabbables[k].MarkIsCandidate();
				}
				hasCandidate = true;
			}
			if (_data.grabTarget.TryGetObject<Cactus>(out var obj5))
			{
				obj5.MarkIsCandidate();
			}
			break;
		}
		case PlayerGrabState.Requested:
		{
			_data.timer.DecrementTimer();
			if (!_data.grabTarget.Exists())
			{
				Debug.Log("Grab Target Not Valid!");
				_data.grabState = PlayerGrabState.NotGrabbing;
				_data.grabTarget = Entity.invalid;
			}
			if (_data.grabTarget.TryGetObject<Grabbable>(out var obj))
			{
				obj.MarkIsCandidate();
				hasCandidate = true;
			}
			break;
		}
		case PlayerGrabState.RequestGranted:
		{
			if (!_data.grabTarget.Exists())
			{
				_data.grabState = PlayerGrabState.NotGrabbing;
				_data.grabTarget = Entity.invalid;
			}
			else
			{
				_data.grabState = PlayerGrabState.Grabbed;
				UpdateHintTarget();
				if (!_sentZookeeperAchievement && _data.grabTarget.TryGetObject<Grabbable>(out var obj2) && zookeeperStack.Length != 0)
				{
					_entities.Clear();
					obj2.GetStack(_entities);
					if (_entities.Count >= zookeeperStack.Length)
					{
						_ids.Clear();
						for (int i = 0; i < zookeeperStack.Length; i++)
						{
							_ids.Add(zookeeperStack[i].GetComponent<NetworkIdentity>().assetId);
						}
						for (int j = 0; j < _entities.Count; j++)
						{
							_ids.Remove(_entities[j].netIdentity.assetId);
						}
						if (_ids.Count == 0)
						{
							_sentZookeeperAchievement = true;
							Aggro.Core.Platform.UnlockAchievement("ach_zookeeper");
						}
					}
				}
			}
			if (_data.grabTarget.TryGetObject<Grabbable>(out var obj3))
			{
				obj3.MarkIsCandidate();
				hasCandidate = true;
			}
			break;
		}
		case PlayerGrabState.Grabbed:
			UpdateHintTarget();
			break;
		case PlayerGrabState.ReleasingGrab:
			_data.timer.DecrementTimer();
			if (_data.timer.IsFinished())
			{
				_data.grabState = PlayerGrabState.NotGrabbing;
			}
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	private void UpdateLift()
	{
		if (!IsGrabBusy() && _data.liftState == PlayerLiftState.LoweredContext)
		{
			if (_data.grabState == PlayerGrabState.Grabbed)
			{
				if (_data.hintTarget.Exists() && _data.hintLevel == 1)
				{
					_data.liftState = PlayerLiftState.RaisedContext;
				}
			}
			else if (_data.grabTarget.Exists() && _data.gradLevel > 1)
			{
				_data.liftState = PlayerLiftState.RaisedContext;
			}
		}
		switch (_data.liftState)
		{
		case PlayerLiftState.LoweredContext:
		case PlayerLiftState.LoweredNotUsable:
			NetworksyncLiftRaised = false;
			break;
		case PlayerLiftState.RaisedContext:
		case PlayerLiftState.RaisedExplicit:
			NetworksyncLiftRaised = true;
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	private void UpdateInput()
	{
		if (_data.grabReleaseRequested && !IsGrabBusy())
		{
			_data.grabReleaseRequested = false;
			if (!base.entity.TryGetObject<PlayerStress>(out var obj) || !obj.crashingOut)
			{
				if (_data.grabState == PlayerGrabState.Grabbed)
				{
					LocalPlayerSetKickDebounce(_data.grabTarget);
					if (_data.hintTarget.Exists())
					{
						CmdReleaseGrabTarget(_data.grabTarget, _data.hintTarget, _data.hintId, grabbedContainer.position, grabbedContainer.rotation, GetReleaseVelocity());
					}
					else
					{
						CmdReleaseGrabLocation(_data.grabTarget, grabbedContainer.position, checkThrowFrom.position, grabbedContainer.rotation, GetReleaseVelocity(), breakStacks: false);
					}
					downInstance.start();
					_data.grabState = PlayerGrabState.ReleasingGrab;
					_data.grabTarget = Entity.invalid;
					_data.hintTarget = Entity.invalid;
					_data.hintId = -1;
				}
				else if (_data.grabTarget.Exists())
				{
					Cactus obj2;
					if (_data.grabTarget.HasObject<Grabbable>())
					{
						_data.grabState = PlayerGrabState.Requested;
						_data.hintTarget = Entity.invalid;
						CmdRequestGrab(_data.grabTarget);
						upInstance.start();
					}
					else if (_data.grabTarget.HasObject<ShopHolder>())
					{
						_shopHolders.Clear();
						_data.grabTarget.GetObjects(_shopHolders);
						for (int i = 0; i < _shopHolders.Count; i++)
						{
							ShopHolder shopHolder = _shopHolders[i];
							if (shopHolder.id == _data.grabId)
							{
								shopHolder.RequestPurchase();
								break;
							}
						}
					}
					else if (_data.grabTarget.TryGetObject<Cactus>(out obj2))
					{
						obj2.RequestDestroy();
						playerAnimation.PlayUpRoot();
					}
				}
				else
				{
					emptyInstance.start();
					playerAnimation.PlayGrabDenied();
				}
			}
		}
		if (IsGrabBusy())
		{
			return;
		}
		if (!base.entity.TryGetObject<PlayerStress>(out var obj3) || !obj3.crashingOut)
		{
			if (_data.raisedHeld)
			{
				_data.liftState = PlayerLiftState.RaisedExplicit;
			}
			else
			{
				_data.liftState = PlayerLiftState.LoweredContext;
			}
		}
		else
		{
			_data.liftState = PlayerLiftState.LoweredNotUsable;
		}
	}

	private bool IsGrabBusy()
	{
		if (_data.grabState != PlayerGrabState.NotGrabbing)
		{
			return _data.grabState != PlayerGrabState.Grabbed;
		}
		return false;
	}

	private void PopulateCandidates(List<Collider> list, int layer)
	{
		Transform obj = base.entity.transform;
		Vector3 position = obj.position;
		Vector3 vector = obj.forward;
		if (vector.y != 0f)
		{
			vector.y = 0f;
			vector = vector.normalized;
		}
		int num = Physics.OverlapCapsuleNonAlloc(position + Vector3.up * 10f / 2f, position + Vector3.down * 10f / 2f, grabCandidateCheckRadius, _collidersArray, layer);
		float num2 = math.cos(math.radians(grabCandidateCheckAngle / 2f));
		for (int i = 0; i < num; i++)
		{
			Collider collider = _collidersArray[i];
			Vector3 position2 = collider.transform.position;
			position2.y = 0f;
			Vector3 vector2 = position2 - position;
			if ((math.dot(vector2, vector) >= 0f && math.dot(vector2.normalized, vector) >= num2 && math.lengthsq(vector2) <= grabCandidateCheckRadius * grabCandidateCheckRadius) || math.lengthsq(vector2) <= 0.010000001f)
			{
				list.Add(collider);
			}
		}
	}

	private void UpgradeGrabTarget()
	{
		if (_data.liftState != PlayerLiftState.LoweredNotUsable)
		{
			TryFindGrabTarget(_data.liftState == PlayerLiftState.RaisedExplicit, out _data.grabTarget, out _data.grabId, out _data.gradLevel);
		}
	}

	private bool TryFindGrabTarget(bool raisedOnly, out Entity target, out int id, out int grabLevel)
	{
		_colliders.Clear();
		PopulateCandidates(_colliders, 536887304);
		if (TryFindGrabTarget(raisedOnly, grabCandidatePriorityProjectedDistance, out target, out id, out grabLevel))
		{
			return true;
		}
		if (TryFindGrabTarget(raisedOnly, float.PositiveInfinity, out target, out id, out grabLevel))
		{
			return true;
		}
		if (!raisedOnly)
		{
			Vector3 position = base.entity.transform.position;
			int num = Physics.OverlapSphereNonAlloc(position, grabShopCheckRadius, _collidersArray, 16384);
			Entity entity = Entity.invalid;
			float num2 = float.MaxValue;
			int num3 = -1;
			for (int i = 0; i < num; i++)
			{
				Collider collider = _collidersArray[i];
				if (collider.TryGetEntity(out var entity2) && collider.TryGetComponent<ShopHolderTrigger>(out var component))
				{
					Vector3 position2 = component.transform.position;
					position2.y = 0f;
					float num4 = math.distancesq(position, position2);
					if (num4 <= num2)
					{
						entity = entity2;
						num2 = num4;
						num3 = component.holder.id;
					}
				}
			}
			if (entity != Entity.invalid)
			{
				target = entity;
				grabLevel = 1;
				id = num3;
				return true;
			}
		}
		return false;
	}

	private bool TryFindGrabTarget(bool raisedOnly, float dist, out Entity target, out int id, out int grabLevel)
	{
		Vector3 position = base.entity.transform.position;
		target = Entity.invalid;
		id = 0;
		grabLevel = 1;
		if (raisedOnly)
		{
			position.y = 1.5f;
		}
		else
		{
			position.y = 0.5f;
		}
		float num = float.MaxValue;
		Vector3 right = base.entity.transform.right;
		for (int i = 0; i < _colliders.Count; i++)
		{
			Collider collider = _colliders[i];
			if (!collider.TryGetEntity(out var entity))
			{
				continue;
			}
			ShopHolderTrigger component;
			if (entity.TryGetObject<Grabbable>(out var obj))
			{
				if (!obj.isInteractable || obj.stackLevel > 2 || (raisedOnly && obj.stackLevel < 2) || (!raisedOnly && !obj.isBase && obj.isInStack))
				{
					continue;
				}
				Vector3 position2 = entity.transform.position;
				float num2 = math.distancesq(position, position2);
				if (num2 <= num)
				{
					Vector3 vector = position2;
					vector.y = 0f;
					if (!(Vector3.Project(vector - position, right).sqrMagnitude >= dist * dist))
					{
						target = entity;
						num = num2;
						grabLevel = obj.stackLevel;
					}
				}
			}
			else if (!raisedOnly && collider.TryGetComponent<ShopHolderTrigger>(out component))
			{
				Vector3 position3 = component.transform.position;
				position3.y = 0f;
				float num3 = math.distancesq(position, position3);
				if (num3 <= num && !(Vector3.Project(position3 - position, right).sqrMagnitude >= dist * dist))
				{
					target = component.entity;
					id = component.holder.id;
					num = num3;
					grabLevel = 1;
				}
			}
			else if (!raisedOnly && entity.HasObject<Cactus>())
			{
				Vector3 position4 = entity.transform.position;
				position4.y = 0f;
				float num4 = math.distancesq(position, position4);
				if (num4 <= num && !(Vector3.Project(position4 - position, right).sqrMagnitude >= dist * dist))
				{
					target = entity;
					num = num4;
					grabLevel = 1;
				}
			}
		}
		return target != Entity.invalid;
	}

	private void UpdateHintTarget()
	{
		if (_data.liftState == PlayerLiftState.LoweredNotUsable)
		{
			_data.hintTarget = Entity.invalid;
			_data.hintId = -1;
		}
		else if (AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen || (AggroInputManager.input.Game.UseBox.IsPressed() && _data.grabTarget != Entity.invalid && _data.grabTarget.HasObject<IBoxUsable>()))
		{
			_data.hintTarget = Entity.invalid;
			_data.hintId = -1;
		}
		else
		{
			TryGetHintTarget(_data.liftState == PlayerLiftState.RaisedExplicit, out _data.hintTarget, out _data.hintId, out _data.hintLevel);
		}
	}

	private bool TryGetHintTarget(bool raisedOnly, out Entity target, out int id, out int hintLevel)
	{
		_colliders.Clear();
		PopulateCandidates(_colliders, 512);
		if (TryGetHintTarget(raisedOnly, grabCandidatePriorityProjectedDistance, out target, out id, out hintLevel))
		{
			return true;
		}
		return TryGetHintTarget(raisedOnly, float.PositiveInfinity, out target, out id, out hintLevel);
	}

	private bool TryGetHintTarget(bool raisedOnly, float dist, out Entity target, out int id, out int hintLevel)
	{
		Vector3 position = base.entity.transform.position;
		Vector3 right = base.entity.transform.right;
		target = Entity.invalid;
		id = -1;
		hintLevel = 1;
		if (raisedOnly)
		{
			position.y = 1.5f;
		}
		else
		{
			position.y = 0.5f;
		}
		float num = float.MaxValue;
		for (int i = 0; i < _colliders.Count; i++)
		{
			Collider collider = _colliders[i];
			if (!collider.TryGetEntity(out var entity))
			{
				continue;
			}
			if (entity.TryGetObject<Grabbable>(out var obj))
			{
				if (!obj.isInteractable || obj.stackLevel > 2 || !obj.canPutBoxOn || (raisedOnly && obj.stackLevel != 1) || (!raisedOnly && !obj.isBase && obj.isInStack) || !(entity != _data.grabTarget))
				{
					continue;
				}
				Vector3 position2 = entity.transform.position;
				float num2 = math.distancesq(position, position2);
				if (num2 <= num)
				{
					Vector3 vector = position2;
					vector.y = 0f;
					if (!(Vector3.Project(vector - position, right).sqrMagnitude >= dist * dist))
					{
						target = entity;
						num = num2;
						hintLevel = obj.stackLevel;
					}
				}
			}
			else
			{
				if (!collider.TryGetComponent<GrabbableHolderTrigger>(out var component) || (object)component.holder == null)
				{
					continue;
				}
				GrabbableHolder holder = component.holder;
				if (!holder.isHoldingAnItem && holder.isInteractable && (!raisedOnly || holder.holderLevel == 2))
				{
					Vector3 position3 = holder.container.position;
					position3.y = 0f;
					float num3 = math.distancesq(position, position3);
					if (num3 <= num && !(Vector3.Project(position3 - position, right).sqrMagnitude >= dist * dist))
					{
						target = collider.GetComponent<EntityCollider>().entity;
						id = holder.id;
						num = num3;
						hintLevel = holder.holderLevel - 1;
					}
				}
			}
		}
		return target != Entity.invalid;
	}

	[Command]
	private void CmdRequestGrab(Entity e)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e);
		SendCommandInternal("System.Void PlayerGrabber::CmdRequestGrab(Aggro.Core.Entity)", 729125502, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdReleaseGrabLocation(Entity e, Vector3 position, Vector3 fromPosition, Quaternion rotation, Vector3 velocity, bool breakStacks)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e);
		writer.WriteVector3(position);
		writer.WriteVector3(fromPosition);
		writer.WriteQuaternion(rotation);
		writer.WriteVector3(velocity);
		writer.WriteBool(breakStacks);
		SendCommandInternal("System.Void PlayerGrabber::CmdReleaseGrabLocation(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,System.Boolean)", -759084796, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdReleaseGrabLocationOthers(Entity e, Vector3 position, Vector3 fromPosition, Quaternion rotation, Vector3 velocity, bool breakStacks)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e);
		writer.WriteVector3(position);
		writer.WriteVector3(fromPosition);
		writer.WriteQuaternion(rotation);
		writer.WriteVector3(velocity);
		writer.WriteBool(breakStacks);
		SendCommandInternal("System.Void PlayerGrabber::CmdReleaseGrabLocationOthers(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,System.Boolean)", -252984151, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdReleaseGrabTarget(Entity e, Entity target, int targetId, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnectionToClient conn = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e);
		writer.WriteEntity(target);
		writer.WriteVarInt(targetId);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		writer.WriteVector3(velocity);
		SendCommandInternal("System.Void PlayerGrabber::CmdReleaseGrabTarget(Aggro.Core.Entity,Aggro.Core.Entity,System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,Mirror.NetworkConnectionToClient)", -2023904246, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcGotChickenJockey(NetworkConnectionToClient conn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(conn, "System.Void PlayerGrabber::RpcGotChickenJockey(Mirror.NetworkConnectionToClient)", -2068406831, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetBox(Entity box, Entity ignore)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerGrabber::ServerSetBox(Aggro.Core.Entity,Aggro.Core.Entity)' called when server was not active");
			return;
		}
		_entitySet.Clear();
		_entities.Clear();
		_entitySet.Add(box);
		_entitySet.Add(ignore);
		if (box.TryGetObject<Grabbable>(out var obj))
		{
			obj.GetStack(_entities);
			for (int i = 0; i < _entities.Count; i++)
			{
				_entitySet.Add(_entities[i]);
			}
		}
		Vector3 position = box.rigidbody.position;
		Quaternion rotation = box.rigidbody.rotation;
		int num = Physics.OverlapBoxNonAlloc(position, Vector3.one * 0.5f, _collidersArray, rotation, 16384);
		for (int j = 0; j < num; j++)
		{
			Entity entity = _collidersArray[j].GetEntity();
			if (!_entitySet.Contains(entity))
			{
				if (entity.TryGetObject<Grabbable>(out var obj2))
				{
					obj2.ServerAddPlacementForce(box, position);
				}
				else if (entity.Exists())
				{
					Debug.LogWarning($"PlayerGrabber.ServerSetBox - Collider does not have a valid entity ({entity})");
				}
				else
				{
					Debug.LogWarning($"PlayerGrabber.ServerSetBox - Collider's entity does not have a Grabbable ({entity})");
				}
			}
		}
	}

	private void LocalPlayerSetKickDebounce(Entity e)
	{
		if (e.Exists())
		{
			e.SetOrAddStruct(new VehicleController.KickedComp
			{
				frameKicked = TimeUtil.frame
			});
		}
	}

	[Server]
	private void ServerSetVelocity(Grabbable grabbable, Vector3 velocity)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerGrabber::ServerSetVelocity(Grabbable,UnityEngine.Vector3)' called when server was not active");
			return;
		}
		_grabbables.Clear();
		grabbable.GetStack(_grabbables);
		for (int i = 0; i < _grabbables.Count; i++)
		{
			Entity entity = _grabbables[i].entity;
			entity.rigidbody.velocity = velocity;
			entity.rigidbody.angularVelocity = Vector3.zero;
		}
	}

	[TargetRpc]
	private void RpcRequestGranted(Entity e)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e);
		SendTargetRPCInternal(null, "System.Void PlayerGrabber::RpcRequestGranted(Aggro.Core.Entity)", 1064066870, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private Vector3 GetReleaseVelocity()
	{
		Vector3 velocity = base.entity.rigidbody.velocity;
		float magnitude = velocity.magnitude;
		if (magnitude <= 0f)
		{
			return Vector3.zero;
		}
		velocity /= magnitude;
		float num = math.dot(velocity, base.entity.transform.forward);
		magnitude = math.min(magnitude, 15f);
		float num3;
		if (num > 0f)
		{
			float num2 = math.lerp(1f, grabReleaseVelocityForwardMultiplier, math.saturate(magnitude / 15f));
			num3 = magnitude * num2 * num;
		}
		else
		{
			num3 = magnitude * grabReleaseVelocityBackwardsMultiplier * math.abs(num);
		}
		float num4;
		switch (_data.liftState)
		{
		case PlayerLiftState.LoweredContext:
		case PlayerLiftState.LoweredNotUsable:
			num4 = grabReleaseVelocityUpwardsModifierLowered;
			break;
		case PlayerLiftState.RaisedContext:
		case PlayerLiftState.RaisedExplicit:
			num4 = grabReleaseVelocityUpwardsModifierRaised;
			break;
		default:
			throw new InvalidEnumException();
		}
		num3 /= math.cos(math.radians(num4));
		velocity = Quaternion.AngleAxis(num4, MathUtil.GetOrtho(velocity, Vector3.up)) * velocity;
		return velocity * num3;
	}

	[TargetRpc]
	private void RpcRequestDenied()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(null, "System.Void PlayerGrabber::RpcRequestDenied()", -1983997412, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public bool TryGetShopHolderGrabTarget(out ShopHolder holder)
	{
		if (_data.grabTarget.HasObject<ShopHolder>())
		{
			_shopHolders.Clear();
			_data.grabTarget.GetObjects(_shopHolders);
			for (int i = 0; i < _shopHolders.Count; i++)
			{
				ShopHolder shopHolder = _shopHolders[i];
				if (shopHolder.id == _data.grabId)
				{
					holder = shopHolder;
					return true;
				}
			}
		}
		holder = null;
		return false;
	}

	protected override void OnServerOwnerDisconnecting()
	{
		if (serverGrabbed.TryGetObject<Grabbable>(out var obj))
		{
			serverGrabbed = Entity.invalid;
			obj.ServerBreakStackAtMe();
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Quaternion quaternion2 = Quaternion.Euler(0f, grabCandidateCheckAngle / 2f, 0f);
		Gizmos.DrawLine(base.transform.position, base.transform.position + quaternion2 * base.transform.forward * grabCandidateCheckRadius);
		Gizmos.DrawLine(base.transform.position, base.transform.position + base.transform.forward * grabCandidateCheckRadius);
		Gizmos.DrawLine(base.transform.position, base.transform.position + Quaternion.Inverse(quaternion2) * base.transform.forward * grabCandidateCheckRadius);
		Gizmos.color = Color.yellow;
		Vector3 right = base.transform.right;
		Gizmos.DrawLine(base.transform.position + right * grabCandidatePriorityProjectedDistance, base.transform.position + -right * grabCandidatePriorityProjectedDistance);
		Gizmos.color = Color.green;
		for (int i = 0; i < _debugGrabCandidates.Count; i++)
		{
			Vector3 vector = _debugGrabCandidates[i];
			vector.y = 0f;
			Vector3 vector2 = Vector3.Project(vector - base.transform.position, right);
			Gizmos.DrawLine(base.transform.position + vector2, vector);
		}
	}

	static PlayerGrabber()
	{
		_collidersArray = new Collider[32];
		_colliders = new List<Collider>();
		_grabbables = new List<Grabbable>();
		_holders = new List<GrabbableHolder>();
		_shopHolders = new List<ShopHolder>();
		_entities = new List<Entity>();
		_entitySet = new HashSet<Entity>();
		_ids = new HashSet<uint>();
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerGrabber), "System.Void PlayerGrabber::CmdRequestGrab(Aggro.Core.Entity)", InvokeUserCode_CmdRequestGrab__Entity, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerGrabber), "System.Void PlayerGrabber::CmdReleaseGrabLocation(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,System.Boolean)", InvokeUserCode_CmdReleaseGrabLocation__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerGrabber), "System.Void PlayerGrabber::CmdReleaseGrabLocationOthers(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,System.Boolean)", InvokeUserCode_CmdReleaseGrabLocationOthers__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerGrabber), "System.Void PlayerGrabber::CmdReleaseGrabTarget(Aggro.Core.Entity,Aggro.Core.Entity,System.Int32,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdReleaseGrabTarget__Entity__Entity__Int32__Vector3__Quaternion__Vector3__NetworkConnectionToClient, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerGrabber), "System.Void PlayerGrabber::RpcPlayerDropBoxes(System.Boolean,System.Boolean)", InvokeUserCode_RpcPlayerDropBoxes__Boolean__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerGrabber), "System.Void PlayerGrabber::RpcDropBoxesSimple()", InvokeUserCode_RpcDropBoxesSimple);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerGrabber), "System.Void PlayerGrabber::RpcGotChickenJockey(Mirror.NetworkConnectionToClient)", InvokeUserCode_RpcGotChickenJockey__NetworkConnectionToClient);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerGrabber), "System.Void PlayerGrabber::RpcRequestGranted(Aggro.Core.Entity)", InvokeUserCode_RpcRequestGranted__Entity);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerGrabber), "System.Void PlayerGrabber::RpcRequestDenied()", InvokeUserCode_RpcRequestDenied);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPlayerDropBoxes__Boolean__Boolean(bool breakStack, bool checkUpgrade)
	{
		LocalPlayerDropBoxes(breakStack, checkUpgrade);
	}

	protected static void InvokeUserCode_RpcPlayerDropBoxes__Boolean__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcPlayerDropBoxes called on server.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_RpcPlayerDropBoxes__Boolean__Boolean(reader.ReadBool(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcDropBoxesSimple()
	{
		_data.grabState = PlayerGrabState.ReleasingGrab;
		_data.grabTarget = Entity.invalid;
		_data.hintTarget = Entity.invalid;
		_data.hintId = -1;
	}

	protected static void InvokeUserCode_RpcDropBoxesSimple(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcDropBoxesSimple called on server.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_RpcDropBoxesSimple();
		}
	}

	protected void UserCode_CmdRequestGrab__Entity(Entity e)
	{
		if (e.TryGetObject<Grabbable>(out var obj) && obj.isInteractable)
		{
			if (obj.isInStack && !obj.isBase)
			{
				obj.ServerSplitStackAtMe();
			}
			if (obj.serverHolderEntity.Exists())
			{
				_holders.Clear();
				obj.serverHolderEntity.GetObjects(_holders);
				for (int i = 0; i < _holders.Count; i++)
				{
					GrabbableHolder grabbableHolder = _holders[i];
					if (grabbableHolder.id == obj.serverHolderId)
					{
						grabbableHolder.ServerRemoveItem();
						break;
					}
				}
			}
			obj.ServerPlayerGrabbed(this);
			RpcRequestGranted(obj.entity);
			serverGrabbed = e;
		}
		else
		{
			RpcRequestDenied();
		}
	}

	protected static void InvokeUserCode_CmdRequestGrab__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestGrab called on client.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_CmdRequestGrab__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdReleaseGrabLocation__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean(Entity e, Vector3 position, Vector3 fromPosition, Quaternion rotation, Vector3 velocity, bool breakStacks)
	{
		if (e.TryGetObject<Grabbable>(out var obj))
		{
			float num = math.min((float)NetworkUtil.ServerGetPing(base.connectionToClient), 0.3f);
			Vector3 vector = position + num * velocity;
			fromPosition.y = math.max(vector.y, 0.6f);
			Vector3 vector2 = vector - fromPosition;
			float magnitude = vector2.magnitude;
			vector2 /= magnitude;
			if (Physics.SphereCast(new Ray(fromPosition, vector2), 0.1f, out var hitInfo, magnitude, 2048))
			{
				vector = hitInfo.point - vector2 * 0.5f;
			}
			if (Physics.SphereCast(new Ray(vector + Vector3.up, Vector3.down), 0.5f, out hitInfo, 1.5f, 2097152))
			{
				vector = hitInfo.point + Vector3.up * 0.55f;
			}
			obj.ServerPlayerDropped(vector, velocity, rotation);
			ServerSetBox(e, Entity.invalid);
			if (breakStacks)
			{
				obj.ServerBreakEntireStack();
			}
		}
		serverGrabbed = Entity.invalid;
	}

	protected static void InvokeUserCode_CmdReleaseGrabLocation__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReleaseGrabLocation called on client.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_CmdReleaseGrabLocation__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean(reader.ReadEntity(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVector3(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdReleaseGrabLocationOthers__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean(Entity e, Vector3 position, Vector3 fromPosition, Quaternion rotation, Vector3 velocity, bool breakStacks)
	{
		if (e.TryGetObject<Grabbable>(out var obj) && obj.isBase && obj.isInStack)
		{
			_grabbables.Clear();
			obj.GetStack(_grabbables);
			if (_grabbables.Count > 1)
			{
				Grabbable grabbable = _grabbables[1];
				grabbable.ServerSplitStackAtMe();
				float num = math.min((float)NetworkUtil.ServerGetPing(base.connectionToClient), 0.3f);
				Vector3 vector = position + num * velocity;
				fromPosition.y = math.max(vector.y, 0.6f);
				Vector3 vector2 = vector - fromPosition;
				float magnitude = vector2.magnitude;
				vector2 /= magnitude;
				if (Physics.SphereCast(new Ray(fromPosition, vector2), 0.1f, out var hitInfo, magnitude, 2048))
				{
					vector = hitInfo.point - vector2 * 0.5f;
				}
				grabbable.ServerPlayerDropped(vector, velocity, rotation);
				ServerSetBox(grabbable.entity, Entity.invalid);
				if (breakStacks)
				{
					grabbable.ServerBreakEntireStack();
				}
			}
		}
		serverGrabbed = Entity.invalid;
	}

	protected static void InvokeUserCode_CmdReleaseGrabLocationOthers__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReleaseGrabLocationOthers called on client.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_CmdReleaseGrabLocationOthers__Entity__Vector3__Vector3__Quaternion__Vector3__Boolean(reader.ReadEntity(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVector3(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdReleaseGrabTarget__Entity__Entity__Int32__Vector3__Quaternion__Vector3__NetworkConnectionToClient(Entity e, Entity target, int targetId, Vector3 position, Quaternion rotation, Vector3 velocity, NetworkConnectionToClient conn)
	{
		if (e.TryGetObject<Grabbable>(out var obj))
		{
			bool flag = true;
			if (target.Exists())
			{
				if (target.TryGetObject<Grabbable>(out var obj2))
				{
					if (obj2.isInteractable && obj2.CanAddToStack(obj) && obj2.GetStackCount() == 1)
					{
						obj.ServerPlayerPrepareForStacked();
						obj2.ServerAddToStack(obj);
						flag = false;
						if (conn != null && !_serverChickenJockeySent.Contains(conn) && chickenJockeyStack.Length != 0)
						{
							_entities.Clear();
							obj.GetStack(_entities);
							if (_entities.Count >= chickenJockeyStack.Length)
							{
								bool flag2 = true;
								int num = _entities.Count - chickenJockeyStack.Length;
								for (int i = 0; i < chickenJockeyStack.Length; i++)
								{
									if (_entities[num + i].netIdentity.assetId != chickenJockeyStack[i].GetComponent<NetworkIdentity>().assetId)
									{
										flag2 = false;
										break;
									}
								}
								if (flag2)
								{
									_serverChickenJockeySent.Add(conn);
									RpcGotChickenJockey(conn);
								}
							}
						}
					}
				}
				else
				{
					_holders.Clear();
					target.GetObjects(_holders);
					for (int j = 0; j < _holders.Count; j++)
					{
						GrabbableHolder grabbableHolder = _holders[j];
						if (grabbableHolder.id == targetId)
						{
							if (grabbableHolder.ServerTrySetItem(obj, fromPlayer: true))
							{
								obj.ServerPlaceInHolder(grabbableHolder);
								flag = false;
							}
							break;
						}
					}
				}
			}
			if (flag)
			{
				obj.ServerPlayerDropped(position, Vector3.zero, rotation);
				ServerSetVelocity(obj, velocity);
			}
			ServerSetBox(e, target);
		}
		serverGrabbed = Entity.invalid;
	}

	protected static void InvokeUserCode_CmdReleaseGrabTarget__Entity__Entity__Int32__Vector3__Quaternion__Vector3__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReleaseGrabTarget called on client.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_CmdReleaseGrabTarget__Entity__Entity__Int32__Vector3__Quaternion__Vector3__NetworkConnectionToClient(reader.ReadEntity(), reader.ReadEntity(), reader.ReadVarInt(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVector3(), senderConnection);
		}
	}

	protected void UserCode_RpcGotChickenJockey__NetworkConnectionToClient(NetworkConnectionToClient conn)
	{
		Aggro.Core.Platform.UnlockAchievement("ach_chicken_jockey");
	}

	protected static void InvokeUserCode_RpcGotChickenJockey__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcGotChickenJockey called on server.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_RpcGotChickenJockey__NetworkConnectionToClient(null);
		}
	}

	protected void UserCode_RpcRequestGranted__Entity(Entity e)
	{
		if (_data.grabState == PlayerGrabState.Requested)
		{
			_data.grabState = PlayerGrabState.RequestGranted;
			return;
		}
		Debug.Log($"Request Granted but not in right state! {_data.grabState}");
		LocalPlayerSetKickDebounce(_data.grabTarget);
		CmdReleaseGrabLocation(e, e.transform.position, checkThrowFrom.position, e.transform.rotation, GetReleaseVelocity(), breakStacks: false);
	}

	protected static void InvokeUserCode_RpcRequestGranted__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcRequestGranted called on server.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_RpcRequestGranted__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_RpcRequestDenied()
	{
		_data.grabState = PlayerGrabState.NotGrabbing;
	}

	protected static void InvokeUserCode_RpcRequestDenied(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcRequestDenied called on server.");
		}
		else
		{
			((PlayerGrabber)obj).UserCode_RpcRequestDenied();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(syncLiftRaised);
			writer.WriteEntity(syncGrabTarget);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(syncLiftRaised);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteEntity(syncGrabTarget);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref syncLiftRaised, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncGrabTarget, null, reader.ReadEntity());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncLiftRaised, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncGrabTarget, null, reader.ReadEntity());
		}
	}
}
