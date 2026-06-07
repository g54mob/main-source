using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
	[Serializable]
	public struct DoorController
	{
		public Transform DoorHinge;

		public float OpenDegree;

		public float ClosedDegree;

		public bool UseRot;

		public Vector3 OpenRot;

		public Vector3 ClosedRot;
	}

	public int ID;

	public DoorController[] Doors;

	[NonSerialized]
	public HashSet<Actor> Occupants = new HashSet<Actor>();

	public int Capacity;

	public bool CanGoIn = true;

	public bool CanGoOut = true;

	private bool DoorOpen;

	public float OpenAmount;

	private float DoorStart;

	public int SubAnimation;

	public static string[] AnimationStates = new string[3] { "CarOutRight", "CarOutLeft", "BusOut" };

	public static string[] AnimationInStates = new string[3] { "CarInRight", "CarInLeft", "BusIn" };

	public bool AutoCloseDoor;

	public bool WalkOut;

	public bool isSpawning;

	public float MinSpawnDelay = 1f;

	public float MaxSpawnDelay = 2f;

	public bool PositionOffset;

	public Vector2 MinOffset;

	public Vector2 MaxOffset;

	public float MinAngle;

	public float MaxAngle;

	public AudioClip DoorOpenSfx;

	public AudioClip DoorCloseSfx;

	public CarScript Parent;

	public Vector3 ClosedAngle;

	public Vector3 OpenAngle;

	public void Reset()
	{
		Occupants.Clear();
		OpenAmount = 0f;
		DoorOpen = false;
		for (int i = 0; i < Doors.Length; i++)
		{
			Doors[i].DoorHinge.localRotation = Quaternion.Euler(0f, Doors[i].ClosedDegree, 0f);
		}
	}

	private void Update()
	{
		if (DoorOpen && OpenAmount < 1f)
		{
			DoorStart -= Time.deltaTime * GameSettings.GameSpeed * 2f;
			if (DoorStart < 0f)
			{
				OpenAmount = 1f;
			}
			else
			{
				OpenAmount = 1f - DoorStart;
			}
		}
		if (!DoorOpen && OpenAmount > 0f)
		{
			DoorStart -= Time.deltaTime * GameSettings.GameSpeed * 2f;
			if (DoorStart < 0f)
			{
				if (DoorCloseSfx != null)
				{
					Parent.PlaySFX(DoorCloseSfx);
				}
				OpenAmount = 0f;
			}
			else
			{
				OpenAmount = DoorStart;
			}
		}
		for (int i = 0; i < Doors.Length; i++)
		{
			if (Doors[i].UseRot)
			{
				Doors[i].DoorHinge.localRotation = Quaternion.Lerp(Quaternion.Euler(Doors[i].ClosedRot), Quaternion.Euler(Doors[i].OpenRot), OpenAmount);
			}
			else
			{
				Doors[i].DoorHinge.localRotation = Quaternion.Euler(0f, Mathf.Lerp(Doors[i].ClosedDegree, Doors[i].OpenDegree, OpenAmount), 0f);
			}
		}
	}

	public void OpenDoor()
	{
		if (OpenAmount == 0f)
		{
			DoorStart = 1f;
			if (DoorOpenSfx != null)
			{
				Parent.PlaySFX(DoorOpenSfx);
			}
		}
		DoorOpen = true;
	}

	public void CloseDoor()
	{
		if (OpenAmount == 1f)
		{
			DoorStart = 1f;
		}
		DoorOpen = false;
	}

	public void BeginSpawn()
	{
		if (Occupants.Count > 0)
		{
			StartCoroutine(SpawnOccupants());
		}
	}

	public bool AnyActive()
	{
		foreach (Actor occupant in Occupants)
		{
			if (occupant != null && occupant.isActiveAndEnabled)
			{
				return true;
			}
		}
		return false;
	}

	private IEnumerator SpawnOccupants()
	{
		isSpawning = true;
		foreach (Actor item in Occupants.ToList())
		{
			if (item != null && (!item.isActiveAndEnabled || item.Biking))
			{
				OpenDoor();
				if (Parent.IsBike)
				{
					item.transform.SetParent(null, true);
					item.Biking = false;
				}
				if (PositionOffset)
				{
					item.transform.position = (item.ActualPosition = base.transform.position + base.transform.rotation * new Vector3(UnityEngine.Random.Range(MinOffset.x, MaxOffset.x), 0f, UnityEngine.Random.Range(MinOffset.y, MaxOffset.x)));
					item.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, UnityEngine.Random.Range(MinAngle, MaxAngle), 0f);
				}
				else
				{
					item.ActualPosition = base.transform.position;
					item.transform.rotation = base.transform.rotation;
				}
				item.enabled = true;
				item.SetVisible(true);
				item.anim.enabled = true;
				item.anim.Play(Parent.IsBike ? "OffBike" : AnimationStates[SubAnimation], 0, 0f);
				item.MeetNow();
				if (WalkOut)
				{
					item.PathProg = 0f;
					item.CurrentPathNode = 0;
					List<PathVector> list = Actor.PathPool.Get();
					list.Add(item.ActualPosition);
					list.Add(item.ActualPosition + base.transform.rotation * new Vector3(UnityEngine.Random.Range(-2f, 2f), 0f, UnityEngine.Random.Range(0f, 0.15f)));
					item.SetPath(list);
				}
				while (GameSettings.GameSpeed == 0f)
				{
					yield return new WaitForSeconds(0.1f);
				}
				yield return new WaitForSeconds(UnityEngine.Random.Range(MinSpawnDelay, MaxSpawnDelay) / GameSettings.GameSpeed);
			}
		}
		if (AutoCloseDoor)
		{
			CloseDoor();
		}
		isSpawning = false;
	}
}
