using System.Collections.Generic;
using UnityEngine;

public class TooManyEggsEvent : InGameEvent
{
	public GameObject chosenDog;

	private int eggOverrideValueLow = 1;

	private int eggOverrideValueHigh = 15;

	public override void Update()
	{
		base.Update();
	}

	public override void RunEvent(EventController controllerRef)
	{
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		List<GameObject> objects = globalComponent.GetAllInWorldOwnedDogs();
		ListUtil.ShuffleList(ref objects);
		for (int i = 0; i < objects.Count; i++)
		{
			GameObject dog = objects[i];
			if (globalComponent.GetSaveableDogFromDog(dog).brain.dogAge == DogAge.ADULT)
			{
				chosenDog = dog;
				chosenDog.GetComponent<DogEggLayingController>().SetEggOverride(Random.Range(eggOverrideValueLow, eggOverrideValueHigh));
				break;
			}
		}
	}

	public override void StopEvent()
	{
	}
}
