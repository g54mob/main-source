using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCreation : MonoBehaviour
{
	public bool dummy;

	public bool isCreating;

	private Coroutine creationRoutine;

	private Coroutine currentSubRoutine;

	private void Start()
	{
		if (!dummy && !isCreating)
		{
			creationRoutine = StartCoroutine(Create());
		}
	}

	private void OnDestroy()
	{
		StopCreationRoutine();
	}

	public void StopCreationRoutine()
	{
		if (currentSubRoutine != null)
		{
			StopCoroutine(currentSubRoutine);
			currentSubRoutine = null;
		}
		if (creationRoutine != null)
		{
			StopCoroutine(creationRoutine);
			creationRoutine = null;
		}
	}

	public IEnumerator Create(SaveableDog existingDog = null, bool dummyDog = false, bool playerOwned = true, bool timeslice = true, bool forceCacheThumbnails = false, SaveableDogProfile dogProfile = null, DogAge customDogAge = DogAge.NONE, float customDogAgeProgress = -1f, bool traitsAllowed = true, bool useTemporaryID = false, SaveableDogPersonality customPersonality = null, List<string> customFloraPool = null, bool isGhost = false, float? customEndOfLifeModifier = null, float? customLifeExtension = null, bool customEmptyGut = false)
	{
		if (isCreating)
		{
			yield break;
		}
		isCreating = true;
		if (dummy)
		{
			dummyDog = true;
		}
		if (dogProfile == null && CheatEngine.cheatRef.defaultDogProfile != null)
		{
			dogProfile = new SaveableDogProfile(CheatEngine.cheatRef.defaultDogProfile);
		}
		DogAI aiRef = GetComponent<DogAI>();
		DoggyBrain brainRef = GetComponent<DoggyBrain>();
		DogNoises dogNoisesRef = GetComponent<DogNoises>();
		LegController legRef = GetComponent<LegController>();
		FaceController faceRef = GetComponent<FaceController>();
		DogGeneManager dogGeneRef = GetComponent<DogGeneManager>();
		DogClothingController dogClothingRef = GetComponent<DogClothingController>();
		GhostManager ghostRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER);
		SceneManagerBase globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		DogRegistration dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		if (brainRef != null)
		{
			brainRef.PreCreate(existingDog != null, traitsAllowed, customPersonality);
			if (isGhost)
			{
				brainRef.SetIsGhost();
			}
		}
		if (playerOwned && globalComponent.GetGameMode() == GameMode.HOME)
		{
			GetComponent<DogGutController>().OnCreate(customFloraPool, customEmptyGut);
		}
		if (existingDog == null)
		{
			brainRef.GenerateEndOfLifeModifier();
		}
		if (!useTemporaryID && !playerOwned)
		{
			useTemporaryID = true;
		}
		if (isGhost)
		{
			useTemporaryID = true;
		}
		if (!dummyDog)
		{
			dogRegRef.PreRegisterDog(base.gameObject, existingDog, playerOwned, dogProfile, customDogAge, customDogAgeProgress, useTemporaryID, isGhost, customEndOfLifeModifier, customLifeExtension);
		}
		else if (forceCacheThumbnails)
		{
			ObjectRegistration.GetRegistrationScript().AssignID(base.gameObject, null, useTemporaryID);
		}
		if (legRef != null)
		{
			legRef.PreInitialize();
		}
		Vector3 originalPos = base.transform.position;
		base.transform.position = new Vector3(-10000f, -10000f, -10000f);
		if (timeslice)
		{
			SetRBGravStatus(status: false);
			yield return new WaitForEndOfFrame();
		}
		DogLooks component = GetComponent<DogLooks>();
		currentSubRoutine = StartCoroutine(component.CreateDog(isGhost));
		yield return currentSubRoutine;
		currentSubRoutine = null;
		SetRBGravStatus(status: false);
		SetCollisionStatus(status: false);
		faceRef.AssignEyes();
		faceRef.AssignMouth();
		dogNoisesRef.AssignVoiceSet();
		if (timeslice)
		{
			yield return new WaitForEndOfFrame();
		}
		if (legRef != null)
		{
			GetComponent<LegController>().Initialize();
		}
		if (forceCacheThumbnails)
		{
			currentSubRoutine = StartCoroutine(dogRegRef.CacheThumbnailForDog(base.gameObject));
			yield return currentSubRoutine;
			currentSubRoutine = null;
		}
		else if (!dummy)
		{
			if (playerOwned)
			{
				currentSubRoutine = StartCoroutine(dogRegRef.GenerateHighQualityThumbnailForDog(base.gameObject));
				yield return currentSubRoutine;
				currentSubRoutine = null;
			}
			currentSubRoutine = StartCoroutine(dogRegRef.CacheThumbnailForDog(base.gameObject, playerOwned));
			yield return currentSubRoutine;
			currentSubRoutine = null;
		}
		if (brainRef != null)
		{
			bool permanentPlayerDog = true;
			if (dummy || !playerOwned || useTemporaryID || isGhost)
			{
				permanentPlayerDog = false;
			}
			brainRef.Initialize(permanentPlayerDog);
		}
		if (legRef != null)
		{
			GetComponent<LegController>().PostInitialize();
		}
		if (aiRef != null)
		{
			aiRef.Initialize();
		}
		if (dogGeneRef != null)
		{
			dogGeneRef.Initialize();
		}
		if (dogClothingRef != null)
		{
			dogClothingRef.Initialize();
		}
		if (dogNoisesRef != null)
		{
			dogNoisesRef.GenerateSoundPalette();
		}
		if (!dummyDog)
		{
			GetComponent<RegisterTaggedObject>().ManualRegister(playerOwned);
		}
		if (playerOwned)
		{
			dogRegRef.UpdateSavedLooks(base.gameObject);
		}
		if (existingDog != null && brainRef != null)
		{
			if (existingDog.brain.requiresDeath)
			{
				brainRef.PrepareToDie(existingDog.brain.deathReason);
			}
			else if (existingDog.brain.isDead)
			{
				brainRef.Die(existingDog.brain.deathReason);
			}
		}
		base.transform.position = originalPos;
		SetRBGravStatus(status: true);
		SetCollisionStatus(status: true);
		if (!isGhost)
		{
			ghostRef.UpdateGhostCollisionsForNewDog(base.gameObject);
		}
		creationRoutine = null;
		Object.Destroy(this);
	}

	public void SetRBGravStatus(bool status)
	{
		Rigidbody[] components = GetComponents<Rigidbody>();
		foreach (Rigidbody rigidbody in components)
		{
			rigidbody.useGravity = status;
			bool flag = !status;
			if (flag)
			{
				rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			rigidbody.isKinematic = flag;
			if (!flag)
			{
				rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
		}
		components = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody2 in components)
		{
			rigidbody2.useGravity = status;
			bool flag = !status;
			if (flag)
			{
				rigidbody2.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			}
			rigidbody2.isKinematic = !status;
			if (!flag)
			{
				rigidbody2.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
		}
	}

	public void SetCollisionStatus(bool status)
	{
		Collider[] components = GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = status;
		}
		components = GetComponentsInChildren<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].enabled = status;
		}
	}
}
