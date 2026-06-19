using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMachine : MonoBehaviour
{
	public GameObject capsuleBlocker;

	public GameObject capsuleSpawner;

	public GameObject suctionPoint;

	public GameObject expulsionTrigger;

	public GameObject agitationRod;

	public GameObject capsulePrefab;

	public static float agitationTurnRate = 25f;

	private float capsuleSpawnRate = 0.1f;

	private float currentSpawnRate;

	private Coroutine expelRoutine;

	private List<GameObject> capsulesToSpawn = new List<GameObject>();

	private List<GameObject> containedCapsules = new List<GameObject>();

	private DogRegistration dogRegRef;

	private InventoryManager invManagerRef;

	private void Awake()
	{
		expulsionTrigger.GetComponent<CapsuleExpulsionTrigger>().Initialize(this);
		expulsionTrigger.GetComponent<MeshRenderer>().enabled = false;
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		invManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
	}

	private void FixedUpdate()
	{
		AgitateCapsules();
	}

	private void Update()
	{
		SpawnCapsules();
	}

	public bool ContainsCapsules()
	{
		return containedCapsules.Count > 0;
	}

	public void OnCrankClicked()
	{
		if (expelRoutine != null)
		{
			StopCoroutine(expelRoutine);
			OnExpelFinished();
		}
		else if (containedCapsules.Count == 0)
		{
			OnExpelFinished();
		}
		else
		{
			expelRoutine = StartCoroutine(ExpelCapsules());
		}
	}

	public void SpawnDogCapsule()
	{
		dogRegRef.RequestNewDog(Vector3.zero, Quaternion.identity, null, null, manualDog: false, DogCreationCallback);
	}

	private void DogCreationCallback(GameObject newDog)
	{
		SaveableDog saveableDogFromDog = dogRegRef.GetSaveableDogFromDog(newDog);
		SpawnCapsule(null, saveableDogFromDog);
		Object.Destroy(newDog);
	}

	public void SpawnCapsule(InventoryItem containedObject = null, SaveableDog containedDog = null)
	{
		containedCapsules.Add(Object.Instantiate(capsulePrefab, capsuleSpawner.transform.position, Quaternion.identity));
		containedCapsules[containedCapsules.Count - 1].GetComponent<Capsule>().SetContainedDog(containedDog);
		containedCapsules[containedCapsules.Count - 1].SetActive(value: false);
		capsulesToSpawn.Add(containedCapsules[containedCapsules.Count - 1]);
	}

	public void OnCapsuleExpulled(GameObject capsule)
	{
		if (containedCapsules.Contains(capsule))
		{
			containedCapsules.Remove(capsule);
		}
	}

	private void SpawnCapsules()
	{
		if (capsulesToSpawn.Count != 0)
		{
			currentSpawnRate += Time.deltaTime;
			if (!(currentSpawnRate < capsuleSpawnRate))
			{
				capsulesToSpawn[0].SetActive(value: true);
				capsulesToSpawn.RemoveAt(0);
				currentSpawnRate = 0f;
			}
		}
	}

	private IEnumerator ExpelCapsules()
	{
		capsuleBlocker.SetActive(value: false);
		while (containedCapsules.Count > 0)
		{
			yield return new WaitForSeconds(0.1f);
		}
		OnExpelFinished();
		yield return 0;
	}

	private void OnExpelFinished()
	{
		expelRoutine = null;
		capsuleBlocker.SetActive(value: true);
	}

	private void AgitateCapsules()
	{
		if (expelRoutine != null)
		{
			agitationRod.transform.Rotate(Vector3.up, agitationTurnRate * Time.fixedDeltaTime);
		}
	}
}
