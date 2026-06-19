using System.Collections.Generic;
using UnityEngine;

public class DogPositionSetter : MonoBehaviour
{
	public KeyCode keyRef;

	public List<ulong> dogList;

	private void Update()
	{
		if (Input.GetKeyDown(keyRef))
		{
			PositionDogs();
		}
	}

	private void PositionDogs()
	{
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		for (int i = 0; i < dogList.Count; i++)
		{
			PositionDog(globalComponent.GetDogFromID(dogList[i]));
		}
	}

	private void PositionDog(GameObject dogRef)
	{
		dogRef.GetComponent<BoundingBoxComponent>();
		Vector3 position = dogRef.GetComponent<LegController>().bodyFront.transform.position;
		Vector3 vector = base.transform.position - position;
		dogRef.transform.position += vector;
	}
}
