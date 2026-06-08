using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProbeItem : DropableItem, ICombatTarget, IDamagableObject, IHasHitpoints, IOverrideHitpoints, ITargetLocation, IUpdateCameraView
{
	private const float PAUSE_BETWEEN_ROOM_CHANGE = 2f;

	public Material NormalMtl;

	public GameObject probeModel;

	public AudioSource hoverAudio;

	private float _currentHitPoints;

	private bool _isDead;

	private ColorBlinkManager _blinkManager = new ColorBlinkManager();

	private Color _startColor;

	private float _velocityScale = 0.1f;

	private float _currentSpeed = 0.3f;

	private Waypoint _currentWaypoint;

	private List<Waypoint> _currentPath;

	private float _roomChangePauseTimer;

	private DungeonManager _dungeonManager;

	private Dictionary<Room, float> _previousRoomsWithTime = new Dictionary<Room, float>();

	private System.Random _randomGenerator = new System.Random();

	private bool isInTakingDamageState;

	private float timerUntilNextDamageNotification;

	private float _totalHitpoints = 100f;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public override DropItemType DropType
	{
		get
		{
			return DropItemType.Probe;
		}
	}

	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	public Collider ObjectCollider
	{
		get
		{
			return GetComponent<Collider>();
		}
	}

	public bool CanCollide
	{
		get
		{
			return true;
		}
	}

	public List<ICombatTarget> SubordinateTargets { get; set; }

	public bool IsHidden { get; private set; }

	public Room CurrentRoom { get; set; }

	public Corridor CurrentCorridor { get; set; }

	public float CurrentHitPoints
	{
		get
		{
			return _currentHitPoints;
		}
	}

	public float TotalHitpoints
	{
		get
		{
			return _totalHitpoints;
		}
	}

	public float TimeStunned { get; private set; }

	public bool IsDead
	{
		get
		{
			return _isDead;
		}
	}

	public bool IsStunned { get; private set; }

	public Vector3 StunPosition { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiCurrentHitpoints != CurrentHitPoints)
			{
				_guiString = " (" + Math.Round(CurrentHitPoints, 0) + ") ";
				guiCurrentHitpoints = CurrentHitPoints;
			}
			return _guiString;
		}
	}

	public void Initialize(Room room, Corridor corridor)
	{
		CurrentRoom = room;
		CurrentCorridor = corridor;
		if (room != null)
		{
			_previousRoomsWithTime.Add(room, 0f);
		}
	}

	private void Awake()
	{
		_currentWaypoint = null;
		_currentPath = null;
		SubordinateTargets = new List<ICombatTarget>();
	}

	public override void Start()
	{
		base.Start();
		_currentHitPoints = TotalHitpoints;
		GetComponent<Renderer>().material = NormalMtl;
		_startColor = GetComponent<Renderer>().material.color;
		_dungeonManager = DungeonManager.Instance;
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			probeModel.SetActive(false);
		}
		EventManager.Instance.SubscribeInstant(GeneralEventType.RefreshNavigation, HandleResetNavigation);
	}

	protected override void Update()
	{
		if (!GlobalSettings.IsGamePaused)
		{
			if (_blinkManager.IsActive)
			{
				Color color = _blinkManager.Update(Time.deltaTime);
				GetComponent<Renderer>().material.color = color;
				if (dvOverlayObject != null)
				{
					dvOverlayObject.GetComponent<Renderer>().material.color = color;
				}
				if (svOverlayObject != null)
				{
					svOverlayObject.GetComponent<Renderer>().material.color = color;
				}
				if (IsDead)
				{
					hoverAudio.Stop();
					SetDead();
				}
			}
			if (!IsDead)
			{
				CalcCurrentRoom();
				CalcCurrentCorridor();
				if (CurrentRoom != null && !CurrentRoom.isExplored)
				{
					CurrentRoom.ExternallyMarkAsExplored();
				}
				if (_roomChangePauseTimer > 0f)
				{
					_roomChangePauseTimer -= Time.deltaTime;
				}
				if (_currentPath == null || _currentPath.Count == 0)
				{
					CalculateNextRoom();
				}
				else if (_currentPath != null && _roomChangePauseTimer <= 0f)
				{
					MoveToNextWaypoint();
				}
				if (GlobalSettings.cameraMode == CameraMode.Drone)
				{
					hoverAudio.volume = GameAudio.RemoteVolume * 1f;
				}
			}
			if (isInTakingDamageState && timerUntilNextDamageNotification > 0f)
			{
				timerUntilNextDamageNotification -= Time.deltaTime;
			}
		}
		base.Update();
	}

	private void CalculateNextRoom()
	{
		Room room = CurrentRoom;
		if (room == null && CurrentCorridor != null)
		{
			room = CurrentCorridor.rooms.FirstOrDefault();
		}
		if (!(room != null))
		{
			return;
		}
		List<AdjacentRoomData> list = null;
		List<AdjacentRoomData> list2 = NavigationHelper.GetAllAdjacentRoomData(room).ToList();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			AdjacentRoomData adjacentRoomData = list2[i];
			if (adjacentRoomData.ConnectingDoor.state == DoorState.Open)
			{
				if (list == null)
				{
					list = new List<AdjacentRoomData>();
				}
				list.Add(adjacentRoomData);
			}
		}
		if (list == null)
		{
			if (!room.isScanned)
			{
				_currentPath = new List<Waypoint>();
				_currentPath.Add(NavigationHelper.GetMainRoomWaypoint(room));
			}
			return;
		}
		AdjacentRoomData adjacentRoomData2 = CommonMethods.PickRandomItem(list.Where((AdjacentRoomData x) => !_previousRoomsWithTime.Keys.Contains(x.Room1) || !_previousRoomsWithTime.Keys.Contains(x.Room2)).ToList(), _randomGenerator);
		if (adjacentRoomData2 == null)
		{
			List<KeyValuePair<Room, float>> list3 = _previousRoomsWithTime.OrderBy((KeyValuePair<Room, float> x) => x.Value).ToList();
			count = list3.Count();
			int count2 = list.Count;
			for (int num = 0; num < count; num++)
			{
				Room key = list3[num].Key;
				adjacentRoomData2 = null;
				for (int num2 = 0; num2 < count2; num2++)
				{
					AdjacentRoomData adjacentRoomData3 = list[num2];
					if (adjacentRoomData3.Room1 == key || adjacentRoomData3.Room2 == key)
					{
						adjacentRoomData2 = adjacentRoomData3;
						break;
					}
				}
				if (adjacentRoomData2 != null)
				{
					break;
				}
			}
		}
		if (adjacentRoomData2 == null)
		{
			adjacentRoomData2 = CommonMethods.PickRandomItem(list.ToList(), _randomGenerator);
		}
		if (adjacentRoomData2 == null)
		{
			return;
		}
		if (room == adjacentRoomData2.Room1)
		{
			_currentPath = adjacentRoomData2.ConnectingWaypoints.ToList();
		}
		else
		{
			_currentPath = adjacentRoomData2.ConnectingWaypoints.ToList();
			_currentPath.Reverse();
		}
		if (!_currentPath.Contains(_currentWaypoint) || !(_currentPath[0] != _currentWaypoint))
		{
			return;
		}
		List<Waypoint> list4 = _currentPath.ToList();
		count = list4.Count;
		for (int num3 = 0; num3 < count; num3++)
		{
			Waypoint waypoint = list4[num3];
			if (waypoint != _currentWaypoint)
			{
				_currentPath.Remove(waypoint);
				continue;
			}
			break;
		}
	}

	private void MoveToNextWaypoint()
	{
		_currentWaypoint = _currentPath[0];
		if (_currentWaypoint.IsBlocked())
		{
			_currentPath = null;
			_roomChangePauseTimer = 2f;
			return;
		}
		float num = Vector3.Distance(base.transform.position, _currentWaypoint.transform.position);
		if (num > 0.5f)
		{
			if (dvOverlayObject != null)
			{
				dvOverlayObject.transform.parent = null;
			}
			bool flag = svOverlayObject != null && svOverlayObject.transform.parent != null;
			if (svOverlayObject != null)
			{
				svOverlayObject.transform.parent = null;
			}
			Vector3 position = _currentWaypoint.transform.position;
			position.z = base.transform.position.z;
			base.transform.LookAt(position);
			if (dvOverlayObject != null)
			{
				dvOverlayObject.transform.parent = base.transform;
			}
			if (flag && svOverlayObject != null)
			{
				svOverlayObject.transform.parent = base.transform;
			}
			moveForward();
			if (dvOverlayObject != null)
			{
				dvOverlayObject.transform.parent = null;
			}
			if (svOverlayObject != null)
			{
				svOverlayObject.transform.parent = null;
			}
			if (dvOverlayObject != null)
			{
				dvOverlayObject.transform.parent = base.transform;
			}
			if (flag && svOverlayObject != null)
			{
				svOverlayObject.transform.parent = base.transform;
			}
		}
		else
		{
			_currentPath.RemoveAt(0);
			if (_currentPath.Count == 0)
			{
				_roomChangePauseTimer = 2f;
			}
			if (CurrentRoom != null && !CurrentRoom.isScanned)
			{
				CurrentRoom.scan(false);
			}
		}
	}

	private void CalcCurrentRoom()
	{
		if (CurrentRoom != null && CurrentRoom.GetComponent<Collider>().bounds.Contains(base.transform.position))
		{
			return;
		}
		Room room = null;
		Room[] rooms = _dungeonManager.rooms;
		foreach (Room room2 in rooms)
		{
			if (room2.GetComponent<Collider>().bounds.Contains(base.transform.position))
			{
				room = room2;
				break;
			}
		}
		if (!(room != null))
		{
			return;
		}
		CurrentRoom = room;
		_previousRoomsWithTime[room] = Time.time;
		if (IsHidden)
		{
			return;
		}
		RoomItem roomItem = CurrentRoom.GetRoomItem(typeof(DungeonDefense), true);
		if (roomItem != null)
		{
			DungeonDefense dungeonDefense = (DungeonDefense)roomItem;
			if (dungeonDefense.armed)
			{
				TakeDamage(1000f, DamageType.Physical, null);
				SystemMessageManager.ShowSystemMessage("Probe destroyed by ship defense", ConsoleMessageType.Warning);
			}
		}
	}

	private void CalcCurrentCorridor()
	{
		if (CurrentCorridor != null && CurrentCorridor.GetComponent<Collider>().bounds.Contains(base.transform.position))
		{
			return;
		}
		Corridor currentCorridor = null;
		Corridor[] corridors = _dungeonManager.corridors;
		foreach (Corridor corridor in corridors)
		{
			if (corridor.GetComponent<Collider>().bounds.Contains(base.transform.position))
			{
				currentCorridor = corridor;
				break;
			}
		}
		CurrentCorridor = currentCorridor;
	}

	public void moveForward()
	{
		base.transform.position += GetVelocityDelta();
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
	}

	private Vector3 GetVelocityDelta()
	{
		return base.transform.forward * _velocityScale * _currentSpeed * 60f * Time.deltaTime;
	}

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (droneUIObject != null)
			{
				probeModel.SetActive(!droneUIObject.Deactivated);
			}
			if (IsDead)
			{
				GetComponent<Renderer>().material = DeathMtl;
				return;
			}
			GetComponent<Renderer>().material = NormalMtl;
			hoverAudio.Play();
		}
		else
		{
			probeModel.SetActive(false);
			if (hoverAudio.isPlaying)
			{
				hoverAudio.Stop();
			}
		}
	}

	public void Stun(float durationMin, float durationMax)
	{
	}

	public void ClearStun()
	{
	}

	public void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (!IsDead)
		{
			_blinkManager.Start(_startColor, DamageColor, 0.5f, 4);
			_currentHitPoints -= damage;
			if (_currentHitPoints <= 0f)
			{
				_currentHitPoints = 0f;
				_isDead = true;
				base.Destroyed = true;
				hoverAudio.Stop();
				SetDead();
			}
			else if (!isInTakingDamageState || timerUntilNextDamageNotification <= 0f)
			{
				isInTakingDamageState = true;
				timerUntilNextDamageNotification = 1.5f;
				SystemMessageManager.ShowSystemMessage("Probe taking damage", ConsoleMessageType.Warning);
			}
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}

	private void HandleResetNavigation(object sender, EventArgs args)
	{
		_currentPath = null;
		_currentWaypoint = null;
	}

	public void OverrideCurrentHitpoints(float hitpoints)
	{
		_currentHitPoints = hitpoints;
	}

	public void OverrideTotalHitpoints(float hitpoints)
	{
		_totalHitpoints = hitpoints;
	}

	public void OverrideIsDead(bool isDead)
	{
		_isDead = isDead;
	}

	public void SetStealthMode()
	{
		IsHidden = true;
	}

	public void DisconnectSvVisuals()
	{
		if (svOverlayObject != null)
		{
			svOverlayObject.transform.parent = null;
		}
	}

	public void ReconnectSvVisuals()
	{
		if (svOverlayObject != null)
		{
			svOverlayObject.transform.parent = base.transform;
			svOverlayObject.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, svOverlayObject.transform.position.z);
		}
	}

	public override void Vaporize()
	{
		probeModel.SetActive(false);
		GetComponent<Renderer>().enabled = false;
		base.gameObject.GetComponent<Renderer>().enabled = false;
		base.gameObject.SetActive(false);
		UnityEngine.Object.Destroy(base.gameObject);
		droneUIObject.Deactivate();
		UnityEngine.Object.Destroy(droneUIObject.gameObject);
	}

	public override void SetDeactivated()
	{
		if (probeModel.activeSelf)
		{
			probeModel.SetActive(false);
		}
		base.SetDeactivated();
	}
}
