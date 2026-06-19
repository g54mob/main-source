using System.Collections.Generic;
using UnityEngine;

public class DogBed : InteractableBase
{
	public int maximumDogs = 1;

	private List<ulong> containedDogs = new List<ulong>();

	private DogRegistration dogRegRef;

	private void Start()
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	public void AddDog(GameObject dog)
	{
		if (!CanAddDog())
		{
			Debug.LogError("Attempting to add a dog to a dog bed but the bed is already at maximum capacity.");
			return;
		}
		OnDogEnter(dog);
		containedDogs.Add(dogRegRef.GetIDFromDog(dog));
	}

	public void RemoveDog(GameObject dog)
	{
		ulong iDFromDog = dogRegRef.GetIDFromDog(dog);
		if (!containedDogs.Contains(iDFromDog))
		{
			Debug.LogError("Attempting to remove dog " + iDFromDog + " from a dog bed but it doesn't appear to be inside.");
			return;
		}
		OnDogExit(dog);
		containedDogs.Remove(iDFromDog);
	}

	public bool CanAddDog()
	{
		return containedDogs.Count < maximumDogs;
	}

	private void OnDogEnter(GameObject dog)
	{
		dog.GetComponent<SleepBehavior>().RequestSleep();
	}

	private void OnDogExit(GameObject dog)
	{
		dog.GetComponent<SleepBehavior>().RequestWakeUp();
	}
}
