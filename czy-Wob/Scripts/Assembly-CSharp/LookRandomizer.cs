using System.Collections;
using UnityEngine;

public class LookRandomizer : MonoBehaviour
{
	public GameObject lastDog;

	public GameObject dogPrefab;

	public bool rapidFire;

	private bool waitingForRequest;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void Update()
	{
		if ((Input.GetKeyDown(KeyCode.R) || rapidFire) && !waitingForRequest)
		{
			waitingForRequest = true;
			dogRegRef.RequestNewDog(base.transform.position, base.transform.localRotation, null, null, manualDog: false, DogCreationCallback);
		}
	}

	private void DogCreationCallback(GameObject newDog)
	{
		if (lastDog != null)
		{
			Object.Destroy(lastDog);
		}
		lastDog = newDog;
		lastDog.GetComponent<LegController>().bodyFront.GetComponent<Rigidbody>().isKinematic = true;
		lastDog.GetComponent<LegController>().bodyBack.GetComponent<Rigidbody>().isKinematic = true;
		StartCoroutine(RequestRoutine());
	}

	private IEnumerator RequestRoutine()
	{
		yield return new WaitForEndOfFrame();
		waitingForRequest = false;
	}
}
