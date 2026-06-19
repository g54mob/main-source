using System.Collections;
using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class DogDen : MonoBehaviour
{
	public delegate void DenCallback();

	public GameObject stageEmpty;

	public GameObject stageCleared;

	public GameObject stage_1;

	public GameObject denUpgradeNone;

	public GameObject denUpgradeWD;

	public GameObject denUpgradeSpooky;

	public GameObject denUpgradeSpacelab;

	public GameObject denUpgradeSuburban;

	public GameObject denUpgradeJungle;

	public GameObject denUpgradeRocky;

	public GameObject denUpgradeSnowy;

	public GameObject denUpgradeFish;

	public GameObject denUpgradeGrocery;

	public GameObject denUpgradeDesert;

	public GameObject denUpgradeBasement;

	public GameObject denInteriorPrefab;

	public GameObject denCreatedParticles;

	public GameObject denCreatedParticlesSnow;

	public GameObject denUpgradeParticles;

	public GameObject constructionParticles;

	public GameObject dirtCollectedParticles;

	public GameObject snowCollectedParticles;

	public GameObject denUpgradeGUIPrefab;

	public GameObject dirtPatch_1;

	public GameObject snowPatch_1;

	public GameObject dirtPatch_2;

	public GameObject snowPatch_2;

	public GameObject worldMessagePrefab;

	private string dirtCollectedMessage = "+1";

	private Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private DenStage currentStage;

	private bool isSnowy;

	private int maxOccupants = 2;

	private List<ulong> currentOccupants = new List<ulong>();

	private DogDenInterior instantiatedInteriorRef;

	private DenUpgradeType currentUpgradeType;

	private Coroutine currentUpgradeRoutine;

	private int dirtClumps;

	private int requiredDirtClumps = 20;

	private float goofBoredomFromExpel = 0.2f;

	private float layaboutStressFromExpel = -0.15f;

	private bool isBeingFinalized;

	private bool destroyFunctionalityRun;

	private bool markedForDestroyFromTravel;

	private Coroutine currentExpelRoutine;

	private AudioObject digAudioObject;

	private string denConstructionStartedSound = "denConstruction_start";

	private string denInProgressSound = "denConstruction_loop";

	private string denCreatedSound = "denConstruction_end";

	private string denUpgradeSound = "dogDen_Upgrade";

	private string dirtCollectSound = "dirt_collect";

	private GameObject dogClearingArea;

	private Coroutine activeClearAreaRoutine;

	private GameObject instantiatedConstructionParticles;

	private DogRegistration dogRegRef;

	private BoundingBoxComponent bbcRef;

	private InteractibleDogDen interactibleDogDenRef;

	private void Awake()
	{
		denUpgradeNone.SetActive(value: true);
		denUpgradeWD.SetActive(value: false);
		denUpgradeSpooky.SetActive(value: false);
		denUpgradeSpacelab.SetActive(value: false);
		denUpgradeSuburban.SetActive(value: false);
		denUpgradeJungle.SetActive(value: false);
		denUpgradeRocky.SetActive(value: false);
		denUpgradeSnowy.SetActive(value: false);
		denUpgradeFish.SetActive(value: false);
		denUpgradeGrocery.SetActive(value: false);
		denUpgradeDesert.SetActive(value: false);
		denUpgradeBasement.SetActive(value: false);
		dirtPatch_1.SetActive(value: true);
		snowPatch_1.SetActive(value: false);
		dirtPatch_2.SetActive(value: true);
		snowPatch_2.SetActive(value: false);
		ClearStages();
		SetStage(currentStage);
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		bbcRef = GetComponent<BoundingBoxComponent>();
		if (bbcRef == null)
		{
			bbcRef = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
		interactibleDogDenRef = GetComponent<InteractibleDogDen>();
	}

	public void MarkForTravel()
	{
		markedForDestroyFromTravel = true;
	}

	public void PreDestroy()
	{
		DestroyFunctionality();
	}

	private void OnDestroy()
	{
		DestroyFunctionality();
	}

	private void DestroyFunctionality()
	{
		if (destroyFunctionalityRun)
		{
			return;
		}
		destroyFunctionalityRun = true;
		if (currentExpelRoutine != null)
		{
			StopCoroutine(currentExpelRoutine);
			currentExpelRoutine = null;
		}
		if (activeClearAreaRoutine != null)
		{
			StopCoroutine(activeClearAreaRoutine);
			OnClearAreaRoutineFinished(fromDestroy: true);
		}
		if (currentUpgradeRoutine != null)
		{
			StopCoroutine(currentUpgradeRoutine);
			currentUpgradeRoutine = null;
		}
		PlacedObjectID component = GetComponent<PlacedObjectID>();
		if (component != null)
		{
			DogDenManager.RemoveDen(component.GetUID());
			if (instantiatedInteriorRef != null)
			{
				DenInteriorManager.DestroyDenInterior(component.GetUID(), bbcRef, markedForDestroyFromTravel);
			}
		}
		if (digAudioObject != null)
		{
			digAudioObject.Stop();
			digAudioObject = null;
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.boolList.Add(isSnowy);
		saveableObject.intList.Add((int)currentStage);
		saveableObject.intList.Add(dirtClumps);
		saveableObject.intList.Add(-1);
		if (!(instantiatedInteriorRef == null))
		{
			saveableObject.intList[2] = DenInteriorManager.GetInteriorIndexForDen(base.gameObject);
			saveableObject.intList.Add(instantiatedInteriorRef.expansions.currentExpansionStage);
			saveableObject.intList.Add((int)currentUpgradeType);
		}
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		ClearStages();
		if (saveableObject.boolList != null && saveableObject.boolList.Count > 0)
		{
			isSnowy = saveableObject.boolList[0];
		}
		if (saveableObject.intList[2] >= 0)
		{
			SetStage((DenStage)saveableObject.intList[0], saveableObject.intList[2]);
		}
		else
		{
			SetStage((DenStage)saveableObject.intList[0]);
		}
		dirtClumps = saveableObject.intList[1];
		if (instantiatedInteriorRef != null)
		{
			instantiatedInteriorRef.expansions.SetExpansionStage(saveableObject.intList[3]);
		}
		if (saveableObject.intList.Count > 4)
		{
			ApplyDenUpgrade((DenUpgradeType)saveableObject.intList[4], fromLoad: true);
		}
		if (isSnowy)
		{
			dirtPatch_1.SetActive(value: false);
			snowPatch_1.SetActive(value: true);
			dirtPatch_2.SetActive(value: false);
			snowPatch_2.SetActive(value: true);
		}
		else
		{
			dirtPatch_1.SetActive(value: true);
			snowPatch_1.SetActive(value: false);
			dirtPatch_2.SetActive(value: true);
			snowPatch_2.SetActive(value: false);
		}
		DogDenManager.RegisterDen(GetComponent<PlacedObjectID>().GetUID());
	}

	public bool GetIsSnowy()
	{
		return isSnowy;
	}

	public void SetIsSnowy(bool val)
	{
		isSnowy = val;
		if (isSnowy)
		{
			dirtPatch_1.SetActive(value: false);
			snowPatch_1.SetActive(value: true);
			dirtPatch_2.SetActive(value: false);
			snowPatch_2.SetActive(value: true);
		}
		else
		{
			dirtPatch_1.SetActive(value: true);
			snowPatch_1.SetActive(value: false);
			dirtPatch_2.SetActive(value: true);
			snowPatch_2.SetActive(value: false);
		}
	}

	public void OpenUpgradeUI()
	{
		Object.Instantiate(denUpgradeGUIPrefab).GetComponent<DenUpgradeGUIController>().SetDogDenRef(this);
	}

	public DenUpgradeType GetCurrentDenUpgrade()
	{
		return currentUpgradeType;
	}

	public void ApplyDenUpgrade(DenUpgradeType newUpgradeType, bool fromLoad = false)
	{
		if (newUpgradeType == DenUpgradeType.SNOWY)
		{
			SetIsSnowy(val: true);
		}
		else
		{
			SetIsSnowy(val: false);
		}
		if (fromLoad || newUpgradeType == currentUpgradeType)
		{
			GetObjectForUpgradeType(currentUpgradeType).SetActive(value: false);
			GetObjectForUpgradeType(newUpgradeType).SetActive(value: true);
			currentUpgradeType = newUpgradeType;
		}
		else
		{
			currentUpgradeRoutine = StartCoroutine(DenUpgradeRoutine(newUpgradeType));
		}
	}

	private IEnumerator DenUpgradeRoutine(DenUpgradeType newUpgradeType)
	{
		DenUpgradeType oldType = currentUpgradeType;
		currentUpgradeType = newUpgradeType;
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		GameObject gameObject = Object.Instantiate(denUpgradeParticles, component.GetBoxCenter(), Quaternion.identity);
		gameObject.transform.localScale = base.transform.localScale;
		for (int num = gameObject.transform.childCount - 1; num >= 0; num--)
		{
			gameObject.transform.GetChild(num).SetParent(null);
		}
		AudioController.Play(denUpgradeSound, component.GetBoxCenter());
		yield return new WaitForSeconds(0.15f);
		GetObjectForUpgradeType(oldType).SetActive(value: false);
		GetObjectForUpgradeType(newUpgradeType).SetActive(value: true);
		currentUpgradeRoutine = null;
	}

	public GameObject GetObjectForUpgradeType(DenUpgradeType upgradeType)
	{
		switch (upgradeType)
		{
		case DenUpgradeType.NONE:
			return denUpgradeNone;
		case DenUpgradeType.JUNGLE:
			return denUpgradeJungle;
		case DenUpgradeType.ROCKY:
			return denUpgradeRocky;
		case DenUpgradeType.SPACELAB:
			return denUpgradeSpacelab;
		case DenUpgradeType.SPOOKY:
			return denUpgradeSpooky;
		case DenUpgradeType.SUBURBAN:
			return denUpgradeSuburban;
		case DenUpgradeType.WOBBLEDOGS:
			return denUpgradeWD;
		case DenUpgradeType.SNOWY:
			return denUpgradeSnowy;
		case DenUpgradeType.FISH:
			return denUpgradeFish;
		case DenUpgradeType.GROCERY:
			return denUpgradeGrocery;
		case DenUpgradeType.DESERT:
			return denUpgradeDesert;
		case DenUpgradeType.BASEMENT:
			return denUpgradeBasement;
		default:
			Debug.LogError("No upgrade found for upgrade type: " + upgradeType);
			return stage_1;
		}
	}

	public int GetNumberOfCurrentOccupants()
	{
		return currentOccupants.Count;
	}

	public int GetDirtClumpCount()
	{
		return dirtClumps;
	}

	public int GetRequiredDirtClumpCount()
	{
		return requiredDirtClumps;
	}

	public bool CanFinalize()
	{
		if (isBeingFinalized)
		{
			return false;
		}
		if (currentStage == DenStage.CLEARED && dirtClumps >= requiredDirtClumps)
		{
			return true;
		}
		return false;
	}

	public DenStage GetCurrentDenStage()
	{
		return currentStage;
	}

	public bool CanBeMovedManually()
	{
		return IsCompleted();
	}

	public bool CanAddOccupant()
	{
		int num = 0;
		if (instantiatedInteriorRef != null)
		{
			num = instantiatedInteriorRef.GetAdditionalCapacity();
		}
		return currentOccupants.Count < maxOccupants + num;
	}

	public void AddOccupant(GameObject dog)
	{
		ulong iDFromDog = dogRegRef.GetIDFromDog(dog);
		if (currentOccupants.Contains(iDFromDog))
		{
			Debug.LogError(string.Concat("Attempting to double-add dog: ", dog, " to den!"));
			return;
		}
		if (currentOccupants.Count >= maxOccupants)
		{
			Debug.LogWarning("Too many dogs in den: " + base.gameObject);
		}
		currentOccupants.Add(iDFromDog);
	}

	public void RemoveOccupant(ulong dogID)
	{
		if (!currentOccupants.Contains(dogID))
		{
			Debug.LogError("Attempting to remove occupant: " + dogID + " from den, but it isn't listed as being inside");
		}
		else
		{
			currentOccupants.Remove(dogID);
		}
	}

	public void ExpelDogs()
	{
		for (int num = currentOccupants.Count - 1; num >= 0; num--)
		{
			GameObject dogFromID = dogRegRef.GetDogFromID(currentOccupants[num]);
			ExpelDog(dogFromID);
		}
		currentOccupants.Clear();
	}

	public void ExpelDog(GameObject dog)
	{
		Vector3 position = interactibleDogDenRef.GetInteractionPointTransform().position;
		dog.GetComponent<DogDenController>().ExitDen();
		LegController component = dog.GetComponent<LegController>();
		List<LegStructure> allLegStructures = component.GetAllLegStructures();
		for (int i = 0; i < allLegStructures.Count; i++)
		{
			allLegStructures[i].limb.ForceGiveOut();
		}
		Rigidbody component2 = component.bodyFront.GetComponent<Rigidbody>();
		Rigidbody component3 = component.bodyBack.GetComponent<Rigidbody>();
		component2.AddExplosionForce(30000f, position, 0f, 5f);
		component3.AddExplosionForce(30000f, position, 0f, 5f);
		DoggyBrain component4 = dog.GetComponent<DoggyBrain>();
		switch (component4.GetPersonality().GetEnergyPersonality())
		{
		case EnergyPersonalityType.GOOF:
			component4.UpdateBoredom(goofBoredomFromExpel);
			break;
		case EnergyPersonalityType.LAYABOUT:
			component4.UpdateStress(layaboutStressFromExpel);
			break;
		}
	}

	public void ExpelAllObjects()
	{
		if (currentExpelRoutine != null)
		{
			StopCoroutine(currentExpelRoutine);
			currentExpelRoutine = null;
		}
		currentExpelRoutine = StartCoroutine(ExpelRoutine());
	}

	private IEnumerator ExpelRoutine()
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		ulong uID = GetComponent<PlacedObjectID>().GetUID();
		List<GameObject> allObjects = DenInteriorManager.GetAllContainedObjects(uID, TagsEnum.ALL, dogsAllowed: false);
		for (int i = 0; i < allObjects.Count; i++)
		{
			ExpelObject(allObjects[i]);
			yield return frameWait;
		}
		currentExpelRoutine = null;
	}

	public void ExpelObject(GameObject obj)
	{
		Rigidbody[] componentsInChildren = obj.GetComponentsInChildren<Rigidbody>();
		if (componentsInChildren.Length == 0)
		{
			Debug.LogError(string.Concat("Cannot expel an object: ", obj, " from a den because it has no physics."));
			return;
		}
		Vector3 position = interactibleDogDenRef.GetInteractionPointTransform().position;
		Vector3 position2 = componentsInChildren[0].transform.position;
		Vector3 vector = position;
		ObjectUtil.AllowPhysics(obj, val: false);
		Vector3 vector2 = (position2 - vector) * -1f;
		ObjectConnectionsManager.OnObjectTeleported(obj, vector2);
		obj.transform.position += vector2;
		obj.GetComponent<BoundingBoxComponent>().ForceUpdateBoundingBox();
		if (!obj.GetComponent<BoundingBoxComponent>().MoveToGoodLocation())
		{
			Debug.LogError(string.Concat("Failed to find a good location for obj: ", obj, " to be expelled from its current den. Destroying it to prevent issues. Sorry."));
			Object.Destroy(obj);
			return;
		}
		ObjectUtil.AllowPhysics(obj, val: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].velocity = Vector3.zero;
			componentsInChildren[i].angularVelocity = Vector3.zero;
			componentsInChildren[i].AddExplosionForce(1500f, position, 0f, 5f);
		}
	}

	public void CollectDirt(GameObject dirtClump)
	{
		if (dirtClumps < requiredDirtClumps)
		{
			dirtClumps++;
			Vector3 position = dirtClump.GetComponentInChildren<Rigidbody>().transform.position;
			GameObject original = dirtCollectedParticles;
			if (isSnowy)
			{
				original = snowCollectedParticles;
			}
			Object.Instantiate(original, position, Quaternion.identity);
			DisplayDirtCollectedMessage(position);
			Object.Destroy(dirtClump);
			AudioController.Play(dirtCollectSound, position);
		}
	}

	private void DisplayDirtCollectedMessage(Vector3 pos)
	{
		GameObject obj = Object.Instantiate(worldMessagePrefab, pos + messageOffset, Quaternion.identity);
		obj.transform.localScale = Vector3.one;
		WorldMessage component = obj.GetComponent<WorldMessage>();
		component.SetFadeTime(1.5f);
		component.SetDisplayColor(Color.green);
		component.SetDisplayMessage(dirtCollectedMessage);
	}

	public bool IsCompleted()
	{
		return currentStage >= DenStage.STAGE_1;
	}

	public bool IsExpandable()
	{
		if (!IsCompleted())
		{
			return false;
		}
		if (instantiatedInteriorRef == null)
		{
			return false;
		}
		return instantiatedInteriorRef.CanExpand();
	}

	public bool IsEmpty()
	{
		return currentOccupants.Count == 0;
	}

	public void SetStage(DenStage newStage, int? interiorIndex = null, bool fromPlacementGhost = false)
	{
		GetObjectForStage(currentStage).SetActive(value: false);
		currentStage = newStage;
		GetObjectForStage(currentStage).SetActive(value: true);
		if (!fromPlacementGhost)
		{
			if (currentStage > DenStage.CLEARED && instantiatedInteriorRef == null)
			{
				CreateDenInterior(interiorIndex);
			}
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER).Rebuild();
		}
	}

	public GameObject GetObjectForStage(DenStage stage)
	{
		switch (stage)
		{
		case DenStage.EMPTY:
			return stageEmpty;
		case DenStage.CLEARED:
			return stageCleared;
		case DenStage.STAGE_1:
			return stage_1;
		default:
			Debug.LogError("No object listed for den stage: " + stage);
			return null;
		}
	}

	private void ClearStages()
	{
		foreach (DenStage value in EnumUtils.GetValues<DenStage>())
		{
			GetObjectForStage(value).SetActive(value: false);
		}
	}

	public void FinalizeDenConstruction(GameObject dog, DenCallback callbackRef)
	{
		if (isBeingFinalized)
		{
			dog.GetComponent<DogAI>().ForceInterruptBehavior();
			return;
		}
		isBeingFinalized = true;
		activeClearAreaRoutine = StartCoroutine(ClearAreaRoutine(dog, DenStage.STAGE_1, callbackRef));
	}

	private IEnumerator ClearAreaRoutine(GameObject dog, DenStage nextStage, DenCallback callbackRef)
	{
		GetObjectForStage(nextStage).SetActive(value: true);
		bbcRef.ForceUpdateBoundingBox();
		GetObjectForStage(nextStage).SetActive(value: false);
		float force = 3000f;
		float upwardsMod = 3f;
		float forceRadius = 0f;
		float maxBound = bbcRef.GetMaxBound();
		Vector3 forcePos = bbcRef.GetBoxCenter();
		dogClearingArea = dog;
		DogHider.HideDog(dogRegRef.GetIDFromDog(dog));
		digAudioObject = AudioController.Play(denConstructionStartedSound, forcePos);
		digAudioObject = AudioController.Play(denInProgressSound, forcePos);
		instantiatedConstructionParticles = Object.Instantiate(constructionParticles, forcePos + Vector3.up * -1f, Quaternion.identity);
		ParticleSystem.ShapeModule shape = instantiatedConstructionParticles.GetComponent<ParticleSystem>().shape;
		shape.radius = maxBound - 1f;
		shape = instantiatedConstructionParticles.GetComponentInChildren<ParticleSystem>().shape;
		shape.radius = maxBound;
		float buildTime = 10f;
		float impulseTime = 0.5f;
		WaitForSeconds impulseWait = new WaitForSeconds(impulseTime);
		while (buildTime > 0f)
		{
			yield return impulseWait;
			buildTime -= impulseTime;
			List<RaycastHit> globalIntersections = bbcRef.GetGlobalIntersections(allowDogIntersection: false, forceCheck: true, null, updateBoundingBox: false);
			for (int i = 0; i < globalIntersections.Count; i++)
			{
				if (globalIntersections[i].rigidbody != null)
				{
					globalIntersections[i].rigidbody.AddExplosionForce(force, forcePos, forceRadius, upwardsMod);
				}
			}
		}
		OnClearAreaRoutineFinished(fromDestroy: false);
		SetStage(nextStage);
		if (GetIsSnowy())
		{
			ApplyDenUpgrade(DenUpgradeType.SNOWY, fromLoad: true);
		}
		dog.GetComponent<DogDenController>().EnterDen(base.gameObject);
		GetComponent<ObjectIndicatorController>().OnDenFinalized();
		bbcRef.ForceUpdateBoundingBox();
		bbcRef.GetCurrentRoom().ClearSpaceForObject(base.gameObject);
		AudioController.Play(denCreatedSound, forcePos);
		GameObject original = denCreatedParticles;
		if (isSnowy)
		{
			original = denCreatedParticlesSnow;
		}
		Object.Instantiate(original, bbcRef.GetBoxCenter() + bbcRef.GetBoxSize().y * Vector3.up, Quaternion.identity);
		GoalsController.ReportGoalEvent(GoalCondition.CONSTRUCT_DEN);
		callbackRef?.Invoke();
	}

	private void OnClearAreaRoutineFinished(bool fromDestroy)
	{
		if (dogClearingArea != null)
		{
			DogHider.UnhideDog(dogRegRef.GetIDFromDog(dogClearingArea));
			if (fromDestroy)
			{
				dogClearingArea.GetComponent<DogAI>().ForceInterruptBehavior();
			}
			dogClearingArea = null;
		}
		Object.Destroy(instantiatedConstructionParticles);
		instantiatedConstructionParticles = null;
		if (digAudioObject != null)
		{
			digAudioObject.Stop(0.25f);
			digAudioObject = null;
		}
		isBeingFinalized = false;
		activeClearAreaRoutine = null;
	}

	private void CreateDenInterior(int? interiorIndex = null)
	{
		GameObject gameObject = DenInteriorManager.CreateDenInterior(denInteriorPrefab, GetComponent<PlacedObjectID>().GetUID(), this, interiorIndex);
		instantiatedInteriorRef = gameObject.GetComponent<DogDenInterior>();
		instantiatedInteriorRef.SetIsSnowy(isSnowy);
	}
}
