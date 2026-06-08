using System;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkRoom")]
[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class AkRoom : AkTriggerHandler
{
	public class PriorityList
	{
		private class CompareByPriority : IComparer<AkRoom>
		{
			public virtual int Compare(AkRoom a, AkRoom b)
			{
				int num = a.priority.CompareTo(b.priority);
				if (num == 0 && a != b)
				{
					return 1;
				}
				return -num;
			}
		}

		private static readonly CompareByPriority s_compareByPriority = new CompareByPriority();

		private List<AkRoom> rooms = new List<AkRoom>();

		public int Count => rooms.Count;

		public AkRoom this[int index] => rooms[index];

		public ulong GetHighestPriorityActiveAndEnabledRoomID()
		{
			AkRoom highestPriorityActiveAndEnabledRoom = GetHighestPriorityActiveAndEnabledRoom();
			if (!(highestPriorityActiveAndEnabledRoom == null))
			{
				return highestPriorityActiveAndEnabledRoom.GetID();
			}
			return INVALID_ROOM_ID;
		}

		public AkRoom GetHighestPriorityActiveAndEnabledRoom()
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (rooms[i].isActiveAndEnabled)
				{
					return rooms[i];
				}
			}
			return null;
		}

		public void Clear()
		{
			rooms.Clear();
		}

		public void Add(AkRoom room)
		{
			int num = BinarySearch(room);
			if (num < 0)
			{
				rooms.Insert(~num, room);
			}
		}

		public void Remove(AkRoom room)
		{
			rooms.Remove(room);
		}

		public bool Contains(AkRoom room)
		{
			if ((bool)room)
			{
				return rooms.Contains(room);
			}
			return false;
		}

		public int BinarySearch(AkRoom room)
		{
			if (!room)
			{
				return -1;
			}
			return rooms.BinarySearch(room, s_compareByPriority);
		}
	}

	public static ulong INVALID_ROOM_ID = ulong.MaxValue;

	[Tooltip("Higher number has a higher priority")]
	public int priority;

	public AuxBus reverbAuxBus = new AuxBus();

	[Range(0f, 1f)]
	public float reverbLevel = 1f;

	[Range(0f, 1f)]
	public float transmissionLoss = 1f;

	public Event roomToneEvent = new Event();

	[Range(0f, 1f)]
	[Tooltip("Send level for sounds that are posted on the room game object; adds reverb to ambience and room tones. Valid range: (0.f-1.f). A value of 0 disables the aux send.")]
	public float roomToneAuxSend;

	private List<AkRoomAwareObject> roomAwareObjectsEntered = new List<AkRoomAwareObject>();

	private List<AkRoomAwareObject> roomAwareObjectsDetectedWhileDisabled = new List<AkRoomAwareObject>();

	private Collider roomCollider;

	private Type previousColliderType;

	public static int RoomCount { get; private set; }

	[Obsolete("This functionality is deprecated as of Wwise v2021.1.0 and will be removed in a future release.")]
	public float wallOcclusion
	{
		get
		{
			return transmissionLoss;
		}
		set
		{
			transmissionLoss = value;
		}
	}

	public static ulong GetAkRoomID(AkRoom room)
	{
		if (!(room == null))
		{
			return room.GetID();
		}
		return INVALID_ROOM_ID;
	}

	public bool TryEnter(AkRoomAwareObject roomAwareObject)
	{
		if ((bool)roomAwareObject)
		{
			if (base.isActiveAndEnabled)
			{
				if (!roomAwareObjectsEntered.Contains(roomAwareObject))
				{
					roomAwareObjectsEntered.Add(roomAwareObject);
				}
				return true;
			}
			if (!roomAwareObjectsDetectedWhileDisabled.Contains(roomAwareObject))
			{
				roomAwareObjectsDetectedWhileDisabled.Add(roomAwareObject);
			}
			return false;
		}
		return false;
	}

	public void Exit(AkRoomAwareObject roomAwareObject)
	{
		if ((bool)roomAwareObject)
		{
			roomAwareObjectsEntered.Remove(roomAwareObject);
			roomAwareObjectsDetectedWhileDisabled.Remove(roomAwareObject);
		}
	}

	public ulong GetID()
	{
		return AkSoundEngine.GetAkGameObjectID(base.gameObject);
	}

	public void SetRoom()
	{
		ulong geometryID = GetGeometryID();
		AkRoomParams in_roomParams = new AkRoomParams
		{
			Up = base.transform.up,
			Front = base.transform.forward,
			ReverbAuxBus = reverbAuxBus.Id,
			ReverbLevel = reverbLevel,
			TransmissionLoss = transmissionLoss,
			RoomGameObj_AuxSendLevelToSelf = roomToneAuxSend,
			RoomGameObj_KeepRegistered = roomToneEvent.IsValid()
		};
		RoomCount++;
		AkSoundEngine.SetRoom(GetID(), in_roomParams, geometryID, base.name);
		AkRoomManager.RegisterRoomUpdate(this);
	}

	private Vector3 GetCapsuleScale(Vector3 localScale, float radius, float height, int direction)
	{
		Vector3 result = default(Vector3);
		switch (direction)
		{
		case 0:
			result.y = Mathf.Max(localScale.y, localScale.z) * (radius * 2f);
			result.z = result.y;
			result.x = Mathf.Max(result.y, localScale.x * height);
			break;
		case 2:
			result.x = Mathf.Max(localScale.x, localScale.y) * (radius * 2f);
			result.y = result.x;
			result.z = Mathf.Max(result.x, localScale.z * height);
			break;
		default:
			result.x = Mathf.Max(localScale.x, localScale.z) * (radius * 2f);
			result.y = Mathf.Max(result.x, localScale.y * height);
			result.z = result.x;
			break;
		}
		return result;
	}

	private ulong GetGeometryID()
	{
		ulong num = AkSurfaceReflector.INVALID_GEOMETRY_ID;
		AkSurfaceReflector component = GetComponent<AkSurfaceReflector>();
		if ((bool)component && component.enabled)
		{
			num = component.GetID();
		}
		else
		{
			if (roomCollider == null)
			{
				roomCollider = GetComponent<Collider>();
			}
			if (roomCollider.GetType() == typeof(MeshCollider))
			{
				num = GetID();
				AkSurfaceReflector.SetGeometryFromMesh(GetComponent<MeshCollider>().sharedMesh, base.transform, num, INVALID_ROOM_ID, enableDiffraction: false, enableDiffractionOnBoundaryEdges: false, enableTriangles: false);
				previousColliderType = typeof(MeshCollider);
			}
			else if (roomCollider.GetType() == typeof(BoxCollider))
			{
				num = GetID();
				BoxCollider component2 = GetComponent<BoxCollider>();
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
				Mesh sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				gameObject.transform.position = component2.bounds.center;
				gameObject.transform.rotation = base.transform.rotation;
				Vector3 localScale = new Vector3
				{
					x = base.transform.localScale.x * component2.size.x,
					y = base.transform.localScale.y * component2.size.y,
					z = base.transform.localScale.z * component2.size.z
				};
				gameObject.transform.localScale = localScale;
				AkSurfaceReflector.SetGeometryFromMesh(sharedMesh, gameObject.transform, num, INVALID_ROOM_ID, enableDiffraction: false, enableDiffractionOnBoundaryEdges: false, enableTriangles: false);
				previousColliderType = typeof(BoxCollider);
				UnityEngine.Object.Destroy(gameObject);
			}
			else if (roomCollider.GetType() == typeof(CapsuleCollider))
			{
				num = GetID();
				CapsuleCollider component3 = GetComponent<CapsuleCollider>();
				GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
				Mesh sharedMesh2 = gameObject2.GetComponent<MeshFilter>().sharedMesh;
				gameObject2.transform.position = component3.bounds.center;
				gameObject2.transform.rotation = base.transform.rotation;
				gameObject2.transform.localScale = GetCapsuleScale(base.transform.localScale, component3.radius, component3.height, component3.direction);
				AkSurfaceReflector.SetGeometryFromMesh(sharedMesh2, gameObject2.transform, num, INVALID_ROOM_ID, enableDiffraction: false, enableDiffractionOnBoundaryEdges: false, enableTriangles: false);
				previousColliderType = typeof(CapsuleCollider);
				UnityEngine.Object.Destroy(gameObject2);
			}
			else if (roomCollider.GetType() == typeof(SphereCollider))
			{
				num = GetID();
				GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				Mesh sharedMesh3 = gameObject3.GetComponent<MeshFilter>().sharedMesh;
				gameObject3.transform.position = roomCollider.bounds.center;
				gameObject3.transform.localScale = roomCollider.bounds.size;
				AkSurfaceReflector.SetGeometryFromMesh(sharedMesh3, gameObject3.transform, num, INVALID_ROOM_ID, enableDiffraction: false, enableDiffractionOnBoundaryEdges: false, enableTriangles: false);
				previousColliderType = typeof(SphereCollider);
				UnityEngine.Object.Destroy(gameObject3);
			}
			else
			{
				if (previousColliderType == roomCollider.GetType())
				{
					return num;
				}
				Debug.LogWarning(base.name + " has an invalid collider for wet transmission. Wet Transmission will be disabled.");
				if (previousColliderType == typeof(MeshCollider) || previousColliderType == typeof(BoxCollider) || previousColliderType == typeof(SphereCollider) || previousColliderType == typeof(CapsuleCollider))
				{
					AkSoundEngine.RemoveGeometry(GetID());
				}
				previousColliderType = roomCollider.GetType();
			}
		}
		return num;
	}

	public override void OnEnable()
	{
		roomCollider = GetComponent<Collider>();
		SetRoom();
		for (int i = 0; i < roomAwareObjectsDetectedWhileDisabled.Count; i++)
		{
			AkRoomAwareManager.ObjectEnteredRoom(roomAwareObjectsDetectedWhileDisabled[i], this);
		}
		roomAwareObjectsDetectedWhileDisabled.Clear();
		base.OnEnable();
	}

	private void OnDisable()
	{
		for (int i = 0; i < roomAwareObjectsEntered.Count; i++)
		{
			roomAwareObjectsEntered[i].ExitedRoom(this);
			AkRoomAwareManager.RegisterRoomAwareObjectForUpdate(roomAwareObjectsEntered[i]);
			roomAwareObjectsDetectedWhileDisabled.Add(roomAwareObjectsEntered[i]);
		}
		roomAwareObjectsEntered.Clear();
		AkRoomManager.RegisterRoomUpdate(this);
		if (previousColliderType == typeof(MeshCollider) || previousColliderType == typeof(BoxCollider) || previousColliderType == typeof(SphereCollider) || previousColliderType == typeof(CapsuleCollider))
		{
			AkSoundEngine.RemoveGeometry(GetID());
		}
		previousColliderType = null;
		AkSoundEngine.StopAll(GetID());
		RoomCount--;
		AkSoundEngine.RemoveRoom(GetID());
	}

	private void OnTriggerEnter(Collider in_other)
	{
		AkRoomAwareManager.ObjectEnteredRoom(in_other, this);
	}

	private void OnTriggerExit(Collider in_other)
	{
		AkRoomAwareManager.ObjectExitedRoom(in_other, this);
	}

	public void PostRoomTone()
	{
		if (roomToneEvent.IsValid())
		{
			AkSoundEngine.PostEventOnRoom(roomToneEvent.Id, GetID());
		}
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
		PostRoomTone();
	}
}
