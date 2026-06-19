using I2.Loc;
using UnityEngine;

public class DogCore : MonoBehaviour
{
	public string dogName;

	public SaveableDogGene dogGene;

	public DogAge dogAge;

	public DogLabelType labelType;

	public SaveableThumbSet thumbSet;

	public DeathReason dogDeathReason;

	public SaveableDogProfile dogProfile;

	public SaveableDogPersonality dogPersonality;

	public InventoryItem crackedCoreObject;

	public RoomCustomizationObject dogMemorialObject;

	public GameObject actionParticles;

	public GameObject coreCrackParticles;

	public GameObject worldMessagePrefab;

	private Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private string dogCoreCrackSound = "dogCore_crack";

	private string objectDestroySound = "object_destroy";

	private GameObject thumbnailDog;

	private bool isRealCore = true;

	private float currentTimer;

	private float autoCollectTimer = 10f;

	private float autoCollectionJiggle = 5f;

	private void Awake()
	{
		currentTimer = Random.Range(0f - autoCollectionJiggle, 0f);
	}

	public void Update()
	{
		if (!GameSettings.IsPassiveModeEnabled() || !GameSettings.PassiveModeAutoCollectCores() || !isRealCore)
		{
			return;
		}
		if (!CompareTag(Tags.DOG_CORE))
		{
			isRealCore = false;
			return;
		}
		currentTimer += Time.deltaTime;
		if (currentTimer >= autoCollectTimer)
		{
			Vector3 objCenter = ObjectUtil.GetObjCenter(base.gameObject);
			Object.Instantiate(actionParticles, objCenter, Quaternion.identity);
			AudioController.Play(objectDestroySound, objCenter);
			Object.Destroy(base.gameObject);
		}
	}

	public void SetDog(SaveableDog dog)
	{
		dogGene = dog.dogGene;
		dogName = dog.dogName;
		thumbSet = dog.thumbSet;
		dogAge = dog.brain.dogAge;
		labelType = dog.labelType;
		dogDeathReason = dog.brain.deathReason;
		dogProfile = dog.dogProfile.GetCopy();
		dogPersonality = dog.brain.personality.GetCopy();
	}

	public void TransferDogDataFromCore(DogCore oldCore)
	{
		dogGene = oldCore.dogGene;
		dogName = oldCore.dogName;
		dogAge = oldCore.dogAge;
		thumbSet = oldCore.thumbSet;
		labelType = oldCore.labelType;
		dogProfile = oldCore.dogProfile;
		dogDeathReason = oldCore.dogDeathReason;
		if (oldCore.dogPersonality != null)
		{
			dogPersonality = oldCore.dogPersonality;
		}
		else
		{
			dogPersonality = new SaveableDogPersonality(new DogPersonality(traitsAllowed: false));
		}
	}

	public void SaveCore(SaveableDogCore core)
	{
		core.dogGene = dogGene.GetCopy();
		core.dogName = dogName;
		core.dogAge = dogAge;
		core.thumbSet = thumbSet;
		core.labelType = labelType;
		core.dogDeathReason = dogDeathReason;
		core.dogProfile = dogProfile.GetCopy();
		core.dogPersonality = dogPersonality.GetCopy();
		if (thumbSet != null)
		{
			core.defaultThumbnail = thumbSet.defaultPortrait.Load();
		}
	}

	public void LoadSaveableDogCore(SaveableDogCore core)
	{
		dogGene = core.dogGene.GetCopy();
		MasterDogGene.MigrateSaveableDogGene(dogGene);
		dogName = core.dogName;
		dogAge = core.dogAge;
		thumbSet = core.thumbSet;
		labelType = core.labelType;
		dogDeathReason = core.dogDeathReason;
		dogProfile = core.dogProfile.GetCopy();
		if (core.dogPersonality != null)
		{
			dogPersonality = core.dogPersonality.GetCopy();
		}
		else
		{
			dogPersonality = new SaveableDogPersonality(new DogPersonality(traitsAllowed: false));
		}
		if (thumbSet == null || thumbSet.defaultPortrait == null)
		{
			CacheThumbnail();
		}
	}

	public void Crack()
	{
		Vector3 position = GetComponentInChildren<Rigidbody>().transform.position;
		GameObject gameObject = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).TrySpawnItem(crackedCoreObject, position, null, moveToGoodLocation: false);
		if (gameObject == null)
		{
			Debug.LogError("Not able to spawn cracked core! Oops!");
			return;
		}
		CoreQuality coreQuality = GetCoreQuality();
		gameObject.GetComponent<CrackedDogCore>().SetAssociatedCoreQuality(coreQuality);
		Object.Instantiate(coreCrackParticles, position, Quaternion.identity);
		AudioController.Play(dogCoreCrackSound, position);
		CreateGoopPuddle(position);
		GetComponent<RegisterTaggedObject>().SetSafeDestroy();
		Object.Destroy(base.gameObject);
		GoalsController.ReportGoalEvent(GoalCondition.CRACK_CORE);
	}

	public CoreQuality GetCoreQuality()
	{
		CoreQuality result = CoreQuality.HIGH;
		if (dogAge < DogAge.ADULT)
		{
			result = CoreQuality.LOW;
		}
		else if (dogDeathReason != DeathReason.OLD_AGE && dogDeathReason != DeathReason.NONE)
		{
			result = CoreQuality.STANDARD;
		}
		return result;
	}

	private void CreateGoopPuddle(Vector3 spawnPos)
	{
		LiquidInfo liquidForType = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER).GetLiquidForType(LiquidType.CORE_GOOP);
		RaycastUtil.StageRaycast(spawnPos, Vector3.down, out var hitInfo, 50f);
		Vector3 position = hitInfo.point + Vector3.up * 0.1f;
		GameObject obj = new GameObject("Core Goop Puddle Creator");
		obj.transform.position = position;
		Liquid liquid = obj.AddComponent<Liquid>();
		liquid.ApplyLiquid(liquidForType);
		liquid.CreatePuddle();
		Object.Destroy(obj);
	}

	public void Memorialize()
	{
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		ulong? roomUID = component.GetRoomUID(requireInRoom: true);
		if (!roomUID.HasValue)
		{
			DisplayMemorialError();
			return;
		}
		RoomBase component2 = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER).GetObjectForUID(roomUID.Value)
			.GetComponent<RoomBase>();
		Vector3 chosenPosition = Vector3.zero;
		Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(component.GetBoxCenter(), component2);
		if (!ObjectPlacementManager.CanReserveSpaceForObject(component2, dogMemorialObject, gridSquareForPositionAndRoom, ref chosenPosition))
		{
			DisplayMemorialError();
			return;
		}
		PlacedObjectInfo placedObjectInfo = ObjectPlacementManager.PlaceObjectManually(component2, dogMemorialObject, gridSquareForPositionAndRoom, 0, ignoreDogs: false);
		if (placedObjectInfo == null || placedObjectInfo.objectRef == null)
		{
			DisplayMemorialError();
			return;
		}
		placedObjectInfo.objectRef.GetComponent<DogMemorial>().SetDogInfo(this);
		GetComponent<RegisterTaggedObject>().SetSafeDestroy();
		Object.Destroy(base.gameObject);
		GoalsController.ReportGoalEvent(GoalCondition.CREATE_MEMORIAL);
	}

	private void DisplayMemorialError()
	{
		BoundingBoxComponent component = GetComponent<BoundingBoxComponent>();
		GameObject obj = Object.Instantiate(worldMessagePrefab, component.GetBoxCenter() + messageOffset, Quaternion.identity);
		obj.transform.localScale = Vector3.one;
		WorldMessage component2 = obj.GetComponent<WorldMessage>();
		component2.SetFadeTime(0.75f);
		component2.SetDisplayColor(Color.red);
		component2.SetDisplayMessage(ScriptLocalization.GUI.GUI_MESSAGE_AREABLOCKED);
	}

	private void CacheThumbnail()
	{
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).RequestNewDog(new Vector3(1000f, 1000f, 1000f), Quaternion.identity, dogGene, null, manualDog: false, dogProfile: dogProfile, callback: OnThumbnailDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: dogAge, customDogAgeProgress: 0f);
	}

	private void OnThumbnailDogCreated(GameObject dog)
	{
		thumbnailDog = dog;
		Rigidbody[] componentsInChildren = thumbnailDog.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
			obj.isKinematic = true;
		}
		DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		globalComponent.StartCoroutine(globalComponent.GenerateDogThumbnailFromDog(dog, 0uL, highQuality: false, OnThumbnailGenerated));
	}

	private void OnThumbnailGenerated(ThumbnailSet newSet)
	{
		if (thumbnailDog != null)
		{
			Object.Destroy(thumbnailDog);
			thumbnailDog = null;
		}
		thumbSet = new SaveableThumbSet(newSet);
	}
}
