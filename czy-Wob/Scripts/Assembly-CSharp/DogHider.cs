using System.Collections.Generic;
using UnityEngine;

public static class DogHider
{
	public static List<ulong> currentlyHiddenDogs = new List<ulong>();

	public static Dictionary<ulong, Vector3> hiddenDogOriginalPositions = new Dictionary<ulong, Vector3>();

	public static DogRegistration dogRegRef;

	private static Vector3 spacing = new Vector3(10f, 10f, 10f);

	private static Vector3 startingHideLocation = new Vector3(10000f, 10000f, 10000f);

	public static bool IsDogHidden(GameObject dog)
	{
		GetRefs();
		ulong iDFromDog = dogRegRef.GetIDFromDog(dog);
		if (currentlyHiddenDogs.Contains(iDFromDog))
		{
			return true;
		}
		return false;
	}

	public static void HideDog(ulong dogID)
	{
		GetRefs();
		if (currentlyHiddenDogs.Contains(dogID))
		{
			return;
		}
		GameObject dogFromID = dogRegRef.GetDogFromID(dogID);
		if (!(dogFromID == null))
		{
			PenFocus component = Camera.main.GetComponent<PenFocus>();
			if (component.IsCameraFollowingObject(dogFromID))
			{
				component.ClearFollowCam();
			}
			currentlyHiddenDogs.Add(dogID);
			hiddenDogOriginalPositions[dogID] = dogFromID.transform.position;
			dogFromID.GetComponent<OOBDestroy>().SetDestroyFlag(flag: false);
			Rigidbody[] componentsInChildren = dogFromID.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody obj in componentsInChildren)
			{
				obj.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
				obj.isKinematic = true;
			}
			dogFromID.transform.position = startingHideLocation;
			SpaceDogs();
		}
	}

	public static void UnhideDog(ulong dogID)
	{
		if (!currentlyHiddenDogs.Contains(dogID))
		{
			return;
		}
		GameObject dogFromID = dogRegRef.GetDogFromID(dogID);
		if (!(dogFromID == null))
		{
			dogFromID.transform.position = hiddenDogOriginalPositions[dogID];
			Rigidbody[] componentsInChildren = dogFromID.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody obj in componentsInChildren)
			{
				obj.isKinematic = false;
				obj.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
			dogFromID.GetComponent<OOBDestroy>().SetDestroyFlag(flag: true);
			currentlyHiddenDogs.Remove(dogID);
			hiddenDogOriginalPositions.Remove(dogID);
			SpaceDogs();
		}
	}

	private static void GetRefs()
	{
		if (!(dogRegRef != null))
		{
			dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
	}

	private static void SpaceDogs()
	{
		for (int i = 0; i < currentlyHiddenDogs.Count; i++)
		{
			dogRegRef.GetDogFromID(currentlyHiddenDogs[i]).transform.position = startingHideLocation + spacing * i;
		}
	}
}
