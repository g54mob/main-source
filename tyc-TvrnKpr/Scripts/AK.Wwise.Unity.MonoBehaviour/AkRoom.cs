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
				return 0;
			}
		}

		private static readonly CompareByPriority s_compareByPriority;

		private List<AkRoom> rooms;

		public int Count => 0;

		public AkRoom this[int index] => null;

		public ulong GetHighestPriorityActiveAndEnabledRoomID()
		{
			return 0uL;
		}

		public AkRoom GetHighestPriorityActiveAndEnabledRoom()
		{
			return null;
		}

		public void Clear()
		{
		}

		public void Add(AkRoom room)
		{
		}

		public void Remove(AkRoom room)
		{
		}

		public bool Contains(AkRoom room)
		{
			return false;
		}

		public int BinarySearch(AkRoom room)
		{
			return 0;
		}
	}

	public struct OutdoorsRoomParameters
	{
		public AuxBus reverbAuxBus;

		public float reverbLevel;

		public float transmissionLoss;

		public float auxSendLevel;

		public bool keepRegistered;

		public static OutdoorsRoomParameters Default => default(OutdoorsRoomParameters);

		public OutdoorsRoomParameters(AuxBus in_reverbAuxBus, float in_reverbLevel, float in_transmissionLoss, float in_auxSendLevel, bool in_keepRegistered)
		{
			reverbAuxBus = null;
			reverbLevel = 0f;
			transmissionLoss = 0f;
			auxSendLevel = 0f;
			keepRegistered = false;
		}
	}

	public static ulong INVALID_ROOM_ID;

	[Tooltip("Higher number has a higher priority")]
	public int priority;

	public AuxBus reverbAuxBus;

	[Range(0f, 1f)]
	public float reverbLevel;

	[Range(0f, 1f)]
	public float transmissionLoss;

	public Event roomToneEvent;

	[Range(0f, 1f)]
	[Tooltip("Send level for sounds that are posted on the room game object; adds reverb to ambience and room tones. Valid range: (0.f-1.f). A value of 0 disables the aux send.")]
	public float roomToneAuxSend;

	private List<AkRoomAwareObject> roomAwareObjectsEntered;

	private List<AkRoomAwareObject> roomAwareObjectsDetectedWhileDisabled;

	private Collider roomCollider;

	private int previousRoomState;

	private int previousTransformState;

	private int previousGeometryState;

	private bool bSentToWwise;

	private bool isSolid;

	private ulong geometryID;

	private bool bGeometrySetByRoom;

	private bool _isAReverbZoneInWwise;

	private ulong _parentRoomID;

	private static ulong INVALID_ROOM_GAMEOBJECT_ID;

	private static OutdoorsRoomParameters _currentOutdoorsRoomParameters;

	public static int RoomCount { get; private set; }

	public bool IsAReverbZoneInWwise => false;

	public ulong ParentRoomID => 0uL;

	public static OutdoorsRoomParameters currentOutdoorsRoomParameters => default(OutdoorsRoomParameters);

	[Obsolete("This functionality is deprecated as of Wwise v2021.1.0 and will be removed in a future release.")]
	public float wallOcclusion
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static ulong GetAkRoomID(AkRoom room)
	{
		return 0uL;
	}

	private int GetRoomState()
	{
		return 0;
	}

	private int GetTransformState()
	{
		return 0;
	}

	private int GetGeometryState()
	{
		return 0;
	}

	public bool TryEnter(AkRoomAwareObject roomAwareObject)
	{
		return false;
	}

	public void Exit(AkRoomAwareObject roomAwareObject)
	{
	}

	public ulong GetID()
	{
		return 0uL;
	}

	public bool IsAssociatedGeometryFromCollider()
	{
		return false;
	}

	private void SetGeometryFromCollider()
	{
	}

	private void SetGeometryInstanceFromCollider()
	{
	}

	public void SetRoom()
	{
	}

	public void SetRoom(ulong id)
	{
	}

	public bool UsesGeometry(ulong id)
	{
		return false;
	}

	private void Update()
	{
	}

	private Vector3 GetCubeScaleFromCapsule(Vector3 capsuleScale, float capsuleRadius, float capsuleHeight, int capsuleDirection)
	{
		return default(Vector3);
	}

	public override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnDestroy()
	{
	}

	private void OnTriggerEnter(Collider in_other)
	{
	}

	private void OnTriggerExit(Collider in_other)
	{
	}

	public void PostRoomTone()
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}

	public void SetReverbZone(AkRoom parentRoom, float transitionRegionWidth)
	{
	}

	public void RemoveReverbZone()
	{
	}

	public static void SetOutdoorsRoomParameters(OutdoorsRoomParameters in_outdoorsRoomParameters)
	{
	}

	public static uint PostEventOutdoors(Event in_event)
	{
		return 0u;
	}

	public static void StopOutdoors()
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2023.1.0 and will be removed in a future release.")]
	public ulong GetGeometryID()
	{
		return 0uL;
	}

	[Obsolete("This functionality is deprecated as of Wwise v2023.1.0 and will be removed in a future release.")]
	public void SetGeometryID(ulong id)
	{
	}
}
