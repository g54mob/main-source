using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class PlayerStationPlacer : NetworkEntityBehaviourBase
{
	[Header("Pick up")]
	[Min(0f)]
	public float pickUpDistance = 3f;

	[Min(0f)]
	public float pickUpRadius = 1f;

	[Header("Place")]
	[Min(0f)]
	public float placeMaxDistanceFromPlayer = 8f;

	[Min(0f)]
	public float placeSnapSize = 0.25f;

	public StudioEventEmitter startPickUpSFX;

	private static Collider[] _colliders;

	private static Vector3[] _corners;

	private Entity _placingBoxStation;

	private Entity _previewEntity;

	private bool _isPickingUp;

	private int _angleIndex;

	private int _inputRotate;

	private bool _inputPickingUp;

	private bool _inputStartPickUp;

	private bool _inputPlace;

	private bool _gizmoEnabled;

	private Quaternion _gizmoRotation;

	private Vector3 _gizmoLocation;

	private Vector3 _gizmoSize;

	private Vector3 _gizmoPlayerPos;

	private string _placedAchievement;

	public GameObject placementVFX;

	public Entity pickUpCandidate { get; private set; }

	protected override void OnUpdatePresentation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		if (!AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen)
		{
			if (AggroInputManager.input.Game.StationRotateClockwise.WasPerformedThisFrame())
			{
				_inputRotate++;
			}
			if (AggroInputManager.input.Game.StationRotateCounterClockwise.WasPerformedThisFrame())
			{
				_inputRotate--;
			}
			if (AggroInputManager.input.Game.StationPlace.WasPerformedThisFrame())
			{
				_inputPlace = true;
			}
			if (AggroInputManager.input.Game.StationPlace.WasPressedThisFrame())
			{
				_inputStartPickUp = true;
			}
		}
		_inputPickingUp = AggroInputManager.input.Game.StationPlace.IsPressed() && !AggroManagerBase<TipTapPhoneVisual>.instance.tiptapOpen;
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isLocalPlayer)
		{
			return;
		}
		PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
		if (playerGrabber.grabState == PlayerGrabState.Grabbed && !playerGrabber.syncLiftRaised && playerGrabber.localPlayerGrabTarget.TryGetObject<BoxStation>(out var obj) && obj != null)
		{
			if (playerGrabber.localPlayerGrabTarget != _placingBoxStation)
			{
				if (_previewEntity.Exists())
				{
					EntityUtil.Destroy(_previewEntity);
				}
				_previewEntity = EntityUtil.Instantiate(obj.previewPrefab);
				_angleIndex = obj.GetDefaultAngleIndex();
				_placingBoxStation = playerGrabber.localPlayerGrabTarget;
			}
			float[] angles = obj.GetAngles();
			_angleIndex += _inputRotate;
			if (_angleIndex < 0)
			{
				_angleIndex = math.max(angles.Length + _angleIndex, 0);
			}
			_angleIndex %= angles.Length;
			Quaternion rotation = Quaternion.AngleAxis(angles[_angleIndex], Vector3.up);
			StationPreview stationPreview = _previewEntity.GetObject<StationPreview>();
			if (CanPlaceStation(playerGrabber.localPlayerGrabTarget, base.entity.transform.position, base.entity.transform.forward, rotation, out var placementPos))
			{
				stationPreview.SetPlacement(placementPos, rotation, isValid: true);
				if (_inputPlace)
				{
					NetworkAggroManagerBase<VFXManager>.instance.Play(placementVFX, placementPos);
					if (GameUtil.GetCurrentRoomType() == RoomType.Warehouse)
					{
						_placedAchievement = obj.warehousePlacedAchievement;
					}
					CmdPlaceStation(playerGrabber.localPlayerGrabTarget, placementPos, rotation);
				}
			}
			else
			{
				stationPreview.SetPlacement(placementPos, rotation, isValid: false);
			}
		}
		else
		{
			_gizmoEnabled = false;
			if (_previewEntity.Exists())
			{
				EntityUtil.Destroy(_previewEntity);
				_previewEntity = Entity.invalid;
			}
			_placingBoxStation = Entity.invalid;
		}
		if (!pickUpCandidate.Exists())
		{
			_isPickingUp = false;
		}
		if (_isPickingUp)
		{
			if (!_inputPickingUp && pickUpCandidate.Exists())
			{
				CmdStopPickingUp(pickUpCandidate);
				_isPickingUp = false;
			}
		}
		else if (_inputStartPickUp && pickUpCandidate.Exists())
		{
			startPickUpSFX.Play();
			CmdStartPickingUp(pickUpCandidate);
			_isPickingUp = true;
		}
		else
		{
			Vector3 position = base.entity.transform.position;
			Vector3 point = position + base.entity.transform.forward * pickUpDistance;
			int num = Physics.OverlapCapsuleNonAlloc(position, point, pickUpRadius, _colliders, 524288);
			float num2 = float.MaxValue;
			Entity entity = Entity.invalid;
			for (int i = 0; i < num; i++)
			{
				Entity entity2 = _colliders[i].GetEntity();
				float num3 = math.distancesq(position, entity2.transform.position);
				if (num3 < num2 && entity2.GetObject<Station>().canBePickedUp)
				{
					entity = entity2;
					num2 = num3;
				}
			}
			if (entity == Entity.invalid || entity != pickUpCandidate)
			{
				pickUpCandidate = entity;
			}
		}
		_inputRotate = 0;
		_inputPlace = false;
		_inputStartPickUp = false;
	}

	[Command]
	private void CmdPlaceStation(Entity boxEntity, Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(boxEntity);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendCommandInternal("System.Void PlayerStationPlacer::CmdPlaceStation(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Quaternion)", -299490930, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlacementConfirmed(EventReference eventRef, Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEventReference(eventRef);
		writer.WriteVector3(position);
		SendRPCInternal("System.Void PlayerStationPlacer::RpcPlacementConfirmed(FMODUnity.EventReference,UnityEngine.Vector3)", 787789361, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdStartPickingUp(Entity stationEntity)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(stationEntity);
		SendCommandInternal("System.Void PlayerStationPlacer::CmdStartPickingUp(Aggro.Core.Entity)", 1919082889, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command]
	private void CmdStopPickingUp(Entity stationEntity)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(stationEntity);
		SendCommandInternal("System.Void PlayerStationPlacer::CmdStopPickingUp(Aggro.Core.Entity)", 3700829, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private bool CanPlaceStation(Entity boxEntity, Vector3 playerPos, Vector3 placeDir, Quaternion rotation, out Vector3 placementPos)
	{
		if (boxEntity.TryGetObject<BoxStation>(out var obj))
		{
			Vector3 vector = new Vector3(obj.stationCheckSizeX, 1f, obj.stationCheckSizeZ);
			MathUtil.GetBoxCorners(Vector3.zero, vector, rotation, _corners);
			float num = 0f;
			for (int i = 0; i < _corners.Length; i++)
			{
				num = math.max(num, 0f - Vector3.Dot(_corners[i], placeDir));
			}
			Vector3 vector2 = playerPos + placeDir * num;
			if (Physics.OverlapBoxNonAlloc(vector2, vector / 2f, _colliders, rotation, 2099200) == 0)
			{
				if (Physics.BoxCast(vector2, vector / 2f, placeDir, out var hitInfo, rotation, placeMaxDistanceFromPlayer - num, 2099200))
				{
					placementPos = vector2 + placeDir * (hitInfo.distance - 0.05f);
					placementPos = MathUtil.SnapTowardIncrement(placementPos, -placeDir, placeSnapSize);
				}
				else
				{
					placementPos = vector2 + placeDir * (placeMaxDistanceFromPlayer - num);
					placementPos = MathUtil.SnapTowardIncrement(placementPos, placeDir, placeSnapSize);
				}
			}
			else
			{
				placementPos = MathUtil.SnapTowardIncrement(vector2, placeDir, placeSnapSize);
			}
			_gizmoEnabled = true;
			_gizmoLocation = placementPos;
			_gizmoRotation = rotation;
			_gizmoSize = vector;
			_gizmoPlayerPos = playerPos;
			int num2 = 2103296;
			if (obj.checkForBoxesAndPlayers)
			{
				num2 |= 0x4108;
			}
			return Physics.OverlapBoxNonAlloc(placementPos, vector / 2f, _colliders, rotation, num2) == 0;
		}
		_gizmoEnabled = false;
		placementPos = Vector3.zero;
		return false;
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying && GameUtil.isReady && base.isLocalPlayer && _gizmoEnabled)
		{
			Gizmos.color = Color.cyan;
			Gizmos.matrix = Matrix4x4.Translate(_gizmoLocation) * Matrix4x4.Rotate(_gizmoRotation);
			Gizmos.DrawWireCube(Vector3.zero, _gizmoSize);
			Gizmos.color = Color.yellow;
			Gizmos.matrix = Matrix4x4.identity;
			for (int i = 0; i < _corners.Length; i++)
			{
				Gizmos.DrawSphere(_gizmoPlayerPos + _corners[i], 0.1f);
			}
		}
	}

	static PlayerStationPlacer()
	{
		_colliders = new Collider[16];
		_corners = new Vector3[8];
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerStationPlacer), "System.Void PlayerStationPlacer::CmdPlaceStation(Aggro.Core.Entity,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdPlaceStation__Entity__Vector3__Quaternion, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerStationPlacer), "System.Void PlayerStationPlacer::CmdStartPickingUp(Aggro.Core.Entity)", InvokeUserCode_CmdStartPickingUp__Entity, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerStationPlacer), "System.Void PlayerStationPlacer::CmdStopPickingUp(Aggro.Core.Entity)", InvokeUserCode_CmdStopPickingUp__Entity, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerStationPlacer), "System.Void PlayerStationPlacer::RpcPlacementConfirmed(FMODUnity.EventReference,UnityEngine.Vector3)", InvokeUserCode_RpcPlacementConfirmed__EventReference__Vector3);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdPlaceStation__Entity__Vector3__Quaternion(Entity boxEntity, Vector3 position, Quaternion rotation)
	{
		if (boxEntity.Exists())
		{
			BoxStation boxStation = boxEntity.GetObject<BoxStation>();
			RpcPlacementConfirmed(boxStation.placementSFXEvent, base.transform.position);
			boxEntity.TryGetStruct<StationData>(out var comp);
			Entity entity = EntityUtil.Instantiate(boxStation.stationPrefab, position, rotation);
			EntityUtil.Destroy(boxEntity);
			entity.AddStruct(comp);
			if (entity.TryGetObject<IStation>(out var obj))
			{
				obj.ServerPlaced();
			}
		}
	}

	protected static void InvokeUserCode_CmdPlaceStation__Entity__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlaceStation called on client.");
		}
		else
		{
			((PlayerStationPlacer)obj).UserCode_CmdPlaceStation__Entity__Vector3__Quaternion(reader.ReadEntity(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_RpcPlacementConfirmed__EventReference__Vector3(EventReference eventRef, Vector3 position)
	{
		AudioManager.PlaySfx(eventRef, position);
		if (!string.IsNullOrEmpty(_placedAchievement))
		{
			Aggro.Core.Platform.UnlockAchievement(_placedAchievement);
		}
	}

	protected static void InvokeUserCode_RpcPlacementConfirmed__EventReference__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlacementConfirmed called on server.");
		}
		else
		{
			((PlayerStationPlacer)obj).UserCode_RpcPlacementConfirmed__EventReference__Vector3(reader.ReadEventReference(), reader.ReadVector3());
		}
	}

	protected void UserCode_CmdStartPickingUp__Entity(Entity stationEntity)
	{
		if (stationEntity.TryGetObject<Station>(out var obj))
		{
			obj.ServerIncrementPickUp();
		}
	}

	protected static void InvokeUserCode_CmdStartPickingUp__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStartPickingUp called on client.");
		}
		else
		{
			((PlayerStationPlacer)obj).UserCode_CmdStartPickingUp__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdStopPickingUp__Entity(Entity stationEntity)
	{
		if (stationEntity.TryGetObject<Station>(out var obj))
		{
			obj.ServerDecrementPickUp();
		}
	}

	protected static void InvokeUserCode_CmdStopPickingUp__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdStopPickingUp called on client.");
		}
		else
		{
			((PlayerStationPlacer)obj).UserCode_CmdStopPickingUp__Entity(reader.ReadEntity());
		}
	}
}
