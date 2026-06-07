using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkRoomAwareObject")]
[RequireComponent(typeof(AkGameObj))]
[DisallowMultipleComponent]
public class AkRoomAwareObject : MonoBehaviour
{
	private static readonly Dictionary<Collider, AkRoomAwareObject> ColliderToRoomAwareObjectMap;

	public Collider m_Collider;

	private readonly AkRoom.PriorityList roomPriorityList;

	public static AkRoomAwareObject GetAkRoomAwareObjectFromCollider(Collider collider)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetGameObjectInHighestPriorityActiveAndEnabledRoom()
	{
	}

	private void SetGameObjectInRoom(AkRoom room)
	{
	}

	public void EnteredRoom(AkRoom room)
	{
	}

	public void ExitedRoom(AkRoom room)
	{
	}
}
