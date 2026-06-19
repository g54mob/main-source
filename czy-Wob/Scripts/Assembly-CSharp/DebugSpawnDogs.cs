using UnityEngine;

public class DebugSpawnDogs : MonoBehaviour
{
	public float initialOffset;

	public int dogNum = 10;

	public GameObject dogRef;

	private float timePassed;

	private int totalDogs;

	private float timeDelay = 0.1f;

	private float currentDelay;

	private bool needsDogs = true;

	private DogRegistration dogRegRef;

	private void Start()
	{
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		SpawnDogs();
	}

	private void Update()
	{
		if (!needsDogs)
		{
			return;
		}
		if (timePassed < initialOffset)
		{
			timePassed += Time.deltaTime;
			return;
		}
		currentDelay -= Time.deltaTime;
		if (currentDelay <= 0f)
		{
			SpawnDog();
		}
	}

	private void SpawnDogs()
	{
		currentDelay = timeDelay;
		dogRegRef.ReserveDogs(dogNum);
	}

	private void SpawnDog()
	{
		dogRegRef.RequestReservedDog(base.transform.position, base.transform.rotation);
		totalDogs++;
		if (totalDogs >= dogNum)
		{
			needsDogs = false;
			Object.Destroy(base.gameObject);
		}
		else
		{
			currentDelay = timeDelay;
		}
	}
}
