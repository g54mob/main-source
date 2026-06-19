using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnParticles : MonoBehaviour
{
	public DogRegistration dogRegRef;

	public Vector3 spawnPos;

	public bool useReservedDog;

	public GameObject existingDog;

	public GameObject existingDogToSpawn;

	public ParticleSystem particleSystemRef;

	public bool customDelay;

	public float customDelayValue;

	private string dogSpawnSound = "dog_spawn";

	private string objectSpawnSound = "object_spawn";

	private string spawnSoundOverride;

	private bool spawnNewDog;

	private SaveableDog dogToSpawn;

	private List<InventoryItem> itemsToSpawn = new List<InventoryItem>();

	private bool moveSpawnedItemsToGoodLocation;

	private bool customEmptyGut;

	private List<string> customFloraPool;

	private SaveableDogGene dogGene;

	private bool traitsAllowed = true;

	private bool isGhost;

	private bool attachToSpawnedDog;

	private float requestedDogAgeProgress = -1f;

	private DogAge requestedAge = DogAge.PUPPY;

	private SaveableDogProfile dogProfile;

	private SaveableDogPersonality dogPersonality;

	private float spawnTimer = 0.25f;

	private float currentTimer;

	private bool dogMustExist;

	private bool requestIntention;

	private bool saveGene = true;

	private ulong? expectedRoomUID;

	private ulong optionalUlong;

	private DogRequest.DogRequestCallback currentCallback;

	private DogRequest.DogRequestCallbackUlongArg currentCallbackUlongArg;

	private void Awake()
	{
		spawnPos = base.transform.position;
		if (customDelay)
		{
			spawnTimer = customDelayValue;
		}
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void OnDestroy()
	{
		if (requestIntention && dogRegRef != null)
		{
			requestIntention = false;
			dogRegRef.RemoveRequestIntention();
		}
	}

	private void Update()
	{
		if (existingDog != null)
		{
			base.gameObject.transform.position = existingDog.GetComponent<LegController>().bodyFront.transform.position;
			spawnPos = base.gameObject.transform.position;
		}
		if (currentTimer < spawnTimer)
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= spawnTimer)
			{
				if (requestIntention)
				{
					requestIntention = false;
					dogRegRef.RemoveRequestIntention();
				}
				if (dogToSpawn != null || spawnNewDog)
				{
					SpawnDog();
				}
				if (itemsToSpawn != null && itemsToSpawn.Count > 0)
				{
					SpawnItems();
				}
				if (existingDogToSpawn != null)
				{
					SpawnExistingDog();
				}
			}
		}
		if (!particleSystemRef.isPlaying)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void RegisterRequestIntention()
	{
		requestIntention = true;
		dogRegRef.AddRequestIntention();
	}

	public void SetIsGhost(bool val)
	{
		isGhost = val;
	}

	public void SetAttachToSpawnedDog()
	{
		attachToSpawnedDog = true;
	}

	public void SetTraitsAllowed(bool val)
	{
		traitsAllowed = val;
	}

	public void SetSpawnSoundOverride(string newSound)
	{
		spawnSoundOverride = newSound;
	}

	public void SetSaveGene(bool newVal)
	{
		saveGene = newVal;
	}

	public void SetSpawnCallback(DogRequest.DogRequestCallback callback)
	{
		currentCallback = callback;
	}

	public void SetSpawnCallback(DogRequest.DogRequestCallbackUlongArg callback, ulong ulongValue)
	{
		optionalUlong = ulongValue;
		currentCallbackUlongArg = callback;
	}

	public void SetExistingDog(GameObject newDog)
	{
		existingDog = newDog;
	}

	public void RequireDogExists()
	{
		dogMustExist = true;
	}

	public void SetExistingDogToSpawn(GameObject newDog)
	{
		existingDogToSpawn = newDog;
	}

	public void SetContainedDog(SaveableDog newDog)
	{
		dogToSpawn = newDog;
	}

	public void SetContainedItem(InventoryItem newItem)
	{
		itemsToSpawn.Add(newItem);
	}

	public void SetMoveItemsToGoodLocation(bool val)
	{
		moveSpawnedItemsToGoodLocation = val;
	}

	public void SetSpawnNewDog()
	{
		spawnNewDog = true;
	}

	public void SetFloraPool(List<string> newFloraPool)
	{
		customFloraPool = newFloraPool;
	}

	public void SetEmptyGut(bool newVal)
	{
		customEmptyGut = newVal;
	}

	public void SetDogGene(SaveableDogGene newGene)
	{
		dogGene = newGene;
	}

	public void SetDogAge(DogAge newAge)
	{
		requestedAge = newAge;
		requestedDogAgeProgress = 0f;
	}

	public void SetDogProfile(SaveableDogProfile newProfile)
	{
		dogProfile = newProfile;
	}

	public void SetDogPersonality(SaveableDogPersonality newPersonality)
	{
		dogPersonality = newPersonality;
	}

	public void SetExpectedRoom(ulong? newRoomUID)
	{
		expectedRoomUID = newRoomUID;
	}

	private void SpawnDog()
	{
		if (dogMustExist && existingDog == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (existingDog != null)
		{
			dogRegRef.SaveDog(existingDog, inWorld: true, inCocoon: false, saveGene);
			dogRegRef.ClearCachedThumbnailsForDog(existingDog);
			DogRegistration.SafeDestroy(existingDog);
		}
		if (useReservedDog)
		{
			dogRegRef.RequestReservedDog(spawnPos, Quaternion.identity, null, dogToSpawn, DogCreationCallback);
		}
		else if (spawnNewDog)
		{
			if (dogGene != null)
			{
				dogRegRef.RequestNewDog(spawnPos, Quaternion.identity, dogGene, null, manualDog: false, DogCreationCallback, playerOwned: true, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, dogProfile, customDogPersonality: dogPersonality, customDogAge: requestedAge, customDogAgeProgress: requestedDogAgeProgress, traitsAllowed: traitsAllowed, useTemporaryID: false, customFloraPool: customFloraPool, respectMaxDogs: true, isGhost: isGhost, customEndOfLifeModifier: null, customLifeExtension: null, spawnDuringPause: true, customEmptyGut: customEmptyGut);
			}
			else
			{
				dogRegRef.RequestNewDog(spawnPos, Quaternion.identity, null, null, manualDog: false, DogCreationCallback, playerOwned: true, useBaseGeneWithoutMutation: true, timeslice: true, forceCacheThumbnails: false, dummyDog: false, dogProfile, customDogPersonality: dogPersonality, customDogAge: requestedAge, customDogAgeProgress: requestedDogAgeProgress, traitsAllowed: traitsAllowed, useTemporaryID: false, customFloraPool: customFloraPool, respectMaxDogs: true, isGhost: isGhost, customEndOfLifeModifier: null, customLifeExtension: null, spawnDuringPause: true, customEmptyGut: customEmptyGut);
			}
		}
		else
		{
			dogRegRef.RequestNewDog(spawnPos, Quaternion.identity, null, dogToSpawn, manualDog: false, DogCreationCallback, playerOwned: true, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, null, DogAge.NONE, -1f, traitsAllowed, useTemporaryID: false, null, customFloraPool, respectMaxDogs: true, isGhost, null, null, spawnDuringPause: true, customEmptyGut);
		}
		dogToSpawn = null;
	}

	private void SpawnItems()
	{
		for (int i = 0; i < itemsToSpawn.Count; i++)
		{
			SpawnItem(itemsToSpawn[i]);
		}
		itemsToSpawn.Clear();
		string text = objectSpawnSound;
		if (spawnSoundOverride != null)
		{
			text = spawnSoundOverride;
		}
		if (text.Length > 0)
		{
			AudioController.Play(text, spawnPos);
		}
	}

	private void SpawnItem(InventoryItem itemToSpawn)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(itemToSpawn.itemPrefab);
		gameObject.transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
		ObjectRegistration.GetRegistrationScript().AssignID(gameObject, itemToSpawn);
		if (moveSpawnedItemsToGoodLocation)
		{
			BoundingBoxComponent boundingBoxComponent = gameObject.GetComponent<BoundingBoxComponent>();
			if (boundingBoxComponent == null)
			{
				boundingBoxComponent = gameObject.AddComponent<BoundingBoxComponent>();
			}
			boundingBoxComponent.MoveToGoodLocation();
		}
		if (currentCallback != null)
		{
			currentCallback(gameObject);
			currentCallback = null;
		}
		else if (currentCallbackUlongArg != null)
		{
			currentCallbackUlongArg(gameObject, optionalUlong);
			currentCallbackUlongArg = null;
		}
	}

	private void SpawnExistingDog()
	{
		existingDogToSpawn.transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
		existingDogToSpawn.SetActive(value: true);
		if (!existingDogToSpawn.GetComponent<BoundingBoxComponent>().MoveToGoodLocation(expectedRoomUID))
		{
			dogRegRef.SaveDog(existingDogToSpawn, inWorld: false);
			UnityEngine.Object.Destroy(existingDogToSpawn);
			Debug.LogError("Couldn't find valid location for existing spawned dog!");
			return;
		}
		if (currentCallback != null)
		{
			currentCallback(existingDogToSpawn);
			currentCallback = null;
		}
		else if (currentCallbackUlongArg != null)
		{
			currentCallbackUlongArg(existingDogToSpawn, optionalUlong);
			currentCallbackUlongArg = null;
		}
		existingDogToSpawn = null;
	}

	private void DogCreationCallback(GameObject newDog)
	{
		try
		{
			if (currentCallback != null)
			{
				currentCallback(newDog);
				currentCallback = null;
			}
			else if (currentCallbackUlongArg != null)
			{
				currentCallbackUlongArg(newDog, optionalUlong);
				currentCallbackUlongArg = null;
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		if (newDog == null)
		{
			Debug.LogError("Could not spawn dog.");
			return;
		}
		Vector3 position = newDog.transform.position;
		if (!newDog.GetComponent<BoundingBoxComponent>().MoveToGoodLocation(expectedRoomUID))
		{
			dogRegRef.SaveDog(newDog, inWorld: false);
			UnityEngine.Object.Destroy(newDog);
			Debug.LogError("Couldn't find valid location for aged up dog!");
			return;
		}
		if (attachToSpawnedDog && this != null)
		{
			base.transform.position += position - newDog.transform.position;
		}
		string text = dogSpawnSound;
		if (spawnSoundOverride != null)
		{
			text = spawnSoundOverride;
		}
		if (text.Length > 0)
		{
			AudioController.Play(text, newDog.GetComponent<LegController>().bodyFront.transform.position);
		}
	}
}
