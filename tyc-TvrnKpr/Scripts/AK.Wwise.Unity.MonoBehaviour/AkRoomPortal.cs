using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkRoomPortal")]
[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class AkRoomPortal : AkTriggerHandler
{
	public enum State
	{
		Closed = 0,
		Open = 1
	}

	public const int MAX_ROOMS_PER_PORTAL = 2;

	public State initialState;

	private bool active;

	public List<int> closePortalTriggerList;

	[SerializeField]
	private AkRoom[] rooms;

	private AkRoom.PriorityList[] roomList;

	private AkTransform portalTransform;

	private BoxCollider portalCollider;

	private bool portalSet;

	private bool portalNeedsUpdate;

	private Vector3 previousPosition;

	private Vector3 previousScale;

	private Quaternion previousRotation;

	public bool portalActive
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private ulong frontRoomID => 0uL;

	private ulong backRoomID => 0uL;

	public AkRoom frontRoom => null;

	public AkRoom backRoom => null;

	public bool IsValid => false;

	public AkRoom GetRoom(int index)
	{
		return null;
	}

	public bool isSetInWwise()
	{
		return false;
	}

	private void SetRoomPortal()
	{
	}

	public void UpdateRoomPortal()
	{
	}

	public bool Overlaps(AkRoom room)
	{
		return false;
	}

	public ulong GetID()
	{
		return 0uL;
	}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}

	public void ClosePortal(GameObject in_gameObject)
	{
	}

	protected override void OnDestroy()
	{
	}

	public override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private bool IsRoomActive(AkRoom in_room)
	{
		return false;
	}

	public void Open()
	{
	}

	public void Close()
	{
	}

	public void FindOverlappingRooms(AkRoom.PriorityList[] roomList)
	{
	}

	private void FillRoomList(Vector3 position, AkRoom.PriorityList list)
	{
	}

	public bool UpdateRooms()
	{
		return false;
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public void SetRoom(int in_roomIndex, AkRoom in_room)
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public void SetFrontRoom(AkRoom room)
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public void SetBackRoom(AkRoom room)
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public void UpdateSoundEngineRoomIDs()
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public void UpdateOverlappingRooms()
	{
	}
}
